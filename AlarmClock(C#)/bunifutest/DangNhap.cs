using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Login_To_Exit;
using System.Diagnostics;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
// Line 294
namespace bunifutest
{
    public partial class DangNhap : Form
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
        String textR = "Đăng ký";
        bool DangKy=true;
        // sự kiện nút close

        protected override void OnClosing(CancelEventArgs e)
        {


            e.Cancel = true;
            this.Hide();

        }

        #region *********** Các biến hàm *************
        String user = "admin", pass = "admin"; int shake = 0;
        int loginAgain = 0;
        Timer nutxoatime_lefT = new Timer()
        {
            Interval = 10
        };
        Timer welcometimer = new Timer()
        {
            Interval = 10
        };
        Timer nutxoatime = new Timer()
        {
            Interval = 10
        };

        Timer tm = new Timer()
        {
            Interval = 10
        };
        Timer nutxoatime2 = new Timer()
        {
            Interval = 10
        };
        Timer nutxoatime3_left = new Timer()
        {
            Interval = 10
        };
        Timer tim = new Timer();
        int passHeight;
        int choi = 0;
        int sec = 0;
        int xoapanelWidth;
        int LoadingHeight;
        #endregion

        // thiết lập mọi thứ trước khi ứng dụng mở
        public DangNhap()
        {
            InitializeComponent();
            linkLabel1.Text = textR;
            Test.Start();
            timer1.Start();

            tim.Interval = 10; UserText.Focus();
            UserText.KeyDown += UserText_KeyDown;
            tim.Tick += tim_Tick;
            userControl11.Hide();
            //  label4.Visible = false; Startbutton.Visible = false; 
            Startbutton.Text = "Chạy";
            NutXTimer.Start();


            XoaPanel.Location = new Point(XoaPanel.Location.X - 35, XoaPanel.Location.Y);

            StreamReader sr = new StreamReader(@"Data\User\user.adb");
            user = sr.ReadLine();
            pass = sr.ReadLine();
            sr.Close();
            iconShow.Tick += iconShow_Tick;
            iconShow.Start();

        }

        void iconShow_Tick(object sender, EventArgs e)
        {

        }
        #region
        #region ******** di chuyển form ********
        Boolean xy; int x, y;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            xy = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            xy = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (xy == true) this.SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);
        }
        #endregion

        #region *********** Các sự kiện Timer Tick ***********
        void tim_Tick(object sender, EventArgs e)
        {
            Pass.Visible = true;
            PassText.Focus();
            if (passHeight >= User.Height) tim.Stop();
            Pass.Size = new Size(Pass.Width, passHeight += 2);
            XoaPanel.Location = new Point(XoaPanel.Location.X - 2, XoaPanel.Location.Y);
        }
        void nutxoatime_Tick(object sender, EventArgs e)
        {
            if (xoapanelWidth >= 487) { nutxoatime.Stop(); }
            XoaPanel.Location = new Point(xoapanelWidth += 2, XoaPanel.Location.Y);

        }
        void tm_Tick(object sender, EventArgs e)
        {

            if (LoadingHeight >= 48)
            {
                tm.Stop();
                Pass.Visible = false;

            }
            userControl11.Size = new Size(userControl11.Width, LoadingHeight += 2);
        }
        void nutxoatime2_Tick(object sender, EventArgs e)
        {

            if (xoapanelWidth >= 488) { nutxoatime2.Stop(); }
            XoaPanel.Location = new Point(xoapanelWidth += 2, XoaPanel.Location.Y);
        }
        //bring panel để che phần bị lỗi size
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.BringToFront();
            panel2.BringToFront();
            linkLabel1.BringToFront();

        }
        //lùi nút xoá khi click nút trong phần user
        void nutxoatime_lefT_Tick(object sender, EventArgs e)
        {
            if (XoaPanel.Location.X < 463) nutxoatime_lefT.Stop();
            choi = 0;
            XoaPanel.Location = new Point(XoaPanel.Location.X - 2, XoaPanel.Location.Y);
        }
        #endregion

        // khi enter user
        void UserText_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.CapsLock || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey) return;
            nutxoatime.Tick += nutxoatime_Tick;
            xoapanelWidth = XoaPanel.Location.X;

            if (choi == 0)
            {
                nutxoatime.Start();
                choi = 1;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (UserText.Text == "")
                {
                    for (int i = 0; i < 300; i++)
                    {
                        this.Location = new Point(this.Location.X + 40, this.Location.Y);
                        this.Location = new Point(this.Location.X - 40, this.Location.Y);

                    }
                }

                else
                {
                    DangKy = false;
                    linkLabel1.Visible = true;
                    linkLabel1.Text = "Quay lại";
                    PassText.KeyDown += PassText_KeyDown;
                    Pass.Size = new Size(Pass.Width, 10);
                    passHeight = Pass.Height;
                    Pass.BringToFront();
                    tim.Start();
                }
            }
        }

        // khi enter password
        void PassText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey) return;

            if (choi == 1)
            {
                nutxoatime2.Tick += nutxoatime2_Tick;
                nutxoatime2.Start();
                xoapanelWidth = 459;
                choi = 2;

            }

            if (e.KeyCode == Keys.Enter)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
                {
                    e.Handled = e.SuppressKeyPress = true;
                }

                if (PassText.Text == "")
                {
                    for (int i = 0; i < 400; i++)
                    {
                        this.Location = new Point(this.Location.X + 40, this.Location.Y);
                        this.Location = new Point(this.Location.X - 40, this.Location.Y);

                    }
                }
                else
                {
                    textBox1.Focus();
                    linkLabel1.Visible = false;
                    User.Visible = false;
                    userControl11.BringToFront();
                    nutxoatime3_left.Tick += nutxoatime3_left_Tick;
                    tm.Tick += tm_Tick;
                    nutxoatime3_left.Start();
                    userControl11.Size = new Size(userControl11.Width, 10);
                    LoadingHeight = userControl11.Height;
                    tm.Start();
                    userControl11.Show();
                }
            }

        }

        // ấn nút sẽ xoá text
        private void label2_Click(object sender, EventArgs e)
        {

            if (choi == 1) { UserText.ResetText(); }

            else if (choi == 2) PassText.ResetText();
            nutxoatime_lefT.Tick += nutxoatime_lefT_Tick;
            nutxoatime_lefT.Start();

        }

     
        // Kiểm tra user và pass
        void nutxoatime3_left_Tick(object sender, EventArgs e)
        {

            if (sec == 100)
            {
                //if (IdAccount.DangNhap(UserText.Text, PassText.Text))
                //{
                //    nutxoatime3_left.Stop();
                //    System.Threading.Thread.Sleep(550);
                //    timer1.Stop();//  stop vì ngăn không cho bring 2 panel kia
                //    Welcomepanel.BringToFront();
                //    //nút thoát
                //    label3.BringToFront();
                //    Welcomepanel.Visible = true;
                //    welcometimer.Tick += welcometimer_Tick;
                //    StreamReader sr = new StreamReader(@"data\user\name.adb");
                //    UserText.Text = sr.ReadLine(); sr.Close();
                //    label4.Text = "Chào mừng quay trở lại " + UserText.Text;
                //    welcometimer.Start();
                //    loginAgain = 1;
                //}
     
                #region nếu đúng user và pass
                if (UserText.Text.Equals(user) && PassText.Text.Equals(pass))
                {
                    nutxoatime3_left.Stop();
                    System.Threading.Thread.Sleep(550);
                    timer1.Stop();//  stop vì ngăn không cho bring 2 panel kia
                    Welcomepanel.BringToFront();
                    //nút thoát
                    label3.BringToFront();
                    Welcomepanel.Visible = true;
                    welcometimer.Tick += welcometimer_Tick;
                    StreamReader sr = new StreamReader(@"data\user\name.adb");
                    UserText.Text = sr.ReadLine(); sr.Close();
                    label4.Text = "Chào mừng quay trở lại " + UserText.Text;
                    welcometimer.Start();
                    loginAgain = 1;
                }
                #endregion
                #region nếu sai user và pass
                else //nếu sai mật khẩu
                {
                    SaiMK();
                    return;
                }
                #endregion
            }
            XoaPanel.Location = new Point(xoapanelWidth -= 2, XoaPanel.Location.Y);
            sec++;
        }
        void SaiMK()
        {
            nutxoatime3_left.Stop();
            XoaPanel.Location = new Point(200, XoaPanel.Location.Y);
            // báo động
            // SoundPlayer baodong = new SoundPlayer("data.wav");
            // baodong.PlayLooping();
            //   MessageBox.Show("Sai mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (shake < 2)
            {
                for (int i = 0; i < 300; i++)
                {
                    this.Location = new Point(this.Location.X + 40, this.Location.Y);
                    this.Location = new Point(this.Location.X - 40, this.Location.Y);

                }
                shake++;
            }
            User.BringToFront(); User.Visible = true; UserText.Focus();
            // Clock.ShowBalloonTip(0, "", "Tài khoản hoặc mật khẩu không đúng", ToolTipIcon.Error);
            PassText.ResetText();
            DangKy = true;
            linkLabel1.Visible = true;
            linkLabel1.Text = textR;
        }

        // nếu mật khẩu đúng
        void welcometimer_Tick(object sender, EventArgs e)
        {
            if (Welcomepanel.Location.Y == 0) { Startbutton.Visible = true; label4.Visible = true; label3.BackColor = Color.FromArgb(255, 144, 32); welcometimer.Stop(); }
            Welcomepanel.Location = new Point(Welcomepanel.Location.X, Welcomepanel.Location.Y - 10);
        }
        //quay lại user
        private void button1_Click(object sender, EventArgs e)
        {
            if (!DangKy)
            {
                User.BringToFront(); User.Visible = true;
                linkLabel1.Text = textR;
                choi = 1;
                UserText.Focus();
                DangKy = true;
                linkLabel1.Visible = false;
            }
        }
        // nút X thoát App
        private void label3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("data\\iconshow.adb");
            sw.WriteLine("0"); sw.Close();
            this.Hide();
        }
        // click đúp vào notifyicon
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StreamReader sr = new StreamReader(@"data\user\name.adb");
            UserText.Text = sr.ReadLine(); sr.Close();
            label4.Text = "Chào mừng quay trở lại " + UserText.Text; UserText.Text = "";
            this.Opacity = 1.0; label3.BackColor = Color.FromArgb(53, 193, 137);
            this.Show(); PassText.Text = ""; login_Again1.BringToFront();
            if (loginAgain == 1)
            {
                timer1.Stop();
                login_Again1.Location = new Point(0, 0);
                login_Again1.Visible = true;

                login_Again1.BringToFront(); label3.BringToFront(); label3.BackColor = Color.FromArgb(68, 178, 86);
                label3.BringToFront();
            }
        }
        // nút đăng nhập lại
        private void Startbutton_Click(object sender, EventArgs e)
        {
            while (this.Opacity > 0.0)
            {
                this.Opacity -= 0.1;
                System.Threading.Thread.Sleep(50);
            }

            this.Hide();



            StreamWriter sr = new StreamWriter("data\\uishow.adb");
            sr.WriteLine("0");
            sr.Close();

            StreamWriter sr1 = new StreamWriter("data\\uisizeW.adb");
            sr1.WriteLine("1226");
            sr1.Close();
            StreamWriter sr2 = new StreamWriter("data\\uisizeH.adb");
            sr2.WriteLine("673");
            sr2.Close();

        }
        // nút thoát trong notifyicon
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fom = new Form1();
            fom.Show();
        }

        // nút mở ứng dụng
        private void mởỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
            this.Show();
            if (loginAgain == 1)
            {
                timer1.Stop();
                login_Again1.Location = new Point(0, 0);
                login_Again1.Visible = true;
                login_Again1.BringToFront(); label3.BringToFront(); label3.BackColor = Color.FromArgb(68, 178, 86);
            }
        }

        //Developer mode (KT thời gian)
        private void Test_Tick(object sender, EventArgs e)
        {

            // StreamReader sr = new StreamReader("time.txt");
            // MessageBox.Show(sr.ReadLine());
            // sr.Close();                           
        }

        // thay đổi màu nút X
        private void NutXTimer_Tick(object sender, EventArgs e)
        {
            if (login_Again1.Visible == false) label3.BackColor = Color.FromArgb(255, 144, 32);
        }

        private void UserText_KeyDown_1(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }


        #endregion
        Timer iconShow = new Timer() { Interval = 1 };

    }
}
