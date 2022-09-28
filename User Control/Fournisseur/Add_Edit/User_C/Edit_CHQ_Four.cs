using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.ListALL;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C
{
    public partial class Edit_CHQ_Four : UserControl
    {
        private readonly int IDFOUR;
        private readonly int IDCHQ;
        private Panel panel;
        private float TOTAL;
  

        public Edit_CHQ_Four(int FOUR, int IDCHQ, Panel panel)
        {
            InitializeComponent();
            IDFOUR = FOUR;
            this.IDCHQ = IDCHQ;
            this.panel = panel;
        }


        private void Edit_CHQ_Four_Load(object sender, EventArgs e)
        {
            TOTAL = 0;
            TOTALCMD.Text = " 0 DH";
  
            comboBox2.SelectedIndex = 0;
            SetMyCustomFormat();
            try
            {
                AddDeleteButton();
                Load_CHQ_Data();
                Search_Cmd("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Load_CHQ_Data()
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    Conx.ConnectionString = MainClass.ConnectionDataBase();
                    SqlCommand Cmd = new SqlCommand($"SELECT * FROM CHEQUEFOURNISSEUR WHERE IDCHQ_FOUR = '{IDCHQ}';", Conx);
                    SqlCommand CmdCMD = new SqlCommand($"SELECT ID_CMD_FOUR FROM REGLE_CHQ_FOUR WHERE IDCHQ_FOUR= '{IDCHQ}';", Conx);

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();
                    SqlDataReader ReadCMD = CmdCMD.ExecuteReader();

                    this.dataGridView1.Rows.Clear();
                    if (ReadCMD.HasRows && Read.HasRows)
                    {
                        while (Read.Read())
                        {
                            NCHQ.Text = Read["N_CHQ"].ToString();
                            dateTimePicker.Value = DateTime.Parse(Read["DATEDONNER"].ToString());
                            dateTimePicker1.Value = DateTime.Parse(Read["DATEPAYER"].ToString());
                            Montant.Text = Read["MONTANT"].ToString();

                            while (ReadCMD.Read())
                            {
                                //Add Selected Cmd to datagridview 2 :
                                Add_Selected_Cmd(int.Parse(ReadCMD[0].ToString()));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aucune Commande a ete enregistrer de ce Fournisseur !!!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IDCMD_DGV2(int ID)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
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
                                    DialogResult Dialog = MessageBox.Show($"Do You Want To unselect Cmd N° = { item.Cells["ID_CMD"].Value.ToString()}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (Dialog == DialogResult.Yes)
                                    {
                                        TOTAL -= float.Parse(item2.Cells["MONTANTTOTAL1"].Value.ToString());
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

        // Check if the user needs to refresh Selected orders
        private string CheckSelectedCmd()
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "false";
            }
        }

        // Select Cmd After Search
        private void SelectCmdAfterSearch()
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
                            if (int.Parse(Item2.Cells["ID_CMD1"].Value.ToString()) == int.Parse(Item.Cells["ID_CMD"].Value.ToString()))
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

        private void Add_Selected_Cmd(int IDCMD)
        {
            try
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
                            this.dataGridView2.Rows.Add(ReadCmd["ID_CMD_FOUR"], ReadCmd["DESCRIPTION"], ReadCmd["MONTANTTOTAL"].ToString());

                            TOTAL += float.Parse(ReadCmd["MONTANTTOTAL"].ToString());
                            TOTALCMD.Text = TOTAL.ToString() + " DH";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Search_Cmd(string Search)
        {
            String Query = "SELECT * From COMMANDEFOUR";
            try
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    Query += $" WHERE IDFOUR = '{IDFOUR}' and year(DATECMD) = '{dateTimePicker2.Value.Year}' ;";

                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    Query += $" WHERE IDFOUR = '{IDFOUR}' and month(DATECMD) = '{dateTimePicker2.Value.Month}' and year(DATECMD) = '{dateTimePicker2.Value.Year}' ;";
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    Query += $" WHERE ID_CMD_FOUR = '{int.Parse(Search)}';";
                }
                else if (comboBox2.SelectedIndex == 3)
                {
                    Query += $" WHERE DESCRIPTION LIKE '" + Search + $"%' and IDFOUR = '{IDFOUR}'";
                }
                else if (comboBox2.SelectedIndex == 4)
                {
                    if (Search.Substring(0, 1).ToLower() == "n")
                    {
                        Query += $" WHERE STATUT = 0 and IDFOUR = '{IDFOUR}'";
                    }
                    else if (Search.Substring(0, 1).ToLower() == "p")
                    {
                        Query += $" WHERE STATUT = 1 and IDFOUR = '{IDFOUR}'";
                    }
                }
                else if (comboBox2.SelectedIndex == 5)
                {
                    Query += $" WHERE MONTANTTOTAL = '{float.Parse(Search)}' and IDFOUR = '{IDFOUR}'";
                }

                Load_Data_Cmd(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Load_Data_Cmd(String Query)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    string Statut = "non payée";
                    SqlCommand CmdFour = new SqlCommand(Query, Conx);

                    Conx.Open();
                    SqlDataReader ReadCmdFour = CmdFour.ExecuteReader();
                    this.dataGridView1.Rows.Clear();
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
                                ReadCmdFour["MONTANTTOTAL"],
                                Convert.ToDateTime(ReadCmdFour["DATECMD"]).ToString("dd MMMM yyyy"));
                        };
                        SelectCmdAfterSearch();
                    }
                    else
                    {
                        MessageBox.Show("Aucune Commande a ete enregistrer de ce Fournisseur !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void REGLE_CHQ_FOUR(int IDCHQ_FOUR)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    SqlCommand Cmd;
                    SqlCommand CmdDelete;
                    SqlCommand CmdUpdate;
                    Conx.Open();

                    CmdDelete = new SqlCommand($"DELETE FROM REGLE_CHQ_FOUR WHERE IDCHQ_FOUR = '{IDCHQ_FOUR}';", Conx);
                    CmdDelete.ExecuteNonQuery();
                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
                        Cmd = new SqlCommand("INSERT INTO REGLE_CHQ_FOUR(IDCHQ_FOUR,ID_CMD_FOUR) values(@IDCHQ_FOUR,@ID_CMD_FOUR);", Conx);
                        CmdUpdate = new SqlCommand($"UPDATE COMMANDEFOUR SET PCHEQUE = '{true}' WHERE ID_CMD_FOUR = @ID_CMDUpdate ;", Conx);

                        Cmd.Parameters.AddWithValue("IDCHQ_FOUR", IDCHQ_FOUR);
                        Cmd.Parameters.AddWithValue("ID_CMD_FOUR", int.Parse(item.Cells["ID_CMD1"].Value.ToString()));
                        CmdUpdate.Parameters.AddWithValue("ID_CMDUpdate", int.Parse(item.Cells["ID_CMD1"].Value.ToString()));
                        Cmd.ExecuteNonQuery();
                        CmdUpdate.ExecuteNonQuery();
                    }
                    Conx.Close();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool TestifAnySelectedCmd()
        {
            try
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Check"].Value) == true)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            try
            {
                string CheckSelected = CheckSelectedCmd();
                if (CheckSelected == "Refresh")
                {
                    CheckBox();
                    MessageBox.Show("Actualiser !!!");
                    return;
                }
                else if (CheckSelected == "false" && TestifAnySelectedCmd())
                {
                    CheckBox();
                    MessageBox.Show("Actualiser !!!");
                    return;
                }
                else
                {
                    using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                    {
                        if (CheckSelected == "true" && NCHQ.Text != "" && Montant.Text != "" && MainClass.TypeCheckFloat(Montant.Text) && DateTime.Compare(dateTimePicker.Value, dateTimePicker1.Value) < 0)
                        {
                            Conx.Open();

                            SqlCommand Cmd = new SqlCommand($"UPDATE  CHEQUEFOURNISSEUR SET DATEDONNER = @DATEDONNER,DATEPAYER=@DATEPAYER,MONTANT=@MONTANT,N_CHQ=@N_CHQ  WHERE IDCHQ_FOUR = @IDCHQ ;", Conx);

                            Cmd.Parameters.AddWithValue("DATEDONNER", dateTimePicker.Value);
                            Cmd.Parameters.AddWithValue("DATEPAYER", dateTimePicker1.Value);
                            Cmd.Parameters.AddWithValue("MONTANT", float.Parse(Montant.Text));
                            Cmd.Parameters.AddWithValue("N_CHQ", NCHQ.Text);
                            Cmd.Parameters.AddWithValue("IDCHQ", IDCHQ);

                            Cmd.ExecuteNonQuery();
                          
                            REGLE_CHQ_FOUR(IDCHQ);

                            MessageBox.Show($"CHQ N°'{NCHQ.Text}' a été modifie");
                            panel.Controls.Clear();
                            List_Main_Four MFour = new List_Main_Four(IDFOUR, panel, 3);
                            MainClass.ShowControl(MFour, panel);

                            Conx.Close();


                        }
                        else
                        {
                            if (NCHQ.Text == "")
                            {
                                labelDescription.Visible = true;
                                label2.BackColor = Color.Red;
                                MessageBox.Show("Veuillez Saisir La Description de La Commande");
                            }
                            if (DateTime.Compare(dateTimePicker.Value, dateTimePicker1.Value) >=0 )
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
                            else if (MainClass.TypeCheckFloat(Montant.Text) == false)
                            {
                                labelMT.Visible = true;
                                label8.BackColor = Color.Red;
                                MessageBox.Show("veuillez Vérifier Le Montant de Cheque");
                            }

                            if (CheckSelected == "false" && TestifAnySelectedCmd() == false)
                            {
                                labelCmd.BackColor = Color.Red;
                                labelCmd.Visible = true;
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
        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string. 
            //dateTimePicker2.CustomFormat = "MMMM yyyy";
            //dateTimePicker2.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MMMM yyyy";

        }
        private void AddDeleteButton()
        {
            MainClass.Button_DGV(dataGridView2, "Delete", "remove1");
            dataGridView2.Columns["Delete"].Width = 50;
        }
        public void Clear()
        {
            NCHQ.Text = "";
            Montant.Text = "";
     
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        Dialog = MessageBox.Show($"Do You Want To Delete '{this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[0].Value.ToString()}'", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            TOTAL -= float.Parse(dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells["MONTANTTOTAL1"].Value.ToString());
                            TOTALCMD.Text = TOTAL.ToString() + " DH";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox();
                SelectCmdAfterSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                CheckBox();
                Search_Cmd(Search.Text);
                SelectCmdAfterSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            TOTAL = 0;
            TOTALCMD.Text = "  0 DH";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
