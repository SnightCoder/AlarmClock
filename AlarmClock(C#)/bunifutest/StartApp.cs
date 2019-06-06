using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_To_Exit;
using System.Media;
using System.Runtime.InteropServices;
using System.Net;

namespace bunifutest
{

    public partial class StartApp : Form
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
        Timer tm = new Timer() { Interval = 1 };
        Timer tmRun = new Timer() { Interval = 1 };
        Timer tmCheck = new Timer() { Interval = 1 };
        Timer AlarmTime = new Timer() { Interval = 1000 };

        #region tăng âm lượng
        private const int APPCOMMAND_VOLUME_UP = 0xA0000; private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        private void VolUp()
        {
            for (int lapp = 0; lapp < 50; lapp++)
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                    (IntPtr)APPCOMMAND_VOLUME_UP);
            }
        }

        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
        }

        public StartApp()
        {

            InitializeComponent();



            StreamWriter swO = new StreamWriter(@"Data\User\off.adb");
            swO.WriteLine("0");
            swO.Close();


            AlarmTime.Tick += AlarmTime_Tick;
            AlarmTime.Start();
            StreamWriter sr = new StreamWriter("data\\uishow.adb");
            sr.WriteLine("1");
            sr.Close();

            UI_App ui = new UI_App();

            ui.Show(); ui.Size = new System.Drawing.Size(0, 0);
            StreamWriter sr1 = new StreamWriter("data\\uisizeW.adb");
            sr1.WriteLine("0");
            sr1.Close();

            StreamWriter sr2 = new StreamWriter("data\\uisizeH.adb");
            sr2.WriteLine("0");
            sr2.Close();

            Clock.Visible = true;
            StreamWriter sw = new StreamWriter("data\\iconshow.adb");
            sw.WriteLine("0");
            sw.Close();

            panel2.Location = new Point(321, 0);
            tm.Tick += tm_Tick;
            tmRun.Tick += tmRun_Tick;
            tmRun.Start();
            tmCheck.Tick += tmCheck_Tick;
            tmCheck.Start();
            button1.Location = new Point(285, 0);


            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);

            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        void AlarmTime_Tick(object sender, EventArgs e)
        {
            
            for (int i = 1; i < u; i++)
            {
                String hou = @"Data\BaoThuc\Clock" + i + "\\hou.adb";
                String min = @"Data\BaoThuc\Clock" + i + "\\min.adb";
                String sec = @"Data\BaoThuc\Clock" + i + "\\sec.adb";

                String day = @"Data\BaoThuc\Clock" + i + "\\date.adb";
                String month = @"Data\BaoThuc\Clock" + i + "\\month.adb";
                String year = @"Data\BaoThuc\Clock" + i + "\\year.adb";
                String nhacngay = @"Data\BaoThuc\Clock" + i + "\\nhacngay.adb";
                String nhacthoi = @"Data\BaoThuc\Clock" + i + "\\nhacthoi.adb";

                String on_offAlarm = @"Data\BaoThuc\Clock" + i + "\\on_off.adb";
                String thu2_Read = @"Data\BaoThuc\Clock" + i + "\\thu2.adb";
                String thu3_Read = @"Data\BaoThuc\Clock" + i + "\\thu3.adb";
                String thu4_Read = @"Data\BaoThuc\Clock" + i + "\\thu4.adb";
                String thu5_Read = @"Data\BaoThuc\Clock" + i + "\\thu5.adb";
                String thu6_Read = @"Data\BaoThuc\Clock" + i + "\\thu6.adb";
                String thu7_Read = @"Data\BaoThuc\Clock" + i + "\\thu7.adb";
                String thu8_Read = @"Data\BaoThuc\Clock" + i + "\\thu8.adb";
                String ChiCheck_Read = @"Data\BaoThuc\Clock" + i + "\\ChiCheck.adb";

                StreamWriter swI = new StreamWriter(@"Data\BaoThuc\I.adb"); swI.WriteLine(i.ToString()); swI.Close();



                StreamReader srDate = new StreamReader(day);
                int dayn = Convert.ToInt32(srDate.ReadLine());
                srDate.Close();

                StreamReader srMonth = new StreamReader(month);
                int monthn = Convert.ToInt32(srMonth.ReadLine());
                srMonth.Close();

                StreamReader srYear = new StreamReader(year);
                int yearn = Convert.ToInt32(srYear.ReadLine());
                srYear.Close();

                StreamReader srNhacNgay = new StreamReader(nhacngay);
                int nhacngayn = Convert.ToInt32(srNhacNgay.ReadLine());
                srNhacNgay.Close();

                StreamReader srNhacThoi = new StreamReader(nhacthoi);
                int nhacthoin = Convert.ToInt32(srNhacThoi.ReadLine());
                srNhacThoi.Close();


                StreamReader srThu2 = new StreamReader(thu2_Read);
                int thu2 = Convert.ToInt32(srThu2.ReadLine());
                srThu2.Close();

                StreamReader srThu3 = new StreamReader(thu3_Read);
                int thu3 = Convert.ToInt32(srThu3.ReadLine());
                srThu3.Close();

                StreamReader srThu4 = new StreamReader(thu4_Read);
                int thu4 = Convert.ToInt32(srThu4.ReadLine());
                srThu4.Close();

                StreamReader srThu5 = new StreamReader(thu5_Read);
                int thu5 = Convert.ToInt32(srThu5.ReadLine());
                srThu5.Close();

                StreamReader srThu6 = new StreamReader(thu6_Read);
                int thu6 = Convert.ToInt32(srThu6.ReadLine());
                srThu6.Close();

                StreamReader srThu7 = new StreamReader(thu7_Read);
                int thu7 = Convert.ToInt32(srThu7.ReadLine());
                srThu7.Close();

                StreamReader srThu8 = new StreamReader(thu8_Read);
                int thu8 = Convert.ToInt32(srThu8.ReadLine());
                srThu8.Close();

                StreamReader srChiCheck = new StreamReader(ChiCheck_Read);
                int ChiCheck = Convert.ToInt32(srChiCheck.ReadLine());
                srChiCheck.Close();

                StreamReader srON = new StreamReader(on_offAlarm);
                int On = Convert.ToInt32(srON.ReadLine());
                srON.Close();
                StreamReader srHou = new StreamReader(hou);
                int houn = Convert.ToInt32(srHou.ReadLine());
                srHou.Close();
                StreamReader srMin = new StreamReader(min);
                int minn = Convert.ToInt32(srMin.ReadLine());
                srMin.Close();
                StreamReader srSec = new StreamReader(sec);
                int secn = Convert.ToInt32(srSec.ReadLine());
                srSec.Close();

                DateTime dt = Convert.ToDateTime(houn + ":" + minn + ":" + secn);

                StreamReader ConLai = new StreamReader(@"Data\Setting\thongbao.adb");
                if (ConLai.ReadLine() == "1")
                {
                    #region còn số phút nè
                    if (On == 1)
                    {
                        if (nhacngayn == 1)
                        {
                            DateTime dateNow1 = new DateTime(yearn, monthn, dayn);
                            if (dateNow1.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                            {
                                #region còn số phút
                                //Còn 5 phút nữa
                                dt = dt.AddMinutes(-5);
                                if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                {
                                    StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                    swCon.WriteLine("Còn 5 phút nữa");
                                    swCon.Close();
                                    ThongBao tb = new ThongBao();
                                    tb.Show();
                                };


                                //Còn 15 phút nữa
                                dt = dt.AddMinutes(-10);
                                if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                {
                                    StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                    swCon.WriteLine("Còn 15 phút nữa");
                                    swCon.Close();
                                    ThongBao tb = new ThongBao();
                                    tb.Show();
                                };

                                //Còn 30 phút nữa
                                dt = dt.AddMinutes(-15);
                                if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                {
                                    StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                    swCon.WriteLine("Còn 30 phút nữa");
                                    swCon.Close();
                                    ThongBao tb = new ThongBao();
                                    tb.Show();
                                };
                                #endregion
                            }

                        }
                        if (ChiCheck == 0)
                        {
                            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                            {
                                if (thu2 == 1)
                                {
                                    #region còn số phút
                                    //Còn 5 phút nữa
                                    dt = dt.AddMinutes(-5);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 5 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };


                                    //Còn 15 phút nữa
                                    dt = dt.AddMinutes(-10);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 15 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };

                                    //Còn 30 phút nữa
                                    dt = dt.AddMinutes(-15);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 30 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };
                                    #endregion
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                            {
                                if (thu3 == 1)
                                {
                                    #region còn số phút
                                    //Còn 5 phút nữa
                                    dt = dt.AddMinutes(-5);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 5 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };


                                    //Còn 15 phút nữa
                                    dt = dt.AddMinutes(-10);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 15 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };

                                    //Còn 30 phút nữa
                                    dt = dt.AddMinutes(-15);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 30 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };
                                    #endregion
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                            {
                                if (thu4 == 1)
                                {
                                    #region còn số phút
                                    //Còn 5 phút nữa
                                    dt = dt.AddMinutes(-5);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 5 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };


                                    //Còn 15 phút nữa
                                    dt = dt.AddMinutes(-10);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 15 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };

                                    //Còn 30 phút nữa
                                    dt = dt.AddMinutes(-15);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 30 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };
                                    #endregion
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                            {
                                if (thu5 == 1)
                                {
                                    #region còn số phút
                                    //Còn 5 phút nữa
                                    dt = dt.AddMinutes(-5);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 5 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };


                                    //Còn 15 phút nữa
                                    dt = dt.AddMinutes(-10);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 15 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };

                                    //Còn 30 phút nữa
                                    dt = dt.AddMinutes(-15);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 30 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };
                                    #endregion
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                            {
                                if (thu6 == 1)
                                {
                                    #region còn số phút
                                    //Còn 5 phút nữa
                                    dt = dt.AddMinutes(-5);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 5 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };


                                    //Còn 15 phút nữa
                                    dt = dt.AddMinutes(-10);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 15 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };

                                    //Còn 30 phút nữa
                                    dt = dt.AddMinutes(-15);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 30 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };
                                    #endregion
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                            {
                                if (thu7 == 1)
                                {
                                    #region còn số phút
                                    //Còn 5 phút nữa
                                    dt = dt.AddMinutes(-5);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 5 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };


                                    //Còn 15 phút nữa
                                    dt = dt.AddMinutes(-10);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 15 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };

                                    //Còn 30 phút nữa
                                    dt = dt.AddMinutes(-15);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 30 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };
                                    #endregion
                                }
                            }

                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                            {
                                if (thu8 == 1)
                                {
                                    #region còn số phút
                                    //Còn 5 phút nữa
                                    dt = dt.AddMinutes(-5);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 5 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };


                                    //Còn 15 phút nữa
                                    dt = dt.AddMinutes(-10);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 15 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };

                                    //Còn 30 phút nữa
                                    dt = dt.AddMinutes(-15);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 30 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };
                                    #endregion
                                }
                            }

                        }
                        else
                        {
                            if (nhacngayn == 1)
                            {
                                String dateNow1 = dayn + "/" + monthn + "/" + yearn;
                                DateTime datet1 = new DateTime(Convert.ToInt32(yearn), Convert.ToInt32(monthn), Convert.ToInt32(dayn));
                                if (datet1.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                                {
                                    #region còn số phút
                                    //Còn 5 phút nữa
                                    dt = dt.AddMinutes(-5);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 5 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };


                                    //Còn 15 phút nữa
                                    dt = dt.AddMinutes(-10);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 15 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };

                                    //Còn 30 phút nữa
                                    dt = dt.AddMinutes(-15);
                                    if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                    {
                                        StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                        swCon.WriteLine("Còn 30 phút nữa");
                                        swCon.Close();
                                        ThongBao tb = new ThongBao();
                                        tb.Show();
                                    };
                                    #endregion
                                };

                            }
                            else
                            {
                                #region còn số phút
                                //Còn 5 phút nữa
                                dt = dt.AddMinutes(-5);
                                if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                {
                                    StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                    swCon.WriteLine("Còn 5 phút nữa");
                                    swCon.Close();
                                    ThongBao tb = new ThongBao();
                                    tb.Show();
                                };


                                //Còn 15 phút nữa
                                dt = dt.AddMinutes(-10);
                                if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                {
                                    StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                    swCon.WriteLine("Còn 15 phút nữa");
                                    swCon.Close();
                                    ThongBao tb = new ThongBao();
                                    tb.Show();
                                };

                                //Còn 30 phút nữa
                                dt = dt.AddMinutes(-15);
                                if (DateTime.Now.ToString("HH:mm:ss") == dt.ToString("HH:mm:ss"))
                                {
                                    StreamWriter swCon = new StreamWriter(@"data\baothuc\timetext.adb");
                                    swCon.WriteLine("Còn 30 phút nữa");
                                    swCon.Close();
                                    ThongBao tb = new ThongBao();
                                    tb.Show();
                                };
                                #endregion
                            }
                        }
                    }
                    #endregion
                }
                ConLai.Close();

                dt = Convert.ToDateTime(houn + ":" + minn + ":" + secn);

                if (dt.ToString("HH:mm:ss") == DateTime.Now.ToString("HH:mm:ss"))
                {

                    if (On == 1)
                    {

                        if (nhacngayn == 1)
                        {
                            DateTime dateNow = new DateTime(yearn, monthn, dayn);
                            if (dateNow.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                            {
                                loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                if (nhacthoin == 1)
                                {
                                    StreamWriter swOn1 = new StreamWriter(on_offAlarm);
                                    swOn1.WriteLine("0");
                                    swOn1.Close();
                                    loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                    sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                }
                                else
                                {
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                }
                                continue;
                            }
                        }

                        if (ChiCheck == 0)
                        {


                            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                            {
                                if (thu2 == 1)
                                {
                                    loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                    sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                            {
                                if (thu3 == 1)
                                {
                                    loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                    sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                            {
                                if (thu4 == 1)
                                {
                                    loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                    sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                            {
                                if (thu5 == 1)
                                {
                                    loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                    sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                            {
                                if (thu6 == 1)
                                {
                                    loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                    sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                }
                            }
                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                            {
                                if (thu7 == 1)
                                {
                                    loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                    sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                }
                            }

                            else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                            {
                                if (thu8 == 1)
                                {
                                    loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                    sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                }
                            }

                        }
                        else
                        {
                            if (nhacngayn == 1)
                            {
                                String dateNow = dayn + "/" + monthn + "/" + yearn;
                                DateTime datet = new DateTime(Convert.ToInt32(yearn), Convert.ToInt32(monthn), Convert.ToInt32(dayn));
                                if (datet.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                                {
                                    StreamWriter swOn = new StreamWriter(on_offAlarm);
                                    swOn.WriteLine("0");
                                    swOn.Close();
                                    loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                    sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                    BaoThuc();
                                    StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                    if (srVol.ReadLine() == "1")
                                        VolUp();
                                    srVol.Close();
                                };

                                continue;
                            }
                            else
                            {
                                StreamWriter swOn = new StreamWriter(on_offAlarm);
                                swOn.WriteLine("0");
                                swOn.Close();
                                loop = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                                sr = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\chuongpath.adb");
                                BaoThuc();
                                StreamReader srVol = new StreamReader(@"data\setting\autovolume.adb");
                                if (srVol.ReadLine() == "1")
                                    VolUp();
                                srVol.Close();
                            }
                        }

                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        String loop;
        StreamReader sr;
        void BaoThuc()
        {
            StreamReader srI = new StreamReader(@"Data\BaoThuc\I.adb"); int i = Convert.ToInt32(srI.ReadLine()); srI.Close();
            String TenBaoThuc_Read = @"Data\BaoThuc\Clock" + i + "\\TenBaoThuc.adb";
            StreamReader srTen = new StreamReader(TenBaoThuc_Read);
            String text = srTen.ReadLine(); srTen.Close();
            StreamWriter swText = new StreamWriter(@"Data\BaoThuc\Text.adb");
            swText.WriteLine(text); swText.Close();
            StreamReader swVongLap = new StreamReader(@"Data\BaoThuc\Clock" + i + "\\VongLap.adb");
            int lanLap = Convert.ToInt32(swVongLap.ReadLine()); swVongLap.Close();
            StreamWriter sw = new StreamWriter(@"Data\BaoThuc\loop.adb");
            sw.WriteLine(lanLap.ToString()); sw.Close();
            String path = sr.ReadLine();
            sr.Close();
            StreamWriter srSong = new StreamWriter(@"Data\BaoThuc\song.adb"); srSong.WriteLine(path); srSong.Close();
            BaoThucBox b = new BaoThucBox();
            b.Show();
        }

        void tmCheck_Tick(object sender, EventArgs e)
        {
            // kieemr tra thowif gian

            StreamReader sr = new StreamReader("data\\iconshow.adb");
            String haha = sr.ReadLine();

            if (haha == "0")
                this.Show();


            else this.Hide();

            sr.Close();

        }



        void tmRun_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader(@"data\user\name.adb");
            label9.Text = sr.ReadLine();
            sr.Close();
            label1.Text = dt.ToString("dd : HH : mm : ss");
            label6.Text = "Ngày" + dt.ToString(" dd ") + "Tháng" + dt.ToString(" MM") + " Năm";
            label7.Text = dt.ToString("yyyy");
        }

        void tm_Tick(object sender, EventArgs e)
        {
            if (slide == 1)
            {
                if (panel2.Location.X > 179)
                {
                    panel2.Location = new Point(panel2.Location.X - 10, panel2.Location.Y);
                    button1.Location = new Point(button1.Location.X - 10, button1.Location.Y);
                }
                else { tm.Stop(); slide = 0; }
            }
            else if (slide == 0)
            {
                if (panel2.Location.X < 321)
                {
                    panel2.Location = new Point(panel2.Location.X + 10, panel2.Location.Y);
                    button1.Location = new Point(button1.Location.X + 10, button1.Location.Y);
                }
                else { tm.Stop(); slide = 1; }
            }
        }


        private void mởỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StreamWriter sr = new StreamWriter("data\\iconshow.adb");
            sr.WriteLine("0");
            sr.Close();
            this.Show();
            panel2.Location = new Point(321, 0); button1.Location = new Point(285, 0);
            slide = 1;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"data\setting\login.adb");
            if (sr.ReadLine() == "1")
            {
                Form1 fom = new Form1();
                fom.Show();
            }
            else
            {
                DialogResult d = MessageBox.Show("Nếu bạn thoát, ứng dụng này sẽ không thể thông báo cho bạn nữa, bạn có chắc muốn thoát ", "Chú ý", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    StreamWriter sw = new StreamWriter(@"Data\User\off.adb");
                    sw.WriteLine("1");
                    sw.Close();
                    Application.Exit();
                }

            }
        }

        private void Clock_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            StreamWriter sr = new StreamWriter("data\\iconshow.adb");
            sr.WriteLine("0");
            sr.Close();
            this.Show();
            panel2.Location = new Point(321, 0); button1.Location = new Point(285, 0);
            slide = 1;
        }
        int slide = 1;
        private void button1_Click(object sender, EventArgs e)
        {

            tm.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter("data\\iconshow.adb");
            sr.WriteLine("1");
            sr.Close();
            this.Hide();
            StreamReader sr1 = new StreamReader(@"data\setting\Login.adb");
            if (sr1.ReadLine() == "1")
            {
                DangNhap dn = new DangNhap();
                dn.ShowDialog();
            }
            else
            {
                StreamWriter srui = new StreamWriter("data\\uishow.adb");
                srui.WriteLine("0");
                srui.Close();

                StreamWriter srW = new StreamWriter("data\\uisizeW.adb");
                srW.WriteLine("1226");
                srW.Close();
                StreamWriter srH = new StreamWriter("data\\uisizeH.adb");
                srH.WriteLine("673");
                srH.Close();
            }
            sr1.Close();
            panel2.Location = new Point(321, 0); button1.Location = new Point(285, 0);
            slide = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            StreamWriter sr = new StreamWriter("data\\iconshow.adb");
            sr.WriteLine("1");
            sr.Close();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("https://www.facebook.com/PhamHoaiNamPage/");
            CongCu cc = new CongCu();
            cc.Show();
            tm.Start();
        }
        int trong = 1;
        private void button5_Click(object sender, EventArgs e)
        {
            if (trong == 1)
            {
                button5.Text = "Tắt trong suốt";
                this.Opacity = 0.3; trong = 0;
                tm.Start();
            }
            else
            {
                this.Opacity = 1;
                button5.Text = "Bật trong suốt";
                trong = 1; tm.Start();
            }

        }


    }
}
