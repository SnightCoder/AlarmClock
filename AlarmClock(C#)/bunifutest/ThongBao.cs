using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace bunifutest
{
    public partial class ThongBao : Form
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

        Timer tmHide = new Timer() { Interval = 10 };
        Timer Tm = new Timer() { Interval = 10 };
        Timer closeTm = new Timer() { Interval = 3000 };
        Timer tLeave = new Timer() { Interval = 10 };
        public ThongBao()
        {
            InitializeComponent();


            #region Botton sc
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            #endregion
            #region 1
            StreamReader srI = new StreamReader(@"data\baothuc\i.adb"); string u = srI.ReadLine(); srI.Close();
            StreamReader srName = new StreamReader(@"data\baothuc\clock" + u + "\\TenBaothuc.adb");
            label1.Text = srName.ReadLine();
            srName.Close();
            StreamReader srImage = new StreamReader(@"data\baothuc\clock" + u + "\\AnhPath.adb");
            try
            {
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\" + srImage.ReadLine());
            }
            catch {    
                pictureBox1.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoThuc\MacDinh.png");
            }
            srImage.Close();
            StreamReader srTime = new StreamReader(@"data\baothuc\TimeText.adb");
            label3.Text = srTime.ReadLine();
            srTime.Close();

            label2.Click += label2_Click;
            Tm.Tick += Tm_Tick;
            Tm.Start();

            tmHide.Tick += tmHide_Tick;

           
            closeTm.Tick += closeTm_Tick;
            closeTm.Start();
            #endregion 
            tLeave.Tick += tLeave_Tick;
            

        }

        void tLeave_Tick(object sender, EventArgs e)
        {
            tmHide.Start();
        }

        void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void tmHide_Tick(object sender, EventArgs e)
        {
            Tm.Stop();
            i -= 0.1;
            this.Opacity = i;
            if (this.Opacity == 0) this.Close();
        }

        void closeTm_Tick(object sender, EventArgs e)
        {
            tmHide.Start();
        }
        double i = 0;
        void Tm_Tick(object sender, EventArgs e)
        {
            i += 0.1;
            this.Opacity = i;
        }

        private void ThongBao_MouseHover(object sender, EventArgs e)
        {
            tLeave.Stop();
            closeTm.Stop();
        }

        private void ThongBao_MouseLeave(object sender, EventArgs e)
        {
          //  tLeave.Start();
        }
    }
}
