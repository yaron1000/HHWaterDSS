using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;


namespace DatabaseManageBar
{
    class SqlOperation
    {
        //static string strConne = @"Data Source=LIZY\MSSQLEXPRESS;Database=HeiHeDSS;User ID=sa;PWD=saa";//连接数据库字符串
        static string strConne = DataConnectManager.return_ConnectString();


        #region  建立数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回SqlConnection对象</returns>
        private static SqlConnection open()
        {

            SqlConnection sqlConne = new SqlConnection(strConne);      //创建连接对象

            try
            {
                sqlConne.Open();       //打开连接

            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString(), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return sqlConne;
        }
        #endregion

        #region  利用SqlDataReader读取数据(select)
        /// <summary>
        /// 利用SqlDataReader读取数据
        /// </summary>
        ///<param name="strConne">数据库连接字符串</param>
        ///<param name="strSql">查询分析</param>
        /// <returns>反回一个表格</returns>
        public static DataTable SelectData(string strSql)
        {
            SqlConnection sqlConne = open();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlcom = new SqlCommand(strSql, sqlConne);

                SqlDataReader sqlRead = sqlcom.ExecuteReader();

                sqlcom.Dispose();

                DataRow dr;
                int size = sqlRead.FieldCount;
                //提取列名
                for (int i = 0; i < size; i++)
                {
                    DataColumn dc;

                    dc = new DataColumn(sqlRead.GetName(i));

                    dt.Columns.Add(dc);

                }
                //提取每行的数据
                while (sqlRead.Read())
                {
                    dr = dt.NewRow();

                    for (int i = 0; i < size; i++)
                    {
                        dr[sqlRead.GetName(i)] = sqlRead[sqlRead.GetName(i)].ToString();

                    }
                    dt.Rows.Add(dr);

                }
                sqlRead.Close();
                sqlRead.Dispose();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString(), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {

                sqlConne.Close();//关闭sql连接
                sqlConne.Dispose();//释放资源
            }


            return dt;
        }
        #endregion

       

        /// <summary>
        /// 查询一个表所又的字段名
        /// </summary>
        /// <param name="strConne">连接字符串</param>
        /// <param name="strSql">查询语句</param>
        /// <returns></returns>
        public static List<string> GetAllTableFields(string strSql)
        {
            SqlConnection sqlConne = open();
            List<string> columnName = new List<string>();
            try
            {
                SqlCommand sqlcom = new SqlCommand(strSql, sqlConne);

                SqlDataReader sqlRead = sqlcom.ExecuteReader();

                sqlcom.Dispose();
                int size = sqlRead.FieldCount;

                //提取列名
                for (int i = 0; i < size; i++)
                {
                    columnName.Add(sqlRead.GetName(i));
                    //columnName[i] = sqlRead.GetName(i);不能这样写
                }

                sqlRead.Close();
                sqlRead.Dispose();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString(), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                sqlConne.Close();//关闭sql连接
                sqlConne.Dispose();//释放资源
            }
            return columnName;
        }

        public static string[] GetAllTableName()
        {
            SqlConnection sqlConne = open();
            //利用OleDbConnection的GetOleDbSchemaTable来获得数据库的结构 
            DataTable dt = sqlConne.GetSchema("TABLES");

            string[] tableNames = new string[dt.Rows.Count];

            for (int row = 0; row < dt.Rows.Count; row++)
            {
                tableNames[row] = dt.Rows[row]["TABLE_NAME"].ToString();
            }

            return tableNames;
        }


        #region  执行sqlCommanda操作
        /// <summary>
        /// 执行sqlCommanda操作
        /// </summary>
        public static void SqlCom(string strSql)
        {
            SqlConnection sqlConne = open();
            try
            {
                SqlCommand sqlcom = new SqlCommand(strSql, sqlConne);  //通过SQL语句和连接对象创建命令对象
                sqlcom.ExecuteNonQuery();     //对sqlcon执行SQL语句并返回受影响的行数
                sqlcom.Dispose();           //释放sqlcom'
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString(), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                sqlConne.Close();//关闭sql连接
                sqlConne.Dispose();//释放资源
            }
        }
        #endregion

        #region  创建DataSet对象
        /// <summary>
        /// 创建一个DataSet对象
        /// </summary>
        /// <returns>返回DataSet对象</returns>
        public static DataSet getds(string strSql, string tableName)  //查询
        {
            //SqlConnection sqlcon = getcon();
            SqlDataAdapter sqlda = new SqlDataAdapter(strSql, strConne);
            DataSet myds = new DataSet();
            sqlda.Fill(myds, tableName);
            return myds;
        }
        #endregion


        //#region  执行SqlCommand命令
        // <summary>
        // 执行SqlCommand
        // </summary>
        // <param name="M_str_sqlstr">SQL语句</param>
        //private static void getcom(string M_str_sqlstr)
        //{
        //    SqlConnection sqlcon = getcon();   //获取连接字符串
        //    sqlcon.Open();       //打开连接
        //    try
        //    {
        //        SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);  //通过SQL语句和连接对象创建命令对象
        //        sqlcom.ExecuteNonQuery();     //对sqlcon执行SQL语句并返回受影响的行数
        //        sqlcom.Dispose();           //释放sqlcom'
        //    }
        //    catch (SqlException e)
        //    {
        //        MessageBox.Show(e.ToString(), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    finally
        //    {
        //        sqlcon.Close();
        //        sqlcon.Dispose();
        //    }
        //}
        //#endregion
    }
}
