using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bunifutest
{
    public partial class ExportType : Form
    {
        int x, y;bool move;
        public ExportType()
        {
            InitializeComponent();
            timer1.Interval = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdAccount.user != null)
            {
              
                this.Close();
                LoginExport login = new LoginExport();
                login.ShowDialog();
            }
            else
            {
                back = false;
                timer1.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Thư mục \"baothuc\" sẽ được mang ra ngoài màn hình(Desktop) bạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\baothuc";
                Copy("data\\baothuc", path);
                MessageBox.Show("Sao lưu thành công! Thư mục sao lưu được đưa ra ngoài màn hình (Desktop)");
            }
        }
        void Copy(string sourceDir, string targetDir)
        {
            TaoLai:
            try
            {

                Directory.CreateDirectory(targetDir);

                foreach (var file in Directory.GetFiles(sourceDir))
                    File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));

                foreach (var directory in Directory.GetDirectories(sourceDir))
                    Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
            }
            catch
            {
                DialogResult d = MessageBox.Show("Đã tồn tại bạn có muốn ghi đè", "", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    try
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(targetDir);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                        Directory.Delete(targetDir);
                        goto TaoLai;
                    }
                    catch { MessageBox.Show("Thư mục đang được sử dụng", "Lỗi"); }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExportType_MouseMove(object sender, MouseEventArgs e)
        {
            if (move) SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);
        }

        private void ExportType_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            UseWaitCursor = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp sign = new SignUp();
            sign.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IdAccount.DangNhap(textBox1.Text,textBox2.Text))
            {
                this.Close();
                LoginExport login = new LoginExport();
                login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
        }
        int Cy = 460;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (back)
            {
                if (panel1.Location.Y <= 460)
                {
                    panel1.Location = new Point(panel1.Location.X, Cy += 20);
                }
                else timer1.Stop();
            }
            else
            {
                if (panel1.Location.Y >= 0)
                {
                    panel1.Location = new Point(panel1.Location.X, Cy -= 20);
                }
                else timer1.Stop();
            }
        }
        bool back = false;
        private void button4_Click(object sender, EventArgs e)
        {
            back = true;
            timer1.Start();
        }

        private void ExportType_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            move = true;
        }
    }
}
