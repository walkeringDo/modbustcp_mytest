using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 订单管理系统
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "Calmness.ssk";
        }

        public string OutData = "";
        public string OutTable = "";
        public string strserver = "";
        public string struser = "";
        public string strpwd = "";

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "数据表名称：" + OutTable;
            try
            {
                using (SqlConnection con = new SqlConnection("Server=" + strserver + ";database=" + OutData + ";Uid=" + struser + ";Pwd=" + strpwd))
                {
                    string strSql = "select * from " + OutTable + "";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(strSql, con);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt.DefaultView;
                    this.dataGridView1.Columns["D_time"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=192.168.2.199;database=test;uid=sa;pwd=AAaa00!!";
            try
            {
                string startTime = dateTimePicker2.Value.ToString();//.Remove(9);

                //MessageBox.Show(startTime);
                string endTime = dateTimePicker3.Value.ToString();//.Remove(9);

                con.Open();
                string sql_look;
                sql_look = "select * from Menu_statistics where D_time>='" + startTime + "'and D_time<='" + endTime + "'";

               
                SqlCommand cmd1 = new SqlCommand(sql_look, con);
                SqlDataAdapter da = new SqlDataAdapter(sql_look, con);
                DataSet dataset = new DataSet();
                int count = da.Fill(dataset);
                if (count < 1)
                {
                    MessageBox.Show("查询的时间段没有设置时效信息，请检查");
                }
                Invoke((EventHandler)delegate
                {
                    label3.Text = count.ToString ();
                });
                dataGridView1.DataSource = dataset.Tables[0];
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].Width = 270;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }




        private void SaveAs() //导出成Excel
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To";
            saveFileDialog.ShowDialog();
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string str = "";
            try
            {
                //写标题
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dataGridView1.Columns[i].HeaderText;
                }
                sw.WriteLine(str);
                //写内容
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        tempStr += dataGridView1.Rows[j].Cells[k].Value.ToString();
                    }
                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }

        public void ExportData(DataGridView srcDgv, string fileName)//导出数据,传入一个datagridview和一个文件路径
        {
            string type = fileName.Substring(fileName.IndexOf(".") + 1);//获得数据类型
            if (type.Equals("xls", StringComparison.CurrentCultureIgnoreCase))//Excel文档
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                try
                {
                    excel.DisplayAlerts = false;
                    excel.Workbooks.Add(true);
                    excel.Visible = false;
                    for (int i = 0; i < srcDgv.Columns.Count; i++)//设置标题
                    {
                        excel.Cells[2, i + 1] = srcDgv.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < srcDgv.Rows.Count; i++)//填充数据
                    {
                        for (int j = 0; j < srcDgv.Columns.Count; j++)
                        {
                            if (srcDgv[j, i].ValueType.ToString() == "System.Byte[]")
                            {
                                excel.Cells[i + 3, j + 1] = "System.Byte[]";
                            }
                            else
                            {
                                excel.Cells[i + 3, j + 1] = srcDgv[j, i].Value;
                            }
                        }
                    }
                    excel.Workbooks[1].SaveCopyAs(fileName);//保存
                }
                finally
                {
                    excel.Quit();
                }
                return;
            }
            ////保存Word文件
            //if (type.Equals("doc", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    object path = fileName;
            //    Object none = System.Reflection.Missing.Value;
            //    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            //    Microsoft.Office.Interop.Word.Document document = wordApp.Documents.Add(ref none, ref none, ref none, ref none);
            //    //建立表格
            //    Microsoft.Office.Interop.Word.Table table = document.Tables.Add(document.Paragraphs.Last.Range, srcDgv.Rows.Count + 1, srcDgv.Columns.Count, ref none, ref none);
            //    try
            //    {

            //        for (int i = 0; i < srcDgv.Columns.Count; i++)//设置标题
            //        {
            //            table.Cell(1, i + 1).Range.Text = srcDgv.Columns[i].HeaderText;
            //        }

            //        for (int i = 0; i < srcDgv.Rows.Count; i++)//填充数据
            //        {
            //            for (int j = 0; j < srcDgv.Columns.Count; j++)
            //            {
            //                string a = srcDgv[j, i].ValueType.ToString();
            //                if (a == "System.Byte[]")
            //                {
            //                    PictureBox pp = new PictureBox();
            //                    byte[] pic = (byte[])(srcDgv[j, i].Value); //将数据库中的图片转换成二进制流
            //                    MemoryStream ms = new MemoryStream(pic);	//将字节数组存入到二进制流中
            //                    pp.Image = Image.FromStream(ms);           //二进制流Image控件中显示
            //                    pp.Image.Save(@"C:\wxk.bmp");               //将图片存入到指定的路径
            //                    object aaa = table.Cell(i + 2, j + 1).Range;
            //                    wordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //                    wordApp.Selection.InlineShapes.AddPicture(@"C:\wxk.bmp", ref none, ref none, ref aaa);
            //                    pp.Dispose();
            //                }
            //                else
            //                {
            //                    table.Cell(i + 2, j + 1).Range.Text = srcDgv[j, i].Value.ToString();
            //                }
            //            }
            //        }
            //        document.SaveAs(ref path, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none);
            //        document.Close(ref none, ref none, ref none);
            //        if (File.Exists(@"C:\wxk.bmp"))
            //        {
            //            File.Delete(@"C:\wxk.bmp");
            //        }
            //    }
            //    finally
            //    {
            //        wordApp.Quit(ref none, ref none, ref none);
            //    }
            //}
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string savePath = "";
            //if (radioButton1.Checked == true)
            //{
            //    saveFileDialog1.Filter = "WORD(*.doc)|*.doc";
            //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //    {
            //        savePath = saveFileDialog1.FileName;
            //        ExportData(dataGridView1, savePath);
            //    }
            //}
            if (radioButton2.Checked == true)
            {
                saveFileDialog1.Filter = "EXCEL(*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    savePath = saveFileDialog1.FileName;
                    ExportData(dataGridView1, savePath);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
