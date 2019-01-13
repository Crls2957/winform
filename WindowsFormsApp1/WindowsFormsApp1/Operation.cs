using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 对数据库进行操作
/// </summary>
namespace WindowsFormsApp1
{
    class Operation
    {
        //声明数据库连接对象
        SqlConnection sqlConnection = null;
        //声明数据库语句操作对象
        SqlCommand sqlCommand = null;
        //声明结果操作对象
        SqlDataReader sqlDataReader = null;

        //添加,修改，删除数据
        public Boolean operate(String sql)//sql,传入的DML语句
        {
            sqlConnection = DBhelper.getConn();
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = sql;
            int count = sqlCommand.ExecuteNonQuery();
            DBhelper.close(sqlConnection);
            return count>0?true:false;
        }
        //查询数据
        public  LinkedList<Stu> select(String sql)
        {
            LinkedList<Stu> linkedList = new LinkedList<Stu>();
            sqlConnection = DBhelper.getConn();
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = sql;
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Stu stu = new Stu();
                stu.Name = sqlDataReader["name"].ToString().Trim();
                stu.Id = sqlDataReader["id"].ToString().Trim();
                stu.Chinese= sqlDataReader["chinese"].ToString().Trim();
                stu.Math= sqlDataReader["math"].ToString().Trim();
                stu.English= sqlDataReader["english"].ToString().Trim();
                linkedList.AddLast(stu);
            }
            return linkedList;
        }
    }
}
