using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Store_Management_System.User_Control;
using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.ListFour;

namespace Store_Management_System
{
    public partial class Menu : Form
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["Store_Management_System.Properties.Settings.DataBaseMagasinConnectionString"].ConnectionString;
        public Menu()
        {
            InitializeComponent();
        }

        private void Display_Click(object sender, EventArgs e)
        {
            /*SqlConnection Conx = new SqlConnection();
            Conx.ConnectionString = ConnectionString ;

            String Query = "SELECT * From FOURNISSEUR;";
            SqlCommand Cmd = new SqlCommand(Query, Conx);

            Conx.Open();
            SqlDataReader ReadFour = Cmd.ExecuteReader();

            if (ReadFour.HasRows)
            {
                this.DataGridViewFour.Rows.Clear();
                while (ReadFour.Read())
                {
                    this.DataGridViewFour.Rows.Add(ReadFour["IDFOUR"], ReadFour["ENTREPRISE"], ReadFour["TELEPHONE"], ReadFour["CATEGORIE"], ReadFour["ADRESSE"]);
                }
                Conx.Close();
            }
            else
            {
                 MessageBox.Show("La Table Fournisseur est vide !!!");

            }*/



        }

      

        private void Menu_Four_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            MenuFournisseur MFour = new MenuFournisseur();
            MainControl.ShowControl(MFour,PanelContent);

           
        }
        
        private void PanelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
