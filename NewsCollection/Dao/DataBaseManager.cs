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
            DataTable dataTable = new DataTable();
            try
            {
                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return dataTable;
            }
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
                connection.Close();
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
            return getData(sql);
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="configname"></param>
        /// <param name="username"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="dbname"></param>
        public Boolean saveConfig(String configname, String ip, String port, String dbname)
        {
            String sql = "insert into OuterConfig(configname, username ,ip,port,dbname) " +
                "values('" + configname + "'," + "'" + currentUserName + "'," + "'" + ip + "'," +
                "'" + port + "'," + "'" + dbname + "')";
            return changeDataWithoutReturn(sql);
        }
        //获取网站分组
        public DataTable getWebsiteGroup()
        {
            String sql = "SELECT title FROM `webgroup`";
            DataTable dt = getData(sql);
            return dt;
        }
        //获取网站组里面网站
        public DataTable getWebsiteInGroup(String group)
        {
            String sql = "SELECT a.title AS title FROM website AS a,webgroup AS b WHERE a.groupid=b.id AND b.title = '"+ group + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        //获取当前编辑的网站
        public DataTable getCurtainWebsite(String websiteName,String parentName)
        {
            String sql = "SELECT * FROM website AS a LEFT JOIN webgroup AS b ON a.groupid = b.id " +
                "WHERE a.title = '"+ websiteName + "' AND b.title = '"+ parentName + "' ";
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
            String sql = "insert into website(id,title,url,note,groupid) select REPLACE(UUID(),'-',''),'" + websiteInfo[0] + "' as title,'" + websiteInfo[1] + "'as url,'" + websiteInfo[2] + "' as note,id from webgroup where title='"+ websiteInfo[3] + "'";
            return changeDataWithoutReturn(sql);
        }
        //删除网站记录
        public Boolean deleteWebsite(String websiteId)
        {
            String sql = "DELETE FROM website WHERE id ='"+websiteId+"'";
            return changeDataWithoutReturn(sql);
        }
        //获取当前编辑网站分组
        public DataTable getCurtainWebGroup(String CurtainNodeText)
        {
            String sql = "SELECT * FROM webgroup WHERE title='" + CurtainNodeText + "'";
            return getData(sql);
        }
        //创建网站分组
        public Boolean creatWebGroup(String [] groupInfo)
        {
            String sql = "INSERT INTO webgroup VALUES(REPLACE(UUID(),'-',''),'" + groupInfo[0] + "','" + groupInfo[1] + "')";
            return changeDataWithoutReturn(sql);
        }
        //编辑网站分组
        public Boolean editWebGroup(String groupID,String[] groupInfo)
        {
            String sql = "UPDATE webgroup SET title='"+ groupInfo [0]+ "',note='" + groupInfo[0] + "' WHERE id='" + groupID + "'";
            return changeDataWithoutReturn(sql);
        }
        //删除网站分组
        public Boolean deleteWebGroup(String groupID)
        {
            String sql = "DELETE FROM website WHERE groupid = '" + groupID + "'";
            if (changeDataWithoutReturn(sql))
            {
                sql = "DELETE from webgroup WHERE id='" + groupID + "'";
                return changeDataWithoutReturn(sql);
            }
            else
                return false;
        }

        /// <summary>
        /// 任务组数据库操作
        /// </summary>
        /// 
        //获取任务分组
        public DataTable getTaskGroup()
        {
            String sql = "SELECT title FROM `taskgroup`";
            DataTable dt = getData(sql);
            return dt;
        }
        //获取任务组里面网站
        public DataTable getTaskInGroup(String group)
        {
            String sql = "SELECT a.title AS title FROM task AS a,taskgroup AS b WHERE a.groupid=b.id AND b.title = '" + group + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        //获取当前编辑任务分组
        public DataTable getCurtainTaskGroup(String CurtainNodeText)
        {
            String sql = "SELECT * FROM taskgroup WHERE title='" + CurtainNodeText + "'";
            return getData(sql);
        }
        //创建任务分组
        public Boolean creatTaskGroup(String[] groupInfo)
        {
            String sql = "INSERT INTO taskgroup VALUES(REPLACE(UUID(),'-',''),'" + groupInfo[0] + "','" + groupInfo[1] + "')";
            return changeDataWithoutReturn(sql);
        }
        //编辑任务分组
        public Boolean editTaskGroup(String groupID, String[] groupInfo)
        {
            String sql = "UPDATE taskgroup SET title='" + groupInfo[0] + "',note='" + groupInfo[0] + "' WHERE id='" + groupID + "'";
            return changeDataWithoutReturn(sql);
        }
        //删除任务分组
        public Boolean deleteTaskGroup(String groupID)
        {
            String sql = "DELETE form taskgroup WHERE id='" + groupID + "'";
            return changeDataWithoutReturn(sql);
        }

        /// <summary>
        /// 存入任务
        /// </summary>
        /// <param name="taskName">任务名</param>
        /// <param name="taskDes">任务描述</param>
        /// <param name="taskGroup">任务组</param>
        /// <param name="taskUrl">任务Url</param>
        /// <param name="taskNextFilter">任务翻页规则</param>
        /// <param name="taskFilter">任务扒取规则</param>
        /// <param name="keyWord">关键字</param>
        /// <returns></returns>
        public Boolean saveTask(String taskName, String taskDes, String  taskGroup, String taskUrl,
                                String taskNextFilter, String taskFilter, String keyWord)
        {
            String sql = "INSERT INTO Task(owner, tname, tdes,tgroup,turl,tnextfilter,tfilter,tkeyword) VALUES("
                + currentUserName + ","
                + taskName + ","
                + taskDes + "," 
                + taskGroup + ","
                + taskUrl + ","
                + taskNextFilter + ","
                + taskFilter + ","
                + keyWord + ")";
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
