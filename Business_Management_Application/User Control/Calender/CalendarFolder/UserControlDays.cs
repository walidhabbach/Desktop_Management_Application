using Store_Management_System.Class;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C.CalendarFolder
{
    public partial class UserControlDays : UserControl
    {
        readonly Panel PanelDGV;
        readonly Panel daycontainer; 
        public UserControlDays(int numday, Panel daycontainer, Panel panelDGV, bool color)
        {
            InitializeComponent();
            button1.Text = numday + "";
            this.PanelDGV = panelDGV;
            this.daycontainer = daycontainer;

            if (color == true)
            {
                button1.FlatAppearance.BorderSize = 2;
                button1.FlatAppearance.BorderColor = SystemColors.Highlight;
                button1.FlatAppearance.MouseOverBackColor = SystemColors.Highlight; 
            }
            else
            {
                button1.FlatAppearance.BorderSize = 1;
                button1.FlatAppearance.BorderColor = Color.Silver;
                button1.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            }
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {  
            try
            {
                DGVTask UC;

                Calendar.Day = int.Parse(button1.Text);
                daycontainer.Controls.Clear();
                Calendar.Ins_Calendar.Display_Days(0);

                Calendar.Ins_Calendar.DisplaySelectedDay();

                if (Calendar.Category == "Tous")
                {
                    UC = new DGVTask($"SELECT * FROM Task WHERE day(TaskDate)= '{Calendar.Day}'and month(TaskDate) = '{Calendar.Month}' and year(TaskDate) = '{Calendar.Year}';", PanelDGV);
                }
                else
                {
                    UC = new DGVTask($"SELECT * FROM Task WHERE Category = '{Calendar.Category}' and day(TaskDate)= '{Calendar.Day}'and month(TaskDate) = '{Calendar.Month}' and year(TaskDate) = '{Calendar.Year}';", PanelDGV);
                }
                MainClass.ShowControl(UC, PanelDGV);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
