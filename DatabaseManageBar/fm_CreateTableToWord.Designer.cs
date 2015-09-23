namespace DatabaseManageBar
{
    partial class fm_CreateTableToWord
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_CreateDirctToWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(130, 82);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(225, 19);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // btn_CreateDirctToWord
            // 
            this.btn_CreateDirctToWord.Location = new System.Drawing.Point(202, 141);
            this.btn_CreateDirctToWord.Name = "btn_CreateDirctToWord";
            this.btn_CreateDirctToWord.Size = new System.Drawing.Size(76, 28);
            this.btn_CreateDirctToWord.TabIndex = 2;
            this.btn_CreateDirctToWord.Text = "确定";
            this.btn_CreateDirctToWord.UseVisualStyleBackColor = true;
            this.btn_CreateDirctToWord.Click += new System.EventHandler(this.btn_CreateDirctToWord_Click);
            // 
            // fm_CreateTableToWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(483, 247);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_CreateDirctToWord);
            this.DoubleBuffered = true;
            this.Name = "fm_CreateTableToWord";
            this.Text = "导出字典表到Word";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_CreateDirctToWord;
    }
}