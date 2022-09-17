using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.ListALL
{
    public partial class ListCMD : UserControl
    {
        private readonly int IDFOUR;
        private readonly Panel Content;
        private readonly int load;
        public ListCMD(int ID, Panel content, int load)
        {
            this.load = load;
            IDFOUR = ID;
            Content = content;
            InitializeComponent();

        }

        private void List_Cmd_Four(int IDFOUR)
        {
            label.Text = "Les Commandes :";
            label1.Text = "Produits Sélectionnés :";

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                string Statut = "non payée";
                string MPaiement = "PESPECE";
                String QueryCmdFour = "SELECT * From COMMANDEFOUR WHERE IDFOUR = @IDFOUR;";

                SqlCommand CmdFour = new SqlCommand(QueryCmdFour, Conx);
                CmdFour.Parameters.AddWithValue("IDFOUR", IDFOUR);

                Conx.Open();
                SqlDataReader ReadCmdFour = CmdFour.ExecuteReader();
                if (ReadCmdFour.HasRows)
                {
                    this.dataGridView2.Rows.Clear();
                    this.dataGridView2.Columns.Clear();

                    this.dataGridView2.ColumnCount = 6;
                    this.dataGridView2.Columns[0].Name = "IDCMD";
                    this.dataGridView2.Columns[1].Name = "DESCRIPTION";
                    this.dataGridView2.Columns[2].Name = "STATUT";
                    this.dataGridView2.Columns[3].Name = "DATECMD";
                    this.dataGridView2.Columns[4].Name = "Mode de Paiement";
                    this.dataGridView2.Columns[5].Name = "MONTANT TOTAL";


                    MainClass.DataGridMod(this.dataGridView2);


                    //Button Delete, Edit
                    MainClass.Button_DGV(dataGridView2, "Edit", "edit");
                    dataGridView2.Columns["Edit"].Width = 70;
                    MainClass.Button_DGV(dataGridView2, "Delete", "delete");
                    dataGridView2.Columns["Delete"].Width = 70;

                    while (ReadCmdFour.Read())
                    {
                        if ((bool)ReadCmdFour["STATUT"])
                        {
                            Statut = "payée";
                            this.dataGridView2.Columns[2].DefaultCellStyle.BackColor = Color.Green;
                        }
                        else
                        {
                            this.dataGridView2.Columns[2].DefaultCellStyle.BackColor = Color.Red;
                        }
                        if ((bool)ReadCmdFour["PCHEQUE"] && (bool)ReadCmdFour["PESPECE"])
                        {
                            MPaiement = "CHEQUE ET PESPECE";
                        }
                        else if ((bool)ReadCmdFour["PCHEQUE"])
                        {
                            MPaiement = "CHEQUE";
                        }
                        else if ((bool)ReadCmdFour["PESPECE"])
                        {
                            MPaiement = "PESPECE";
                        }
                        this.dataGridView2.Rows.Add(
                            ReadCmdFour["ID_CMD_FOUR"],
                            ReadCmdFour["DESCRIPTION"],
                            Statut,
                            string.Format("{0:0.##}", ReadCmdFour["DATECMD"].ToString()),
                            MPaiement,
                            ReadCmdFour["MONTANTTOTAL"]
                        );

                    };

                }

                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");

                }
            }
        }
        private void Load_Data_Produit(int IDCMD)
        {
            dataGridView1.Rows.Clear();

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                SqlCommand Cmd = new SqlCommand($"SELECT ID_PRODUIT FROM COMMANDER WHERE ID_CMD_FOUR = '{IDCMD}';", Conx);
                SqlCommand CmdProduit;
                SqlDataReader ReadProduit;
                Conx.Open();
                SqlDataReader Read = Cmd.ExecuteReader();


                if (Read.HasRows)
                {
                    this.dataGridView1.Rows.Clear();
                    this.dataGridView1.Columns.Clear();

                    this.dataGridView1.ColumnCount = 5;
                    this.dataGridView1.Columns[0].Name = "IDPRODUIT";
                    this.dataGridView1.Columns[1].Name = "DESIGNATION";
                    this.dataGridView1.Columns[2].Name = "PRIXACHAT";
                    this.dataGridView1.Columns[3].Name = "PRIXVENTE";
                    this.dataGridView1.Columns[4].Name = "DPRIXVENTE";

                    while (Read.Read())
                    {
                        CmdProduit = new SqlCommand($"SELECT * FROM PRODUIT WHERE ID_PRODUIT = '{Read["ID_PRODUIT"]}';", Conx);
                        ReadProduit = CmdProduit.ExecuteReader();
                        while (ReadProduit.Read())
                        {
                            this.dataGridView1.Rows.Add(ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[4].ToString()), String.Format("{0:0.##}", ReadProduit[5].ToString()), String.Format("{0:0.##}", ReadProduit[6].ToString()));
                        }
                    }

                    dataGridView1.Columns["DESIGNATION"].Width = 200;
                    dataGridView1.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);

                }
                else
                {
                    MessageBox.Show("La Table Produit est vide !!!");
                }
            }
        }

        private void List_CHQ_Four(int IDFOUR)
        {
            label.Text = "Listes des Cheques :";
            label1.Text = "Les Commandes Sélectionnés :";


            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                this.dataGridView2.Rows.Clear();
                this.dataGridView2.Columns.Clear();

                this.dataGridView2.ColumnCount = 4;
                this.dataGridView2.Columns[0].Name = "IDCHQ";
                this.dataGridView2.Columns[1].Name = "DATEDONNER";
                this.dataGridView2.Columns[2].Name = "DATEPAYER";
                this.dataGridView2.Columns[3].Name = "MONTANT";

                //Return CHQ Details
                SqlCommand Cmd_CHQFour = new SqlCommand($"SELECT * From CHEQUEFOURNISSEUR WHERE IDFOUR = '{IDFOUR}' ;", Conx);
                Conx.Open();
                SqlDataReader Read = Cmd_CHQFour.ExecuteReader();

                if (Read.HasRows)
                {
                    while (Read.Read())
                    {

                        this.dataGridView2.Rows.Add(
                                Read["IDCHQ_FOUR"],
                                DateTime.Parse(Read["DATEDONNER"].ToString()),
                                DateTime.Parse(Read["DATEPAYER"].ToString()),
                                Read["MONTANT"]
                        );

                    }
                }

                else
                {
                    MessageBox.Show("La Table CHQ est vide !!!");

                }

            }

        }
        private void List_ESP_Four(int IDFOUR)
        {
            label.Text = "Listes des Paiement : ";
            label1.Text = "Les Commandes Sélectionnés :";


            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                SqlCommand Cmd = new SqlCommand($"SELECT * From PAIEMENTESPECEFOUR WHERE IDFOUR = '{IDFOUR}';", Conx);

                Conx.Open();
                SqlDataReader Read = Cmd.ExecuteReader();

                if (Read.HasRows)
                {
                    this.dataGridView2.Rows.Clear();
                    this.dataGridView2.Columns.Clear();

                    this.dataGridView2.ColumnCount = 4;
                    this.dataGridView2.Columns[0].Name = "IDESP";
                    this.dataGridView2.Columns[1].Name = "DATE";
                    this.dataGridView2.Columns[2].Name = "DATE de Paiement";
                    this.dataGridView2.Columns[3].Name = "MONTANT";

                    while (Read.Read())
                    {
                        this.dataGridView2.Rows.Add(
                                Read["IDESP_FOUR"],
                                DateTime.Parse(Read["DATEDONNER"].ToString()),
                                DateTime.Parse(Read["DATE_PAIEMENT"].ToString()),
                                Read["MONTANT"]
                        );
                    }

                    Conx.Close();

                }
                else
                {
                    MessageBox.Show("La Table PAIEMENT est vide !!!");

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

                    this.dataGridView1.ColumnCount = 6;
                    this.dataGridView1.Columns[0].Name = "ID_CMD_FOUR";
                    this.dataGridView1.Columns[1].Name = "DESCRIPTION";
                    this.dataGridView1.Columns[2].Name = "STATUT";
                    this.dataGridView1.Columns[3].Name = "MTRESTE";
                    this.dataGridView1.Columns[4].Name = "MONTANT TOTAL";
                    this.dataGridView1.Columns[5].Name = "DATECMD";

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
                                ReadCmd["ID_CMD_FOUR"],
                                ReadCmd["DESCRIPTION"],
                                Statut,
                                ReadCmd["MTRESTE"],
                                ReadCmd["MONTANTTOTAL"],
                                Convert.ToDateTime(ReadCmd["DATECMD"]).ToString("dd MMMM yyyy"));
                        };
                    }


                }
                else
                {
                    MessageBox.Show("Aucune Commande a ete enregistrer de ce Fournisseur !!!");
                }
            }

        }

        private void Edit(int IDCMD)
        {
            Content.Controls.Clear();
            Edit_CMD_Four ECmd = new Edit_CMD_Four(IDCMD, IDFOUR, Content);
            MainClass.ShowControl(ECmd, Content);
        }
        private void Delete(int IDCMD)
        {
            //int position = this.DataGridView.CurrentRow.Index;
            //int IDFour = int.Parse(this.DataGridView.Rows[position].Cells[0].Value);

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                SqlCommand Cmd = new SqlCommand
                {
                    Connection = Conx,
                    CommandText = "DELETE FROM COMMANDEFOUR WHERE ID_CMD_FOUR = @IDCMD;"
                };

                try
                {
                    Cmd.Parameters.AddWithValue("@IDCMD", IDCMD);
                    Conx.Open();
                    Cmd.ExecuteNonQuery();
                    Conx.Close();
                    List_Cmd_Four(IDFOUR);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow Row;
                DialogResult Dialog;
                String ColName = this.dataGridView2.Columns[e.ColumnIndex].Name;

                Row = dataGridView2.Rows[e.RowIndex];
                Row.Selected = true;

                if (label.Text == "Les Commandes :")
                {
                    Load_Data_Produit(int.Parse(Row.Cells["IDCMD"].Value.ToString()));

                    if (ColName == "Edit")
                    {
                        Edit(Convert.ToInt32(Row.Cells["IDCMD"].Value));
                    }
                    else if (ColName == "Delete")
                    {

                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[0].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        Delete(Convert.ToInt32(Row.Cells["IDCMD"].Value));

                    }
                }
                else if (label.Text == "Listes des Cheques :")
                {
                    Data_Cmd($"SELECT ID_CMD_FOUR FROM REGLE_CHQ_FOUR WHERE IDCHQ_FOUR = '{Convert.ToInt32(Row.Cells["IDCHQ"].Value)}';");
                }
                else if (label.Text == "Listes des Paiement : ")
                {
                    Data_Cmd($"SELECT ID_CMD_FOUR FROM REGLER_ESP_FOUR WHERE IDESP_FOUR = '{Convert.ToInt32(Row.Cells["IDESP"].Value)}';");

                }


            }
        }

        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex >= 0)
            {
                string ColName = this.dataGridView2.Columns[e.ColumnIndex].Name;

                if (ColName != "BtnEdit" && ColName != "BtnDelete")
                {
                    dataGridView2.Cursor = Cursors.Default;
                }
                else
                {
                    dataGridView2.Cursor = Cursors.Hand;
                }
            }
        }

        private void ListCMD_Load(object sender, EventArgs e)
        {
            if (load == 1)
            {
                List_Cmd_Four(IDFOUR);
            }
            else if (load == 2)
            {
                List_CHQ_Four(IDFOUR);
            }
            else if (load == 3)
            {
                List_ESP_Four(IDFOUR);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

