using Store_Management_System.Class;
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

        public Edit_CMD_Four(int ID, int FOUR)
        {
            InitializeComponent();
            IDCMD = ID;
            IDFOUR = FOUR;
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
                        Add_Selected_Product(int.Parse(ReadCMD["ID_PRODUIT"].ToString()), ReadCMD["QUANTITE"].ToString());

                        /*Select  selected Products in datagridview 1 :
                        foreach (DataGridViewRow Item in dataGridView1.Rows)
                        {
                            if (int.Parse(ReadCMD["ID_PRODUIT"].ToString()) == int.Parse(Item.Cells[0].Value.ToString()))
                            {
                                Item.Cells["Check"].Value = true;
                            }
                        }*/
                    }
                }
            }
        }

        private void CheckBox()
        {
            //DataGridViewCheckBoxColumn Cb = new DataGridViewCheckBoxColumn();
            //DataGridView.Columns.Insert(0, Cb);
            this.dataGridView2.Rows.Clear();
            if (dataGridView1.RowCount > 0)
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Check"].Value))
                    {
                        MessageBox.Show(item.Cells["ID_PRODUIT"].Value.ToString());
                        Add_Selected_Product(int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()), "0");
                    }
                }
            }
        }
        private void Add_Selected_Product(int ID_PRODUIT, string QTE)
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
                        this.dataGridView2.Rows.Add(ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], float.Parse(QTE));
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
                SqlCommand Cmd1 = new SqlCommand($"SELECT ID_PRODUIT FROM COMMANDER WHERE ID_CMD_FOUR = '{IDCMD}';", Conx);

                Cmd1.Parameters.AddWithValue("ID_CMD_FOUR", IDCMD);
                Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);

                Conx.Open();
                SqlDataReader ReadProduit = Cmd.ExecuteReader();
                SqlDataReader Read = Cmd1.ExecuteReader();

                dataGridView1.Rows.Clear();

                if (ReadProduit.HasRows)
                {
                    if (Read.HasRows)
                    {
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
                        */
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
                        }
                    }
                    else
                    {
                        while (ReadProduit.Read())
                        {
                            this.dataGridView1.Rows.Add(false, ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5]), String.Format("{0:0.##}", ReadProduit[6]));

                        }
                    }
                    dataGridView1.Columns["DESIGNATION"].Width = 200;
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

        private void Search_Produit(string Search)
        {
            if (Search != "")
            {
                Search.ToCharArray();

                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    SqlCommand Cmd = new SqlCommand("SELECT * From PRODUIT WHERE IDFOUR = @IDFOUR and DESIGNATION LIKE  '@Search%' ; ", Conx);
                    Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                    Cmd.Parameters.AddWithValue("Search", Search[1]);
                    Conx.Open();
                    SqlDataReader ReadProduit = Cmd.ExecuteReader();
                    dataGridView1.Rows.Clear();

                    if (ReadProduit.HasRows)
                    {
                        //Button Delete, Edit
                        MainClass.Button_DGV(dataGridView1, "Edit", "edit");
                        dataGridView1.Columns["Edit"].Width = 50;
                        MainClass.Button_DGV(dataGridView1, "Delete", "delete");
                        dataGridView1.Columns["Delete"].Width = 50;

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
        private void button3_Click(object sender, EventArgs e)
        {
            CheckBox();
        }

        private string CheckeSelectedProduct()
        {

            if (dataGridView2.RowCount > 0)
            {
                string Temp = "false";
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    if (item.Cells["Quantite"].Value.ToString() != "0")
                    {
                        if (MainClass.TypeCheckFloat(item.Cells["Quantite"].Value.ToString()))
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
                        Temp = item.Cells["IDPRODUIT1"].Value.ToString();
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
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                if (CheckeSelectedProduct() == "true" && Description.Text != "" && MONTANTTOTAL.Text != "" && comboBox.Text != "" && (Cheque.Checked || Espece.Checked))
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
                        Clear();

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
                    if (CheckeSelectedProduct() == "false" || CheckeSelectedProduct() != "true")
                    {
                        labelQuantite.BackColor = Color.Red;
                        if (CheckeSelectedProduct() != "true" && CheckeSelectedProduct() != "false")
                        {
                            MessageBox.Show("Veuillez Verifier La Quantite de Produit ' " + CheckeSelectedProduct() + "' .");
                        }
                        else
                        {
                            MessageBox.Show("Veuillez Selecter les Produit.");
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
            else
            {
                Search_Produit(Search.Text);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            CheckBox();
        }
    }
}
