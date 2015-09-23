using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseManageBar
{
    public partial class fm_InsertDic : DevComponents.DotNetBar.OfficeForm
    {
        public fm_InsertDic()
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
        private void btn_ChooseExcelPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "所有文件(*.*)|*.*|Excel文件|*.xlsx|Excel文件|*.xls";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filePath = dlg.FileName;
                this.tb_ExcelPath.Text = filePath;
            }
        }
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

        private void btn_ExcelIntoSql_Click(object sender, EventArgs e)
        {
            string strFileName = tb_ExcelPath.Text;//excel路径
            string sqlTbName = tb_TableName.Text.Trim();//表名
            //检查是否按要求输入数据
            if (strFileName == "" || sqlTbName == "")
            {
                MessageBox.Show("请选择Excel文件的路径和填写表名！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = GetExcelData(strFileName);//获取excel中的表格
                int rCount = dt.Rows.Count;//表格的行数
                int lCount = dt.Columns.Count;//表格的列数
                //在数据库中建立存储表格
                //string sqlTbName = System.IO.Path.GetFileNameWithoutExtension(strFileName);//返回不带扩展名的文件名

                string sqlTbNameChar = ChineseIntoLetter.HZToPYSimple(sqlTbName);//表名转化为拼音首字母
                string tableName = "tb_dic_" + sqlTbNameChar;//表名



                string[] dbTableNames = SqlOperation.GetAllTableName();//获取所有表名   
                //判断是否有相同的表名
                bool ifExistTable = false;
                for (int tableNum = 0; tableNum < dbTableNames.Length; tableNum++)
                {
                    if (dbTableNames[tableNum] == tableName)
                    {
                        ifExistTable = true;
                        break;
                    }
                }
                if (ifExistTable)
                {
                    MessageBox.Show("该表已存在！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sqlCreateTable = "CREATE TABLE " + tableName + "(ID_AUTO INT NOT NULL PRIMARY KEY IDENTITY(1,1),Code varchar(20),Name varchar(100))";//SQL创建表格语句
                    //for (int colunm = 0; colunm < lCount - 1; colunm++)
                    //{
                    //    sqlCreateTable += arrFiledChar[colunm] + " varchar(100),";
                    //}
                    //sqlCreateTable += arrFiledChar[lCount - 1] + " varchar(100))";
                    SqlOperation.SqlCom(sqlCreateTable);//执行创建表格指令

                    //将数据导入表中
                    string sqlInsertFirst = "insert into " + tableName + " values('" + dt.Columns[0].ColumnName + "','" + dt.Columns[1].ColumnName + "')";
                    SqlOperation.SqlCom(sqlInsertFirst);
                    for (int i = 0; i < rCount; i++)
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
                    //是否创建字典表

                    bool ifExistDict = false;
                    for (int tableNum = 0; tableNum < dbTableNames.Length; tableNum++)
                    {
                        if (dbTableNames[tableNum] == "tb_dict")
                        {
                            ifExistDict = true;
                            break;
                        }
                    }
                    if (!ifExistDict)
                    {
                        //表名 TableName,表名注释 TableNameNote,字段名称 FieldName,字段注释 FieldNameNote,单位 Unit,数据类型 DataType,是否为空 IfNull,是否为主键 IfPrimaryKey
                        string sqlCreateDict = "create table tb_dict(ID_AUTO INT NOT NULL PRIMARY KEY IDENTITY(1,1),TableName varchar(100),TableNameNote varchar(100),FieldName varchar(100),FieldNameNote varchar(100),Unit varchar(100),DataType varchar(100),IfNull varchar(100),IfPrimaryKey varchar(100))";//新建字典表语句
                        SqlOperation.SqlCom(sqlCreateDict);//执行新建字典表语句
                    }


                    //向字典表中导入数据
                    string[] arryField = new string[2];
                    arryField[0] = "Code";
                    arryField[1] = "Name";
                    string[] arryFieldNote = new string[2];
                    arryFieldNote[0] = "代码";
                    arryFieldNote[1] = "名字";


                    for (int field = 0; field < lCount; field++)
                    {
                        string sqlInsterDict = "insert into tb_dict values('" + tableName + "','" + sqlTbName + "','" + arryField[field] + "','" + arryFieldNote[field] + "','" + "无" + "','varchar(100)','否','否')";//向字典表插入数据语句
                        SqlOperation.SqlCom(sqlInsterDict);//执行字典表插入数据语句

                    }
                    MessageBox.Show("表格新建成功并导入了数据！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
