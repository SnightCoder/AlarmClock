using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace bunifutest
{
    public partial class LoginExport : Form
    {
        int x, y; bool xy;
        Timer tim = new Timer() { Interval = 1000 };
        public LoginExport()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            //System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            //gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            //Region rg = new Region(gp);
            //pictureBox1.Region = rg;
            tim.Tick += Tim_Tick;
            textBox1.Text = "Tên tài khoản: " + IdAccount.user;
            pictureBox1.ImageLocation = IdAccount.Avatar;
            StreamWriter swo = new StreamWriter(@"Data\User\off.adb");
            swo.WriteLine("1");
            swo.Close();
            tim.Start();
        }

        private void Tim_Tick(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Data\User\maTK.adb");
            sw.WriteLine(IdAccount.MaTaiKhoan);
            sw.WriteLine(IdAccount.user);
            sw.Close();
            StreamWriter swO = new StreamWriter(@"Data\User\off.adb");
            swO.WriteLine("0");
            swO.Close();
            Process.Start("ChuongBao.exe");
            tim.Stop();
        }

        private void LoginExport_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            xy = true;
        }

        private void LoginExport_MouseUp(object sender, MouseEventArgs e)
        {
            xy = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sao lưu lên tài khoản của bạn", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //loading
                panel2.Visible = true;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IdAccount.UploadToDataBase())
            {
                //done
                panel2.Visible = false;
                timer1.Stop();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                IdAccount.UI_App(IdAccount.user, textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("LoadBaoThuc.exe");
            Application.Exit();
        }

        private void close(object sender, EventArgs e)
        {
            //StreamWriter sw = new StreamWriter(@"Data\User\off.adb");
            //sw.WriteLine("1");
            //sw.Close();
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
                textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DS_ChuongBao ds = new DS_ChuongBao();
            ds.ShowDialog();
        }

        private void DX_Click(object sender, EventArgs e)
        {
            IdAccount.user = null;
            IdAccount.pass = null;
            StreamWriter sw = new StreamWriter(@"Data\User\off.adb");
            sw.WriteLine("1");
            sw.Close();
            Close();
        }

        private void LoginExport_MouseMove(object sender, MouseEventArgs e)
        {
            if (xy) SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);
        }
    }
}
