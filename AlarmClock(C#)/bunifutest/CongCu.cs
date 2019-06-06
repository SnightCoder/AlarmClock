using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bunifutest
{
    public partial class CongCu : Form
    {
        public CongCu()
        {
            InitializeComponent();
            tinhGioUI1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tinhGioUI1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bamGio_UI1.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Boolean bl; int x, y;
        private void CongCu_MouseDown(object sender, MouseEventArgs e)
        {
            bl = true;
            x = e.X;
            y = e.Y;
        }

        private void CongCu_MouseUp(object sender, MouseEventArgs e)
        {
            bl = false;
        }

        private void CongCu_MouseMove(object sender, MouseEventArgs e)
        {
            if (bl == true) this.SetDesktopLocation(Cursor.Position.X-x,Cursor.Position.Y-y);
        }
    }
}
