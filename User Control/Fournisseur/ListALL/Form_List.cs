using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.ListALL
{
    public partial class Form_List : Form
    {
        private int IDFOUR;
        private int load;
        private String Query;

        public Form_List(int IDFOUR, int load, String Query)
        {
            InitializeComponent();
            this.IDFOUR = IDFOUR;
            this.load = load;
            this.Query = Query;
        }

        private void List_Load(object sender, EventArgs e)
        {
            if (load == 1)
            {
                Load_Data_Produit(Query);
            }
            else if (load == 2)
            {
                label.Text = "     Les Commandes Sélectionnés :";
                Data_Cmd(Query);
            }

        }
        private void Load_Data_Produit(String Query)
        {
            dataGridView1.Rows.Clear();

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                SqlCommand Cmd = new SqlCommand(Query, Conx);
                SqlCommand CmdProduit;
                SqlDataReader ReadProduit;
                Conx.Open();
                SqlDataReader Read = Cmd.ExecuteReader();


                if (Read.HasRows)
                {
                    this.dataGridView1.Rows.Clear();
                    this.dataGridView1.Columns.Clear();

                    this.dataGridView1.ColumnCount = 6;
                    this.dataGridView1.Columns[0].Name = "#";
                    this.dataGridView1.Columns[0].Width = 30;
                    this.dataGridView1.Columns[1].Name = "Produit";
                    this.dataGridView1.Columns[2].Name = "Designation";
                    this.dataGridView1.Columns[3].Name = "PrixACHAT";
                    this.dataGridView1.Columns[4].Name = "PrixVENTE";
                    this.dataGridView1.Columns[5].Name = "D_PrixVENTE";

                    while (Read.Read())
                    {
                        CmdProduit = new SqlCommand($"SELECT * FROM PRODUIT WHERE ID_PRODUIT = '{Read["ID_PRODUIT"]}';", Conx);
                        ReadProduit = CmdProduit.ExecuteReader();
                        while (ReadProduit.Read())
                        {
                            this.dataGridView1.Rows.Add((dataGridView1.RowCount + 1), ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], Math.Round(double.Parse(ReadProduit[4].ToString()), 2), Math.Round(double.Parse(ReadProduit[5].ToString()), 2), Math.Round(double.Parse(ReadProduit[5].ToString()), 2));
                        }
                    }

                    dataGridView1.Columns["Produit"].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);

                }
                else
                {
                    MessageBox.Show("La Table Produit est vide !!!");
                }
            }
        }

        private void Data_Cmd(String Query)
        {

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                string Statut = "non payée";
                SqlCommand Cmd = new SqlCommand(Query, Conx);
                SqlCommand Cmd1;

                Conx.Open();

                SqlDataReader Read = Cmd.ExecuteReader();
                SqlDataReader ReadCmd;

                if (Read.HasRows)
                {
                    this.dataGridView1.Rows.Clear();
                    this.dataGridView1.Columns.Clear();

                    this.dataGridView1.ColumnCount = 7;
                    this.dataGridView1.Columns[0].Name = "#";
                    this.dataGridView1.Columns[0].Width = 30;
                    this.dataGridView1.Columns[1].Name = "id";
                    this.dataGridView1.Columns[1].Width = 50;
                    this.dataGridView1.Columns[2].Name = "Description";
                    this.dataGridView1.Columns[4].Name = "Date";
                    this.dataGridView1.Columns[3].Name = "Statut";
                    this.dataGridView1.Columns[5].Name = "MTReste";
                    this.dataGridView1.Columns[6].Name = "MT";


                    while (Read.Read())
                    {
                        Cmd1 = new SqlCommand($"SELECT * FROM COMMANDEFOUR WHERE ID_CMD_FOUR = '{int.Parse(Read["ID_CMD_FOUR"].ToString())}'", Conx);
                        ReadCmd = Cmd1.ExecuteReader();

                        while (ReadCmd.Read())
                        {
                            if ((bool)ReadCmd["STATUT"])
                            {
                                Statut = "payée par CHQ";
                            }

                            this.dataGridView1.Rows.Add(
                                (dataGridView1.RowCount + 1),
                                ReadCmd["ID_CMD_FOUR"],
                                ReadCmd["DESCRIPTION"],
                                Statut,
                                Convert.ToDateTime(ReadCmd["DATECMD"]).ToString("dd MMMM yyyy"),
                                ReadCmd["MTRESTE"],
                                Math.Round(double.Parse(ReadCmd["MONTANTTOTAL"].ToString()), 2)
                                );

                        };
                    }
                }
                else
                {
                    MessageBox.Show("Aucune Commande a ete enregistrer de ce Fournisseur !!!");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
