using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms
{
    public partial class Add_Task : Form
    {
        public Add_Task()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox1.Text != "" && richTextBox1.Text != String.Empty)
                    {
                        string Query = $"INSERT INTO Task(Details,Statut,Category,TaskDate,PriorityLevel) values('{richTextBox1.Text}','{0}','{comboBox1.Text}',@Date,'{comboBox2.Text}')";
                        SqlCommand Cmd = new SqlCommand(Query, Conx);
                        Cmd.Parameters.AddWithValue("Date", (DateTime)dateTimePicker1.Value);
                        Conx.Open();
                        Cmd.ExecuteNonQuery();
                        this.Close();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_Task_Load(object sender, EventArgs e)
        {
            FillCombobox();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
