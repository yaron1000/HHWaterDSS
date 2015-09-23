namespace DatabaseManageBar
{
    partial class DataBaseConnect
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_uid = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_database = new System.Windows.Forms.ComboBox();
            this.btn_Link = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.txt_fuwuqi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(57, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // txt_uid
            // 
            this.txt_uid.Location = new System.Drawing.Point(124, 13);
            this.txt_uid.Name = "txt_uid";
            this.txt_uid.Size = new System.Drawing.Size(156, 21);
            this.txt_uid.TabIndex = 1;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(124, 50);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(156, 21);
            this.txt_pwd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(71, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(57, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据库：";
            // 
            // cmb_database
            // 
            this.cmb_database.FormattingEnabled = true;
            this.cmb_database.Location = new System.Drawing.Point(124, 127);
            this.cmb_database.Name = "cmb_database";
            this.cmb_database.Size = new System.Drawing.Size(156, 20);
            this.cmb_database.TabIndex = 5;
            // 
            // btn_Link
            // 
            this.btn_Link.Location = new System.Drawing.Point(74, 176);
            this.btn_Link.Name = "btn_Link";
            this.btn_Link.Size = new System.Drawing.Size(75, 23);
            this.btn_Link.TabIndex = 6;
            this.btn_Link.Text = "连接";
            this.btn_Link.UseVisualStyleBackColor = true;
            this.btn_Link.Click += new System.EventHandler(this.btn_Link_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(205, 176);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 7;
            this.btn_exit.Text = "取消";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // txt_fuwuqi
            // 
            this.txt_fuwuqi.Location = new System.Drawing.Point(124, 89);
            this.txt_fuwuqi.Name = "txt_fuwuqi";
            this.txt_fuwuqi.Size = new System.Drawing.Size(156, 21);
            this.txt_fuwuqi.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(43, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "服务器名：";
            // 
            // DataBaseConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 211);
            this.Controls.Add(this.txt_fuwuqi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_Link);
            this.Controls.Add(this.cmb_database);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_uid);
            this.Controls.Add(this.label1);
            this.Name = "DataBaseConnect";
            this.Text = "数据库连接";
            this.Load += new System.EventHandler(this.DataBaseConnect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_uid;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_database;
        private System.Windows.Forms.Button btn_Link;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TextBox txt_fuwuqi;
        private System.Windows.Forms.Label label4;
    }
}