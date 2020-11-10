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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.ImportDestTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter integer size of table:";
            // 
            // AddRow
            // 
            this.AddRow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddRow.Location = new System.Drawing.Point(1336, 61);
            this.AddRow.Name = "AddRow";
            this.AddRow.Size = new System.Drawing.Size(107, 34);
            this.AddRow.TabIndex = 2;
            this.AddRow.Text = "Add Row";
            this.AddRow.UseVisualStyleBackColor = false;
            this.AddRow.Click += new System.EventHandler(this.AddRow_Click);
            // 
            // AddColumn
            // 
            this.AddColumn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddColumn.Location = new System.Drawing.Point(1463, 60);
            this.AddColumn.Name = "AddColumn";
            this.AddColumn.Size = new System.Drawing.Size(107, 34);
            this.AddColumn.TabIndex = 2;
            this.AddColumn.Text = "Add Column";
            this.AddColumn.UseVisualStyleBackColor = false;
            this.AddColumn.Click += new System.EventHandler(this.AddColumn_Click);
            // 
            // CellEditText
            // 
            this.CellEditText.Location = new System.Drawing.Point(446, 62);
            this.CellEditText.Name = "CellEditText";
            this.CellEditText.Size = new System.Drawing.Size(353, 22);
            this.CellEditText.TabIndex = 5;
            // 
            // Table
            // 
            this.Table.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(24, 106);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(1546, 562);
            this.Table.TabIndex = 3;
            this.Table.Text = "dataGridView2";
            this.Table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellClick);
            // 
            // TableRows
            // 
            this.TableRows.Location = new System.Drawing.Point(24, 70);
            this.TableRows.Name = "TableRows";
            this.TableRows.Size = new System.Drawing.Size(75, 22);
            this.TableRows.TabIndex = 6;
            // 
            // TableColumns
            // 
            this.TableColumns.Location = new System.Drawing.Point(121, 69);
            this.TableColumns.Name = "TableColumns";
            this.TableColumns.Size = new System.Drawing.Size(75, 22);
            this.TableColumns.TabIndex = 6;
            // 
            // LabelRows
            // 
            this.LabelRows.AutoSize = true;
            this.LabelRows.Location = new System.Drawing.Point(24, 50);
            this.LabelRows.Name = "LabelRows";
            this.LabelRows.Size = new System.Drawing.Size(42, 17);
            this.LabelRows.TabIndex = 1;
            this.LabelRows.Text = "Rows";
            // 
            // LabelColumns
            // 
            this.LabelColumns.AutoSize = true;
            this.LabelColumns.Location = new System.Drawing.Point(121, 50);
            this.LabelColumns.Name = "LabelColumns";
            this.LabelColumns.Size = new System.Drawing.Size(62, 17);
            this.LabelColumns.TabIndex = 1;
            this.LabelColumns.Text = "Columns";
            // 
            // CreateTableBtn
            // 
            this.CreateTableBtn.Location = new System.Drawing.Point(227, 53);
            this.CreateTableBtn.Name = "CreateTableBtn";
            this.CreateTableBtn.Size = new System.Drawing.Size(135, 42);
            this.CreateTableBtn.TabIndex = 7;
            this.CreateTableBtn.Text = "Create table";
            this.CreateTableBtn.UseVisualStyleBackColor = true;
            this.CreateTableBtn.Click += new System.EventHandler(this.CreateTableBtn_Click);
            // 
            // UpdateCellBtn
            // 
            this.UpdateCellBtn.Location = new System.Drawing.Point(816, 52);
            this.UpdateCellBtn.Name = "UpdateCellBtn";
            this.UpdateCellBtn.Size = new System.Drawing.Size(150, 42);
            this.UpdateCellBtn.TabIndex = 8;
            this.UpdateCellBtn.Text = "Update";
            this.UpdateCellBtn.UseVisualStyleBackColor = true;
            this.UpdateCellBtn.Click += new System.EventHandler(this.UpdateCellBtn_Click);
            // 
            // DelRowBtn
            // 
            this.DelRowBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DelRowBtn.Location = new System.Drawing.Point(1336, 13);
            this.DelRowBtn.Name = "DelRowBtn";
            this.DelRowBtn.Size = new System.Drawing.Size(107, 34);
            this.DelRowBtn.TabIndex = 2;
            this.DelRowBtn.Text = "Delete Row";
            this.DelRowBtn.UseVisualStyleBackColor = false;
            this.DelRowBtn.Click += new System.EventHandler(this.DelRowBtn_Click);
            // 
            // DelColBtn
            // 
            this.DelColBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DelColBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.DelColBtn.Location = new System.Drawing.Point(1463, 13);
            this.DelColBtn.Name = "DelColBtn";
            this.DelColBtn.Size = new System.Drawing.Size(107, 34);
            this.DelColBtn.TabIndex = 2;
            this.DelColBtn.Text = "Delete Column";
            this.DelColBtn.UseVisualStyleBackColor = false;
            this.DelColBtn.Click += new System.EventHandler(this.DelColBtn_Click);
            // 
            // InfoBtn
            // 
            this.InfoBtn.BackColor = System.Drawing.SystemColors.Info;
            this.InfoBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.InfoBtn.Location = new System.Drawing.Point(1116, 13);
            this.InfoBtn.Name = "InfoBtn";
            this.InfoBtn.Size = new System.Drawing.Size(189, 35);
            this.InfoBtn.TabIndex = 9;
            this.InfoBtn.Text = "Information";
            this.InfoBtn.UseVisualStyleBackColor = false;
            this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ExportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportBtn.Location = new System.Drawing.Point(999, 12);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(85, 33);
            this.ExportBtn.TabIndex = 10;
            this.ExportBtn.Text = "Export";
            this.ExportBtn.UseVisualStyleBackColor = false;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // ImportBtn
            // 
            this.ImportBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ImportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImportBtn.Location = new System.Drawing.Point(999, 58);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(85, 33);
            this.ImportBtn.TabIndex = 10;
            this.ImportBtn.Text = "Import";
            this.ImportBtn.UseVisualStyleBackColor = false;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // ImportDestTB
            // 
            this.ImportDestTB.Location = new System.Drawing.Point(1116, 66);
            this.ImportDestTB.Name = "ImportDestTB";
            this.ImportDestTB.Size = new System.Drawing.Size(188, 22);
            this.ImportDestTB.TabIndex = 11;
            this.ImportDestTB.TextChanged += new System.EventHandler(this.ImportDestTB_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1614, 681);
            this.Controls.Add(this.ImportDestTB);
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
            this.Text = "Pavlo Redko";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox ImportDestTB;

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

