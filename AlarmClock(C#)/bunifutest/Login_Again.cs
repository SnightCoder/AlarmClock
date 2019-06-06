using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace bunifutest
{
    public partial class Login_Again : UserControl
    {
        public Login_Again()
        {
            InitializeComponent();


        }


        Timer tm = new Timer() { Interval = 2000 };


        private void button1_Click(object sender, EventArgs e)
        {
            enter();
        }

        void enter()
        {
            StreamReader sr = new StreamReader(@"data\user\user.adb");
            if (textBox1.Text == sr.ReadLine() && textBox2.Text == sr.ReadLine())
            {
                userControl11.Visible = true;

                textBox1.Text = "";
                textBox2.Text = "";
                tm.Tick += tm_Tick;
                tm.Start();
            }
            else MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai");
            sr.Close();

        }
        //time này để đợi load
        void tm_Tick(object sender, EventArgs e)
        {
            tm.Stop();
            this.Hide();
            userControl11.Visible = false;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
                {
                    e.Handled = e.SuppressKeyPress = true;
                }
                if (textBox1.Text != "")
                {
                    if (textBox2.Text == "") textBox2.Focus();
                    else enter();
                }
                else if(textBox2.Text!="") {
                  
                        if (textBox1.Text == "") textBox1.Focus();
                        else enter();
                    
                }
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            buttonXoa.Visible = true;
            buttonXoa.Location = new Point(495, 157);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buttonXoa.Visible = true;
            buttonXoa.Location = new Point(495, 84);
        }
        //nút xoá
        private void label2_Click(object sender, EventArgs e)
        {
            if (buttonXoa.Location.Y == 84) textBox1.ResetText();
            if (buttonXoa.Location.Y == 157) textBox2.ResetText();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox2.UseSystemPasswordChar = false;
            else textBox2.UseSystemPasswordChar = true;
        }


    }
}
