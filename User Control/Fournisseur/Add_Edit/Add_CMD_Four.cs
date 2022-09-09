using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.A_M_D
{
    public partial class Add_CMD_Four : Form
    {

        private readonly int IDFOUR;
        private readonly string ENTREPRISE;
        public Add_CMD_Four(int ID, string NFour)
        {
            InitializeComponent();
            IDFOUR = ID;
            ENTREPRISE = NFour;
        }
        private void Add_Colone()
        {
            // DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            //  check.Name = "SELECTER";
            //   dataGridView1.Columns.Add(check);
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
                        Add_Selected_Product(int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()));
                    }
                }
            }
        }
        private void Add_Selected_Product(int ID_PRODUIT)
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
                        this.dataGridView2.Rows.Add(ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], null);
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
        private void Data_Produit()
        {
            dataGridView1.Rows.Clear();

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd = new SqlCommand($"SELECT * From PRODUIT WHERE IDFOUR = @IDFOUR;", Conx);
                Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                Conx.Open();
                SqlDataReader ReadProduit = Cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                if (ReadProduit.HasRows)
                {
                    /*/Button Delete, Edit
                    MainClass.Button_DGV(dataGridView1, "Edit", "edit");
                    dataGridView1.Columns["Edit"].Width = 50;
                    MainClass.Button_DGV(dataGridView1, "Delete", "delete");
                    dataGridView1.Columns["Delete"].Width = 50;

                    //
                    ///dataGridView1.AllowUserToAddRows = true;
                    MainClass.DataGridMod(this.dataGridView1);*/
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    while (ReadProduit.Read())
                    {
                        this.dataGridView1.Rows.Add(false, ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5], false), String.Format("{0:0.##}", ReadProduit[6]));
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
                            this.dataGridView1.Rows.Add(false,ReadProduit[0], ReadProduit[2], ReadProduit[3], String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5], false), String.Format("{0:0.##}", ReadProduit[6]));
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

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if (Search.Text == "")
            {
                Data_Produit();
            }
            else
            {
                Search_Produit(Search.Text);
            }

        }

        public void Clear()
        {
            Description.Text = "";
            comboBox.Text = "";
            MONTANTTOTAL.Text = "";
            comboBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Produit Form = new Add_Produit(IDFOUR, ENTREPRISE);
            Form.Show();
        }
        private void Add_CMD_Four_Load(object sender, EventArgs e)
        {
            Data_Produit();
            label1.Text = ENTREPRISE;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_CMD_Four_Load_1(object sender, EventArgs e)
        {
            label1.Text = ENTREPRISE;
            Add_Colone();
            Data_Produit();
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
                Conx.Open();
                try
                {
                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
                        Cmd = new SqlCommand("INSERT INTO COMMANDER(ID_PRODUIT,IDPRODUIT,ID_CMD_FOUR,QUANTITE) values(@ID_PRODUIT1,@IDPRODUIT1,@ID_CMD_FOUR1,@QUANTITE);", Conx);
                        Cmd.Parameters.AddWithValue("ID_PRODUIT1", int.Parse(item.Cells["ID_PRODUIT1"].Value.ToString()));
                        Cmd.Parameters.AddWithValue("IDPRODUIT1", item.Cells["IDPRODUIT1"].Value.ToString());
                        Cmd.Parameters.AddWithValue("ID_CMD_FOUR1", IDCMD);
                        Cmd.Parameters.AddWithValue("QUANTITE", float.Parse(item.Cells["Quantite"].Value.ToString()));
                        Cmd.ExecuteNonQuery();
                    }
 
                    Conx.Close();
                    Clear();
                    this.Close();
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
                    string Query = "INSERT INTO COMMANDEFOUR(IDFOUR,DESCRIPTION,STATUT,DATECMD,PESPECE,PCHEQUE,MONTANTTOTAL) values(@IDFOUR,@DESCRIPTION,@STATUT,@DATECMD,@PESPECE,@PCHEQUE,@MONTANTTOTAL);";
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
                        Cmd.ExecuteNonQuery();

                        SqlCommand CmdId = new SqlCommand("SELECT max(ID_CMD_FOUR) FROM COMMANDEFOUR;", Conx);
                        SqlDataReader Read = CmdId.ExecuteReader();

                        while(Read.Read())
                        {
                            COMMANDER(int.Parse(Read[0].ToString()));
                        }


                        Conx.Close();

                        Clear();
                        this.Close();

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
                    if (Cheque.Checked == false && Espece.Checked == false )
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}



