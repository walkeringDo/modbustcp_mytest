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

namespace 炒菜单测机
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "SteelBlue.ssk";
        }
        //远程数据库
        SqlConnection dbConnection;


        private void clear_face()
        {
            Invoke((EventHandler)delegate
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";
                textBox24.Text = "";
                textBox25.Text = "";
                textBox26.Text = "";
                textBox27.Text = "";
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == "" && textBox8.Text == "" && textBox9.Text == "" && textBox10.Text == "" && textBox11.Text == "" && textBox12.Text == "" && textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "" && textBox17.Text == "" && textBox18.Text == "" && textBox19.Text == "" && textBox20.Text == "" && textBox21.Text == "" && textBox22.Text == "" && textBox23.Text == "" && textBox24.Text == "" && textBox25.Text == "" && textBox26.Text == "" && textBox27.Text == "")
            {
                MessageBox.Show("没有参数,请填写菜品参数再写入数据库中!");
                return;
            }
            //打开数据库
            string strcon = "Data Source=" + textBox28.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            string sql_in = "INSERT INTO Typeofdish(F_course,M_material,Accessories,Heating,Oil_time,Oil_weight,Water_time,Water_weight,Vinegar_time,Vinegar_weight,Shotgun_time,Shotgun_weight,MSG_time,MSG_weight,Sugar_time,Sugar_weight,Salt_time,Salt_weight,Ch_time,Ch_weight,Scallion_time,Scallion_weight,Ginger_time,Ginger_weight,Garlic_time,Garlic_weight,Washing)";
            sql_in += " VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + textBox19.Text + "','" + textBox20.Text + "','" + textBox21.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + textBox24.Text + "','" + textBox25.Text + "','" + textBox26.Text + "','" + textBox27.Text + "')";
            SqlCommand cmd = new SqlCommand(sql_in,dbConnection);
            cmd.ExecuteNonQuery();

            clear_face();
            dbConnection.Close();
        }
    }
}
