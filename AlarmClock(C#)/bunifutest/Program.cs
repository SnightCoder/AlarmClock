using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace bunifutest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            for (int i = 1; i < 11; i++) { 
            if (Directory.Exists("data\\baothuc\\Clock" + i)) {

                }
                else
                {
                    MessageBox.Show("Lỗi không tìm thấy dữ liệu sao lưu");
                    Process.Start("LoadBaothuc.exe");
                    return;
                }
        } 

            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            {
                try
                {
                    StreamWriter sw = new StreamWriter("data\\iconshow.adb");
                    sw.WriteLine("0"); sw.Close();return;
                }
                catch { return; }
            }
            // lấy ổ đĩa
            String diskName = Directory.GetCurrentDirectory();
            diskName = diskName[0].ToString();

            StreamWriter sr = new StreamWriter("HelloClock.bat");
            sr.WriteLine("@echo Dang Khoi Dong Chuong Trinh Hello Clock");
            sr.WriteLine("@"+diskName+":");
            sr.WriteLine("@cd "+Directory.GetCurrentDirectory());
            sr.WriteLine("@StartApp.exe"); sr.Close();
            StreamReader srStat = new StreamReader(@"data\windows.adb");
            int stat = Convert.ToInt32(srStat.ReadLine());
            srStat.Close();
            if (stat == 1)  KhoiDongCungWinDows(true);
            else KhoiDongCungWinDows(false);
           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartApp()); //ThongBao());//UI_App());//DangNhap());
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
    }
}
