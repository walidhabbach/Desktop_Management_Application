using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.List
{
    public partial class List_Cmd_AllFour : UserControl
    {
        Panel Content;
        public List_Cmd_AllFour(Panel content)
        {
            InitializeComponent();
            Content = content;
        }

        private void List_Cmd_AllFour_Load(object sender, EventArgs e)
        {
            FillCombobox();
            comboBox1.Text = "Tous";
            Search_Cmd(Search.Text);
            dateTimePicker2.Value = DateTime.Now;

        }

        private void Edit(int IDCMDFOUR, int IDFOUR)
        {
            Content.Controls.Clear();
            Edit_CMD_Four ECmd = new Edit_CMD_Four(IDCMDFOUR, IDFOUR, Content);
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
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        
        private void DisplaytTotal(int Month, double Total)
        {
            this.DataGridView.Rows.Add(
                                   "",
                                        "Total",
                                        "de mois",
                                        "", DateTimeFormatInfo.CurrentInfo.GetMonthName(Month),
                                        "=",
                                       Total + " DH"

                               );;
            DataGridView.Rows[DataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

        }
        private void LoadDataCmd(String Query)
        {

            this.DataGridView.Rows.Clear();

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd = new SqlCommand(Query, Conx);
                SqlCommand Cmd1 = new SqlCommand(Query, Conx);

                int i = 0;
                double Total = 0;
                int Count = 0;

                int Month = 0;
                string Statut;
                string MPaiement;

                Conx.Open();
                SqlDataReader Read = Cmd.ExecuteReader(); 
                SqlDataReader Read1 = Cmd1.ExecuteReader(); 
                if (Read.HasRows)
                {
                    while (Read1.Read())
                    {
                        if (Count == 0)
                        {
                            Month = Convert.ToDateTime(Read1[4]).Month;
                        }
                        Count++;
                    } 
                    while (Read.Read())
                    {
                        Statut = "non payée";
                        
                        if (Month != Convert.ToDateTime(Read[4].ToString()).Month || Count == i)
                        {
                            DisplaytTotal(Month, Total);
                            Total = 0;
                            Month = Convert.ToDateTime(Read[4].ToString()).Month;
                        }

                        if ((bool)Read[3])
                        {
                            Statut = "payée";
                            this.DataGridView.Columns["Column4"].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            this.DataGridView.Columns["Column4"].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        }
                        if ((bool)Read[6] && (bool)Read[5])
                        {
                            MPaiement = "CHQ et Espece";
                        }
                        else if ((bool)Read[6])
                        {
                            MPaiement = "CHQ";
                        }
                        else if ((bool)Read[5])
                        {
                            MPaiement = "Espece";
                        }
                        else
                        {
                            MPaiement = "Rien";
                        }

                        DataGridView.Columns["Column2"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 16, FontStyle.Bold);
                        DataGridView.Columns["Column7"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 14, FontStyle.Bold);

                        this.DataGridView.Rows.Add(
                           
                           Read[0],
                           Read[1],
                           Read[2],
                           Statut,
                            Convert.ToDateTime(Read[4]).ToString("dd / MM / yyyy"),
                           MPaiement,
                           Math.Round(double.Parse(Read[7].ToString()), 2) + " DH"

                       );
                        Total += Math.Round(double.Parse(Read[7].ToString()), 2);

                        i++;
                        if (Count == i)
                        {
                            DisplaytTotal(Month, Total);
                        }

                    }
                    Conx.Close();
                }
                else
                {
                    MessageBox.Show(" 0 result!!!");
                }
            }


        }

        private void FillCombobox()
        {
            comboBox2.Items.Clear();

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                String Query = "SELECT ENTREPRISE From FOURNISSEUR;";
                SqlCommand Cmd = new SqlCommand(Query, Conx);

                Conx.Open();
                SqlDataReader ReadFour = Cmd.ExecuteReader();


                // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);

                if (ReadFour.HasRows)
                {
                    comboBox2.Items.Add("Tous Les Fournisseurs");
                    while (ReadFour.Read())
                    {
                        comboBox2.Items.Add(ReadFour["ENTREPRISE"].ToString());
                    }

                    comboBox2.Text = "Tous Les Fournisseurs";
                    Conx.Close();

                }
                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");
                }
            }
        }
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    DialogResult Dialog;
                    String ColName = this.DataGridView.Columns[e.ColumnIndex].Name;
                    DataGridViewRow Row = DataGridView.Rows[e.RowIndex];
                    Row.Selected = true;
                    int IDCMDFour = Convert.ToInt32(Row.Cells["ID_CMD_FOUR"].Value);
                    int IDFOUR = Convert.ToInt32(Row.Cells["IDFOUR"].Value);
                    string NomFour = Row.Cells["ENTREPRISE"].Value.ToString();

                    if (ColName == "Edit")
                    {
                        Edit(IDCMDFour, IDFOUR);
                    }
                    else if (ColName == "Delete")
                    {

                        Dialog = MessageBox.Show("Do You Want To Delete " + this.DataGridView.Rows[this.DataGridView.CurrentRow.Index].Cells[0].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        Delete(IDCMDFour);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0)
                {
                    string ColName = this.DataGridView.Columns[e.ColumnIndex].Name;

                    if (ColName != "BtnEdit" && ColName != "BtnDelete")
                    {
                        DataGridView.Cursor = Cursors.Default;
                    }
                    else
                    {
                        DataGridView.Cursor = Cursors.Hand;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Search_Cmd(string search)
        {
            try
            {
                String Query = " SELECT COMMANDEFOUR.ID_CMD_FOUR,FOURNISSEUR.ENTREPRISE ,COMMANDEFOUR.DESCRIPTION ,COMMANDEFOUR.STATUT ,COMMANDEFOUR.DATECMD ,COMMANDEFOUR.PESPECE    ,COMMANDEFOUR.PCHEQUE  ,COMMANDEFOUR.MONTANTTOTAL  " +
                   " From COMMANDEFOUR   INNER JOIN FOURNISSEUR   ON COMMANDEFOUR.IDFOUR = FOURNISSEUR.IDFOUR    WHERE ";

                if (comboBox2.Text != "Tous Les Fournisseurs")
                {
                    Query += $"FOURNISSEUR.ENTREPRISE = '{comboBox2.Text}' and ";
                }
                if (comboBox1.Text == "Tous")
                {
                    Query += $" year(COMMANDEFOUR.DATECMD) = '{dateTimePicker2.Value.Year}' ";

                }
                else if (search != string.Empty)
                {
                    if (comboBox1.Text == "N°Cmd")
                    {
                        Query += $" COMMANDEFOUR.ID_CMD_FOUR  = '{int.Parse(search)}'  ";
                    }
                    else if (comboBox1.Text == "Description")
                    {
                        Query += $" COMMANDEFOUR.DESCRIPTION LIKE '" + search + "%' ";
                   
                    }
                    else if (comboBox1.Text == "Statut")
                    {
                        if (search.Substring(0, 1).ToLower() == "n")
                        {
                            Query += $"  COMMANDEFOUR.STATUT = '{0}' ";
                        }
                        else if (search.Substring(0, 1).ToLower() == "p")
                        {
                            Query += $" COMMANDEFOUR.STATUT = '{1}' ";
                        }
                    }
                    else if (comboBox1.Text == "Mode Paiement")
                    {

                        if (search.Substring(0, 1).ToLower() == "c")
                        {
                            Query += $" COMMANDEFOUR.PCHEQUE = '{1}' ";
                        }
                        else if (search.Substring(0, 1).ToLower() == "e")
                        {
                            Query += $" COMMANDEFOUR.PESPECE = '{1}' ;";
                        }
                    }
                    else if (comboBox1.Text == "Montant Total")
                    {
                        Query += $" COMMANDEFOUR.MONTANTTOTAL = '{float.Parse(search)}' ";
                    }

                    else if (search == String.Empty && comboBox1.Text != "Date d'Achat")
                    {
                        MessageBox.Show("Remplir la barre de recherche !!!");
                        Search.Focus();
                    }
                    else if (comboBox1.Text == "Date d'Achat")
                    {
                        Query += $" month(COMMANDEFOUR.DATECMD) = '{dateTimePicker2.Value.Month}'  and year(COMMANDEFOUR.DATECMD) = '{dateTimePicker2.Value.Year}' ";
                    }

                }
                LoadDataCmd(Query + " ORDER BY COMMANDEFOUR.DATECMD ASC ;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
            Search_Cmd(Search.Text);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}


