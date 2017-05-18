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
        #region 单例模式实例化对象
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
        #endregion

        //绑定当前的用户名
        private String currentUserName;
        private String currentUserType;
        public string CurrentUserName { get => currentUserName; set => currentUserName = value; }
        public string CurrentUserType { get => currentUserType; set => currentUserType = value; }
      
        #region 通用数据库操作（增删改查）
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
        //更新数据：插入和更新
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
        //获取当前用户的id
        public  String getCurrentUserId()
        {
            String sql = "select id from user where username='" + currentUserName + "'";
            DataTable dt = getData(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0].ItemArray[0] as string;
            }
            return null;
        }
        #endregion
        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public DataTable login(String username, String password, String usertype)
        {
            String sql = "SELECT checkstatus FROM `user`  WHERE username='" + username + "' AND `password`='" + password + "' AND `usertype`='" + usertype+ "'";
            return getData(sql);
        }
#endregion
        #region 注册
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
            String sql = "SELECT COUNT(*) As number FROM USER WHERE email ='" + Email + "' and username != '"+currentUserName+"'" ;
            DataTable dt = getData(sql);
            int num = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            return num == 0;
        }
        //注册
        public Boolean regeistUser(String Username, String Usertype, String Email, String pwd)
        {
            String InsertSql = "INSERT INTO USER(id,username,usertype,email,`password`,checkstatus) VALUES(REPLACE(UUID(),'-',''),'" + Username + "','" + Usertype + "','" + Email + "','" + pwd + "','001003')";
            return changeDataWithoutReturn(InsertSql);
        }
        //获取当前用户信息
        public DataTable getuserInfo()
        {
            String sql = "SELECT username,email,PASSWORD,usertype,IFNULL(nickname,username) FROM USER where username='" + currentUserName + "'";
            return getData(sql);
        }
        //更新用户信息
        public Boolean updataUserInfo(String [] newuserInfo)
        {
            String sql = "update user set email='" + newuserInfo[0] + "',password='" + newuserInfo[1] + "',nickname='" + newuserInfo[2] + "' where username='"+currentUserName+"'";
            return changeDataWithoutReturn(sql);
        }
        #endregion
        #region 导入到数据库
        /// <summary>
        /// 获取某用户的所有数据库配置信息
        /// </summary>
        public DataTable getAllConfig()
        {
            String sql = "select configname,ip, port,dbname from OuterConfig where username = " + currentUserName;
            return getData(sql);
        }
#endregion
        #region 网站及任务分组数据库操作
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
            String sql = "SELECT a.id AS id,title FROM `webgroup` AS a LEFT JOIN USER  AS b ON a.owner = b.id  WHERE username = '"+currentUserName+"'";
            DataTable dt = getData(sql);
            return dt;
        }
        //获取网站组里面网站
        public DataTable getWebsiteInGroup(String group)
        {
            String sql = "SELECT a.title AS title,url FROM website AS a,webgroup AS b WHERE a.groupid=b.id AND b.title = '"+ group + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        //获取当前编辑的网站
        public DataTable getCurtainWebsite(String websiteName,String parentName,String currentWebsiteId)
        {
            String sql = "SELECT * FROM website AS a LEFT JOIN webgroup AS b ON a.groupid = b.id " +
                "WHERE a.title = '"+ websiteName + "' AND b.title = '"+ parentName + "' and a.id!='"+currentWebsiteId+"'";
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
        //通过网站名称获取网站分组信息
        public DataTable getWebGroupInfo(String GroupName,String currentgroupId)
        {
            String sql = "SELECT a.id as id,title,note FROM webgroup AS a LEFT JOIN USER  AS b ON a.owner = b.id WHERE title='"+ GroupName + "' and username='"+currentUserName+ "' AND a.id !='"+ currentgroupId + "'";
            return getData(sql);
        }
        //创建网站分组
        public Boolean creatWebGroup(String [] groupInfo)
        { 

            String currentUserId = getCurrentUserId();
            String sql = "INSERT INTO webgroup VALUES(REPLACE(UUID(),'-',''),'" + groupInfo[0] + "','" + groupInfo[1] + "','" + currentUserId + "')";
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
        #endregion
        #region 任务分组组数据库操作
        /// <summary>
        /// 任务组数据库操作
        /// </summary>
        /// 
        //获取当前用户任务分组
        public DataTable getTaskGroup()
        {
            String sql = "SELECT * FROM taskgroup AS a LEFT JOIN  USER AS b  ON a.owner=b.id WHERE username='"+currentUserName+"'";
            DataTable dt = getData(sql);
            return dt;
        }
        //获取任务组里面网站
        public DataTable getTaskInGroup(String groupid)
        {
            String sql = "SELECT * FROM task AS c LEFT JOIN taskgroup AS a ON c.groupid = a.id " +
                          "WHERE groupid = '"+ groupid + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        //获取当前编辑任务分组
        public DataTable getCurtainTaskGroup(String CurtainNodeText,String CurrentGroupId)
        {
            String sql = "SELECT * FROM taskgroup WHERE title='" + CurtainNodeText + "' and owner = '"+getCurrentUserId()+"' and id != '"+ CurrentGroupId + "'";
            return getData(sql);
        }
        //创建任务分组
        public Boolean creatTaskGroup(String[] groupInfo)
        {
            String sql = "INSERT INTO taskgroup VALUES(REPLACE(UUID(),'-',''),'" + groupInfo[0] + "','" + groupInfo[1] + "','"+ getCurrentUserId()+ "')";
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
            String sql = "DELETE FROM task WHERE groupid = '" + groupID + "'";
            if (changeDataWithoutReturn(sql))
            {
                 sql = "DELETE from taskgroup WHERE id='" + groupID + "'";
                return changeDataWithoutReturn(sql);
            }
            return false;
        }
#endregion

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



        //查找包含搜索关键字的分组和网站
        public DataTable searchwebsite(String keyword)
        {
            String sql = "SELECT groupid,b.title AS groupname ,a.title AS website " +
                "FROM website AS a LEFT JOIN webgroup AS b ON a.groupid=b.id " +
                "WHERE (a.title LIKE '%"+keyword+"%' OR b.title LIKE '%"+keyword+"%') and owner='"+getCurrentUserId()+"' ORDER BY groupid";
            return getData(sql);
        }
        #region adminForm 界面操作
        /// <summary>
        /// adminForm 界面操作
        /// </summary>
        /// 
        //获取总的条目数
        public int getTotalNum(String tableame)
        {
            int totalNum = 0;
            String sql = "select count(*) as number from " + tableame;
            DataTable dt = getData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                //totalNum = Convert.ToInt32(getData(sql).Rows[0]["number"] as String);
                totalNum = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            }
            return totalNum;
        }
        //获取当前需要的记录,总记录处
        public DataTable getDataResult(String tableName,int pageIndex,int pageSize)
        {
            int start = (pageIndex - 1) * pageSize;
            String sql = "SELECT * FROM " + tableName + " LIMIT " + start + "," + pageSize;
            return getData(sql);
        }
        //获取分类显示处有几个类
        public DataTable getClassifyType(String tableName,String ClassifyField)
        {
            //String sql;
            //if (ClassifyField == "usertype")
            //{
            //    sql = "SELECT DISTINCT IFNULL(" + ClassifyField + ",'未知') AS " + ClassifyField + " FROM " + tableName;
            //}
            //else
            //{
            //    sql = "SELECT DISTINCT IFNULL(b.title,'未知') AS newstype FROM news AS a LEFT JOIN taskgroup AS b ON a.newstype = b.id";
            //}
            String sql = "SELECT DISTINCT IFNULL(" + ClassifyField + ",'未知') AS " + ClassifyField + " FROM " + tableName;
            return getData(sql);
        }
        //获取分类显示处的数据
        public DataTable getClassifyResult(String tableName,String condition,String conditionValue)
        {
            String sql = "SELECT * FROM " + tableName;
            String where = "";
            if (condition!=null&&(!condition.Trim().Equals(""))&& conditionValue != null && (!conditionValue.Trim().Equals("")))
            {
                where = " WHERE " + condition + " ='" + conditionValue + "'";
            }
            sql += where;
            return getData(sql);
        }
        //更新审核状态
        public Boolean updataCheckStatus(string tableName,string id,string newStatus)
        {
            String sql = "UPDATE " + tableName + " SET checkstatus = '" + newStatus + "' WHERE id ='" + id + "'";
            return changeDataWithoutReturn(sql);
        }
        //插入日志信息
        public Boolean insertLogInfo(String [] logInfo)
        {
            string sql = "select id from code where title='" + logInfo[2] + "'";
            logInfo[2] = (string)getData(sql).Rows[0].ItemArray[0];
            sql = "INSERT INTO `log` VALUES(REPLACE(UUID(),'-',''),'"+ logInfo [0]+ "','"+ logInfo[1] + "','" + logInfo[2] + "','" + logInfo[3] + "','" + logInfo[4] + "')";
            return changeDataWithoutReturn(sql);
        }
        
        ////获取日志相关信息
        //public DataTable getlogRelateInfo()
        //{
        //    String sql = "SELECT DATABASE()";
        //    DataTable dt1 = getData(sql);
        //    return dt1;
        //}
        ////获取状态
        //public DataTable getStatus(String tableName)
        //{
        //    String sql = "SELECT DISTINCT checkstatus, CASE WHEN checkstatus ='-1' THEN '审核未通过' " +
        //                 "WHEN checkstatus = '1' THEN '审核通过' ELSE '未审核' END `Status` FROM " + tableName;
        //    return getData(sql);
        //}
        //获取所有的审核状态类型
        public DataTable getAllStatus()
        {
            String sql = "SELECT * FROM CODE WHERE id LIKE '%001___'";
            return getData(sql);
        }
        #endregion
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
