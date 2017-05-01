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
        private MySqlConnection connection;
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
        public List<String> queryAllTableName(String databaseName)
        {
            List<String> tables = new List<string>();
            String sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + databaseName + "';";
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
