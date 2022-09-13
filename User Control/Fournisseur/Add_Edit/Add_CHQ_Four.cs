using Store_Management_System.Class;
using Store_Management_System.Model;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit
{
    public partial class Add_CHQ_Four : UserControl
    {
        private readonly int IDFOUR;
        private readonly Panel panel;
        private String Query ;
        private String QueryAll ;
        public Add_CHQ_Four(int FOUR, Panel Panel)
        {
            InitializeComponent();
            IDFOUR = FOUR;
            Panel = panel;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool IDCMD_DGV2(int ID)
        {
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                if (ID == int.Parse(item.Cells["ID_CMD1"].Value.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
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
                    Temp = IDCMD_DGV2(int.Parse(item.Cells["ID_CMD"].Value.ToString()));

                    if (Convert.ToBoolean(item.Cells["Check"].Value) && Temp == false)
                    {
                        Add_Selected_Cmd(int.Parse(item.Cells["ID_CMD"].Value.ToString()));
                    }
                    else if (Convert.ToBoolean(item.Cells["Check"].Value) == false && Temp)
                    {
                        foreach (DataGridViewRow item2 in dataGridView2.Rows)
                        {
                            if (int.Parse(item.Cells["ID_CMD"].Value.ToString()) == int.Parse(item2.Cells["ID_CMD1"].Value.ToString()))
                            {
                                dataGridView2.Rows.RemoveAt(item2.Index);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private string CheckeSelectedProduct()
        {
            if (dataGridView2.RowCount > 0)
            {   string Temp = "false";
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    foreach (DataGridViewRow item2 in dataGridView2.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells["Check"].Value) == true)
                        {

                            if (int.Parse(item.Cells["ID_CMD"].Value.ToString()) == int.Parse(item2.Cells["ID_CMD1"].Value.ToString()))
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
                            if (int.Parse(item.Cells["ID_CMD"].Value.ToString()) == int.Parse(item2.Cells["ID_CMD1"].Value.ToString()))
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
                return Temp;
            }
            else
            {
                return "false";
            }
        }
        private void AddDeleteButton()
        {
            MainClass.Button_DGV(dataGridView2, "Delete", "delete");
            dataGridView2.Columns["Delete"].Width = 40;
        }
        private void Add_Selected_Cmd(int IDCMD)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd = new SqlCommand("SELECT * From COMMANDEFOUR WHERE ID_CMD_FOUR = @ID_CMD_FOUR;", Conx);
                Cmd.Parameters.AddWithValue("ID_CMD_FOUR", IDCMD);
                Conx.Open();
                SqlDataReader ReadCmd = Cmd.ExecuteReader();

                if (ReadCmd.HasRows)
                {
                    while (ReadCmd.Read())
                    {
                        this.dataGridView2.Rows.Add(ReadCmd["ID_CMD_FOUR"], ReadCmd["DESCRIPTION"], ReadCmd["MONTANTTOTAL"], ReadCmd["MTRESTE"]);
                    }

                    dataGridView2.Columns[0].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);
                    dataGridView2.Columns[1].DefaultCellStyle.Font = new Font("Tahoma", 12);
                }
                else
                {
                    MessageBox.Show("La Table COMMANDEFOUR est vide !!!");
                }

            }
        }
        
        private void Data_Cmd(String Query)
        {

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                string Statut = "non payée";
                SqlCommand CmdFour = new SqlCommand(Query, Conx);
               

                Conx.Open();
                SqlDataReader ReadCmdFour = CmdFour.ExecuteReader();
                if (ReadCmdFour.HasRows)
                {
                    while (ReadCmdFour.Read())
                    {
                        if ((bool)ReadCmdFour["STATUT"])
                        {
                            Statut = "payée";
                        }

                        this.dataGridView1.Rows.Add(
                            false,
                            ReadCmdFour["ID_CMD_FOUR"],
                            ReadCmdFour["DESCRIPTION"],
                            Statut,
                            ReadCmdFour["MTRESTE"],
                            ReadCmdFour["MONTANTTOTAL"]
                        );

                    };
                }
                else
                {
                    MessageBox.Show("Aucune Commande a ete enregistrer de ce Fournisseur !!!");
                }
            }

        }

        private void Search_Cmd(string Search)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox1.Text == "Tous")
            {
                QueryAll = $"select * from COMMANDEFOUR where IDFOUR = '{IDFOUR}'";
                dataGridView1.Rows.Clear();
                Data_Cmd(QueryAll);
            }
            else
            {
                Query = $"select * from COMMANDEFOUR where IDFOUR = '{IDFOUR}' and month(DATECMD) = '{MainClass.ConvertToNumber(comboBox1.Text)}' and year(DATECMD) = '{dateTimePicker2.Value.Year}' ;";
                dataGridView1.Rows.Clear();
                Data_Cmd(Query);
            }
        }


        public void Clear()
        {
            IDCHQ.Text = "";
            Montant.Text = "";
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckBox();
        }

        private void REGLE_CHQ_FOUR(int IDCHQ_FOUR)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd;
                Conx.Open();
                try
                {
                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
                        Cmd = new SqlCommand("INSERT INTO REGLE_CHQ_FOUR(IDCHQ_FOUR,ID_CMD_FOUR) values(@IDCHQ_FOUR,@ID_CMD_FOUR);", Conx);
                        Cmd.Parameters.AddWithValue("IDCHQ_FOUR", IDCHQ_FOUR);
                        Cmd.Parameters.AddWithValue("ID_CMD_FOUR", item.Cells["ID_CMD1"].Value.ToString());
                        Cmd.ExecuteNonQuery();
                    }

                    Conx.Close();
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {

            CheckBox();
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                if (CheckeSelectedProduct() == "true" && IDCHQ.Text != "" && Montant.Text != "" && MainClass.TypeCheckFloat(Montant.Text) && DateTime.Compare(dateTimePicker.Value, dateTimePicker1.Value) > 0)
                {
                    string Query = "INSERT INTO CHEQUEFOURNISSEUR(DATEDONNER,DATEPAYER,MONTANT,N_CHQ) values(@DATEDONNER,@DATEPAYER,@MONTANT,@N_CHQ);";
                    Conx.Open();
                    SqlCommand Cmd = new SqlCommand(Query, Conx);
                    try
                    {
                        Cmd.Parameters.AddWithValue("N_CHQ", IDCHQ.Text);
                        Cmd.Parameters.AddWithValue("DATEDONNER", dateTimePicker.Value);
                        Cmd.Parameters.AddWithValue("DATEPAYER", dateTimePicker1.Value);
                        Cmd.Parameters.AddWithValue("MONTANT", float.Parse(Montant.Text));
                        Cmd.ExecuteNonQuery();
                        MessageBox.Show("test");
                        SqlCommand CmdId = new SqlCommand("SELECT max(IDCHQ_FOUR) FROM CHEQUEFOURNISSEUR;", Conx);
                        SqlDataReader Read = CmdId.ExecuteReader();

                        while (Read.Read())
                        {
                            MessageBox.Show( Read[0].ToString());
                            REGLE_CHQ_FOUR(int.Parse(Read[0].ToString()));
                        }

                        Conx.Close();
                        Clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                else
                {
                    if (IDCHQ.Text == "")
                    {
                        labelDescription.Visible = true;
                        label2.BackColor = Color.Red;
                        MessageBox.Show("Veuillez Saisir La Description de La Commande");
                    }
                    if (DateTime.Compare(dateTimePicker.Value, dateTimePicker1.Value) > 0)
                    {
                        label1.Visible = true;
                        DATE.BackColor = Color.Red;
                        MessageBox.Show("Veuillez Choisir La Date de Paiement ");
                    }
                    if (Montant.Text == "")
                    {
                        labelMT.Visible = true;
                        label8.BackColor = Color.Red;
                        MessageBox.Show("Veuillez Saisir Le Montant Total de La Commande");
                    }
                    else if (MainClass.TypeCheckFloat(Montant.Text)==false)
                    {
                        labelMT.Visible = true;
                        label8.BackColor = Color.Red;
                        MessageBox.Show("veuillez Vérifier Le Montant de Cheque");
                    }

                    if (CheckeSelectedProduct() == "false" )
                    {
                        labelCmd.BackColor = Color.Red;
                        labelCmd.Visible = true;
                        MessageBox.Show("Veuillez Selecter les Produit.");

                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            
        }
  
        private void button3_Click_1(object sender, EventArgs e)
        {
            CheckBox();
        }
        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            //dateTimePicker2.CustomFormat = "MMMM yyyy";
            dateTimePicker2.CustomFormat = "yyyy";
            //dateTimePicker2.ShowUpDown = true;
        }
        private void Add_CHQ_Four_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Tous";
            Data_Cmd(QueryAll);
            AddDeleteButton();
            SetMyCustomFormat();
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker.Value = DateTime.Now;
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Query = $"select * from COMMANDEFOUR where IDFOUR = '{IDFOUR}' and month(DATECMD) = '{MainClass.ConvertToNumber(comboBox1.Text)}' and year(DATECMD) = '{dateTimePicker2.Value.Year}' ;";
            Data_Cmd(Query);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[0].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Dialog == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {

                        foreach (DataGridViewRow row in this.dataGridView1.Rows)
                        {
                            if (int.Parse(dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells["ID_CMD1"].Value.ToString()) == int.Parse(row.Cells["ID_CMD"].Value.ToString()))
                            {
                                row.Cells["Check"].Value = false;
                               break;
                            }
                        }
                        this.dataGridView2.Rows.RemoveAt(this.dataGridView2.CurrentRow.Index); 
                        
                    }

                }
            }
        }
    }
}

