using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;

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
                        x.Key.position == Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                        (Table.CurrentCell.RowIndex + 1).ToString()).Key;
                    CurrentCell.Dependencies = TableIdentifier.FirstOrDefault(x =>
                        x.Key.position == Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                        (Table.CurrentCell.RowIndex + 1).ToString()).Key.Dependencies;
                    CurrentCell.expression = TableIdentifier.FirstOrDefault(x =>
                        x.Key.position == Program.PrintColumnName(Table.CurrentCell.ColumnIndex) +
                        (Table.CurrentCell.RowIndex + 1).ToString()).Key.expression;

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
                CurrentCell.expression = CellEditText.Text;

                //expressions[new Cell()] = CellEditText.Text;
                //TableIdentifier[CurrentCell] = result;

                
                // Update dependent cells

                if (CurrentCell.Dependencies.Count > 0)
                {
                    foreach (Cell Dependency in CurrentCell.Dependencies)
                    {
                        var depResult = Calculator.Evaluate(Dependency.expression);

                        (string Column, int Row) = Program.ParseIdentifier(Dependency.position);
                        Table.Rows[Row-1].Cells[Table.Columns[Column].Index].Value = depResult;
                        TableIdentifier[Dependency] = depResult;
                    }
                }


                // Check if temporary dependency not null and update dependencies

                if (CurrentCell.temporaryDependencies.Count > 0)
                {
                    foreach (Cell dependency in CurrentCell.temporaryDependencies)
                    {
                        (Cell temp, double value) = (dependency, TableIdentifier[dependency]);
                        temp.Dependencies = dependency.Dependencies;
                        temp.expression = dependency.expression;
                        temp.Dependencies.Add(CurrentCell);
                        TableIdentifier.Remove(dependency);
                        TableIdentifier.Add(temp, value);
                    }
                }

            }
            catch (Exception exception)
            {
                int line = (new StackTrace(exception, true)).GetFrame(0).GetFileLineNumber();
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
            /*
            if (Table.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < Table.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = Table.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    for (int j = 0; j < Table.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = Table.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
            */
        }


        private void InfoBtn_Click(object sender, EventArgs e)
        {
            var infoForm = new InfoForm();
            infoForm.ShowDialog();
        }
    }
}
