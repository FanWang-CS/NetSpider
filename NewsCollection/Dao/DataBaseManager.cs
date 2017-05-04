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
        internal DataTable getData(String sql)
        {
            DataSet dataSet = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            return dataTable;
        }
        //更新数据：插入和更新（更新有待考证）
        internal Boolean changeDataWithoutReturn(String sql)
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
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public DataTable login(String username, String password)
        {
            String sql = "SELECT checkstatus FROM `user`  WHERE username='" + username + "' AND `password`='" + password + "'";
            return getData(sql);
        }

        /// <summary>
        /// 判断是否允许注册
        /// </summary>
        /// <param name="username"></param>
        public Boolean canRegeist(String Username)
        {
            String sql = "SELECT COUNT(*) As number FROM USER WHERE username ='" + Username + "'";
            DataTable dt = getData(sql);
            int num = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            return num == 0;
        }

        /// <summary>
        /// 判断邮箱是否可用
        /// </summary>
        /// <param name="username"></param>
        public Boolean isAvailableofEmail(String Email)
        {
            String sql = "SELECT COUNT(*) As number FROM USER WHERE email ='" + Email + "'";
            DataTable dt = getData(sql);
            int num = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            return num == 0;
        }

        public Boolean regeistUser(String Username, String Usertype, String Email, String pwd)
        {
            String InsertSql = "INSERT INTO USER(id,username,usertype,email,`password`,checkstatus) VALUES(REPLACE(UUID(),'-',''),'" + Username + "','" + Usertype + "','" + Email + "','" + pwd + "',0)";
            return changeDataWithoutReturn(InsertSql);
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
        public void saveConfig(String configname, String ip, String port, String dbname)
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
        //获取当前编辑的网站
        public DataTable getCurtainWebsite(String websiteName)
        {
            String sql = "SELECT * FROM website WHERE title = '" + websiteName + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        //更新网站信息，返回更新是否成功的信息
        public Boolean updateCurtainWebsite(String websiteId,String [] websiteInfo)
        {
            String sql = "UPDATE website SET title = '"+ websiteInfo [0]+ "', url = '" + websiteInfo[1] + "', note = '" + websiteInfo[2] + "' " +
                         "WHERE id = '"+ websiteId + "'";
            return changeDataWithoutReturn(sql);
        }
        //新增网站记录
        public Boolean insertWebsite(String[] websiteInfo)
        {
            String sql = "INSERT INTO website(id,title,url,note) VALUES(REPLACE(UUID(),'-',''),'"+ websiteInfo[0]+ "','" + websiteInfo[1] + "','" + websiteInfo[2] + "')";
            return changeDataWithoutReturn(sql);
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
