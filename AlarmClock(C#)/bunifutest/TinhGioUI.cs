using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bunifutest
{
    public partial class TinhGioUI : UserControl
    {
        public TinhGioUI()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;

            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox2_chek;
        }

        void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label1.Text + " - " + label2.Text);
        }

        void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        void LoiOTrong()
        {
            if (textBox10.Text == "") textBox10.Text = "0";
            if (textBox8.Text == "") textBox8.Text = "1";
            if (textBox7.Text == "") textBox7.Text = "1";
            if (textBox11.Text == "") textBox11.Text = "1";
            if (textBox12.Text == "") textBox12.Text = "0";
            if (textBox9.Text == "") textBox9.Text = "0";
            if (textBox6.Text == "") textBox6.Text = "0";
            if (textBox5.Text == "") textBox5.Text = "0";
            if (textBox4.Text == "") textBox4.Text = "0";
            if (textBox3.Text == "") textBox3.Text = "0";
            if (textBox2.Text == "") textBox2.Text = "0";
            if (textBox1.Text == "") textBox1.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoiOTrong();
            try
            {
                DateTime ToDay = new DateTime(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text), Convert.ToInt32(textBox12.Text));
                label3.Text = ToDay.ToString("dd/MM/yyyy" + " - " + ToDay.ToString("HH:mm:ss"));
                label4.Text = "Cộng thêm";
                label5.Text = textBox3.Text + " ngày, " + textBox2.Text + " tháng, " + textBox1.Text + " năm, " + textBox4.Text + " giờ, " + textBox5.Text + " phút, " + textBox6.Text + " giây";
                ToDay = ToDay.AddMonths(Convert.ToInt32(textBox2.Text));
                ToDay = ToDay.AddDays(Convert.ToInt32(textBox3.Text));
                ToDay = ToDay.AddYears(Convert.ToInt32(textBox1.Text));
                ToDay = ToDay.AddHours(Convert.ToInt32(textBox4.Text));
                ToDay = ToDay.AddMinutes(Convert.ToInt32(textBox5.Text));
                ToDay = ToDay.AddSeconds(Convert.ToInt32(textBox6.Text));
                label1.Text = (ToDay.ToString("dd/MM/yyyy"));
                label2.Text = ToDay.ToString("HH:mm:ss");
                panel3.Visible = true;
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoiOTrong();
            try
            {
                DateTime ToDay = new DateTime(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text), Convert.ToInt32(textBox12.Text));
                label3.Text = ToDay.ToString("dd/MM/yyyy" + " - " + ToDay.ToString("HH:mm:ss"));
                label4.Text = "Trừ đi";
                label5.Text = textBox3.Text + " ngày, " + textBox2.Text + " tháng, " + textBox1.Text + " năm, " + textBox4.Text + " giờ, " + textBox5.Text + " phút, " + textBox6.Text + " giây";
                ToDay = ToDay.AddMonths(-Convert.ToInt32(textBox2.Text));
                ToDay = ToDay.AddDays(-Convert.ToInt32(textBox3.Text));
                ToDay = ToDay.AddYears(-Convert.ToInt32(textBox1.Text));
                ToDay = ToDay.AddHours(-Convert.ToInt32(textBox4.Text));
                ToDay = ToDay.AddMinutes(-Convert.ToInt32(textBox5.Text));
                ToDay = ToDay.AddSeconds(-Convert.ToInt32(textBox6.Text));
                label1.Text = (ToDay.ToString("dd/MM/yyyy"));
                label2.Text = ToDay.ToString("HH:mm:ss"); panel3.Visible = true;
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (checkBox1.Checked == true)
            {
                textBox11.Text = dt.ToString("dd");
                textBox8.Text = dt.ToString("MM");
                textBox7.Text = dt.ToString("yyyy");
                textBox9.Text = dt.ToString("HH");
                textBox10.Text = dt.ToString("mm");
                textBox12.Text = dt.ToString("ss");
            }
        }

        private void CheckBox2_chek(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (checkBox2.Checked == true)
            {
                textBox3.Text = dt.ToString("dd");
                textBox2.Text = dt.ToString("MM");
                textBox1.Text = dt.ToString("yyyy");
                textBox4.Text = dt.ToString("HH");
                textBox5.Text = dt.ToString("mm");
                textBox6.Text = dt.ToString("ss");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox10.Text = "0";
            textBox8.Text = "1";
            textBox7.Text = "1";
            textBox11.Text = "1";
            textBox12.Text = "0";
            textBox9.Text = "0";
            textBox6.Text = "0";
            textBox5.Text = "0";
            textBox4.Text = "0";
            textBox3.Text = "0";
            textBox2.Text = "0";
            textBox1.Text = "0";
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = e.SuppressKeyPress = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Quydoi_Click(object sender, EventArgs e)
        {

            LoiOTrong();
            try
            {
                TimeSpan tmp = new TimeSpan(Convert.ToInt32(textBox9.Text) + Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox10.Text) + Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox12.Text) + Convert.ToInt32(textBox6.Text));
                label3.Text = (Convert.ToInt32(textBox9.Text) + Convert.ToInt32(textBox4.Text)) + " giờ, " + (Convert.ToInt32(textBox10.Text) + Convert.ToInt32(textBox5.Text)) + " phút, " + (Convert.ToInt32(textBox12.Text) + Convert.ToInt32(textBox6.Text)) + " giây";
                label4.Text = "Quy Đổi ";
                label5.Text = "                  Thành Giờ Phút Giây :";
                label1.Text = "";
                label2.Text = tmp.ToString(@"hh\:mm\:ss");
                panel3.Visible = true;
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void DuongAm_Click(object sender, EventArgs e)
        {
            LoiOTrong();
            #region Checker    
            int Month = Convert.ToInt32(textBox8.Text) + Convert.ToInt32(textBox2.Text);
            int day = Convert.ToInt32(textBox11.Text) + Convert.ToInt32(textBox3.Text);  
            // 31 days 11 3          
            if (Month > 12) { MessageBox.Show("Tháng không được lớn hơn 12"); return; }
            else if (Month < 1) { MessageBox.Show("Tháng không được nhỏ hơn 1"); return; }

            if (day < 0) { MessageBox.Show("Ngày không được nhỏ hơn 0"); return; }
            else if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
            {
                if (day > 31) { MessageBox.Show("Trong tháng " + Month + " Không có ngày " + day); return; }
            }     
            //28 days: 2
            else if (Month == 2)
            {
                if (day > 28)
                {
                    MessageBox.Show("Trong tháng 2 không có ngày " + day); return;
                }
            }

            else
            {
                if (day > 30)
                {
                    MessageBox.Show("Trong tháng " + Month + " Không có ngày " + day); return;
                }
            }
            #endregion

            try
            {
                int ngay = Convert.ToInt32(textBox11.Text) + Convert.ToInt32(textBox3.Text);
                int thang = Convert.ToInt32(textBox8.Text) + Convert.ToInt32(textBox2.Text);
                int nam = Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox1.Text);

                label3.Text = "ngày " + ngay + " tháng " + thang + " năm " + nam;
                label4.Text = "   Quy Đổi ";
                label5.Text = "                         Thành lịch âm:";
                label1.Text = "";

                int Intngay = convertSolar2Lunar_Ngay(ngay, thang, nam);
                int Intthang = convertSolar2Lunar_Thang(ngay, thang, nam);
                int Intnam = convertSolar2Lunar_Nam(ngay, thang, nam);

                label2.Text = Intngay + "/" + Intthang + "/" + Intnam;
                panel3.Visible = true;
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }

        }
        #region Đổi lịch âm dương
        static long getJulius(int intNgay, int intThang, int intNam)
        {
            int a, y, m, jd;
            a = (int)((14 - intThang) / 12);
            y = intNam + 4800 - a;
            m = intThang + 12 * a - 3;
            jd = intNgay + (int)((153 * m + 2) / 5) + 365 * y + (int)(y / 4) - (int)(y / 100) + (int)(y / 400) - 32045;
            if (jd < 2299161)
            {
                jd = intNgay + (int)((153 * m + 2) / 5) + 365 * y + (int)(y / 4) - 32083;
            }
            return jd;
        }
        // Tinh ngay Soc
        static int getNewMoonDay(int k)
        {
            float PI = 3.14f;
            double T, T2, T3, dr, Jd1, M, Mpr, F, C1, deltat, JdNew;
            T = k / 1236.85;
            T2 = T * T;
            T3 = T2 * T;
            dr = PI / 180;
            double timeZone = 7.0;
            Jd1 = 2415020.75933 + 29.53058868 * k + 0.0001178 * T2 - 0.000000155 * T3;
            // Mean new moon
            Jd1 = Jd1 + 0.00033 * Math.Sin((166.56 + 132.87 * T - 0.009173 * T2) * dr);
            // Sun's mean anomaly
            M = 359.2242 + 29.10535608 * k - 0.0000333 * T2 - 0.00000347 * T3;
            // Moon's mean anomaly
            Mpr = 306.0253 + 385.81691806 * k + 0.0107306 * T2 + 0.00001236 * T3;
            // Moon's argument of latitude
            F = 21.2964 + 390.67050646 * k - 0.0016528 * T2 - 0.00000239 * T3;
            C1 = (0.1734 - 0.000393 * T) * Math.Sin(M * dr) + 0.0021 * Math.Sin(2 * dr * M);
            C1 = C1 - 0.4068 * Math.Sin(Mpr * dr) + 0.0161 * Math.Sin(dr * 2 * Mpr);
            C1 = C1 - 0.0004 * Math.Sin(dr * 3 * Mpr);
            C1 = C1 + 0.0104 * Math.Sin(dr * 2 * F) - 0.0051 * Math.Sin(dr * (M + Mpr));
            C1 = C1 - 0.0074 * Math.Sin(dr * (M - Mpr)) + 0.0004 * Math.Sin(dr * (2 * F + M));
            C1 = C1 - 0.0004 * Math.Sin(dr * (2 * F - M)) - 0.0006 * Math.Sin(dr * (2 * F + Mpr));
            C1 = C1 + 0.0010 * Math.Sin(dr * (2 * F - Mpr)) + 0.0005 * Math.Sin(dr * (2 * Mpr + M));
            if (T < -11)
            {
                deltat = 0.001 + 0.000839 * T + 0.0002261 * T2 - 0.00000845 * T3 - 0.000000081 * T * T3;
            }
            else
            {
                deltat = -0.000278 + 0.000265 * T + 0.000262 * T2;
            }
            JdNew = Jd1 + C1 - deltat;
            return (int)(JdNew + 0.5 + timeZone / 24);
        }
        //Tính toa do mat troi
        static int getSunLongitude(int jdn)
        {
            double timeZone = 7.0;
            float PI = 3.14f;
            double T, T2, dr, M, L0, DL, L;
            // Time in Julian centuries from 2000-01-01 12:00:00 GMT
            T = (jdn - 2451545.5 - timeZone / 24) / 36525;
            T2 = T * T;
            // degree to radian
            dr = PI / 180;
            // mean anomaly, degree
            M = 357.52910 + 35999.05030 * T - 0.0001559 * T2 - 0.00000048 * T * T2;
            // mean longitude, degree
            L0 = 280.46645 + 36000.76983 * T + 0.0003032 * T2;
            DL = (1.914600 - 0.004817 * T - 0.000014 * T2) * Math.Sin(dr * M);
            DL = DL + (0.019993 - 0.000101 * T) * Math.Sin(dr * 2 * M) + 0.000290 * Math.Sin(dr * 3 * M);
            L = L0 + DL; // true longitude, degree
            L = L * dr;
            // Normalize to (0, 2*PI)
            L = L - PI * 2 * (int)(L / (PI * 2));
            return (int)(L / PI * 6);
        }
        // Tìm ngày bat dau tháng 11 am lich
        static int getLunarMonthll(int intNam)
        {
            double k, off, nm, sunLong;
            off = getJulius(31, 12, intNam) - 2415021;
            k = (int)(off / 29.530588853);
            nm = getNewMoonDay((int)k);
            // sun longitude at local midnight
            sunLong = getSunLongitude((int)nm);
            if (sunLong >= 9)
            {
                nm = getNewMoonDay((int)k - 1);
            }
            return (int)nm;
        }
        //Xác dinh thang nhuan
        static int getLeapMonthOffset(double a11)
        {
            double last, arc;
            int k, i;
            k = (int)((a11 - 2415021.076998695) / 29.530588853 + 0.5);
            last = 0;
            // We start with the month following lunar month 11
            i = 1;
            arc = getSunLongitude((int)getNewMoonDay((int)(k + i)));
            do
            {
                last = arc;
                i++;
                arc = getSunLongitude((int)getNewMoonDay((int)(k + i)));
            } while (arc != last && i < 14);
            return i - 1;
        }
        //Doi ra ngay am-duong
        static int convertSolar2Lunar_Ngay(int intNgay, int intThang, int intNam)
        {
            double dayNumber, monthStart, a11, b11, lunarDay, lunarMonth, lunarYear;
            //double lunarLeap;
            int k, diff;
            dayNumber = getJulius(intNgay, intThang, intNam);
            k = (int)((dayNumber - 2415021.076998695) / 29.530588853);
            monthStart = getNewMoonDay(k + 1);
            if (monthStart > dayNumber)
            {
                monthStart = getNewMoonDay(k);
            }
            a11 = getLunarMonthll(intNam);
            b11 = a11;
            if (a11 >= monthStart)
            {
                lunarYear = intNam;
                a11 = getLunarMonthll(intNam - 1);
            }
            else
            {
                lunarYear = intNam + 1;
                b11 = getLunarMonthll(intNam + 1);
            }
            lunarDay = dayNumber - monthStart + 1;
            diff = (int)((monthStart - a11) / 29);
            //lunarLeap = 0;
            lunarMonth = diff + 11;
            if (b11 - a11 > 365)
            {
                int leapMonthDiff = getLeapMonthOffset(a11);
                if (diff >= leapMonthDiff)
                {
                    lunarMonth = diff + 10;
                    if (diff == leapMonthDiff)
                    {
                        //lunarLeap = 1;
                    }
                }
            }
            if (lunarMonth > 12)
            {
                lunarMonth = lunarMonth - 12;
            }
            if (lunarMonth >= 11 && diff < 4)
            {
                lunarYear -= 1;
            }
            int Ngay = (int)lunarDay;
            int Thang = (int)lunarMonth;
            int Nam = (int)lunarYear;
            return Ngay;
        }
        static int convertSolar2Lunar_Thang(int intNgay, int intThang, int intNam)
        {
            double dayNumber, monthStart, a11, b11, lunarDay, lunarMonth, lunarYear;
            //double lunarLeap;
            int k, diff;
            dayNumber = getJulius(intNgay, intThang, intNam);
            k = (int)((dayNumber - 2415021.076998695) / 29.530588853);
            monthStart = getNewMoonDay(k + 1);
            if (monthStart > dayNumber)
            {
                monthStart = getNewMoonDay(k);
            }
            a11 = getLunarMonthll(intNam);
            b11 = a11;
            if (a11 >= monthStart)
            {
                lunarYear = intNam;
                a11 = getLunarMonthll(intNam - 1);
            }
            else
            {
                lunarYear = intNam + 1;
                b11 = getLunarMonthll(intNam + 1);
            }
            lunarDay = dayNumber - monthStart + 1;
            diff = (int)((monthStart - a11) / 29);
            //lunarLeap = 0;
            lunarMonth = diff + 11;
            if (b11 - a11 > 365)
            {
                int leapMonthDiff = getLeapMonthOffset(a11);
                if (diff >= leapMonthDiff)
                {
                    lunarMonth = diff + 10;
                    if (diff == leapMonthDiff)
                    {
                        //lunarLeap = 1;
                    }
                }
            }
            if (lunarMonth > 12)
            {
                lunarMonth = lunarMonth - 12;
            }
            if (lunarMonth >= 11 && diff < 4)
            {
                lunarYear -= 1;
            }
            int Thang = (int)lunarMonth;
            return Thang;
        }
        static int convertSolar2Lunar_Nam(int intNgay, int intThang, int intNam)
        {
            double dayNumber, monthStart, a11, b11, lunarDay, lunarMonth, lunarYear;
            //double lunarLeap;
            int k, diff;
            dayNumber = getJulius(intNgay, intThang, intNam);
            k = (int)((dayNumber - 2415021.076998695) / 29.530588853);
            monthStart = getNewMoonDay(k + 1);
            if (monthStart > dayNumber)
            {
                monthStart = getNewMoonDay(k);
            }
            a11 = getLunarMonthll(intNam);
            b11 = a11;
            if (a11 >= monthStart)
            {
                lunarYear = intNam;
                a11 = getLunarMonthll(intNam - 1);
            }
            else
            {
                lunarYear = intNam + 1;
                b11 = getLunarMonthll(intNam + 1);
            }
            lunarDay = dayNumber - monthStart + 1;
            diff = (int)((monthStart - a11) / 29);
            //lunarLeap = 0;
            lunarMonth = diff + 11;
            if (b11 - a11 > 365)
            {
                int leapMonthDiff = getLeapMonthOffset(a11);
                if (diff >= leapMonthDiff)
                {
                    lunarMonth = diff + 10;
                    if (diff == leapMonthDiff)
                    {
                        //lunarLeap = 1;
                    }
                }
            }
            if (lunarMonth > 12)
            {
                lunarMonth = lunarMonth - 12;
            }
            if (lunarMonth >= 11 && diff < 4)
            {
                lunarYear -= 1;
            }
            int Ngay = (int)lunarDay;
            int Thang = (int)lunarMonth;
            int Nam = (int)lunarYear;
            return Nam;
        }
        #endregion



    }

}
