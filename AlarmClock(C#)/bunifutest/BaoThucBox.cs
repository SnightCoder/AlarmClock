using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Diagnostics;

namespace bunifutest
{
    public partial class BaoThucBox : Form
    {
        int i; int passclose = 0;

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
        public BaoThucBox()
        {
            InitializeComponent();
            //axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.settings.volume = 100;
            StreamReader sw = new StreamReader(@"Data\User\user.adb");
            sw.ReadLine();
            pass = sw.ReadLine();
            sw.Close();

            Load();
            LoadI();
            button4.Click += button4_Click;
            tGiam.Tick += tGiam_Tick;
            timer1.Start();
            StreamReader sr = new StreamReader(@"Data\Setting\closebox.adb");
            passclose = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            if (passclose == 0) ;
            else
            {
                textBox2.Visible = true;
                label5.Visible = true;
            };

        }



        void LoadI()
        {
            StreamReader srLoop = new StreamReader(@"data\baothuc\I.adb");
            i = Convert.ToInt32(srLoop.ReadLine());
            srLoop.Close();
            StreamReader srHou = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\Hou.adb");
            String Houn = srHou.ReadLine();
            srHou.Close();
            StreamReader srMin = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\min.adb");
            String minn = srMin.ReadLine();
            srMin.Close();
            StreamReader srSec = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\sec.adb");
            String secn = srSec.ReadLine();
            srSec.Close();
            DateTime dt = new DateTime(Convert.ToInt32(DateTime.Now.ToString("yyyy")), Convert.ToInt32(DateTime.Now.ToString("MM")), Convert.ToInt32(DateTime.Now.ToString("dd")), Convert.ToInt32(Houn), Convert.ToInt32(minn), Convert.ToInt32(secn));
            label2.Text = dt.ToString("HH:mm:ss");
        }
        int lop; String song;
        void Load()
        {
            button1.Click += button1_Click;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            StreamReader srLoop = new StreamReader(@"data\baothuc\loop.adb");
            lop = Convert.ToInt32(srLoop.ReadLine());
            srLoop.Close();
            StreamReader srSong = new StreamReader(@"data\baothuc\song.adb");
            song = srSong.ReadLine();
            srSong.Close();
            StreamReader srText = new StreamReader(@"data\baothuc\text.adb");
            String text = srText.ReadLine();
            srText.Close();
            label1.Text = text;
            try
            {
                if (!song.EndsWith(".mp3") && !song.EndsWith(".wav") && !song.EndsWith(".mp4"))
                {
                    Process.Start(song);
                    return;
                }
                if (lop == 1)
                {
                    axWindowsMediaPlayer1.settings.setMode("Loop", true);
                    axWindowsMediaPlayer1.URL = song;
                }
                else
                {
             
                    axWindowsMediaPlayer1.settings.setMode("Loop", false);
                    axWindowsMediaPlayer1.URL = song;
                }
            }
            catch
            {
                try
                {
                    Process.Start(song);
                }
                catch
                {
                    song = Directory.GetCurrentDirectory() + @"\" + song;
                    MessageBox.Show("Đường dẫn: " + song + " Không tìm thấy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        Boolean Xy; int x, y;
        void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Xy = false;
        }

        void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Xy == true) this.SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);
        }

        void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Xy = true;
            x = e.X;
            y = e.Y;
        }
        int cl = 0;
        void ExitBut()
        {
            if (passclose == 0) {  tGiam.Stop(); cl = 1; this.Close(); }
            else
            {
                if (textBox2.Text == pass)
                {
                    tGiam.Stop();
                    cl = 1;
                    this.Close();
                }
                else { MessageBox.Show("Mật khẩu sai"); cl = 0; }
            }
        }
        void button1_Click(object sender, EventArgs e)
        {
            ExitBut();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (cl == 1)
            {
            }
            else e.Cancel = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedIndex == 0) label3.Text = "01:00";
            else if (cb.SelectedIndex == 1) label3.Text = "02:00";
            else if (cb.SelectedIndex == 2) label3.Text = "03:00";
            else if (cb.SelectedIndex == 3) label3.Text = "04:00";
            else if (cb.SelectedIndex == 4) label3.Text = "05:00";
            else if (cb.SelectedIndex == 5) label3.Text = "10:00";
            else if (cb.SelectedIndex == 6) label3.Text = "15:00";
            else if (cb.SelectedIndex == 7) label3.Text = "00:10";
        }
        Timer tGiam = new Timer() { Interval = 1000 };
        DateTime dt1;
        private void button2_Click(object sender, EventArgs e)
        {
            CLick();
        }
        String pass;
        void CLick()
        {

            if (textBox1.Text == pass)
            {
                WMPLib.IWMPControls3 controls = (WMPLib.IWMPControls3)axWindowsMediaPlayer1.Ctlcontrols;

                // Check first to be sure the operation is valid. 
                if (controls.get_isAvailable("stop"))
                {
                    controls.stop();
                }
                dt1 = Convert.ToDateTime("00:" + label3.Text);
                tGiam.Start();
                button2.Visible = false; comboBox1.Visible = false; button5.Visible = true;
            }
            else { comboBox1.Text = "Mật khẩu sai"; }
        }
        void tGiam_Tick(object sender, EventArgs e)
        {
            if (label3.Text == "00:00")
            {
                tGiam.Stop();
                label3.Text = "00:00";
                button2.Visible = true; comboBox1.Visible = true; button5.Visible = false;
                dt1 = dt1.AddSeconds(1);
                comboBox1.Text = "0 giây";
                try
                {
                    if (!song.EndsWith(".mp3") && !song.EndsWith(".wav") && !song.EndsWith(".mp4"))
                    {
                        Process.Start(song);
                        return;
                    }
                    if (lop == 1)
                    {
                        axWindowsMediaPlayer1.settings.setMode("Loop", true);
                        axWindowsMediaPlayer1.URL = song;
                    }
                    else
                    {

                        axWindowsMediaPlayer1.settings.setMode("Loop", false);
                        axWindowsMediaPlayer1.URL = song;
                    }
                }
                catch
                {
                    try
                    {
                        Process.Start(song);
                    }
                    catch
                    {
                        song = Directory.GetCurrentDirectory() + @"\" + song;
                        MessageBox.Show("Đường dẫn: " + song + " Không tìm thấy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            dt1 = dt1.AddSeconds(-1);
            label3.Text = dt1.ToString("mm:ss");

        }
        //slide panel
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (choi == 1)
            {
                if (panel4.Width < 418)
                {
                    panel4.Size = new Size(panel4.Width + 30, panel4.Height);
                }
            }
            else
            {
                if (panel4.Width > 0)
                {
                    panel4.Size = new Size(panel4.Width - 30, panel4.Height);
                }
            }

        }
        int choi = 0;
        //on/off slide panel
        private void button3_Click(object sender, EventArgs e)
        {
            choi = 1;

        }
        //OFF slide panel
        void button4_Click(object sender, EventArgs e)
        {
            choi = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            tGiam.Stop();
            button2.Visible = true; comboBox1.Visible = true; button5.Visible = false;
            comboBox1.Text = "0 giây";
            label3.Text = "00:00";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) CLick();
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = e.SuppressKeyPress = true;
                if (e.KeyCode == Keys.Enter) ExitBut();
            }

        }
    }
}
