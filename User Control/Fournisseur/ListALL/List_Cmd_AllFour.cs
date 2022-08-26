using System;
using System.Data;
using Store_Management_System.Class;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

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
            SqlConnection Conx = new SqlConnection
            {
                ConnectionString = MainClass.ConnectionDataBase()
            };
            string Statut = "non payée";
            String QueryCmdFour = "SELECT * From COMMANDEFOUR;";

            SqlCommand CmdFour = new SqlCommand(QueryCmdFour, Conx);
            SqlCommand CmdNomFour ;
            

            Conx.Open();
            SqlDataReader ReadCmdFour = CmdFour.ExecuteReader();
            SqlDataReader ReadNomFour;
            if (ReadCmdFour.HasRows)
            {
                this.DataGridView.Rows.Clear();
                
                    MainClass.DataGridMod(DataGridView, 40);
                    DataGridView.Columns["ID_CMD_FOUR"].Width = 75;
                    DataGridView.Columns["ENTREPRISE"].Width = 150;
                    DataGridView.Columns["ENTREPRISE"].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);
                    DataGridView.Columns["DESCRIPTION"].Width = 150;
                    DataGridView.Columns["STATUT"].Width = 150;
                    DataGridView.Columns["STATUT"].DefaultCellStyle.BackColor = Color.Red;
                    DataGridView.Columns["DATECMD"].Width = 150;
                    DataGridView.Columns["PESPECE"].Width = 100;
                    DataGridView.Columns["PCHEQUE"].Width = 100;
                    DataGridView.Columns["MONTANT_TOTAL"].Width = 150;
                    DataGridView.Columns["MTRESTE"].Width = 150;
                    DataGridView.Columns["MTAVANCE"].Width = 150;

                while (ReadCmdFour.Read())
                {
                    CmdNomFour = new SqlCommand("SELECT ENTREPRISE FROM FOURNISSEUR WHERE IDFOUR = @IDFOUR;", Conx);
                    CmdNomFour.Parameters.AddWithValue("@IDFour", ReadCmdFour["IDFOUR"]);
                    ReadNomFour = CmdNomFour.ExecuteReader();

                    while (ReadNomFour.Read())
                    {
                        if((bool)ReadCmdFour["STATUT"])
                        {
                            Statut = "payée";
                            DataGridView.Columns["STATUT"].DefaultCellStyle.BackColor = Color.Green;
                        }
                        this.DataGridView.Rows.Add(
                            ReadCmdFour["ID_CMD_FOUR"],
                            ReadNomFour["ENTREPRISE"],
                            ReadCmdFour["DESCRIPTION"],
                            Statut,
                            ReadCmdFour["DATECMD"],
                            ReadCmdFour["PESPECE"],
                            ReadCmdFour["PCHEQUE"],
                            ReadCmdFour["MONTANTTOTAL"],
                            ReadCmdFour["MTRESTE"],
                            ReadCmdFour["MTAVANCE"]

                        );

                    };

                };
                Conx.Close();
            }
            else
            {
                MessageBox.Show("La Table Fournisseur est vide !!!");

            }
          }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

       
    }


