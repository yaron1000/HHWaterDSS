using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseManageBar
{
    /// <summary>
    /// 数据库连接管理类
    /// </summary>
    public  class DataConnectManager
    {
        /// <summary>
        /// 建立连接字符串
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <param name="basename"></param>
        public static bool ConnectDataBase(string fuwuqi,string uid,string pwd,string basename)
        {
            bool isConnect=false;
            string path = Application.StartupPath + "\\App.config";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.GetElementsByTagName("add");
            //nodes[0].RemoveAll();
            //doc.Save(path);
            string attrvalue = "server="+fuwuqi+";database="+basename+";uid="+uid+";pwd="+pwd+";";
            //XmlAttribute attr_name = doc.CreateAttribute("name");
            //attr_name.Value = "sqlcon";
            //nodes[0].Attributes.Append(attr_name);
            //XmlAttribute attr_connect = doc.CreateAttribute("connectionString");
            //attr_connect.Value = attrvalue;
            //nodes[0].Attributes.Append(attr_connect);
            XmlElement ele = (XmlElement)nodes[0];
            ele.SetAttribute("connectionString", attrvalue);
            doc.Save(path);
            SqlConnection con =null;
            try
            {
                con = new SqlConnection(DataConnectManager.return_ConnectString());
                con.Open();
                isConnect = true; 
                return isConnect;
            }
            catch 
            {
                return isConnect;
            }
            finally
            {
               
                con.Close();  
            }
           
        }
        /// <summary>
        /// 返回连接字符串
        /// </summary>
        /// <returns></returns>
        public static string return_ConnectString()
        {
            string path = Application.StartupPath + "\\App.config";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.GetElementsByTagName("add");
            string sqlcon = nodes[0].Attributes["connectionString"].Value.ToString();
            return sqlcon;
        }
        /// <summary>
        /// 连接初始化，获取数据库名称
        /// </summary>
        /// <returns></returns>
        public static List<string> initConnect()
        {
            string strcon = "server=localhost;Initial Catalog=master;Integrated Security=true;";
            List<string> list_table = new List<string>();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strsql = "select Name from SysDatabases Order by Name";
            SqlCommand cmd = DataBaseOperate.getSqlCmd(strsql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list_table.Add(reader[0].ToString());
            }
            con.Close();
            return list_table;
        
        }
    }
}
