using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 连接数据库工具类
/// </summary>
namespace WindowsFormsApp1
{
    class DBhelper
    {
        //数据库连接字符串，本地登录
        private static String connString = "server=localhost;database=stu;integrated security=true";
        //声明连接对象
        private static SqlConnection sqlConnection = null;

        public static SqlConnection getConn()
        {
            try
            {
                sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
            }
            catch
            {
                throw;
            }
            return sqlConnection;
        }
        public static void close(SqlConnection sqlConnection)
        {
            if (sqlConnection != null)
            {
                try
                {
                    sqlConnection.Close();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
