using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Store_Management_System.User_Control;
using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C;

namespace Store_Management_System
{
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
        }

        private void Display_Click(object sender, EventArgs e)
        {
            /*SqlConnection Conx = new SqlConnection();
            Conx.ConnectionString = MainClass.ConnectionString;

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
        public void Menu_Four_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            MenuFournisseur MFour = new MenuFournisseur();
            MainClass.ShowControl(MFour,PanelContent);
     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            Calendar MFour = new Calendar();
            MainClass.ShowControl(MFour, PanelContent);
        }
    }
}
