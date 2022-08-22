using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.ListFour
{
    public partial class ListFour : UserControl
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["Store_Management_System.Properties.Settings.DataBaseMagasinConnectionString"].ConnectionString;
        public ListFour()
        {
            InitializeComponent();
        }

        private void ListFour_Load(object sender, EventArgs e)
        {
            SqlConnection Conx = new SqlConnection();
            Conx.ConnectionString = ConnectionString;

            String Query = "SELECT * From FOURNISSEUR;";
            SqlCommand Cmd = new SqlCommand(Query, Conx);

            Conx.Open();
            SqlDataReader ReadFour = Cmd.ExecuteReader();

            if (ReadFour.HasRows)
            {
                this.DataGridView.Rows.Clear();
                while (ReadFour.Read())
                {
                    this.DataGridView.Rows.Add(ReadFour["IDFOUR"], ReadFour["ENTREPRISE"], ReadFour["TELEPHONE"], ReadFour["CATEGORIE"], ReadFour["ADRESSE"]);
                }
                Conx.Close();
            }
            else
            {
                MessageBox.Show("La Table Fournisseur est vide !!!");

            }
        }
    }
}
