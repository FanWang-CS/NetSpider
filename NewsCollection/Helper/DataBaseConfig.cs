using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCollection.Dao
{
    /// <summary>
    /// 本地连接数据库配置
    /// </summary>
    class DataBaseConfig
    {
        //数据库地址
        public static String ip = "localhost";
        //数据库端口
        public static int port = 3306;
        //登录用户名
        public static String uid = "root";
        //登录密码
        public static String psw = "root";
        //使用的数据库名
        public static String databaseName = "newscollection";
        //编码格式
        public static String encoding = "utf8";
    }
}
