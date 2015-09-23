using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace DatabaseManageBar
{
    public partial class fm_CreateDatabaseTable : DevComponents.DotNetBar.OfficeForm
    {
        public fm_CreateDatabaseTable()
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
        /// <summary>
        /// 获取Excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 导入Excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExcelIntoSql_Click(object sender, EventArgs e)
        {
            string strFileName = tb_ExcelPath.Text;//excel路径
            string fieldsRow = tb_FieldsRow.Text;//字段所在的行
            int intFieldsRow = Convert.ToInt32(fieldsRow);
            string sqlTbName = tb_TableName.Text;//表名
            //检查是否按要求输入数据
            if (strFileName == "" || fieldsRow == "" || sqlTbName == "")
            {
                MessageBox.Show("请选择Excel文件的路径、填写字段所在的行和表名！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = GetExcelData(strFileName);//获取excel中的表格
                int rCount = dt.Rows.Count;//表格的行数
                int lCount = dt.Columns.Count;//表格的列数

                //检查输入的字段行是否有空值 
                bool ifFieldsRow = true;
                if (intFieldsRow == 1)
                {
                    for (int columnIndex = 0; columnIndex < lCount; columnIndex++)
                    {
                        if (dt.Columns[columnIndex].ColumnName.ToString().Trim() == "")
                        {
                            ifFieldsRow = false;
                            break;
                        }

                    }
                }
                else
                {
                    for (int columnIndex = 0; columnIndex < lCount; columnIndex++)
                    {
                        if (dt.Rows[intFieldsRow - 2][columnIndex].ToString().Trim() == "")
                        {
                            ifFieldsRow = false;
                            break;
                        }

                    }

                }

                if (rCount > 0 && ifFieldsRow)
                {
                    string[] arrFiledChar = new string[lCount];//储存转化的首字母
                    string[] arrFiledstring = new string[lCount];//储存汉字列
                    string[] arrFieldUnit = new string[lCount];//储存单位
                    string[] arrFiledstringUnit = new string[lCount];//储存去掉单位的汉字列

                    //获取所有的字段名并转化为首字母
                    if (intFieldsRow == 1)
                    {
                        for (int colunm = 0; colunm < lCount; colunm++)
                        {
                            arrFiledstring[colunm] = dt.Columns[colunm].ColumnName;
                            //处理有单位的字段
                            //方法：将所有字段括号里面的都视为单位
                            string[] splitUnit = arrFiledstring[colunm].Split(new char[2] { '(', ')' });
                            int splitLegth = splitUnit.Length;
                            if (splitLegth == 3)
                            {
                                arrFieldUnit[colunm] = splitUnit[1];
                                arrFiledstringUnit[colunm] = splitUnit[0];
                            }
                            else
                            {
                                arrFieldUnit[colunm] = "无";
                                arrFiledstringUnit[colunm] = arrFiledstring[colunm];
                            }


                            arrFiledChar[colunm] = ChineseIntoLetter.HZToPYSimple(arrFiledstringUnit[colunm]);
                        }

                    }
                    else
                    {
                        for (int colunm = 0; colunm < lCount; colunm++)
                        {
                            arrFiledstring[colunm] = dt.Rows[intFieldsRow - 2][colunm].ToString();

                            //处理有单位的字段
                            //方法：将所有字段括号里面的都视为单位

                            string[] splitUnit = arrFiledstring[colunm].Split(new char[2] { '(', ')' });
                            int splitLegth = splitUnit.Length;
                            if (splitLegth == 3)
                            {
                                arrFieldUnit[colunm] = splitUnit[1];
                                arrFiledstringUnit[colunm] = splitUnit[0];
                            }
                            else
                            {
                                arrFieldUnit[colunm] = "无";
                                arrFiledstringUnit[colunm] = arrFiledstring[colunm];
                            }



                            arrFiledChar[colunm] = ChineseIntoLetter.HZToPYSimple(arrFiledstringUnit[colunm]);
                        }
                    }

                    //处理字段名转首字母后首个字符为数字和整个字符串相同
                    for (int count = 0; count < arrFiledChar.Length; count++)
                    {
                        //处理字段名转首字母后首个字符为数字
                        //处理方法：将前面的数字移到最后面并加上_C隔开
                        int origStrLength = arrFiledChar[count].Length;//获取原始字符串的长度
                        //从第一个字符开始，一次检查一个
                        for (int strLength = 0; strLength < origStrLength; strLength++)
                        {

                            if (char.IsNumber(arrFiledChar[count][0]))
                            {
                                if (strLength == 0)
                                {
                                    arrFiledChar[count] = arrFiledChar[count].Substring(1, arrFiledChar[count].Length - 1) + "_C" + arrFiledChar[count][0];//第一次加_C并将第一个移到最后
                                }
                                else
                                {
                                    arrFiledChar[count] = arrFiledChar[count].Substring(1, arrFiledChar[count].Length - 1) + arrFiledChar[count][0];
                                }
                            }
                            else
                            {
                                break;//当不为数字是则跳出循环
                            }
                        }

                        //处理字段名转首字母后整串字符相同
                        //处理方法：在字符后面加_S和数字
                        for (int temp = count - 1; temp >= 0; temp--)
                        {
                            string[] split = Regex.Split(arrFiledChar[temp], "_S", RegexOptions.IgnoreCase);

                            if (arrFiledChar[count] == split[0])
                            {

                                if (split.Length == 1)
                                {
                                    arrFiledChar[count] = split[0] + "_S1";
                                }
                                else
                                {
                                    int order = Convert.ToInt32(split[1]) + 1;
                                    arrFiledChar[count] = split[0] + "_S" + order;
                                }
                                break;
                            }
                        }
                    }

                    //在数据库中建立存储表格
                    //string sqlTbName = System.IO.Path.GetFileNameWithoutExtension(strFileName);//返回不带扩展名的文件名

                    string sqlTbNameChar = ChineseIntoLetter.HZToPYSimple(sqlTbName);//表名转化为拼音首字母
                    string tableName = "tb_" + sqlTbNameChar;//表名



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
                        string sqlCreateTable = "CREATE TABLE " + tableName + "(ID_AUTO INT NOT NULL PRIMARY KEY IDENTITY(1,1),";//SQL创建表格语句
                        for (int colunm = 0; colunm < lCount - 1; colunm++)
                        {
                            sqlCreateTable += arrFiledChar[colunm] + " varchar(100),";
                        }
                        sqlCreateTable += arrFiledChar[lCount - 1] + " varchar(100))";
                        SqlOperation.SqlCom(sqlCreateTable);//执行创建表格指令

                        //将数据导入表中
                        if (cb_IfInsert.Checked)
                        {
                            for (int i = intFieldsRow - 1; i < rCount; i++)
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
                        for (int field = 0; field < lCount; field++)
                        {
                            string sqlInsterDict = "insert into tb_dict values('" + tableName + "','" + sqlTbName + "','" + arrFiledChar[field] + "','" + arrFiledstringUnit[field] + "','" + arrFieldUnit[field] + "','varchar(100)','否','否')";//向字典表插入数据语句
                            SqlOperation.SqlCom(sqlInsterDict);//执行字典表插入数据语句

                        }

                        if (cb_IfInsert.Checked)
                        {
                            MessageBox.Show("表格新建成功并导入了数据！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("表格新建成功！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    if (!ifFieldsRow)
                    {
                        MessageBox.Show("输入的表头所在行有空，请检查重新输入！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("请检查你的Excel中是否存在数据！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

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

        private void tb_FieldsRow_KeyPress(object sender, KeyPressEventArgs e)
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

        ///// <summary>
        ///// 处理字段名转首字母后首个字符为数字和整串字符相同
        ///// </summary>
        ///// <param name="arrFiledChar">需要处理的字符串数组</param>
        //private void DisposeFiledChar(string[] arrFiledChar)
        //{
        //    for (int count = 0; count < arrFiledChar.Length; count++)
        //    {
        //        //处理字段名转首字母后首个字符为数字
        //        //处理方法：将前面的数字以后最后面并加上_C隔开
        //        int origStrLength = arrFiledChar[count].Length;//获取原始字符串的长度
        //        for (int strLength = 0; strLength < origStrLength; strLength++)
        //        {

        //            if (char.IsNumber(arrFiledChar[count][0]))
        //            {
        //                if (strLength == 0)
        //                {
        //                    arrFiledChar[count] = arrFiledChar[count].Substring(1, arrFiledChar[count].Length - 1) + "_C" + arrFiledChar[count][0];//第一次加_并将第一个移到最后
        //                }
        //                else
        //                {
        //                    arrFiledChar[count] = arrFiledChar[count].Substring(1, arrFiledChar[count].Length - 1) + arrFiledChar[count][0];
        //                }
        //            }
        //            else
        //            {
        //                break;//当不为数字是则跳出循环
        //            }
        //        }
        //        //处理字段名转首字母后整串字符相同
        //        //处理方法：在字符后面加_和数字
        //        for (int temp = count; temp >= 0; temp--)
        //        {
        //            if (arrFiledChar[count] == arrFiledChar[temp])
        //            {
        //                string[] split = Regex.Split(arrFiledChar[temp], "_S", RegexOptions.IgnoreCase);
        //                if (split.Length == 1)
        //                {
        //                    arrFiledChar[count] = split[0] + "_S1";
        //                }
        //                else
        //                {
        //                    int order = Convert.ToInt32(split[1]) + 1;
        //                    arrFiledChar[count] = split[0] + "_S" + order;
        //                }
        //                break;
        //            }
        //        }
        //    }



        //}
    }
}
