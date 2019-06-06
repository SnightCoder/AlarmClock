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

namespace bunifutest
{
    public partial class LichLabelSetting : Form
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

        String u, u1; 
        int i;
        public LichLabelSetting()
        {
            InitializeComponent();
            StreamReader srChoice = new StreamReader(@"Data\LichText\Choice.adb"); 
            i=Convert.ToInt32(srChoice.ReadLine());
            srChoice.Close();
            StreamReader srImage = new StreamReader(@"Data\LichText\Lich"+i+"\\ImagePath.adb");
            String imagePath = srImage.ReadLine();
            srImage.Close();
            StreamReader srText = new StreamReader(@"Data\LichText\Lich"+i+"\\Text.adb");
            String texti = (srText.ReadToEnd());
            srText.Close();
            StreamReader srTitle = new StreamReader(@"Data\LichText\Lich" + i + "\\Title.adb");
            String titlei = (srTitle.ReadToEnd());
            srTitle.Close();
            textBox1.Text = texti;
            textBox2.Text = titlei;
            u1 = textBox1.Text;
            u = textBox2.Text;
            try
            {
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\" + imagePath);
            }catch{
                pictureBox1.Image = new Bitmap(@"Data\Baothuc\AnhBaoThuc\Lichmacdinh.jpg");
            }
            Load();

        }
        void Load()
        {
            button2.Click+=pictureBox1_Click;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            button3.Click += button3_Click;
            button1.Click += button1_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;

        }

        void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void button4_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button1.Visible = false;
            button3.Visible = true;
            button5.Visible = true;
            button4.Visible = false;
            textBox1.ReadOnly = true; textBox1.BorderStyle = BorderStyle.None;
            u = textBox2.Text;
            u1 = textBox1.Text;
            StreamWriter swText = new StreamWriter(@"Data\LichText\Lich" + i + "\\Text.adb");
            swText.Write(u1); swText.Close();
            StreamWriter swTitle = new StreamWriter(@"Data\LichText\Lich" + i + "\\Title.adb");
            swTitle.Write(u); swTitle.Close();

        }

        void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button1.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            button3.Visible = true;
            textBox2.ReadOnly = true;
            textBox1.ReadOnly = true; textBox1.BorderStyle = BorderStyle.None;
            textBox2.Text = u;
            textBox1.Text = u1;

        }

        void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button1.Visible = true;
            button4.Visible = true;
            button3.Visible = false;
            button5.Visible = false;
            textBox1.ReadOnly = false; textBox2.ReadOnly = false;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (xy == true) this.SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            xy = false;
        }
        Boolean xy; int x, y;
        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            xy = true;
            x = e.X;
            y = e.Y;
        }

        void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = Directory.GetCurrentDirectory() + "\\data\\baothuc\\anhbaothuc";
            DialogResult d = f.ShowDialog();
            if (d == DialogResult.OK)
            {
                String file = f.FileName;
                String file1 = Path.GetFileName(f.FileName);
                String pathImage1 = @"data\baothuc\anhbaothuc";
                pathImage1 = pathImage1 + "\\" + file1;
                try
                {
                    File.Copy(file, pathImage1);
                }
                catch { }

                StreamWriter sr = new StreamWriter(@"Data\LichText\Lich" + i + "\\ImagePath.adb");
                sr.WriteLine(pathImage1);
                sr.Close();
                try
                {
                    pictureBox1.Image = new Bitmap(Application.StartupPath + "\\" + pathImage1);
                }
                catch
                {
                    pictureBox1.Image = new Bitmap(@"Data\Baothuc\AnhBaoThuc\Lichmacdinh.jpg");
                }

            };
        }



    }
}
