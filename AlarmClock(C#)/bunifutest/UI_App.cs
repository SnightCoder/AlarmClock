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
using System.Globalization;
using System.Diagnostics;
using Microsoft.Win32;
using System.Media;
using Microsoft.VisualBasic;
using System.Net;
// Line 1835
namespace bunifutest
{
    public partial class UI_App : Form
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


        int u = 21;
        int uu = 20;
        Timer Isong = new Timer() { Interval = 1 };

        void LoadISong()
        {
            Isong.Tick += Isong_Tick;
            Isong.Start();

        }
        String pathMusicRead;
        void Isong_Tick(object sender, EventArgs e)
        {
            if (iu < 0 || iu > uu) return;
            StreamReader sr = new StreamReader(@"data\baothuc\clock" + iu + "\\chuongpath.adb");
            pathMusicRead = sr.ReadLine();
            sr.Close();
        }
        public UI_App()
        {
            InitializeComponent();
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            LoadISong();
            #region checkboxLoad ne
            ThoiCheck.Enabled = true;
            DateText.Enabled = true;
            YearText.Enabled = true;
            MonthText.Enabled = true;
            if (NgayCheck.Checked == false) { ThoiCheck.Checked = false; ThoiCheck.Enabled = false; DateText.Enabled = false; YearText.Enabled = false; MonthText.Enabled = false; }
            #endregion
            #region load các panel
            panelMau.BackColor = Color.FromArgb(239, 238, 236); panelMau2.BackColor = Color.FromArgb(239, 238, 236);
            HenGioButton.TabStop = false;
            HenGioButton.FlatAppearance.BorderSize = 0;
            TinhGioButton.TabStop = false;
            TinhGioButton.FlatAppearance.BorderSize = 0;
            BamGioButton.TabStop = false;
            BamGioButton.FlatAppearance.BorderSize = 0;
            HenGioButton.TabStop = false;
            HenGioButton.FlatAppearance.BorderSize = 0;

            button3.TabStop = false;
            #endregion
            getTimeNow();
            FormLoad();
            MenuClock();

        }
        void LoadCheckLogin()
        {
            #region
            StreamReader srCheck = new StreamReader(@"data\setting\login.adb");
            passCheck = Convert.ToInt32(srCheck.ReadLine()); srCheck.Close();
            #endregion
        }
        // TimeNowLabel,SecNowLabel,ThuTrongTuanLabel,NgayVaThangLabel,NutThoat,AnChuongTrinh,PhongTo,SearchText,SearchButton
        // LeftButton,RightButton,NowTimeReset,AmLichButton,SlideBlue,BaoThucButton
        // sự kiện nút Close Alt+F4

        /*
         *  // [if (iu == 3)GetTime_tick;] tmCLock3.Start(); LoadCLock5;
        void GetTime_tick(object sender, EventArgs e)
        {*/
        Timer tmLich = new Timer() { Interval = 10 };
        void tmLich_Tick(object sender, EventArgs e)
        {
          
            LoadLich();
        }
        void LoadLich()
        {
            #region 1
            StreamReader srImage = new StreamReader(@"Data\LichText\Lich1\ImagePath.adb");
            String imagePath = srImage.ReadLine();
            srImage.Close();
            StreamReader srText = new StreamReader(@"Data\LichText\Lich1\Text.adb");
            String texti = (srText.ReadToEnd());
            srText.Close();
            StreamReader srTitle = new StreamReader(@"Data\LichText\Lich1\\Title.adb");
            String titlei = (srTitle.ReadToEnd());
            srTitle.Close();

            Lich1.Text = titlei;
            LichMot.Text = texti;
            #endregion
            #region 2
            StreamReader srImage2 = new StreamReader(@"Data\LichText\Lich2\ImagePath.adb");
            String imagePath2 = srImage2.ReadLine();
            srImage2.Close();
            StreamReader srText2 = new StreamReader(@"Data\LichText\Lich2\Text.adb");
            String texti2 = (srText2.ReadToEnd());
            srText2.Close();
            StreamReader srTitle2 = new StreamReader(@"Data\LichText\Lich2\\Title.adb");
            String titlei2 = (srTitle2.ReadToEnd());
            srTitle2.Close();

            Lich2.Text = titlei2;
            LichHai.Text = texti2;
            #endregion
            #region 3
            StreamReader srImage3 = new StreamReader(@"Data\LichText\Lich3\ImagePath.adb");
            String imagePath3 = srImage3.ReadLine();
            srImage3.Close();
            StreamReader srText3 = new StreamReader(@"Data\LichText\Lich3\Text.adb");
            String texti3 = (srText3.ReadToEnd());
            srText3.Close();
            StreamReader srTitle3 = new StreamReader(@"Data\LichText\Lich3\\Title.adb");
            String titlei3 = (srTitle3.ReadToEnd());
            srTitle3.Close();

            Lich3.Text = titlei3;
            LichBa.Text = texti3;
            #endregion
        }

        String path = @"data\user\user.adb";
        String pathAvatar = @"data\user\avatar.adb";
        String pathAvatarB = @"data\user\avatarb.adb";
        String pathImage = @"data\user\anh";
        String path2 = @"data\user\name.adb";

        void GetTime_tick(object sender, EventArgs e)
        {
            LoadRong();
            DateTime dtt = DateTime.Now; ngayNam.Text = dtt.DayOfYear.ToString();
            StreamReader srStat = new StreamReader(@"data\windows.adb");
            int stat = Convert.ToInt32(srStat.ReadLine());
            srStat.Close();
            if (stat == 1) checkBox2.Checked = true;
            else checkBox2.Checked = false;
            for (int i = 1; i < u; i++)
            {
                String On_OFF = @"data\baothuc\Clock" + i + "\\ON_OFF.adb";
                StreamReader sr = new StreamReader(On_OFF);
                int on = Convert.ToInt32(sr.ReadLine());
                sr.Close();


                if (i == 1)
                {
                    if (on == 1)
                    {
                        ON1.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off = 0;
                    }
                    else
                    {
                        ON1.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off = 1;
                    }
                }
                if (i == 2)
                {
                    if (on == 1)
                    {
                        ON2.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off2 = 0;
                    }
                    else
                    {
                        ON2.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off2 = 1;
                    }
                }

                if (i == 3)
                {
                    if (on == 1)
                    {
                        ON3.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off3 = 0;
                    }
                    else
                    {
                        ON3.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off3 = 1;
                    }
                }
                if (i == 4)
                {
                    if (on == 1)
                    {
                        ON4.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off4 = 0;
                    }
                    else
                    {
                        ON4.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off4 = 1;
                    }
                }
                if (i == 5)
                {
                    if (on == 1)
                    {
                        ON5.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off5 = 0;
                    }
                    else
                    {
                        ON5.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off5 = 1;
                    }
                }
                if (i == 6)
                {
                    if (on == 1)
                    {
                        ON6.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off6 = 0;
                    }
                    else
                    {
                        ON6.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off6 = 1;
                    }
                }

                if (i == 7)
                {
                    if (on == 1)
                    {
                        ON7.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off7 = 0;
                    }
                    else
                    {
                        ON7.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off7 = 1;
                    }
                }

                if (i == 8)
                {
                    if (on == 1)
                    {
                        ON8.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off8 = 0;
                    }
                    else
                    {
                        ON8.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off8 = 1;
                    }
                }

                if (i == 9)
                {
                    if (on == 1)
                    {
                        ON9.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off9 = 0;
                    }
                    else
                    {
                        ON9.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off9 = 1;
                    }
                }

                if (i == 10)
                {
                    if (on == 1)
                    {
                        ON10.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off10 = 0;
                    }
                    else
                    {
                        ON10.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off10 = 1;
                    }
                }

                if (i == 11)
                {
                    if (on == 1)
                    {
                        ON11.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off11 = 0;
                    }
                    else
                    {
                        ON11.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off11 = 1;
                    }
                }

                if (i == 12)
                {
                    if (on == 1)
                    {
                        ON12.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off12 = 0;
                    }
                    else
                    {
                        ON12.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off12 = 1;
                    }
                }

                if (i == 13)
                {
                    if (on == 1)
                    {
                        ON13.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off13 = 0;
                    }
                    else
                    {
                        ON13.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off13 = 1;
                    }
                }

                if (i == 14)
                {
                    if (on == 1)
                    {
                        ON14.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off14 = 0;
                    }
                    else
                    {
                        ON14.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off14 = 1;
                    }
                }

                if (i == 15)
                {
                    if (on == 1)
                    {
                        ON15.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off15 = 0;
                    }
                    else
                    {
                        ON15.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off15 = 1;
                    }
                }

                if (i == 16)
                {
                    if (on == 1)
                    {
                        ON16.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off16 = 0;
                    }
                    else
                    {
                        ON16.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off16 = 1;
                    }
                }

                if (i == 17)
                {
                    if (on == 1)
                    {
                        ON17.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off17 = 0;
                    }
                    else
                    {
                        ON17.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off17 = 1;
                    }
                }

                if (i == 18)
                {
                    if (on == 1)
                    {
                        ON18.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off18 = 0;
                    }
                    else
                    {
                        ON18.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off18 = 1;
                    }
                }

                if (i == 19)
                {
                    if (on == 1)
                    {
                        ON19.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off19 = 0;
                    }
                    else
                    {
                        ON19.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off19 = 1;
                    }
                }

                if (i == 20)
                {
                    if (on == 1)
                    {
                        ON20.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off20 = 0;
                    }
                    else
                    {
                        ON20.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off20 = 1;
                    }
                }
            }

            if (LichAm == 0)
            {
                TimeNowLabel.Text = DateTime.Now.ToString("HH:mm").ToString();
                SecNowLabel.Text = DateTime.Now.ToString("ss").ToString();
                DateTime dt = Convert.ToDateTime(DateTime.Now);
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                #region dịch tháng trong năm
                int thangCheck = Convert.ToInt32(dt.ToString("MM"));
                if (thangCheck == 1) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Giêng";
                if (thangCheck == 2) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Hai";
                if (thangCheck == 3) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Ba";
                if (thangCheck == 4) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Tư";
                if (thangCheck == 5) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Năm";
                if (thangCheck == 6) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Sáu";
                if (thangCheck == 7) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Bảy";
                if (thangCheck == 8) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Tám";
                if (thangCheck == 9) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Chín";
                if (thangCheck == 10) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Mười";
                if (thangCheck == 11) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Mười Một";
                if (thangCheck == 12) NgayVaThangLabel.Text = DateTime.Now.ToString("dd").ToString() + " Tháng Mười Hai";
                #endregion
                #region dịch ngày trong tuần
                if (dt.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
                else if (dt.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
                else if (dt.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
                else if (dt.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
                else if (dt.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
                else if (dt.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
                else if (dt.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
                #endregion
            }
            if (LichAm == 1)
            {
                DateTime dt1 = DateTime.Now;
                TimeNowLabel.Text = dt1.ToString("HH:mm").ToString();
                SecNowLabel.Text = dt1.ToString("ss").ToString();

                DuongLichButton.Visible = true;

                TimeNowLabel.Visible = true;
                DuongLichButton.Visible = true;
                SecNowLabel.Visible = true;
                ngayNam.Visible = false;


                #region lấy ngày âm hiện tại
                DateTime dt = DateTime.Now;
                int ngay = dt.Day;
                int thang = dt.Month;
                int nam = dt.Year;

                int Intngay = convertSolar2Lunar_Ngay(ngay, thang, nam);
                int Intthang = convertSolar2Lunar_Thang(ngay, thang, nam);
                int Intnam = convertSolar2Lunar_Nam(ngay, thang, nam);
                NgayVaThuTuan = dt.ToString();
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                #region dịch tháng trong năm
                int thangCheck = Intthang;
                if (thangCheck == 1) NgayVaThangLabel.Text =  Intngay + " Tháng Giêng" + " (Âm)";
                if (thangCheck == 2) NgayVaThangLabel.Text =  Intngay + " Tháng Hai" + " (Âm)";
                if (thangCheck == 3) NgayVaThangLabel.Text =  Intngay + " Tháng Ba" + " (Âm)";
                if (thangCheck == 4) NgayVaThangLabel.Text =  Intngay + " Tháng Tư" + " (Âm)";
                if (thangCheck == 5) NgayVaThangLabel.Text =  Intngay + " Tháng Năm" + " (Âm)";
                if (thangCheck == 6) NgayVaThangLabel.Text =  Intngay + " Tháng Sáu" + " (Âm)";
                if (thangCheck == 7) NgayVaThangLabel.Text =  Intngay + " Tháng Bảy" + " (Âm)";
                if (thangCheck == 8) NgayVaThangLabel.Text =  Intngay + " Tháng Tám" + " (Âm)";
                if (thangCheck == 9) NgayVaThangLabel.Text =  Intngay + " Tháng Chín" + " (Âm)";
                if (thangCheck == 10) NgayVaThangLabel.Text = Intngay + " Tháng Mười" + " (Âm)";
                if (thangCheck == 11) NgayVaThangLabel.Text = Intngay + " Tháng Mười Một" + " (Âm)";
                if (thangCheck == 12) NgayVaThangLabel.Text = Intngay + " Tháng Mười Hai" + " (Âm)";
                #endregion
                #region dịch ngày trong tuần
                if (dt.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
                else if (dt.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
                else if (dt.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
                else if (dt.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
                else if (dt.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
                else if (dt.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
                else if (dt.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
                #endregion
                #endregion

            }

        }


        protected override void OnClosing(CancelEventArgs e)
        {

            StreamWriter sr = new StreamWriter("data\\iconshow.adb");
            sr.WriteLine("0");
            sr.Close();

            StreamWriter sr1 = new StreamWriter("data\\uishow.adb");
            sr1.WriteLine("1");
            sr1.Close();

            e.Cancel = true;
            this.Hide();

        }
        Timer tmShow = new Timer() { Interval = 1 };
        //K iểm tra tên để hiện lên màn hình clock
        void HideShowClock()
        {
            String Path_name = @"Data\BaoThuc\Clock1\On_Off.adb";
            String Path_name2 = @"Data\BaoThuc\Clock2\On_Off.adb";
            String Path_name3 = @"Data\BaoThuc\Clock3\On_Off.adb";
            String Path_name4 = @"Data\BaoThuc\Clock4\On_Off.adb";
            String Path_name5 = @"Data\BaoThuc\Clock5\On_Off.adb";
            String Path_name6 = @"Data\BaoThuc\Clock6\On_Off.adb";
            String Path_name7 = @"Data\BaoThuc\Clock7\On_Off.adb";
            String Path_name8 = @"Data\BaoThuc\Clock8\On_Off.adb";
            String Path_name9 = @"Data\BaoThuc\Clock9\On_Off.adb";
            String Path_name10 = @"Data\BaoThuc\Clock10\On_Off.adb";
            String Path_name11 = @"Data\BaoThuc\Clock11\On_Off.adb";
            String Path_name12 = @"Data\BaoThuc\Clock12\On_Off.adb";
            String Path_name13 = @"Data\BaoThuc\Clock13\On_Off.adb";
            String Path_name14 = @"Data\BaoThuc\Clock14\On_Off.adb";
            String Path_name15 = @"Data\BaoThuc\Clock15\On_Off.adb";
            String Path_name16 = @"Data\BaoThuc\Clock16\On_Off.adb";
            String Path_name17 = @"Data\BaoThuc\Clock17\On_Off.adb";
            String Path_name18 = @"Data\BaoThuc\Clock18\On_Off.adb";
            String Path_name19 = @"Data\BaoThuc\Clock19\On_Off.adb";
            String Path_name20 = @"Data\BaoThuc\Clock20\On_Off.adb";

            StreamReader sr1 = new StreamReader(Path_name);
            int name1 = Convert.ToInt32(sr1.ReadLine());
            if (name1 == 1) Clock1.Visible = true;
            sr1.Close();
            StreamReader sr2 = new StreamReader(Path_name2);
            int name2 = Convert.ToInt32(sr2.ReadLine());
            if (name2 == 1) Clock2.Visible = true;
            sr2.Close();
            StreamReader sr3 = new StreamReader(Path_name3);
            int name3 = Convert.ToInt32(sr3.ReadLine());
            if (name3 == 1) Clock3.Visible = true;
            sr3.Close();
            StreamReader sr4 = new StreamReader(Path_name4);
            int name4 = Convert.ToInt32(sr4.ReadLine());
            if (name4 == 1) Clock4.Visible = true;
            sr4.Close();
            StreamReader sr5 = new StreamReader(Path_name5);
            int name5 = Convert.ToInt32(sr5.ReadLine());
            if (name5 == 1) Clock5.Visible = true;
            sr5.Close();

            StreamReader sr6 = new StreamReader(Path_name6);
            int name6 = Convert.ToInt32(sr6.ReadLine());
            if (name6 == 1) Clock6.Visible = true;
            sr6.Close();

            StreamReader sr7 = new StreamReader(Path_name7);
            int name7 = Convert.ToInt32(sr7.ReadLine());
            if (name7 == 1) Clock7.Visible = true;
            sr7.Close();

            StreamReader sr8 = new StreamReader(Path_name8);
            int name8 = Convert.ToInt32(sr8.ReadLine());
            if (name8 == 1) Clock8.Visible = true;
            sr8.Close();

            StreamReader sr9 = new StreamReader(Path_name9);
            int name9 = Convert.ToInt32(sr9.ReadLine());
            if (name9 == 1) Clock9.Visible = true;
            sr9.Close();

            StreamReader sr10 = new StreamReader(Path_name10);
            int name10 = Convert.ToInt32(sr10.ReadLine());
            if (name10 == 1) Clock10.Visible = true;
            sr10.Close();

            StreamReader sr11 = new StreamReader(Path_name11);
            int name11 = Convert.ToInt32(sr11.ReadLine());
            if (name11 == 1) Clock11.Visible = true;
            sr11.Close();

            StreamReader sr12 = new StreamReader(Path_name12);
            int name12 = Convert.ToInt32(sr12.ReadLine());
            if (name12 == 1) Clock12.Visible = true;
            sr12.Close();

            StreamReader sr13 = new StreamReader(Path_name13);
            int name13 = Convert.ToInt32(sr13.ReadLine());
            if (name13 == 1) Clock13.Visible = true;
            sr13.Close();

            StreamReader sr14 = new StreamReader(Path_name14);
            int name14 = Convert.ToInt32(sr14.ReadLine());
            if (name14 == 1) Clock14.Visible = true;
            sr14.Close();

            StreamReader sr15 = new StreamReader(Path_name15);
            int name15 = Convert.ToInt32(sr15.ReadLine());
            if (name15 == 1) Clock15.Visible = true;
            sr15.Close();

            StreamReader sr16 = new StreamReader(Path_name16);
            int name16 = Convert.ToInt32(sr16.ReadLine());
            if (name16 == 1) Clock16.Visible = true;
            sr16.Close();

            StreamReader sr17 = new StreamReader(Path_name17);
            int name17 = Convert.ToInt32(sr17.ReadLine());
            if (name17 == 1) Clock17.Visible = true;
            sr17.Close();

            StreamReader sr18 = new StreamReader(Path_name18);
            int name18 = Convert.ToInt32(sr18.ReadLine());
            if (name18 == 1) Clock18.Visible = true;
            sr18.Close();

            StreamReader sr19 = new StreamReader(Path_name19);
            int name19 = Convert.ToInt32(sr19.ReadLine());
            if (name19 == 1) Clock19.Visible = true;
            sr19.Close();

            StreamReader sr20 = new StreamReader(Path_name20);
            int name20 = Convert.ToInt32(sr20.ReadLine());
            if (name20 == 1) Clock20.Visible = true;
            sr20.Close();
        }
        void LoadCacClock()
        {
            LoadClock1(); LoadClock2(); LoadClock3(); LoadClock4(); LoadClock5(); LoadClock6(); LoadClock7(); LoadClock8(); LoadClock9();
            LoadClock10(); LoadClock11(); LoadClock12(); LoadClock13(); LoadClock14(); LoadClock15(); LoadClock16(); LoadClock17(); LoadClock18();
            LoadClock19(); LoadClock20();
        }
        void FormLoad()
        {
            HideShowClock();
            tmLich.Tick += tmLich_Tick;
            tmLich.Start();
            LoadCacClock();
            TextRong.Tick += TextRong_Tick;
            TextRong.Start();
            panel9.Size = new Size(163, 23); //panel11.Location = new Point(983, 273);
            StreamWriter sr0 = new StreamWriter("data\\iconshow.adb");
            sr0.WriteLine("1");
            sr0.Close();

            tmShow.Tick += tmShow_Tick;
            tmShow.Start();

            tinhGioUI1.Visible = false;
            StreamReader sr = new StreamReader(path);
            String User = sr.ReadLine();
            String Pass = sr.ReadLine();
            sr.Close();

            StreamReader sr2 = new StreamReader(path2);
            String name1 = sr2.ReadLine(); sr2.Close();
            adminBtn.Text = name1;
            textBox3.Text = name1;
            textBox1.Text = User;
            textBox2.Text = Pass;
            StreamReader srAV = new StreamReader(pathAvatar);
            String pathAV = srAV.ReadLine();
            srAV.Close();
            try
            {
                Avatar.Image = new Bitmap(Application.StartupPath + "\\" + pathAV);
            }
            catch
            {

            }
            StreamReader srAV1 = new StreamReader(pathAvatarB);
            String pathAV1 = srAV1.ReadLine();
            srAV1.Close();
            try
            {
                pictureBox2.Image = new Bitmap(Application.StartupPath + "\\" + pathAV1);
            }
            catch
            {

            }


            SearchText.Size = new Size(0, SearchText.Height);// ẩn SearchText
            bamGio_UI1.SendToBack();
            henGioUI1.SendToBack();
            bamGio_UI1.Location = new Point(499, 91);
            henGioUI1.Location = new Point(499, 91);
            tinhGioUI1.Location = new Point(499, 91);
            month_UI1.Location = new Point(109, 192);
        }





        void tmShow_Tick(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("data\\uishow.adb"); String haha = sr.ReadLine(); sr.Close();
            if (haha == "0") this.Show();
            else this.Hide();

            StreamReader sr1 = new StreamReader("data\\uisizeW.adb");
            int W = Convert.ToInt32(sr1.ReadLine());
            sr1.Close();

            StreamReader sr2 = new StreamReader("data\\uisizeH.adb");
            int H = Convert.ToInt32(sr2.ReadLine());
            sr2.Close();

            this.Size = new Size(W, H);

        }

        #region Phần Design
        #region các biến
        Timer timeNow = new Timer() { Interval = 100 };//lấy thời gian hiện tại
        int FUllScreen = 0;//phóng to thu nhỏ form
        Timer timeSearch = new Timer() { Interval = 1 };// slide right SearchText
        int sizeSearchText = 0;//size width của SearchText để dùng trong timeSearch_Tick
        int SearchLeftOrRIght = 0;// Kiểm tra searchText có nên slide left or right
        String NgayVaThuTuan = DateTime.Now.ToString();// lấy thời gian hiện tại để thực hiện RightButton_Click or LeftButton_Click
        int LichAm = 0;// để Kiểm tra xem nên hiển thị âm hay lịch dương
        int Themngayam = 0;// Để thêm ngày âm hoặc giảm khi ấn rightbutton hoặc leftbutton (Themngayam+=1)
        int slide1 = 0; int slide2 = 0;//hỗ trợ việc menuSlide2_Tick như thay đổi hướng Slide
        Timer menuSlide2 = new Timer()
        {
            Interval = 10
        };
        #endregion
        #region các hàm
        void getTimeNow() // lấy thời gian hiện tại
        {
            timeNow.Tick += GetTime_tick;
            timeNow.Start();
            TimeNowLabel.Text = DateTime.Now.ToString("HH:mm").ToString();
            SecNowLabel.Text = DateTime.Now.ToString("ss").ToString();
            DateTime dt = Convert.ToDateTime(DateTime.Now);
            ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
            NgayVaThangLabel.Text = DateTime.Now.ToString("dd MMMM").ToString();
            DichNgayTrongTuan();
            menuSlide2.Tick += menuSlide2_Tick;
            menuSlide2.Start();

        }
        void DichNgayTrongTuan()
        {
            #region dịch ngày trong tuần
            DateTime dt = Convert.ToDateTime(DateTime.Now);
            if (dt.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
            else if (dt.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
            else if (dt.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
            else if (dt.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
            else if (dt.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
            else if (dt.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
            else if (dt.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
            #endregion
        }
        // ở hàm getTimeNow()

        #endregion
        #region Di Chuyển Form Mouse_Down, Mouse_Up,Mouse_Move
        Boolean DiChuyen; int x, y;
        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            DiChuyen = true;
            x = e.X;
            y = e.Y;
        }
        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            DiChuyen = false;
        }
        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (DiChuyen == true) this.SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);
        }
        #endregion
        #region các hàm 2
        private void Click_Thoat(object sender, EventArgs e)
        {
            //button1.Visible = true;
            //this.WindowState = FormWindowState.Normal;

            //int height = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(100, height - 70);
            //FUllScreen = 0;
            //panelMau.Visible = true;
            //panelMau2.Visible = true;
            WindowState = FormWindowState.Minimized;
        }

        private void Click_FullScreen(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 18, Screen.PrimaryScreen.Bounds.Height / 28);
            button1.Visible = false;
            if (FUllScreen == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                panelMau.Visible = false;
                panelMau2.Visible = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                panelMau.Visible = true;
                panelMau2.Visible = true;
                FUllScreen = -1;
            }
            FUllScreen++;
        }

        private void Search_Click(object sender, EventArgs e)//SearchText.Text (Click button icon search sẽ search)
        {
            goWeb();
        }

        void goWeb()
        {

            String url = "https://www.google.com.vn/search?dcr=0&source=hp&ei=r-KXWo3dEIXV0AT9w73QDw&q=" + SearchText.Text + "&oq=nam&gs_l=psy-ab.3..35i39k1j0i67k1j0i131k1j0i67k1j0i131k1l2j0i67k1l2j0j0i131k1.645.847.0.1065.4.3.0.0.0.0.177.177.0j1.1.0....0...1c.1.64.psy-ab..3.1.175.0...0.dbLvp9vImds";
            if (SearchText.Text.IndexOf("http") >= 0) url = SearchText.Text;
            Process.Start(url);
            SearchLeftOrRIght = 1;

            timeSearch.Tick += timeSearch_Tick;
            timeSearch.Start();


        }// truy cập trang web

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) goWeb();
        }

        private void SearchButton_MouseHover(object sender, EventArgs e)
        {
            SearchText.ReadOnly = false;
            timeSearch.Tick += timeSearch_Tick;
            timeSearch.Start();
            SearchLeftOrRIght = 0;
        }

        void timeSearch_Tick(object sender, EventArgs e)
        {
            if (SearchLeftOrRIght == 0)
            {
                if (sizeSearchText >= 90) { timeSearch.Stop(); sizeSearchText = 90; SearchText.Focus(); }
                SearchText.Size = new Size(sizeSearchText += 10, SearchText.Height);
            }
            else
            {
                if (sizeSearchText <= 0)
                {
                    timeSearch.Stop(); sizeSearchText = 0;
                    SearchText.ReadOnly = true;//thêm readonly vì để khi SearchText slide left nó k bị người dùng nhập vào nữa
                }
                SearchText.Size = new Size(sizeSearchText -= 3, SearchText.Height);
            }

        }

        private void button4_Click(object sender, EventArgs e)//RightButton_CLick
        {
            if (LichAm == 0)
            {
                DateTime dt = Convert.ToDateTime(NgayVaThuTuan);
                dt = dt.AddDays(1);
                NgayVaThuTuan = dt.ToString();
                NgayVaThangLabel.Text = dt.ToString("dd MMMM");
                timeNow.Stop();
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                TimeNowLabel.Visible = false;
                SecNowLabel.Visible = false;
                ngayNam.Text = dt.DayOfYear.ToString();
                #region dịch tháng trong năm
                int thangCheck = Convert.ToInt32(dt.ToString("MM"));
                if (thangCheck == 1) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Giêng";
                if (thangCheck == 2) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Hai";
                if (thangCheck == 3) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Ba";
                if (thangCheck == 4) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tư";
                if (thangCheck == 5) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Năm";
                if (thangCheck == 6) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Sáu";
                if (thangCheck == 7) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Bảy";
                if (thangCheck == 8) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tám";
                if (thangCheck == 9) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Chín";
                if (thangCheck == 10) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười";
                if (thangCheck == 11) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Một";
                if (thangCheck == 12) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Hai";
                #endregion
                #region dịch ngày trong tuần
                if (dt.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
                else if (dt.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
                else if (dt.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
                else if (dt.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
                else if (dt.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
                else if (dt.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
                else if (dt.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
                #endregion
            }
            else
            {
                   #region lấy ngày âm hiện tại
                DateTime dt = DateTime.Now;
                int ngay = dt.Day;
                int thang = dt.Month;
                int nam = dt.Year;

                int Intngay = convertSolar2Lunar_Ngay(ngay, thang, nam);
                int Intthang = convertSolar2Lunar_Thang(ngay, thang, nam);
                int Intnam = convertSolar2Lunar_Nam(ngay, thang, nam);
                NgayVaThuTuan = dt.ToString();
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                #region dịch tháng trong năm
                int thangCheck = Intthang;
                if (thangCheck == 1) NgayVaThangLabel.Text =  Intngay + " Tháng Giêng" + " (Âm)";
                if (thangCheck == 2) NgayVaThangLabel.Text =  Intngay + " Tháng Hai" + " (Âm)";
                if (thangCheck == 3) NgayVaThangLabel.Text =  Intngay + " Tháng Ba" + " (Âm)";
                if (thangCheck == 4) NgayVaThangLabel.Text =  Intngay + " Tháng Tư" + " (Âm)";
                if (thangCheck == 5) NgayVaThangLabel.Text =  Intngay + " Tháng Năm" + " (Âm)";
                if (thangCheck == 6) NgayVaThangLabel.Text =  Intngay + " Tháng Sáu" + " (Âm)";
                if (thangCheck == 7) NgayVaThangLabel.Text =  Intngay + " Tháng Bảy" + " (Âm)";
                if (thangCheck == 8) NgayVaThangLabel.Text =  Intngay + " Tháng Tám" + " (Âm)";
                if (thangCheck == 9) NgayVaThangLabel.Text =  Intngay + " Tháng Chín" + " (Âm)";
                if (thangCheck == 10) NgayVaThangLabel.Text = Intngay + " Tháng Mười" + " (Âm)";
                if (thangCheck == 11) NgayVaThangLabel.Text = Intngay + " Tháng Mười Một" + " (Âm)";
                if (thangCheck == 12) NgayVaThangLabel.Text = Intngay + " Tháng Mười Hai" + " (Âm)";
                #endregion
                #region dịch ngày trong tuần
                if (dt.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
                else if (dt.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
                else if (dt.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
                else if (dt.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
                else if (dt.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
                else if (dt.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
                else if (dt.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
                #endregion
                #endregion
                #region lấy ngày âm hiện tại
                DateTime dtNow = DateTime.Now;
               
                dt =new DateTime(Intnam,Intthang,Intngay);
                dt = dt.AddDays(Themngayam += 1);
                dtNow = dtNow.AddDays(Themngayam);
               NgayVaThuTuan = dt.ToString();
                NgayVaThangLabel.Text = dt.ToString("dd MMMM") + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                timeNow.Stop();
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                TimeNowLabel.Visible = false;
                SecNowLabel.Visible = false;
                #region dịch tháng trong năm
                thangCheck = Convert.ToInt32(dt.ToString("MM"));
                if (thangCheck == 1) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Giêng" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 2) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Hai" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 3) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Ba" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 4) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tư" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 5) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Năm" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 6) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Sáu" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 7) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Bảy" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 8) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tám" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 9) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Chín" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 10) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 11) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Một" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 12) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Hai" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                #endregion
                #region dịch ngày trong tuần
                if (dtNow.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
                else if (dtNow.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
                else if (dtNow.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
                else if (dtNow.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
                else if (dtNow.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
                else if (dtNow.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
                else if (dtNow.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
                #endregion
                #endregion
            }
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            if (LichAm == 0)
            {
                DateTime dt = Convert.ToDateTime(NgayVaThuTuan);
                dt = dt.AddDays(-1);
                NgayVaThuTuan = dt.ToString();
                NgayVaThangLabel.Text = dt.ToString("dd MMMM");
                timeNow.Stop();
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                TimeNowLabel.Visible = false;
                SecNowLabel.Visible = false;
                ngayNam.Text = dt.DayOfYear.ToString();
                #region dịch tháng trong năm
                int thangCheck = Convert.ToInt32(dt.ToString("MM"));
                if (thangCheck == 1) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Giêng";
                if (thangCheck == 2) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Hai";
                if (thangCheck == 3) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Ba";
                if (thangCheck == 4) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tư";
                if (thangCheck == 5) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Năm";
                if (thangCheck == 6) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Sáu";
                if (thangCheck == 7) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Bảy";
                if (thangCheck == 8) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tám";
                if (thangCheck == 9) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Chín";
                if (thangCheck == 10) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười";
                if (thangCheck == 11) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Một";
                if (thangCheck == 12) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Hai";
                #endregion
                #region dịch ngày trong tuần
                if (dt.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
                else if (dt.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
                else if (dt.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
                else if (dt.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
                else if (dt.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
                else if (dt.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
                else if (dt.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
                #endregion
            }
            else
            {

                #region lấy ngày âm hiện tại
                DateTime dt = DateTime.Now;
                int ngay = dt.Day;
                int thang = dt.Month;
                int nam = dt.Year;

                int Intngay = convertSolar2Lunar_Ngay(ngay, thang, nam);
                int Intthang = convertSolar2Lunar_Thang(ngay, thang, nam);
                int Intnam = convertSolar2Lunar_Nam(ngay, thang, nam);
                NgayVaThuTuan = dt.ToString();
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                #region dịch tháng trong năm
                int thangCheck = Intthang;
                if (thangCheck == 1) NgayVaThangLabel.Text = Intngay + " Tháng Giêng" + " (Âm)";
                if (thangCheck == 2) NgayVaThangLabel.Text = Intngay + " Tháng Hai" + " (Âm)";
                if (thangCheck == 3) NgayVaThangLabel.Text = Intngay + " Tháng Ba" + " (Âm)";
                if (thangCheck == 4) NgayVaThangLabel.Text = Intngay + " Tháng Tư" + " (Âm)";
                if (thangCheck == 5) NgayVaThangLabel.Text = Intngay + " Tháng Năm" + " (Âm)";
                if (thangCheck == 6) NgayVaThangLabel.Text = Intngay + " Tháng Sáu" + " (Âm)";
                if (thangCheck == 7) NgayVaThangLabel.Text = Intngay + " Tháng Bảy" + " (Âm)";
                if (thangCheck == 8) NgayVaThangLabel.Text = Intngay + " Tháng Tám" + " (Âm)";
                if (thangCheck == 9) NgayVaThangLabel.Text = Intngay + " Tháng Chín" + " (Âm)";
                if (thangCheck == 10) NgayVaThangLabel.Text = Intngay + " Tháng Mười" + " (Âm)";
                if (thangCheck == 11) NgayVaThangLabel.Text = Intngay + " Tháng Mười Một" + " (Âm)";
                if (thangCheck == 12) NgayVaThangLabel.Text = Intngay + " Tháng Mười Hai" + " (Âm)";
                #endregion
                #region dịch ngày trong tuần
                if (dt.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
                else if (dt.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
                else if (dt.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
                else if (dt.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
                else if (dt.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
                else if (dt.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
                else if (dt.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
                #endregion
                #endregion
                #region lấy ngày âm hiện tại
                DateTime dtNow = DateTime.Now;

                dt = new DateTime(Intnam, Intthang, Intngay);
                dt = dt.AddDays(Themngayam -= 1);
                dtNow = dtNow.AddDays(Themngayam);
                NgayVaThuTuan = dt.ToString();
                NgayVaThangLabel.Text = dt.ToString("dd MMMM") + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                timeNow.Stop();
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                TimeNowLabel.Visible = false;
                SecNowLabel.Visible = false;
                #region dịch tháng trong năm
                thangCheck = Convert.ToInt32(dt.ToString("MM"));
                if (thangCheck == 1) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Giêng" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 2) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Hai" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 3) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Ba" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 4) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tư" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 5) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Năm" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 6) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Sáu" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 7) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Bảy" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 8) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tám" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 9) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Chín" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 10) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 11) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Một" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                if (thangCheck == 12) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Hai" + " (Âm)" + "\r\n" + dtNow.ToString("dd/MM/yyy");
                #endregion
                #region dịch ngày trong tuần
                if (dtNow.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
                else if (dtNow.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
                else if (dtNow.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
                else if (dtNow.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
                else if (dtNow.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
                else if (dtNow.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
                else if (dtNow.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
                #endregion
                #endregion
            }
        }

        private void NowTimeReset_Click(object sender, EventArgs e)
        {
            if (LichAm == 0)
            {
                NgayVaThuTuan = DateTime.Now.ToString();
                timeNow.Start();
                TimeNowLabel.Visible = true;
                AmLichButton.Visible = true;
                SecNowLabel.Visible = true;
                #region lấy thời gian hiện tại
                TimeNowLabel.Text = DateTime.Now.ToString("HH:mm").ToString();
                SecNowLabel.Text = DateTime.Now.ToString("ss").ToString();
                DateTime dt = Convert.ToDateTime(DateTime.Now);
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                NgayVaThangLabel.Text = DateTime.Now.ToString("dd MMMM").ToString();
                DichNgayTrongTuan();
                #endregion
                #region dịch tháng trong năm
                int thangCheck = Convert.ToInt32(dt.ToString("MM"));
                if (thangCheck == 1) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Giêng";
                if (thangCheck == 2) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Hai";
                if (thangCheck == 3) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Ba";
                if (thangCheck == 4) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tư";
                if (thangCheck == 5) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Năm";
                if (thangCheck == 6) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Sáu";
                if (thangCheck == 7) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Bảy";
                if (thangCheck == 8) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tám";
                if (thangCheck == 9) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Chín";
                if (thangCheck == 10) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười";
                if (thangCheck == 11) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Một";
                if (thangCheck == 12) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Hai";
                #endregion
            }
            else
            {
                LichAm = 1;
                #region lấy ngày âm hiện tại
                DateTime dt = DateTime.Now;
                int ngay = dt.Day;
                int thang = dt.Month;
                int nam = dt.Year;

                int Intngay = convertSolar2Lunar_Ngay(ngay, thang, nam);
                int Intthang = convertSolar2Lunar_Thang(ngay, thang, nam);
                int Intnam = convertSolar2Lunar_Nam(ngay, thang, nam);
                NgayVaThuTuan = dt.ToString();
                ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
                #region dịch tháng trong năm
                int thangCheck = Intthang;
                if (thangCheck == 1) NgayVaThangLabel.Text = Intngay + " Tháng Giêng" + " (Âm)";
                if (thangCheck == 2) NgayVaThangLabel.Text = Intngay + " Tháng Hai" + " (Âm)";
                if (thangCheck == 3) NgayVaThangLabel.Text = Intngay + " Tháng Ba" + " (Âm)";
                if (thangCheck == 4) NgayVaThangLabel.Text = Intngay + " Tháng Tư" + " (Âm)";
                if (thangCheck == 5) NgayVaThangLabel.Text = Intngay + " Tháng Năm" + " (Âm)";
                if (thangCheck == 6) NgayVaThangLabel.Text = Intngay + " Tháng Sáu" + " (Âm)";
                if (thangCheck == 7) NgayVaThangLabel.Text = Intngay + " Tháng Bảy" + " (Âm)";
                if (thangCheck == 8) NgayVaThangLabel.Text = Intngay + " Tháng Tám" + " (Âm)";
                if (thangCheck == 9) NgayVaThangLabel.Text = Intngay + " Tháng Chín" + " (Âm)";
                if (thangCheck == 10) NgayVaThangLabel.Text = Intngay + " Tháng Mười" + " (Âm)";
                if (thangCheck == 11) NgayVaThangLabel.Text = Intngay + " Tháng Mười Một" + " (Âm)";
                if (thangCheck == 12) NgayVaThangLabel.Text = Intngay + " Tháng Mười Hai" + " (Âm)";
                #endregion
                #region dịch ngày trong tuần
                if (dt.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
                else if (dt.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
                else if (dt.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
                else if (dt.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
                else if (dt.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
                else if (dt.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
                else if (dt.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
                #endregion
                #endregion

                timeNow.Start();


            }
        }

        private void AmLichButton_Click(object sender, EventArgs e)//Click để chuyến sang lịch âm
        {
            LichAm = 1;
            #region lấy ngày âm hiện tại
            DateTime dt = DateTime.Now;
            int ngay = dt.Day;
            int thang = dt.Month;
            int nam = dt.Year;

            int Intngay = convertSolar2Lunar_Ngay(ngay, thang, nam);
            int Intthang = convertSolar2Lunar_Thang(ngay, thang, nam);
            int Intnam = convertSolar2Lunar_Nam(ngay, thang, nam);
            NgayVaThuTuan = dt.ToString();
            ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
            #region dịch tháng trong năm
            int thangCheck = Intthang;
            if (thangCheck == 1) NgayVaThangLabel.Text = Intngay + " Tháng Giêng" + " (Âm)";
            if (thangCheck == 2) NgayVaThangLabel.Text = Intngay + " Tháng Hai" + " (Âm)";
            if (thangCheck == 3) NgayVaThangLabel.Text = Intngay + " Tháng Ba" + " (Âm)";
            if (thangCheck == 4) NgayVaThangLabel.Text = Intngay + " Tháng Tư" + " (Âm)";
            if (thangCheck == 5) NgayVaThangLabel.Text = Intngay + " Tháng Năm" + " (Âm)";
            if (thangCheck == 6) NgayVaThangLabel.Text = Intngay + " Tháng Sáu" + " (Âm)";
            if (thangCheck == 7) NgayVaThangLabel.Text = Intngay + " Tháng Bảy" + " (Âm)";
            if (thangCheck == 8) NgayVaThangLabel.Text = Intngay + " Tháng Tám" + " (Âm)";
            if (thangCheck == 9) NgayVaThangLabel.Text = Intngay + " Tháng Chín" + " (Âm)";
            if (thangCheck == 10) NgayVaThangLabel.Text = Intngay + " Tháng Mười" + " (Âm)";
            if (thangCheck == 11) NgayVaThangLabel.Text = Intngay + " Tháng Mười Một" + " (Âm)";
            if (thangCheck == 12) NgayVaThangLabel.Text = Intngay + " Tháng Mười Hai" + " (Âm)";
            #endregion
            #region dịch ngày trong tuần
            if (dt.DayOfWeek == DayOfWeek.Monday) ThuTrongTuanLabel.Text = "Thứ Hai";
            else if (dt.DayOfWeek == DayOfWeek.Tuesday) ThuTrongTuanLabel.Text = "Thứ Ba";
            else if (dt.DayOfWeek == DayOfWeek.Wednesday) ThuTrongTuanLabel.Text = "Thứ Tư";
            else if (dt.DayOfWeek == DayOfWeek.Thursday) ThuTrongTuanLabel.Text = "Thứ Năm";
            else if (dt.DayOfWeek == DayOfWeek.Friday) ThuTrongTuanLabel.Text = "Thứ Sáu";
            else if (dt.DayOfWeek == DayOfWeek.Saturday) ThuTrongTuanLabel.Text = "Thứ Bảy";
            else if (dt.DayOfWeek == DayOfWeek.Sunday) ThuTrongTuanLabel.Text = "Chủ Nhật";
            #endregion
            #endregion

            timeNow.Start();
           
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

        private void DuongLichButton_Click(object sender, EventArgs e)
        {
            LichAm = 0;
            DuongLichButton.Visible = false;
            Themngayam = 0;
            NgayVaThuTuan = DateTime.Now.ToString();
            timeNow.Start();
            TimeNowLabel.Visible = true;
            AmLichButton.Visible = true;
            SecNowLabel.Visible = true;
            ngayNam.Visible = true;
            #region lấy thời gian hiện tại
            TimeNowLabel.Text = DateTime.Now.ToString("HH:mm").ToString();
            SecNowLabel.Text = DateTime.Now.ToString("ss").ToString();
            DateTime dt = Convert.ToDateTime(DateTime.Now);
            ThuTrongTuanLabel.Text = dt.DayOfWeek.ToString();
            NgayVaThangLabel.Text = DateTime.Now.ToString("dd MMMM").ToString();
            DichNgayTrongTuan();
            #endregion
            #region dịch tháng trong năm
            int thangCheck = Convert.ToInt32(dt.ToString("MM"));
            if (thangCheck == 1) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Giêng";
            if (thangCheck == 2) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Hai";
            if (thangCheck == 3) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Ba";
            if (thangCheck == 4) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tư";
            if (thangCheck == 5) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Năm";
            if (thangCheck == 6) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Sáu";
            if (thangCheck == 7) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Bảy";
            if (thangCheck == 8) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Tám";
            if (thangCheck == 9) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Chín";
            if (thangCheck == 10) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười";
            if (thangCheck == 11) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Một";
            if (thangCheck == 12) NgayVaThangLabel.Text = dt.ToString("dd") + " Tháng Mười Hai";
            #endregion

        }
        #endregion



        void menuSlide2_Tick(object sender, EventArgs e)
        {

            if (BaoThucButton.ForeColor == Color.Black)
            {
                Point a = new Point(30, 40);
                if (SlideBlue.Left >= a.X)
                {
                    SlideBlue.Left -= 10;
                }
                else
                {
                    menuSlide2.Stop();
                    slide1 = 0; slide2 = 0;
                }
            }
            else if (TinhGioButton.ForeColor == Color.Black)
            {
                Point a = new Point(120, 39);
                if (slide1 == 0)
                {
                    if (SlideBlue.Left <= a.X)
                    {
                        SlideBlue.Left += 10;

                    }
                    else
                    {
                        menuSlide2.Stop();
                    }
                }
                Point a1 = new Point(130, 39);
                if (slide1 == 1)
                    if (SlideBlue.Left >= a1.X)
                    {
                        SlideBlue.Left -= 10;

                    }
                slide2 = 0;


            }
            else if (BamGioButton.ForeColor == Color.Black)
            {
                Point a = new Point(227, 39);
                if (slide2 == 0)
                {
                    if (SlideBlue.Left <= a.X)
                    {
                        SlideBlue.Left += 10;
                    }

                    else
                    {
                        menuSlide2.Stop(); slide1 = 1;
                    }
                }
                Point a1 = new Point(240, 39);
                if (slide2 == 1)
                {
                    if (SlideBlue.Left >= a1.X)
                    {
                        SlideBlue.Left -= 10;

                    }

                }
            }
            else if (HenGioButton.ForeColor == Color.Black)
            {
                Point a = new Point(340, 38);
                if (SlideBlue.Left <= a.X)
                {
                    SlideBlue.Left += 10;
                }
                else
                {
                    menuSlide2.Stop();
                    slide2 = 1;
                    slide1 = 1;
                }
            }


        }// slidePanel màu xanh dương sẽ trượt trên menu khi click các button trên menu


        private void TinhGioButton_Click(object sender, EventArgs e)// Click tính giờ menu button
        {
            TinhGioButton.ForeColor = Color.Black; 
            BaoThucButton.ForeColor = Color.FromArgb(171, 169, 167);
            HenGioButton.ForeColor = Color.FromArgb(171, 169, 167);
            BamGioButton.ForeColor = Color.FromArgb(171, 169, 167);
            tinhGioUI1.Visible = true;
            tinhGioUI1.BringToFront();
            menuSlide2.Start();
            henGioUI1.Visible = false;
            panelMau.BackColor = Color.FromArgb(70, 82, 157);
            panelMau2.BackColor = Color.FromArgb(77, 89, 161);
            panel11.Visible = false;
            panel12.Visible = false;
        }

        private void BaoThucButton_Click(object sender, EventArgs e)//Click báo thức menu
        {

            tinhGioUI1.Visible = false; 
            BaoThucButton.ForeColor = Color.Black;
            HenGioButton.ForeColor = Color.FromArgb(171, 169, 167);
            TinhGioButton.ForeColor = Color.FromArgb(171, 169, 167);
            BamGioButton.ForeColor = Color.FromArgb(171, 169, 167);
            menuSlide2.Start();
            slide1 = 1;
            flowLayoutPanel1.BringToFront();
            henGioUI1.Visible = false;
            panel11.Visible = true;
            panelMau.BackColor = Color.FromArgb(239, 238, 236); panelMau2.BackColor = Color.FromArgb(239, 238, 236);
            if (iu < 0) ;
            else
                panel12.Visible = true;
        }


        private void BamGioButton_Click(object sender, EventArgs e)
        {
            BaoThucButton.ForeColor = Color.FromArgb(171, 169, 167);
            HenGioButton.ForeColor = Color.FromArgb(171, 169, 167);
            TinhGioButton.ForeColor = Color.FromArgb(171, 169, 167);
            BamGioButton.ForeColor = Color.Black;
            menuSlide2.Start();
            bamGio_UI1.BringToFront(); tinhGioUI1.Visible = false;
            henGioUI1.Visible = false;
            panelMau.BackColor = Color.FromArgb(239, 238, 236); panelMau2.BackColor = Color.FromArgb(239, 238, 236);
            panel12.Visible = false;
            panel11.Visible = false;
        }

        private void HenGioButton_Click(object sender, EventArgs e)
        {
            tinhGioUI1.Visible = false; 
            BaoThucButton.ForeColor = Color.FromArgb(171, 169, 167);
            HenGioButton.ForeColor = Color.Black;
            TinhGioButton.ForeColor = Color.FromArgb(171, 169, 167);
            BamGioButton.ForeColor = Color.FromArgb(171, 169, 167);
            menuSlide2.Start();
            henGioUI1.BringToFront(); henGioUI1.Visible = true;
            panelMau.BackColor = Color.FromArgb(70, 82, 157);
            panelMau2.BackColor = Color.FromArgb(77, 89, 161);
            panel11.Visible = false;
            panel12.Visible = false;
        }
        #endregion

        private void Click_ThoatX(object sender, EventArgs e)
        {
            panel32.Visible = false;

            StreamWriter sr = new StreamWriter("data\\iconshow.adb");
            sr.WriteLine("0");
            sr.Close();

            StreamWriter sr1 = new StreamWriter("data\\uishow.adb");
            sr1.WriteLine("1");
            sr1.Close();



            DangNhap dn = new DangNhap();
            dn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 18, Screen.PrimaryScreen.Bounds.Height / 28);
        }

        private void TuanButton_Click(object sender, EventArgs e)
        {
            TuanButton.ForeColor = Color.FromArgb(185, 189, 217);
            NgayButton.ForeColor = Color.FromArgb(126, 134, 186);
            ThangButton.ForeColor = Color.FromArgb(126, 134, 186);
            WeekUI wek1 = new WeekUI();
            panel1.Controls.Add(wek1);
            wek1.Location = new Point(114, 199);
            wek1.BringToFront();
            month_UI1.SendToBack();

        }

        private void NgayButton_Click(object sender, EventArgs e)
        {
            TuanButton.ForeColor = Color.FromArgb(126, 134, 186);
            NgayButton.ForeColor = Color.FromArgb(185, 189, 217);
            ThangButton.ForeColor = Color.FromArgb(126, 134, 186);
            panel30.BringToFront();
            month_UI1.SendToBack();
        }

        private void ThangButton_Click(object sender, EventArgs e)
        {
            TuanButton.ForeColor = Color.FromArgb(126, 134, 186);
            NgayButton.ForeColor = Color.FromArgb(126, 134, 186);
            ThangButton.ForeColor = Color.FromArgb(185, 189, 217);
            month_UI1.BringToFront();
            month_UI1.Visible = true;
        }

        int CLickAdmin = 0; int passCheck;
        private void adminBtn_Click(object sender, EventArgs e)
        {
            LoadCheckLogin();
            if (passCheck == 1)
            {
                if (CLickAdmin == 0)
                {
                    panel32.Visible = true;
                    StreamReader sr = new StreamReader(path);
                    StreamReader sr2 = new StreamReader(path2);
                    String name = sr2.ReadLine(); sr2.Close();
                    adminBtn.Text = name;
                    String User = sr.ReadLine();
                    String Pass = sr.ReadLine();
                    sr.Close();

                    textBox1.Text = User;
                    textBox2.Text = Pass;

                    StreamReader srr = new StreamReader("data\\user\\name.adb");
                    textBox3.Text = srr.ReadLine();
                    srr.Close();

                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    label21.Visible = true;
                    label4.Visible = true;
                    checkBox1.Visible = true;

                }
                else if (CLickAdmin == 1)
                {
                    panel32.Visible = false;
                    CLickAdmin = -1;
                }
                CLickAdmin++;
            }
            else
            {
                if (CLickAdmin == 0)
                {
                    panel32.Visible = true;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    label21.Visible = false;
                    label4.Visible = false;
                    checkBox1.Visible = false;
                }
                else if (CLickAdmin == 1)
                {
                    panel32.Visible = false;
                    CLickAdmin = -1;
                }
                CLickAdmin++;
            }

        }

        private void DoiPassBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("User và mật khẩu không được bỏ trống");
                StreamReader sr = new StreamReader(path);
                StreamReader sr2 = new StreamReader(path2);
                String name = sr2.ReadLine(); sr2.Close();
                adminBtn.Text = name;
                String User = sr.ReadLine();
                String Pass = sr.ReadLine();
                sr.Close();

                textBox1.Text = User;
                textBox2.Text = Pass;
            }
            else
            {
                panel32.Visible = false; CLickAdmin = 0;
                StreamWriter sw1 = new StreamWriter(path2);
                sw1.WriteLine(textBox3.Text);
                sw1.Close();
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(textBox1.Text);
                sw.WriteLine(textBox2.Text);
                sw.Close();
                adminBtn.Text = textBox3.Text;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox2.UseSystemPasswordChar = false; else textBox2.UseSystemPasswordChar = true;
        }

        private void Avatar_MouseHover(object sender, EventArgs e)
        {
            panel10.Visible = true;

        }

        private void Avatar_MouseLeave(object sender, EventArgs e)
        {
            // panel10.Visible = false;
            //    CLickAdmin = 0;
        }

        private void panel10_MouseLeave(object sender, EventArgs e)
        {
            panel10.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = Directory.GetCurrentDirectory() + "\\data\\baothuc\\anhbaothuc";
            DialogResult d = f.ShowDialog();
            if (d == DialogResult.OK)
            {
                String file = f.FileName;
                String file1 = Path.GetFileName(f.FileName);
                String pathImage1 = pathImage + "\\" + file1;
                try
                {
                    File.Copy(file, pathImage1);
                }
                catch { }

                StreamWriter sr = new StreamWriter(pathAvatar);
                sr.WriteLine(pathImage1);
                sr.Close();
                try
                {
                    Avatar.Image = new Bitmap(Application.StartupPath + "\\" + pathImage1);
                }
                catch
                {

                }

            };
        }


        private void panel7_Click(object sender, EventArgs e)// thay đổi ảnh bìa
        {
            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = Directory.GetCurrentDirectory() + "\\data\\baothuc\\anhbaothuc";
            DialogResult d = f.ShowDialog();
            if (d == DialogResult.OK)
            {
                String file = f.FileName;
                String file1 = Path.GetFileName(f.FileName);
                String pathImage1 = pathImage + "\\" + file1;
                try
                {
                    File.Copy(file, pathImage1);
                }
                catch { }

                StreamWriter sr = new StreamWriter(pathAvatarB);
                sr.WriteLine(pathImage1);
                sr.Close();
                try
                {
                    pictureBox2.Image = new Bitmap(Application.StartupPath + "\\" + pathImage1);
                }
                catch
                {

                }

            };
        }

        private void DoiPassBtn_Click1(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter(pathAvatarB);
            sr.WriteLine("MacDinh");
            sr.Close();

            try
            {
                pictureBox2.Image = null;
            }
            catch
            {

            }

            StreamWriter sr1 = new StreamWriter(pathAvatar);
            sr1.WriteLine(@"data\user\anh\macdinh.jpg");
            sr1.Close();
            StreamReader s1r1 = new StreamReader(pathAvatar);
            String iii = s1r1.ReadLine();
            s1r1.Close();
            try
            {
                Avatar.Image = new Bitmap(Application.StartupPath + "\\" + iii);
            }
            catch
            {

            }
        }
        // check bật khởi đôg cug windows                                                     
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                StreamWriter sr = new StreamWriter(@"data\Windows.adb");
                sr.WriteLine("1"); sr.Close();
                KhoiDongCungWinDows(true);
            }
            else
            {
                StreamWriter sr = new StreamWriter(@"data\Windows.adb");
                sr.WriteLine("0"); sr.Close();
                KhoiDongCungWinDows(false);
            }
        }
        public static void KhoiDongCungWinDows(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (isChecked)
            {
                // Đăng ký stratup cùng Windows
                registryKey.SetValue("HelloClock", Directory.GetCurrentDirectory() + "\\HelloClock.bat");
            }
            else
            {
                // Hủy đăng ký
                try
                {
                    registryKey.DeleteValue("HelloClock");
                }
                catch { }
            }
        }

        private void Facebtn_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/hoainam.pham.94695");
        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }



        //Test
        int iu = -2;
        private void button10_Click(object sender, EventArgs e)
        {
            ButtonAdd();
        }
        void ButtonAdd()
        {
            stopSou();
            RongPanel.Visible = false;
            if (iu == 21)
            {
                Clock1.Visible = false;
                Clock2.Visible = false;
                Clock3.Visible = false;
                Clock4.Visible = false;
                Clock5.Visible = false;
                Clock6.Visible = false;
                Clock7.Visible = false;
                Clock8.Visible = false;
                Clock9.Visible = false;
                Clock10.Visible = false;
                Clock11.Visible = false;
                Clock12.Visible = false;
                Clock13.Visible = false;
                Clock14.Visible = false;
                Clock15.Visible = false;
                Clock16.Visible = false;
                Clock17.Visible = false;
                Clock18.Visible = false;
                Clock19.Visible = false;
                Clock20.Visible = false;
                for (int i = 1; i < u; i++)
                {
                    StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\ON_OFF.adb");
                    sw.WriteLine("0");
                    sw.Close();


                }
                iu = -2;
                Clock1.BackColor = Color.White;
                Clock1.Visible = true;

                return;

            }
            if (Clock1.Visible == false) Clock1.Visible = true;
            else if (Clock2.Visible == false) Clock2.Visible = true;
            else if (Clock3.Visible == false) Clock3.Visible = true;
            else if (Clock4.Visible == false) Clock4.Visible = true;
            else if (Clock5.Visible == false) Clock5.Visible = true;
            else if (Clock6.Visible == false) Clock6.Visible = true;
            else if (Clock7.Visible == false) Clock7.Visible = true;
            else if (Clock8.Visible == false) Clock8.Visible = true;
            else if (Clock9.Visible == false) Clock9.Visible = true;
            else if (Clock10.Visible == false) Clock10.Visible = true;
            else if (Clock11.Visible == false) Clock11.Visible = true;
            else if (Clock12.Visible == false) Clock12.Visible = true;
            else if (Clock13.Visible == false) Clock13.Visible = true;
            else if (Clock14.Visible == false) Clock14.Visible = true;
            else if (Clock15.Visible == false) Clock15.Visible = true;
            else if (Clock16.Visible == false) Clock16.Visible = true;
            else if (Clock17.Visible == false) Clock17.Visible = true;
            else if (Clock18.Visible == false) Clock18.Visible = true;
            else if (Clock19.Visible == false) Clock19.Visible = true;
            else if (Clock20.Visible == false) Clock20.Visible = true;
            panel12.Visible = false;
            iu = -2;
            Clock2.BackColor = Color.White;
            Clock1.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
        }
        private void Clock1_Click(object sender, EventArgs e)
        {
            iu = 1;
            Clock1.BackColor = Color.FromArgb(70, 82, 157);
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            CaiDatDate();
        }

        private void Clock2_Click(object sender, EventArgs e)
        {
            iu = 2;
            Clock2.BackColor = Color.FromArgb(70, 82, 157);
            Clock1.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
        }

        private void Clock3_Click(object sender, EventArgs e)
        {
            iu = 3;
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.FromArgb(70, 82, 157);
            Clock4.BackColor = Color.White;
        }

        private void Clock4_Click(object sender, EventArgs e)
        {
            iu = 4;
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.FromArgb(70, 82, 157);
        }
        void LoadNoFor()
        {
            int i = iu;
            #region reset moi thu
            StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\ON_OFF.adb");
            sw.WriteLine("0");
            sw.Close();

            StreamWriter sw1 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\hou.adb");
            sw1.WriteLine("0");
            sw1.Close();
            StreamWriter sw2 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\min.adb");
            sw2.WriteLine("0");
            sw2.Close();
            StreamWriter sw3 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\sec.adb");
            sw3.WriteLine("0");
            sw3.Close();
            StreamWriter sw4 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\chicheck.adb");
            sw4.WriteLine("1");
            sw4.Close();
            StreamWriter sw5 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\nhacngay.adb");
            sw5.WriteLine("0");
            sw5.Close();
            StreamWriter sw6 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\nhacthoi.adb");
            sw6.WriteLine("0");
            sw6.Close();
            StreamWriter sw7 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\anhpath.adb");
            sw7.WriteLine(@"Data\BaoThuc\Clock2\AnhBaoThuc\MacDinh.png");
            sw7.Close();

            StreamWriter sw8 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
            sw8.WriteLine(@"Data\BaoThuc\chuongbaothuc\MusicBox.wav");
            sw8.Close();
            StreamWriter sw9 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\VongLap.adb");
            sw9.WriteLine("0");
            sw9.Close();
            #endregion
            #region nameRename
            String so = i.ToString();
            if (so == "1") so = so.Replace("1", "một");
            if (so == "2") so = so.Replace("2", "hai");
            if (so == "3") so = so.Replace("3", "ba");
            if (so == "4") so = so.Replace("4", "bốn");
            if (so == "5") so = so.Replace("5", "năm");
            if (so == "6") so = so.Replace("6", "sáu");
            if (so == "7") so = so.Replace("7", "bảy");
            if (so == "8") so = so.Replace("8", "tám");
            if (so == "9") so = so.Replace("9", "chín");
            if (so == "10") so = so.Replace("10", "mười");
            if (so == "11") so = so.Replace("11", "mười một");
            if (so == "12") so = so.Replace("12", "mười hai");
            if (so == "13") so = so.Replace("13", "mười ba");
            if (so == "14") so = so.Replace("14", "mười bốn");
            if (so == "15") so = so.Replace("15", "mười năm");
            if (so == "16") so = so.Replace("16", "mười sáu");
            if (so == "17") so = so.Replace("17", "mười bảy");
            if (so == "18") so = so.Replace("18", "mười tám");
            if (so == "19") so = so.Replace("19", "mười chín");
            if (so == "20") so = so.Replace("20", "hai mươi");
            StreamWriter swName = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\TenBaoThuc.adb");
            swName.WriteLine("Báo thức " + so); swName.Close();
            LoadResetIU();
            #endregion
        }
        void LoadFor()
        {
            for (int i = 1; i < u; i++)
            {
                #region reset moi thu
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();

                StreamWriter sw1 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\hou.adb");
                sw1.WriteLine("0");
                sw1.Close();
                StreamWriter sw2 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\min.adb");
                sw2.WriteLine("0");
                sw2.Close();
                StreamWriter sw3 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\sec.adb");
                sw3.WriteLine("0");
                sw3.Close();
                StreamWriter sw4 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\chicheck.adb");
                sw4.WriteLine("1");
                sw4.Close(); tmCLock1.Start();
                StreamWriter sw5 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\nhacngay.adb");
                sw5.WriteLine("0");
                sw5.Close();
                StreamWriter sw6 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\nhacthoi.adb");
                sw6.WriteLine("0");
                sw6.Close();
                StreamWriter sw7 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\anhpath.adb");
                sw7.WriteLine(@"Data\BaoThuc\AnhBaoThuc\MacDinh.png");
                sw7.Close();

                StreamWriter sw8 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                sw8.WriteLine(@"Data\BaoThuc\chuongbaothuc\MusicBox.wav");
                sw8.Close();
                StreamWriter sw9 = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\VongLap.adb");
                sw9.WriteLine("0");
                sw9.Close();

                #endregion
                #region nameRename
                String so = i.ToString();
                if (so == "1") so = so.Replace("1", "một");
                if (so == "2") so = so.Replace("2", "hai");
                if (so == "3") so = so.Replace("3", "ba");
                if (so == "4") so = so.Replace("4", "bốn");
                if (so == "5") so = so.Replace("5", "năm");
                if (so == "6") so = so.Replace("6", "sáu");
                if (so == "7") so = so.Replace("7", "bảy");
                if (so == "8") so = so.Replace("8", "tám");
                if (so == "9") so = so.Replace("9", "chín");
                if (so == "10") so = so.Replace("10", "mười");
                if (so == "11") so = so.Replace("11", "mười một");
                if (so == "12") so = so.Replace("12", "mười hai");
                if (so == "13") so = so.Replace("13", "mười ba");
                if (so == "14") so = so.Replace("14", "mười bốn");
                if (so == "15") so = so.Replace("15", "mười năm");
                if (so == "16") so = so.Replace("16", "mười sáu");
                if (so == "17") so = so.Replace("17", "mười bảy");
                if (so == "18") so = so.Replace("18", "mười tám");
                if (so == "19") so = so.Replace("19", "mười chín");
                if (so == "20") so = so.Replace("20", "hai mươi");
                StreamWriter swName = new StreamWriter(@"Data\BaoThuc\Clock" + i + "\\TenBaoThuc.adb");
                swName.WriteLine("Báo thức " + so); swName.Close();
                #endregion
            }
            //LoadCacClock();
            LoadTime();
        }
        void LoadTime()
        {
            tmCLock1.Start();
            tmCLock2.Start();
            tmCLock3.Start();
            tmCLock4.Start();
            tmCLock5.Start();
            tmCLock6.Start();
            tmCLock7.Start();
            tmCLock8.Start();
            tmCLock9.Start();
            tmCLock10.Start();
            tmCLock11.Start();
            tmCLock12.Start();
            tmCLock13.Start();
            tmCLock14.Start();
            tmCLock15.Start();
            tmCLock16.Start();
            tmCLock17.Start();
            tmCLock18.Start();
            tmCLock19.Start();
            tmCLock20.Start();
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            ButtonDel();
        }
        void ButtonDel()
        {
            stopSou();
            if (iu == 21)
            {
                Clock1.Visible = false;
                Clock2.Visible = false;
                Clock3.Visible = false;
                Clock4.Visible = false;
                Clock5.Visible = false;
                Clock6.Visible = false;
                Clock7.Visible = false;
                Clock8.Visible = false;
                Clock9.Visible = false;
                Clock10.Visible = false;
                Clock11.Visible = false;
                Clock12.Visible = false;
                Clock13.Visible = false;
                Clock14.Visible = false;
                Clock15.Visible = false;
                Clock16.Visible = false;
                Clock17.Visible = false;
                Clock18.Visible = false;
                Clock19.Visible = false;
                Clock20.Visible = false;
                LoadFor();
                iu = -2;
                return;

            }
            Clock2.BackColor = Color.White;
            Clock1.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;

            if (iu == 1)
            {
                Clock1.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock1\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 2)
            {
                Clock2.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock2\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 3)
            {
                Clock3.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock3\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 4)
            {
                Clock4.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock4\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 5)
            {
                Clock5.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock5\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 6)
            {
                Clock6.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock6\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 7)
            {
                Clock7.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock7\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 8)
            {
                Clock8.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock8\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 9)
            {
                Clock9.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock9\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 10)
            {
                Clock10.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock10\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 11)
            {
                Clock11.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock11\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 12)
            {
                Clock12.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock12\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 13)
            {
                Clock13.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock13\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 14)
            {
                Clock14.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock14\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 15)
            {
                Clock15.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock15\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 16)
            {
                Clock16.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock16\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 17)
            {
                Clock17.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock17\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 18)
            {
                Clock18.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock18\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 19)
            {
                Clock19.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock19\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu == 20)
            {
                Clock20.Visible = false;
                StreamWriter sw = new StreamWriter(@"Data\BaoThuc\Clock20\ON_OFF.adb");
                sw.WriteLine("0");
                sw.Close();
            }
            if (iu < 1 || iu > u) ; else LoadNoFor();
            panel12.Visible = false;
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        int ngaySetting = 0;
        private void button14_Click(object sender, EventArgs e)
        {
            button14.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            if (ngaySetting == 0)
            {

                panel9.Size = new Size(163, 94);
                panel9.BackColor = Color.WhiteSmoke;
                ngaySetting = 1; //panel11.Location = new Point(984, 331);
            }
            else
            {

                panel9.Size = new Size(163, 23); //panel11.Location = new Point(983, 273);

                ngaySetting = 0;
            }
        }


        // nhắc tôi vào ngày
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            ThoiCheck.Enabled = true;
            DateText.Enabled = true;
            YearText.Enabled = true;
            MonthText.Enabled = true;
            if (NgayCheck.Checked == false) { ThoiCheck.Checked = false; ThoiCheck.Enabled = false; DateText.Enabled = false; YearText.Enabled = false; MonthText.Enabled = false; }
        }
        // Chỉ một lần checked
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (ChiCheck.Checked == true)
            {
                HaiCheck.Checked = false;
                TuCheck.Checked = false;
                BaCheck.Checked = false;
                NamCheck.Checked = false;
                SauCheck.Checked = false;
                BayCheck.Checked = false;
                TamCheck.Checked = false;
            }
            if (HaiCheck.Checked == false &&
                TuCheck.Checked == false &&
                BaCheck.Checked == false &&
                NamCheck.Checked == false &&
                SauCheck.Checked == false &&
                BayCheck.Checked == false &&
                TamCheck.Checked == false) ChiCheck.Checked = true;
        }

        private void BaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (
            HaiCheck.Checked == true ||
            TuCheck.Checked == true ||
            BaCheck.Checked == true ||
            NamCheck.Checked == true ||
            SauCheck.Checked == true ||
            BayCheck.Checked == true ||
            TamCheck.Checked == true) { ChiCheck.Checked = false; }
            else ChiCheck.Checked = true;
        }

        private void Clock01_Load(object sender, EventArgs e)
        {

        }

        private void Clock01_Click(object sender, EventArgs e)
        {
            iu = 1;
            Clock1.BackColor = Color.FromArgb(70, 82, 157);
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            CaiDatDate();
        }


        void CaiDatDate()
        {
            panel12.Visible = true;
            // lấy dữ liệu
            String hou = (@"Data\BaoThuc\Clock" + iu + "\\hou.adb");
            String min = (@"Data\BaoThuc\Clock" + iu + "\\min.adb");
            String sec = (@"Data\BaoThuc\Clock" + iu + "\\sec.adb");
            String thu2Read = (@"Data\BaoThuc\Clock" + iu + "\\thu2.adb");
            String thu3Read = (@"Data\BaoThuc\Clock" + iu + "\\thu3.adb");
            String thu4Read = (@"Data\BaoThuc\Clock" + iu + "\\thu4.adb");
            String thu5Read = (@"Data\BaoThuc\Clock" + iu + "\\thu5.adb");
            String thu6Read = (@"Data\BaoThuc\Clock" + iu + "\\thu6.adb");
            String thu7Read = (@"Data\BaoThuc\Clock" + iu + "\\thu7.adb");
            String thu8Read = (@"Data\BaoThuc\Clock" + iu + "\\thu8.adb");
            String ChiCheck_Read = (@"Data\BaoThuc\Clock" + iu + "\\chicheck.adb");
            String TenBaoThucRead = (@"Data\BaoThuc\Clock" + iu + "\\TenBaoThuc.adb");
            String NhacNgayRead = (@"Data\BaoThuc\Clock" + iu + "\\nhacngay.adb");
            String NhacThoiRead = (@"Data\BaoThuc\Clock" + iu + "\\nhacthoi.adb");
            String AnhPathRead = (@"Data\BaoThuc\Clock" + iu + "\\AnhPath.adb");
            String ChuongPathRead = (@"Data\BaoThuc\Clock" + iu + "\\chuongPath.adb");
            String dateRead = (@"Data\BaoThuc\Clock" + iu + "\\date.adb");
            String monthRead = (@"Data\BaoThuc\Clock" + iu + "\\month.adb");
            String yearRead = (@"Data\BaoThuc\Clock" + iu + "\\year.adb");

            StreamReader srDate = new StreamReader(dateRead);
            String dateText = srDate.ReadLine();
            srDate.Close();
            StreamReader srMonth = new StreamReader(monthRead);
            String monthText = srMonth.ReadLine();
            srMonth.Close();
            StreamReader srYear = new StreamReader(yearRead);
            String yearText = srYear.ReadLine();
            srYear.Close();

            StreamReader srChuong = new StreamReader(ChuongPathRead);
            String ChuongPath = srChuong.ReadLine();
            srChuong.Close();

            StreamReader srAnh = new StreamReader(AnhPathRead);
            String AnhPath = srAnh.ReadLine();
            srAnh.Close();
            StreamReader srNhacNgay = new StreamReader(NhacNgayRead);
            int NhacNgay = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();

            StreamReader srNhacThoi = new StreamReader(NhacThoiRead);
            int NhacThoi = Convert.ToInt32(srNhacThoi.ReadLine());
            srNhacThoi.Close();

            StreamReader srThu2 = new StreamReader(thu2Read);
            int thu2 = Convert.ToInt32(srThu2.ReadLine());
            srThu2.Close();
            StreamReader srThu3 = new StreamReader(thu3Read);
            int thu3 = Convert.ToInt32(srThu3.ReadLine());
            srThu3.Close();
            StreamReader srThu4 = new StreamReader(thu4Read);
            int thu4 = Convert.ToInt32(srThu4.ReadLine());
            srThu4.Close();
            StreamReader srThu5 = new StreamReader(thu5Read);
            int thu5 = Convert.ToInt32(srThu5.ReadLine());
            srThu5.Close();
            StreamReader srThu6 = new StreamReader(thu6Read);
            int thu6 = Convert.ToInt32(srThu6.ReadLine());
            srThu6.Close();
            StreamReader srThu7 = new StreamReader(thu7Read);
            int thu7 = Convert.ToInt32(srThu7.ReadLine());
            srThu7.Close();
            StreamReader srThu8 = new StreamReader(thu8Read);
            int thu8 = Convert.ToInt32(srThu8.ReadLine());
            srThu8.Close();
            StreamReader Chi_Check = new StreamReader(ChiCheck_Read);
            int ChiCheckread = Convert.ToInt32(Chi_Check.ReadLine());
            Chi_Check.Close();

            // đọc dữ liệu
            StreamReader srHou = new StreamReader(hou);
            houText.Text = srHou.ReadLine();
            srHou.Close();
            StreamReader srMin = new StreamReader(min);
            minText.Text = srMin.ReadLine();
            srMin.Close();
            StreamReader srSec = new StreamReader(sec);
            secText.Text = srSec.ReadLine();
            srSec.Close();
            if (thu2 == 1) { HaiCheck.Checked = true; }
            else { HaiCheck.Checked = false; }
            if (thu3 == 1) { BaCheck.Checked = true; }
            else { BaCheck.Checked = false; }
            if (thu4 == 1) { TuCheck.Checked = true; }
            else { TuCheck.Checked = false; }
            if (thu5 == 1) { NamCheck.Checked = true; }
            else { NamCheck.Checked = false; }
            if (thu6 == 1) { SauCheck.Checked = true; }
            else { SauCheck.Checked = false; }
            if (thu7 == 1) { BayCheck.Checked = true; }
            else { BayCheck.Checked = false; }
            if (thu8 == 1) { TamCheck.Checked = true; }
            else { TamCheck.Checked = false; }
            if (ChiCheckread == 1) { ChiCheck.Checked = true; }
            else { ChiCheck.Checked = false; }
            StreamReader srName = new StreamReader(TenBaoThucRead);
            NameBox.Text = srName.ReadLine();
            srName.Close();
            if (NhacNgay == 1) NgayCheck.Checked = true;
            else NgayCheck.Checked = false;
            if (NhacThoi == 1) ThoiCheck.Checked = true;
            else ThoiCheck.Checked = false;
            try
            {
                AnhBox.Image = new Bitmap(Application.StartupPath + "\\" + AnhPath);
            }
            catch { }
            ChuongBox.Text = Path.GetFileName(ChuongPath);
            DateText.Text = dateText;
            MonthText.Text = monthText;
            YearText.Text = yearText;

            String LoopCheckRead = (@"Data\BaoThuc\Clock" + iu + "\\VongLap.adb");
            StreamReader swLoop = new StreamReader(LoopCheckRead);
            int looping = Convert.ToInt32(swLoop.ReadLine());
            if (looping == 0) LoopCheck.Checked = false;
            else LoopCheck.Checked = true;
            swLoop.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonSave();
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn gì nên không thể lưu");
            }
        }
        void ButtonSave()
        {
            stopSou();
            StreamWriter srSog = new StreamWriter(@"Data\BaoThuc\Clock" + iu + "\\Chuongpath.adb");
            srSog.WriteLine(pathMusicRead);
            srSog.Close();
            Isong.Start();

            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            panel12.Visible = false;
            //Kiểm tra lỗi

            if (iu < 1 || iu > 20) { MessageBox.Show("Bạn chưa chọn gì"); return; }

            // lấy dữ liệu
            String hou = (@"Data\BaoThuc\Clock" + iu + "\\hou.adb");//done
            String min = (@"Data\BaoThuc\Clock" + iu + "\\min.adb");//done
            String sec = (@"Data\BaoThuc\Clock" + iu + "\\sec.adb");//done
            String thu2Read = (@"Data\BaoThuc\Clock" + iu + "\\thu2.adb");
            String thu3Read = (@"Data\BaoThuc\Clock" + iu + "\\thu3.adb");
            String thu4Read = (@"Data\BaoThuc\Clock" + iu + "\\thu4.adb");
            String thu5Read = (@"Data\BaoThuc\Clock" + iu + "\\thu5.adb");
            String thu6Read = (@"Data\BaoThuc\Clock" + iu + "\\thu6.adb");
            String thu7Read = (@"Data\BaoThuc\Clock" + iu + "\\thu7.adb");
            String thu8Read = (@"Data\BaoThuc\Clock" + iu + "\\thu8.adb");
            String ChiCheckRead = (@"Data\BaoThuc\Clock" + iu + "\\chicheck.adb");
            String TenBaoThucRead = (@"Data\BaoThuc\Clock" + iu + "\\TenBaoThuc.adb");
            String NhacNgayRead = (@"Data\BaoThuc\Clock" + iu + "\\nhacngay.adb");
            String NhacThoiRead = (@"Data\BaoThuc\Clock" + iu + "\\nhacthoi.adb");
            String AnhPathRead = (@"Data\BaoThuc\Clock" + iu + "\\AnhPath.adb");
            String ChuongPathRead = (@"Data\BaoThuc\Clock" + iu + "\\chuongPath.adb");
            String dateRead = (@"Data\BaoThuc\Clock" + iu + "\\date.adb");
            String monthRead = (@"Data\BaoThuc\Clock" + iu + "\\month.adb");
            String yearRead = (@"Data\BaoThuc\Clock" + iu + "\\year.adb");
            String LoopCheckRead = (@"Data\BaoThuc\Clock" + iu + "\\VongLap.adb");
            String on_offRead = (@"Data\BaoThuc\Clock" + iu + "\\ON_OFF.adb");

            StreamWriter swON = new StreamWriter(on_offRead);
            swON.WriteLine("1");
            swON.Close();

            StreamWriter swLoop = new StreamWriter(LoopCheckRead);
            if (LoopCheck.Checked == true) swLoop.WriteLine("1"); else swLoop.WriteLine("0");
            swLoop.Close();

            StreamWriter swDate = new StreamWriter(dateRead);
            swDate.WriteLine(DateText.Text);
            swDate.Close();

            StreamWriter swMonth = new StreamWriter(monthRead);
            swMonth.WriteLine(MonthText.Text);
            swMonth.Close();

            StreamWriter swYear = new StreamWriter(yearRead);
            swYear.WriteLine(YearText.Text);
            swYear.Close();

            #region rối quá
            StreamWriter swName = new StreamWriter(TenBaoThucRead);
            swName.WriteLine(NameBox.Text);
            swName.Close();

            StreamWriter srNgayCheck = new StreamWriter(NhacNgayRead);
            if (NgayCheck.Checked == true)
            {
                srNgayCheck.WriteLine("1");
            }
            else
            {
                srNgayCheck.WriteLine("0");
            }
            srNgayCheck.Close();

            StreamWriter srThoiCheck = new StreamWriter(NhacThoiRead);
            if (ThoiCheck.Checked == true)
            {
                srThoiCheck.WriteLine("1");
            }
            else
            {
                srThoiCheck.WriteLine("0");
            }
            srThoiCheck.Close();

            StreamWriter srHou = new StreamWriter(hou);
            srHou.WriteLine(houText.Text);
            srHou.Close();

            StreamWriter srMin = new StreamWriter(min);
            srMin.WriteLine(minText.Text);
            srMin.Close();

            StreamWriter srSec = new StreamWriter(sec);
            srSec.WriteLine(secText.Text);
            srSec.Close();

            StreamWriter srThu2 = new StreamWriter(thu2Read);
            if (HaiCheck.Checked == true)
            {
                srThu2.WriteLine("1");
            }
            else
            {
                srThu2.WriteLine("0");
            }
            srThu2.Close();
            StreamWriter srThu3 = new StreamWriter(thu3Read);
            if (BaCheck.Checked == true)
            {
                srThu3.WriteLine("1");
            }
            else
            {
                srThu3.WriteLine("0");
            }
            srThu3.Close();
            StreamWriter srThu4 = new StreamWriter(thu4Read);
            if (TuCheck.Checked == true)
            {
                srThu4.WriteLine("1");
            }
            else
            {
                srThu4.WriteLine("0");
            }
            srThu4.Close();
            StreamWriter srThu5 = new StreamWriter(thu5Read);
            if (NamCheck.Checked == true)
            {
                srThu5.WriteLine("1");
            }
            else
            {
                srThu5.WriteLine("0");
            }
            srThu5.Close();
            StreamWriter srThu6 = new StreamWriter(thu6Read);
            if (SauCheck.Checked == true)
            {
                srThu6.WriteLine("1");
            }
            else
            {
                srThu6.WriteLine("0");
            }
            srThu6.Close();
            StreamWriter srThu7 = new StreamWriter(thu7Read);
            if (BayCheck.Checked == true)
            {
                srThu7.WriteLine("1");
            }
            else
            {
                srThu7.WriteLine("0");
            }
            srThu7.Close();
            StreamWriter srThu8 = new StreamWriter(thu8Read);
            if (TamCheck.Checked == true)
            {
                srThu8.WriteLine("1");
            }
            else
            {
                srThu8.WriteLine("0");
            }
            srThu8.Close();
            StreamWriter srChiCheck = new StreamWriter(ChiCheckRead);
            if (ChiCheck.Checked == true)
            {
                srChiCheck.WriteLine("1");
            }
            else
            {
                srChiCheck.WriteLine("0");
            }
            srChiCheck.Close();
            #endregion
            LoadResetIU();
        }
        //reset lại các báo thức khi bấm lưu hay gì đó
        void LoadResetIU()
        {
            if (iu == 1) tmCLock1.Start();
            if (iu == 2) tmCLock2.Start();
            if (iu == 3) tmCLock3.Start();
            if (iu == 4) tmCLock4.Start();
            if (iu == 5) tmCLock5.Start();
            if (iu == 6) tmCLock6.Start();
            if (iu == 7) tmCLock7.Start();
            if (iu == 8) tmCLock8.Start();
            if (iu == 9) tmCLock9.Start();
            if (iu == 10) tmCLock10.Start();
            if (iu == 11) tmCLock11.Start();
            if (iu == 12) tmCLock12.Start();
            if (iu == 13) tmCLock13.Start();
            if (iu == 14) tmCLock14.Start();
            if (iu == 15) tmCLock15.Start();
            if (iu == 16) tmCLock16.Start();
            if (iu == 17) tmCLock17.Start();
            if (iu == 18) tmCLock18.Start();
            if (iu == 19) tmCLock19.Start();
            if (iu == 20) tmCLock20.Start();
        }

        // khong cho nhập chữ trong caidatTime
        private void houText_KeyPress(object sender, KeyPressEventArgs e)
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

        Timer TextRong = new Timer() { Interval = 1 };
        void TextRong_Tick(object sender, EventArgs e)
        {



        }

        private void AnhBox_Click(object sender, EventArgs e)
        {
            //Kiểm tra lỗi

            if (iu < 1 || iu > 20) { MessageBox.Show("Bạn chưa chọn gì"); return; }


            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File Ảnh|*.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.gif";
            f.InitialDirectory = Directory.GetCurrentDirectory() + "\\data\\baothuc\\anhbaothuc";
            DialogResult d = f.ShowDialog();
            if (d == DialogResult.OK)
            {

                String file = f.FileName;
                String file1 = Path.GetFileName(f.FileName);



                String pathImage1 = @"Data\BaoThuc\AnhBaoThuc";
                pathImage1 = pathImage1 + "\\" + file1;
                try
                {
                    File.Copy(file, pathImage1);
                }
                catch { }

                StreamWriter sr = new StreamWriter(@"Data\BaoThuc\Clock" + iu + "\\anhpath.adb");
                sr.WriteLine(pathImage1);
                sr.Close();
                try
                {
                    AnhBox.Image = new Bitmap(Application.StartupPath + "\\" + pathImage1);
                }
                catch
                {
                    MessageBox.Show("Không tìm thấy hình ảnh");
                }
                LoadResetIU();
            };

        }
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
        private void ChuongBut_Click(object sender, EventArgs e)
        {
            //Kiểm tra lỗi
            stopSou();
            if (iu < 1 || iu > 20) { MessageBox.Show("Bạn chưa chọn gì"); return; }


            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = Directory.GetCurrentDirectory() + "\\data\\baothuc\\chuongcuatoi";
            f.Filter = "File Âm Thanh|*.wav;*.mp3;*.mp4|File khác|*.lnk;*.doc;*.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.gif;*.pdf";
            //  f.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | )|Wav file|*wav";
            DialogResult d = f.ShowDialog();
            if (d == DialogResult.OK)
            {
                String file = f.FileName;
                String file1 = Path.GetFileName(f.FileName);

                String pathImage1 = @"Data\BaoThuc\ChuongCuaToi";
                pathImage1 = pathImage1 + "\\" + file1;
                try
                {
                    File.Copy(file, pathImage1);
                }
                catch { }

                Isong.Stop();
                pathMusicRead = pathImage1;

                try
                {
                    ChuongBox.Text = file1;
                }
                catch
                {
                    MessageBox.Show("Không tìm thấy âm thanh");
                }

            };
        }
        #region Clock1
        Timer tmCLock1 = new Timer() { Interval = 1 };
        String Path_on_off = @"Data\BaoThuc\Clock1\On_Off.adb";
        String Like_on_Dis = @"Data\BaoThuc\Clock1\Like_Dis.adb";
        String ON_OFF = @"Data\User\Anh\On.png";
        String OFF_ON = @"Data\User\Anh\Off.png";
        String Path_name = @"Data\BaoThuc\Clock1\TenBaoThuc.adb";
        String Path_Hou = @"Data\BaoThuc\Clock1\hou.adb";
        String Path_Min = @"Data\BaoThuc\Clock1\min.adb";
        String Path_Sec = @"Data\BaoThuc\Clock1\sec.adb";
        String Path_NhacNgay = (@"Data\BaoThuc\Clock1\nhacngay.adb");
        String Path_Day = @"Data\BaoThuc\Clock1\date.adb";
        String Path_Month = @"Data\BaoThuc\Clock1\month.adb";
        String Path_Year = @"Data\BaoThuc\Clock1\year.adb";

        String Path_Thu2 = @"Data\BaoThuc\Clock1\thu2.adb";
        String Path_Thu3 = @"Data\BaoThuc\Clock1\thu3.adb";
        String Path_Thu4 = @"Data\BaoThuc\Clock1\thu4.adb";
        String Path_Thu5 = @"Data\BaoThuc\Clock1\thu5.adb";
        String Path_Thu6 = @"Data\BaoThuc\Clock1\thu6.adb";
        String Path_Thu7 = @"Data\BaoThuc\Clock1\thu7.adb";
        String Path_Thu8 = @"Data\BaoThuc\Clock1\thu8.adb";
        String Path_ChiCheck = (@"Data\BaoThuc\Clock1\chicheck.adb");
        String Path_Anhpath = (@"Data\BaoThuc\Clock1\AnhPath.adb");

        void LoadClock1()
        {
            tmCLock1.Tick += tmCLock1_Tick;
            tmCLock1.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis);
            like = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like == 1) { LikeBut1.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; }
            else { LikeBut1.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off);
            on_off = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off == 1)
            {
                ON1.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off = 0;
            }
            else
            {
                ON1.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off = 1;
            }
        }

        void tmCLock1_Tick(object sender, EventArgs e)
        {
            tmCLock1.Stop();
            StreamReader srName = new StreamReader(Path_name);
            Title1.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time1.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date1.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date1.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu2); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu3); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu4); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu5); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu6); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu7); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu8); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday1.Text = "";
            if (ChiCheck == 1) Monday1.Text = "";
            else
            {
                if (thu2 == 1) Monday1.Text = Monday1.Text + "Thứ 2 ";
                else Monday1.Text = Monday1.Text + "";
                if (thu3 == 1) Monday1.Text = Monday1.Text + "Thứ 3 ";
                else Monday1.Text = Monday1.Text + "";
                if (thu4 == 1) Monday1.Text = Monday1.Text + "Thứ 4 ";
                else Monday1.Text = Monday1.Text + "";
                if (thu5 == 1) Monday1.Text = Monday1.Text + "Thứ 5 ";
                else Monday1.Text = Monday1.Text + "";
                if (thu6 == 1) Monday1.Text = Monday1.Text + "Thứ 6 ";
                else Monday1.Text = Monday1.Text + "";
                if (thu7 == 1) Monday1.Text = Monday1.Text + "Thứ 7 ";
                else Monday1.Text = Monday1.Text + "";
                if (thu8 == 1) Monday1.Text = Monday1.Text + "Chủ Nhật ";
                else Monday1.Text = Monday1.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath);
            try
            {
                AnhMot.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMot.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }

        int like = 0;// nút like
        private void LikeBut1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis);
            if (like == 1) { LikeBut1.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut1.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }

        int on_off = 0;
        private void ON1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off);

            if (on_off == 1)
            {
                ON1.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off = 0; sw.WriteLine("1");
            }
            else
            {
                ON1.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion

        #region Clock2
        Timer tmCLock2 = new Timer() { Interval = 1 };
        int on_off2 = 0; int like2 = 0;// nút like
        String Path_on_off2 = @"Data\BaoThuc\Clock2\On_Off.adb";
        String Like_on_Dis2 = @"Data\BaoThuc\Clock2\Like_Dis.adb";
        String Path_name2 = @"Data\BaoThuc\Clock2\TenBaoThuc.adb";
        String Path_Hou2 = @"Data\BaoThuc\Clock2\hou.adb";
        String Path_Min2 = @"Data\BaoThuc\Clock2\min.adb";
        String Path_Sec2 = @"Data\BaoThuc\Clock2\sec.adb";
        String Path_NhacNgay2 = (@"Data\BaoThuc\Clock2\nhacngay.adb");
        String Path_Day2 = @"Data\BaoThuc\Clock2\date.adb";
        String Path_Month2 = @"Data\BaoThuc\Clock2\month.adb";
        String Path_Year2 = @"Data\BaoThuc\Clock2\year.adb";
        String Path_Thu22 = @"Data\BaoThuc\Clock2\thu2.adb";
        String Path_Thu32 = @"Data\BaoThuc\Clock2\thu3.adb";
        String Path_Thu42 = @"Data\BaoThuc\Clock2\thu4.adb";
        String Path_Thu52 = @"Data\BaoThuc\Clock2\thu5.adb";
        String Path_Thu62 = @"Data\BaoThuc\Clock2\thu6.adb";
        String Path_Thu72 = @"Data\BaoThuc\Clock2\thu7.adb";
        String Path_Thu82 = @"Data\BaoThuc\Clock2\thu8.adb";
        String Path_ChiCheck2 = (@"Data\BaoThuc\Clock2\chicheck.adb");
        String Path_Anhpath2 = (@"Data\BaoThuc\Clock2\AnhPath.adb");

        void LoadClock2()
        {
            tmCLock2.Tick += tmCLock2_Tick;
            tmCLock2.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis2);
            like2 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like2 == 1) { LikeBut2.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like2 = 0; }
            else { LikeBut2.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like2 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off2);
            on_off2 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off2 == 1)
            {
                ON2.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off2 = 0;
            }
            else
            {
                ON2.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off2 = 1;
            }
        }

        void tmCLock2_Tick(object sender, EventArgs e)
        {
            tmCLock2.Stop();

            StreamReader srName = new StreamReader(Path_name2);
            Title2.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou2); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min2); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec2); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time2.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay2);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day2); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month2); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year2); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date2.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date2.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu22); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu32); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu42); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu52); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu62); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu72); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu82); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck2); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday2.Text = "";
            if (ChiCheck == 1) Monday2.Text = "";
            else
            {
                if (thu2 == 1) Monday2.Text = Monday2.Text + "Thứ 2 ";
                else Monday2.Text = Monday2.Text + "";
                if (thu3 == 1) Monday2.Text = Monday2.Text + "Thứ 3 ";
                else Monday2.Text = Monday2.Text + "";
                if (thu4 == 1) Monday2.Text = Monday2.Text + "Thứ 4 ";
                else Monday2.Text = Monday2.Text + "";
                if (thu5 == 1) Monday2.Text = Monday2.Text + "Thứ 5 ";
                else Monday2.Text = Monday2.Text + "";
                if (thu6 == 1) Monday2.Text = Monday2.Text + "Thứ 6 ";
                else Monday2.Text = Monday2.Text + "";
                if (thu7 == 1) Monday2.Text = Monday2.Text + "Thứ 7 ";
                else Monday2.Text = Monday2.Text + "";
                if (thu8 == 1) Monday2.Text = Monday2.Text + "Chủ Nhật ";
                else Monday2.Text = Monday2.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath2);
            try
            {
                AnhHai.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhHai.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis2);
            if (like == 1) { LikeBut2.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut2.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off2);

            if (on_off2 == 1)
            {
                ON2.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off2 = 0; sw.WriteLine("1");
            }
            else
            {
                ON2.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off2 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock3
        Timer tmCLock3 = new Timer() { Interval = 1 };
        int on_off3 = 0; int like3 = 0;// nút like
        String Path_on_off3 = @"Data\BaoThuc\Clock3\On_Off.adb";
        String Like_on_Dis3 = @"Data\BaoThuc\Clock3\Like_Dis.adb";
        String Path_name3 = @"Data\BaoThuc\Clock3\TenBaoThuc.adb";
        String Path_Hou3 = @"Data\BaoThuc\Clock3\hou.adb";
        String Path_Min3 = @"Data\BaoThuc\Clock3\min.adb";
        String Path_Sec3 = @"Data\BaoThuc\Clock3\sec.adb";
        String Path_NhacNgay3 = (@"Data\BaoThuc\Clock3\nhacngay.adb");
        String Path_Day3 = @"Data\BaoThuc\Clock3\date.adb";
        String Path_Month3 = @"Data\BaoThuc\Clock3\month.adb";
        String Path_Year3 = @"Data\BaoThuc\Clock3\year.adb";
        String Path_Thu23 = @"Data\BaoThuc\Clock3\thu2.adb";
        String Path_Thu33 = @"Data\BaoThuc\Clock3\thu3.adb";
        String Path_Thu43 = @"Data\BaoThuc\Clock3\thu4.adb";
        String Path_Thu53 = @"Data\BaoThuc\Clock3\thu5.adb";
        String Path_Thu63 = @"Data\BaoThuc\Clock3\thu6.adb";
        String Path_Thu73 = @"Data\BaoThuc\Clock3\thu7.adb";
        String Path_Thu83 = @"Data\BaoThuc\Clock3\thu8.adb";
        String Path_ChiCheck3 = (@"Data\BaoThuc\Clock3\chicheck.adb");
        String Path_Anhpath3 = (@"Data\BaoThuc\Clock3\AnhPath.adb");

        void LoadClock3()
        {
            tmCLock3.Tick += tmCLock3_Tick;
            tmCLock3.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis3);
            like3 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like3 == 1) { LikeBut3.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like3 = 0; }
            else { LikeBut3.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like3 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off3);
            on_off3 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off3 == 1)
            {
                ON3.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off3 = 0;
            }
            else
            {
                ON3.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off3 = 1;
            }
        }

        void tmCLock3_Tick(object sender, EventArgs e)
        {
            tmCLock3.Stop();

            StreamReader srName = new StreamReader(Path_name3);
            Title3.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou3); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min3); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec3); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time3.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay3);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day3); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month3); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year3); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date3.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date3.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu23); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu33); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu43); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu53); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu63); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu73); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu83); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck3); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday3.Text = "";
            if (ChiCheck == 1) Monday3.Text = "";
            else
            {
                if (thu2 == 1) Monday3.Text = Monday3.Text + "Thứ 2 ";
                else Monday3.Text = Monday3.Text + "";
                if (thu3 == 1) Monday3.Text = Monday3.Text + "Thứ 3 ";
                else Monday3.Text = Monday3.Text + "";
                if (thu4 == 1) Monday3.Text = Monday3.Text + "Thứ 4 ";
                else Monday3.Text = Monday3.Text + "";
                if (thu5 == 1) Monday3.Text = Monday3.Text + "Thứ 5 ";
                else Monday3.Text = Monday3.Text + "";
                if (thu6 == 1) Monday3.Text = Monday3.Text + "Thứ 6 ";
                else Monday3.Text = Monday3.Text + "";
                if (thu7 == 1) Monday3.Text = Monday3.Text + "Thứ 7 ";
                else Monday3.Text = Monday3.Text + "";
                if (thu8 == 1) Monday3.Text = Monday3.Text + "Chủ Nhật ";
                else Monday3.Text = Monday3.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath3);
            try
            {
                AnhBa.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhBa.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis3);
            if (like == 1) { LikeBut3.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut3.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off3);

            if (on_off3 == 1)
            {
                ON3.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off3 = 0; sw.WriteLine("1");
            }
            else
            {
                ON3.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off3 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock4
        Timer tmCLock4 = new Timer() { Interval = 1 };
        int on_off4 = 0; int like4 = 0;// nút like
        String Path_on_off4 = @"Data\BaoThuc\Clock4\On_Off.adb";
        String Like_on_Dis4 = @"Data\BaoThuc\Clock4\Like_Dis.adb";
        String Path_name4 = @"Data\BaoThuc\Clock4\TenBaoThuc.adb";
        String Path_Hou4 = @"Data\BaoThuc\Clock4\hou.adb";
        String Path_Min4 = @"Data\BaoThuc\Clock4\min.adb";
        String Path_Sec4 = @"Data\BaoThuc\Clock4\sec.adb";
        String Path_NhacNgay4 = (@"Data\BaoThuc\Clock4\nhacngay.adb");
        String Path_Day4 = @"Data\BaoThuc\Clock4\date.adb";
        String Path_Month4 = @"Data\BaoThuc\Clock4\month.adb";
        String Path_Year4 = @"Data\BaoThuc\Clock4\year.adb";
        String Path_Thu24 = @"Data\BaoThuc\Clock4\thu2.adb";
        String Path_Thu34 = @"Data\BaoThuc\Clock4\thu3.adb";
        String Path_Thu44 = @"Data\BaoThuc\Clock4\thu4.adb";
        String Path_Thu54 = @"Data\BaoThuc\Clock4\thu5.adb";
        String Path_Thu64 = @"Data\BaoThuc\Clock4\thu6.adb";
        String Path_Thu74 = @"Data\BaoThuc\Clock4\thu7.adb";
        String Path_Thu84 = @"Data\BaoThuc\Clock4\thu8.adb";
        String Path_ChiCheck4 = (@"Data\BaoThuc\Clock4\chicheck.adb");
        String Path_Anhpath4 = (@"Data\BaoThuc\Clock4\AnhPath.adb");

        void LoadClock4()
        {
            tmCLock4.Tick += tmCLock4_Tick;
            tmCLock4.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis4);
            like4 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like4 == 1) { LikeBut4.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like4 = 0; }
            else { LikeBut4.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like4 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off4);
            on_off4 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off4 == 1)
            {
                ON4.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off4 = 0;
            }
            else
            {
                ON4.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off4 = 1;
            }
        }

        void tmCLock4_Tick(object sender, EventArgs e)
        {
            tmCLock4.Stop();

            StreamReader srName = new StreamReader(Path_name4);
            Title4.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou4); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min4); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec4); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time4.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay4);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day4); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month4); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year4); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date4.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date4.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu24); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu34); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu44); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu54); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu64); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu74); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu84); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck4); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday4.Text = "";
            if (ChiCheck == 1) Monday4.Text = "";
            else
            {
                if (thu2 == 1) Monday4.Text = Monday4.Text + "Thứ 2 ";
                else Monday4.Text = Monday4.Text + "";
                if (thu3 == 1) Monday4.Text = Monday4.Text + "Thứ 3 ";
                else Monday4.Text = Monday4.Text + "";
                if (thu4 == 1) Monday4.Text = Monday4.Text + "Thứ 4 ";
                else Monday4.Text = Monday4.Text + "";
                if (thu5 == 1) Monday4.Text = Monday4.Text + "Thứ 5 ";
                else Monday4.Text = Monday4.Text + "";
                if (thu6 == 1) Monday4.Text = Monday4.Text + "Thứ 6 ";
                else Monday4.Text = Monday4.Text + "";
                if (thu7 == 1) Monday4.Text = Monday4.Text + "Thứ 7 ";
                else Monday4.Text = Monday4.Text + "";
                if (thu8 == 1) Monday4.Text = Monday4.Text + "Chủ Nhật ";
                else Monday4.Text = Monday4.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath4);
            try
            {
                AnhBon.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhBon.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut4_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis4);
            if (like == 1) { LikeBut4.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut4.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON4_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off4);

            if (on_off4 == 1)
            {
                ON4.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off4 = 0; sw.WriteLine("1");
            }
            else
            {
                ON4.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off4 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock5
        Timer tmCLock5 = new Timer() { Interval = 1 };
        int on_off5 = 0; int like5 = 0;// nút like
        String Path_on_off5 = @"Data\BaoThuc\Clock5\On_Off.adb";
        String Like_on_Dis5 = @"Data\BaoThuc\Clock5\Like_Dis.adb";
        String Path_name5 = @"Data\BaoThuc\Clock5\TenBaoThuc.adb";
        String Path_Hou5 = @"Data\BaoThuc\Clock5\hou.adb";
        String Path_Min5 = @"Data\BaoThuc\Clock5\min.adb";
        String Path_Sec5 = @"Data\BaoThuc\Clock5\sec.adb";
        String Path_NhacNgay5 = @"Data\BaoThuc\Clock5\nhacngay.adb";
        String Path_Day5 = @"Data\BaoThuc\Clock5\date.adb";
        String Path_Month5 = @"Data\BaoThuc\Clock5\month.adb";
        String Path_Year5 = @"Data\BaoThuc\Clock5\year.adb";
        String Path_Thu25 = @"Data\BaoThuc\Clock5\thu2.adb";
        String Path_Thu35 = @"Data\BaoThuc\Clock5\thu3.adb";
        String Path_Thu45 = @"Data\BaoThuc\Clock5\thu4.adb";
        String Path_Thu55 = @"Data\BaoThuc\Clock5\thu5.adb";
        String Path_Thu65 = @"Data\BaoThuc\Clock5\thu6.adb";
        String Path_Thu75 = @"Data\BaoThuc\Clock5\thu7.adb";
        String Path_Thu85 = @"Data\BaoThuc\Clock5\thu8.adb";
        String Path_ChiCheck5 = @"Data\BaoThuc\Clock5\chicheck.adb";
        String Path_Anhpath5 = @"Data\BaoThuc\Clock5\AnhPath.adb";

        void LoadClock5()
        {
            tmCLock5.Tick += tmCLock5_Tick;
            tmCLock5.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis5);
            like5 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like5 == 1) { LikeBut5.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like5 = 0; }
            else { LikeBut5.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like5 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off5);
            on_off5 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off5 == 1)
            {
                ON5.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off5 = 0;
            }
            else
            {
                ON5.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off5 = 1;
            }
        }

        void tmCLock5_Tick(object sender, EventArgs e)
        {
            tmCLock5.Stop();

            StreamReader srName = new StreamReader(Path_name5);
            Title5.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou5); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min5); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec5); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time5.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay5);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day5); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month5); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year5); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date5.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date5.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu25); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu35); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu45); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu55); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu65); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu75); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu85); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck5); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday5.Text = "";
            if (ChiCheck == 1) Monday5.Text = "";
            else
            {
                if (thu2 == 1) Monday5.Text = Monday5.Text + "Thứ 2 ";
                else Monday5.Text = Monday5.Text + "";
                if (thu3 == 1) Monday5.Text = Monday5.Text + "Thứ 3 ";
                else Monday5.Text = Monday5.Text + "";
                if (thu4 == 1) Monday5.Text = Monday5.Text + "Thứ 4 ";
                else Monday5.Text = Monday5.Text + "";
                if (thu5 == 1) Monday5.Text = Monday5.Text + "Thứ 5 ";
                else Monday5.Text = Monday5.Text + "";
                if (thu6 == 1) Monday5.Text = Monday5.Text + "Thứ 6 ";
                else Monday5.Text = Monday5.Text + "";
                if (thu7 == 1) Monday5.Text = Monday5.Text + "Thứ 7 ";
                else Monday5.Text = Monday5.Text + "";
                if (thu8 == 1) Monday5.Text = Monday5.Text + "Chủ Nhật ";
                else Monday5.Text = Monday5.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath5);
            try
            {
                AnhNam.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhNam.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut5_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis5);
            if (like == 1) { LikeBut5.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut5.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON5_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off5);

            if (on_off5 == 1)
            {
                ON5.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off5 = 0; sw.WriteLine("1");
            }
            else
            {
                ON5.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off5 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock6
        Timer tmCLock6 = new Timer() { Interval = 1 };
        int on_off6 = 0; int like6 = 0;// nút like
        String Path_on_off6 = @"Data\BaoThuc\Clock6\On_Off.adb";
        String Like_on_Dis6 = @"Data\BaoThuc\Clock6\Like_Dis.adb";
        String Path_name6 = @"Data\BaoThuc\Clock6\TenBaoThuc.adb";
        String Path_Hou6 = @"Data\BaoThuc\Clock6\hou.adb";
        String Path_Min6 = @"Data\BaoThuc\Clock6\min.adb";
        String Path_Sec6 = @"Data\BaoThuc\Clock6\sec.adb";
        String Path_NhacNgay6 = @"Data\BaoThuc\Clock6\nhacngay.adb";
        String Path_Day6 = @"Data\BaoThuc\Clock6\date.adb";
        String Path_Month6 = @"Data\BaoThuc\Clock6\month.adb";
        String Path_Year6 = @"Data\BaoThuc\Clock6\year.adb";
        String Path_Thu26 = @"Data\BaoThuc\Clock6\thu2.adb";
        String Path_Thu36 = @"Data\BaoThuc\Clock6\thu3.adb";
        String Path_Thu46 = @"Data\BaoThuc\Clock6\thu4.adb";
        String Path_Thu56 = @"Data\BaoThuc\Clock6\thu5.adb";
        String Path_Thu66 = @"Data\BaoThuc\Clock6\thu6.adb";
        String Path_Thu76 = @"Data\BaoThuc\Clock6\thu7.adb";
        String Path_Thu86 = @"Data\BaoThuc\Clock6\thu8.adb";
        String Path_ChiCheck6 = @"Data\BaoThuc\Clock6\chicheck.adb";
        String Path_Anhpath6 = @"Data\BaoThuc\Clock6\AnhPath.adb";

        void LoadClock6()
        {
            tmCLock6.Tick += tmCLock6_Tick;
            tmCLock6.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis6);
            like6 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like6 == 1) { LikeBut6.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like6 = 0; }
            else { LikeBut6.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like6 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off6);
            on_off6 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off6 == 1)
            {
                ON6.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off6 = 0;
            }
            else
            {
                ON6.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off6 = 1;
            }
        }

        void tmCLock6_Tick(object sender, EventArgs e)
        {
            tmCLock6.Stop();

            StreamReader srName = new StreamReader(Path_name6);
            Title6.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou6); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min6); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec6); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time6.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay6);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day6); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month6); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year6); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date6.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date6.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu26); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu36); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu46); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu56); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu66); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu76); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu86); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck6); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday6.Text = "";
            if (ChiCheck == 1) Monday6.Text = "";
            else
            {
                if (thu2 == 1) Monday6.Text = Monday6.Text + "Thứ 2 ";
                else Monday6.Text = Monday6.Text + "";
                if (thu3 == 1) Monday6.Text = Monday6.Text + "Thứ 3 ";
                else Monday6.Text = Monday6.Text + "";
                if (thu4 == 1) Monday6.Text = Monday6.Text + "Thứ 4 ";
                else Monday6.Text = Monday6.Text + "";
                if (thu5 == 1) Monday6.Text = Monday6.Text + "Thứ 5 ";
                else Monday6.Text = Monday6.Text + "";
                if (thu6 == 1) Monday6.Text = Monday6.Text + "Thứ 6 ";
                else Monday6.Text = Monday6.Text + "";
                if (thu7 == 1) Monday6.Text = Monday6.Text + "Thứ 7 ";
                else Monday6.Text = Monday6.Text + "";
                if (thu8 == 1) Monday6.Text = Monday6.Text + "Chủ Nhật ";
                else Monday6.Text = Monday6.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath6);
            try
            {
                AnhSau.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhSau.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut6_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis6);
            if (like == 1) { LikeBut6.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut6.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON6_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off6);

            if (on_off6 == 1)
            {
                ON6.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off6 = 0; sw.WriteLine("1");
            }
            else
            {
                ON6.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off6 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock7
        Timer tmCLock7 = new Timer() { Interval = 1 };
        int on_off7 = 0; int like7 = 0;// nút like
        String Path_on_off7 = @"Data\BaoThuc\Clock7\On_Off.adb";
        String Like_on_Dis7 = @"Data\BaoThuc\Clock7\Like_Dis.adb";
        String Path_name7 = @"Data\BaoThuc\Clock7\TenBaoThuc.adb";
        String Path_Hou7 = @"Data\BaoThuc\Clock7\hou.adb";
        String Path_Min7 = @"Data\BaoThuc\Clock7\min.adb";
        String Path_Sec7 = @"Data\BaoThuc\Clock7\sec.adb";
        String Path_NhacNgay7 = @"Data\BaoThuc\Clock7\nhacngay.adb";
        String Path_Day7 = @"Data\BaoThuc\Clock7\date.adb";
        String Path_Month7 = @"Data\BaoThuc\Clock7\month.adb";
        String Path_Year7 = @"Data\BaoThuc\Clock7\year.adb";
        String Path_Thu27 = @"Data\BaoThuc\Clock7\thu2.adb";
        String Path_Thu37 = @"Data\BaoThuc\Clock7\thu3.adb";
        String Path_Thu47 = @"Data\BaoThuc\Clock7\thu4.adb";
        String Path_Thu57 = @"Data\BaoThuc\Clock7\thu5.adb";
        String Path_Thu67 = @"Data\BaoThuc\Clock7\thu6.adb";
        String Path_Thu77 = @"Data\BaoThuc\Clock7\thu7.adb";
        String Path_Thu87 = @"Data\BaoThuc\Clock7\thu8.adb";
        String Path_ChiCheck7 = @"Data\BaoThuc\Clock7\chicheck.adb";
        String Path_Anhpath7 = @"Data\BaoThuc\Clock7\AnhPath.adb";

        void LoadClock7()
        {
            tmCLock7.Tick += tmCLock7_Tick;
            tmCLock7.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis7);
            like7 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like7 == 1) { LikeBut7.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like7 = 0; }
            else { LikeBut7.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like7 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off7);
            on_off7 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off7 == 1)
            {
                ON7.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off7 = 0;
            }
            else
            {
                ON7.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off7 = 1;
            }
        }

        void tmCLock7_Tick(object sender, EventArgs e)
        {
            tmCLock7.Stop();

            StreamReader srName = new StreamReader(Path_name7);
            Title7.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou7); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min7); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec7); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time7.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay7);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day7); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month7); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year7); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date7.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date7.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu27); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu37); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu47); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu57); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu67); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu77); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu87); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck7); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday7.Text = "";
            if (ChiCheck == 1) Monday7.Text = "";
            else
            {
                if (thu2 == 1) Monday7.Text = Monday7.Text + "Thứ 2 ";
                else Monday7.Text = Monday7.Text + "";
                if (thu3 == 1) Monday7.Text = Monday7.Text + "Thứ 3 ";
                else Monday7.Text = Monday7.Text + "";
                if (thu4 == 1) Monday7.Text = Monday7.Text + "Thứ 4 ";
                else Monday7.Text = Monday7.Text + "";
                if (thu5 == 1) Monday7.Text = Monday7.Text + "Thứ 5 ";
                else Monday7.Text = Monday7.Text + "";
                if (thu6 == 1) Monday7.Text = Monday7.Text + "Thứ 6 ";
                else Monday7.Text = Monday7.Text + "";
                if (thu7 == 1) Monday7.Text = Monday7.Text + "Thứ 7 ";
                else Monday7.Text = Monday7.Text + "";
                if (thu8 == 1) Monday7.Text = Monday7.Text + "Chủ Nhật ";
                else Monday7.Text = Monday7.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath7);
            try
            {
                AnhBay.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhBay.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut7_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis7);
            if (like == 1) { LikeBut7.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut7.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON7_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off7);

            if (on_off7 == 1)
            {
                ON7.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off7 = 0; sw.WriteLine("1");
            }
            else
            {
                ON7.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off7 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock8
        Timer tmCLock8 = new Timer() { Interval = 1 };
        int on_off8 = 0; int like8 = 0;// nút like
        String Path_on_off8 = @"Data\BaoThuc\Clock8\On_Off.adb";
        String Like_on_Dis8 = @"Data\BaoThuc\Clock8\Like_Dis.adb";
        String Path_name8 = @"Data\BaoThuc\Clock8\TenBaoThuc.adb";
        String Path_Hou8 = @"Data\BaoThuc\Clock8\hou.adb";
        String Path_Min8 = @"Data\BaoThuc\Clock8\min.adb";
        String Path_Sec8 = @"Data\BaoThuc\Clock8\sec.adb";
        String Path_NhacNgay8 = @"Data\BaoThuc\Clock8\nhacngay.adb";
        String Path_Day8 = @"Data\BaoThuc\Clock8\date.adb";
        String Path_Month8 = @"Data\BaoThuc\Clock8\month.adb";
        String Path_Year8 = @"Data\BaoThuc\Clock8\year.adb";
        String Path_Thu28 = @"Data\BaoThuc\Clock8\thu2.adb";
        String Path_Thu38 = @"Data\BaoThuc\Clock8\thu3.adb";
        String Path_Thu48 = @"Data\BaoThuc\Clock8\thu4.adb";
        String Path_Thu58 = @"Data\BaoThuc\Clock8\thu5.adb";
        String Path_Thu68 = @"Data\BaoThuc\Clock8\thu6.adb";
        String Path_Thu78 = @"Data\BaoThuc\Clock8\thu7.adb";
        String Path_Thu88 = @"Data\BaoThuc\Clock8\thu8.adb";
        String Path_ChiCheck8 = @"Data\BaoThuc\Clock8\chicheck.adb";
        String Path_Anhpath8 = @"Data\BaoThuc\Clock8\AnhPath.adb";

        void LoadClock8()
        {
            tmCLock8.Tick += tmCLock8_Tick;
            tmCLock8.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis8);
            like8 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like8 == 1) { LikeBut8.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like8 = 0; }
            else { LikeBut8.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like8 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off8);
            on_off8 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off8 == 1)
            {
                ON8.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off8 = 0;
            }
            else
            {
                ON8.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off8 = 1;
            }
        }

        void tmCLock8_Tick(object sender, EventArgs e)
        {
            tmCLock8.Stop();

            StreamReader srName = new StreamReader(Path_name8);
            Title8.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou8); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min8); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec8); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time8.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay8);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day8); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month8); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year8); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date8.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date8.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu28); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu38); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu48); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu58); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu68); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu78); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu88); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck8); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday8.Text = "";
            if (ChiCheck == 1) Monday8.Text = "";
            else
            {
                if (thu2 == 1) Monday8.Text = Monday8.Text + "Thứ 2 ";
                else Monday8.Text = Monday8.Text + "";
                if (thu3 == 1) Monday8.Text = Monday8.Text + "Thứ 3 ";
                else Monday8.Text = Monday8.Text + "";
                if (thu4 == 1) Monday8.Text = Monday8.Text + "Thứ 4 ";
                else Monday8.Text = Monday8.Text + "";
                if (thu5 == 1) Monday8.Text = Monday8.Text + "Thứ 5 ";
                else Monday8.Text = Monday8.Text + "";
                if (thu6 == 1) Monday8.Text = Monday8.Text + "Thứ 6 ";
                else Monday8.Text = Monday8.Text + "";
                if (thu7 == 1) Monday8.Text = Monday8.Text + "Thứ 7 ";
                else Monday8.Text = Monday8.Text + "";
                if (thu8 == 1) Monday8.Text = Monday8.Text + "Chủ Nhật ";
                else Monday8.Text = Monday8.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath8);
            try
            {
                AnhTam.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhTam.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut8_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis8);
            if (like == 1) { LikeBut8.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut8.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON8_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off8);

            if (on_off8 == 1)
            {
                ON8.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off8 = 0; sw.WriteLine("1");
            }
            else
            {
                ON8.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off8 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock9
        Timer tmCLock9 = new Timer() { Interval = 1 };
        int on_off9 = 0; int like9 = 0;// nút like
        String Path_on_off9 = @"Data\BaoThuc\Clock9\On_Off.adb";
        String Like_on_Dis9 = @"Data\BaoThuc\Clock9\Like_Dis.adb";
        String Path_name9 = @"Data\BaoThuc\Clock9\TenBaoThuc.adb";
        String Path_Hou9 = @"Data\BaoThuc\Clock9\hou.adb";
        String Path_Min9 = @"Data\BaoThuc\Clock9\min.adb";
        String Path_Sec9 = @"Data\BaoThuc\Clock9\sec.adb";
        String Path_NhacNgay9 = @"Data\BaoThuc\Clock9\nhacngay.adb";
        String Path_Day9 = @"Data\BaoThuc\Clock9\date.adb";
        String Path_Month9 = @"Data\BaoThuc\Clock9\month.adb";
        String Path_Year9 = @"Data\BaoThuc\Clock9\year.adb";
        String Path_Thu29 = @"Data\BaoThuc\Clock9\thu2.adb";
        String Path_Thu39 = @"Data\BaoThuc\Clock9\thu3.adb";
        String Path_Thu49 = @"Data\BaoThuc\Clock9\thu4.adb";
        String Path_Thu59 = @"Data\BaoThuc\Clock9\thu5.adb";
        String Path_Thu69 = @"Data\BaoThuc\Clock9\thu6.adb";
        String Path_Thu79 = @"Data\BaoThuc\Clock9\thu7.adb";
        String Path_Thu89 = @"Data\BaoThuc\Clock9\thu8.adb";
        String Path_ChiCheck9 = @"Data\BaoThuc\Clock9\chicheck.adb";
        String Path_Anhpath9 = @"Data\BaoThuc\Clock9\AnhPath.adb";

        void LoadClock9()
        {
            tmCLock9.Tick += tmCLock9_Tick;
            tmCLock9.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis9);
            like9 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like9 == 1) { LikeBut9.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like9 = 0; }
            else { LikeBut9.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like9 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off9);
            on_off9 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off9 == 1)
            {
                ON9.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off9 = 0;
            }
            else
            {
                ON9.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off9 = 1;
            }
        }

        void tmCLock9_Tick(object sender, EventArgs e)
        {
            tmCLock9.Stop();

            StreamReader srName = new StreamReader(Path_name9);
            Title9.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou9); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min9); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec9); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time9.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay9);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day9); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month9); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year9); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date9.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date9.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu29); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu39); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu49); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu59); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu69); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu79); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu89); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck9); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday9.Text = "";
            if (ChiCheck == 1) Monday9.Text = "";
            else
            {
                if (thu2 == 1) Monday9.Text = Monday9.Text + "Thứ 2 ";
                else Monday9.Text = Monday9.Text + "";
                if (thu3 == 1) Monday9.Text = Monday9.Text + "Thứ 3 ";
                else Monday9.Text = Monday9.Text + "";
                if (thu4 == 1) Monday9.Text = Monday9.Text + "Thứ 4 ";
                else Monday9.Text = Monday9.Text + "";
                if (thu5 == 1) Monday9.Text = Monday9.Text + "Thứ 5 ";
                else Monday9.Text = Monday9.Text + "";
                if (thu6 == 1) Monday9.Text = Monday9.Text + "Thứ 6 ";
                else Monday9.Text = Monday9.Text + "";
                if (thu7 == 1) Monday9.Text = Monday9.Text + "Thứ 7 ";
                else Monday9.Text = Monday9.Text + "";
                if (thu8 == 1) Monday9.Text = Monday9.Text + "Chủ Nhật ";
                else Monday9.Text = Monday9.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath9);
            try
            {
                AnhChin.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhChin.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut9_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis9);
            if (like == 1) { LikeBut9.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut9.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON9_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off9);

            if (on_off9 == 1)
            {
                ON9.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off9 = 0; sw.WriteLine("1");
            }
            else
            {
                ON9.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off9 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock10
        Timer tmCLock10 = new Timer() { Interval = 1 };
        int on_off10 = 0; int like10 = 0;// nút like
        String Path_on_off10 = @"Data\BaoThuc\Clock10\On_Off.adb";
        String Like_on_Dis10 = @"Data\BaoThuc\Clock10\Like_Dis.adb";
        String Path_name10 = @"Data\BaoThuc\Clock10\TenBaoThuc.adb";
        String Path_Hou10 = @"Data\BaoThuc\Clock10\hou.adb";
        String Path_Min10 = @"Data\BaoThuc\Clock10\min.adb";
        String Path_Sec10 = @"Data\BaoThuc\Clock10\sec.adb";
        String Path_NhacNgay10 = @"Data\BaoThuc\Clock10\nhacngay.adb";
        String Path_Day10 = @"Data\BaoThuc\Clock10\date.adb";
        String Path_Month10 = @"Data\BaoThuc\Clock10\month.adb";
        String Path_Year10 = @"Data\BaoThuc\Clock10\year.adb";
        String Path_Thu210 = @"Data\BaoThuc\Clock10\thu2.adb";
        String Path_Thu310 = @"Data\BaoThuc\Clock10\thu3.adb";
        String Path_Thu410 = @"Data\BaoThuc\Clock10\thu4.adb";
        String Path_Thu510 = @"Data\BaoThuc\Clock10\thu5.adb";
        String Path_Thu610 = @"Data\BaoThuc\Clock10\thu6.adb";
        String Path_Thu710 = @"Data\BaoThuc\Clock10\thu7.adb";
        String Path_Thu810 = @"Data\BaoThuc\Clock10\thu8.adb";
        String Path_ChiCheck10 = @"Data\BaoThuc\Clock10\chicheck.adb";
        String Path_Anhpath10 = @"Data\BaoThuc\Clock10\AnhPath.adb";

        void LoadClock10()
        {
            tmCLock10.Tick += tmCLock10_Tick;
            tmCLock10.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis10);
            like10 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like10 == 1) { LikeBut10.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like10 = 0; }
            else { LikeBut10.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like10 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off10);
            on_off10 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off10 == 1)
            {
                ON10.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off10 = 0;
            }
            else
            {
                ON10.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off10 = 1;
            }
        }

        void tmCLock10_Tick(object sender, EventArgs e)
        {
            tmCLock10.Stop();

            StreamReader srName = new StreamReader(Path_name10);
            Title10.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou10); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min10); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec10); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time10.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay10);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day10); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month10); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year10); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date10.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date10.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu210); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu310); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu410); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu510); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu610); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu710); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu810); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck10); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday10.Text = "";
            if (ChiCheck == 1) Monday10.Text = "";
            else
            {
                if (thu2 == 1) Monday10.Text = Monday10.Text + "Thứ 2 ";
                else Monday10.Text = Monday10.Text + "";
                if (thu3 == 1) Monday10.Text = Monday10.Text + "Thứ 3 ";
                else Monday10.Text = Monday10.Text + "";
                if (thu4 == 1) Monday10.Text = Monday10.Text + "Thứ 4 ";
                else Monday10.Text = Monday10.Text + "";
                if (thu5 == 1) Monday10.Text = Monday10.Text + "Thứ 5 ";
                else Monday10.Text = Monday10.Text + "";
                if (thu6 == 1) Monday10.Text = Monday10.Text + "Thứ 6 ";
                else Monday10.Text = Monday10.Text + "";
                if (thu7 == 1) Monday10.Text = Monday10.Text + "Thứ 7 ";
                else Monday10.Text = Monday10.Text + "";
                if (thu8 == 1) Monday10.Text = Monday10.Text + "Chủ Nhật ";
                else Monday10.Text = Monday10.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath10);
            try
            {
                AnhMuoi.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoi.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut10_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis10);
            if (like == 1) { LikeBut10.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut10.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON10_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off10);

            if (on_off10 == 1)
            {
                ON10.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off10 = 0; sw.WriteLine("1");
            }
            else
            {
                ON10.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off10 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock11
        Timer tmCLock11 = new Timer() { Interval = 1 };
        int on_off11 = 0; int like11 = 0;// nút like
        String Path_on_off11 = @"Data\BaoThuc\Clock11\On_Off.adb";
        String Like_on_Dis11 = @"Data\BaoThuc\Clock11\Like_Dis.adb";
        String Path_name11 = @"Data\BaoThuc\Clock11\TenBaoThuc.adb";
        String Path_Hou11 = @"Data\BaoThuc\Clock11\hou.adb";
        String Path_Min11 = @"Data\BaoThuc\Clock11\min.adb";
        String Path_Sec11 = @"Data\BaoThuc\Clock11\sec.adb";
        String Path_NhacNgay11 = @"Data\BaoThuc\Clock11\nhacngay.adb";
        String Path_Day11 = @"Data\BaoThuc\Clock11\date.adb";
        String Path_Month11 = @"Data\BaoThuc\Clock11\month.adb";
        String Path_Year11 = @"Data\BaoThuc\Clock11\year.adb";
        String Path_Thu211 = @"Data\BaoThuc\Clock11\thu2.adb";
        String Path_Thu311 = @"Data\BaoThuc\Clock11\thu3.adb";
        String Path_Thu411 = @"Data\BaoThuc\Clock11\thu4.adb";
        String Path_Thu511 = @"Data\BaoThuc\Clock11\thu5.adb";
        String Path_Thu611 = @"Data\BaoThuc\Clock11\thu6.adb";
        String Path_Thu711 = @"Data\BaoThuc\Clock11\thu7.adb";
        String Path_Thu811 = @"Data\BaoThuc\Clock11\thu8.adb";
        String Path_ChiCheck11 = @"Data\BaoThuc\Clock11\chicheck.adb";
        String Path_Anhpath11 = @"Data\BaoThuc\Clock11\AnhPath.adb";

        void LoadClock11()
        {
            LikeBut11.Click += LikeBut11_Click;
            ON11.Click += ON11_Click;
            tmCLock11.Tick += tmCLock11_Tick;
            tmCLock11.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis11);
            like11 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like11 == 1) { LikeBut11.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like11 = 0; }
            else { LikeBut11.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like11 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off11);
            on_off11 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off11 == 1)
            {
                ON11.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off11 = 0;
            }
            else
            {
                ON11.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off11 = 1;
            }
        }

        void tmCLock11_Tick(object sender, EventArgs e)
        {
            tmCLock11.Stop();

            StreamReader srName = new StreamReader(Path_name11);
            Title11.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou11); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min11); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec11); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time11.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay11);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day11); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month11); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year11); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date11.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date11.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu211); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu311); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu411); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu511); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu611); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu711); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu811); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck11); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday11.Text = "";
            if (ChiCheck == 1) Monday11.Text = "";
            else
            {
                if (thu2 == 1) Monday11.Text = Monday11.Text + "Thứ 2 ";
                else Monday11.Text = Monday11.Text + "";
                if (thu3 == 1) Monday11.Text = Monday11.Text + "Thứ 3 ";
                else Monday11.Text = Monday11.Text + "";
                if (thu4 == 1) Monday11.Text = Monday11.Text + "Thứ 4 ";
                else Monday11.Text = Monday11.Text + "";
                if (thu5 == 1) Monday11.Text = Monday11.Text + "Thứ 5 ";
                else Monday11.Text = Monday11.Text + "";
                if (thu6 == 1) Monday11.Text = Monday11.Text + "Thứ 6 ";
                else Monday11.Text = Monday11.Text + "";
                if (thu7 == 1) Monday11.Text = Monday11.Text + "Thứ 7 ";
                else Monday11.Text = Monday11.Text + "";
                if (thu8 == 1) Monday11.Text = Monday11.Text + "Chủ Nhật ";
                else Monday11.Text = Monday11.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath11);
            try
            {
                AnhMuoiMot.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoiMot.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut11_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis11);
            if (like == 1) { LikeBut11.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut11.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON11_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off11);

            if (on_off11 == 1)
            {
                ON11.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off11 = 0; sw.WriteLine("1");
            }
            else
            {
                ON11.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off11 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock12
        Timer tmCLock12 = new Timer() { Interval = 1 };
        int on_off12 = 0; int like12 = 0;// nút like
        String Path_on_off12 = @"Data\BaoThuc\Clock12\On_Off.adb";
        String Like_on_Dis12 = @"Data\BaoThuc\Clock12\Like_Dis.adb";
        String Path_name12 = @"Data\BaoThuc\Clock12\TenBaoThuc.adb";
        String Path_Hou12 = @"Data\BaoThuc\Clock12\hou.adb";
        String Path_Min12 = @"Data\BaoThuc\Clock12\min.adb";
        String Path_Sec12 = @"Data\BaoThuc\Clock12\sec.adb";
        String Path_NhacNgay12 = @"Data\BaoThuc\Clock12\nhacngay.adb";
        String Path_Day12 = @"Data\BaoThuc\Clock12\date.adb";
        String Path_Month12 = @"Data\BaoThuc\Clock12\month.adb";
        String Path_Year12 = @"Data\BaoThuc\Clock12\year.adb";
        String Path_Thu212 = @"Data\BaoThuc\Clock12\thu2.adb";
        String Path_Thu312 = @"Data\BaoThuc\Clock12\thu3.adb";
        String Path_Thu412 = @"Data\BaoThuc\Clock12\thu4.adb";
        String Path_Thu512 = @"Data\BaoThuc\Clock12\thu5.adb";
        String Path_Thu612 = @"Data\BaoThuc\Clock12\thu6.adb";
        String Path_Thu712 = @"Data\BaoThuc\Clock12\thu7.adb";
        String Path_Thu812 = @"Data\BaoThuc\Clock12\thu8.adb";
        String Path_ChiCheck12 = @"Data\BaoThuc\Clock12\chicheck.adb";
        String Path_Anhpath12 = @"Data\BaoThuc\Clock12\AnhPath.adb";

        void LoadClock12()
        {
            LikeBut12.Click += LikeBut12_Click;
            ON12.Click += ON12_Click;
            tmCLock12.Tick += tmCLock12_Tick;
            tmCLock12.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis12);
            like12 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like12 == 1) { LikeBut12.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like12 = 0; }
            else { LikeBut12.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like12 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off12);
            on_off12 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off12 == 1)
            {
                ON12.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off12 = 0;
            }
            else
            {
                ON12.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off12 = 1;
            }
        }

        void tmCLock12_Tick(object sender, EventArgs e)
        {
            tmCLock12.Stop();

            StreamReader srName = new StreamReader(Path_name12);
            Title12.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou12); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min12); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec12); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time12.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay12);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day12); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month12); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year12); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date12.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date12.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu212); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu312); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu412); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu512); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu612); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu712); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu812); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck12); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday12.Text = "";
            if (ChiCheck == 1) Monday12.Text = "";
            else
            {
                if (thu2 == 1) Monday12.Text = Monday12.Text + "Thứ 2 ";
                else Monday12.Text = Monday12.Text + "";
                if (thu3 == 1) Monday12.Text = Monday12.Text + "Thứ 3 ";
                else Monday12.Text = Monday12.Text + "";
                if (thu4 == 1) Monday12.Text = Monday12.Text + "Thứ 4 ";
                else Monday12.Text = Monday12.Text + "";
                if (thu5 == 1) Monday12.Text = Monday12.Text + "Thứ 5 ";
                else Monday12.Text = Monday12.Text + "";
                if (thu6 == 1) Monday12.Text = Monday12.Text + "Thứ 6 ";
                else Monday12.Text = Monday12.Text + "";
                if (thu7 == 1) Monday12.Text = Monday12.Text + "Thứ 7 ";
                else Monday12.Text = Monday12.Text + "";
                if (thu8 == 1) Monday12.Text = Monday12.Text + "Chủ Nhật ";
                else Monday12.Text = Monday12.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath12);
            try
            {
                AnhMuoiHai.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoiHai.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut12_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis12);
            if (like == 1) { LikeBut12.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut12.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON12_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off12);

            if (on_off12 == 1)
            {
                ON12.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off12 = 0; sw.WriteLine("1");
            }
            else
            {
                ON12.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off12 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock13
        Timer tmCLock13 = new Timer() { Interval = 1 };
        int on_off13 = 0; int like13 = 0;// nút like
        String Path_on_off13 = @"Data\BaoThuc\Clock13\On_Off.adb";
        String Like_on_Dis13 = @"Data\BaoThuc\Clock13\Like_Dis.adb";
        String Path_name13 = @"Data\BaoThuc\Clock13\TenBaoThuc.adb";
        String Path_Hou13 = @"Data\BaoThuc\Clock13\hou.adb";
        String Path_Min13 = @"Data\BaoThuc\Clock13\min.adb";
        String Path_Sec13 = @"Data\BaoThuc\Clock13\sec.adb";
        String Path_NhacNgay13 = @"Data\BaoThuc\Clock13\nhacngay.adb";
        String Path_Day13 = @"Data\BaoThuc\Clock13\date.adb";
        String Path_Month13 = @"Data\BaoThuc\Clock13\month.adb";
        String Path_Year13 = @"Data\BaoThuc\Clock13\year.adb";
        String Path_Thu213 = @"Data\BaoThuc\Clock13\thu2.adb";
        String Path_Thu313 = @"Data\BaoThuc\Clock13\thu3.adb";
        String Path_Thu413 = @"Data\BaoThuc\Clock13\thu4.adb";
        String Path_Thu513 = @"Data\BaoThuc\Clock13\thu5.adb";
        String Path_Thu613 = @"Data\BaoThuc\Clock13\thu6.adb";
        String Path_Thu713 = @"Data\BaoThuc\Clock13\thu7.adb";
        String Path_Thu813 = @"Data\BaoThuc\Clock13\thu8.adb";
        String Path_ChiCheck13 = @"Data\BaoThuc\Clock13\chicheck.adb";
        String Path_Anhpath13 = @"Data\BaoThuc\Clock13\AnhPath.adb";

        void LoadClock13()
        {
            LikeBut13.Click += LikeBut13_Click;
            ON13.Click += ON13_Click;
            tmCLock13.Tick += tmCLock13_Tick;
            tmCLock13.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis13);
            like13 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like13 == 1) { LikeBut13.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like13 = 0; }
            else { LikeBut13.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like13 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off13);
            on_off13 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off13 == 1)
            {
                ON13.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off13 = 0;
            }
            else
            {
                ON13.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off13 = 1;
            }
        }

        void tmCLock13_Tick(object sender, EventArgs e)
        {
            tmCLock13.Stop();

            StreamReader srName = new StreamReader(Path_name13);
            Title13.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou13); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min13); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec13); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time13.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay13);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day13); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month13); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year13); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date13.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date13.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu213); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu313); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu413); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu513); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu613); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu713); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu813); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck13); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday13.Text = "";
            if (ChiCheck == 1) Monday13.Text = "";
            else
            {
                if (thu2 == 1) Monday13.Text = Monday13.Text + "Thứ 2 ";
                else Monday13.Text = Monday13.Text + "";
                if (thu3 == 1) Monday13.Text = Monday13.Text + "Thứ 3 ";
                else Monday13.Text = Monday13.Text + "";
                if (thu4 == 1) Monday13.Text = Monday13.Text + "Thứ 4 ";
                else Monday13.Text = Monday13.Text + "";
                if (thu5 == 1) Monday13.Text = Monday13.Text + "Thứ 5 ";
                else Monday13.Text = Monday13.Text + "";
                if (thu6 == 1) Monday13.Text = Monday13.Text + "Thứ 6 ";
                else Monday13.Text = Monday13.Text + "";
                if (thu7 == 1) Monday13.Text = Monday13.Text + "Thứ 7 ";
                else Monday13.Text = Monday13.Text + "";
                if (thu8 == 1) Monday13.Text = Monday13.Text + "Chủ Nhật ";
                else Monday13.Text = Monday13.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath13);
            try
            {
                AnhMuoiBa.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoiBa.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut13_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis13);
            if (like == 1) { LikeBut13.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut13.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON13_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off13);

            if (on_off13 == 1)
            {
                ON13.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off13 = 0; sw.WriteLine("1");
            }
            else
            {
                ON13.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off13 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock14
        Timer tmCLock14 = new Timer() { Interval = 1 };
        int on_off14 = 0; int like14 = 0;// nút like
        String Path_on_off14 = @"Data\BaoThuc\Clock14\On_Off.adb";
        String Like_on_Dis14 = @"Data\BaoThuc\Clock14\Like_Dis.adb";
        String Path_name14 = @"Data\BaoThuc\Clock14\TenBaoThuc.adb";
        String Path_Hou14 = @"Data\BaoThuc\Clock14\hou.adb";
        String Path_Min14 = @"Data\BaoThuc\Clock14\min.adb";
        String Path_Sec14 = @"Data\BaoThuc\Clock14\sec.adb";
        String Path_NhacNgay14 = @"Data\BaoThuc\Clock14\nhacngay.adb";
        String Path_Day14 = @"Data\BaoThuc\Clock14\date.adb";
        String Path_Month14 = @"Data\BaoThuc\Clock14\month.adb";
        String Path_Year14 = @"Data\BaoThuc\Clock14\year.adb";
        String Path_Thu214 = @"Data\BaoThuc\Clock14\thu2.adb";
        String Path_Thu314 = @"Data\BaoThuc\Clock14\thu3.adb";
        String Path_Thu414 = @"Data\BaoThuc\Clock14\thu4.adb";
        String Path_Thu514 = @"Data\BaoThuc\Clock14\thu5.adb";
        String Path_Thu614 = @"Data\BaoThuc\Clock14\thu6.adb";
        String Path_Thu714 = @"Data\BaoThuc\Clock14\thu7.adb";
        String Path_Thu814 = @"Data\BaoThuc\Clock14\thu8.adb";
        String Path_ChiCheck14 = @"Data\BaoThuc\Clock14\chicheck.adb";
        String Path_Anhpath14 = @"Data\BaoThuc\Clock14\AnhPath.adb";

        void LoadClock14()
        {
            LikeBut14.Click += LikeBut14_Click;
            ON14.Click += ON14_Click;
            tmCLock14.Tick += tmCLock14_Tick;
            tmCLock14.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis14);
            like14 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like14 == 1) { LikeBut14.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like14 = 0; }
            else { LikeBut14.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like14 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off14);
            on_off14 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off14 == 1)
            {
                ON14.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off14 = 0;
            }
            else
            {
                ON14.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off14 = 1;
            }
        }

        void tmCLock14_Tick(object sender, EventArgs e)
        {
            tmCLock14.Stop();

            StreamReader srName = new StreamReader(Path_name14);
            Title14.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou14); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min14); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec14); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time14.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay14);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day14); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month14); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year14); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date14.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date14.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu214); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu314); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu414); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu514); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu614); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu714); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu814); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck14); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday14.Text = "";
            if (ChiCheck == 1) Monday14.Text = "";
            else
            {
                if (thu2 == 1) Monday14.Text = Monday14.Text + "Thứ 2 ";
                else Monday14.Text = Monday14.Text + "";
                if (thu3 == 1) Monday14.Text = Monday14.Text + "Thứ 3 ";
                else Monday14.Text = Monday14.Text + "";
                if (thu4 == 1) Monday14.Text = Monday14.Text + "Thứ 4 ";
                else Monday14.Text = Monday14.Text + "";
                if (thu5 == 1) Monday14.Text = Monday14.Text + "Thứ 5 ";
                else Monday14.Text = Monday14.Text + "";
                if (thu6 == 1) Monday14.Text = Monday14.Text + "Thứ 6 ";
                else Monday14.Text = Monday14.Text + "";
                if (thu7 == 1) Monday14.Text = Monday14.Text + "Thứ 7 ";
                else Monday14.Text = Monday14.Text + "";
                if (thu8 == 1) Monday14.Text = Monday14.Text + "Chủ Nhật ";
                else Monday14.Text = Monday14.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath14);
            try
            {
                AnhMuoiBon.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoiBon.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut14_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis14);
            if (like == 1) { LikeBut14.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut14.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON14_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off14);

            if (on_off14 == 1)
            {
                ON14.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off14 = 0; sw.WriteLine("1");
            }
            else
            {
                ON14.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off14 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock15
        Timer tmCLock15 = new Timer() { Interval = 1 };
        int on_off15 = 0; int like15 = 0;// nút like
        String Path_on_off15 = @"Data\BaoThuc\Clock15\On_Off.adb";
        String Like_on_Dis15 = @"Data\BaoThuc\Clock15\Like_Dis.adb";
        String Path_name15 = @"Data\BaoThuc\Clock15\TenBaoThuc.adb";
        String Path_Hou15 = @"Data\BaoThuc\Clock15\hou.adb";
        String Path_Min15 = @"Data\BaoThuc\Clock15\min.adb";
        String Path_Sec15 = @"Data\BaoThuc\Clock15\sec.adb";
        String Path_NhacNgay15 = @"Data\BaoThuc\Clock15\nhacngay.adb";
        String Path_Day15 = @"Data\BaoThuc\Clock15\date.adb";
        String Path_Month15 = @"Data\BaoThuc\Clock15\month.adb";
        String Path_Year15 = @"Data\BaoThuc\Clock15\year.adb";
        String Path_Thu215 = @"Data\BaoThuc\Clock15\thu2.adb";
        String Path_Thu315 = @"Data\BaoThuc\Clock15\thu3.adb";
        String Path_Thu415 = @"Data\BaoThuc\Clock15\thu4.adb";
        String Path_Thu515 = @"Data\BaoThuc\Clock15\thu5.adb";
        String Path_Thu615 = @"Data\BaoThuc\Clock15\thu6.adb";
        String Path_Thu715 = @"Data\BaoThuc\Clock15\thu7.adb";
        String Path_Thu815 = @"Data\BaoThuc\Clock15\thu8.adb";
        String Path_ChiCheck15 = @"Data\BaoThuc\Clock15\chicheck.adb";
        String Path_Anhpath15 = @"Data\BaoThuc\Clock15\AnhPath.adb";

        void LoadClock15()
        {
            LikeBut15.Click += LikeBut15_Click;
            ON15.Click += ON15_Click;
            tmCLock15.Tick += tmCLock15_Tick;
            tmCLock15.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis15);
            like15 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like15 == 1) { LikeBut15.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like15 = 0; }
            else { LikeBut15.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like15 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off15);
            on_off15 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off15 == 1)
            {
                ON15.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off15 = 0;
            }
            else
            {
                ON15.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off15 = 1;
            }
        }

        void tmCLock15_Tick(object sender, EventArgs e)
        {
            tmCLock15.Stop();

            StreamReader srName = new StreamReader(Path_name15);
            Title15.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou15); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min15); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec15); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time15.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay15);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day15); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month15); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year15); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date15.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date15.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu215); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu315); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu415); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu515); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu615); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu715); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu815); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck15); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday15.Text = "";
            if (ChiCheck == 1) Monday15.Text = "";
            else
            {
                if (thu2 == 1) Monday15.Text = Monday15.Text + "Thứ 2 ";
                else Monday15.Text = Monday15.Text + "";
                if (thu3 == 1) Monday15.Text = Monday15.Text + "Thứ 3 ";
                else Monday15.Text = Monday15.Text + "";
                if (thu4 == 1) Monday15.Text = Monday15.Text + "Thứ 4 ";
                else Monday15.Text = Monday15.Text + "";
                if (thu5 == 1) Monday15.Text = Monday15.Text + "Thứ 5 ";
                else Monday15.Text = Monday15.Text + "";
                if (thu6 == 1) Monday15.Text = Monday15.Text + "Thứ 6 ";
                else Monday15.Text = Monday15.Text + "";
                if (thu7 == 1) Monday15.Text = Monday15.Text + "Thứ 7 ";
                else Monday15.Text = Monday15.Text + "";
                if (thu8 == 1) Monday15.Text = Monday15.Text + "Chủ Nhật ";
                else Monday15.Text = Monday15.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath15);
            try
            {
                AnhMuoiNam.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoiNam.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut15_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis15);
            if (like == 1) { LikeBut15.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut15.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON15_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off15);

            if (on_off15 == 1)
            {
                ON15.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off15 = 0; sw.WriteLine("1");
            }
            else
            {
                ON15.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off15 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock16
        Timer tmCLock16 = new Timer() { Interval = 1 };
        int on_off16 = 0; int like16 = 0;// nút like
        String Path_on_off16 = @"Data\BaoThuc\Clock16\On_Off.adb";
        String Like_on_Dis16 = @"Data\BaoThuc\Clock16\Like_Dis.adb";
        String Path_name16 = @"Data\BaoThuc\Clock16\TenBaoThuc.adb";
        String Path_Hou16 = @"Data\BaoThuc\Clock16\hou.adb";
        String Path_Min16 = @"Data\BaoThuc\Clock16\min.adb";
        String Path_Sec16 = @"Data\BaoThuc\Clock16\sec.adb";
        String Path_NhacNgay16 = @"Data\BaoThuc\Clock16\nhacngay.adb";
        String Path_Day16 = @"Data\BaoThuc\Clock16\date.adb";
        String Path_Month16 = @"Data\BaoThuc\Clock16\month.adb";
        String Path_Year16 = @"Data\BaoThuc\Clock16\year.adb";
        String Path_Thu216 = @"Data\BaoThuc\Clock16\thu2.adb";
        String Path_Thu316 = @"Data\BaoThuc\Clock16\thu3.adb";
        String Path_Thu416 = @"Data\BaoThuc\Clock16\thu4.adb";
        String Path_Thu516 = @"Data\BaoThuc\Clock16\thu5.adb";
        String Path_Thu616 = @"Data\BaoThuc\Clock16\thu6.adb";
        String Path_Thu716 = @"Data\BaoThuc\Clock16\thu7.adb";
        String Path_Thu816 = @"Data\BaoThuc\Clock16\thu8.adb";
        String Path_ChiCheck16 = @"Data\BaoThuc\Clock16\chicheck.adb";
        String Path_Anhpath16 = @"Data\BaoThuc\Clock16\AnhPath.adb";

        void LoadClock16()
        {
            LikeBut16.Click += LikeBut16_Click;
            ON16.Click += ON16_Click;
            tmCLock16.Tick += tmCLock16_Tick;
            tmCLock16.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis16);
            like16 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like16 == 1) { LikeBut16.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like16 = 0; }
            else { LikeBut16.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like16 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off16);
            on_off16 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off16 == 1)
            {
                ON16.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off16 = 0;
            }
            else
            {
                ON16.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off16 = 1;
            }
        }

        void tmCLock16_Tick(object sender, EventArgs e)
        {
            tmCLock16.Stop();

            StreamReader srName = new StreamReader(Path_name16);
            Title16.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou16); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min16); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec16); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time16.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay16);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day16); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month16); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year16); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date16.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date16.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu216); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu316); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu416); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu516); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu616); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu716); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu816); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck16); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday16.Text = "";
            if (ChiCheck == 1) Monday16.Text = "";
            else
            {
                if (thu2 == 1) Monday16.Text = Monday16.Text + "Thứ 2 ";
                else Monday16.Text = Monday16.Text + "";
                if (thu3 == 1) Monday16.Text = Monday16.Text + "Thứ 3 ";
                else Monday16.Text = Monday16.Text + "";
                if (thu4 == 1) Monday16.Text = Monday16.Text + "Thứ 4 ";
                else Monday16.Text = Monday16.Text + "";
                if (thu5 == 1) Monday16.Text = Monday16.Text + "Thứ 5 ";
                else Monday16.Text = Monday16.Text + "";
                if (thu6 == 1) Monday16.Text = Monday16.Text + "Thứ 6 ";
                else Monday16.Text = Monday16.Text + "";
                if (thu7 == 1) Monday16.Text = Monday16.Text + "Thứ 7 ";
                else Monday16.Text = Monday16.Text + "";
                if (thu8 == 1) Monday16.Text = Monday16.Text + "Chủ Nhật ";
                else Monday16.Text = Monday16.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath16);
            try
            {
                AnhMuoiSau.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoiSau.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut16_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis16);
            if (like == 1) { LikeBut16.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut16.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON16_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off16);

            if (on_off16 == 1)
            {
                ON16.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off16 = 0; sw.WriteLine("1");
            }
            else
            {
                ON16.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off16 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock17
        Timer tmCLock17 = new Timer() { Interval = 1 };
        int on_off17 = 0; int like17 = 0;// nút like
        String Path_on_off17 = @"Data\BaoThuc\Clock17\On_Off.adb";
        String Like_on_Dis17 = @"Data\BaoThuc\Clock17\Like_Dis.adb";
        String Path_name17 = @"Data\BaoThuc\Clock17\TenBaoThuc.adb";
        String Path_Hou17 = @"Data\BaoThuc\Clock17\hou.adb";
        String Path_Min17 = @"Data\BaoThuc\Clock17\min.adb";
        String Path_Sec17 = @"Data\BaoThuc\Clock17\sec.adb";
        String Path_NhacNgay17 = @"Data\BaoThuc\Clock17\nhacngay.adb";
        String Path_Day17 = @"Data\BaoThuc\Clock17\date.adb";
        String Path_Month17 = @"Data\BaoThuc\Clock17\month.adb";
        String Path_Year17 = @"Data\BaoThuc\Clock17\year.adb";
        String Path_Thu217 = @"Data\BaoThuc\Clock17\thu2.adb";
        String Path_Thu317 = @"Data\BaoThuc\Clock17\thu3.adb";
        String Path_Thu417 = @"Data\BaoThuc\Clock17\thu4.adb";
        String Path_Thu517 = @"Data\BaoThuc\Clock17\thu5.adb";
        String Path_Thu617 = @"Data\BaoThuc\Clock17\thu6.adb";
        String Path_Thu717 = @"Data\BaoThuc\Clock17\thu7.adb";
        String Path_Thu817 = @"Data\BaoThuc\Clock17\thu8.adb";
        String Path_ChiCheck17 = @"Data\BaoThuc\Clock17\chicheck.adb";
        String Path_Anhpath17 = @"Data\BaoThuc\Clock17\AnhPath.adb";

        void LoadClock17()
        {
            LikeBut17.Click += LikeBut17_Click;
            ON17.Click += ON17_Click;
            tmCLock17.Tick += tmCLock17_Tick;
            tmCLock17.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis17);
            like17 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like17 == 1) { LikeBut17.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like17 = 0; }
            else { LikeBut17.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like17 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off17);
            on_off17 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off17 == 1)
            {
                ON17.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off17 = 0;
            }
            else
            {
                ON17.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off17 = 1;
            }
        }

        void tmCLock17_Tick(object sender, EventArgs e)
        {
            tmCLock17.Stop();

            StreamReader srName = new StreamReader(Path_name17);
            Title17.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou17); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min17); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec17); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time17.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay17);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day17); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month17); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year17); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date17.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date17.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu217); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu317); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu417); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu517); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu617); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu717); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu817); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck17); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday17.Text = "";
            if (ChiCheck == 1) Monday17.Text = "";
            else
            {
                if (thu2 == 1) Monday17.Text = Monday17.Text + "Thứ 2 ";
                else Monday17.Text = Monday17.Text + "";
                if (thu3 == 1) Monday17.Text = Monday17.Text + "Thứ 3 ";
                else Monday17.Text = Monday17.Text + "";
                if (thu4 == 1) Monday17.Text = Monday17.Text + "Thứ 4 ";
                else Monday17.Text = Monday17.Text + "";
                if (thu5 == 1) Monday17.Text = Monday17.Text + "Thứ 5 ";
                else Monday17.Text = Monday17.Text + "";
                if (thu6 == 1) Monday17.Text = Monday17.Text + "Thứ 6 ";
                else Monday17.Text = Monday17.Text + "";
                if (thu7 == 1) Monday17.Text = Monday17.Text + "Thứ 7 ";
                else Monday17.Text = Monday17.Text + "";
                if (thu8 == 1) Monday17.Text = Monday17.Text + "Chủ Nhật ";
                else Monday17.Text = Monday17.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath17);
            try
            {
                AnhMuoiBay.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoiBay.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut17_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis17);
            if (like == 1) { LikeBut17.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut17.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON17_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off17);

            if (on_off17 == 1)
            {
                ON17.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off17 = 0; sw.WriteLine("1");
            }
            else
            {
                ON17.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off17 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock18
        Timer tmCLock18 = new Timer() { Interval = 1 };
        int on_off18 = 0; int like18 = 0;// nút like
        String Path_on_off18 = @"Data\BaoThuc\Clock18\On_Off.adb";
        String Like_on_Dis18 = @"Data\BaoThuc\Clock18\Like_Dis.adb";
        String Path_name18 = @"Data\BaoThuc\Clock18\TenBaoThuc.adb";
        String Path_Hou18 = @"Data\BaoThuc\Clock18\hou.adb";
        String Path_Min18 = @"Data\BaoThuc\Clock18\min.adb";
        String Path_Sec18 = @"Data\BaoThuc\Clock18\sec.adb";
        String Path_NhacNgay18 = @"Data\BaoThuc\Clock18\nhacngay.adb";
        String Path_Day18 = @"Data\BaoThuc\Clock18\date.adb";
        String Path_Month18 = @"Data\BaoThuc\Clock18\month.adb";
        String Path_Year18 = @"Data\BaoThuc\Clock18\year.adb";
        String Path_Thu218 = @"Data\BaoThuc\Clock18\thu2.adb";
        String Path_Thu318 = @"Data\BaoThuc\Clock18\thu3.adb";
        String Path_Thu418 = @"Data\BaoThuc\Clock18\thu4.adb";
        String Path_Thu518 = @"Data\BaoThuc\Clock18\thu5.adb";
        String Path_Thu618 = @"Data\BaoThuc\Clock18\thu6.adb";
        String Path_Thu718 = @"Data\BaoThuc\Clock18\thu7.adb";
        String Path_Thu818 = @"Data\BaoThuc\Clock18\thu8.adb";
        String Path_ChiCheck18 = @"Data\BaoThuc\Clock18\chicheck.adb";
        String Path_Anhpath18 = @"Data\BaoThuc\Clock18\AnhPath.adb";

        void LoadClock18()
        {
            LikeBut18.Click += LikeBut18_Click;
            ON18.Click += ON18_Click;
            tmCLock18.Tick += tmCLock18_Tick;
            tmCLock18.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis18);
            like18 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like18 == 1) { LikeBut18.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like18 = 0; }
            else { LikeBut18.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like18 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off18);
            on_off18 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off18 == 1)
            {
                ON18.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off18 = 0;
            }
            else
            {
                ON18.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off18 = 1;
            }
        }

        void tmCLock18_Tick(object sender, EventArgs e)
        {
            tmCLock18.Stop();

            StreamReader srName = new StreamReader(Path_name18);
            Title18.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou18); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min18); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec18); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time18.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay18);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day18); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month18); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year18); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date18.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date18.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu218); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu318); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu418); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu518); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu618); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu718); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu818); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck18); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday18.Text = "";
            if (ChiCheck == 1) Monday18.Text = "";
            else
            {
                if (thu2 == 1) Monday18.Text = Monday18.Text + "Thứ 2 ";
                else Monday18.Text = Monday18.Text + "";
                if (thu3 == 1) Monday18.Text = Monday18.Text + "Thứ 3 ";
                else Monday18.Text = Monday18.Text + "";
                if (thu4 == 1) Monday18.Text = Monday18.Text + "Thứ 4 ";
                else Monday18.Text = Monday18.Text + "";
                if (thu5 == 1) Monday18.Text = Monday18.Text + "Thứ 5 ";
                else Monday18.Text = Monday18.Text + "";
                if (thu6 == 1) Monday18.Text = Monday18.Text + "Thứ 6 ";
                else Monday18.Text = Monday18.Text + "";
                if (thu7 == 1) Monday18.Text = Monday18.Text + "Thứ 7 ";
                else Monday18.Text = Monday18.Text + "";
                if (thu8 == 1) Monday18.Text = Monday18.Text + "Chủ Nhật ";
                else Monday18.Text = Monday18.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath18);
            try
            {
                AnhMuoiTam.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoiTam.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut18_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis18);
            if (like == 1) { LikeBut18.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut18.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON18_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off18);

            if (on_off18 == 1)
            {
                ON18.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off18 = 0; sw.WriteLine("1");
            }
            else
            {
                ON18.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off18 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock19
        Timer tmCLock19 = new Timer() { Interval = 1 };
        int on_off19 = 0; int like19 = 0;// nút like
        String Path_on_off19 = @"Data\BaoThuc\Clock19\On_Off.adb";
        String Like_on_Dis19 = @"Data\BaoThuc\Clock19\Like_Dis.adb";
        String Path_name19 = @"Data\BaoThuc\Clock19\TenBaoThuc.adb";
        String Path_Hou19 = @"Data\BaoThuc\Clock19\hou.adb";
        String Path_Min19 = @"Data\BaoThuc\Clock19\min.adb";
        String Path_Sec19 = @"Data\BaoThuc\Clock19\sec.adb";
        String Path_NhacNgay19 = @"Data\BaoThuc\Clock19\nhacngay.adb";
        String Path_Day19 = @"Data\BaoThuc\Clock19\date.adb";
        String Path_Month19 = @"Data\BaoThuc\Clock19\month.adb";
        String Path_Year19 = @"Data\BaoThuc\Clock19\year.adb";
        String Path_Thu219 = @"Data\BaoThuc\Clock19\thu2.adb";
        String Path_Thu319 = @"Data\BaoThuc\Clock19\thu3.adb";
        String Path_Thu419 = @"Data\BaoThuc\Clock19\thu4.adb";
        String Path_Thu519 = @"Data\BaoThuc\Clock19\thu5.adb";
        String Path_Thu619 = @"Data\BaoThuc\Clock19\thu6.adb";
        String Path_Thu719 = @"Data\BaoThuc\Clock19\thu7.adb";
        String Path_Thu819 = @"Data\BaoThuc\Clock19\thu8.adb";
        String Path_ChiCheck19 = @"Data\BaoThuc\Clock19\chicheck.adb";
        String Path_Anhpath19 = @"Data\BaoThuc\Clock19\AnhPath.adb";

        void LoadClock19()
        {
            LikeBut19.Click += LikeBut19_Click;
            ON19.Click += ON19_Click;
            tmCLock19.Tick += tmCLock19_Tick;
            tmCLock19.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis19);
            like19 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like19 == 1) { LikeBut19.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like19 = 0; }
            else { LikeBut19.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like19 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off19);
            on_off19 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off19 == 1)
            {
                ON19.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off19 = 0;
            }
            else
            {
                ON19.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off19 = 1;
            }
        }

        void tmCLock19_Tick(object sender, EventArgs e)
        {
            tmCLock19.Stop();

            StreamReader srName = new StreamReader(Path_name19);
            Title19.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou19); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min19); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec19); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time19.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay19);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day19); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month19); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year19); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date19.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date19.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu219); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu319); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu419); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu519); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu619); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu719); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu819); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck19); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday19.Text = "";
            if (ChiCheck == 1) Monday19.Text = "";
            else
            {
                if (thu2 == 1) Monday19.Text = Monday19.Text + "Thứ 2 ";
                else Monday19.Text = Monday19.Text + "";
                if (thu3 == 1) Monday19.Text = Monday19.Text + "Thứ 3 ";
                else Monday19.Text = Monday19.Text + "";
                if (thu4 == 1) Monday19.Text = Monday19.Text + "Thứ 4 ";
                else Monday19.Text = Monday19.Text + "";
                if (thu5 == 1) Monday19.Text = Monday19.Text + "Thứ 5 ";
                else Monday19.Text = Monday19.Text + "";
                if (thu6 == 1) Monday19.Text = Monday19.Text + "Thứ 6 ";
                else Monday19.Text = Monday19.Text + "";
                if (thu7 == 1) Monday19.Text = Monday19.Text + "Thứ 7 ";
                else Monday19.Text = Monday19.Text + "";
                if (thu8 == 1) Monday19.Text = Monday19.Text + "Chủ Nhật ";
                else Monday19.Text = Monday19.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath19);
            try
            {
                AnhMuoiChin.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhMuoiChin.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut19_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis19);
            if (like == 1) { LikeBut19.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut19.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON19_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off19);

            if (on_off19 == 1)
            {
                ON19.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off19 = 0; sw.WriteLine("1");
            }
            else
            {
                ON19.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off19 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion
        #region Clock20
        Timer tmCLock20 = new Timer() { Interval = 1 };
        int on_off20 = 0; int like20 = 0;// nút like
        String Path_on_off20 = @"Data\BaoThuc\Clock20\On_Off.adb";
        String Like_on_Dis20 = @"Data\BaoThuc\Clock20\Like_Dis.adb";
        String Path_name20 = @"Data\BaoThuc\Clock20\TenBaoThuc.adb";
        String Path_Hou20 = @"Data\BaoThuc\Clock20\hou.adb";
        String Path_Min20 = @"Data\BaoThuc\Clock20\min.adb";
        String Path_Sec20 = @"Data\BaoThuc\Clock20\sec.adb";
        String Path_NhacNgay20 = @"Data\BaoThuc\Clock20\nhacngay.adb";
        String Path_Day20 = @"Data\BaoThuc\Clock20\date.adb";
        String Path_Month20 = @"Data\BaoThuc\Clock20\month.adb";
        String Path_Year20 = @"Data\BaoThuc\Clock20\year.adb";
        String Path_Thu220 = @"Data\BaoThuc\Clock20\thu2.adb";
        String Path_Thu320 = @"Data\BaoThuc\Clock20\thu3.adb";
        String Path_Thu420 = @"Data\BaoThuc\Clock20\thu4.adb";
        String Path_Thu520 = @"Data\BaoThuc\Clock20\thu5.adb";
        String Path_Thu620 = @"Data\BaoThuc\Clock20\thu6.adb";
        String Path_Thu720 = @"Data\BaoThuc\Clock20\thu7.adb";
        String Path_Thu820 = @"Data\BaoThuc\Clock20\thu8.adb";
        String Path_ChiCheck20 = @"Data\BaoThuc\Clock20\chicheck.adb";
        String Path_Anhpath20 = @"Data\BaoThuc\Clock20\AnhPath.adb";

        void LoadClock20()
        {
            LikeBut20.Click += LikeBut20_Click;
            ON20.Click += ON20_Click;
            tmCLock20.Tick += tmCLock20_Tick;
            tmCLock20.Start();
            StreamReader srLikeDis = new StreamReader(Like_on_Dis20);
            like20 = Convert.ToInt32(srLikeDis.ReadLine());
            srLikeDis.Close();
            if (like20 == 1) { LikeBut20.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like20 = 0; }
            else { LikeBut20.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like20 = 1; }

            StreamReader srOn_Off = new StreamReader(Path_on_off20);
            on_off20 = Convert.ToInt32(srOn_Off.ReadLine());
            srOn_Off.Close();
            if (on_off20 == 1)
            {
                ON20.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off20 = 0;
            }
            else
            {
                ON20.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off20 = 1;
            }
        }

        void tmCLock20_Tick(object sender, EventArgs e)
        {
            tmCLock20.Stop();

            StreamReader srName = new StreamReader(Path_name20);
            Title20.Text = srName.ReadLine();
            srName.Close();
            StreamReader srHou = new StreamReader(Path_Hou20); int hoU = Convert.ToInt32(srHou.ReadLine()); srHou.Close();
            StreamReader srMin = new StreamReader(Path_Min20); int miN = Convert.ToInt32(srMin.ReadLine()); srMin.Close();
            StreamReader srSec = new StreamReader(Path_Sec20); int seC = Convert.ToInt32(srSec.ReadLine()); srSec.Close();
            DateTime dtime = Convert.ToDateTime(hoU + ":" + miN + ":" + seC);
            Time20.Text = dtime.ToString("HH:mm");
            StreamReader srNhacNgay = new StreamReader(Path_NhacNgay20);
            int Checked = Convert.ToInt32(srNhacNgay.ReadLine());
            srNhacNgay.Close();
            if (Checked == 1)
            {
                StreamReader srDay = new StreamReader(Path_Day20); int day = Convert.ToInt32(srDay.ReadLine()); srDay.Close();
                StreamReader srMonth = new StreamReader(Path_Month20); int month = Convert.ToInt32(srMonth.ReadLine()); srMonth.Close();
                StreamReader srYear = new StreamReader(Path_Year20); int year = Convert.ToInt32(srYear.ReadLine()); srYear.Close();
                DateTime datet = new DateTime(year, month, day);
                Date20.Text = datet.ToString("dd/MM/yyyy");
            }
            else Date20.Text = "";

            StreamReader srThu2 = new StreamReader(Path_Thu220); int thu2 = Convert.ToInt32(srThu2.ReadLine()); srThu2.Close();
            StreamReader srThu3 = new StreamReader(Path_Thu320); int thu3 = Convert.ToInt32(srThu3.ReadLine()); srThu3.Close();
            StreamReader srThu4 = new StreamReader(Path_Thu420); int thu4 = Convert.ToInt32(srThu4.ReadLine()); srThu4.Close();
            StreamReader srThu5 = new StreamReader(Path_Thu520); int thu5 = Convert.ToInt32(srThu5.ReadLine()); srThu5.Close();
            StreamReader srThu6 = new StreamReader(Path_Thu620); int thu6 = Convert.ToInt32(srThu6.ReadLine()); srThu6.Close();
            StreamReader srThu7 = new StreamReader(Path_Thu720); int thu7 = Convert.ToInt32(srThu7.ReadLine()); srThu7.Close();
            StreamReader srThu8 = new StreamReader(Path_Thu820); int thu8 = Convert.ToInt32(srThu8.ReadLine()); srThu8.Close();
            StreamReader srChiCheck = new StreamReader(Path_ChiCheck20); int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine()); srChiCheck.Close();

            Monday20.Text = "";
            if (ChiCheck == 1) Monday20.Text = "";
            else
            {
                if (thu2 == 1) Monday20.Text = Monday20.Text + "Thứ 2 ";
                else Monday20.Text = Monday20.Text + "";
                if (thu3 == 1) Monday20.Text = Monday20.Text + "Thứ 3 ";
                else Monday20.Text = Monday20.Text + "";
                if (thu4 == 1) Monday20.Text = Monday20.Text + "Thứ 4 ";
                else Monday20.Text = Monday20.Text + "";
                if (thu5 == 1) Monday20.Text = Monday20.Text + "Thứ 5 ";
                else Monday20.Text = Monday20.Text + "";
                if (thu6 == 1) Monday20.Text = Monday20.Text + "Thứ 6 ";
                else Monday20.Text = Monday20.Text + "";
                if (thu7 == 1) Monday20.Text = Monday20.Text + "Thứ 7 ";
                else Monday20.Text = Monday20.Text + "";
                if (thu8 == 1) Monday20.Text = Monday20.Text + "Chủ Nhật ";
                else Monday20.Text = Monday20.Text + "";
            }
            StreamReader srAnhPath = new StreamReader(Path_Anhpath20);
            try
            {
                AnhHaiMuoi.Image = new Bitmap(Application.StartupPath + "\\" + srAnhPath.ReadLine());
            }
            catch
            {
                AnhHaiMuoi.Image = new Bitmap(Application.StartupPath + @"\Data\BaoThuc\AnhBaoTHUc\MacDinh.png");
            }
            srAnhPath.Close();

        }


        private void LikeBut20_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Like_on_Dis20);
            if (like == 1) { LikeBut20.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\like.png"); like = 0; sw.WriteLine("1"); }
            else { LikeBut20.BackgroundImage = new Bitmap(Application.StartupPath + "\\data\\user\\anh\\dislike.png"); like = 1; sw.WriteLine("0"); }
            sw.Close();
        }


        private void ON20_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path_on_off20);

            if (on_off20 == 1)
            {
                ON20.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + ON_OFF); on_off20 = 0; sw.WriteLine("1");
            }
            else
            {
                ON20.BackgroundImage = new Bitmap(Application.StartupPath + "\\" + OFF_ON); on_off20 = 1; sw.WriteLine("0");
            }
            sw.Close();
        }

        #endregion

        void stopSou()
        {
            if (play == 0)
            {
                sou.Stop(); PlayBut.Text = "|>"; play = 1;
            }
        }
        void StopSouAndStartISong()
        {
            Isong.Start();
            try
            {
                stopSou();
            }
            catch { }
        }
        private void HuyButton_Click(object sender, EventArgs e)
        {
            StopSouAndStartISong();
            panel12.Visible = false; iu = -1;
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
        }
        private void ClockMot_Click(object sender, EventArgs e)
        {
            iu = 1;
            StopSouAndStartISong();
            Clock1.BackColor = Color.FromArgb(70, 82, 157);
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }

        private void ClockHai_Click(object sender, EventArgs e)
        {
            iu = 2; StopSouAndStartISong();
            Clock2.BackColor = Color.FromArgb(70, 82, 157);
            Clock1.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }

        private void ClockBa_Click(object sender, EventArgs e)
        {
            iu = 3; StopSouAndStartISong();
            Clock2.BackColor = Color.White;
            Clock1.BackColor = Color.White;
            Clock3.BackColor = Color.FromArgb(70, 82, 157);
            Clock4.BackColor = Color.White;
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void ClockBon_Click(object sender, EventArgs e)
        {
            iu = 4; StopSouAndStartISong();
            Clock2.BackColor = Color.White;
            Clock1.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void Clock5_Click(object sender, EventArgs e)
        {
            iu = 5; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock5.BackColor = Color.FromArgb(70, 82, 157);
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void ClockSau_Click(object sender, EventArgs e)
        {
            iu = 6; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock6.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void ClockBay_Click(object sender, EventArgs e)
        {
            iu = 7; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock7.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void ClockTam_Click(object sender, EventArgs e)
        {
            iu = 8; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock8.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void ClockChin_Click(object sender, EventArgs e)
        {
            iu = 9; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock9.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void ClockMuoi_Click(object sender, EventArgs e)
        {
            iu = 10; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock10.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void Clock1Mot_Click(object sender, EventArgs e)
        {
            iu = 11; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock11.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void Clock1Hai_Click(object sender, EventArgs e)
        {
            iu = 12; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock12.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        private void Clock1Ba_Click(object sender, EventArgs e)
        {
            iu = 13; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock13.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }
        #region LichButon
        private void LichMot_Click(object sender, EventArgs e)
        {
            StreamWriter srChoice = new StreamWriter(@"Data\LichText\Choice.adb");
            srChoice.WriteLine("1");
            srChoice.Close();
            LichLabelSetting setting = new LichLabelSetting();
            setting.Show();

        }

        private void Lich1_Click(object sender, EventArgs e)
        {
            StreamWriter srChoice = new StreamWriter(@"Data\LichText\Choice.adb");
            srChoice.WriteLine("1");
            srChoice.Close();
            LichLabelSetting setting = new LichLabelSetting();
            setting.Show();
        }

        private void Lich2_Click(object sender, EventArgs e)
        {
            StreamWriter srChoice = new StreamWriter(@"Data\LichText\Choice.adb");
            srChoice.WriteLine("2");
            srChoice.Close();
            LichLabelSetting setting = new LichLabelSetting();
            setting.Show();
        }

        private void Lich3_Click(object sender, EventArgs e)
        {
            StreamWriter srChoice = new StreamWriter(@"Data\LichText\Choice.adb");
            srChoice.WriteLine("3");
            srChoice.Close();
            LichLabelSetting setting = new LichLabelSetting();
            setting.Show();
        }
        #endregion


        private void ClockBay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Clock10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Clock1Bon_Click(object sender, EventArgs e)
        {
            iu = 14; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock14.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }

        private void Clock1Nam_Click(object sender, EventArgs e)
        {
            iu = 15; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock15.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }

        private void Clock1Sau_Click(object sender, EventArgs e)
        {
            iu = 16; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock16.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }

        private void Clock1Bay_Click(object sender, EventArgs e)
        {
            iu = 17; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock17.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }

        private void Clock1Tam_Click(object sender, EventArgs e)
        {
            iu = 18; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock18.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }

        private void Clock1Chin_Click(object sender, EventArgs e)
        {
            iu = 19; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock19.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            Clock20.BackColor = Color.White;
            CaiDatDate();
        }

        private void Clock1Muoi_Click(object sender, EventArgs e)
        {
            iu = 20; StopSouAndStartISong();
            Clock1.BackColor = Color.White;
            Clock2.BackColor = Color.White;
            Clock3.BackColor = Color.White;
            Clock4.BackColor = Color.White;
            Clock20.BackColor = Color.FromArgb(70, 82, 157);
            Clock5.BackColor = Color.White;
            Clock6.BackColor = Color.White;
            Clock7.BackColor = Color.White;
            Clock8.BackColor = Color.White;
            Clock9.BackColor = Color.White;
            Clock10.BackColor = Color.White;
            Clock11.BackColor = Color.White;
            Clock13.BackColor = Color.White;
            Clock14.BackColor = Color.White;
            Clock15.BackColor = Color.White;
            Clock16.BackColor = Color.White;
            Clock17.BackColor = Color.White;
            Clock18.BackColor = Color.White;
            Clock19.BackColor = Color.White;
            Clock12.BackColor = Color.White;
            CaiDatDate();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//thêm phím tắt
        {
            if (keyData == (Keys.Delete) || keyData == (Keys.Control | Keys.W) || keyData == (Keys.Control | Keys.D))
            {
                ButtonDel(); return true;
            }
            if (keyData == (Keys.Control | Keys.N))
            {
                ButtonAdd();
                return true;
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                try
                {
                    ButtonSave();
                }
                catch
                {
                    MessageBox.Show("Bạn chưa chọn gì nên không thể lưu");
                }
                return true;
            }
            if (keyData == (Keys.Control | Keys.A))
            {
                #region Click All
                stopSou();
                panel12.Visible = false;
                iu = 21;
                Clock2.BackColor = Color.FromArgb(70, 82, 157);
                Clock1.BackColor = Color.FromArgb(70, 82, 157);
                Clock3.BackColor = Color.FromArgb(70, 82, 157);
                Clock4.BackColor = Color.FromArgb(70, 82, 157);
                Clock5.BackColor = Color.FromArgb(70, 82, 157);
                Clock6.BackColor = Color.FromArgb(70, 82, 157);
                Clock7.BackColor = Color.FromArgb(70, 82, 157);
                Clock8.BackColor = Color.FromArgb(70, 82, 157);
                Clock9.BackColor = Color.FromArgb(70, 82, 157);
                Clock10.BackColor = Color.FromArgb(70, 82, 157);
                Clock11.BackColor = Color.FromArgb(70, 82, 157);
                Clock12.BackColor = Color.FromArgb(70, 82, 157);
                Clock13.BackColor = Color.FromArgb(70, 82, 157);
                Clock14.BackColor = Color.FromArgb(70, 82, 157);
                Clock15.BackColor = Color.FromArgb(70, 82, 157);
                Clock16.BackColor = Color.FromArgb(70, 82, 157);
                Clock17.BackColor = Color.FromArgb(70, 82, 157);
                Clock18.BackColor = Color.FromArgb(70, 82, 157);
                Clock19.BackColor = Color.FromArgb(70, 82, 157);
                Clock20.BackColor = Color.FromArgb(70, 82, 157);
                #endregion
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        void LoadRong()
        {
            if (
            Clock1.Visible == false &&
            Clock2.Visible == false &&
            Clock3.Visible == false &&
            Clock4.Visible == false &&
            Clock5.Visible == false &&
            Clock6.Visible == false &&
            Clock7.Visible == false &&
            Clock8.Visible == false &&
            Clock9.Visible == false &&
            Clock10.Visible == false &&
            Clock11.Visible == false &&
            Clock12.Visible == false &&
            Clock13.Visible == false &&
            Clock14.Visible == false &&
            Clock15.Visible == false &&
            Clock16.Visible == false &&
            Clock17.Visible == false &&
            Clock18.Visible == false &&
            Clock19.Visible == false &&
            Clock20.Visible == false
            ) RongPanel.Visible = true;
            else RongPanel.Visible = false;
        }
        void MenuClock()
        {
            flowLayoutPanel1.ContextMenuStrip = contextMenuStrip1;
        }

        private void checkGetNow_Click(object sender, EventArgs e)
        {
            houText.Text = DateTime.Now.ToString("HH");
            minText.Text = DateTime.Now.ToString("mm");
            secText.Text = DateTime.Now.ToString("ss");
            DateText.Text = DateTime.Now.ToString("dd");
            MonthText.Text = DateTime.Now.ToString("MM");
            YearText.Text = DateTime.Now.ToString("yyyy");
        }


        private void ThemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonAdd();
        }

        int play = 1; SoundPlayer sou;
        private void PlayBut_Click(object sender, EventArgs e)
        {

            sou = new SoundPlayer(pathMusicRead);
            if (play == 1)
            {
                try
                {
                    sou.PlayLooping();
                    PlayBut.Text = "| |";
                    play = 0;
                }
                catch
                {
                    try
                    {
                        Process.Start(pathMusicRead);
                    }
                    catch
                    {
                        String errorPath = Directory.GetCurrentDirectory() + @"\" + pathMusicRead;
                        MessageBox.Show("Đường dẫn: " + errorPath + " không tìm thấy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                PlayBut.Text = "|>";
                sou.Stop();
                play = 1;
            }
        }

        private void ChuongBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            stopSou(); Isong.Stop();
            String newSong = "";
            if (cb.SelectedIndex == 0) newSong = @"Data\BaoThuc\ChuongBaoThuc\Alarm.wav";
            else if (cb.SelectedIndex == 1) newSong = @"Data\BaoThuc\ChuongBaoThuc\Bells.wav";
            else if (cb.SelectedIndex == 2) newSong = @"Data\BaoThuc\ChuongBaoThuc\Cuckoo.wav";
            else if (cb.SelectedIndex == 3) newSong = @"Data\BaoThuc\ChuongBaoThuc\Flute.wav";
            else if (cb.SelectedIndex == 4) newSong = @"Data\BaoThuc\ChuongBaoThuc\MusicBox.wav";
            else if (cb.SelectedIndex == 5) newSong = @"Data\BaoThuc\ChuongBaoThuc\RengReng1.wav";
            else if (cb.SelectedIndex == 6) newSong = @"Data\BaoThuc\ChuongBaoThuc\RengReng2.wav";

            //StreamWriter sr = new StreamWriter(@"Data\BaoThuc\Clock" + iu + "\\Chuongpath.adb");
            //sr.WriteLine(newSong);
            //sr.Close();
            pathMusicRead = newSong;
        }



        private void Settingbtn_Click(object sender, EventArgs e)
        {
            Setting st = new Setting();
            st.ShowDialog();
        }

        private void adminBtn_MouseHover(object sender, EventArgs e)
        {
            adminBtn.ForeColor = Color.FromArgb(244, 225, 172);
        }

        private void adminBtn_MouseLeave(object sender, EventArgs e)
        {
            adminBtn.ForeColor = Color.FromArgb(100, 192, 228, 248);
        }


        private void DeleteAllbtn_Click(object sender, EventArgs e)
        {
            ButtonDel();
        }
      
    }
}
    

