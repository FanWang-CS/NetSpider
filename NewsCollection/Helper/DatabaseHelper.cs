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
            DataSet dataSet = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter("show databases;",connection);
            adapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            int rowNum = table.Rows.Count;
            for(int i = 0; i < rowNum; i++)
            {
                String value = table.Rows[i][0] as String;
                databases.Add(value);
            }
            return databases;
        }
    }
}
