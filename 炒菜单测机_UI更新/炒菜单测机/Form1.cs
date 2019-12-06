using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModbusTCP;
using System.Data.SqlClient;
using System.Diagnostics;

namespace 炒菜单测机
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "SteelBlue.ssk";           
        }

        private ModbusTCP.Master MBmaster;
        //private ModbusTCP.Master MBmaster1;
        private ModbusTCP.Master MBmaster2;
        private ModbusTCP.Master MBmaster3;
        private ModbusTCP.Master MBmaster4;
        private ModbusTCP.Master MBmaster5;
        private ModbusTCP.Master MBmaster6;
        private ModbusTCP.Master MBmaster7;
        private ModbusTCP.Master MBmaster8;
        private ModbusTCP.Master MBmaster9;
        private ModbusTCP.Master MBmaster10;
        private ModbusTCP.Master MBmaster11;
        private ModbusTCP.Master MBmaster12;
        private ModbusTCP.Master MBmaster13;
        private ModbusTCP.Master MBmaster14;




        //开启锅 给1秒的 1状态再复位0
        private void button1_Click(object sender, EventArgs e)
        {
            //start_modbustcp(); //开启通讯
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2248"), false);
        }
        
        //private void start_modbustcp()
        //{
        //    try
        //    {
        //        // Create new modbus master and add event functions
        //        MBmaster = new Master("192.168.0.4", 502);

        //        Invoke((EventHandler) delegate
        //        {
        //            label1.BackColor = Color.Green;
        //            label1.Text = "已连接到台达dvp24sv PLC！！";
        //        });
        //    }
        //    catch (SystemException error)
        //    {
        //        //MessageBox.Show(error.Message);
        //        Invoke((EventHandler) delegate
        //        {
        //            label1.BackColor = Color.Red;
        //            label1.Text = "未连接到台达dvp24sv PLC！！";
        //        });

        //        Thread.Sleep(50);
        //        //if (MBmaster.connected == false)
        //        //{
        //        MBmaster = new Master("192.168.0.4", 502);
        //        //}
        //        Invoke((EventHandler)delegate
        //        {
        //            label1.BackColor = Color.Green;
        //            label1.Text = "已连接到台达dvp24sv PLC！！";
        //        });
        //    }

        //}

        //锅停止
        //锅1急停

            //
        private void button2_Click(object sender, EventArgs e)
        {
            //start_modbustcp();//开启通讯
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }
        //手动洗锅
        private void button4_Click(object sender, EventArgs e)
        {
            //start_modbustcp();//开启通讯
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2263"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2263"), false);
        }

        //手动转锅
        private void button3_Click(object sender, EventArgs e)
        {
            //start_modbustcp();//开启通讯
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2264"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2264"), false);
        }


        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        // ------------------------------------------------------------------------
        // Show values in selected way
        // ------------------------------------------------------------------------
        private void ShowAs1(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data1);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData1.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs2(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data2);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData2.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs3(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data3);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData3.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs4(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data4);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData4.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs5(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data5);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData5.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs6(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data6);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData6.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs7(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data7);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData7.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs8(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data8);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData8.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs9(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data9);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData9.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs10(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data10);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData10.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs11(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data11);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData11.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs12(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data12);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData12.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs13(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data13);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData13.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void ShowAs14(object sender, System.EventArgs e)
        {
            RadioButton rad;
            if (sender is RadioButton)
            {
                rad = (RadioButton)sender;
                if (rad.Checked == false) return;
            }

            bool[] bits = new bool[1];
            int[] word = new int[1];

            // Convert data to selected data type
            if (radBits.Checked == true)
            {
                System.Collections.BitArray bitArray = new System.Collections.BitArray(data14);
                bits = new bool[bitArray.Count];
                bitArray.CopyTo(bits, 0);
            }

            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in grpData14.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToInt16(ctrl.Tag);
                    if (radBits.Checked)
                    {
                        if (x <= bits.GetUpperBound(0))
                        {
                            Invoke((EventHandler)delegate {
                                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                                ctrl.Visible = true;
                            });
                            //                     ctrl.Text = Convert.ToByte(bits[x]).ToString();
                            //ctrl.Visible = true;
                        }
                        else
                            Invoke((EventHandler)delegate { ctrl.Text = ""; });

                    }
                }
            }

        }
        private void MO_connect()
        {
            ////连通炒菜机1
            MBmaster = new Master("192.168.0.4", 502);
            MBmaster.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData1);

            /*
             * //炒菜机器人还未装备好
            MBmaster2 = new Master("192.168.0.4", 502);
            MBmaster2.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster2.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData2);
            MBmaster3 = new Master("192.168.0.4", 502);
            MBmaster3.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster3.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData3);
            MBmaster4 = new Master("192.168.0.4", 502);
            MBmaster4.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster4.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData4);
            MBmaster5 = new Master("192.168.0.4", 502);
            MBmaster5.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster5.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData5);
            MBmaster6 = new Master("192.168.0.4", 502);
            MBmaster6.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster6.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData6);
            MBmaster7 = new Master("192.168.0.4", 502);
            MBmaster7.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster7.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData7);
            MBmaster8 = new Master("192.168.0.4", 502);
            MBmaster8.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster8.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData8);
            MBmaster9 = new Master("192.168.0.4", 502);
            MBmaster9.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster9.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData9);
            MBmaster10 = new Master("192.168.0.4", 502);
            MBmaster10.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster10.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData10);
            MBmaster11 = new Master("192.168.0.4", 502);
            MBmaster11.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster11.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData11);
            MBmaster12 = new Master("192.168.0.4", 502);
            MBmaster12.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster12.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData12);
            MBmaster13 = new Master("192.168.0.4", 502);
            MBmaster13.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster13.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData13);
            MBmaster14 = new Master("192.168.0.4", 502);
            MBmaster14.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster14.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData14);
            */
            Watchdog.Enabled = true;

            //炒菜机1界面显示效果
            if (MBmaster.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label1.BackColor = Color.Red;
                    label1.Text = "未连接到台达dvp24sv PLC！！";

                    label5.BackColor = Color.Red;
                    label5.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster = new Master("192.168.0.4", 502);
            }
            if (MBmaster.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label1.BackColor = Color.Green;
                    label1.Text = "已连接到台达dvp24sv PLC！！";

                    label5.BackColor = Color.Green;
                    label5.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            /*
            //炒菜机2界面显示效果
            if (MBmaster2.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label6.BackColor = Color.Red;
                    label6.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster2 = new Master("192.168.0.4", 502);
            }
            if (MBmaster2.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label6.BackColor = Color.Green;
                    label6.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机3界面显示效果
            if (MBmaster3.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label9.BackColor = Color.Red;
                    label9.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster3 = new Master("192.168.0.4", 502);
            }
            if (MBmaster3.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label9.BackColor = Color.Green;
                    label9.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机4界面显示效果
            if (MBmaster4.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label11.BackColor = Color.Red;
                    label11.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster4 = new Master("192.168.0.4", 502);
            }
            if (MBmaster4.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label11.BackColor = Color.Green;
                    label11.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机5界面显示效果
            if (MBmaster5.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label13.BackColor = Color.Red;
                    label13.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster5 = new Master("192.168.0.4", 502);
            }
            if (MBmaster5.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label13.BackColor = Color.Green;
                    label13.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机6界面显示效果
            if (MBmaster6.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label15.BackColor = Color.Red;
                    label15.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster6 = new Master("192.168.0.4", 502);
            }
            if (MBmaster6.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label15.BackColor = Color.Green;
                    label15.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机7界面显示效果
            if (MBmaster7.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label17.BackColor = Color.Red;
                    label17.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster7 = new Master("192.168.0.4", 502);
            }
            if (MBmaster7.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label17.BackColor = Color.Green;
                    label17.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机8界面显示效果
            if (MBmaster8.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label19.BackColor = Color.Red;
                    label19.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster8 = new Master("192.168.0.4", 502);
            }
            if (MBmaster8.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label19.BackColor = Color.Green;
                    label19.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机10界面显示效果
            if (MBmaster10.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label23.BackColor = Color.Red;
                    label23.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster10 = new Master("192.168.0.4", 502);
            }
            if (MBmaster10.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label23.BackColor = Color.Green;
                    label23.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机11界面显示效果
            if (MBmaster11.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label25.BackColor = Color.Red;
                    label25.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster11 = new Master("192.168.0.4", 502);
            }
            if (MBmaster11.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label25.BackColor = Color.Green;
                    label25.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机12界面显示效果
            if (MBmaster12.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label27.BackColor = Color.Red;
                    label27.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster12 = new Master("192.168.0.4", 502);
            }
            if (MBmaster12.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label27.BackColor = Color.Green;
                    label27.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机13界面显示效果
            if (MBmaster13.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label29.BackColor = Color.Red;
                    label29.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster13 = new Master("192.168.0.4", 502);
            }
            if (MBmaster13.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label29.BackColor = Color.Green;
                    label29.Text = "已连接到台达dvp24sv PLC！！";
                });
            }

            //炒菜机14界面显示效果
            if (MBmaster14.connected == false)
            {
                Invoke((EventHandler)delegate
                {
                    label31.BackColor = Color.Red;
                    label31.Text = "未连接到台达dvp24sv PLC！！";
                });
                MBmaster14 = new Master("192.168.0.4", 502);
            }
            if (MBmaster14.connected == true)
            {
                Invoke((EventHandler)delegate
                {
                    label31.BackColor = Color.Green;
                    label31.Text = "已连接到台达dvp24sv PLC！！";
                });
            }
            */
        }
        private void Watchdog_Tick(object sender, EventArgs e)
        {
            MBmaster.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));

            /*
            MBmaster2.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));   
            MBmaster3.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster4.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster5.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster6.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster7.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster8.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster9.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster10.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster11.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster12.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster13.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            MBmaster14.WriteSingleRegister(0xFF, 0x1044, BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)0xc1)));
            */
        }

        //炒菜机器人工作状态键
        public static int Sta1 = 0;//炒菜机器人1
        public static int Sta1_2 = 0;
        public static int Sta2 = 0;//炒菜机器人2
        public static int Sta2_2 = 0;
        public static int Sta3 = 0;//炒菜机器人3
        public static int Sta3_2 = 0;
        public static int Sta4 = 0;//炒菜机器人4
        public static int Sta4_2 = 0;
        public static int Sta5 = 0;//炒菜机器人5
        public static int Sta5_2 = 0;
        public static int Sta6 = 0;//炒菜机器人6
        public static int Sta6_2 = 0;
        public static int Sta7 = 0;//炒菜机器人7
        public static int Sta7_2 = 0;
        public static int Sta8 = 0;//炒菜机器人8
        public static int Sta8_2 = 0;
        public static int Sta9 = 0;//炒菜机器人9
        public static int Sta9_2 = 0;
        public static int Sta10 = 0;//炒菜机器人10
        public static int Sta10_2 = 0;
        public static int Sta11 = 0;//炒菜机器人11
        public static int Sta11_2 = 0;
        public static int Sta12 = 0;//炒菜机器人12
        public static int Sta12_2 = 0;
        public static int Sta13 = 0;//炒菜机器人13
        public static int Sta13_2 = 0;
        public static int Sta14 = 0;//炒菜机器人14
        public static int Sta14_2 = 0;


        // 查看炒菜当前人数
        Thread Count;
        //数据库中点菜数据,炒菜机器人工作状态线程
        Thread Rob;

        Thread pot1;
        Thread pot2;
        Thread pot3;
        Thread pot4;
        Thread pot5;
        Thread pot6;
        Thread pot7;
        Thread pot8;
        Thread pot9;
        Thread pot10;
        Thread pot11;
        Thread pot12;
        Thread pot13;
        Thread pot14;
        Thread pot15;
        Thread pot16;
        Thread pot17;
        Thread pot18;
        Thread pot19;
        Thread pot20;
        Thread pot21;
        Thread pot22;
        Thread pot23;
        Thread pot24;
        Thread pot25;
        Thread pot26;
        Thread pot27;
        Thread pot28;

        //监控炒菜机器人的状态(少水,少油等),并将信息显示到界面上
        Thread Mo1;
        Thread Mo2;
        Thread Mo3;
        Thread Mo4;
        Thread Mo5;
        Thread Mo6;
        Thread Mo7;
        Thread Mo8;
        Thread Mo9;
        Thread Mo10;
        Thread Mo11;
        Thread Mo12;
        Thread Mo13;
        Thread Mo14;



        //查看菜单数据库中有没有数据
        private int connect_sql()
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //读取数据库数据
            string sql_1 = "SELECT  * FROM Dish_Name";
            SqlCommand cmd = new SqlCommand(sql_1 ,dbConnection);
            int count = 0;
            SqlDataReader m_readr = cmd.ExecuteReader();
            if (m_readr.Read())
                count = 1;
            //count = (int)cmd.ExecuteScalar();
            m_readr.Close();
            dbConnection.Close();
            //MessageBox.Show("1233");
            return count;
        }

        //判断点餐人数到lable32
        public static int a_count = 0;

        private string GetStrcon_1()
        {
            
            //以后可以另外设立数据库
            string strcon_1 = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            return strcon_1;
        }
        private void show_num()
        {
            while (true)
            {
                SqlConnection dbConnection_1;
                string strcon_1 = GetStrcon_1();
                dbConnection_1 = new SqlConnection(strcon_1);
                dbConnection_1.Open();

                //菜单数据库中读取最早的(菜名).
                string sql_4 = "Select count(*) from Dish_Name";
                SqlCommand cmd_x = new SqlCommand(sql_4, dbConnection_1);

                a_count = Convert.ToInt32(cmd_x.ExecuteScalar());


                if (a_count == 0)
                {
                    Invoke((EventHandler)delegate
                    {
                        label32.BackColor = Color.Gray;
                        label32.Text = "暂时无人点餐";
                    });
                }
                else
                {

                    Invoke((EventHandler)delegate
                    {
                        label32.BackColor = Color.Green;
                        label32.Text = "目前订餐等待人数：" + a_count.ToString();
                    });
                }
                dbConnection_1.Close();
            }
        }
        //从菜单数据库中读取最早的一条信息(菜名).
        //1
        private string Read_Order1()
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //菜单数据库中读取最早的(菜名).
            string sql_2 = "Select * from Dish_Name where D_time = (select min(D_time) from Dish_Name) ";
            SqlCommand cmd = new SqlCommand(sql_2,dbConnection);

            //MessageBox.Show("123");

            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            //向历史数据库中添加该数据
            string Order_N = dt.Tables[0].Rows[0]["f_course"].ToString();
            string Order_T = dt.Tables[0].Rows[0]["D_time"].ToString();
            string sql_in = "INSERT INTO Menu_statistics(f_course,D_time)";
            sql_in += " VALUES ('" + Order_N + "','" + Order_T + "')";
            SqlCommand cmd_in = new SqlCommand(sql_in, dbConnection);
            cmd_in.ExecuteNonQuery();

            //从数据库删除该条数据
            string sql_Dle = "delete  from Dish_Name where D_time = (select min(D_time) from Dish_Name)";
            SqlCommand cmd1 = new SqlCommand(sql_Dle,dbConnection);
            cmd1.ExecuteNonQuery();
            dbConnection.Close();

            return Order_N;
        }
        //2
        private string Read_Order2()
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //菜单数据库中读取最早的(菜名).
            string sql_2 = "Select * from Dish_Name where D_time = (select min(D_time) from Dish_Name) ";
            SqlCommand cmd = new SqlCommand(sql_2, dbConnection);

            //MessageBox.Show("123");

            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            string Order_N = dt.Tables[0].Rows[0]["f_course"].ToString();
            string Order_T = dt.Tables[0].Rows[0]["D_time"].ToString();
            string sql_in = "INSERT INTO Dish_Name(f_course,D_time)";
            sql_in += " VALUES ('" + Order_N + "','" + Order_T + "')";


            //从数据库删除该条数据
            string sql_Dle = "delete  from Dish_Name where D_time = (select min(D_time) from Dish_Name)";
            SqlCommand cmd1 = new SqlCommand(sql_Dle, dbConnection);
            cmd1.ExecuteNonQuery();
            dbConnection.Close();

            return Order_N;
        }
        //3
        private string Read_Order3()
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //菜单数据库中读取最早的(菜名).
            string sql_2 = "Select * from Dish_Name where D_time = (select min(D_time) from Dish_Name) ";
            SqlCommand cmd = new SqlCommand(sql_2, dbConnection);

            //MessageBox.Show("123");

            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            string Order_N = dt.Tables[0].Rows[0]["f_course"].ToString();

            //从数据库删除该条数据
            string sql_Dle = "delete  from Dish_Name where D_time = (select min(D_time) from Dish_Name)";
            SqlCommand cmd1 = new SqlCommand(sql_Dle, dbConnection);
            cmd1.ExecuteNonQuery();
            dbConnection.Close();

            return Order_N;
        }
        //4
        private string Read_Order4()
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //菜单数据库中读取最早的(菜名).
            string sql_2 = "Select * from Dish_Name where D_time = (select min(D_time) from Dish_Name) ";
            SqlCommand cmd = new SqlCommand(sql_2, dbConnection);

            //MessageBox.Show("123");

            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            string Order_N = dt.Tables[0].Rows[0]["f_course"].ToString();

            //从数据库删除该条数据
            string sql_Dle = "delete  from Dish_Name where D_time = (select min(D_time) from Dish_Name)";
            SqlCommand cmd1 = new SqlCommand(sql_Dle, dbConnection);
            cmd1.ExecuteNonQuery();
            dbConnection.Close();

            return Order_N;
        }
        //5
        private string Read_Order5()
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //菜单数据库中读取最早的(菜名).
            string sql_2 = "Select * from Dish_Name where D_time = (select min(D_time) from Dish_Name) ";
            SqlCommand cmd = new SqlCommand(sql_2, dbConnection);

            //MessageBox.Show("123");

            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            string Order_N = dt.Tables[0].Rows[0]["f_course"].ToString();

            //从数据库删除该条数据
            string sql_Dle = "delete  from Dish_Name where D_time = (select min(D_time) from Dish_Name)";
            SqlCommand cmd1 = new SqlCommand(sql_Dle, dbConnection);
            cmd1.ExecuteNonQuery();
            dbConnection.Close();

            return Order_N;
        }
        //6
        private string Read_Order6()
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            //菜单数据库中读取最早的(菜名).
            string sql_2 = "Select * from Dish_Name where D_time = (select min(D_time) from Dish_Name) ";
            SqlCommand cmd = new SqlCommand(sql_2, dbConnection);

            //MessageBox.Show("123");

            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            string Order_N = dt.Tables[0].Rows[0]["f_course"].ToString();

            //从数据库删除该条数据
            string sql_Dle = "delete  from Dish_Name where D_time = (select min(D_time) from Dish_Name)";
            SqlCommand cmd1 = new SqlCommand(sql_Dle, dbConnection);
            cmd1.ExecuteNonQuery();
            dbConnection.Close();

            return Order_N;
        }
        //7



        //从配菜数据库查看配菜
        //1
        private string[] Order_Type1(string str)
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            str = "'" + str + "'";
            //从菜名查看该菜配菜单
            string sql_3 = "Select * from Typeofdish where F_course = " + str;
            SqlCommand cmd = new SqlCommand(sql_3, dbConnection);
            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            dbConnection.Close();

            //读取菜品配置参数
            string[] Par = new string[50];
            Par[0] = dt.Tables[0].Rows[0]["M_material"].ToString();//主料
            Par[1] = dt.Tables[0].Rows[0]["Accessories"].ToString();//辅料
            Par[2] = dt.Tables[0].Rows[0]["Heating"].ToString();//加热
            Par[3] = dt.Tables[0].Rows[0]["Oil_time"].ToString();//油时间
            Par[4] = dt.Tables[0].Rows[0]["Oil_weight"].ToString();//油重量
            Par[5] = dt.Tables[0].Rows[0]["Water_time"].ToString();//水时间
            Par[6] = dt.Tables[0].Rows[0]["Water_weight"].ToString();//水重量
            Par[7] = dt.Tables[0].Rows[0]["Vinegar_time"].ToString();//醋时间
            Par[8] = dt.Tables[0].Rows[0]["Vinegar_weight"].ToString();//醋重量
            Par[9] = dt.Tables[0].Rows[0]["Shotgun_time"].ToString();//生抽时间
            Par[10] = dt.Tables[0].Rows[0]["Shotgun_weight"].ToString();//生抽重量
            Par[11] = dt.Tables[0].Rows[0]["MSG_time"].ToString();//味精时间
            Par[12] = dt.Tables[0].Rows[0]["MSG_weight"].ToString();//味精重量
            Par[13] = dt.Tables[0].Rows[0]["Sugar_time"].ToString();//糖时间
            Par[14] = dt.Tables[0].Rows[0]["Sugar_weight"].ToString();//糖重量
            Par[15] = dt.Tables[0].Rows[0]["Salt_time"].ToString();//盐时间
            Par[16] = dt.Tables[0].Rows[0]["Salt_weight"].ToString();//盐重量
            Par[17] = dt.Tables[0].Rows[0]["Scallion_time"].ToString();//葱时间
            Par[18] = dt.Tables[0].Rows[0]["Scallion_weight"].ToString();//葱重量
            Par[19] = dt.Tables[0].Rows[0]["Ch_time"].ToString();//鸡精时间
            Par[20] = dt.Tables[0].Rows[0]["Ch_weight"].ToString();//鸡精重量
            Par[21] = dt.Tables[0].Rows[0]["Ginger_time"].ToString();//生姜时间
            Par[22] = dt.Tables[0].Rows[0]["Ginger_weight"].ToString();//生姜重量
            Par[23] = dt.Tables[0].Rows[0]["Garlic_time"].ToString();//蒜时间
            Par[24] = dt.Tables[0].Rows[0]["Garlic_weight"].ToString();//蒜重量
            Par[25] = dt.Tables[0].Rows[0]["Washing"].ToString();//洗锅

            return Par;
        }
        //2
        private string[] Order_Type2(string str)
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            str = "'" + str + "'";
            //从菜名查看该菜配菜单
            string sql_3 = "Select * from Typeofdish where F_course = " + str;
            SqlCommand cmd = new SqlCommand(sql_3, dbConnection);
            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            dbConnection.Close();

            //读取菜品配置参数
            string[] Par = new string[50];
            Par[0] = dt.Tables[0].Rows[0]["M_material"].ToString();//主料
            Par[1] = dt.Tables[0].Rows[0]["Accessories"].ToString();//辅料
            Par[2] = dt.Tables[0].Rows[0]["Heating"].ToString();//加热
            Par[3] = dt.Tables[0].Rows[0]["Oil_time"].ToString();//油时间
            Par[4] = dt.Tables[0].Rows[0]["Oil_weight"].ToString();//油重量
            Par[5] = dt.Tables[0].Rows[0]["Water_time"].ToString();//水时间
            Par[6] = dt.Tables[0].Rows[0]["Water_weight"].ToString();//水重量
            Par[7] = dt.Tables[0].Rows[0]["Vinegar_time"].ToString();//醋时间
            Par[8] = dt.Tables[0].Rows[0]["Vinegar_weight"].ToString();//醋重量
            Par[9] = dt.Tables[0].Rows[0]["Shotgun_time"].ToString();//生抽时间
            Par[10] = dt.Tables[0].Rows[0]["Shotgun_weight"].ToString();//生抽重量
            Par[11] = dt.Tables[0].Rows[0]["MSG_time"].ToString();//味精时间
            Par[12] = dt.Tables[0].Rows[0]["MSG_weight"].ToString();//味精重量
            Par[13] = dt.Tables[0].Rows[0]["Sugar_time"].ToString();//糖时间
            Par[14] = dt.Tables[0].Rows[0]["Sugar_weight"].ToString();//糖重量
            Par[15] = dt.Tables[0].Rows[0]["Salt_time"].ToString();//盐时间
            Par[16] = dt.Tables[0].Rows[0]["Salt_weight"].ToString();//盐重量
            Par[17] = dt.Tables[0].Rows[0]["Scallion_time"].ToString();//葱时间
            Par[18] = dt.Tables[0].Rows[0]["Scallion_weight"].ToString();//葱重量
            Par[19] = dt.Tables[0].Rows[0]["Ch_time"].ToString();//鸡精时间
            Par[20] = dt.Tables[0].Rows[0]["Ch_weight"].ToString();//鸡精重量
            Par[21] = dt.Tables[0].Rows[0]["Ginger_time"].ToString();//生姜时间
            Par[22] = dt.Tables[0].Rows[0]["Ginger_weight"].ToString();//生姜重量
            Par[23] = dt.Tables[0].Rows[0]["Garlic_time"].ToString();//蒜时间
            Par[24] = dt.Tables[0].Rows[0]["Garlic_weight"].ToString();//蒜重量
            Par[25] = dt.Tables[0].Rows[0]["Washing"].ToString();//洗锅

            return Par;
        }
        //3
        private string[] Order_Type3(string str)
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            str = "'" + str + "'";
            //从菜名查看该菜配菜单
            string sql_3 = "Select * from Typeofdish where F_course = " + str;
            SqlCommand cmd = new SqlCommand(sql_3, dbConnection);
            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            dbConnection.Close();

            //读取菜品配置参数
            string[] Par = new string[50];
            Par[0] = dt.Tables[0].Rows[0]["M_material"].ToString();//主料
            Par[1] = dt.Tables[0].Rows[0]["Accessories"].ToString();//辅料
            Par[2] = dt.Tables[0].Rows[0]["Heating"].ToString();//加热
            Par[3] = dt.Tables[0].Rows[0]["Oil_time"].ToString();//油时间
            Par[4] = dt.Tables[0].Rows[0]["Oil_weight"].ToString();//油重量
            Par[5] = dt.Tables[0].Rows[0]["Water_time"].ToString();//水时间
            Par[6] = dt.Tables[0].Rows[0]["Water_weight"].ToString();//水重量
            Par[7] = dt.Tables[0].Rows[0]["Vinegar_time"].ToString();//醋时间
            Par[8] = dt.Tables[0].Rows[0]["Vinegar_weight"].ToString();//醋重量
            Par[9] = dt.Tables[0].Rows[0]["Shotgun_time"].ToString();//生抽时间
            Par[10] = dt.Tables[0].Rows[0]["Shotgun_weight"].ToString();//生抽重量
            Par[11] = dt.Tables[0].Rows[0]["MSG_time"].ToString();//味精时间
            Par[12] = dt.Tables[0].Rows[0]["MSG_weight"].ToString();//味精重量
            Par[13] = dt.Tables[0].Rows[0]["Sugar_time"].ToString();//糖时间
            Par[14] = dt.Tables[0].Rows[0]["Sugar_weight"].ToString();//糖重量
            Par[15] = dt.Tables[0].Rows[0]["Salt_time"].ToString();//盐时间
            Par[16] = dt.Tables[0].Rows[0]["Salt_weight"].ToString();//盐重量
            Par[17] = dt.Tables[0].Rows[0]["Scallion_time"].ToString();//葱时间
            Par[18] = dt.Tables[0].Rows[0]["Scallion_weight"].ToString();//葱重量
            Par[19] = dt.Tables[0].Rows[0]["Ch_time"].ToString();//鸡精时间
            Par[20] = dt.Tables[0].Rows[0]["Ch_weight"].ToString();//鸡精重量
            Par[21] = dt.Tables[0].Rows[0]["Ginger_time"].ToString();//生姜时间
            Par[22] = dt.Tables[0].Rows[0]["Ginger_weight"].ToString();//生姜重量
            Par[23] = dt.Tables[0].Rows[0]["Garlic_time"].ToString();//蒜时间
            Par[24] = dt.Tables[0].Rows[0]["Garlic_weight"].ToString();//蒜重量
            Par[25] = dt.Tables[0].Rows[0]["Washing"].ToString();//洗锅

            return Par;
        }
        //4
        private string[] Order_Type4(string str)
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            str = "'" + str + "'";
            //从菜名查看该菜配菜单
            string sql_3 = "Select * from Typeofdish where F_course = " + str;
            SqlCommand cmd = new SqlCommand(sql_3, dbConnection);
            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            dbConnection.Close();

            //读取菜品配置参数
            string[] Par = new string[50];
            Par[0] = dt.Tables[0].Rows[0]["M_material"].ToString();//主料
            Par[1] = dt.Tables[0].Rows[0]["Accessories"].ToString();//辅料
            Par[2] = dt.Tables[0].Rows[0]["Heating"].ToString();//加热
            Par[3] = dt.Tables[0].Rows[0]["Oil_time"].ToString();//油时间
            Par[4] = dt.Tables[0].Rows[0]["Oil_weight"].ToString();//油重量
            Par[5] = dt.Tables[0].Rows[0]["Water_time"].ToString();//水时间
            Par[6] = dt.Tables[0].Rows[0]["Water_weight"].ToString();//水重量
            Par[7] = dt.Tables[0].Rows[0]["Vinegar_time"].ToString();//醋时间
            Par[8] = dt.Tables[0].Rows[0]["Vinegar_weight"].ToString();//醋重量
            Par[9] = dt.Tables[0].Rows[0]["Shotgun_time"].ToString();//生抽时间
            Par[10] = dt.Tables[0].Rows[0]["Shotgun_weight"].ToString();//生抽重量
            Par[11] = dt.Tables[0].Rows[0]["MSG_time"].ToString();//味精时间
            Par[12] = dt.Tables[0].Rows[0]["MSG_weight"].ToString();//味精重量
            Par[13] = dt.Tables[0].Rows[0]["Sugar_time"].ToString();//糖时间
            Par[14] = dt.Tables[0].Rows[0]["Sugar_weight"].ToString();//糖重量
            Par[15] = dt.Tables[0].Rows[0]["Salt_time"].ToString();//盐时间
            Par[16] = dt.Tables[0].Rows[0]["Salt_weight"].ToString();//盐重量
            Par[17] = dt.Tables[0].Rows[0]["Scallion_time"].ToString();//葱时间
            Par[18] = dt.Tables[0].Rows[0]["Scallion_weight"].ToString();//葱重量
            Par[19] = dt.Tables[0].Rows[0]["Ch_time"].ToString();//鸡精时间
            Par[20] = dt.Tables[0].Rows[0]["Ch_weight"].ToString();//鸡精重量
            Par[21] = dt.Tables[0].Rows[0]["Ginger_time"].ToString();//生姜时间
            Par[22] = dt.Tables[0].Rows[0]["Ginger_weight"].ToString();//生姜重量
            Par[23] = dt.Tables[0].Rows[0]["Garlic_time"].ToString();//蒜时间
            Par[24] = dt.Tables[0].Rows[0]["Garlic_weight"].ToString();//蒜重量
            Par[25] = dt.Tables[0].Rows[0]["Washing"].ToString();//洗锅

            return Par;
        }
        //5
        private string[] Order_Type5(string str)
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            str = "'" + str + "'";
            //从菜名查看该菜配菜单
            string sql_3 = "Select * from Typeofdish where F_course = " + str;
            SqlCommand cmd = new SqlCommand(sql_3, dbConnection);
            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            dbConnection.Close();

            //读取菜品配置参数
            string[] Par = new string[50];
            Par[0] = dt.Tables[0].Rows[0]["M_material"].ToString();//主料
            Par[1] = dt.Tables[0].Rows[0]["Accessories"].ToString();//辅料
            Par[2] = dt.Tables[0].Rows[0]["Heating"].ToString();//加热
            Par[3] = dt.Tables[0].Rows[0]["Oil_time"].ToString();//油时间
            Par[4] = dt.Tables[0].Rows[0]["Oil_weight"].ToString();//油重量
            Par[5] = dt.Tables[0].Rows[0]["Water_time"].ToString();//水时间
            Par[6] = dt.Tables[0].Rows[0]["Water_weight"].ToString();//水重量
            Par[7] = dt.Tables[0].Rows[0]["Vinegar_time"].ToString();//醋时间
            Par[8] = dt.Tables[0].Rows[0]["Vinegar_weight"].ToString();//醋重量
            Par[9] = dt.Tables[0].Rows[0]["Shotgun_time"].ToString();//生抽时间
            Par[10] = dt.Tables[0].Rows[0]["Shotgun_weight"].ToString();//生抽重量
            Par[11] = dt.Tables[0].Rows[0]["MSG_time"].ToString();//味精时间
            Par[12] = dt.Tables[0].Rows[0]["MSG_weight"].ToString();//味精重量
            Par[13] = dt.Tables[0].Rows[0]["Sugar_time"].ToString();//糖时间
            Par[14] = dt.Tables[0].Rows[0]["Sugar_weight"].ToString();//糖重量
            Par[15] = dt.Tables[0].Rows[0]["Salt_time"].ToString();//盐时间
            Par[16] = dt.Tables[0].Rows[0]["Salt_weight"].ToString();//盐重量
            Par[17] = dt.Tables[0].Rows[0]["Scallion_time"].ToString();//葱时间
            Par[18] = dt.Tables[0].Rows[0]["Scallion_weight"].ToString();//葱重量
            Par[19] = dt.Tables[0].Rows[0]["Ch_time"].ToString();//鸡精时间
            Par[20] = dt.Tables[0].Rows[0]["Ch_weight"].ToString();//鸡精重量
            Par[21] = dt.Tables[0].Rows[0]["Ginger_time"].ToString();//生姜时间
            Par[22] = dt.Tables[0].Rows[0]["Ginger_weight"].ToString();//生姜重量
            Par[23] = dt.Tables[0].Rows[0]["Garlic_time"].ToString();//蒜时间
            Par[24] = dt.Tables[0].Rows[0]["Garlic_weight"].ToString();//蒜重量
            Par[25] = dt.Tables[0].Rows[0]["Washing"].ToString();//洗锅

            return Par;
        }
        //6
        private string[] Order_Type6(string str)
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            str = "'" + str + "'";
            //从菜名查看该菜配菜单
            string sql_3 = "Select * from Typeofdish where F_course = " + str;
            SqlCommand cmd = new SqlCommand(sql_3, dbConnection);
            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            dbConnection.Close();

            //读取菜品配置参数
            string[] Par = new string[50];
            Par[0] = dt.Tables[0].Rows[0]["M_material"].ToString();//主料
            Par[1] = dt.Tables[0].Rows[0]["Accessories"].ToString();//辅料
            Par[2] = dt.Tables[0].Rows[0]["Heating"].ToString();//加热
            Par[3] = dt.Tables[0].Rows[0]["Oil_time"].ToString();//油时间
            Par[4] = dt.Tables[0].Rows[0]["Oil_weight"].ToString();//油重量
            Par[5] = dt.Tables[0].Rows[0]["Water_time"].ToString();//水时间
            Par[6] = dt.Tables[0].Rows[0]["Water_weight"].ToString();//水重量
            Par[7] = dt.Tables[0].Rows[0]["Vinegar_time"].ToString();//醋时间
            Par[8] = dt.Tables[0].Rows[0]["Vinegar_weight"].ToString();//醋重量
            Par[9] = dt.Tables[0].Rows[0]["Shotgun_time"].ToString();//生抽时间
            Par[10] = dt.Tables[0].Rows[0]["Shotgun_weight"].ToString();//生抽重量
            Par[11] = dt.Tables[0].Rows[0]["MSG_time"].ToString();//味精时间
            Par[12] = dt.Tables[0].Rows[0]["MSG_weight"].ToString();//味精重量
            Par[13] = dt.Tables[0].Rows[0]["Sugar_time"].ToString();//糖时间
            Par[14] = dt.Tables[0].Rows[0]["Sugar_weight"].ToString();//糖重量
            Par[15] = dt.Tables[0].Rows[0]["Salt_time"].ToString();//盐时间
            Par[16] = dt.Tables[0].Rows[0]["Salt_weight"].ToString();//盐重量
            Par[17] = dt.Tables[0].Rows[0]["Scallion_time"].ToString();//葱时间
            Par[18] = dt.Tables[0].Rows[0]["Scallion_weight"].ToString();//葱重量
            Par[19] = dt.Tables[0].Rows[0]["Ch_time"].ToString();//鸡精时间
            Par[20] = dt.Tables[0].Rows[0]["Ch_weight"].ToString();//鸡精重量
            Par[21] = dt.Tables[0].Rows[0]["Ginger_time"].ToString();//生姜时间
            Par[22] = dt.Tables[0].Rows[0]["Ginger_weight"].ToString();//生姜重量
            Par[23] = dt.Tables[0].Rows[0]["Garlic_time"].ToString();//蒜时间
            Par[24] = dt.Tables[0].Rows[0]["Garlic_weight"].ToString();//蒜重量
            Par[25] = dt.Tables[0].Rows[0]["Washing"].ToString();//洗锅

            return Par;
        }
        //7
        private string[] Order_Type7(string str)
        {
            //远程数据库
            SqlConnection dbConnection;

            string strcon = "Data Source=" + textBox1.Text + ";Database=test;Uid=sa;Pwd=AAaa00!!;";
            //打开连接sql数据库
            dbConnection = new SqlConnection(strcon);
            dbConnection.Open();

            str = "'" + str + "'";
            //从菜名查看该菜配菜单
            string sql_3 = "Select * from Typeofdish where F_course = " + str;
            SqlCommand cmd = new SqlCommand(sql_3, dbConnection);
            DataSet dt = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            dbConnection.Close();

            //读取菜品配置参数
            string[] Par = new string[50];
            Par[0] = dt.Tables[0].Rows[0]["M_material"].ToString();//主料
            Par[1] = dt.Tables[0].Rows[0]["Accessories"].ToString();//辅料
            Par[2] = dt.Tables[0].Rows[0]["Heating"].ToString();//加热
            Par[3] = dt.Tables[0].Rows[0]["Oil_time"].ToString();//油时间
            Par[4] = dt.Tables[0].Rows[0]["Oil_weight"].ToString();//油重量
            Par[5] = dt.Tables[0].Rows[0]["Water_time"].ToString();//水时间
            Par[6] = dt.Tables[0].Rows[0]["Water_weight"].ToString();//水重量
            Par[7] = dt.Tables[0].Rows[0]["Vinegar_time"].ToString();//醋时间
            Par[8] = dt.Tables[0].Rows[0]["Vinegar_weight"].ToString();//醋重量
            Par[9] = dt.Tables[0].Rows[0]["Shotgun_time"].ToString();//生抽时间
            Par[10] = dt.Tables[0].Rows[0]["Shotgun_weight"].ToString();//生抽重量
            Par[11] = dt.Tables[0].Rows[0]["MSG_time"].ToString();//味精时间
            Par[12] = dt.Tables[0].Rows[0]["MSG_weight"].ToString();//味精重量
            Par[13] = dt.Tables[0].Rows[0]["Sugar_time"].ToString();//糖时间
            Par[14] = dt.Tables[0].Rows[0]["Sugar_weight"].ToString();//糖重量
            Par[15] = dt.Tables[0].Rows[0]["Salt_time"].ToString();//盐时间
            Par[16] = dt.Tables[0].Rows[0]["Salt_weight"].ToString();//盐重量
            Par[17] = dt.Tables[0].Rows[0]["Scallion_time"].ToString();//葱时间
            Par[18] = dt.Tables[0].Rows[0]["Scallion_weight"].ToString();//葱重量
            Par[19] = dt.Tables[0].Rows[0]["Ch_time"].ToString();//鸡精时间
            Par[20] = dt.Tables[0].Rows[0]["Ch_weight"].ToString();//鸡精重量
            Par[21] = dt.Tables[0].Rows[0]["Ginger_time"].ToString();//生姜时间
            Par[22] = dt.Tables[0].Rows[0]["Ginger_weight"].ToString();//生姜重量
            Par[23] = dt.Tables[0].Rows[0]["Garlic_time"].ToString();//蒜时间
            Par[24] = dt.Tables[0].Rows[0]["Garlic_weight"].ToString();//蒜重量
            Par[25] = dt.Tables[0].Rows[0]["Washing"].ToString();//洗锅

            return Par;
        }
        //8


        //监控炒菜机器人的状态和菜单数据库数据.
        //1
        private void pot1_D()
        {
            test_D1(Type_par, Order_O);
        }
        //2
        private void pot2_D()
        {
            test_D1_2(Type_par, Order_O);
        }
        //3
        private void pot3_D()
        {
            //读取时间最早的菜名
            string Order_O = Read_Order3();

            //读取菜种配置
            string[] Type_par = new string[50];
            Type_par = Order_Type3(Order_O);
            test_D2(Type_par, Order_O);
        }
        //4
        //private void pot4_D()
        //{
        //    //读取时间最早的菜名
        //    string Order_O = Read_Order();

        //    //读取菜种配置
        //    string[] Type_par = new string[50];
        //    Type_par = Order_Type(Order_O);
        //    test_D2_2(Type_par, Order_O);
        //}
        ////5
        //private void pot5_D()
        //{
        //    //读取时间最早的菜名
        //    string Order_O = Read_Order();

        //    //读取菜种配置
        //    string[] Type_par = new string[50];
        //    Type_par = Order_Type(Order_O);
        //    test_D3(Type_par, Order_O);
        //}

        public static string Order_O = "";
        public static string[] Type_par = new string[50];
        private void monitor()
        {
            while (true)
            {

                //查看菜单数据库是否单子
                int Order = 0;
                while (true)
                {
                    Order = connect_sql();
                    if (Order > 0)
                        break;
                }

                //while (Sta1 != 0 && Sta1_2 != 0)
                while (true)
                {
                    if (Sta1 == 0 || Sta1_2 == 0)
                    //if(Sta1 == 0)
                        break;
                }

                //查看各个炒菜机器人的状态,并找出闲置的机器人.
                //while (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 != 0 && Sta7 != 0 && Sta8 != 0 && Sta9 != 0 && Sta10 != 0 && Sta11 != 0 && Sta12 != 0 && Sta13 != 0 && Sta14 != 0)
                ////while(true)
                //{
                //    //有点多余...
                //    if (Sta1 == 0 || Sta2 == 0 || Sta3 == 0 || Sta4 == 0 || Sta5 == 0 || Sta6 == 0 || Sta7 == 0 || Sta8 == 0 || Sta9 == 0 || Sta10 == 0 || Sta11 == 0 || Sta12 != 0 || Sta13 == 0 || Sta14 == 0)
                //        break;
                //}

                //读取时间最早的菜名
                Order_O = Read_Order1();

                //读取菜种配置
                Type_par = Order_Type1(Order_O);

                if (Sta1_2 == 0)
                {
                    pot1 = new Thread(new ThreadStart(pot2_D));
                    pot1.Start();
                }
                else if (Sta1_2 != 0 && Sta1 == 0)
                {
                    pot2 = new Thread(new ThreadStart(pot1_D));
                    pot2.Start();
                }
                //else if (Sta1 != 0 && Sta1_2 != 0 && Sta2 == 0)
                //{                
                //    pot3 = new Thread(new ThreadStart(pot3_D));
                //    pot3.Start();
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D3(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D4(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D5(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D6(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 != 0 && Sta7 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D7(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 != 0 && Sta7 != 0 && Sta8 ==0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D8(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 != 0 && Sta7 != 0 && Sta8 != 0 && Sta9 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D9(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 != 0 && Sta7 != 0 && Sta8 != 0 && Sta9 != 0 && Sta10 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D10(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 != 0 && Sta7 != 0 && Sta8 != 0 && Sta9 != 0 && Sta10 != 0 && Sta11 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D11(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 != 0 && Sta7 != 0 && Sta8 != 0 && Sta9 != 0 && Sta10 != 0 && Sta11 != 0 && Sta12 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D12(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 != 0 && Sta7 != 0 && Sta8 != 0 && Sta9 != 0 && Sta10 != 0 && Sta11 != 0 && Sta12 != 0 && Sta13 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D13(Type_par, Order_O);
                //}
                //else if (Sta1 != 0 && Sta2 != 0 && Sta3 != 0 && Sta4 != 0 && Sta5 != 0 && Sta6 != 0 && Sta7 != 0 && Sta8 != 0 && Sta9 != 0 && Sta10 != 0 && Sta11 != 0 && Sta12 != 0 && Sta13 != 0 && Sta14 == 0)
                //{
                //    //读取时间最早的菜名
                //    string Order_O = Read_Order();

                //    //读取菜种配置
                //    string[] Type_par = new string[50];
                //    Type_par = Order_Type(Order_O);
                //    test_D14(Type_par, Order_O);
                //}

            }
        }

        //打开软件就监控炒菜机器人的状态和菜单数据库数据.
        private void Form1_Load(object sender, EventArgs e)
        {
            //连接各个炒菜机PLC.
            MO_connect();

            //监控炒菜机器人1的状态(少水,少油等),并将信息显示到界面上
            Mo1 = new Thread(new ThreadStart(R_Abnor1));
            Mo1.Start();

            //显示点餐等待人数
            Count = new Thread(new ThreadStart(show_num));
            Count.Start();

            //监控炒菜机器人2的状态(少水, 少油等),并将信息显示到界面上
            //Mo2 = new Thread(new ThreadStart(R_Abnor2));
            //Mo2.Start();


            //点餐状况和菜单数据库数据,并进行炒菜.
            Rob = new Thread(new ThreadStart(monitor));
            Rob.Start();


        }

        //任务管理器关闭应用程序
        private void _close()
        {
            Process[] ps = Process.GetProcesses();//获取进程列表
            foreach (Process item in ps)//遍历进程名
            {
                if (item.ProcessName == "炒菜单测机.exe")//如果是任务管理器
                {
                    item.Kill();//杀死它
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mo1.Abort();
            //Mo2.Abort();
            Count.Abort();
            Rob.Abort();
            _close();
        }


        private byte[] data;

        private byte[] data1_2;
        private byte[] data2;
        private byte[] data2_2;
        //时间
        private byte[] GetData3(int num,string str)
        {
            bool[] bits = new bool[num];
            byte[] data = new Byte[num];
            int[] word = new int[num];
            int value;
            // ------------------------------------------------------------------------
            // Convert data from text boxes
            value = Convert.ToInt16(str);
            data[0] = Convert.ToByte(value / 256);
            data[1] = Convert.ToByte(value % 256);

            return data;
        }

        //重量
        private byte[] GetData4(int num,string str)
        {
            bool[] bits = new bool[num];
            byte[] data = new Byte[num];
            int[] word = new int[num];
            int value;
            // ------------------------------------------------------------------------
            // Convert data from text boxes
            value = Convert.ToInt16(str);
            data[0] = Convert.ToByte(value / 256);
            data[1] = Convert.ToByte(value % 256);

            return data;
        }


        #region 菜品参数录入炒菜机中
        //菜品参数录入炒菜机器人1

        private void test_D1(string[] str,string co)
        {
            Sta1 = 1;
            Invoke((EventHandler)delegate
            {
                label5.BackColor = Color.Purple;
                label5.Text = "正在做:" + co;
                label50.BackColor = Color.Purple;
                label50.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2,str[11]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2,str[13]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2,str[14]) ;
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2,str[19]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4386"), data);

            Thread.Sleep(2000);

            //开启锅 给1秒的 1状态再复位0
            //MBmaster.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000; 
            //Thread.Sleep(a_time);

            int Heat_time = int.Parse(str[2]) * 100;
            int rush_time = int.Parse(str[25]) * 100;
            int a_time = Heat_time + rush_time + 5000; 
            Thread.Sleep(a_time);

            //MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            //Thread.Sleep(1000);
            //MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), false);

            Invoke((EventHandler)delegate
            {
                label5.BackColor = Color.Gray;
                label5.Text = "空闲";
                label50.BackColor = Color.Purple;
                label50.Text = "正在做:" + co;
            });
            Sta1 = 0;
        }

        private void test_D1_2(string[] str, string co)
        {
            Sta1_2 = 1;
            Invoke((EventHandler)delegate
            {
                label6.BackColor = Color.Purple;
                label6.Text = "正在做:" + co;
                label49.BackColor = Color.Purple;
                label49.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4157"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4119"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4158"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4120"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4155"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4117"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4298"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4208"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4297"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4207"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4166"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4126"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4200"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4201"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4167"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4127"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4156"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4118"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4168"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4128"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4169"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4129"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4296"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4206"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4116"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4186"), data);

            Thread.Sleep(2000);

            ////开启锅 给1秒的 1状态再复位0
            //MBmaster.WriteSingleCoils(5, Convert.ToInt16("2048"), true);
            //Thread.Sleep(1000);
            //MBmaster.WriteSingleCoils(5, Convert.ToInt16("2048"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000; 
            //Thread.Sleep(a_time);

            int Heat_time = int.Parse(str[2]) * 100;
            int rush_time = int.Parse(str[25]) * 100;
            int a_time = Heat_time + rush_time + 5000;
            Thread.Sleep(a_time);

            //MBmaster.WriteSingleCoils(5, Convert.ToInt16("50"), true);
            //Thread.Sleep(1000);
            //MBmaster.WriteSingleCoils(5, Convert.ToInt16("50"), false);
            Invoke((EventHandler)delegate
            {
                label6.BackColor = Color.Purple;
                label6.Text = "空闲";
                label49.BackColor = Color.Purple;
                label49.Text = "正在做:" + co;
            });
            Sta1_2 = 0;
        }

        //菜品参数录入炒菜机器人2
        private void test_D2(string[] str,string co)
        {
            Sta2 = 1;
            Invoke((EventHandler)delegate
            {
                label6.BackColor = Color.Purple;
                label6.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster2.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            MBmaster2.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            Thread.Sleep(1000);
            MBmaster2.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;
            //Thread.Sleep(a_time);

            int Heat_time = int.Parse(str[2])*100;
            int rush_time = int.Parse(str[25])*100;
            int a_time = Heat_time + rush_time + 4000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label6.BackColor = Color.Gray;
                label6.Text = "空闲";
            });
            Thread.Sleep(1000);
            Sta2 = 0;
        }

        //菜品参数录入炒菜机器人3
        private void test_D3(string[] str,string co)
        {
            Sta3 = 1;

            Invoke((EventHandler)delegate
            {
                label9.BackColor = Color.Purple;
                label9.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster3.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster3.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster3.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;
            //Thread.Sleep(a_time);

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label9.BackColor = Color.Gray;
                label9.Text = "空闲";
            });
            Sta3 = 0;
        }

        //菜品参数录入炒菜机器人4
        private void test_D4(string[] str,string co)
        {
            Sta4 = 1;
            Invoke((EventHandler)delegate
            {
                label11.BackColor = Color.Purple;
                label11.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster4.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster4.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster4.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;
            //Thread.Sleep(a_time);

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label11.BackColor = Color.Gray;
                label11.Text = "空闲";
            });
            Sta4 = 0;
        }

        //菜品参数录入炒菜机器人5
        private void test_D5(string[] str,string co)
        {
            Sta5 = 1;
            Invoke((EventHandler)delegate
            {
                label13.BackColor = Color.Purple;
                label13.Text = "正在做:" + co;
            });

            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster5.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster5.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster5.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;
            //Thread.Sleep(a_time);

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label13.BackColor = Color.Gray;
                label13.Text = "空闲";
            });
            Sta5 = 0;
        }

        //菜品参数录入炒菜机器人6
        private void test_D6(string[] str,string co)
        {
            Sta6 = 1;
            Invoke((EventHandler)delegate
            {
                label15.BackColor = Color.Purple;
                label15.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster6.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster6.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster6.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;
            //Thread.Sleep(a_time);

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label15.BackColor = Color.Gray;
                label15.Text = "空闲";
            });
            Sta6 = 0;
        }

        //菜品参数录入炒菜机器人7
        private void test_D7(string[] str,string co)
        {
            Sta7 = 1;
            Invoke((EventHandler)delegate
            {
                label17.BackColor = Color.Purple;
                label17.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster7.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster7.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster7.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;
            //Thread.Sleep(a_time);
            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label17.BackColor = Color.Gray;
                label17.Text = "空闲";
            });
            Sta7 = 0;
        }

        //菜品参数录入炒菜机器人8
        private void test_D8(string[] str,string co)
        {
            Sta8 = 1;
            Invoke((EventHandler)delegate
            {
                label19.BackColor = Color.Purple;
                label19.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster8.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster8.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster8.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;
            //Thread.Sleep(a_time);

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label19.BackColor = Color.Gray;
                label19.Text = "空闲";
            });
            Sta8 = 0;
        }

        //菜品参数录入炒菜机器人9
        private void test_D9(string[] str,string co)
        {
            Sta9 = 1;
            Invoke((EventHandler)delegate
            {
                label21.BackColor = Color.Purple;
                label21.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster9.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster9.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster9.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;
            //Thread.Sleep(a_time);
            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label21.BackColor = Color.Gray;
                label21.Text = "空闲";
            });
            Sta9 = 0;
        }

        //菜品参数录入炒菜机器人10
        private void test_D10(string[] str,string co)
        {
            Sta10 = 1;
            Invoke((EventHandler)delegate
            {
                label23.BackColor = Color.Purple;
                label23.Text = "正在做:" + co;
            });

            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster10.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster10.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster10.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label23.BackColor = Color.Gray;
                label23.Text = "空闲";
            });
            Sta10 = 0;
        }

        //菜品参数录入炒菜机器人11
        private void test_D11(string[] str,string co)
        {
            Sta11 = 1;
            Invoke((EventHandler)delegate
            {
                label25.BackColor = Color.Purple;
                label25.Text = "正在做:" + co;
            });

            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster11.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster11.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster11.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label25.BackColor = Color.Gray;
                label25.Text = "空闲";
            });
            Sta11 = 0;
        }

        //菜品参数录入炒菜机器人12
        private void test_D12(string[] str,string co)
        {
            Sta12 = 1;
            Invoke((EventHandler)delegate
            {
                label27.BackColor = Color.Purple;
                label27.Text = "正在做:" + co;
            });
            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster12.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster12.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster12.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label27.BackColor = Color.Gray;
                label27.Text = "空闲";
            });
            Sta12 = 0;
        }

        //菜品参数录入炒菜机器人13
        private void test_D13(string[] str,string co)
        {
            Sta13 = 1;
            Invoke((EventHandler)delegate
            {
                label29.BackColor = Color.Purple;
                label29.Text = "正在做:" + co;
            });

            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster13.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster13.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster13.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label29.BackColor = Color.Gray;
                label29.Text = "空闲";
            });
            Sta13 = 0;
        }

        //菜品参数录入炒菜机器人14
        private void test_D14(string[] str,string co)
        {
            Sta14 = 1;
            Invoke((EventHandler)delegate
            {
                label31.BackColor = Color.Purple;
                label31.Text = "正在做:" + co;
            });

            //醋参数设置
            //时间
            data = GetData3(2, str[7]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2, str[8]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2, str[9]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2, str[10]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2, str[3]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2, str[4]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2, str[23]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2, str[24]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2, str[21]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2, str[22]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2, str[11]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2, str[12]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2, str[0]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2, str[1]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2, str[13]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2, str[14]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2, str[5]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2, str[6]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2, str[15]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2, str[16]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2, str[19]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2, str[20]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2, str[17]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2, str[18]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2, str[2]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2, str[25]);
            MBmaster14.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            //MBmaster14.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            //Thread.Sleep(1000);
            //MBmaster14.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

            //int n_time1 = int.Parse(str[7]);
            //int n_time2 = int.Parse(str[9]);
            //int n_time3 = int.Parse(str[3]);
            //int n_time4 = int.Parse(str[23]);
            //int n_time5 = int.Parse(str[21]);
            //int n_time6 = int.Parse(str[11]);
            //int n_time7 = int.Parse(str[0]);
            //int n_time8 = int.Parse(str[1]);
            //int n_time9 = int.Parse(str[13]);
            //int n_time10 = int.Parse(str[5]);
            //int n_time11 = int.Parse(str[15]);
            //int n_time12 = int.Parse(str[19]);
            //int n_time13 = int.Parse(str[17]);
            //int n_time14 = int.Parse(str[2]);
            //int n_time15 = int.Parse(str[25]);

            //int a_time = n_time1 + n_time2 + n_time3 + n_time4 + n_time5 + n_time6 + n_time7 + n_time8 + n_time9 + n_time10 + n_time11 + n_time12 + n_time13 + n_time14 + n_time15 + 1000;

            int Heat_time = int.Parse(str[2]);
            int rush_time = int.Parse(str[25]);
            int a_time = Heat_time + rush_time + 2000;
            Thread.Sleep(a_time);

            Invoke((EventHandler)delegate
            {
                label31.BackColor = Color.Gray;
                label31.Text = "空闲";
            });
            Sta14 = 0;
        }

        
        #endregion
        //酸辣白菜 --测试
        private void button5_Click(object sender, EventArgs e)
        {
            //醋参数设置
            //时间
            data = GetData3(2,"270");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4357"), data);
            //重量
            data = GetData4(2,"20");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4319"), data);

            //生抽参数设置
            //时间
            data = GetData3(2,"320");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4358"), data);
            //重量
            data = GetData4(2,"10");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4320"), data);

            //油参数设置
            //时间
            data = GetData3(2,"100");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4355"), data);
            //重量
            data = GetData4(2,"30");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4317"), data);

            //蒜参数设置
            //时间
            data = GetData3(2,"350");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4398"), data);
            //重量
            data = GetData4(2,"5");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4408"), data);

            //生姜参数设置
            //时间
            data = GetData3(2,"370");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4397"), data);
            //重量
            data = GetData4(2,"5");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4407"), data);

            //味精参数设置
            //时间
            data = GetData3(2,"400");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4366"), data);
            //重量
            data = GetData4(2,"2");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4326"), data);

            //主料参数设置 只有时间
            data = GetData3(2,"200");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4400"), data);

            //辅料参数设置  只有时间
            data = GetData3(2,"220");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4401"), data);

            //糖参数设置
            //时间
            data = GetData3(2,"410");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4367"), data);
            //重量
            data = GetData4(2,"20");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4327"), data);

            //水参数设置
            //时间
            data = GetData3(2,"0");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4356"), data);
            //重量
            data = GetData4(2,"0");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4318"), data);

            //盐参数设置
            //时间
            data = GetData3(2,"420");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4368"), data);
            //重量
            data = GetData4(2,"5");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4328"), data);

            //鸡精参数设置
            //时间
            data = GetData3(2,"0");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4369"), data);
            //重量
            data = GetData4(2,"0");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4329"), data);

            //葱参数设置
            //时间
            data = GetData3(2,"450");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4396"), data);
            //重量
            data = GetData4(2,"10");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4406"), data);

            //加热参数设置 只有时间参数
            //时间
            data = GetData3(2,"2000");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4316"), data);

            //洗锅时间设置 只有时间参数
            data = GetData3(2,"100");
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4386"), data);


            //开启锅 给1秒的 1状态再复位0
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2248"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2248"), false);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            MO_connect();
        }



        #region 急停信号
        private void button6_Click(object sender, EventArgs e)
        {
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), false);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("50"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("50"), false);
        }


        private void button9_Click(object sender, EventArgs e)
        {
            MBmaster3.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster3.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MBmaster4.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster4.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MBmaster5.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster5.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MBmaster6.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster6.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MBmaster7.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster7.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MBmaster8.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster8.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MBmaster9.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster9.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MBmaster10.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster10.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MBmaster11.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster11.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MBmaster12.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster12.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            MBmaster13.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster13.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            MBmaster14.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster14.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }
        #endregion


        #region  异常信号处理 1026 14台机器
        //读异常信号地址在 PLC x区 DISCRRETE INPUT  modbus device中
        // Read start address 测第一个点1026对应的1027

        //读取异常信号
        //1
        private void Read_abnormal1_1()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal1_2()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr2();
            byte Length = Convert.ToByte("1");

            MBmaster.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal1_3()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr3();
            byte Length = Convert.ToByte("1");

            MBmaster.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal1_4()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr4();
            byte Length = Convert.ToByte("1");

            MBmaster.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal1_5()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr5();
            byte Length = Convert.ToByte("1");

            MBmaster.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal1_6()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr6();
            byte Length = Convert.ToByte("1");

            MBmaster.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //2
        private void Read_abnormal2_1()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster2.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal2_2()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr2();
            byte Length = Convert.ToByte("1");

            MBmaster2.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal2_3()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr3();
            byte Length = Convert.ToByte("1");

            MBmaster2.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal2_4()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr4();
            byte Length = Convert.ToByte("1");

            MBmaster2.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal2_5()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr5();
            byte Length = Convert.ToByte("1");

            MBmaster2.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        private void Read_abnormal2_6()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr6();
            byte Length = Convert.ToByte("1");

            MBmaster2.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //3
        private void Read_abnormal3()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster3.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //4
        private void Read_abnormal4()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster4.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //5
        private void Read_abnormal5()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster5.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //6
        private void Read_abnormal6()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster6.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //7
        private void Read_abnormal7()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster7.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //8
        private void Read_abnormal8()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster8.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //9
        private void Read_abnormal9()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster9.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //10
        private void Read_abnormal10()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster10.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //11
        private void Read_abnormal11()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster11.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //12
        private void Read_abnormal12()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster12.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //13
        private void Read_abnormal13()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster13.ReadDiscreteInputs(ID, StartAddress, Length);
        }
        //14
        private void Read_abnormal14()
        {
            int ID = 2;
            int StartAddress = ReadStartAdr1();
            byte Length = Convert.ToByte("1");

            MBmaster14.ReadDiscreteInputs(ID, StartAddress, Length);
        }


        // Read start address 测第一个点1026对应的1027 //1 x2
        private int ReadStartAdr1()
        {
            // Convert hex numbers into decimal
            if ("1026".IndexOf("0x", 0, "1026".Length) == 0)
            {
                string str = "1026".Replace("0x", "");
                int hex = Convert.ToInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToInt32("1026");
            }
        }

        // Read start address 测第一个点1027对应的1028  //2
        private int ReadStartAdr2()
        {
            // Convert hex numbers into decimal
            if ("1027".IndexOf("0x", 0, "1027".Length) == 0)
            {
                string str = "1027".Replace("0x", "");
                int hex = Convert.ToInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToInt32("1027");
            }
        }
        // Read start address 测第一个点1028对应的1029  //3
        private int ReadStartAdr3()
        {
            // Convert hex numbers into decimal
            if ("1028".IndexOf("0x", 0, "1028".Length) == 0)
            {
                string str = "1028".Replace("0x", "");
                int hex = Convert.ToInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToInt32("1028");
            }
        }
        // Read start address 测第一个点1029对应的1030  //4
        private int ReadStartAdr4()
        {
            // Convert hex numbers into decimal
            if ("1029".IndexOf("0x", 0, "1029".Length) == 0)
            {
                string str = "1029".Replace("0x", "");
                int hex = Convert.ToInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToInt32("1029");
            }
        }
        // Read start address 测第一个点1030对应的1031  //5
        private int ReadStartAdr5()
        {
            // Convert hex numbers into decimal
            if ("1030".IndexOf("0x", 0, "1030".Length) == 0)
            {
                string str = "1030".Replace("0x", "");
                int hex = Convert.ToInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToInt32("1030");
            }
        }
        // Read start address 测第一个点1031对应的1032  //6
        private int ReadStartAdr6()
        {
            // Convert hex numbers into decimal
            if ("1031".IndexOf("0x", 0, "1031".Length) == 0)
            {
                string str = "1031".Replace("0x", "");
                int hex = Convert.ToInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToInt32("1031");
            }
        }
        // ------------------------------------------------------------------------
        // Generate new number of text boxes
        // ------------------------------------------------------------------------
        private void ResizeData1()
        {
            grpData1.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData1.Controls.Add(txtData);
            });

        }
        private void ResizeData2()
        {
            grpData2.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData2.Controls.Add(txtData);
            });

        }
        private void ResizeData3()
        {
            grpData3.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData3.Controls.Add(txtData);
            });

        }
        private void ResizeData4()
        {
            grpData4.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData4.Controls.Add(txtData);
            });

        }
        private void ResizeData5()
        {
            grpData5.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData5.Controls.Add(txtData);
            });

        }
        private void ResizeData6()
        {
            grpData6.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData6.Controls.Add(txtData);
            });

        }
        private void ResizeData7()
        {
            grpData7.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData7.Controls.Add(txtData);
            });

        }
        private void ResizeData8()
        {
            grpData8.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData8.Controls.Add(txtData);
            });

        }
        private void ResizeData9()
        {
            grpData9.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData9.Controls.Add(txtData);
            });

        }
        private void ResizeData10()
        {
            grpData10.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData10.Controls.Add(txtData);
            });

        }
        private void ResizeData11()
        {
            grpData11.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData11.Controls.Add(txtData);
            });

        }
        private void ResizeData12()
        {
            grpData12.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData12.Controls.Add(txtData);
            });

        }
        private void ResizeData13()
        {
            grpData13.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData13.Controls.Add(txtData);
            });

        }
        private void ResizeData14()
        {
            grpData14.Controls.Clear();
            txtData = new TextBox();
            Invoke((EventHandler)delegate
            {
                grpData14.Controls.Add(txtData);
            });

        }
        private TextBox txtData;
        // ------------------------------------------------------------------------
        // Event for response data
        // ------------------------------------------------------------------------
        public int i;
        public byte[] data1;
        private void MBmaster_OnResponseData1(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data1 = values;
                    ShowAs1(null, null);
                    break;

            }
        }
        //public byte[] data2;
        //private void MBmaster_OnResponseData2(int ID, byte function, byte[] values)
        //{
        //    // Identify requested data
        //    switch (ID)
        //    {
        //        case 2:
        //            data2 = values;
        //            ShowAs2(null, null);
        //            break;

        //    }
        //}
        public byte[] data3;
        private void MBmaster_OnResponseData3(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data3 = values;
                    ShowAs3(null, null);
                    break;

            }
        }
        public byte[] data4;
        private void MBmaster_OnResponseData4(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data4 = values;
                    ShowAs4(null, null);
                    break;

            }
        }
        public byte[] data5;
        private void MBmaster_OnResponseData5(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data5 = values;
                    ShowAs5(null, null);
                    break;

            }
        }
        public byte[] data6;
        private void MBmaster_OnResponseData6(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data6 = values;
                    ShowAs6(null, null);
                    break;

            }
        }
        public byte[] data7;
        private void MBmaster_OnResponseData7(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data7 = values;
                    ShowAs7(null, null);
                    break;

            }
        }
        public byte[] data8;
        private void MBmaster_OnResponseData8(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data8 = values;
                    ShowAs8(null, null);
                    break;

            }
        }
        public byte[] data9;
        private void MBmaster_OnResponseData9(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data9 = values;
                    ShowAs9(null, null);
                    break;

            }
        }
        public byte[] data10;
        private void MBmaster_OnResponseData10(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data10 = values;
                    ShowAs10(null, null);
                    break;

            }
        }
        public byte[] data11;
        private void MBmaster_OnResponseData11(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data11 = values;
                    ShowAs11(null, null);
                    break;

            }
        }
        public byte[] data12;
        private void MBmaster_OnResponseData12(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data12 = values;
                    ShowAs12(null, null);
                    break;

            }
        }
        public byte[] data13;
        private void MBmaster_OnResponseData13(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data13 = values;
                    ShowAs13(null, null);
                    break;

            }
        }
        public byte[] data14;
        private void MBmaster_OnResponseData14(int ID, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 2:
                    data14 = values;
                    ShowAs14(null, null);
                    break;

            }
        }
        //测试 1
        private void button20_Click(object sender, EventArgs e)
        {
            ResizeData1();
            Read_abnormal1_1();
        }

        //机器人1异常信号 6种
        private void R_Abnor1()
        {
            ResizeData1();//创建控件 textbox
            while (true)
            {
                Read_abnormal1_1();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Green;
                        label35.Text = "";
                    });
                }
                else if (txtData .Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Red;
                        label35.Text = "1027 信号报警!";
                    });
                }
                Read_abnormal1_2();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Green;
                        label35.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Red;
                        label35.Text += "1028 信号报警!";
                    });
                }
                Read_abnormal1_3();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Green;
                        label35.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Red;
                        label35.Text += "1029 信号报警!";
                    });
                }
                Read_abnormal1_4();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Green;
                        label35.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Red;
                        label35.Text += "1030 信号报警!";
                    });
                }
                Read_abnormal1_5();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Green;
                        label35.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Red;
                        label35.Text += "1031 信号报警!";
                    });
                }
                Read_abnormal1_6();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Green;
                        label35.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label35.BackColor = Color.Red;
                        label35.Text += "1032 信号报警!";
                    });
                }
            }
        }
        //机器人1异常信号 6种
        private void R_Abnor2()
        {
            ResizeData2();//创建控件 textbox
            while (true)
            {
                Read_abnormal2_1();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Green;
                        label36.Text = "";
                    });
                }
                else if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Red;
                        label36.Text = "1027 信号报警!";
                    });
                }
                Read_abnormal2_2();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Green;
                        label36.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Red;
                        label36.Text += "1028 信号报警!";
                    });
                }
                Read_abnormal2_3();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Green;
                        label36.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Red;
                        label36.Text += "1029 信号报警!";
                    });
                }
                Read_abnormal2_4();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Green;
                        label36.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Red;
                        label36.Text += "1030 信号报警!";
                    });
                }
                Read_abnormal2_5();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Green;
                        label36.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Red;
                        label36.Text += "1031 信号报警!";
                    });
                }
                Read_abnormal2_6();
                Thread.Sleep(100);
                if (txtData.Text == "0")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Green;
                        label36.Text += "";
                    });
                }
                if (txtData.Text == "1")
                {
                    Invoke((EventHandler)delegate
                    {
                        label36.BackColor = Color.Red;
                        label36.Text += "1032 信号报警!";
                    });
                }
            }
        }
        #endregion
        //添加菜品参数 数据库信息
        private void button19_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Mo1.Abort();
            //Mo2.Abort();
            Count.Abort();
            Rob.Abort();
            _close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("10"), false);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("50"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("50"), false);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            data = GetData3(2, textBox2.Text);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4186"), data);

            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2063"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2063"), false);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            data = GetData3(2, textBox3.Text);
            MBmaster.WriteSingleRegister(7, Convert.ToInt16("4386"), data);

            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2263"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2263"), false);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2264"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2264"), false);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2064"), true);
            Thread.Sleep(1000);
            MBmaster.WriteSingleCoils(5, Convert.ToInt16("2064"), false);
        }
    }
}
