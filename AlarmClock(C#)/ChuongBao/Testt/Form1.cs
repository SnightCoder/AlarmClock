using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testt
{
    public partial class Form1 : Form
    {
        static String ahihi;
        bool Exit = false;
        String maTK,tenTK;// "284043979";
        int lengthDT;
        static SoundPlayer s;

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        public Form1()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader(@"Data\User\maTK.adb");
            maTK = sr.ReadLine();
            Text = Text + sr.ReadLine();
            sr.Close();
            tenTK = Text;
            


            axWindowsMediaPlayer1.settings.volume = 100;
            timer1.Start();
            MaximizeBox = false;
            ShowIcon = true;
            //ShowInTaskbar = false;
            Size = new Size(0, 0);
            FormBorderStyle = FormBorderStyle.None;
        }



        static async void webString(String url)
        {
            string page = url;
            String data;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respone = await client.GetAsync(page))
            using (HttpContent content = respone.Content)
            {
                data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    ahihi = data;
                }
            }
        }
        static async void webLoad(String url)
        {
            string page = url;
            String data;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respone = await client.GetAsync(page))
            using (HttpContent content = respone.Content)
            {
                data = await content.ReadAsStringAsync();
                if (data != null)
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            WMPLib.IWMPControls3 controls = (WMPLib.IWMPControls3)axWindowsMediaPlayer1.Ctlcontrols;
            // Check first to be sure the operation is valid. 

            if (controls.get_isAvailable("stop"))
            {
                controls.stop();
            }

            if (ahihi != null)
            {
                DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(ahihi, typeof(DataTable));
                foreach (DataRow row in dataTable.Rows)
                {
                    webLoad("https://wwwphamhoainamcom.000webhostapp.com/Clock/StatusChuongBao.php?id=" + row["id"] + "&maTK=" + maTK + "&run=0");
                    webLoad("https://wwwphamhoainamcom.000webhostapp.com/Clock/RunChuongBao.php?id=" + row["id"] + "&maTK=" + maTK + "&run=0");
                }
            }
        }
        static String path;
        bool a = true;
        private void timer1_Tick(object sender, EventArgs e)
        {

            StreamReader sr = new StreamReader(@"Data\User\off.adb");
            if (sr.ReadLine().Equals("1"))
            {
                sr.Close();
                if (a)
                {
                    Exit = true;
                    Application.Exit();
                    a = false;
                }
            }
            else sr.Close();
            try
            {
                webString("https://wwwphamhoainamcom.000webhostapp.com/Clock/SelectChuongBao.php?maTK=" + maTK);
                if (ahihi != null)
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        dataTable = (DataTable)JsonConvert.DeserializeObject(ahihi, typeof(DataTable));
                    }
                    catch
                    {
                        Text = "Cannot Read Json!!!";
                        return;
                    }
                    Text = tenTK;
                    lengthDT = dataTable.Rows.Count;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["status"].Equals("1"))
                        {
                            path = row["path"].ToString();
                            webLoad("https://wwwphamhoainamcom.000webhostapp.com/Clock/StatusChuongBao.php?id=" + row["id"] + "&maTK=" + maTK + "&run=0");
                            for (int i = 0; i < 100; i++) VolUp();
                            axWindowsMediaPlayer1.URL = path;
                        }
                        if (row["run"].Equals("0"))
                        {
                            WMPLib.IWMPControls3 controls = (WMPLib.IWMPControls3)axWindowsMediaPlayer1.Ctlcontrols;
                            // Check first to be sure the operation is valid. 

                            if (controls.get_isAvailable("stop"))
                            {
                                controls.stop();
                            };
                        }
                        else
                        {
                            //do something here
                        }
                    }
                    textBox1.Text = ahihi;

                }
            }
            catch(Exception eu)
            {
               Text = "Lost Connect";
                if (er == 0)
                {
                    er = 1;
                    MessageBox.Show(eu.ToString());
                }
            }
        }
        int er = 0;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Exit) e.Cancel = true;
            else e.Cancel = false;
        }
    }
}
