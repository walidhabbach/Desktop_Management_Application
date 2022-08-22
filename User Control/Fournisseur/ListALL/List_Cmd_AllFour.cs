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

namespace Store_Management_System.User_Control.Fournisseur.List
{
    public partial class List_Cmd_AllFour : UserControl
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["Store_Management_System.Properties.Settings.DataBaseMagasinConnectionString"].ConnectionString;
        public List_Cmd_AllFour()
        {
            InitializeComponent();
        }

        private void List_Cmd_AllFour_Load(object sender, EventArgs e)
        {
            SqlConnection Conx = new SqlConnection();
            Conx.ConnectionString = ConnectionString;

            String Query = "SELECT * From COMMANDEFOUR;";
            SqlCommand Cmd = new SqlCommand(Query, Conx);

            Conx.Open();
            SqlDataReader ReadFour = Cmd.ExecuteReader();

            if (ReadFour.HasRows)
            {
                this.DataGridView.Rows.Clear();
                while (ReadFour.Read())
                {
                    this.DataGridView.Rows.Add( 
                            ReadFour["ID_CMD_FOUR"], 
                            ReadFour["IDFOUR"], 
                            ReadFour["DESCRIPTION"], 
                            ReadFour["STATUT"], 
                            ReadFour["DATECMD"], 
                            ReadFour["PESPECE"], 
                            ReadFour["PCHEQUE"], 
                            ReadFour["MONTANTTOTAL"], 
                            ReadFour["MTRESTE"], 
                            ReadFour["MTAVANCE"]

                    );
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
