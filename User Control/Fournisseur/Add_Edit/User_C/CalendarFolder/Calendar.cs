using Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C.CalendarFolder;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C
{
    public partial class Calendar : UserControl
    {

        public int Month;
        public int Year;

        public Calendar()
        {
            InitializeComponent();
        }


        private void Calendar_Load(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;

            Month = Now.Month;
            Year = Now.Year;
            Display_Days(0);
            this.dataGridViewCat.Rows.Add("All","bank");
        }

        private void Display_Days(int add)
        {

            string MonthName;
            //First Day of the month
            DateTime startofmonth;

            if (Month == 12 && add == 1)
            {
                Month = 1;
                Year = Year + 1;
            }
            else if (Month == 1 && add == -1)
            {
                Month = 12;
                Year = Year - 1;
            }
            else if (add == 1)
            {
                Month++;
            }
            else if (add == -1)
            {
                Month--;
            }

            MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(Month);
            label1.Text = MonthName + " " + Year;

            startofmonth = new DateTime(Year, Month, 1);

            //Count of days of the month
            int days = DateTime.DaysInMonth(Year, Month);

            //Convert the startofmonth to integer
            int daysofWeek = Convert.ToInt32(startofmonth.DayOfWeek.ToString("d"));

            if (daysofWeek == 0)
            {
                daysofWeek = 7;
            }

            //Blank User Control
            for (int i = 1; i < daysofWeek; i++)
            {
                UserControlBlank userControl = new UserControlBlank();
                daycontainer.Controls.Add(userControl);
            }

            // User Control days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays UCdays = new UserControlDays(i);
                daycontainer.Controls.Add(UCdays);
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            Display_Days(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            Display_Days(-1);
        }


    }

}
