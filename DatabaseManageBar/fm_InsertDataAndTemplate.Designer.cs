namespace DatabaseManageBar
{
    partial class fm_InsertDataAndTemplate
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
            this.tb_FirstRow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ChooseExcelPath = new System.Windows.Forms.Button();
            this.tb_ExcelPath = new System.Windows.Forms.TextBox();
            this.btn_ExportForm = new System.Windows.Forms.Button();
            this.btn_InsertData = new System.Windows.Forms.Button();
            this.cbb_TableNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_FirstRow
            // 
            this.tb_FirstRow.Location = new System.Drawing.Point(187, 133);
            this.tb_FirstRow.Name = "tb_FirstRow";
            this.tb_FirstRow.Size = new System.Drawing.Size(198, 21);
            this.tb_FirstRow.TabIndex = 21;
            this.tb_FirstRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_FirstRow_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "数据起始行";
            // 
            // btn_ChooseExcelPath
            // 
            this.btn_ChooseExcelPath.Location = new System.Drawing.Point(57, 88);
            this.btn_ChooseExcelPath.Name = "btn_ChooseExcelPath";
            this.btn_ChooseExcelPath.Size = new System.Drawing.Size(75, 23);
            this.btn_ChooseExcelPath.TabIndex = 19;
            this.btn_ChooseExcelPath.Text = "选择Excel";
            this.btn_ChooseExcelPath.UseVisualStyleBackColor = true;
            this.btn_ChooseExcelPath.Click += new System.EventHandler(this.btn_ChooseExcelPath_Click);
            // 
            // tb_ExcelPath
            // 
            this.tb_ExcelPath.Location = new System.Drawing.Point(187, 88);
            this.tb_ExcelPath.Name = "tb_ExcelPath";
            this.tb_ExcelPath.Size = new System.Drawing.Size(198, 21);
            this.tb_ExcelPath.TabIndex = 18;
            // 
            // btn_ExportForm
            // 
            this.btn_ExportForm.Location = new System.Drawing.Point(391, 52);
            this.btn_ExportForm.Name = "btn_ExportForm";
            this.btn_ExportForm.Size = new System.Drawing.Size(75, 23);
            this.btn_ExportForm.TabIndex = 17;
            this.btn_ExportForm.Text = "导出模板";
            this.btn_ExportForm.UseVisualStyleBackColor = true;
            this.btn_ExportForm.Click += new System.EventHandler(this.btn_ExportForm_Click);
            // 
            // btn_InsertData
            // 
            this.btn_InsertData.Location = new System.Drawing.Point(208, 184);
            this.btn_InsertData.Name = "btn_InsertData";
            this.btn_InsertData.Size = new System.Drawing.Size(75, 23);
            this.btn_InsertData.TabIndex = 16;
            this.btn_InsertData.Text = "确定";
            this.btn_InsertData.UseVisualStyleBackColor = true;
            this.btn_InsertData.Click += new System.EventHandler(this.btn_InsertData_Click);
            // 
            // cbb_TableNames
            // 
            this.cbb_TableNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TableNames.FormattingEnabled = true;
            this.cbb_TableNames.Location = new System.Drawing.Point(187, 52);
            this.cbb_TableNames.Name = "cbb_TableNames";
            this.cbb_TableNames.Size = new System.Drawing.Size(198, 20);
            this.cbb_TableNames.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "选择要导入的表格：";
            // 
            // fm_InsertDataAndTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(524, 270);
            this.Controls.Add(this.tb_FirstRow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ChooseExcelPath);
            this.Controls.Add(this.tb_ExcelPath);
            this.Controls.Add(this.btn_ExportForm);
            this.Controls.Add(this.btn_InsertData);
            this.Controls.Add(this.cbb_TableNames);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "fm_InsertDataAndTemplate";
            this.Text = "导入数据和导出模板";
            this.Load += new System.EventHandler(this.InsertOnly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_FirstRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ChooseExcelPath;
        private System.Windows.Forms.TextBox tb_ExcelPath;
        private System.Windows.Forms.Button btn_ExportForm;
        private System.Windows.Forms.Button btn_InsertData;
        private System.Windows.Forms.ComboBox cbb_TableNames;
        private System.Windows.Forms.Label label1;
    }
}