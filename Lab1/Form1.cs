﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void InitializeDataGridView(int rows, int columns)
        {
            /*Table.AllowUserToAddRows = false;
            Table.AllowUserToDeleteRows = false;
            Table.AllowUserToResizeRows = false;*/
            //Table.EnableHeadersVisualStyles = false;
            //Table.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //Table.EditMode = DataGridViewEditMode.EditOnKeystroke;
            //Table.ShowEditingIcon = false;
            Table.Name = "Table";
            Table.TabIndex = 0;
            Table.RowHeadersWidth = 55;
            //used to attach event-handlers to the events of the editing control(nice name!)
            //Table.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(MyTable_EditingControlShowing);
            // not implemented here, but I still like the name DataGridViewEditingControlShowingEventHandler :o) LOL
            /*Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            Table.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;*/

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
            
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static string ComputeColumnName(int number)
        {
            string columnName = "";
            if(number < 26)
            {
                return ((char)(number % 26 + 65)).ToString();
            }
            columnName += ((char)(number % 26 + 65)).ToString();
            columnName += ComputeColumnName(number / 26 - 1);
            return columnName;
        }

        private void AddAColumn(int i)
        {
            DataGridViewTextBoxColumn acolumn = new DataGridViewTextBoxColumn();
            acolumn.HeaderText = Reverse(ComputeColumnName(i));
            acolumn.Name = "Column" + i.ToString();
            acolumn.Width = 60;
            acolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //make a Style template to be used in the grid
            DataGridViewCell acell = new DataGridViewTextBoxCell();
            acell.Style.BackColor = Color.SeaShell;
            acell.Style.SelectionBackColor = Color.Wheat;
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


        private void Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCellBtn_Click(object sender, EventArgs e)
        {
            Table.Rows[Table.CurrentCell.RowIndex].Cells[Table.CurrentCell.ColumnIndex].Value = CellEditText.Text;
           
        }
    }
}
