using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace bunifutest
{
    class IdAccount
    {
        // 
        // Setting.cs, DangNhap.cs, SignUp.cs,UI_App.cs, Form1
        public static DataTable dataTB;
        static String host = "https://wwwphamhoainamcom.000webhostapp.com/Clock/";
        public static int id;
        public static String MaTaiKhoan=null,user=null,pass=null;
        public static bool IdEnable = false, Offline = false, Export = false, Import = false;

        public static string Avatar="https://";

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (Stream sr=client.OpenRead("https://wwwphamhoainamcom.000webhostapp.com"))
                {
                    StreamReader str = new StreamReader(sr);
                    if (str.ReadLine().Equals("Connect Success")) return true;
                    else return false;
                }
            }
            catch
            {
                return false;
            }
        }// Kiểm tra kết nối mạng
        //public static bool Setting(String user,String pass)
        //{
        //    if (IdAccount.CheckForInternetConnection())
        //    {
        //        user = user.Replace("'", "''");
        //        pass = pass.Replace("'", "''");
        //        WebClient webClient = new WebClient();
        //        Stream stream = webClient.OpenRead("https://wwwphamhoainamcom.000webhostapp.com/Clock/SelectTaiKhoan.php?taikhoan=" + user + "&matkhau=" + pass);
        //        StreamReader streamR = new StreamReader(stream);
        //        String data = streamR.ReadToEnd();
        //        if (data.Equals("0"))
        //        {
        //            MessageBox.Show("Tài khoản hoặc mật khẩu đang dùng sai");
        //            return false;
        //        }
        //        else
        //        {
        //            DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(data, typeof(DataTable));
        //            foreach (DataRow row in dataTable.Rows)
        //            {
        //                user = row["user"].ToString();
        //                pass = row["pass"].ToString();
        //                String maTK = row["MaTaiKhoan"].ToString();
        //                StreamReader sr4 = new StreamReader(@"Data\Setting\Login.adb");
        //                String gg = sr4.ReadLine();
        //                sr4.Close();

        //                if (gg.Equals("1"))
        //                {
        //                    if (!maTK.Equals(MaTaiKhoan))
        //                    {
        //                        MessageBox.Show("Tài khoản hoặc mật khẩu đang dùng sai");
        //                        return false;
        //                    }
        //                    else
        //                    {
        //                        return true;
        //                    }
        //                }
        //                else
        //                {
        //                   MaTaiKhoan = maTK;
        //                   IdEnable = true;
        //                   return true;
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng kết nối lại mạng");
        //        return false;
        //    }
        //    return false;
        //}
        public static bool DangNhap(String user,String pass)
        {
            if (CheckForInternetConnection())
            {
                user = user.Replace("'", "''");
                pass = pass.Replace("'", "''");
                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(host+"SelectTaiKhoan.php?taikhoan=" + user + "&matkhau=" + pass);
                StreamReader streamR = new StreamReader(stream);
                String data = streamR.ReadToEnd();
                if (data.Equals("0"))
                {
                    return false;
                }
                else
                {
                    DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(data, typeof(DataTable));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        user = row["user"].ToString();
                        pass = row["pass"].ToString();
                        IdAccount.user = user;
                        IdAccount.pass = pass;
                        Avatar = row["avatar"].ToString();
                        MaTaiKhoan = row["MaTaiKhoan"].ToString();
                        IdEnable = true;
                    }
                    return true;
                }

            }
            else
            {
                MessageBox.Show("Vui lòng kết nối lại mạng");
                return false;
            }
        }
        public static bool SignUp(String user,String pass,String rePass)
        {
            if (CheckForInternetConnection())
            {
                user = user.Replace("'", "''");
                pass = pass.Replace("'", "''");
                rePass = rePass.Replace("'", "''");
                if (user != String.Empty && pass!= String.Empty && rePass != String.Empty)
                {
                    if (pass.Equals(rePass))
                    {
                        WebClient web = new WebClient();
                        WebClient webClient = new WebClient();
                        Random random = new Random();
                        String maTK = random.Next(0, 1000000) + "" + DateTime.Now.Millisecond.ToString();
                        Stream streamCheck = web.OpenRead(host+"CheckUserExists.php?taikhoan=" + user+"&matkhau=" + maTK);
                        StreamReader reader = new StreamReader(streamCheck);
                        if (!reader.ReadToEnd().Equals("Exists"))
                        {
                            Stream stream = webClient.OpenRead(host + "InsertTaiKhoan.php?user=" + user + "&pass=" + pass + "&maTK=" + maTK);
                            StreamReader streamR = new StreamReader(stream);
                            String data = streamR.ReadToEnd();
                            if (data.Equals("Success"))
                            {
                                //Success
                                WebClient client = new WebClient();
                                Stream str =client.OpenRead(host + "InsertDanhTrong.php?MaTaiKhoan=" + maTK);
                                StreamReader s = new StreamReader(str);
                                if (s.ReadToEnd().Equals("Success"))
                                {
                                    MessageBox.Show("Đăng ký tài khoản thành công ID của bạn là: " + maTK);
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Lỗi dữ liệu tài khoản");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lỗi đăng ký");
                            }
                        }
                        else MessageBox.Show("Tài khoản đã tồn tại");
                    }
                    else MessageBox.Show("Mời nhập lại mật khẩu đúng với mật khẩu bạn đã đặt");
                }
                else
                {
                    MessageBox.Show("Không dược để trống");
                }
            }
            return false;
        }
        public static bool UI_App(String user,String pass)
        {
            if (CheckForInternetConnection())
            {
                user = user.Replace("'", "''");
                pass = pass.Replace("'", "''");
                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(host+"UpdateTaiKhoan.php?user=" + user + "&pass=" + pass+ "&maTK=" + MaTaiKhoan);
                StreamReader streamR = new StreamReader(stream);
                String data = streamR.ReadToEnd();
                if (data.Equals("Success"))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    return true;
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại");
                }

            }

            return false;
        }
        public static bool UploadToDataBase()
        {
            if (CheckForInternetConnection())
            {
                for (int i = 1; i <= 20; i++)
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
                    String VongLap_Read = @"Data\BaoThuc\Clock" + i + "\\VongLap.adb";
                    String Like_Read = @"Data\BaoThuc\Clock" + i + "\\Like_Dis.adb";
                    String Ten_Read = @"Data\BaoThuc\Clock" + i + "\\TenBaoThuc.adb";

                    StreamReader LikeR = new StreamReader(Like_Read);
                    int Like = Convert.ToInt32(LikeR.ReadLine());
                    LikeR.Close();

                    StreamReader TenR = new StreamReader(Ten_Read);
                    String TenBT = TenR.ReadLine();
                    TenR.Close();

                    StreamReader VongLapR = new StreamReader(VongLap_Read);
                    int VongLap = Convert.ToInt32(VongLapR.ReadLine());
                    VongLapR.Close();

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
                    WebClient we = new WebClient();
                   Stream t= we.OpenRead(host+"UpdateDanhTrong.php?id=" + i + "&MaTaiKhoan=" + MaTaiKhoan + "&ChiCheck=" + ChiCheck + "&date=" + dayn + "&Hou=" + houn + "&Like_Dis=" + Like + "&min=" + minn + "&Month=" + monthn + "&NhacNgay=" + nhacngayn + "&NhacThoi=" + nhacthoin + "&ON_OFF=" + On + "&sec=" + secn + "&TenBaoThuc=" + TenBT + "&Thu2=" + thu2 + "&Thu3=" + thu3 + "&Thu4=" + thu4 + "&Thu5=" + thu5 + "&Thu6=" + thu6 + "&Thu7=" + thu7 + "&Thu8=" + thu8 + "&VongLap=" + VongLap + "&year=" + yearn);
                    StreamReader tr = new StreamReader(t);
                    String gg = tr.ReadToEnd();
                    if (gg.Equals("Success")) ;
                    else MessageBox.Show("Error: "+gg);
                }
            }
            return true;
        }
    }
}
