using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
// line 136
namespace bunifutest
{
    public partial class Setting : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        int thoat = 0;
        public Setting()
        {
            InitializeComponent();
            button5.TabStop = false;
            button6.TabStop = false;
            StreamReader sr1 = new StreamReader(@"Data\Setting\closebox.adb");
            StreamReader sr2 = new StreamReader(@"Data\Setting\thongbao.adb");
            StreamReader sr3 = new StreamReader(@"Data\Setting\AutoVolume.adb");
            StreamReader sr4 = new StreamReader(@"Data\Setting\Login.adb");
            if (sr1.ReadLine() == "1") checkBox1.Checked = true;
            if (sr2.ReadLine() == "1") checkBox2.Checked = true;
            if (sr3.ReadLine() == "1") checkBox3.Checked = true;
            if (sr4.ReadLine() == "1") checkBox4.Checked = true;
            sr1.Close();
            sr2.Close();
            sr3.Close();
            sr4.Close();
            if (checkBox4.Checked == true) thoat = 0; else thoat = 1;
        }


        void LoadSave()
        {

            StreamWriter sr1 = new StreamWriter(@"Data\Setting\closebox.adb");
            StreamWriter sr2 = new StreamWriter(@"Data\Setting\thongbao.adb");
            StreamWriter sr3 = new StreamWriter(@"Data\Setting\AutoVolume.adb");
            StreamWriter sr4 = new StreamWriter(@"Data\Setting\Login.adb");
            if (checkBox1.Checked == true)
                sr1.WriteLine("1");
            else sr1.WriteLine("0");

            if (checkBox2.Checked == true)
                sr2.WriteLine("1");
            else sr2.WriteLine("0");

            if (checkBox3.Checked == true)
                sr3.WriteLine("1");
            else sr3.WriteLine("0");

            if (checkBox4.Checked == true)
                sr4.WriteLine("1");
            else
            {
                sr4.WriteLine("0");
                IdAccount.IdEnable = false;
            }

            sr1.Close();
            sr2.Close();
            sr3.Close();
            sr4.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                panel4.Visible = true;
            else
            {
                if (thoat == 0)
                    panel4.Visible = true;
                else
                {
                    LoadSave(); this.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Boolean xy; int x, y;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            xy = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            xy = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (xy == true) this.SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);
        }
        //nút lưu đăng nhập
        private void button3_Click(object sender, EventArgs e)
        {
            DangNhap();
        }
        void DangNhap()
        {
            StreamReader srU = new StreamReader(@"data\user\user.adb");
            String user = srU.ReadLine();
            String pass = srU.ReadLine();
            srU.Close();

            if (textBox1.Text == user && textBox2.Text == pass) { this.Close(); LoadSave(); }
            else MessageBox.Show("Tài khoản hoặc mật khẩu sai");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter) DangNhap();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            ExportType exportType = new ExportType();
            exportType.ShowDialog();
           
        }

        private void CloseCB_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Data\User\off.adb");
            sw.WriteLine("1");
            sw.Close();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            Process.Start("LoadBaoThuc.exe");
            Application.Exit();
        }


    }
}
