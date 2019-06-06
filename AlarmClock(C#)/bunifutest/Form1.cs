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
using bunifutest;

namespace Login_To_Exit
{
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"data\user\user.adb");
            if (textBox1.Text == sr.ReadLine() && textBox2.Text == sr.ReadLine())
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
            else MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            sr.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
