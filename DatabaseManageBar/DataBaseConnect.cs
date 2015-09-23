using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DatabaseManageBar
{
    public partial class DataBaseConnect : DevComponents.DotNetBar.OfficeForm
    {
        public DataBaseConnect()
        {
            InitializeComponent();
            //禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //去除图标
            this.ShowIcon = false;
        }

        private void DataBaseConnect_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\App.config";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.GetElementsByTagName("add");
            XmlElement ele = (XmlElement)nodes[0];
            string fd = ele.GetAttribute("connectionString");
            string[] val_list = fd.Split(new char[] { ';','='}, StringSplitOptions.RemoveEmptyEntries);
            txt_fuwuqi.Text = val_list[1];
            txt_uid.Text = val_list[5];
            txt_pwd.Text = val_list[7];
            List<string> listdb = new List<string>();
            listdb.Add(val_list[3]);
            cmb_database.DataSource = listdb;
        }

        private void btn_Link_Click(object sender, EventArgs e)
        {
            bool isconnect = DataConnectManager.ConnectDataBase(txt_fuwuqi.Text, txt_uid.Text, txt_pwd.Text, cmb_database.SelectedItem.ToString());
            if (isconnect == true)
            {
                MessageBox.Show("数据库连接成功！");
            }
            else
            {
                MessageBox.Show("数据库连接失败！");
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
