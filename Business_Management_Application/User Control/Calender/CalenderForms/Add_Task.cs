using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C.CalendarFolder;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Calendar = Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C.Calendar;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms
{
    public partial class Add_Task : Form
    {
        Panel PanelDGV;
        public Add_Task(DateTime date , Panel panel )
        {
            InitializeComponent();
            dateTimePicker1.Value = date;
            PanelDGV = panel;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox1.Text != "" && richTextBox1.Text != String.Empty)
            {
                try
                {
                    using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                    {

                        string Query = $"INSERT INTO Task(Details,Statut,Category,TaskDate,PriorityLevel) values('{richTextBox1.Text}','{0}','{comboBox1.Text}',@Date,'{comboBox2.Text}')";
                        SqlCommand Cmd = new SqlCommand(Query, Conx);
                        Cmd.Parameters.AddWithValue("Date", (DateTime)dateTimePicker1.Value);
                        Conx.Open();
                        Cmd.ExecuteNonQuery();
                        this.Close();

                    }

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




        private void Add_Task_Load(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToString());
            FillCombobox();
        }


    }
}
