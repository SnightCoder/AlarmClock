using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
namespace bunifutest
{
    public partial class HenGioUI : UserControl
    {
        public HenGioUI()
        {
            InitializeComponent(); tmRun.Tick += tmRun_Tick; tmDown.Tick += tm_Tick;
           
        }
        Timer tmDown = new Timer() { Interval = 1 };
        Timer tmUp = new Timer() { Interval = 1 };
        Timer tmRight = new Timer() { Interval = 1 };
        Timer tmRun = new Timer() { Interval = 1000 };

        private void Downbtn_Click(object sender, EventArgs e)
        {
            Downbtn.Visible = false;
            Upbtn.Visible = true;
            tmDown.Tick += tm_Tick;
            tmDown.Start();

        }

        void tm_Tick(object sender, EventArgs e)
        {
            if (panel1.Height < 310) panel1.Size = new Size(panel1.Width, panel1.Height + 5); else tmDown.Stop();
        }

        private void Upbtn_Click(object sender, EventArgs e)
        {
            Downbtn.Visible = true;
            Upbtn.Visible = false;
            tmUp.Tick += tmUp_Tick;
            tmUp.Start();
        }

        void tmUp_Tick(object sender, EventArgs e)
        {
            if (panel1.Height > 132) panel1.Size = new Size(panel1.Width, panel1.Height - 5); else tmUp.Stop();
        }
        DateTime dt;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                dt = Convert.ToDateTime(HouText.Text + ":" + MinText.Text + ":" + SecText.Text);
                label1.Text = dt.ToString("HH:mm:ss");

                //  button1.Visible = false;
                tmRun.Start();
                DungBtn.Visible = true;
                tmRight.Tick += tmRight_Tick;

                DateTime dd = Convert.ToDateTime("0:0:0");
                if (dt == dd)
                {
                    tmRun.Stop();
                    try
                    {
                        su = new SoundPlayer(pathCopy);
                        if (amthanh == 1)
                        {
                            if (lap == 0)
                                su.PlayLooping();
                            else su.Play();
                        }

                    }
                    catch
                    {

                    }
                    DungBtn.Visible = false;
                    if(File.Exists(path1))
                    System.Diagnostics.Process.Start(path1); 
                    if(File.Exists(path2))
                    System.Diagnostics.Process.Start(path2);
                    MessageBox.Show(textBox1.Text);
                    su.Stop();
                }


            }
            catch
            {
                MessageBox.Show("Lỗi nhập thời gian");
            }
     
        }
        SoundPlayer su;
        void tmRun_Tick(object sender, EventArgs e)
        {
            TimeSpan tmm = new TimeSpan(0, 0, 0, 1);
            dt = dt.Subtract(tmm);

            label1.Text = dt.ToString("HH:mm:ss");
            DateTime dd = Convert.ToDateTime("0:0:0");
            if (dt == dd)
            {
                try
                {
                    DungBtn.Visible = false;
                    su = new SoundPlayer(pathCopy);
                    if(amthanh==1){
                        if (lap == 0)
                            su.PlayLooping();
                        else su.Play();
                }
                    label1.Text = dt.ToString("00:00:00");
                tmRun.Stop();
                if (File.Exists(path1))
                    System.Diagnostics.Process.Start(path1);
                if (File.Exists(path2))
                    System.Diagnostics.Process.Start(path2); 
                    MessageBox.Show(textBox1.Text); su.Stop();
                }
                catch
                {

                }

              
            }

        }
        String pathCopy = @"data/baothuc/chuongbaothuc/Musicbox.wav";
        void tmRight_Tick(object sender, EventArgs e)
        {
            if (panel1.Location.X > -360) panel1.Location = new Point(panel1.Location.X - 10, panel1.Location.Y); else tmRight.Stop();
        }

        private void DuyetButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = Directory.GetCurrentDirectory() + "\\data\\baothuc\\chuongcuatoi";
            f.Filter = "Wav file|*.wav";
            DialogResult d = f.ShowDialog();
            if (d == DialogResult.OK)
            { 
                String pathSong = f.FileName;
                pathCopy=@"data/baothuc/chuongbaothuc/";
                if (File.Exists(pathSong)) {
                    comboBox1.Text =Path.GetFileName(pathSong);
                   comboBox1.Text= pathCopy+comboBox1.Text;
                   try
                   {
                       File.Copy(pathSong, comboBox1.Text);
                   }
                   catch {
                     
                   }
                   pathCopy = comboBox1.Text;comboBox1.Text = Path.GetFileName(comboBox1.Text);
                }
              
            }

        }
        int amthanh = 1;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedIndex == 0) {pathCopy = "data\\baothuc\\chuongbaothuc\\data.wav";amthanh=1;}
            else if (cb.SelectedIndex == 1) {pathCopy = "data\\baothuc\\chuongbaothuc\\RengReng.wav";amthanh=1;}
            else amthanh=0;
        }

        private void HouText_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void Dungbtn_Click(object sender, EventArgs e)
        {
            tmRun.Stop();
            label1.Text = "00:00:00";
            DungBtn.Visible = false;
        }

        private void Reset1_Click(object sender, EventArgs e)
        {
            HouText.Text = "0";
            MinText.Text = "0";
            SecText.Text = "0";
        }
        String path1, path2;
        private void StatApp1(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = Directory.GetCurrentDirectory() + "\\data\\baothuc\\anhbaothuc";
            DialogResult d=f.ShowDialog();
            if (d == DialogResult.OK) { path1 = f.FileName;
            String pathMot = Path.GetFileName(path1);
                button5.Text=pathMot;
            }
        }

        private void StatApp2(object sender, EventArgs e)
        {

            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = Directory.GetCurrentDirectory() + "\\data\\baothuc\\anhbaothuc";
            DialogResult d = f.ShowDialog();
            if (d == DialogResult.OK)
            {
                path2 = f.FileName;
                String pathHai = Path.GetFileName(path2);
                button4.Text = pathHai;
            }
        }

        private void StatApp3(object sender, EventArgs e)
        {
            path1= "";
            path2 = "";
            button5.Text="Nhấp để chọn";
            button4.Text = "Nhấp để chọn";
        }

        private void GetNow_Click(object sender, EventArgs e)
        {
            HouText.Text = DateTime.Now.ToString("HH");
            MinText.Text = DateTime.Now.ToString("mm");
            SecText.Text = DateTime.Now.ToString("ss");
        }
        private void ChuongBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedIndex == 0) { pathCopy = @"Data\BaoThuc\ChuongBaoThuc\Alarm.wav"; amthanh = 1; }
            else if (cb.SelectedIndex == 1){ pathCopy = @"Data\BaoThuc\ChuongBaoThuc\bells.wav";    amthanh=1;}
            else if (cb.SelectedIndex == 2){ pathCopy = @"Data\BaoThuc\ChuongBaoThuc\cuckoo.wav";   amthanh=1;}
            else if (cb.SelectedIndex == 3){ pathCopy = @"Data\BaoThuc\ChuongBaoThuc\Flute.wav";    amthanh=1;}
            else if (cb.SelectedIndex == 4){ pathCopy = @"Data\BaoThuc\ChuongBaoThuc\musicbox.wav"; amthanh=1;}
            else if (cb.SelectedIndex == 5){ pathCopy = @"Data\BaoThuc\ChuongBaoThuc\RengReng1.wav";amthanh=1;}
            else if (cb.SelectedIndex == 6){ pathCopy = @"Data\BaoThuc\ChuongBaoThuc\RengReng2.wav";amthanh=1;}
            else if (cb.SelectedIndex == 7) amthanh = 0;

        }
        int lap = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) lap = 0;
            else lap = 1;
        }
    }
}
