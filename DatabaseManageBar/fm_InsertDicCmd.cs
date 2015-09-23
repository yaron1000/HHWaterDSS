using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DatabaseManageBar
{
    public class fm_InsertDicCmd : MyPluginEngine.ICommand
    {
        private System.Drawing.Bitmap m_hBitmap;

        public fm_InsertDicCmd()
        {
            string str = @"..\Data\Image\DatabaseManageBar\InsertData.png";
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
            get { return "导入字典表"; }
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
            get { return "导入字典表"; }
        }

        public string Name
        {
            get { return "fm_InsertDicCmd"; }
        }
        public string Tooltip
        {
            get { return "fm_InsertDicCmd"; }
        }

        public void OnClick()
        {
            fm_InsertDic InsertDic = new fm_InsertDic();
            InsertDic.Show();
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
