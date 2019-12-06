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

namespace 订单管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "Calmness.ssk";
        }
        //远程数据库
        SqlConnection dbConnection;

        string strcon = "Data Source=192.168.2.199;Database=test;Uid=sa;Pwd=AAaa00!!;";

        //登录
        private void button1_Click(object sender, EventArgs e)
        {
            string Name, pwd;
            Name = textBox1.Text.Trim();
            pwd = textBox2.Text.Trim();
            ////打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            string sql_2 = "Select * from User_test";
            SqlCommand cmd = new SqlCommand(sql_2, dbConnection);

            //MessageBox.Show("123");

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string name_TEST = reader["name"].ToString().Trim();
            string pwd_TEST = reader["pwd"].ToString().Trim();

            dbConnection.Close();

            if (name_TEST != Name || pwd_TEST != pwd)
            {
                MessageBox.Show("用户名或密码输入有误!!");
            }
            else
            {
                Form2 outdata = new Form2();
                outdata.OutData = "test";
                outdata.OutTable = "Menu_statistics";
                outdata.strserver = "192.168.2.199";
                outdata.struser = "sa";
                outdata.strpwd = "AAaa00!!";
                outdata.ShowDialog();
            }
        }
    }
}
