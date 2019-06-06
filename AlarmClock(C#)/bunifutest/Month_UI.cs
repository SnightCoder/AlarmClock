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
    public partial class Month_UI : UserControl
    {
     

        Timer tm = new Timer() { Interval = 100 };

        #region Peoperties
        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        #endregion
        public  Month_UI()
        {
            InitializeComponent();
            DateTime dt = dtpkDate.Value;
            label1.Text = "Tháng "+dt.ToString("MM/yyyy");
            tm.Tick += tm_Tick;
            LoadMatrix();
        }

        void tm_Tick(object sender, EventArgs e)
        {
        }

        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();

            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, 0), FlatStyle=FlatStyle.Flat};
            for (int i = 0; i < Cons.DayOfColumn; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfWeek; j++)
                {
                    Button btn = new Button() { Width = Cons.dateButtonWidth, Height = Cons.dateButtonHeight, FlatStyle = FlatStyle.Flat };
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.margin, oldBtn.Location.Y);
                    pnlMatrix.Controls.Add(btn);
                    Matrix[i].Add(btn);

                    oldBtn = btn;
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, oldBtn.Location.Y + Cons.dateButtonHeight)  };
            }

            SetDefaultDate();
        }

        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;
                default:
                    return 30; ;
            }
        }

        void AddNumberIntoMatrixByDate(DateTime date)
        {
            ClearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);

            int line = 0;

            for (int i = 1; i <= DayOfMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();

                if (isEqualDate(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.FromArgb(0, 120, 215);
                }

                if (isEqualDate(useDate, date))
                {
                    
                }

                if (column >= 6)
                    line++;

                useDate = useDate.AddDays(1);
            }
        }

        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.FromArgb(77, 89, 161);
                    btn.ForeColor = Color.FromArgb(185, 189, 217);
                }
            }
        }

        void SetDefaultDate()
        {
            dtpkDate.Value = DateTime.Now;
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
            DateTime dt = dtpkDate.Value;
            label1.Text = "Tháng " + dt.ToString("MM/yyyy");

        }

        private void btnPreviours_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
            DateTime dt = dtpkDate.Value;
            label1.Text = "Tháng " + dt.ToString("MM/yyyy");
        }

        private void btnToDay_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
            DateTime dt = dtpkDate.Value;
            label1.Text = "Tháng " + dt.ToString("MM/yyyy");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pnlMatrix_Paint(object sender, PaintEventArgs e)
        {

        }

      

    }
    class Cons
    {
        public static int DayOfWeek = 7;
        public static int DayOfColumn = 6;
        //29, 21
        public static int dateButtonWidth = 29;
        public static int dateButtonHeight = 21;

        public static int margin = 6;
    }

    }

