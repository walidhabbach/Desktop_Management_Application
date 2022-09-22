using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.A_M_D;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C;
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
        public List_Main_Four(int IDFOUR, Panel content, int load)
        {
            InitializeComponent();
            this.load = load;

            this.IDFOUR = IDFOUR;
            Content = content;
        }

        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string. 
            //dateTimePicker2.CustomFormat = "MMMM yyyy";
            //dateTimePicker2.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MMMM yyyy";
        }

        private void List_Cmd_Four(String Query)
        {
            label.Text = "Les Commandes :";
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {

                    string Statut = "non payée";
                    string MPaiement = "PESPECE";
                    String QueryCmdFour = $"SELECT * From COMMANDEFOUR WHERE IDFOUR = '{IDFOUR}' ;";

                    dataGridView2.Rows.Clear();
                    SqlCommand CmdFour = new SqlCommand(Query, Conx);

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
                        this.dataGridView2.Columns[6].Name = "Montant";

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
                        MessageBox.Show("Aucune donnée existe !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void List_CHQ_Four(String Query)
        {
            label.Text = "Liste des Cheques :";
            SetMyCustomFormat();

            try
            {
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

                    // Change the Searched HeaderCell Style BackColor
                    if (comboBox1.Text == "N°CHQ")
                    {
                        this.dataGridView2.Columns["IDCHQ"].HeaderCell.Style.BackColor = Color.Green;
                    }
                    else if (comboBox1.Text == "Date Rédaction")
                    {
                        this.dataGridView2.Columns["Rédaction"].HeaderCell.Style.BackColor = Color.Green;
                    }
                    else if (comboBox1.Text == "Date Encaissement")
                    {
                        this.dataGridView2.Columns["Encaissement"].HeaderCell.Style.BackColor = Color.Green;
                    }
                    else if (comboBox1.Text == "Montant")
                    {
                        this.dataGridView2.Columns["Montant"].HeaderCell.Style.BackColor = Color.Green;
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
                        MessageBox.Show("Aucune donnée existe !!!");
                        this.dataGridView2.Rows.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void List_Produit(String Query)
        {
            dataGridView2.Rows.Clear();
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    SqlCommand Cmd = new SqlCommand(Query, Conx);

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
                                Math.Round(float.Parse(ReadProduit[3].ToString()), 2),
                                Math.Round(float.Parse(ReadProduit[4].ToString()), 2),
                                Math.Round(float.Parse(ReadProduit[5].ToString()), 2)
                            );
                        }

                        dataGridView2.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);

                    }
                    else
                    {
                        MessageBox.Show("Aucune donnée existe !!!");
                        this.dataGridView2.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void List_ESP_Four(String Query)
        {
            label.Text = "Liste des Paiement : ";
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    SqlCommand Cmd = new SqlCommand(Query, Conx);

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

                        if (comboBox1.Text == "id ESP")
                        {
                            this.dataGridView2.Columns["IDESP"].HeaderCell.Style.BackColor = Color.Green;
                        }
                        else if (comboBox1.Text == "Date de Paiement")
                        {
                            this.dataGridView2.Columns["Date de Paiement"].HeaderCell.Style.BackColor = Color.Green;
                        }
                        else if (comboBox1.Text == "Montant")
                        {
                            this.dataGridView2.Columns["Montant"].HeaderCell.Style.BackColor = Color.Green;
                        }

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
                        MessageBox.Show("Aucune donnée existe !!!");
                        this.dataGridView2.Rows.Clear();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Edit(int IDCMD)
        {
            Content.Controls.Clear();
            Edit_CMD_Four ECmd = new Edit_CMD_Four(IDCMD, IDFOUR, Content);
            MainClass.ShowControl(ECmd, Content);
        }
        
        private void Delete(String Query)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {

                    SqlCommand Cmd = new SqlCommand(Query, Conx);
                    try
                    {
                        Conx.Open();
                        Cmd.ExecuteNonQuery();
                        Conx.Close();

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        else
                        {
                            Delete($"DELETE FROM COMMANDEFOUR WHERE ID_CMD_FOUR = '{Convert.ToInt32(Row.Cells["Id"].Value)}';");
                        }
                        
                    }
                    else if (ColName == "Produit")
                    {
                        Form_List Form = new Form_List(IDFOUR, 1, $"SELECT ID_PRODUIT FROM COMMANDER WHERE ID_CMD_FOUR = '{int.Parse(Row.Cells[1].Value.ToString())}';");
                        Form.Show();
                    }
                }
                else if (load == 2)
                {
                    if (ColName == "Edit")
                    {
                        Edit_Produit Form = new Edit_Produit(Convert.ToInt32(Row.Cells["ID_PRODUIT"].Value),IDFOUR, panel2);
                        Form.Show();
                    }
                    else if (ColName == "Delete")
                    {
                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        Delete($"DELETE FROM PRODUIT WHERE ID_PRODUIT = '{Convert.ToInt32(Row.Cells["ID_PRODUIT"].Value)}';");
                        Search_Produit(Search.Text);
                    }

                }
                else if (load == 3)
                {
                    if (ColName == "Edit")
                    {
                        Content.Controls.Clear();
                        Edit_CHQ_Four ECHQ = new Edit_CHQ_Four( IDFOUR,Convert.ToInt32(Row.Cells[1].Value), Content);
                        MainClass.ShowControl(ECHQ, Content);
                    }
                    else if (ColName == "Delete")
                    {
                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        Delete($"DELETE FROM CHEQUEFOURNISSEUR WHERE IDCHQ_FOUR = '{Convert.ToInt32(Row.Cells["Id"].Value)}';");
                        Search_CHQ(Search.Text);
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
                        Content.Controls.Clear();
                        Edit_ESP_Four ECHQ = new Edit_ESP_Four(IDFOUR,Convert.ToInt32(Row.Cells[1].Value),Content);
                        MainClass.ShowControl(ECHQ, Content);
                    }
                    else if (ColName == "Delete")
                    {

                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        Delete($"SELECT ID_CMD_FOUR FROM REGLE_CHQ_FOUR WHERE IDCHQ_FOUR = '{Convert.ToInt32(Row.Cells["Id"].Value)}';");
                        Search_ESP(Search.Text);
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

                if (ColName != "Edit" && ColName != "Delete" && ColName != "Produit" && ColName != "cmd")
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
            dateTimePicker2.Value = DateTime.Now;
            CustomDateFormat();
            if (load == 1)
            {
                FillComboBox(1);
                comboBox1.Text = "Tous";
                Search_Cmd(Search.Text);
            }
            else if (load == 2)
            {
                FillComboBox(2);
                comboBox1.Text = "Tous";
                Search_Produit(Search.Text);
            }
            else if (load == 3)
            {
                FillComboBox(3);
                comboBox1.Text = "Tous";
                Search_CHQ(Search.Text);
            }
            else if (load == 4)
            {
                FillComboBox(4);
                comboBox1.Text = "Tous";
                Search_ESP(Search.Text);
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

        private void Search_Produit(string search)
        {
            String Query = $"SELECT * From PRODUIT WHERE IDFOUR = '{IDFOUR}'";
            try
            {
                if (comboBox1.Text == "Tous")
                {
                    Query = $"SELECT * From PRODUIT WHERE IDFOUR = '{IDFOUR}';";
                }
                else if (search != string.Empty)
                {
                    if (comboBox1.Text == "id Produit")
                    {
                        Query += $" and IDPRODUIT LIKE '" + search + "%' ;";
                    }
                    else if (comboBox1.Text == "Designation")
                    {
                        Query += $" and DESIGNATION LIKE '" + search + "%' ;";
                    }
                    else if (comboBox1.Text == "PrixAchat")
                    {
                        Query += $" and PRIXACHAT = '{Convert.ToDouble(search)}' ;";
                    }
                    else if (comboBox1.Text == "PrixVente")
                    {
                        Query += $" and PRIXVENTE = '{Convert.ToDouble(search)}' ;";
                    }
                    else if (comboBox1.Text == "DPrixVente")
                    {
                        Query += $" and DPRIXVENTE = '{Convert.ToDouble(search)}' ;";
                    }
                }
                else
                {
                    MessageBox.Show("Remplir la barre de recherche !!!");
                    Search.Focus();
                }
                List_Produit(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        private void Search_Cmd(string search)
        {
            String Query = $"SELECT * From COMMANDEFOUR WHERE IDFOUR = '{IDFOUR}' ";
            try
            {
                if (comboBox1.Text == "Tous")
                {
                    Query += $" and year(DATECMD) = '{dateTimePicker2.Value.Year}' ;";
                }
                else if (search != string.Empty)
                {
                    if (comboBox1.Text == "idCmd")
                    {
                        Query += $" and ID_CMD_FOUR = '{int.Parse(search)}';";
                    }
                    else if (comboBox1.Text == "Description")
                    {
                        Query += $" and DESCRIPTION LIKE '" + search + "%' ;";
                    }
                    else if (comboBox1.Text == "Statut")
                    {
                        if (search.Substring(0, 1).ToLower() == "n")
                        {
                            Query += $" and STATUT = 0 ; ";
                        }
                        else if (search.Substring(0, 1).ToLower() == "p")
                        {
                            Query += $" and STATUT = 1 ;";
                        }
                    }
                    else if (comboBox1.Text == "Mode Paiement")
                    {
                        if (search.Substring(0, 1).ToLower() == "c")
                        {
                            Query += $" and PCHEQUE = 1 ; ";
                        }
                        else if (search.Substring(0, 1).ToLower() == "e")
                        {
                            Query += $" and PESPECE = 1 ;";
                        }
                    }
                    else if (comboBox1.Text == "Montant Total")
                    {
                        Query += $" and MONTANTTOTAL = '{float.Parse(search)}' ;";
                    }
                }
                else if (search == String.Empty && comboBox1.Text != "Date Mois")
                {
                    MessageBox.Show("Remplir la barre de recherche !!!");
                    Search.Focus();
                }
                else
                {
                    if (comboBox1.Text == "Date Mois")
                    {
                        Query += $" and month(DATECMD) = '{dateTimePicker2.Value.Month}'  and year(DATECMD) = '{dateTimePicker2.Value.Year}' ;";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            List_Cmd_Four(Query);

        }

        private void Search_CHQ(string search)
        {
            String Query = $"SELECT * From CHEQUEFOURNISSEUR WHERE IDFOUR = '{IDFOUR}' ";
            try
            {
                if (comboBox1.Text == "Tous")
                {
                    Query += $" and year(DATEDONNER) = '{dateTimePicker2.Value.Year}' ";
                }
                else if (search != string.Empty)
                {
                    if (comboBox1.Text == "Date Rédaction")
                    {
                        Query += $" and month(DATEDONNER) = '{dateTimePicker2.Value.Month}' and year(DATEDONNER) = '{dateTimePicker2.Value.Year}' ;";
                    }
                    else if (comboBox1.Text == "Date Encaissement")
                    {
                        Query += $" and month(DATEPAYER) = '{dateTimePicker2.Value.Month}' and year(DATEPAYER) = '{dateTimePicker2.Value.Year}' ;";
                    }
                    else if (comboBox1.Text == "N°CHQ")
                    {
                        Query += $" and N_CHQ  '{int.Parse(search)}'";
                    }
                    else if (comboBox1.Text == "Montant")
                    {
                        Query += $" and MONTANT = '{float.Parse(search)}' ;";
                    }
                }
                else if (search == String.Empty && comboBox1.Text != "Date Rédaction" && comboBox1.Text != "Date Encaissement")
                {
                    MessageBox.Show("Remplir la barre de recherche !!!");
                    Search.Focus();
                }
                else
                {
                    if (comboBox1.Text == "Date Rédaction")
                    {
                        Query += $" and month(DATEDONNER) = '{dateTimePicker2.Value.Month}' and year(DATEDONNER) = '{dateTimePicker2.Value.Year}' ;";
                    }
                    else if (comboBox1.Text == "Date Encaissement")
                    {
                        Query += $" and month(DATEPAYER) = '{dateTimePicker2.Value.Month}' and year(DATEPAYER) = '{dateTimePicker2.Value.Year}' ;";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            List_CHQ_Four(Query);
            Console.WriteLine("valider");
        }

        private void Search_ESP(string search)
        {
            String Query = $"SELECT * From PAIEMENTESPECEFOUR WHERE IDFOUR = '{IDFOUR}' ";
            try
            {
                if (comboBox1.Text == "Tous")
                {
                    Query += $" and year(DATE_PAIEMENT) = '{dateTimePicker2.Value.Year}' ;";
                }
                else if (search != string.Empty)
                {
                    if (comboBox1.Text == "id ESP")
                    {
                        Query += $" and IDESP_FOUR = '{int.Parse(search)}' ;";
                    }
                    else if (comboBox1.Text == "Designation")
                    {
                        Query += $" and DESIGNATION LIKE '" + search + "%' ;";
                    }
                    else if (comboBox1.Text == "Montant")
                    {
                        Query += $" and MONTANT = '{search}' ;";
                    }
                }
                else if (search == String.Empty && comboBox1.Text != "Date de Paiement")
                {
                    MessageBox.Show("Remplir la barre de recherche !!!");
                    Search.Focus();
                }
                else
                {
                    if (comboBox1.Text == "Date de Paiement")
                    {
                        Query += $" and month(DATE_PAIEMENT) = '{dateTimePicker2.Value.Month}' and year(DATE_PAIEMENT) = '{dateTimePicker2.Value.Year}' ;";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            List_ESP_Four(Query);

        }

        private void FillComboBox(int loadList)
        {
            comboBox1.Items.Clear();

            comboBox1.Items.Add("Tous");

            if (loadList == 1)
            {
                comboBox1.Items.Add("idCmd");
                comboBox1.Items.Add("Description");
                comboBox1.Items.Add("Statut");
                comboBox1.Items.Add("Date Mois");
                comboBox1.Items.Add("Mode Paiement");
                comboBox1.Items.Add("Montant Total");
            }
            else if (loadList == 2)
            {
                comboBox1.Items.Add("id Produit");
                comboBox1.Items.Add("Designation");
                comboBox1.Items.Add("PrixAchat");
                comboBox1.Items.Add("PrixVente");
                comboBox1.Items.Add("DPrixVente");
            }
            else if (loadList == 3)
            {
                comboBox1.Items.Add("N°CHQ");
                comboBox1.Items.Add("Designation");
                comboBox1.Items.Add("Date Rédaction");
                comboBox1.Items.Add("Date Encaissement");
                comboBox1.Items.Add("Montant");

            }
            else if (loadList == 4)
            {
                comboBox1.Items.Add("id ESP");
                comboBox1.Items.Add("Date de Paiement");
                comboBox1.Items.Add("Montant");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (load == 1)
            {
                Search_Cmd(Search.Text);
            }
            else if (load == 2)
            {
                Search_Produit(Search.Text);
            }
            else if (load == 3)
            {
                Search_CHQ(Search.Text);
            }
            else if (load == 4)
            {
                Search_ESP(Search.Text);
            }
        }

        private void CustomDateFormat()
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MMMM yyyy";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search.Text = "";
        }



    }

}
