using System;
using System.Data;
using Store_Management_System.Class;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.List
{
    public partial class List_Cmd_AllFour : UserControl
    {
        public List_Cmd_AllFour()
        {
            InitializeComponent();
        }

        private void List_Cmd_AllFour_Load(object sender, EventArgs e)
        {
            SqlConnection Conx = new SqlConnection();

            Conx.ConnectionString = MainClass.ConnectionDataBase();

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
