using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
// Line 51
namespace bunifutest
{
    public partial class SignUp : Form
    {
        int xM, yM;
        bool moveM = false;
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_MouseDown(object sender, MouseEventArgs e)
        {
            xM = e.X;
            yM = e.Y;
            moveM = true;
        }

        private void SignUp_MouseUp(object sender, MouseEventArgs e)
        {
            moveM = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IdAccount.SignUp(textBox1.Text, textBox2.Text, textBox3.Text)) Close();
        }

        private void SignUp_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveM) SetDesktopLocation(Cursor.Position.X - xM, Cursor.Position.Y - yM);
        }
    }
}
