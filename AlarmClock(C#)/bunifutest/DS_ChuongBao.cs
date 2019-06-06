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
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace bunifutest
{
    public partial class DS_ChuongBao : Form
    {
        List<ChuongBao> list = new List<ChuongBao>();
        int id, status, run;
        String name, path;
        Thread th;


        public DS_ChuongBao()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            MaximizeBox = false;
            Text = "Danh sách chuông báo online";
            panel1.Visible = false;

            //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
            //pictureBox1.Region = new Region(path);

            list.Add(new ChuongBao(2, "Nam", "c://it.mp3", 0, 1));
            list.Add(new ChuongBao(4, "Hung", "d://ai.wav", 1, 0));
            ReLoadData();
        }

        void LoadData()
        {
            flowLayoutPanel1.Controls.Clear();
            if (list.Count == 0)
            {
                flowLayoutPanel1.Controls.Add(panel2);
                panel2.Visible = true;

                return;
            }
            else panel2.Visible = false;

            foreach (var items in list)
            {

                Label Name = new Label();
                Label path = new Label();
                Panel panelBlue = new Panel();
                PictureBox image = new PictureBox();
                Panel panelWhite = new Panel();

                Name.AutoSize = true;
                Name.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Name.ForeColor = System.Drawing.Color.Black;
                Name.Location = new System.Drawing.Point(250, 16);
                Name.Size = new System.Drawing.Size(289, 49);
                Name.TabIndex = 0;
                Name.Text = items.Name;
                // 
                // label2
                // 
                path.AutoSize = true;
                path.Font = new System.Drawing.Font("Corbel", 13F);
                path.Location = new System.Drawing.Point(255, 66);
                path.Name = "label2";
                path.Size = new System.Drawing.Size(155, 27);
                path.Text = "Đường dẫn: " + items.Path;
                // 
                // panel2
                // 
                panelBlue.BackColor = System.Drawing.Color.DeepSkyBlue;
                panelBlue.Location = new System.Drawing.Point(0, 0);
                panelBlue.Size = new System.Drawing.Size(169, 228);
                // 
                // pictureBox1
                // 
                image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(214)))), ((int)(((byte)(64)))));
                image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                image.Location = new System.Drawing.Point(118, 44);
                image.Size = new System.Drawing.Size(100, 95);
                image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                image.TabStop = false;
                image.Image = Image.FromFile(@"Data\User\Anh\clock.png");
                // 
                // panel1
                // 
                panelWhite.BackColor = System.Drawing.Color.White;
                panelWhite.Controls.Add(image);
                panelWhite.Controls.Add(Name);
                panelWhite.Controls.Add(path);
                panelWhite.Controls.Add(panelBlue);
                panelWhite.Location = new System.Drawing.Point(3, 3);
                panelWhite.Size = new System.Drawing.Size(539, 186);
                panelWhite.TabIndex = 0;

                System.Drawing.Drawing2D.GraphicsPath pathG = new System.Drawing.Drawing2D.GraphicsPath();
                pathG.AddEllipse(0, 0, image.Width, image.Height);
                image.Region = new Region(pathG);
                flowLayoutPanel1.Controls.Add(panelWhite);

                panelWhite.Tag = items;
                panelWhite.Click += PanelWhite_Click;

            }
        }

        private Panel lastButton = null;
        private void PanelWhite_Click(object sender, EventArgs e)
        {
            String ten = (((Panel)sender).Tag as ChuongBao).Name;
            label2.Text = "Tên File: " + Path.GetFileName((((Panel)sender).Tag as ChuongBao).Path);
            textBox1.Text = ten;

            id = (((Panel)sender).Tag as ChuongBao).Id;
            name = ten;
            path = (((Panel)sender).Tag as ChuongBao).Path;
            status = (((Panel)sender).Tag as ChuongBao).Status;
            run = (((Panel)sender).Tag as ChuongBao).Run;

            Panel current = (Panel)sender;
            current.BackColor = Color.WhiteSmoke;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.White;

            // Update the previously-colored button
            lastButton = current;
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control item in flowLayoutPanel1.Controls.OfType<Panel>())
            {
                item.BackColor = Color.White;
            }
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            name =textBox1.Text;
            WebClient w = new WebClient();
            CheckInjection();
            String link = "https://wwwphamhoainamcom.000webhostapp.com/Clock/UpdateChuongBao.php?id=" + id + "&maTK=" + IdAccount.MaTaiKhoan + "&name=" + name + "&path=" + path;
            //Clipboard.SetText(link);
            Stream s = w.OpenRead(link);
            StreamReader sr = new StreamReader(s);
            String read = sr.ReadLine();
            sr.Close();
            if(read.Equals("Success"))
            ReLoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            WebClient w = new WebClient();
            path = @"Data\baothuc\ChuongBaoThuc\MusicBox.wav";
            name = "Tên chuông báo";
            status = 0;
            run = 1;
            CheckInjection();
            String link = "https://wwwphamhoainamcom.000webhostapp.com/Clock/InsertChuongBao.php?name=" + name + "&path=" + path + "&status=" + status + "&maTK=" + IdAccount.MaTaiKhoan + "&run=" + run;
            //Clipboard.SetText(link);

           Stream s= w.OpenRead(link);
            StreamReader sr = new StreamReader(s);
            String read = sr.ReadLine();
            panel1.Visible = false;
            sr.Close();
                if(read.Equals("Success"))
            ReLoadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Mở File Âm Thanh";
            theDialog.Filter = "File Âm Thanh|*.wav;*.mp3;*.mp4";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                path = theDialog.FileName;
                label2.Text=Path.GetFileName(path);

            }
        }

        void CheckInjection()
        {
            path = path.Replace(@"\", @"\\");
            path = path.Replace("&", "%26");
            path = path.Replace("'", "''");
            name = name.Replace("'", "''");
        }

        void ReLoadData()
        {
            list.Clear();
            WebClient w = new WebClient();
            Stream s = w.OpenRead("https://wwwphamhoainamcom.000webhostapp.com/Clock/SelectChuongBao.php?maTK=" + IdAccount.MaTaiKhoan);
            StreamReader sr = new StreamReader(s);
            String json = sr.ReadToEnd();
            sr.Close();
            DataTable data=new DataTable();
            try
            {
               data= (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
            }
            catch
            {
                list.Clear();
            }
            foreach (DataRow row in data.Rows)
                list.Add(new ChuongBao(Convert.ToInt32(row["id"]), row["name"].ToString(), row["path"].ToString(), Convert.ToInt32(row["status"]), Convert.ToInt32(row["run"])));
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WebClient w = new WebClient();
            Stream s=w.OpenRead("https://wwwphamhoainamcom.000webhostapp.com/Clock/DeleteChuongBao.php?id="+id+"&maTK="+IdAccount.MaTaiKhoan);
            StreamReader sr = new StreamReader(s);
            String read = sr.ReadLine();
            sr.Close();
            panel1.Visible = false;
            if (read.Equals("Success"))
                ReLoadData();
        }
    }
}
