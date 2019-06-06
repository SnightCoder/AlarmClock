using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bunifutest
{
    public partial class openAgain : Form
    {
        public openAgain()
        {
            InitializeComponent();
        }
        Boolean xy; int x, y;
        private void openAgain_MouseDown(object sender, MouseEventArgs e)
        {
            xy = true;
            x = e.X;
            y = e.Y;
        }

        private void openAgain_MouseUp(object sender, MouseEventArgs e)
        {
            xy = false;
        }

        private void openAgain_MouseMove(object sender, MouseEventArgs e)
        {
            if (xy == true) this.SetDesktopLocation(Cursor.Position.X-x,Cursor.Position.Y-y);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            this.Close();
        }
    }
}
