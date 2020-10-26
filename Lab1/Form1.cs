using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDataGridView(15, 25);
            Controls.Add(Table);
        }


        public static Cell CurrentCell;

        public static bool IsCyclic(Cell cell)
        {
            return cell.Dependencies.Exists(x => x == CurrentCell);
        }

        private void InitializeDataGridView(int rows, int columns)
        {
            
            Table.Name = "Table";
            Table.TabIndex = 0;
            Table.RowHeadersWidth = 55;
            //Initializing Table

            for (int i = 0; i < columns; i++)
            {
                AddAColumn(i);
            }
            //Table.RowHeadersDefaultCellStyle.Padding = new Padding(3);//helps to get rid of the selection triangle?
            for (int i = 0; i < rows; i++)
            {
                AddARow(i);
            }

            //Table style

            //Column header style

            Table.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            //Row header style

            Table.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Table.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table.RowHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        private void CreateTableBtn_Click(object sender, EventArgs e)
        {
            int rowsNumb = int.Parse(TableRows.Text);
            int colsNumb = int.Parse(TableColumns.Text);

            InitializeDataGridView(rowsNumb, colsNumb);
            Controls.Add(Table);
        }

        private void AddARow(int i)
        {
            DataGridViewRow arow = new DataGridViewRow {HeaderCell = {Value = (i + 1).ToString()}};
            Table.Rows.Add(arow);
        }

        private void AddAColumn(int i)
        {
            DataGridViewTextBoxColumn acolumn = new DataGridViewTextBoxColumn();
            acolumn.HeaderText = Program.Reverse(Program.ComputeColumnName(i));
            acolumn.Name = acolumn.HeaderText;
            acolumn.Width = 60;
            acolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //make a Style template to be used in the grid
            DataGridViewCell acell = new DataGridViewTextBoxCell();
            acell.Style.BackColor = Color.SeaShell;
            acell.Style.SelectionBackColor = Color.FromArgb(196,207,255);
            acolumn.CellTemplate = acell;
            Table.Columns.Add(acolumn);
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            AddARow(Table.Rows.Count - 1);
        }

        private void AddColumn_Click(object sender, EventArgs e)
        {
            AddAColumn(Table.Columns.Count);
        }

        private void DelRowBtn_Click(object sender, EventArgs e)
        {
            Table.Rows.RemoveAt(Table.Rows.Count - 2);
        }

        private void DelColBtn_Click(object sender, EventArgs e)
        {
            Table.Columns.RemoveAt(Table.Columns.Count - 1);
        }

        public static Dictionary<Cell, double> TableIdentifier = new Dictionary<Cell, double>(new CellEqualityComparer());

        public static (string, string) TempDependency;
        //public static Dictionary<string, List<string>> Dependencies = new Dictionary<string, List<string>>();

        //public static Dictionary<string, string> expressions = new Dictionary<string, string>();

        private void UpdateCellBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableIdentifier.ContainsKey(new Cell(Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                                                         (Table.CurrentCell.RowIndex + 1))))
                {
                    CurrentCell = TableIdentifier.FirstOrDefault(x =>
                        x.Key.position == Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                        (Table.CurrentCell.RowIndex + 1).ToString()).Key;
                    CurrentCell.Dependencies = TableIdentifier.FirstOrDefault(x =>
                        x.Key.position == Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                        (Table.CurrentCell.RowIndex + 1).ToString()).Key.Dependencies;
                    CurrentCell.Expression = TableIdentifier.FirstOrDefault(x =>
                        x.Key.position == Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                        (Table.CurrentCell.RowIndex + 1).ToString()).Key.Expression;

                }
                else
                {
                    CurrentCell = new Cell(Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                                                         (Table.CurrentCell.RowIndex + 1));
                }

                
                // Evaluate expression
                var result = Calculator.Evaluate(CellEditText.Text);

                // Update current cell
                Table.Rows[Table.CurrentCell.RowIndex].Cells[Table.CurrentCell.ColumnIndex].Value = result;

                //Add current cell to table identifier
                TableIdentifier[CurrentCell] = result;

                //Add expression to variable in cell
                if (string.IsNullOrEmpty(CurrentCell.Expression))
                {
                    CurrentCell.Expression = CellEditText.Text;
                }

                //expressions[new Cell()] = CellEditText.Text;
                //TableIdentifier[CurrentCell] = result;

                
                // Update dependent cells

                if (CurrentCell.Dependencies.Count > 0)
                {
                    foreach (Cell dependency in CurrentCell.Dependencies)
                    {
                        var depResult = Calculator.Evaluate(dependency.Expression);

                        (string column, int row) = Program.ParseIdentifier(dependency.position);
                        Table.Rows[row-1].Cells[Table.Columns[column].Index].Value = depResult;
                        TableIdentifier[dependency] = depResult;
                    }
                }


                // Check if temporary dependency not null and update dependencies

                if (CurrentCell.TemporaryDependencies.Count > 0)
                {
                    foreach (Cell dependency in CurrentCell.TemporaryDependencies)
                    {
                        (Cell temp, double value) = (dependency, TableIdentifier[dependency]);
                        temp.Dependencies = dependency.Dependencies;
                        temp.Expression = dependency.Expression;
                        temp.Dependencies.Add(CurrentCell);
                        TableIdentifier.Remove(dependency);
                        TableIdentifier.Add(temp, value);
                    }
                }

            }
            catch (Exception exception)
            {
                int line = new StackTrace(exception, true).GetFrame(0).GetFileLineNumber();
                var errorForm = new ErrorForm(exception.Message + ". Thrown at line " + line);
                errorForm.ShowDialog();
                
            }

            /*catch (ArgumentException argumentException)
            {
                var errorForm = new ErrorForm(argumentException.Message);
                errorForm.ShowDialog();
            }
            catch (DivideByZeroException zeroDiv)
            {
                var errorForm = new ErrorForm(zeroDiv.Message);
                errorForm.ShowDialog();
            }*/
            
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            if (Table.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel (.xlsx)|  *.xlsx";
                sfd.FileName = "Output.xlsx";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Excel.Application XcelApp = new Excel.Application();
                            Excel._Workbook workbook = XcelApp.Workbooks.Add(Type.Missing);
                            Excel._Worksheet worksheet = null;

                            //worksheet = (Excel._Worksheet) workbook.Sheets["Sheet1"];
                            worksheet = (Excel._Worksheet) workbook.ActiveSheet;
                            worksheet.Name = "Output";
                            worksheet.Application.ActiveWindow.SplitRow = 1;
                            worksheet.Application.ActiveWindow.FreezePanes = true;


                            for (int i = 0; i < Table.Rows.Count; i++)
                            {
                                for (int j = 0; j < Table.Columns.Count; j++)
                                {
                                    if (Table.Rows[i].Cells[j].Value != null)
                                    {
                                        worksheet.Cells[i + 1, j + 1] = Table.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                            }

                            worksheet.Columns.AutoFit();
                            workbook.SaveAs(sfd.FileName);
                            XcelApp.Quit();

                            ReleaseObject(worksheet);
                            ReleaseObject(workbook);
                            ReleaseObject(XcelApp);

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog()
                    {Filter = "*.xls|*.xlsx|Excel WorkBook|Excel WorkBook 97-2003", ValidateNames = true})
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        ofd.FileName +
                                        ";Extended Properties='Excel 12.0;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        System.Data.DataTable data = new System.Data.DataTable();
                        sda.Fill(data);
                        Table.DataSource = data;
                        InitializeDataGridView(Table.RowCount, Table.ColumnCount);
                        Controls.Add(Table);
                    }
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.ToString();
            }
        }

    

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.Message, "Error");
            }
            finally
            {
                GC.Collect();
            }
        }


        private void InfoBtn_Click(object sender, EventArgs e)
        {
            var infoForm = new InfoForm();
            infoForm.ShowDialog();
        }
    }
}
