using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection.Dao
{
    /// <summary>
    /// 用户管理本地数据库管理器（登陆 注册)
    /// </summary>
    class DataBaseManager
    {
        private MySqlConnection connection;
        //单例 保证内存唯一
        private DataBaseManager()
        {
            StringBuilder connStr = new StringBuilder();
            connStr.Append("Server=").Append(DataBaseConfig.ip).Append(";")
                    .Append("Port=").Append(DataBaseConfig.port).Append(";")
                    .Append("Uid=").Append(DataBaseConfig.uid).Append(";")
                    .Append("Pwd=").Append(DataBaseConfig.psw).Append(";")
                    .Append("Database=").Append(DataBaseConfig.databaseName).Append(";")
                    .Append("Charset=").Append(DataBaseConfig.encoding);
            connection = new MySqlConnection(connStr.ToString());
        }
        private static DataBaseManager mInstance = null;
        public static DataBaseManager getInstance()
        {
            if (mInstance == null)
            {
                mInstance = new DataBaseManager();
            }
            return mInstance;
        }

        //绑定当前的用户名
        private String currentUserName;
        public string CurrentUserName { get => currentUserName; set => currentUserName = value; }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable getData(String sql)
        {
            DataSet dataSet = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            return dataTable;
        }

        public Boolean changeDataWithoutReturn(String sql)
        {
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// 获取某用户的所有数据库配置信息
        /// </summary>
        public DataTable getAllConfig()
        {
            String sql = "select configname,ip, port,dbname from OuterConfig where username = " + currentUserName;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="configname"></param>
        /// <param name="username"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="dbname"></param>
        public void saveConfig(String configname,String ip,String port,String dbname)
        {
            String sql = "insert into OuterConfig(configname, username ,ip,port,dbname) " +
                "values('" + configname + "'," + "'" + currentUserName + "'," + "'" + ip + "'," +
                "'" + port + "'," + "'" + dbname + "')";
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void close()
        {
            if(mInstance != null){
                mInstance = null;
            }
            if(connection != null)
            {
                connection.Dispose();
                connection.Close();
                connection = null;
            }
        }
    }
}
