using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.List
{
    public partial class List_CHQ_AllFour : UserControl
    {

        public List_CHQ_AllFour()
        {
            InitializeComponent();
        }

     

        private void List_CHQ_AllFour_Load(object sender, EventArgs e)
        {
            SqlConnection Conx = new SqlConnection
            {
                ConnectionString = MainClass.ConnectionDataBase()
            };

            SqlCommand Cmd_RCHQFour = new SqlCommand("SELECT * From REGLE_CHQ_FOUR;", Conx);

            //Nom Four
            SqlCommand Cmd_NOMFour;
            SqlDataReader Read_NomFour;

            //CMD Four
            SqlCommand Cmd_CMDFour;
            SqlDataReader Read_CMDFour;

            //CHQFour
            SqlCommand Cmd_CHQFour;
            SqlDataReader Read_CHQFour;

            Conx.Open();
            SqlDataReader Read_RCHQFour = Cmd_RCHQFour.ExecuteReader();


            if (Read_RCHQFour.HasRows)
            {
                this.DataGridView.Rows.Clear();
                while (Read_RCHQFour.Read())
                {

                    //Return CMD Four
                    Cmd_CMDFour = new SqlCommand($"SELECT IDFOUR , MONTANTTOTAL FROM COMMANDEFOUR WHERE ID_CMD_FOUR = '{Read_RCHQFour[1]}';", Conx);
                    Read_CMDFour = Cmd_CMDFour.ExecuteReader();

                    while (Read_CMDFour.Read())
                    {

                        //Return NomFour
                        Cmd_NOMFour = new SqlCommand($"SELECT ENTREPRISE FROM FOURNISSEUR WHERE IDFOUR = '{Read_CMDFour["IDFOUR"]}';", Conx);
                        Read_NomFour = Cmd_NOMFour.ExecuteReader();

                        while (Read_NomFour.Read())
                        {

                            //Return CHQ Details
                            Cmd_CHQFour = new SqlCommand($"SELECT * From CHEQUEFOURNISSEUR WHERE IDCHQ_FOUR = '{Read_RCHQFour[0]}';", Conx);
                            Read_CHQFour = Cmd_CHQFour.ExecuteReader();

                            while (Read_CHQFour.Read())
                            {

                                this.DataGridView.Rows.Add(
                                        Read_RCHQFour["IDCHQ_FOUR"],
                                        Read_RCHQFour["ID_CMD_FOUR"],
                                        Read_CMDFour["IDFOUR"],
                                        Read_NomFour["ENTREPRISE"],
                                        Read_CHQFour["DATEDONNER"],
                                        Read_CHQFour["DATEPAYER"],
                                        Read_CHQFour["MONTANT"],
                                        Read_CMDFour["MONTANTTOTAL"]

                                );

                            }

                        }

                    }

                }
                Conx.Close();

                MainClass.DataGridMod(DataGridView);
                DataGridView.Columns["ID_CHQ_FOUR"].Width = 75;
                DataGridView.Columns["ID_CMD_FOUR"].Width = 75;
                DataGridView.Columns["IDFOUR"].Width = 75;
                DataGridView.Columns["Fournisseur"].Width = 150;
                DataGridView.Columns["Fournisseur"].DefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
                DataGridView.Columns["DATEDONNEE"].Width = 150;
                DataGridView.Columns["DATEPAYER"].Width = 150;
                DataGridView.Columns["MONTANT"].Width = 150;
                DataGridView.Columns["MONTANTTOTAL"].Width = 150;

                DataGridView.EnableHeadersVisualStyles = false;
                DataGridView.Columns["MONTANT"].HeaderCell.Style.BackColor = Color.Green; 
                DataGridView.Columns["MONTANT"].HeaderCell.Style.Font = new Font("Tahoma", 12, FontStyle.Bold);

                

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
