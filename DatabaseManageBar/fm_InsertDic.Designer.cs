namespace DatabaseManageBar
{
    partial class fm_InsertDic
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
            this.btn_ExcelIntoSql = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_TableName = new System.Windows.Forms.TextBox();
            this.btn_ChooseExcelPath = new System.Windows.Forms.Button();
            this.tb_ExcelPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_ExcelIntoSql
            // 
            this.btn_ExcelIntoSql.Location = new System.Drawing.Point(206, 191);
            this.btn_ExcelIntoSql.Name = "btn_ExcelIntoSql";
            this.btn_ExcelIntoSql.Size = new System.Drawing.Size(75, 23);
            this.btn_ExcelIntoSql.TabIndex = 19;
            this.btn_ExcelIntoSql.Text = "确定";
            this.btn_ExcelIntoSql.UseVisualStyleBackColor = true;
            this.btn_ExcelIntoSql.Click += new System.EventHandler(this.btn_ExcelIntoSql_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "输入表名：";
            // 
            // tb_TableName
            // 
            this.tb_TableName.Location = new System.Drawing.Point(206, 117);
            this.tb_TableName.Name = "tb_TableName";
            this.tb_TableName.Size = new System.Drawing.Size(198, 21);
            this.tb_TableName.TabIndex = 17;
            // 
            // btn_ChooseExcelPath
            // 
            this.btn_ChooseExcelPath.Location = new System.Drawing.Point(71, 62);
            this.btn_ChooseExcelPath.Name = "btn_ChooseExcelPath";
            this.btn_ChooseExcelPath.Size = new System.Drawing.Size(75, 23);
            this.btn_ChooseExcelPath.TabIndex = 16;
            this.btn_ChooseExcelPath.Text = "选择Excel";
            this.btn_ChooseExcelPath.UseVisualStyleBackColor = true;
            this.btn_ChooseExcelPath.Click += new System.EventHandler(this.btn_ChooseExcelPath_Click);
            // 
            // tb_ExcelPath
            // 
            this.tb_ExcelPath.Location = new System.Drawing.Point(206, 62);
            this.tb_ExcelPath.Name = "tb_ExcelPath";
            this.tb_ExcelPath.Size = new System.Drawing.Size(198, 21);
            this.tb_ExcelPath.TabIndex = 15;
            // 
            // fm_InsertDic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(479, 278);
            this.Controls.Add(this.btn_ExcelIntoSql);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_TableName);
            this.Controls.Add(this.btn_ChooseExcelPath);
            this.Controls.Add(this.tb_ExcelPath);
            this.DoubleBuffered = true;
            this.Name = "fm_InsertDic";
            this.Text = "导入字典表";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ExcelIntoSql;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_TableName;
        private System.Windows.Forms.Button btn_ChooseExcelPath;
        private System.Windows.Forms.TextBox tb_ExcelPath;
    }
}