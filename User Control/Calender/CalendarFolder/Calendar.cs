using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C.CalendarFolder;
using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C
{
    public partial class Calendar : UserControl
    {
        public static int Day;
        public static int Month;
        public static int Year;
        public static string Category = "Tous";
        public Calendar()
        {
            InitializeComponent();
        
        }
        private void InitializeDGV(string Query)
        {
            // PanelDGV.Controls.Clear();
            DGVTask UC = new DGVTask(Query, PanelDGV);
            MainClass.ShowControl(UC, PanelDGV);
        }


        private void Calendar_Load(object sender, EventArgs e)
        {
            DateNow.Text = DateTime.Now.ToString("dddd MMMM yyyy");
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
            Day = DateTime.Now.Day;

            Display_Days(0, daycontainer, PanelDGV);
            label1.Text = Day + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(Month) + " " + Year;

            FillCategory();

            PanelDGV.Controls.Clear();
            InitializeDGV($"SELECT * From Task WHERE day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}';");

        }
        //Display days in Calendar 
        public static void Display_Days(int add, Panel daycontainer, Panel PanelDGV)
        {
            //First Day of the month
            DateTime startofmonth;

            if (Month == 12 && add == 1)
            {
                Month = 1;
                Year ++;
            }
            else if (Month == 1 && add == -1)
            {
                Month = 12;
                Year --;
            }
            else if (add == 1)
            {
                Month++;
            }
            else if (add == -1)
            {
                Month--;
            }

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
                if (Calendar.Day == i)
                {
                    UserControlDays UCdays = new UserControlDays(i, daycontainer, PanelDGV, true);
                    daycontainer.Controls.Add(UCdays);
                }
                else
                {
                    UserControlDays UCdays = new UserControlDays(i, daycontainer, PanelDGV, false);
                    daycontainer.Controls.Add(UCdays);
                }
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            Display_Days(1, daycontainer, PanelDGV);
            label1.Text = Day + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(Month) + " " + Year;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            Display_Days(-1, daycontainer, PanelDGV);
            label1.Text = Day + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(Month) + " " + Year;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Task Form = new Add_Task(DateTime.Parse(Day + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(Month) + " " + Year), PanelDGV);
            Form.Show();
        }

        private void FillCategory()
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    String Query = "SELECT Category From CALENDAR;";
                    SqlCommand Cmd = new SqlCommand(Query, Conx);
                    SqlCommand CmdCount = new SqlCommand("Select count(*) FROM CALENDAR;", Conx);
                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();
                    SqlDataReader Count = CmdCount.ExecuteReader();

                    // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);
                    this.dataGridViewCat.Rows.Clear();
                    if (Read.HasRows && Count.HasRows)
                    {
                        int i = 1;
                        int temp = 0;
                        string[] Row = null;

                        while (Count.Read())
                        {
                            temp = int.Parse(Count[0].ToString());
                        }
                        temp++;
                        Row = new string[temp];

                        this.dataGridViewCat.ColumnCount = temp;

                        Row[0] = "Tous";

                        while (Read.Read())
                        {
                            Row[i] = Read["Category"].ToString();
                            i++;
                        }

                        this.dataGridViewCat.Rows.Add(Row);

                        Conx.Close();

                    }
                    else
                    {
                        MessageBox.Show("Aucune catégorie existe !!!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            Category Form = new Category();
            Form.Show();
        }


        private void dataGridViewCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String ColName;
            DataGridViewRow Row;
            label1.Text = Day + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(Month) + " " + Year;

            if (e.RowIndex >= 0)
            {
                Row = dataGridViewCat.Rows[e.RowIndex];

                // IDFour = Convert.ToInt32(Row.Cells["IDFOUR"].Value);
                ColName = Row.Cells[e.ColumnIndex].Value.ToString();

                if (ColName == "Tous")
                {
                    InitializeDGV($"SELECT * FROM Task WHERE  day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}' ;");

                }
                else
                {
                    InitializeDGV($"SELECT * FROM Task WHERE  Category = '{ColName}' and day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}';");

                }
                Category = ColName;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitializeDGV($"SELECT * FROM Task WHERE Statut = '{0}' and day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}' ;");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitializeDGV($"SELECT * FROM Task WHERE Statut = '{1}' and day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}' ;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridViewCat.Rows[0].Selected = false;
            this.dataGridViewCat.Rows[0].Cells[0].Selected = true;
            InitializeDGV($"SELECT * FROM Task  WHERE day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}';");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Day = DateTime.Now.Day;
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
            label1.Text = Day + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(Month) + " " + Year;

            daycontainer.Controls.Clear();
            Display_Days(0, daycontainer, PanelDGV);
        }

        private void daycontainer_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = Day + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(Month) + " " + Year;
        }

        private void daycontainer_MouseHover(object sender, EventArgs e)
        {
            label1.Text = Day + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(Month) + " " + Year;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Category != "Tous" && Category != string.Empty)
            {
                InitializeDGV($"SELECT * FROM Task WHERE  Category = '{Category}' and  PriorityLevel = 'Urgent' and day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}' ");
            }
            else if(Category == "Tous")
            {
                InitializeDGV($"SELECT * FROM Task WHERE PriorityLevel = 'Urgent' and day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}' ;");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Category != "Tous" && Category != string.Empty)
            {
                InitializeDGV($"SELECT * FROM Task WHERE  Category = '{Category}' and  PriorityLevel = 'Moins urgent' and day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}' ");
            }
            else if (Category == "Tous")
            {
                InitializeDGV($"SELECT * FROM Task WHERE PriorityLevel = 'Moins urgent' and day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}' ");
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Category != "Tous" && Category != string.Empty)
            {
                InitializeDGV($"SELECT * FROM Task WHERE  Category = '{Category}' and  PriorityLevel = 'Non urgent' and day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}' ");
            }
            else if (Category == "Tous")
            {
                InitializeDGV($"SELECT * FROM Task WHERE PriorityLevel = 'Non urgent' and day(TaskDate)= '{Day}'and month(TaskDate) = '{Month}' and year(TaskDate) = '{Year}' ");
            }
        }

        private void PanelDGV_Paint(object sender, PaintEventArgs e)
        {

        }

        private void daycontainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
