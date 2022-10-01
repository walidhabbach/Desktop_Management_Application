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
        private Panel Panel;
        private float TOTAL;

        public Edit_CMD_Four(int ID, int FOUR, Panel panel)
        {
            InitializeComponent();
            IDCMD = ID;
            IDFOUR = FOUR;
            Panel = panel;

        }

        private void Load_Data_Cmd()
        {
            try
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
                        Search.Text = "";
                        comboBox1.SelectedIndex = 0;
                        Search_Produit(Search.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Search For a Product From DataGridView(Selected Products)
        private bool IDProduit_DGV2(int ID)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); return false;
            }
        }

        //Delete or ADD Selected Product From DataGridView(Selected Products)
        private void CheckBox()
        {
            //DataGridViewCheckBoxColumn Cb = new DataGridViewCheckBoxColumn();
            //DataGridView.Columns.Insert(0, Cb);
            //this.dataGridView2.Rows.Clear();
            try
            {
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
                                    DialogResult Dialog = MessageBox.Show("Do You Want To unselect Product N° = ' " + item.Cells["IDPRODUIT"].Value.ToString() + " '", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (Dialog == DialogResult.Yes)
                                    {
                                        TOTAL -= float.Parse(item.Cells["PRIXACHAT"].Value.ToString());
                                        TOTALCMD.Text = TOTAL.ToString() + " DH";
                                        dataGridView2.Rows.RemoveAt(item2.Index);

                                    }
                                    else if (Dialog == DialogResult.No)
                                    {
                                        /*dataGridView1.Rows.Add(true, item.Cells["ID_PRODUIT"].Value.ToString(), item.Cells["IDPRODUIT"].Value.ToString(), item.Cells["DESIGNATION"].Value.ToString(), String.Format("{0:0.##}", item.Cells["PRIXACHAT"].Value.ToString()), String.Format("{0:0.##}", item.Cells["PRIXVENTE"].Value.ToString()), String.Format("{0:0.##}", item.Cells["DPRIXVENTE"].Value.ToString()));
                                        dataGridView1.Rows.RemoveAt(item.Index);*/
                                        item.Cells["Check"].Value = true;

                                    }

                                }
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

        private void Add_Selected_Product(int ID_PRODUIT, float QTE)
        {
            try
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
                            TOTAL = TOTAL + float.Parse(ReadProduit["PRIXACHAT"].ToString());
                            TOTALCMD.Text = TOTAL.ToString() + " DH";

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void SelectProductsAfterSearch()
        {
            try
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void SelectProducts_Load()
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {

                    SqlCommand Cmd1 = new SqlCommand($"SELECT ID_PRODUIT FROM COMMANDER WHERE ID_CMD_FOUR = '{IDCMD}';", Conx);
                    Conx.Open();
                    SqlDataReader Read = Cmd1.ExecuteReader();

                    if (Read.HasRows && dataGridView1.Rows.Count > 0)
                    {
                        while (Read.Read())
                        {
                            //Select  selected Products in datagridview 1 :
                            foreach (DataGridViewRow Item in dataGridView1.Rows)
                            {
                                if (int.Parse(Read["ID_PRODUIT"].ToString()) == int.Parse(Item.Cells[1].Value.ToString()))
                                {
                                    Item.Cells["Check"].Value = true;
                                }
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
        private void Load_Data_Produit(String Query)
        {
            try
            {
                dataGridView1.Rows.Clear();

                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    SqlCommand Cmd = new SqlCommand(Query, Conx);
                    Conx.Open();
                    SqlDataReader ReadProduit = Cmd.ExecuteReader();


                    if (ReadProduit.HasRows)
                    {
                        while (ReadProduit.Read())
                        {
                            this.dataGridView1.Rows.Add(false, ReadProduit["ID_PRODUIT"], ReadProduit["IDPRODUIT"], ReadProduit["DESIGNATION"], String.Format("{0:0.##}", ReadProduit[3].ToString()), String.Format("{0:0.##}", ReadProduit[4].ToString()), String.Format("{0:0.##}", ReadProduit[5].ToString()));
                        }

                        dataGridView1.Columns["DESIGNATION"].Width = 200;
                        dataGridView1.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);

                        SelectProducts_Load();

                    }
                    else
                    {
                        MessageBox.Show("La Table Produit est vide !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_Produit(string Search)
        {
            try
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
                SelectProductsAfterSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
        public void Clear()
        {
            Description.Text = "";
            comboBox.Text = "";
            TOTAL = 0;
            MONTANTTOTAL.Text = "";
            comboBox.Text = "";
        }

        private string CheckeSelectedProduct()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "false";
            }
        }
        private void COMMANDER(int IDCMD)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    SqlCommand Cmd;
                    SqlCommand CmdDelete;
                    Conx.Open();
                    CmdDelete = new SqlCommand("DELETE FROM COMMANDER WHERE ID_CMD_FOUR = @ID_CMD_FOUR ;", Conx);
                    CmdDelete.Parameters.AddWithValue("ID_CMD_FOUR", IDCMD);
                    CmdDelete.ExecuteNonQuery();

                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Edit_CMD_Four_Load_1(object sender, EventArgs e)
        {
            TOTAL = 0;
            TOTALCMD.Text = " 0 DH";
            AddDeleteButton();
            Load_Data_Cmd();


        }

        private void AddDeleteButton()
        {
            MainClass.Button_DGV(dataGridView2, "Delete", "remove1");
            dataGridView2.Columns["Delete"].Width = 70;
        }
          
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBox();
                Search_Produit(Search.Text);
                SelectProductsAfterSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            string SelectedProduct = CheckeSelectedProduct();
            try
            {
                if (SelectedProduct == "Refresh")
                {
                    MessageBox.Show("Actualiser !!!");
                    CheckBox();
                    return;
                }
                else
                {

                    using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                    {

                        if (SelectedProduct == "true" && Description.Text != "" && MONTANTTOTAL.Text != "" && comboBox.Text != "")
                        {

                            string Query = "UPDATE COMMANDEFOUR SET IDFOUR = @IDFOUR ,DESCRIPTION = @DESCRIPTION , STATUT = @STATUT, DATECMD=@DATECMD,MONTANTTOTAL=@MONTANTTOTAL WHERE ID_CMD_FOUR = @ID_CMD_FOUR ;";
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

                                Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                                Cmd.Parameters.AddWithValue("DESCRIPTION", Description.Text);
                                Cmd.Parameters.AddWithValue("DATECMD", DateTime.Parse(dateTimePicker.Text));
                                Cmd.Parameters.AddWithValue("MONTANTTOTAL", double.Parse(MONTANTTOTAL.Text));
                                Cmd.Parameters.AddWithValue("ID_CMD_FOUR", IDCMD);
                                Cmd.ExecuteNonQuery();

                                COMMANDER(IDCMD);

                                Conx.Close();


                                Panel.Controls.Clear();
                                List_Main_Four L = new List_Main_Four(IDFOUR, Panel, 1);
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
                                Description.Focus();
                                labelDescription.Visible = true;
                                label2.BackColor = Color.Red;
                                MessageBox.Show("Veuillez Saisir La Description de La Commande");
                            }
                            if (comboBox.Text == "")
                            {
                                comboBox.Focus();
                                labelStatut.Visible = true;
                                label4.BackColor = Color.Red;
                                MessageBox.Show("Veuillez Préciser La Statut de La Commande");
                            }
                            if (MONTANTTOTAL.Text == "")
                            {
                                MONTANTTOTAL.Focus();
                                labelMT.Visible = true;
                                label8.BackColor = Color.Red;
                                MessageBox.Show("Veuillez Saisir Le Montant Total de La Commande");
                            }
                            if (SelectedProduct == "false" || SelectedProduct != "true")
                            {
                                labelQuantite.BackColor = Color.Red;
                                if (SelectedProduct != "true" && SelectedProduct != "false")
                                {
                                    MessageBox.Show("Veuillez Verifier La Quantite de Produit ' " + SelectedProduct + "' .");
                                    this.dataGridView2.Columns["Quantite"].HeaderCell.Style.BackColor = Color.Red;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int IDCMD;
                    DialogResult Dialog;
                    String ColName;
                    DataGridViewRow Row;

                    Row = dataGridView2.Rows[e.RowIndex];
                    Row.Selected = true;
                    IDCMD = Convert.ToInt32(Row.Cells[0].Value.ToString());
                    ColName = this.dataGridView2.Columns[e.ColumnIndex].Name;
                    if (ColName == "Delete")
                    {
                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {

                            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                            {
                                if (int.Parse(dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells["ID_PRODUIT1"].Value.ToString()) == int.Parse(row.Cells["ID_PRODUIT"].Value.ToString()))
                                {
                                    row.Cells["Check"].Value = false;
                                    TOTAL -= float.Parse(row.Cells["PRIXACHAT"].Value.ToString());
                                    TOTALCMD.Text = TOTAL.ToString() + " DH";
                                    break;
                                }
                            }
                            this.dataGridView2.Rows.RemoveAt(this.dataGridView2.CurrentRow.Index);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckBox();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
    }
}


