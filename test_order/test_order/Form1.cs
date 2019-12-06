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

namespace test_order
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "SteelBlue.ssk";
        }





        private void insert_data(string order,string time)
        {
            //打开连接sql数据库
            //远程数据库
            SqlConnection dbConnection;
            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //MessageBox.Show(dt);
            string sql_1 = "INSERT INTO Dish_Name(f_course,D_time)";
            sql_1 += " VALUES ('" + order + "','" + time + "')";

            SqlCommand cmd = new SqlCommand(sql_1, dbConnection);
            cmd.ExecuteNonQuery();

            dbConnection.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            //打开连接sql数据库
            //远程数据库
            SqlConnection dbConnection;
            string strcon = "server=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;Connection Timeout=1200;";
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //插入数据
            string o1 = button1.Text;
            

            string dt = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString();

            //string dt = System.DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss：ffff");

            //MessageBox.Show(dt);
            string sql_1 = "INSERT INTO Dish_Name(f_course,D_time)";
            sql_1 += " VALUES ('" + o1 + "','" + dt +  "')";

            SqlCommand cmd = new SqlCommand(sql_1, dbConnection);
            cmd.ExecuteNonQuery();

            dbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //打开连接sql数据库
            //远程数据库
            SqlConnection dbConnection;
            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //string strcon = "sever=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //插入数据
            string o1 = button2.Text;


            string dt = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString();

            //string dt = System.DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss：ffff");

            //MessageBox.Show(dt);
            string sql_1 = "INSERT INTO Dish_Name(f_course,D_time)";
            sql_1 += " VALUES ('" + o1 + "','" + dt + "')";

            SqlCommand cmd = new SqlCommand(sql_1, dbConnection);
            cmd.ExecuteNonQuery();

            dbConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //插入数据
            string o1 = button3.Text;
            string dt = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString();
            insert_data(o1, dt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //插入数据
            string o1 = button4.Text;
            string dt = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString();
            insert_data(o1, dt);
        }
    }
}
