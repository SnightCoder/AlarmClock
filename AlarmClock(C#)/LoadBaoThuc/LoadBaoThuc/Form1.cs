using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadBaoThuc
{
    public partial class Form1 : Form
    {
        static String mTK;
        static String host = "https://wwwphamhoainamcom.000webhostapp.com/Clock/";
        public Form1()
        {
            InitializeComponent();
            IsProcessRunning();
        }
        private void Paste_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\baothuc";
            FolderBrowserDialog s = new FolderBrowserDialog();
            s.RootFolder = Environment.SpecialFolder.Desktop;
            DialogResult d = s.ShowDialog();
            if (d == DialogResult.OK)
            {
                try
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo("data\\baothuc");
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    Directory.Delete("data\\baothuc");
                }
                catch { }
                Copy(s.SelectedPath, "data\\baothuc");
                MessageBox.Show("Đã khôi phục thành công!");
                Process.Start("Clock.exe");
                Application.Exit();
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
                catch { }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("Clock.exe");
            Application.Exit();
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void IsProcessRunning()
        {
            //if (Process.GetProcessesByName(@"Clock").Length > 0)
            //{

            //    // Trường hợp này không được thêm .exe vào Clock
            //    MessageBox.Show("Ứng dụng đang chạy vui lòng thoát ứng dụng");

            //    this.Close();
            //}
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }// Kiểm tra kết nối mạng

        private void PasteOn_Click(object sender, EventArgs e)
        {
            panel3.SendToBack();
        }
        public static bool DangNhap(String user, String pass)
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
                        mTK = row["MaTaiKhoan"].ToString();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (DangNhap(textBox1.Text, textBox2.Text))
            {

                WebClient web = new WebClient();
                Stream st = web.OpenRead(host+"SelectDanhTrong.php?maTK=" + mTK);
                StreamReader sr = new StreamReader(st);
                String data = sr.ReadToEnd();
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, typeof(DataTable));
                foreach (DataRow da in dt.Rows)
                {
                    String i = da["id"].ToString();
                    String ChiCheck = da["ChiCheck"].ToString();
                    String date = da["date"].ToString();
                    String Hou = da["Hou"].ToString();
                    String Like_Dis = da["Like_Dis"].ToString();
                    String minn = da["min"].ToString();
                    String Month = da["Month"].ToString();
                    String NhacNgay = da["NhacNgay"].ToString();
                    String NhacThoi = da["NhacThoi"].ToString();
                    String ON_OFF = da["ON_OFF"].ToString();
                    String secn = da["sec"].ToString();
                    String TenBaoThuc = da["TenBaoThuc"].ToString();
                    String Thu2 = da["Thu2"].ToString();
                    String Thu3 = da["Thu3"].ToString();
                    String Thu4 = da["Thu4"].ToString();
                    String Thu5 = da["Thu5"].ToString();
                    String Thu6 = da["Thu6"].ToString();
                    String Thu7 = da["Thu7"].ToString();
                    String Thu8 = da["Thu8"].ToString();
                    String VongLap = da["VongLap"].ToString();
                    String yearn = da["year"].ToString();


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

                    StreamWriter LikeR = new StreamWriter(Like_Read);
                    LikeR.WriteLine(Like_Dis);
                    LikeR.Close();

                    StreamWriter TenR = new StreamWriter(Ten_Read);
                    TenR.WriteLine(TenBaoThuc);
                    TenR.Close();

                    StreamWriter VongLapR = new StreamWriter(VongLap_Read);
                    VongLapR.WriteLine(VongLap);
                    VongLapR.Close();

                    StreamWriter srDate = new StreamWriter(day);
                    srDate.WriteLine(date);
                    srDate.Close();

                    StreamWriter srMonth = new StreamWriter(month);
                    srMonth.WriteLine(Month);
                    srMonth.Close();

                    StreamWriter srYear = new StreamWriter(year);
                    srYear.WriteLine(yearn);
                    srYear.Close();

                    StreamWriter srNhacNgay = new StreamWriter(nhacngay);
                    srNhacNgay.WriteLine(NhacNgay);
                    srNhacNgay.Close();

                    StreamWriter srNhacThoi = new StreamWriter(nhacthoi);
                    srNhacThoi.WriteLine(NhacThoi);
                    srNhacThoi.Close();


                    StreamWriter srThu2 = new StreamWriter(thu2_Read);
                    srThu2.WriteLine(Thu2);
                    srThu2.Close();

                    StreamWriter srThu3 = new StreamWriter(thu3_Read);
                    srThu3.WriteLine(Thu3);
                    srThu3.Close();

                    StreamWriter srThu4 = new StreamWriter(thu4_Read);
                    srThu4.WriteLine(Thu4);
                    srThu4.Close();

                    StreamWriter srThu5 = new StreamWriter(thu5_Read);
                    srThu5.WriteLine(Thu5);
                    srThu5.Close();

                    StreamWriter srThu6 = new StreamWriter(thu6_Read);
                    srThu6.WriteLine(Thu6);
                    srThu6.Close();

                    StreamWriter srThu7 = new StreamWriter(thu7_Read);
                    srThu7.WriteLine(Thu7);
                    srThu7.Close();

                    StreamWriter srThu8 = new StreamWriter(thu8_Read);
                    srThu8.WriteLine(Thu8);
                    srThu8.Close();

                    StreamWriter srChiCheck = new StreamWriter(ChiCheck_Read);
                    srChiCheck.WriteLine(ChiCheck);
                    srChiCheck.Close();

                    StreamWriter srON = new StreamWriter(on_offAlarm);
                    srON.WriteLine(ON_OFF);
                    srON.Close();
                    StreamWriter srHou = new StreamWriter(hou);
                    srHou.WriteLine(Hou);
                    srHou.Close();
                    StreamWriter srMin = new StreamWriter(min);
                    srMin.WriteLine(minn);
                    srMin.Close();
                    StreamWriter srSec = new StreamWriter(sec);
                    srSec.WriteLine(secn);
                    srSec.Close();


                }
                Process.Start("Clock.exe");
                Application.Exit();           }
            else MessageBox.Show("Sai");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

    }
}
