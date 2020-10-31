using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

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
            for (var i = 0; i < rows; i++)
            {
                AddARow(i);
            }

            //Table style

            //Column header style

            Table.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            //Row header style

            Table.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
                        x.Key.Position == Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                        (Table.CurrentCell.RowIndex + 1).ToString()).Key;
                    CurrentCell.Dependencies = TableIdentifier.FirstOrDefault(x =>
                        x.Key.Position == Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                        (Table.CurrentCell.RowIndex + 1).ToString()).Key.Dependencies;
                    CurrentCell.Expression = TableIdentifier.FirstOrDefault(x =>
                        x.Key.Position == Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
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
                    foreach (var dependency in CurrentCell.Dependencies)
                    {
                        var depResult = Calculator.Evaluate(dependency.Expression);

                        (string column, int row) = Program.ParseIdentifier(dependency.Position);
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
                sfd.Filter = @"Excel (.xlsx)| *.xlsx";
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
                            MessageBox.Show(Messages.ImpossibleToWriteData + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Excel.Application xcelApp = new Excel.Application();
                            Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
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
                            xcelApp.Quit();

                            ReleaseObject(worksheet);
                            ReleaseObject(workbook);
                            ReleaseObject(xcelApp);

                            MessageBox.Show(Messages.SuccesfulExport, "Info");
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
                MessageBox.Show(Messages.NoRecord, "Info");
            }
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            
            //TODO : Fix import
            
            DataTable dt = new DataTable("dataTable");
            DataSet dsSource = new DataSet("dataSet");
            dt.Reset();

            DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var excelObj = new Excel.Application();
                var filedialogExcel = new OpenFileDialog
                {
                    Title = "Select file",
                    InitialDirectory = @"c:\",
                    Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
                //filedlgExcel.FileName = textBox1.Text;
                if (filedialogExcel.ShowDialog() == DialogResult.OK)
                {

                    var workbook = excelObj.Workbooks.Open(filedialogExcel.FileName, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    var nwSheet = (Excel.Worksheet) workbook.Sheets.get_Item(1);
                    var shtRange = nwSheet.UsedRange;
                    for (int cnum = 1; cnum <= shtRange.Columns.Count; cnum++)
                    {
                        if ((shtRange.Cells[1, cnum] as Excel.Range)?.Value2 != null)
                        {
                            dt.Columns.Add(new DataColumn((shtRange.Cells[1, cnum] as Excel.Range)?.Value2.ToString()));
                        }
                    }

                    dt.AcceptChanges();
                    string[] columnNames = new String[dt.Columns.Count];
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        columnNames[0] = dt.Columns[i].ColumnName;
                    }
                    //string[] columnNames = (from dc in dt.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();


                    for (int rnum = 2; rnum <= shtRange.Rows.Count; rnum++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int cnum = 1; cnum <= shtRange.Columns.Count; cnum++)
                        {
                            if ((shtRange.Cells[rnum, cnum] as Excel.Range)?.Value2 != null)
                            {
                                
                                // NotImplementedException 
                                dr[cnum-1] = (shtRange.Cells[rnum, cnum] as Excel.Range)?.Value2.ToString();
                            }
                        }

                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }

                    workbook.Close(true, Missing.Value, Missing.Value);
                    excelObj.Quit();

                    Table.DataSource = dt;
                }
            }
        }



        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Messages.ReleasingObjectExc + ex.Message, "Error");
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
