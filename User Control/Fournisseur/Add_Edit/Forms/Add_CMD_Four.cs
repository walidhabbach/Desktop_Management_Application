using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using Store_Management_System.User_Control.Fournisseur.ListALL;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Panel = System.Windows.Forms.Panel;

namespace Store_Management_System.User_Control.Fournisseur.A_M_D
{
    public partial class Add_CMD_Four : Form
    {
        private Panel panel;
        private readonly int IDFOUR;
        private readonly string ENTREPRISE;
        public Add_CMD_Four(int ID, string NFour, Panel panel)
        {
            InitializeComponent();
            IDFOUR = ID;
            ENTREPRISE = NFour;
            this.panel = panel;
        }
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
            if (dataGridView1.RowCount > 0)
            {
                bool Temp;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    Temp = IDProduit_DGV2(int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()));

                    if (Convert.ToBoolean(item.Cells["Check"].Value) && Temp == false)
                    {
                        Add_Selected_Product(int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()));
                    }
                    else if (Convert.ToBoolean(item.Cells["Check"].Value) == false && Temp)
                    {
                        foreach (DataGridViewRow item2 in dataGridView2.Rows)
                        {
                            if (int.Parse(item.Cells["ID_PRODUIT"].Value.ToString()) == int.Parse(item2.Cells["ID_PRODUIT1"].Value.ToString()))
                            {
                                DialogResult Dialog = MessageBox.Show("Do You Want To unselect Product N° = ' " + item.Cells["ID_PRODUIT"].Value.ToString() + " '", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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


        private void SelectProductsAfterSearch()
        {
            if (dataGridView2.Rows.Count > 0)
            {
                foreach (DataGridViewRow Item2 in dataGridView2.Rows)
                {
                    //Select  selected Products in datagridview 1 :

                    foreach (DataGridViewRow Item in dataGridView1.Rows)
                    {
                        if (int.Parse(Item2.Cells["ID_PRODUIT1"].Value.ToString()) == int.Parse(Item.Cells["ID_PRODUIT"].Value.ToString()))
                        {
                            Item.Cells["Check"].Value = true;
                        }
                    }
                }
            }
            return;

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
                        this.dataGridView2.Rows.Add(ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], 0);
                    }

                    dataGridView2.Columns[1].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);

                }
                else
                {
                    MessageBox.Show("La Table Produit est vide !!!");
                }


            }
        }
        private void Load_Data_Produit(String Query)
        {
            dataGridView1.Rows.Clear();

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd = new SqlCommand(Query, Conx);
                Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                Conx.Open();
                SqlDataReader ReadProduit = Cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                if (ReadProduit.HasRows)
                {

                    while (ReadProduit.Read())
                    {
                        this.dataGridView1.Rows.Add(false, ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5], false), String.Format("{0:0.##}", ReadProduit[6]));
                    }
                    dataGridView1.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);

                }
                else
                {
                    MessageBox.Show("La Table Produit est vide !!!");
                }
            }
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Search_Produit(string Search)
        {
            String Query = "SELECT * From PRODUIT";

            if (comboBox1.SelectedIndex == 0 || Search == string.Empty)
            {
                Query += $" WHERE IDFOUR = '{IDFOUR}'";

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Query += $" WHERE IDPRODUIT LIKE '" + Search + $"%' and IDFOUR = '{IDFOUR}';";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Query += $" WHERE DESIGNATION LIKE '" + Search + $"%' and IDFOUR = '{IDFOUR}'";
            }

            Load_Data_Produit(Query);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            CheckBox();
            Search_Produit(Search.Text);
            SelectProductsAfterSearch();

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
            Add_Produit Form = new Add_Produit(IDFOUR,panel);
            Form.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_CMD_Four_Load_1(object sender, EventArgs e)
        {
            label1.Text = ENTREPRISE;
            dateTimePicker.Value = DateTime.Now;
            comboBox1.Text = "Tous";
            Search_Produit("");
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
                    if (float.Parse(item.Cells["Quantite"].Value.ToString()) != 0)
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
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    if (CheckeSelectedProduct() == "true" && Description.Text != "" && MONTANTTOTAL.Text != "" && comboBox.Text != "")
                    {
                        string Query = "INSERT INTO COMMANDEFOUR(IDFOUR,DESCRIPTION,STATUT,DATECMD,PESPECE,PCHEQUE,MONTANTTOTAL) values(@IDFOUR,@DESCRIPTION,@STATUT,@DATECMD,@PESPECE,@PCHEQUE,@MONTANTTOTAL);";
                        Conx.Open();
                        SqlCommand Cmd = new SqlCommand(Query, Conx);
                        try
                        {
                            if (comboBox.Text == "payee")
                            {
                                Cmd.Parameters.AddWithValue("STATUT", true);
                            }
                            else
                            {
                                Cmd.Parameters.AddWithValue("STATUT", false);
                            }
                            Cmd.Parameters.AddWithValue("PCHEQUE", false);
                            Cmd.Parameters.AddWithValue("PESPECE", false);
                            Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                            Cmd.Parameters.AddWithValue("DESCRIPTION", Description.Text);
                            Cmd.Parameters.AddWithValue("DATECMD", DateTime.Parse(dateTimePicker.Text));
                            Cmd.Parameters.AddWithValue("MONTANTTOTAL", double.Parse(MONTANTTOTAL.Text));
                            Cmd.ExecuteNonQuery();

                            SqlCommand CmdId = new SqlCommand("SELECT max(ID_CMD_FOUR) FROM COMMANDEFOUR;", Conx);
                            SqlDataReader Read = CmdId.ExecuteReader();

                            while (Read.Read())
                            {
                                COMMANDER(int.Parse(Read[0].ToString()));
                            }

                            panel.Controls.Clear();
                            List_Main_Four MFour = new List_Main_Four(IDFOUR,panel, 1);
                            MainClass.ShowControl(MFour, panel);
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
                            Description.Focus();
                        }
                        if (comboBox.Text == "")
                        {
                            labelStatut.Visible = true;
                            label4.BackColor = Color.Red;
                            comboBox.Focus();
                            MessageBox.Show("Veuillez Préciser La Statut de La Commande");
                        }
                        if (MONTANTTOTAL.Text == "")
                        {
                            labelMT.Visible = true;
                            label8.BackColor = Color.Red;
                            MONTANTTOTAL.Focus();
                            MessageBox.Show("Veuillez Saisir Le Montant Total de La Commande");
                        }

                        if (CheckeSelectedProduct() == "false" || CheckeSelectedProduct() != "true")
                        {
                            labelQuantite.BackColor = Color.Red;
                            if (CheckeSelectedProduct() != "true" && CheckeSelectedProduct() != "false")
                            {
                                MessageBox.Show("Veuillez Verifier La Quantite de Produit ' " + CheckeSelectedProduct() + "' .");
                                this.dataGridView2.Columns["Quantite"].HeaderCell.Style.BackColor = Color.Red;
                            }
                            else
                            {
                                MessageBox.Show("Veuillez Selecter les Produit.");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBox();
            SelectProductsAfterSearch();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}