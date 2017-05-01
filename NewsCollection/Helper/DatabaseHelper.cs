using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection.Helper
{
    /// <summary>
    /// 远程数据库工具类
    /// </summary>
    class DatabaseHelper
    {
        private List<String> keyWord;  //关键字
        private List<List<String>> contents; //扒取到的内容

        private MySqlConnection connection;
        private String dataBaseName; //需要操作的数据库名
        private String tableName; //需要操作的数据表

        public string DataBaseName { get => dataBaseName; set => dataBaseName = value; }
        public string TableName { get => tableName; set => tableName = value; }
        public List<string> KeyWord { get => keyWord; set => keyWord = value; }
        public List<List<string>> Contents { get => contents; set => contents = value; }

        private DatabaseHelper() { }
        private static DatabaseHelper mInstance;
        public  static DatabaseHelper getInstance()
        {
            if(mInstance == null)
            {
                mInstance = new DatabaseHelper();
            }
            return mInstance;
        }

        public void init(String ip,String port,String uid,String psw)
        {
            StringBuilder connStr = new StringBuilder();
            connStr.Append("Server=").Append(ip).Append(";")
                    .Append("Port=").Append(port).Append(";")
                    .Append("Uid=").Append(uid).Append(";")
                    .Append("Pwd=").Append(psw);
            connection = new MySqlConnection(connStr.ToString());
        }

        public Boolean testConnect()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取所有远程数据库的名称
        /// </summary>
        /// <returns></returns>
        public List<String> queryAllDatabaseName()
        {
            List<String> databases = new List<string>();
            try
            {
                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter("show databases;", connection);
                adapter.Fill(dataSet);
                DataTable table = dataSet.Tables[0];
                int rowNum = table.Rows.Count;
                for (int i = 0; i < rowNum; i++)
                {
                    String value = table.Rows[i][0] as String;
                    databases.Add(value);
                }
                return databases;
            }catch(Exception e1)
            {
                Console.WriteLine(e1.ToString());
                return databases;
            }
        }

        /// <summary>
        /// 查询所有的表名
        /// </summary>
        /// <returns></returns>
        public List<String> queryAllTableName()
        {
            List<String> tables = new List<string>();
            String sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + dataBaseName + "';";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                DataTable table = dataSet.Tables[0];
                int rowNum = table.Rows.Count;
                for (int i = 0; i < rowNum; i++)
                {
                    String value = table.Rows[i][0] as String;
                    tables.Add(value);
                }
                return tables;
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.ToString());
                return tables;
            }
        }

        /// <summary>
        /// 返回某数据库结构
        /// </summary>
        /// <returns></returns>
        public Dictionary<String,String> getTableInfo()
        {
            Dictionary<String, String> map = new Dictionary<string, string>();
            String sql = "select column_name,data_type from information_schema.columns " +
                "where TABLE_SCHEMA='" + dataBaseName +"' and table_name='" + tableName + "';" ;
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                DataTable table = dataSet.Tables[0];
                int rowNum = table.Rows.Count;
                for (int i = 0; i < rowNum; i++)
                {
                    String name = table.Rows[i][0] as String;
                    String type = table.Rows[i][1] as String;
                    map.Add(name, type);
                }
                return map;
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1);
                return map;
            }
        }

        /// <summary>
        /// 关闭Helper对象的使用
        /// </summary>
        public void close()
        {
            if(connection != null)
            {
                connection.Dispose();
                connection.Close();
                connection = null;
            }
        }
    }
}
