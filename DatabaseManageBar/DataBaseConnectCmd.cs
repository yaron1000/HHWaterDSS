using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DatabaseManageBar
{
    public class DataBaseConnectCmd : MyPluginEngine.ICommand
    {
        private System.Drawing.Bitmap m_hBitmap;

        public DataBaseConnectCmd()
        {
            string str = @"..\Data\Image\DatabaseManageBar\DBConnect.png";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;
        }

        #region ICommand 成员

        public System.Drawing.Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "连接数据库"; }
        }

        public string Category
        {
            get { return "数据库管理"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public int HelpContextId
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }

        public string Message
        {
            get { return "连接数据库"; }
        }

        public string Name
        {
            get { return "DataBaseConnectCmd"; }
        }
        public string Tooltip
        {
            get { return "DataBaseConnectCmd"; }
        }

        public void OnClick()
        {
            DataBaseConnect pDataBaseConnect = new DataBaseConnect();
            pDataBaseConnect.Show();
        }

        public void OnCreate(MyPluginEngine.IApplication hook)
        {
            //if (hook != null)
            //{
            //    this.hk = hook;
            //    m_mapControl = this.hk.MapControl;
            //}
        }

        

        #endregion
    
    }
}
