using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C.CalendarFolder;
using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using Calendar = Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C.Calendar;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms
{
    public partial class Edit_Task : Form
    {
        private int IdTask;
        private readonly Panel PanelDGV;
        public Edit_Task(int id, Panel panel)
        {
            InitializeComponent();
            PanelDGV = panel;
            dateTimePicker1.Text = Calendar.Day + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(Calendar.Month) + " " + Calendar.Year;

            IdTask = id;
        }

        private void Edit_Task_Load(object sender, EventArgs e)
        {
            FillCombobox();
            LoadTask();
        }
        private void LoadTask()
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {

                    SqlCommand Cmd = new SqlCommand($"SELECT * FROM Task  WHERE IdTask = '{IdTask}';", Conx);

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();

                    if (Read.HasRows)
                    {
                        while (Read.Read())
                        {

                            richTextBox1.Text = Read["Details"].ToString();

                            comboBox1.Text = Read["Category"].ToString();
                            comboBox2.Text = Read["PriorityLevel"].ToString();
                        }
                    }
                    else
                    {
                        //MessageBox.Show("No Tasks existed !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Edit()
        {

            if (comboBox1.Text != "" && comboBox2.Text != "" && richTextBox1.Text != String.Empty)
            {
                try
                {
                    using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                    {

                        string Query = $"UPDATE Task SET Details = '{richTextBox1.Text}',Statut = '{0}',Category = '{comboBox1.Text}', TaskDate = @Date , PriorityLevel = '{comboBox2.Text}' where IdTask = '{IdTask}' ";
                        SqlCommand Cmd = new SqlCommand(Query, Conx);
                        Cmd.Parameters.AddWithValue("Date", (DateTime)dateTimePicker1.Value);
                        Conx.Open();
                        Cmd.ExecuteNonQuery();
                        this.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox1.Text == "")
            {

                MessageBox.Show("Selecter la categorie !!! ");
                comboBox1.Focus();
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Selecter  Niveau de Priority !!! ");
                comboBox2.Focus();
            }
            else if (richTextBox1.Text == String.Empty)
            {
                MessageBox.Show("Verifier Details !!! ");
                richTextBox1.Focus();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Edit();
            PanelDGV.Controls.Clear();

            if (Calendar.Category == "Tous")
            {
                DGVTask UC = new DGVTask($"SELECT * FROM Task  WHERE day(TaskDate)= '{Calendar.Day}'and month(TaskDate) = '{Calendar.Month}' and year(TaskDate) = '{Calendar.Year}';", PanelDGV);
                MainClass.ShowControl(UC, PanelDGV);

            }
            else
            {
                DGVTask UC = new DGVTask($"SELECT * FROM Task  WHERE Category = '{Calendar.Category}'and  day(TaskDate)= '{Calendar.Day}'and month(TaskDate) = '{Calendar.Month}' and year(TaskDate) = '{Calendar.Year}';", PanelDGV);
                MainClass.ShowControl(UC, PanelDGV);

            }


        }


        private void FillCombobox()
        {
            comboBox1.Items.Clear();
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    String Query = "SELECT Category From CALENDAR;";
                    SqlCommand Cmd = new SqlCommand(Query, Conx);

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();
                    // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);

                    if (Read.HasRows)
                    {
                        while (Read.Read())
                        {
                            comboBox1.Items.Add(Read[0].ToString());
                        }
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
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
