using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit
{
    public partial class Add_ESP_Four : UserControl
    {
        private readonly int IDFOUR;
        private readonly Panel Panel;
        private float TOTAL;
        private String QueryCMD;
        private String QueryCMDAll;
        public Add_ESP_Four(int FOUR, Panel Panel)
        {
            InitializeComponent();
            IDFOUR = FOUR;
            this.Panel = Panel;
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
                                TOTAL = TOTAL - float.Parse(item2.Cells["MONTANTTOTAL1"].Value.ToString());
                                TOTALCMD.Text = TOTAL.ToString() + " DH";
                                dataGridView2.Rows.RemoveAt(item2.Index);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private string CheckeSelected_Cmd()
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
                return "true";
            }
            else
            {
                return "false";
            }
        }
        private void AddDeleteButton()
        {
            MainClass.Button_DGV(dataGridView2, "Delete", "remove1");
            dataGridView2.Columns["Delete"].Width = 50;
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
                    try
                    {

                        while (ReadCmd.Read())
                        {
                            this.dataGridView2.Rows.Add(ReadCmd["ID_CMD_FOUR"], ReadCmd["DESCRIPTION"], ReadCmd["MONTANTTOTAL"].ToString(), ReadCmd["MTRESTE"]);

                            TOTAL = TOTAL + float.Parse(ReadCmd["MONTANTTOTAL"].ToString());
                            TOTALCMD.Text = TOTAL.ToString() + " DH";
                        }


                        dataGridView2.Columns[0].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);
                        dataGridView2.Columns[1].DefaultCellStyle.Font = new Font("Tahoma", 12);

                    }
                    catch (SqlException EX)
                    {
                        MessageBox.Show(EX.Message);
                    }
                    CheckBox();
                }
                else
                {
                    MessageBox.Show("La Table COMMANDEFOUR est vide !!!");
                }

            }
        }
        private void SelectCmdAfterSearch()
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
            return;

        }
        private void Search_Cmd(string Search)
        {
            String Query = "SELECT * From COMMANDEFOUR";

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

        private void Data_Cmd(String Query)
        {

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                string Statut = "non payée";
                SqlCommand CmdFour = new SqlCommand(Query, Conx);
                try
                {
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
                                ReadCmdFour["MONTANTTOTAL"],
                                Convert.ToDateTime(ReadCmdFour["DATECMD"]).ToString("dd MMMM yyyy"));
                        };
                    }
                    else
                    {
                        MessageBox.Show("Aucune Commande a ete enregistrer de ce Fournisseur !!!");
                    }

                }
                catch (SqlException EX)
                {
                    MessageBox.Show(EX.Message);
                }

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
                                ReadCmdFour["MTRESTE"],
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CheckBox();
            dataGridView1.Rows.Clear();
            if (comboBox1.Text == "Tous")
            {

                QueryCMDAll = $"select * from COMMANDEFOUR where IDFOUR = '{IDFOUR}' and year(DATECMD) = '{dateTimePicker2.Value.Year}' ;";
                Data_Cmd(QueryCMDAll);
            }
            else
            {
                QueryCMD = $"select * from COMMANDEFOUR where IDFOUR = '{IDFOUR}' and month(DATECMD) = '{MainClass.ConvertToNumber(comboBox1.Text)}' and year(DATECMD) = '{dateTimePicker2.Value.Year}' ;";
                Data_Cmd(QueryCMD);
            }
        }

        public void Clear()
        {
            textBox1.Text = "";
            Montant.Text = "";
            comboBox1.Text = "";
        }

        private void REGLER_ESP_FOUR(int IDESP_FOUR)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd;
                SqlCommand Cmd2;
                Conx.Open();
                try
                {
                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
                        Cmd = new SqlCommand($"INSERT INTO REGLER_ESP_FOUR(ID_CMD_FOUR,IDESP_FOUR) values('{int.Parse(item.Cells["ID_CMD1"].Value.ToString())}' , '{IDESP_FOUR}');", Conx);
                        Cmd2 = new SqlCommand($"UPDATE COMMANDEFOUR SET PESPECE = '{true}' WHERE ID_CMD_FOUR = '{int.Parse(item.Cells["ID_CMD1"].Value.ToString())}' ;", Conx);

                        Cmd.ExecuteNonQuery();
                        Cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show($"PAIEMENT N°'{IDESP_FOUR}' a été ajouté");

                    Conx.Close();
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private string N_PAIEMENT()
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand CmdId = new SqlCommand("SELECT max(IDESP_FOUR) FROM PAIEMENTESPECEFOUR;", Conx);
                Conx.Open();
                SqlDataReader Read = CmdId.ExecuteReader();
                if (Read.HasRows)
                {
                    try
                    {
                        int Num;
                        while (Read.Read())
                        {
                            Num = Convert.ToInt32(Read[0].ToString()) + 1;
                            return Num.ToString().TrimStart();
                        }

                        Conx.Close();
                        Clear();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    return null;
                }
                else
                {
                    return "1";
                }
            }

        }
        private bool TestifAnySelectedCmd()
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
        private void Add_Click(object sender, EventArgs e)
        {
            string CheckSelected = CheckeSelected_Cmd();
            if (CheckSelected == "Refresh")
            {
                MessageBox.Show("Actualiser !!!");
                CheckBox();
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
                    if (CheckSelected == "true" && Montant.Text != "" && MainClass.TypeCheckFloat(Montant.Text))
                    {
                        Conx.Open();
                        SqlCommand Cmd = new SqlCommand($"INSERT INTO PAIEMENTESPECEFOUR(DATE_PAIEMENT,MONTANT,IDFOUR) values(@DATE_PAIEMENT,@MONTANT,@IDFOUR);", Conx);
                        try
                        {
                            Cmd.Parameters.AddWithValue("DATE_PAIEMENT", dateTimePicker1.Value);
                            Cmd.Parameters.AddWithValue("@IDFOUR", IDFOUR);
                            Cmd.Parameters.AddWithValue("MONTANT", float.Parse(Montant.Text));
                            Cmd.ExecuteNonQuery();
                            MessageBox.Show("test1");
                            SqlCommand CmdId = new SqlCommand("SELECT max(IDESP_FOUR) FROM PAIEMENTESPECEFOUR;", Conx);
                            SqlDataReader Read = CmdId.ExecuteReader();
                            if (Read.HasRows)
                            {
                                while (Read.Read())
                                {
                                    MessageBox.Show(Read[0].ToString());
                                    REGLER_ESP_FOUR(int.Parse(Read[0].ToString()));
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
                    else
                    {
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

                        if (CheckSelected == "false")
                        {
                            labelCmd.BackColor = Color.Red;
                            labelCmd.Visible = true;
                            MessageBox.Show("Veuillez Selecter les Produit.");

                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            TOTAL = 0;
            TOTALCMD.Text = "  0 DH";
        }
        private void button3_Click_2(object sender, EventArgs e)
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
        private void Add_ESP_Four_Load(object sender, EventArgs e)
        {

            TOTAL = 0;
            TOTALCMD.Text = " 0 DH";
            comboBox1.Text = "Tous";

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox1.Text = N_PAIEMENT();
            this.dataGridView1.Rows.Clear();
            QueryCMDAll = $"select * from COMMANDEFOUR where IDFOUR = '{IDFOUR}' and year(DATECMD) = '{dateTimePicker2.Value.Year}' ;";
            Data_Cmd(QueryCMDAll);
            AddDeleteButton();
            SetMyCustomFormat();
        }
        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            SetMyCustomFormat();
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
                        TOTAL = TOTAL - float.Parse(dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells["MONTANTTOTAL1"].Value.ToString());
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}





