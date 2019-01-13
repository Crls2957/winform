using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 信息实体类
/// </summary>

namespace WindowsFormsApp1
{
    class Stu
    {
        private String name; //学生姓名
        private String id; //学生编号
        private String chinese; //语文成绩
        private String  math; //数学成绩
        private String english; //英语成绩


        
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string Chinese { get => chinese; set => chinese = value; }
        public string Math { get => math; set => math = value; }
        public string English { get => english; set => english = value; }
    }
}
