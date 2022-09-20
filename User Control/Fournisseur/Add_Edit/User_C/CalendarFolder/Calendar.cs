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

        public int Month;
        public int Year;

        public Calendar()
        {
            InitializeComponent();
        }


        private void Calendar_Load(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;
            DateNow.Text = Now.ToString("dddd MMMM yyyy");
            Month = Now.Month;
            Year = Now.Year;
            Display_Days(0);

            FillCategory();
            LoadTasks();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Task Form = new Add_Task();
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

                        this.dataGridViewCat.ColumnCount = temp ;
                        
                        Row[0] = "ALL";

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Show();
        }
        private void LoadTasks()
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    Conx.ConnectionString = MainClass.ConnectionDataBase();
                    String Query = "SELECT * From Task;";
                    SqlCommand Cmd = new SqlCommand(Query, Conx);

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();


                    // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);

                    if (Read.HasRows)
                    {
                        this.dataGridView1.Rows.Clear();

                        while (Read.Read())
                        {
                            // add new header
                            this.dataGridView1.Rows.Add(Read["Details"], Read["Category"], Read["Statut"], Read["PriorityLevel"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Tasks existed !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
