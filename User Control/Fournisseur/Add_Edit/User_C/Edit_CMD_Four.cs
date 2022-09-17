using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.ListALL;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit
{
    public partial class Edit_CMD_Four : UserControl
    {
        private readonly int IDCMD;
        private readonly int IDFOUR;
        private readonly Panel Panel;

        public Edit_CMD_Four(int ID, int FOUR, Panel panel)
        {
            InitializeComponent();
            IDCMD = ID;
            IDFOUR = FOUR;
            Panel = panel;
        }

        private void Load_Data_Cmd()
        {

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                Conx.ConnectionString = MainClass.ConnectionDataBase();
                SqlCommand Cmd = new SqlCommand($"SELECT * FROM COMMANDEFOUR WHERE ID_CMD_FOUR = '{IDCMD}';", Conx);
                SqlCommand Cmd1 = new SqlCommand($"SELECT ID_PRODUIT , QUANTITE FROM COMMANDER WHERE ID_CMD_FOUR = '{IDCMD}';", Conx);

                Conx.Open();
                SqlDataReader Read = Cmd.ExecuteReader();
                SqlDataReader ReadCMD = Cmd1.ExecuteReader();

                while (Read.Read())
                {
                    Description.Text = Read["DESCRIPTION"].ToString();
                    MONTANTTOTAL.Text = Read["MONTANTTOTAL"].ToString();
                    dateTimePicker.Value = DateTime.Parse(Read["DATECMD"].ToString());

                    Cheque.Checked = Convert.ToBoolean(Read["PCHEQUE"].ToString());
                    Espece.Checked = Convert.ToBoolean(Read["PESPECE"].ToString());

                    if (Convert.ToBoolean(Read["STATUT"].ToString()) == true)
                    {

                        comboBox.Text = "payee";
                    }
                    else
                    {
                        comboBox.Text = "Non payee";
                    }

                    while (ReadCMD.Read())
                    {
                        //Add Selected Product to datagridview 2 :
                        Add_Selected_Product(int.Parse(ReadCMD["ID_PRODUIT"].ToString()), float.Parse(ReadCMD["QUANTITE"].ToString()));
                    }
                }
            }
        }

        //Search For a Product From DataGridView(Selected Products)
        private bool IDProduit_DGV2(int ID)
        {
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                if (ID == int.Parse(item.Cells["ID_PRODUIT1"].Value.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        //Delete or ADD Selected Product From DataGridView(Selected Products)
        private void CheckBox()
        {
            //DataGridViewCheckBoxColumn Cb = new DataGridViewCheckBoxColumn();
            //DataGridView.Columns.Insert(0, Cb);
            //this.dataGridView2.Rows.Clear();

            if (dataGridView1.RowCount > 0)
            {
                bool Temp;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    Temp = IDProduit_DGV2(int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()));

                    if (Convert.ToBoolean(item.Cells["Check"].Value) && Temp == false)
                    {
                        Add_Selected_Product(int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()), 0);
                    }
                    else if (Convert.ToBoolean(item.Cells["Check"].Value) == false && Temp)
                    {
                        foreach (DataGridViewRow item2 in dataGridView2.Rows)
                        {
                            if (int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()) == int.Parse(item2.Cells["ID_PRODUIT1"].Value.ToString()))
                            {
                                DialogResult Dialog = MessageBox.Show("Do You Want To Delete Product N° = ' " + item.Cells["ID_PRODUIT"].Value.ToString() + " '", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (Dialog == DialogResult.Yes)
                                {
                                    dataGridView2.Rows.RemoveAt(item2.Index);
                                }
                                else if (Dialog == DialogResult.No)
                                {
                                    /*dataGridView1.Rows.Add(true, item.Cells["ID_PRODUIT"].Value.ToString(), item.Cells["IDPRODUIT"].Value.ToString(), item.Cells["DESIGNATION"].Value.ToString(), String.Format("{0:0.##}", item.Cells["PRIXACHAT"].Value.ToString()), String.Format("{0:0.##}", item.Cells["PRIXVENTE"].Value.ToString()), String.Format("{0:0.##}", item.Cells["DPRIXVENTE"].Value.ToString()));
                                    dataGridView1.Rows.RemoveAt(item.Index);*/
                                    item.Cells["Check"].Value = true;
                                    return;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Add_Selected_Product(int ID_PRODUIT, float QTE)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd = new SqlCommand("SELECT * From PRODUIT WHERE ID_PRODUIT = @ID_PRODUIT;", Conx);

                Cmd.Parameters.AddWithValue("ID_PRODUIT", ID_PRODUIT);
                Conx.Open();
                SqlDataReader ReadProduit = Cmd.ExecuteReader();

                if (ReadProduit.HasRows)
                {
                    while (ReadProduit.Read())
                    {
                        this.dataGridView2.Rows.Add(ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], QTE);
                    }
                    dataGridView2.Columns[0].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);
                    dataGridView2.Columns[1].DefaultCellStyle.Font = new Font("Tahoma", 12);
                }
                else
                {
                    MessageBox.Show("La Table Produit est vide !!!");
                }
            }
        }
        private void Load_Data_Produit()
        {
            dataGridView1.Rows.Clear();

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd = new SqlCommand($"SELECT * From PRODUIT WHERE IDFOUR = @IDFOUR;", Conx);
                SqlCommand Cmd1 = new SqlCommand($"SELECT ID_PRODUIT FROM COMMANDER WHERE ID_CMD_FOUR = @IDCMD;", Conx);

                Cmd1.Parameters.AddWithValue("IDCMD", IDCMD);
                Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);

                Conx.Open();
                SqlDataReader ReadProduit = Cmd.ExecuteReader();
                SqlDataReader Read = Cmd1.ExecuteReader();

                if (ReadProduit.HasRows)
                {
                    while (ReadProduit.Read())
                    {
                        this.dataGridView1.Rows.Add(false, ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[4].ToString()), String.Format("{0:0.##}", ReadProduit[5].ToString()), String.Format("{0:0.##}", ReadProduit[6].ToString()));
                    }

                    if (Read.HasRows && dataGridView1.Rows.Count > 0)
                    {
                        while (Read.Read())
                        {
                            //Select  selected Products in datagridview 1 :
                            foreach (DataGridViewRow Item in dataGridView1.Rows)
                            {
                                if (int.Parse(Read["ID_PRODUIT"].ToString()) == int.Parse(Item.Cells[1].Value.ToString()))
                                {
                                    /* 
                                         dataGridView1.Rows.Add(true, Item.Cells["ID_PRODUIT"].Value.ToString(), Item.Cells["IDPRODUIT"].Value.ToString(), Item.Cells["DESIGNATION"].Value.ToString(), String.Format("{0:0.##}", Item.Cells["PRIXACHAT"].Value.ToString()), String.Format("{0:0.##}", Item.Cells["PRIXVENTE"].Value.ToString()), String.Format("{0:0.##}", Item.Cells["DPRIXVENTE"].Value.ToString()));
                                         dataGridView1.Rows.RemoveAt(Item.Index); 
                                    */
                                    Item.Cells["Check"].Value = true;
                                }
                            }
                        }


                    }
                    /*
                    while (Read.Read())
                    {
                        while (ReadProduit.Read())
                        {
                            //Select  selected Products in datagridview 1 :
                            if (int.Parse(Read["ID_PRODUIT"].ToString()) == int.Parse(ReadProduit["ID_PRODUIT"].ToString()))
                            {
                                this.dataGridView1.Rows.Add(true, ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5]), String.Format("{0:0.##}", ReadProduit[6]));
                                break;
                            }
                            else
                            {
                                this.dataGridView1.Rows.Add(false, ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5]), String.Format("{0:0.##}", ReadProduit[6]));
                            }
                        }
                    }
                    bool Temp;
                    while (ReadProduit.Read())
                    {
                        Temp = false;
                        while (Read.Read())
                        {
                            //Select  selected Products in datagridview 1 :
                            if (int.Parse(Read["ID_PRODUIT"].ToString()) == int.Parse(ReadProduit["ID_PRODUIT"].ToString()))
                            {
                                this.dataGridView1.Rows.Add(true, ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5]), String.Format("{0:0.##}", ReadProduit[6]));
                                Temp = true;
                                break;
                            }
                        }
                        if (Temp == false)
                        {
                            this.dataGridView1.Rows.Add(false, ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5]), String.Format("{0:0.##}", ReadProduit[6]));
                        }
                    } */

                    dataGridView1.Columns["DESIGNATION"].Width = 200;
                    dataGridView1.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);

                }
                else
                {
                    MessageBox.Show("La Table Produit est vide !!!");
                }
            }
        }

        private void Search_Produit(string Search, String Query)
        {
            if (Search != "")
            {
                Search.ToCharArray();

                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    SqlCommand Cmd = new SqlCommand(Query, Conx);
                    Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                    Cmd.Parameters.AddWithValue("Search", Search[1]);
                    Conx.Open();
                    SqlDataReader ReadProduit = Cmd.ExecuteReader();
                    dataGridView1.Rows.Clear();

                    if (ReadProduit.HasRows)
                    {

                        //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        ///dataGridView1.AllowUserToAddRows = true;
                        MainClass.DataGridMod(this.dataGridView1);
                        while (ReadProduit.Read())
                        {
                            this.dataGridView1.Rows.Add(false, ReadProduit[0], ReadProduit[2], ReadProduit[3], String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5], false), String.Format("{0:0.##}", ReadProduit[6]));
                        }

                        dataGridView1.Columns["Check"].Width = 40;
                        dataGridView1.Columns[2].Width = 150;

                        dataGridView1.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
                        dataGridView1.Columns["PRIXACHAT"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                        dataGridView1.Columns["PRIXVENTE"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                        dataGridView1.Columns["DPRIXVENTE"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                        dataGridView1.Columns["DESIGNATION"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        MessageBox.Show("La Table Produit est vide !!!");
                    }
                }
            }
        }

        public void Clear()
        {
            Description.Text = "";
            comboBox.Text = "";
            MONTANTTOTAL.Text = "";
            comboBox.Text = "";
        }

        private string CheckeSelectedProduct()
        {
            if (dataGridView2.RowCount > 0)
            {
                string Temp = "false";
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    foreach (DataGridViewRow item2 in dataGridView2.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells["Check"].Value) == true)
                        {

                            if (int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()) == int.Parse(item2.Cells["ID_PRODUIT1"].Value.ToString()))
                            {
                                Temp = "true";
                                break;
                            }
                            else
                            {
                                Temp = "Refresh";
                            }

                        }
                        else
                        {
                            if (int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()) == int.Parse(item2.Cells["ID_PRODUIT1"].Value.ToString()))
                            {
                                return "Refresh";
                            }

                        }
                    }
                    if (Temp == "Refresh")
                    {
                        return Temp;
                    }

                }

                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    if (MainClass.TypeCheckFloat(item.Cells["Quantite"].Value.ToString()))
                    {
                        if (float.Parse(item.Cells["Quantite"].Value.ToString()) != 0)
                        {
                            Temp = "true";
                        }
                        else
                        {
                            Temp = item.Cells["IDPRODUIT1"].Value.ToString();
                        }
                    }
                    else
                    {
                        return item.Cells["IDPRODUIT1"].Value.ToString();
                    }
                }
                return Temp;
            }
            else
            {
                return "false";
            }
        }
        private void COMMANDER(int IDCMD)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd;
                SqlCommand CmdDelete;
                Conx.Open();
                CmdDelete = new SqlCommand("DELETE FROM COMMANDER WHERE ID_CMD_FOUR = @ID_CMD_FOUR ;", Conx);
                CmdDelete.Parameters.AddWithValue("ID_CMD_FOUR", IDCMD);
                CmdDelete.ExecuteNonQuery();
                try
                {
                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
                        //Cmd = new SqlCommand("UPDATE COMMANDER SET ID_PRODUIT = @ID_PRODUIT1, IDPRODUIT = @IDPRODUIT1, QUANTITE = @QUANTITE WHERE ID_CMD_FOUR = @ID_CMD_FOUR1;", Conx);
                        Cmd = new SqlCommand("INSERT INTO COMMANDER(ID_PRODUIT,IDPRODUIT,ID_CMD_FOUR,QUANTITE) values(@ID_PRODUIT1,@IDPRODUIT1,@ID_CMD_FOUR1,@QUANTITE);", Conx);

                        Cmd.Parameters.AddWithValue("ID_PRODUIT1", int.Parse(item.Cells["ID_PRODUIT1"].Value.ToString()));
                        Cmd.Parameters.AddWithValue("IDPRODUIT1", item.Cells["IDPRODUIT1"].Value.ToString());
                        Cmd.Parameters.AddWithValue("QUANTITE", float.Parse(item.Cells["Quantite"].Value.ToString()));
                        Cmd.Parameters.AddWithValue("ID_CMD_FOUR1", IDCMD);

                        Cmd.ExecuteNonQuery();

                    }

                    Conx.Close();
                    Clear();
                    MessageBox.Show("La Commande a ete Modifie");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (CheckeSelectedProduct() == "Refresh")
            {
                MessageBox.Show("Actualiser !!!");
                CheckBox();
                return ;
            }
            else
            {
                string SelectedProduct = CheckeSelectedProduct();

                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {

                    if (SelectedProduct == "true" && Description.Text != "" && MONTANTTOTAL.Text != "" && comboBox.Text != "" && (Cheque.Checked || Espece.Checked))
                    {

                        string Query = "UPDATE COMMANDEFOUR SET IDFOUR = @IDFOUR ,DESCRIPTION = @DESCRIPTION , STATUT = @STATUT, DATECMD=@DATECMD,PESPECE=@PESPECE,PCHEQUE=@PCHEQUE,MONTANTTOTAL=@MONTANTTOTAL WHERE ID_CMD_FOUR = @ID_CMD_FOUR ;";
                        Conx.Open();
                        SqlCommand Cmd = new SqlCommand(Query, Conx);
                        try
                        {
                            if (Cheque.Checked)
                            {
                                Cmd.Parameters.AddWithValue("PCHEQUE", true);
                            }
                            else
                            {
                                Cmd.Parameters.AddWithValue("PCHEQUE", false);
                            }
                            if (Espece.Checked)
                            {
                                Cmd.Parameters.AddWithValue("PESPECE", true);
                            }
                            else
                            {
                                Cmd.Parameters.AddWithValue("PESPECE", false);
                            }

                            if (comboBox.Text == "payee")
                            {
                                Cmd.Parameters.AddWithValue("STATUT", true);
                            }
                            else
                            {
                                Cmd.Parameters.AddWithValue("STATUT", false);
                            }

                            Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                            Cmd.Parameters.AddWithValue("DESCRIPTION", Description.Text);
                            Cmd.Parameters.AddWithValue("DATECMD", DateTime.Parse(dateTimePicker.Text));
                            Cmd.Parameters.AddWithValue("MONTANTTOTAL", double.Parse(MONTANTTOTAL.Text));
                            Cmd.Parameters.AddWithValue("ID_CMD_FOUR", IDCMD);
                            Cmd.ExecuteNonQuery();

                            COMMANDER(IDCMD);

                            Conx.Close();
                            MessageBox.Show("La Commande a ete Modifie2");

                            Panel.Controls.Clear();
                            ListCMD L = new ListCMD(IDFOUR, Panel,1);
                            MainClass.ShowControl(L, Panel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        if (Description.Text == "")
                        {
                            labelDescription.Visible = true;
                            label2.BackColor = Color.Red;
                            MessageBox.Show("Veuillez Saisir La Description de La Commande");
                        }
                        if (comboBox.Text == "")
                        {
                            labelStatut.Visible = true;
                            label4.BackColor = Color.Red;
                            MessageBox.Show("Veuillez Préciser La Statut de La Commande");
                        }
                        if (MONTANTTOTAL.Text == "")
                        {
                            labelMT.Visible = true;
                            label8.BackColor = Color.Red;
                            MessageBox.Show("Veuillez Saisir Le Montant Total de La Commande");
                        }
                        if (Cheque.Checked == false && Espece.Checked == false)
                        {
                            label3.BackColor = Color.Red;
                            MessageBox.Show("Veuillez choisir le moyen de paiement de La Command ");
                        }
                        if (SelectedProduct == "false" || SelectedProduct != "true")
                        {
                            labelQuantite.BackColor = Color.Red;
                            if (SelectedProduct != "true" && SelectedProduct != "false")
                            {
                                MessageBox.Show("Veuillez Verifier La Quantite de Produit ' " + CheckeSelectedProduct() + "' .");
                            }
                            else if (SelectedProduct == "false")
                            {
                                MessageBox.Show("Veuillez Selecter les Produit.");
                            }
                        }
                    }
                }
            }
        }
        private void Edit_CMD_Four_Load_1(object sender, EventArgs e)
        {
            Load_Data_Cmd();
            Load_Data_Produit();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            if (Search.Text == "")
            {
                Load_Data_Produit();
            }
            else if (Search.Text == "ID_PRODUIT")
            {
                Search_Produit(Search.Text, "SELECT * From PRODUIT WHERE ID_PRODUIT = @Search ;");
            }
            else if (Search.Text == "DESIGNATION")
            {
                Search_Produit(Search.Text, "SELECT * From PRODUIT WHERE IDFOUR = @IDFOUR and DESIGNATION LIKE '@Search%' ; ");
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
           CheckBox();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button2_Click_1(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                String ColName;

                ColName = this.dataGridView1.Columns[e.ColumnIndex].Name;
                if (ColName == "Check")
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            if (CheckeSelectedProduct() == "Refresh")
                            {
                                CheckBox();
                                break;
                            }
                        }
                    }
                }

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


