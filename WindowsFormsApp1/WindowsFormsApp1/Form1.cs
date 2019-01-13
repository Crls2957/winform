using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //声明操作对象
        Operation operation = new Operation();
        //声明数据库连接对象
        SqlConnection sqlConnection = null;

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Boolean flag = operation.operate(comboBox1.Text);
            if (flag)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "修改数据成功";
                listView1.Items.Add(listViewItem);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "修改数据失败";
                listView1.Items.Add(listViewItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            sqlConnection = DBhelper.getConn();
            if (sqlConnection != null)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "数据库连接成功";
                ListViewItem listViewItem1 = new ListViewItem();
                listViewItem1.Text = "连接状态："+sqlConnection.State;
                ListViewItem listViewItem2 = new ListViewItem();
                listViewItem2.Text = "SQL server实例的名称：luosen-PC";
                ListViewItem listViewItem3 = new ListViewItem();
                listViewItem3.Text = "数据库名称：stu";
                ListViewItem listViewItem4 = new ListViewItem();
                listViewItem4.Text = "SQL server版本：10.50.4000.0";
                ListViewItem listViewItem5 = new ListViewItem();
                listViewItem5.Text = "数据库客户端ID：luosen-PC";
                ListViewItem listViewItem6 = new ListViewItem();
                listViewItem6.Text = "停止尝试并生成错误的等待时间："+sqlConnection.ConnectionTimeout;
                ListViewItem listViewItem7 = new ListViewItem();
                listViewItem7.Text = "网络数据包大小："+sqlConnection.PacketSize;
                listView1.Items.Add(listViewItem);
                listView1.Items.Add(listViewItem1);
                listView1.Items.Add(listViewItem2);
                listView1.Items.Add(listViewItem3);
                listView1.Items.Add(listViewItem4);
                listView1.Items.Add(listViewItem5);
                listView1.Items.Add(listViewItem6);
                listView1.Items.Add(listViewItem7);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "数据库连接失败";
                listView1.Items.Add(listViewItem);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (sqlConnection != null)
            {
                DBhelper.close(sqlConnection);
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "数据库关闭成功";
                listView1.Items.Add(listViewItem);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "数据库未连接";
                listView1.Items.Add(listViewItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Boolean flag=operation.operate(comboBox1.Text);
            if (flag)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "添加数据成功";
                listView1.Items.Add(listViewItem);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "添加数据失败";
                listView1.Items.Add(listViewItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Boolean flag = operation.operate(comboBox1.Text);
            if (flag)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "删除数据成功";
                listView1.Items.Add(listViewItem);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "删除数据失败";
                listView1.Items.Add(listViewItem);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            this.listView1.View = View.Details;
            this.listView1.Columns.Add("编号", 50, HorizontalAlignment.Left);
            this.listView1.Columns.Add("姓名", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("学号", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("语文", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("数学", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("英语", 100, HorizontalAlignment.Left);
            LinkedList<Stu> linkedList = operation.select(comboBox1.Text);
            int n = 1;
            foreach (Stu stu in linkedList) { 
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = n.ToString();
                listViewItem.SubItems.Add(stu.Name);
                listViewItem.SubItems.Add(stu.Id);
                listViewItem.SubItems.Add(stu.Chinese);
                listViewItem.SubItems.Add(stu.Math);
                listViewItem.SubItems.Add(stu.English);
                listView1.Items.Add(listViewItem);
                n++;
            }
        }
    }
}
