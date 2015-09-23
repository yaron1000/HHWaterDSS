namespace DatabaseManageBar
{
    partial class fm_CreateDatabaseTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.cb_IfInsert = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ExcelIntoSql = new System.Windows.Forms.Button();
            this.btn_ChooseExcelPath = new System.Windows.Forms.Button();
            this.tb_TableName = new System.Windows.Forms.TextBox();
            this.tb_FieldsRow = new System.Windows.Forms.TextBox();
            this.tb_ExcelPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cb_IfInsert
            // 
            // 
            // 
            // 
            this.cb_IfInsert.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cb_IfInsert.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_IfInsert.Location = new System.Drawing.Point(256, 168);
            this.cb_IfInsert.Name = "cb_IfInsert";
            this.cb_IfInsert.Size = new System.Drawing.Size(131, 23);
            this.cb_IfInsert.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_IfInsert.TabIndex = 12;
            this.cb_IfInsert.Text = "是否同时导入数据";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(52, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "输入表名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(52, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "输入表头所在的行：";
            // 
            // btn_ExcelIntoSql
            // 
            this.btn_ExcelIntoSql.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ExcelIntoSql.Location = new System.Drawing.Point(177, 223);
            this.btn_ExcelIntoSql.Name = "btn_ExcelIntoSql";
            this.btn_ExcelIntoSql.Size = new System.Drawing.Size(75, 23);
            this.btn_ExcelIntoSql.TabIndex = 8;
            this.btn_ExcelIntoSql.Text = "确定";
            this.btn_ExcelIntoSql.UseVisualStyleBackColor = true;
            this.btn_ExcelIntoSql.Click += new System.EventHandler(this.btn_ExcelIntoSql_Click);
            // 
            // btn_ChooseExcelPath
            // 
            this.btn_ChooseExcelPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ChooseExcelPath.Location = new System.Drawing.Point(54, 40);
            this.btn_ChooseExcelPath.Name = "btn_ChooseExcelPath";
            this.btn_ChooseExcelPath.Size = new System.Drawing.Size(75, 23);
            this.btn_ChooseExcelPath.TabIndex = 9;
            this.btn_ChooseExcelPath.Text = "选择Excel";
            this.btn_ChooseExcelPath.UseVisualStyleBackColor = true;
            this.btn_ChooseExcelPath.Click += new System.EventHandler(this.btn_ChooseExcelPath_Click);
            // 
            // tb_TableName
            // 
            this.tb_TableName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_TableName.Location = new System.Drawing.Point(189, 117);
            this.tb_TableName.Name = "tb_TableName";
            this.tb_TableName.Size = new System.Drawing.Size(198, 21);
            this.tb_TableName.TabIndex = 5;
            // 
            // tb_FieldsRow
            // 
            this.tb_FieldsRow.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_FieldsRow.Location = new System.Drawing.Point(189, 78);
            this.tb_FieldsRow.Name = "tb_FieldsRow";
            this.tb_FieldsRow.Size = new System.Drawing.Size(198, 21);
            this.tb_FieldsRow.TabIndex = 6;
            this.tb_FieldsRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_FieldsRow_KeyPress);
            // 
            // tb_ExcelPath
            // 
            this.tb_ExcelPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ExcelPath.Location = new System.Drawing.Point(189, 40);
            this.tb_ExcelPath.Name = "tb_ExcelPath";
            this.tb_ExcelPath.Size = new System.Drawing.Size(198, 21);
            this.tb_ExcelPath.TabIndex = 7;
            // 
            // fm_CreateDatabaseTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(499, 315);
            this.Controls.Add(this.cb_IfInsert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ExcelIntoSql);
            this.Controls.Add(this.btn_ChooseExcelPath);
            this.Controls.Add(this.tb_TableName);
            this.Controls.Add(this.tb_FieldsRow);
            this.Controls.Add(this.tb_ExcelPath);
            this.DoubleBuffered = true;
            this.Name = "fm_CreateDatabaseTable";
            this.Text = "导入表格";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX cb_IfInsert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ExcelIntoSql;
        private System.Windows.Forms.Button btn_ChooseExcelPath;
        private System.Windows.Forms.TextBox tb_TableName;
        private System.Windows.Forms.TextBox tb_FieldsRow;
        private System.Windows.Forms.TextBox tb_ExcelPath;
    }
}