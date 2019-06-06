using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace bunifutest
{
    public partial class WeekUI : UserControl
    {
        Timer tm = new Timer() { Interval=10};
        Timer tm1 = new Timer() { Interval = 40 };

        String i1;
        int TuanTrongNam;
        String i2 ;
        int TuanTrongThang;


        public static string ChuThuong(string str)
        {
            string ret = "";
            foreach (char c in str)
            {
                string s = c.ToString();
                ret += s.ToLower();
            }

            return ret;
        } 
        public WeekUI()
        {
            InitializeComponent();
            DateTime dt = new DateTime(Convert.ToInt32(DateTime.Now.ToString("yyyy")), Convert.ToInt32(textBox2.Text),Convert.ToInt32(textBox1.Text));
            label25.Text = LayTuanTrongNam(dt).ToString(); 
            int day = Convert.ToInt32(label25.Text);
            day -= 1;
            label25.Text = day.ToString();if (label25.Text != "1") panel1.Visible = true;
            tm.Tick += tm_Tick;
            //tm.Start();

          

            tm1.Tick += tm1_Tick; tm1.Start();
         
        }
        int u = 0, u1 = 0;
        void tm1_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime i1 = new DateTime(Convert.ToInt32(DateTime.Now.ToString("yyyy")), Convert.ToInt32(DateTime.Now.ToString("MM")), Convert.ToInt32(DateTime.Now.ToString("dd")));
                TuanTrongNam = Convert.ToInt32(LayTuanTrongNam(Convert.ToDateTime(i1)));
                DateTime i2 = new DateTime(Convert.ToInt32(DateTime.Now.ToString("yyyy")), 1, Convert.ToInt32(DateTime.Now.ToString("dd")));
                TuanTrongThang = Convert.ToInt32(LayTuanTrongNam(Convert.ToDateTime(i2)));

                if (u == TuanTrongNam) { u--; } if (u1 == TuanTrongThang) { u1--; }

                label3.Text = u.ToString(); u++;
                label2.Text = u1.ToString(); u1++;
            }
            catch {  }
            
        }

        void tm_Tick(object sender, EventArgs e)
        {
            DateTime i = new DateTime(Convert.ToInt32(DateTime.Now.ToString("yyyy")), Convert.ToInt32(DateTime.Now.ToString("MM")), Convert.ToInt32(DateTime.Now.ToString("dd")));
            int TuanTrongNam = Convert.ToInt32(LayTuanTrongNam(Convert.ToDateTime(i))) - 1;
            label3.Text = TuanTrongNam.ToString();
            i = new DateTime(Convert.ToInt32(DateTime.Now.ToString("yyyy")), 1, Convert.ToInt32(DateTime.Now.ToString("dd")));
            TuanTrongNam = Convert.ToInt32(LayTuanTrongNam(Convert.ToDateTime(i))) - 1;
            label2.Text = TuanTrongNam.ToString();
        }
        #region Một số hàm khác
        public static int LayTuanTrongNam(DateTime time)
        {
            CultureInfo myCI = CultureInfo.CurrentCulture;
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            // so tuan hien tai
            return myCal.GetWeekOfYear(time, myCWR, myFirstDOW);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (textBox2.Text == "") textBox2.Text = "1"; if (textBox1.Text == "") textBox1.Text = "1";
                DateTime dt = new DateTime(Convert.ToInt32(DateTime.Now.ToString("yyyy")), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
            
                label25.Text = LayTuanTrongNam(dt).ToString();
                int day = Convert.ToInt32(label25.Text);
                day -= 1;
                label25.Text = day.ToString();
            }
            catch { MessageBox.Show("Lỗi nhập dữ liệu"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                try
                {
                    if (textBox2.Text == "") textBox2.Text = "1";
                    if (textBox1.Text == "") textBox1.Text = "1";
                    DateTime dt = new DateTime(Convert.ToInt32(DateTime.Now.ToString("yyyy")), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));

                    label25.Text = LayTuanTrongNam(dt).ToString();
                    int day = Convert.ToInt32(label25.Text);
                    day -= 1;
                    label25.Text = day.ToString();
                }
                catch { MessageBox.Show("Lỗi nhập dữ liệu"); }
            }
        }
    }
}
