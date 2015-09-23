using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DatabaseManageBar
{
    public class fm_CreateDatabaseTableCmd : MyPluginEngine.ICommand
    {
        private System.Drawing.Bitmap m_hBitmap;

        public fm_CreateDatabaseTableCmd()
        {
            string str = @"..\Data\Image\DatabaseManageBar\CreateTableFromExcel.png";
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
            get { return "直接导表建库"; }
        }

        public string Category
        {
            get { return "导入数据"; }
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
            get { return "直接导表建库"; }
        }

        public string Name
        {
            get { return "fm_1CreateDatabaseTableCmd"; }
        }
        public string Tooltip
        {
            get { return "fm_1CreateDatabaseTableCmd"; }
        }

        public void OnClick()
        {
            fm_CreateDatabaseTable CreateDatabaseTable = new fm_CreateDatabaseTable();
            CreateDatabaseTable.Show();
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
