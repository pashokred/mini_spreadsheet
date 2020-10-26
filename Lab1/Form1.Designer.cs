namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.AddRow = new System.Windows.Forms.Button();
            this.AddColumn = new System.Windows.Forms.Button();
            this.CellEditText = new System.Windows.Forms.TextBox();
            this.Table = new System.Windows.Forms.DataGridView();
            this.TableRows = new System.Windows.Forms.TextBox();
            this.TableColumns = new System.Windows.Forms.TextBox();
            this.LabelRows = new System.Windows.Forms.Label();
            this.LabelColumns = new System.Windows.Forms.Label();
            this.CreateTableBtn = new System.Windows.Forms.Button();
            this.UpdateCellBtn = new System.Windows.Forms.Button();
            this.DelRowBtn = new System.Windows.Forms.Button();
            this.DelColBtn = new System.Windows.Forms.Button();
            this.InfoBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.ImportBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter integer size of table:";
            // 
            // AddRow
            // 
            this.AddRow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddRow.Location = new System.Drawing.Point(1169, 57);
            this.AddRow.Name = "AddRow";
            this.AddRow.Size = new System.Drawing.Size(94, 32);
            this.AddRow.TabIndex = 2;
            this.AddRow.Text = "Add Row";
            this.AddRow.UseVisualStyleBackColor = false;
            this.AddRow.Click += new System.EventHandler(this.AddRow_Click);
            // 
            // AddColumn
            // 
            this.AddColumn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddColumn.Location = new System.Drawing.Point(1280, 56);
            this.AddColumn.Name = "AddColumn";
            this.AddColumn.Size = new System.Drawing.Size(94, 32);
            this.AddColumn.TabIndex = 2;
            this.AddColumn.Text = "Add Column";
            this.AddColumn.UseVisualStyleBackColor = false;
            this.AddColumn.Click += new System.EventHandler(this.AddColumn_Click);
            // 
            // CellEditText
            // 
            this.CellEditText.Location = new System.Drawing.Point(390, 58);
            this.CellEditText.Name = "CellEditText";
            this.CellEditText.PlaceholderText = "This text will be in the selected cell after clicking Update";
            this.CellEditText.Size = new System.Drawing.Size(309, 23);
            this.CellEditText.TabIndex = 5;
            // 
            // Table
            // 
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(21, 99);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(1353, 527);
            this.Table.TabIndex = 3;
            this.Table.Text = "dataGridView2";
            // 
            // TableRows
            // 
            this.TableRows.Location = new System.Drawing.Point(21, 66);
            this.TableRows.Name = "TableRows";
            this.TableRows.Size = new System.Drawing.Size(66, 23);
            this.TableRows.TabIndex = 6;
            // 
            // TableColumns
            // 
            this.TableColumns.Location = new System.Drawing.Point(106, 65);
            this.TableColumns.Name = "TableColumns";
            this.TableColumns.Size = new System.Drawing.Size(66, 23);
            this.TableColumns.TabIndex = 6;
            // 
            // LabelRows
            // 
            this.LabelRows.AutoSize = true;
            this.LabelRows.Location = new System.Drawing.Point(21, 47);
            this.LabelRows.Name = "LabelRows";
            this.LabelRows.Size = new System.Drawing.Size(35, 15);
            this.LabelRows.TabIndex = 1;
            this.LabelRows.Text = "Rows";
            // 
            // LabelColumns
            // 
            this.LabelColumns.AutoSize = true;
            this.LabelColumns.Location = new System.Drawing.Point(106, 47);
            this.LabelColumns.Name = "LabelColumns";
            this.LabelColumns.Size = new System.Drawing.Size(55, 15);
            this.LabelColumns.TabIndex = 1;
            this.LabelColumns.Text = "Columns";
            // 
            // CreateTableBtn
            // 
            this.CreateTableBtn.Location = new System.Drawing.Point(199, 50);
            this.CreateTableBtn.Name = "CreateTableBtn";
            this.CreateTableBtn.Size = new System.Drawing.Size(118, 39);
            this.CreateTableBtn.TabIndex = 7;
            this.CreateTableBtn.Text = "Create table";
            this.CreateTableBtn.UseVisualStyleBackColor = true;
            this.CreateTableBtn.Click += new System.EventHandler(this.CreateTableBtn_Click);
            // 
            // UpdateCellBtn
            // 
            this.UpdateCellBtn.Location = new System.Drawing.Point(714, 49);
            this.UpdateCellBtn.Name = "UpdateCellBtn";
            this.UpdateCellBtn.Size = new System.Drawing.Size(131, 39);
            this.UpdateCellBtn.TabIndex = 8;
            this.UpdateCellBtn.Text = "Update";
            this.UpdateCellBtn.UseVisualStyleBackColor = true;
            this.UpdateCellBtn.Click += new System.EventHandler(this.UpdateCellBtn_Click);
            // 
            // DelRowBtn
            // 
            this.DelRowBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DelRowBtn.Location = new System.Drawing.Point(1169, 12);
            this.DelRowBtn.Name = "DelRowBtn";
            this.DelRowBtn.Size = new System.Drawing.Size(94, 32);
            this.DelRowBtn.TabIndex = 2;
            this.DelRowBtn.Text = "Delete Row";
            this.DelRowBtn.UseVisualStyleBackColor = false;
            this.DelRowBtn.Click += new System.EventHandler(this.DelRowBtn_Click);
            // 
            // DelColBtn
            // 
            this.DelColBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DelColBtn.Location = new System.Drawing.Point(1280, 12);
            this.DelColBtn.Name = "DelColBtn";
            this.DelColBtn.Size = new System.Drawing.Size(94, 32);
            this.DelColBtn.TabIndex = 2;
            this.DelColBtn.Text = "Delete Column";
            this.DelColBtn.UseVisualStyleBackColor = false;
            this.DelColBtn.Click += new System.EventHandler(this.DelColBtn_Click);
            // 
            // InfoBtn
            // 
            this.InfoBtn.BackColor = System.Drawing.SystemColors.Info;
            this.InfoBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.InfoBtn.Location = new System.Drawing.Point(1015, 12);
            this.InfoBtn.Name = "InfoBtn";
            this.InfoBtn.Size = new System.Drawing.Size(127, 33);
            this.InfoBtn.TabIndex = 9;
            this.InfoBtn.Text = "Information";
            this.InfoBtn.UseVisualStyleBackColor = false;
            this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ExportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportBtn.Location = new System.Drawing.Point(873, 57);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(74, 31);
            this.ExportBtn.TabIndex = 10;
            this.ExportBtn.Text = "Export";
            this.ExportBtn.UseVisualStyleBackColor = false;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // ImportBtn
            // 
            this.ImportBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ImportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImportBtn.Location = new System.Drawing.Point(873, 15);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(74, 31);
            this.ImportBtn.TabIndex = 10;
            this.ImportBtn.Text = "Import";
            this.ImportBtn.UseVisualStyleBackColor = false;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 638);
            this.Controls.Add(this.ImportBtn);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.InfoBtn);
            this.Controls.Add(this.UpdateCellBtn);
            this.Controls.Add(this.CreateTableBtn);
            this.Controls.Add(this.TableColumns);
            this.Controls.Add(this.TableRows);
            this.Controls.Add(this.CellEditText);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.DelColBtn);
            this.Controls.Add(this.AddColumn);
            this.Controls.Add(this.DelRowBtn);
            this.Controls.Add(this.AddRow);
            this.Controls.Add(this.LabelColumns);
            this.Controls.Add(this.LabelRows);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddRow;
        private System.Windows.Forms.Button AddColumn;
        private System.Windows.Forms.TextBox CellEditText;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.TextBox TableRows;
        private System.Windows.Forms.TextBox TableColumns;
        private System.Windows.Forms.Label LabelRows;
        private System.Windows.Forms.Label LabelColumns;
        private System.Windows.Forms.Button CreateTableBtn;
        private System.Windows.Forms.Button UpdateCellBtn;
        private System.Windows.Forms.Button DelRowBtn;
        private System.Windows.Forms.Button DelColBtn;
        private System.Windows.Forms.Button InfoBtn;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button ImportBtn;
    }
}

