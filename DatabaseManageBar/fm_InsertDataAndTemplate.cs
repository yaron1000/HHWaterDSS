using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseManageBar
{
    public partial class fm_InsertDataAndTemplate : DevComponents.DotNetBar.OfficeForm
    {
        public fm_InsertDataAndTemplate()
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
        List<string> listTableNames = new List<string>();//除去字典表的表名
        private void btn_ChooseExcelPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel文件|*.xlsx|Excel文件|*.xls|所有文件(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filePath = dlg.FileName;
                this.tb_ExcelPath.Text = filePath;
            }
        }
        /// <summary>
        /// 获取Excel中的数据
        /// </summary>
        /// <param name="excelPath">Excel文件路径</param>
        /// <returns></returns>
        private DataTable GetExcelData(string excelPath)
        {

            string conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";//连接excel2007版本以上的字符串
            string docExtention = Path.GetExtension(excelPath);//获取excel的后缀
            if (docExtention == ".xls")
            {
                conn = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + excelPath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";//连接excel2007版本以下的字符串
            }
            //将excel看做是一个数据源，三种方法之一
            string sql = "select * from [Sheet1$]";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "datatable");
            DataTable dt = ds.Tables[0];
            return dt;
        }

        private void InsertOnly_Load(object sender, EventArgs e)
        {
            string[] dbTableNames = SqlOperation.GetAllTableName();//数据库所有的表名
            List<string> tableNames = new List<string>();//除去字典表的表名
            foreach (string tableName in dbTableNames)
            {
                if (tableName != "tb_dict")
                {
                    tableNames.Add(tableName);
                }
            }
            listTableNames = tableNames;
            List<string> tableNamesCN = new List<string>();//除去字典表的表名的中文

            foreach (string tableName in tableNames)
            {
                string sqlSelect = "select TableName,TableNameNote from tb_dict where TableName ='" + tableName + "'";
                DataTable dt = SqlOperation.SelectData(sqlSelect);
                tableNamesCN.Add(dt.Rows[0]["TableNameNote"].ToString());
            }
            cbb_TableNames.DataSource = tableNamesCN;
        }

        private void btn_InsertData_Click(object sender, EventArgs e)
        {
            string strFileName = tb_ExcelPath.Text;//excel路径
            string firstRow = tb_FirstRow.Text;//第一行数据所在的行
            int intFirstRow = Convert.ToInt32(firstRow);
            int selectedId = cbb_TableNames.SelectedIndex;
            string tableName = listTableNames[selectedId];//要导入的数据库名

            if (strFileName == "" || firstRow == "")
            {
                MessageBox.Show("请选择Excel文件的路径或输入第一行数据所在行！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = GetExcelData(strFileName);//获取excel中的表格
                if (dt.Rows.Count > 0)
                {
                    int rCount = dt.Rows.Count;//表格的行数
                    int lCount = dt.Columns.Count;//表格的列数
                    //导入数据到数据库
                    for (int i = intFirstRow - 2; i < rCount; i++)
                    {
                        string sqlInsert = "insert into " + tableName + " values('"; //SQL插入一行数据   语句        
                        for (int j = 0; j < lCount - 1; j++)
                        {
                            if (dt.Rows[i][j].ToString() == "")
                            {
                                sqlInsert += "无" + "','";
                            }
                            else
                            {
                                sqlInsert += dt.Rows[i][j].ToString() + "','";
                            }
                        }

                        sqlInsert += dt.Rows[i][lCount - 1].ToString() + "')";
                        SqlOperation.SqlCom(sqlInsert);//执行插入一行数据指令
                    }
                    MessageBox.Show("导入数据成功！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("请检查你的Excel中是否存在数据！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_ExportForm_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd_Form = new SaveFileDialog();
            //设置文件类型  
            sfd_Form.Filter = " Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xlsx|All files(*.*)|*.*";

            //设置默认文件类型显示顺序  
            sfd_Form.FilterIndex = 3;

            //保存对话框是否记忆上次打开的目录  
            sfd_Form.RestoreDirectory = true;

            if (sfd_Form.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径  
                //localFilePath = saveFileDialog1.FileName.ToString();  
                //获取文件名，不带路径  
                //fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);  
                //获取文件路径，不带文件名  
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));  
                //给文件名前加上时间  
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;  
                //在文件名里加字符  
                //saveFileDialog1.FileName.Insert(1,"dameng"); 
                // 文件保存路径及名称
                //
                string filePath = sfd_Form.FileName.ToString();

                // 创建Excel文档
                Microsoft.Office.Interop.Excel.Application ExcelApp
                    = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelDoc = ExcelApp.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet xlSheet = ExcelDoc.Worksheets.Add(Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                ExcelApp.DisplayAlerts = false;

                // 写入标题
                int selectedId = cbb_TableNames.SelectedIndex;
                string tableName = listTableNames[selectedId];//要导入的数据库名
                string sqlSelect = "select * from " + tableName;//选择要导入模板的字段
                List<string> fieldsName = SqlOperation.GetAllTableFields(sqlSelect);//提示：选择出的是首字母
                for (int index = 1; index < fieldsName.Count; index++)
                {
                    string sqlSelectDict = "select FieldName,FieldNameNote,Unit from tb_dict where FieldName = '" + fieldsName[index] + "'" + "and TableName = '" + tableName + "'";
                    DataTable dt = SqlOperation.SelectData(sqlSelectDict);
                    if (dt.Rows[0]["Unit"].ToString() == "无")
                    {
                        xlSheet.Cells[1, index] = dt.Rows[0]["FieldNameNote"];
                    }
                    else
                    {
                        xlSheet.Cells[1, index] = dt.Rows[0]["FieldNameNote"] + "(" + dt.Rows[0]["Unit"] + ")";
                    }

                }

                // 文件保存
                xlSheet.SaveAs(filePath);
                ExcelDoc.Close(Type.Missing, filePath, Type.Missing);
                ExcelApp.Quit();
                MessageBox.Show("模板导出成功！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tb_FirstRow_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int kc = (int)e.KeyChar;
                //一般的做法就是在按键事件中处理，判断keychar的值。限制只能输入数字，小数点，Backspace，del这几个键。数字0~9所对应的keychar为48~57，小数点是46，Backspace是8。    
                if ((kc < 48 || kc > 57) && kc != 8)
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("请输入数字！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
