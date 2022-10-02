using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.ListALL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms
{
    public partial class Confirmation : Form
    {
        private readonly int IDFOUR;
        private readonly string ENTREPRISE;
        Panel MainPanel_Four;
        Panel PanelFourListe;
        public Confirmation(int id, string ENTREPRISE, Panel MainPanel_Four, Panel PanelFourListe)
        {
            InitializeComponent();
            IDFOUR = id;
            this.ENTREPRISE = ENTREPRISE;
            this.MainPanel_Four = MainPanel_Four;
            this.PanelFourListe = PanelFourListe;
        }
      

        private void Delete(int IDFour)
        {
            //int position = this.DataGridView.CurrentRow.Index;
            //int IDFour = int.Parse(this.DataGridView.Rows[position].Cells[0].Value);

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                SqlCommand Cmd = new SqlCommand
                {
                    Connection = Conx,
                    CommandText = "DELETE FROM FOURNISSEUR WHERE IDFOUR = @IDFour;"
                };

                try
                {
                    Cmd.Parameters.AddWithValue("@IDFour", IDFour);
                    Conx.Open();
                    Cmd.ExecuteNonQuery();
                    ListFour LFour = new ListFour(MainPanel_Four, PanelFourListe);
                    MainClass.ShowControl(LFour, PanelFourListe);
                    Conx.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "2002")
            {
                Delete(IDFOUR);
                MessageBox.Show($"Fournisseur {ENTREPRISE} a été supprimé !!!");
            }
            else
            {
              
                label3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.UseSystemPasswordChar = true;
            textBox1.PasswordChar ='*';
            textBox1.MaxLength = 6;
        }

    }
}
