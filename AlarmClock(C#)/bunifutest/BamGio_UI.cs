using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bunifutest
{
    public partial class BamGio_UI : UserControl
    {
        public BamGio_UI()
        {
            InitializeComponent(); tim.Tick += tim_Tick;
        }
        void tim_Tick(object sender, EventArgs e)
        {
            TimeSpan tm = new TimeSpan(0, 0, i);
            dt = dt.Add(tm);
            label1.Text = dt.ToString("HH:mm:ss");
            label2.Text = dt.Millisecond.ToString();

        }
        Timer tim = new Timer() { Interval = 1000 };
        int i = 1;
        DateTime dt = Convert.ToDateTime("0:0:0");
        private void button1_Click(object sender, EventArgs e)
        {
            Resetbtn.Visible = true;
            ResetTimebtn.Visible = true;
            Lapbtn.Visible = true;
            listView1.Visible = true;
           
            DeleteAllbtn.Visible = true;
            ResetTimebtn.Enabled = true;
            button2.Visible = true;
            tim.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tim.Stop();
            
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(label1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tim.Stop();
            ResetTimebtn.Enabled = false; button2.Visible = false;
            dt = Convert.ToDateTime("0:0:0");
            label1.Text = dt.ToString("HH:mm:ss");
            label2.Text = dt.Millisecond.ToString();
        }
        int ii = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(getText);
            button5.Visible = false; Deletebtn.Visible = false;

        }
        String getText = "";
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                ListView lw = sender as ListView;
                if (lw.SelectedItems.Count > 0)
                {
                    ListViewItem item = lw.SelectedItems[0];
                    getText = item.Text;
                    button5.Visible = true;
                    Deletebtn.Visible = true;
                }
            
        }

        private void BamGio_UI_Load(object sender, EventArgs e)
        {

        }

        private void button4_2Click(object sender, EventArgs e)
        {
            //tim.Stop();
            dt = Convert.ToDateTime("0:0:0");
            listView1.Items.Add(label1.Text + ":" + label2.Text);
            label1.Text = dt.ToString("HH:mm:ss");
            label2.Text = dt.Millisecond.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
            if (listView1.SelectedItems != null)
            {
              for (int i = 0; i < listView1.Items.Count; i++)
              {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                    i--;
                }
              }
            }
            Deletebtn.Visible = false;
            button5.Visible = false;
            //end
         }

        private void button3_Click_2(object sender, EventArgs e)
        {
            listView1.Items.Clear(); button5.Visible = false; Deletebtn.Visible = false;
        } 
    }
}
