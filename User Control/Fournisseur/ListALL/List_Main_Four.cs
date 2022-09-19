using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.ListALL
{
    public partial class List_Main_Four : UserControl
    {
        private readonly int IDFOUR;
        private readonly Panel Content;
        private readonly int load;
        private readonly string Period;
        private readonly int Year;
        public List_Main_Four(int ID, Panel content, int load, string period, int Year)
        {
            InitializeComponent();
            this.load = load;
            IDFOUR = ID;
            Content = content;
            Period = period;
            this.Year = Year;
        }

        private void List_Cmd_Four(int IDFOUR)
        {
            label.Text = "Les Commandes :";

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                string Statut = "non payée";
                string MPaiement = "PESPECE";
                String QueryCmdFour = $"SELECT * From COMMANDEFOUR WHERE IDFOUR = '{IDFOUR}' ;";

                dataGridView2.Rows.Clear();
                if (Period.ToLower() == "tous")
                {
                    QueryCmdFour = $"SELECT * From COMMANDEFOUR WHERE IDFOUR = '{IDFOUR}' and year(DATECMD) = '{Year}';";
                }
                else
                {
                    QueryCmdFour = $"SELECT * From COMMANDEFOUR WHERE IDFOUR = '{IDFOUR}' and month(DATECMD) = '{DateTime.Parse(Period).Month}' and year(DATECMD) = '{Year}' ;";
                }

                SqlCommand CmdFour = new SqlCommand(QueryCmdFour, Conx);


                Conx.Open();
                SqlDataReader ReadCmdFour = CmdFour.ExecuteReader();
                if (ReadCmdFour.HasRows)
                {
                    this.dataGridView2.Rows.Clear();
                    this.dataGridView2.Columns.Clear();

                    this.dataGridView2.ColumnCount = 7;
                    this.dataGridView2.Columns[0].Name = "#";
                    this.dataGridView2.Columns[0].Width = 30;
                    this.dataGridView2.Columns[1].Name = "Id";
                    this.dataGridView2.Columns[1].Width = 50;
                    this.dataGridView2.Columns[2].Name = "Description";
                    this.dataGridView2.Columns[3].Name = "Statut";
                    this.dataGridView2.Columns[4].Name = "Date";
                    this.dataGridView2.Columns[5].Name = "Paiement";
                    this.dataGridView2.Columns[6].Name = "MT";

                    InitializeButtons("Produit");

                    while (ReadCmdFour.Read())
                    {
                        if ((bool)ReadCmdFour["STATUT"])
                        {
                            Statut = "payée";
                            this.dataGridView2.Columns[3].DefaultCellStyle.BackColor = Color.Green;
                        }
                        else
                        {
                            this.dataGridView2.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                        }
                        if ((bool)ReadCmdFour["PCHEQUE"] && (bool)ReadCmdFour["PESPECE"])
                        {
                            MPaiement = "CHQ et Espece";
                        }
                        else if ((bool)ReadCmdFour["PCHEQUE"])
                        {
                            MPaiement = "CHQ";
                        }
                        else if ((bool)ReadCmdFour["PESPECE"])
                        {
                            MPaiement = "Espece";
                        }
                        else
                        {
                            MPaiement = "Rien";
                        }

                        this.dataGridView2.Rows.Add(
                            (dataGridView2.RowCount + 1),
                            ReadCmdFour["ID_CMD_FOUR"],
                            ReadCmdFour["DESCRIPTION"],
                            Statut,
                            DateTime.Parse(ReadCmdFour["DATECMD"].ToString()).ToString("dd MMMM yy"),
                            MPaiement,
                            Math.Round(double.Parse(ReadCmdFour["MONTANTTOTAL"].ToString()), 2)

                        );
                    };
                }

                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");
                }
            }
        }

        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string. 
            //dateTimePicker2.CustomFormat = "MMMM yyyy";
            //dateTimePicker2.ShowUpDown = true;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
        }

        private void List_CHQ_Four(int IDFOUR, bool temp)
        {
            label.Text = "Liste des Cheques :";
            SetMyCustomFormat();
            PanelEncaissement.Visible = true;

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                this.dataGridView2.Rows.Clear();
                this.dataGridView2.Columns.Clear();
                this.dataGridView2.ColumnCount = 6;
                this.dataGridView2.Columns[0].Name = "#";
                this.dataGridView2.Columns[0].Width = 30;
                this.dataGridView2.Columns[1].Name = "IDCHQ";
                this.dataGridView2.Columns[1].Visible = false;
                this.dataGridView2.Columns[2].Name = "N°CHQ";
                this.dataGridView2.Columns[3].Name = "Rédaction";
                this.dataGridView2.Columns[4].Name = "Encaissement";
                this.dataGridView2.Columns[5].Name = "Montant";

                InitializeButtons("cmd");


                String Query = $"SELECT * From CHEQUEFOURNISSEUR WHERE IDFOUR = '{IDFOUR}' and year(DATEDONNER) = '{Year}' ;";

                if (Period.ToLower() != "" && Period.ToLower() != "tous" && temp == false)
                {
                    Query = $"SELECT * From CHEQUEFOURNISSEUR WHERE IDFOUR = '{IDFOUR}' and month(DATEDONNER) = '{DateTime.Parse(Period).Month}' and year(DATEDONNER) = '{Year}' ;";
                    this.dataGridView2.Columns["Rédaction"].HeaderCell.Style.BackColor = Color.Green;
                }
                else if (temp == true)
                {
                    Query = $"SELECT * From CHEQUEFOURNISSEUR WHERE IDFOUR = '{IDFOUR}' and month(DATEPAYER) = '{dateTimePicker1.Value.Month}' and year(DATEPAYER) = '{dateTimePicker1.Value.Year}' ;";
                    this.dataGridView2.Columns["Encaissement"].HeaderCell.Style.BackColor = Color.Green;
                }

                //Return CHQ Details

                SqlCommand Cmd_CHQFour = new SqlCommand(Query, Conx);
                Conx.Open();
                SqlDataReader Read = Cmd_CHQFour.ExecuteReader();

                if (Read.HasRows)
                {
                    while (Read.Read())
                    {
                        this.dataGridView2.Rows.Add(
                                (dataGridView2.RowCount + 1),
                                Read["IDCHQ_FOUR"],
                                Read["N_CHQ"],
                                DateTime.Parse(Read["DATEDONNER"].ToString()).ToString("dd MMMM yy"),
                                DateTime.Parse(Read["DATEPAYER"].ToString()).ToString("dd MMMM yy"),
                                Math.Round(double.Parse(Read["MONTANT"].ToString()), 2)
                        );

                    }
                    dataGridView2.Columns["N°CHQ"].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);

                }

                else
                {
                    MessageBox.Show("La Table CHQ est vide !!!");

                }
            }

        }
        private void List_Produit()
        {
            dataGridView2.Rows.Clear();

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd = new SqlCommand($"SELECT * From PRODUIT WHERE IDFOUR = @IDFOUR;", Conx);
                Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                Conx.Open();
                SqlDataReader ReadProduit = Cmd.ExecuteReader();
                dataGridView2.Rows.Clear();
                if (ReadProduit.HasRows)
                {
                    this.dataGridView2.Rows.Clear();
                    this.dataGridView2.Columns.Clear();
                    this.dataGridView2.ColumnCount = 7;

                    this.dataGridView2.Columns[0].Name = "#";
                    this.dataGridView2.Columns[0].Width = 30;
                    this.dataGridView2.Columns[1].Name = "ID_PRODUIT";
                    this.dataGridView2.Columns[1].Visible = false;
                    this.dataGridView2.Columns[2].Name = "IDPRODUIT";
                    this.dataGridView2.Columns[3].Name = "DESIGNATION";
                    this.dataGridView2.Columns[4].Name = "Prix Achat";
                    this.dataGridView2.Columns[5].Name = "Prix Vente";
                    this.dataGridView2.Columns[6].Name = "DPrix Vente ";

                    InitializeButtons(null);

                    while (ReadProduit.Read())
                    {
                        this.dataGridView2.Rows.Add(
                            this.dataGridView2.RowCount + 1
                            , ReadProduit["ID_PRODUIT"]
                            , ReadProduit["IDPRODUIT"],
                            ReadProduit["DESIGNATION"],
                            Math.Round(double.Parse(ReadProduit[4].ToString()), 2),
                            Math.Round(double.Parse(ReadProduit[5].ToString()), 2),
                            Math.Round(double.Parse(ReadProduit[6].ToString()), 2)
                        );
                    }

                    dataGridView2.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);

                }
                else
                {
                    MessageBox.Show("La Table Produit est vide !!!");
                }
            }
        }
        private void List_ESP_Four(int IDFOUR)
        {
            label.Text = "Liste des Paiement : ";

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
                    this.dataGridView2.Columns[0].Name = "#";
                    this.dataGridView2.Columns[0].Width = 30;
                    this.dataGridView2.Columns[1].Name = "IDESP";
                    this.dataGridView2.Columns[1].Width = 50;
                    this.dataGridView2.Columns[2].Name = "Date de Paiement";
                    this.dataGridView2.Columns[3].Name = "Montant";

                    InitializeButtons("cmd");

                    while (Read.Read())
                    {
                        this.dataGridView2.Rows.Add(
                                (dataGridView2.RowCount + 1),
                                Read["IDESP_FOUR"],
                                DateTime.Parse(Read["DATE_PAIEMENT"].ToString()).ToString("dd MMMM yy"),
                                Math.Round(double.Parse(Read["MONTANT"].ToString()), 2)
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

                if (load == 1)
                {
                    if (ColName == "Edit")
                    {
                        Edit(Convert.ToInt32(Row.Cells[1].Value));
                    }
                    else if (ColName == "Delete")
                    {

                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[0].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        Delete(Convert.ToInt32(Row.Cells["Id"].Value));
                    }
                    else if (ColName == "Produit")
                    {

                        Form_List Form = new Form_List(IDFOUR, 1, $"SELECT ID_PRODUIT FROM COMMANDER WHERE ID_CMD_FOUR = '{int.Parse(Row.Cells[1].Value.ToString())}';");
                        Form.Show();
                    }
                }
                else if (load == 3)
                {
                    if (ColName == "Edit")
                    {
                        Edit(Convert.ToInt32(Row.Cells[1].Value));
                    }
                    else if (ColName == "Delete")
                    {

                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        Delete(Convert.ToInt32(Row.Cells["Id"].Value));
                    }
                    else if (ColName == "cmd")
                    {
                        Form_List Form = new Form_List(IDFOUR, 2, $"SELECT ID_CMD_FOUR FROM REGLE_CHQ_FOUR WHERE IDCHQ_FOUR = '{Convert.ToInt32(Row.Cells["IDCHQ"].Value)}';");
                        Form.Show();
                    }
                }
                else if (load == 4)
                {
                    if (ColName == "Edit")
                    {
                        Edit(Convert.ToInt32(Row.Cells[1].Value));
                    }
                    else if (ColName == "Delete")
                    {

                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        Delete(Convert.ToInt32(Row.Cells["Id"].Value));
                    }
                    else if (ColName == "cmd")
                    {
                        Form_List Form = new Form_List(IDFOUR, 2, $"SELECT ID_CMD_FOUR FROM REGLER_ESP_FOUR WHERE IDESP_FOUR = '{Convert.ToInt32(Row.Cells["IDESP"].Value)}';");
                        Form.Show();
                    }

                }
            }
        }

        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string ColName = this.dataGridView2.Columns[e.ColumnIndex].Name;

                if (ColName != "Edit" && ColName != "Delete" && ColName != "Produit" && ColName != "cmd" )
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
                List_Produit();
            }
            else if (load == 3)
            {
                List_CHQ_Four(IDFOUR, false);
            }
            else if (load == 4)
            {
                List_ESP_Four(IDFOUR);
            }

        }

        private void InitializeButtons(string Name)
        {
            //Button Delete, Edit
            MainClass.Button_DGV(dataGridView2, "Edit", "edit");
            this.dataGridView2.Columns["Edit"].Width = 70;
            MainClass.Button_DGV(dataGridView2, "Delete", "delete");
            this.dataGridView2.Columns["Delete"].Width = 70;
            if (Name != null)
            {
                MainClass.Button_DGV(dataGridView2, Name, "search");
                this.dataGridView2.Columns[Name].Width = 70;
            }
        }

        // List By Date Encaissement(DATEPAYER) : true
        // List By Date de Rédaction(DATEDONNER) : false
        private void button1_Click(object sender, EventArgs e)
        {
            List_CHQ_Four(IDFOUR, true);

        }


    }
}

