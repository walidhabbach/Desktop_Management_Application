using DocumentFormat.OpenXml.Vml;
using Store_Management_System.Class;
using Store_Management_System.User_Control.Save;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Web.ModelBinding;
using System.Windows.Forms;
 
namespace Store_Management_System.User_Control.Fournisseur.List
{
    public partial class List_CHQ_AllFour : UserControl
    {

        public List_CHQ_AllFour()
        {
            InitializeComponent();
        }

        private void DisplaytTotal(int temp , double Total)
        {

            this.DataGridView.Rows.Add(

                       $"Total CHQ de " + DateTimeFormatInfo.CurrentInfo.GetMonthName(temp) + " = ",
                        "",
                        "",
                        "",
                       Total + " DH"

               );
            DataGridView.Rows[DataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

        }
        private void ListCHQ_Search(String Query, String QueryCount)
        {
            try
            {
                this.DataGridView.Rows.Clear();

                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    SqlCommand Cmd = new SqlCommand(Query, Conx);
                    SqlCommand CmdCount = new SqlCommand(QueryCount, Conx);

                    int i = 0;
                    double Total = 0;
                    int temp = 0;
                    int Number = 0;

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();
                    SqlDataReader Count = CmdCount.ExecuteReader();


                    // DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DataGridView.Columns["ID_CHQ_FOUR"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 15, FontStyle.Bold);
                    DataGridView.Columns["Fournisseur"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 16, FontStyle.Bold);
                    DataGridView.Columns["MONTANT"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 15, FontStyle.Bold);

                    while (Count.Read())
                    {
                        Number = int.Parse(Count[0].ToString());
                    }

                   
                    if (Read.HasRows)
                    {

                        while (Read.Read())
                        {
                            if (temp == 0)
                            {
                                temp = int.Parse(Read[0].ToString());
                            }

                            if (temp == int.Parse(Read[0].ToString()))
                            {

                                this.DataGridView.Rows.Add(
                                           Convert.ToDateTime(Read[1]).ToString("dd / MM / yyyy"),
                                           Read[2],
                                           Read[3] ,
                                             Convert.ToDateTime(Read[4]).ToString("dd / MM / yyyy"),
                                           Math.Round(double.Parse(Read["MONTANT"].ToString()), 2) + " DH"

                                   );
                                Total += Math.Round(double.Parse(Read["MONTANT"].ToString()), 2);
                            }
                            else
                            {
                                DisplaytTotal(temp, Total);
                                Total = 0;
                                temp = int.Parse(Read[0].ToString());
                                this.DataGridView.Rows.Add(
                                              Convert.ToDateTime(Read[1]).ToString("dd / MM / yyyy"),
                                              Read[2],
                                               Read[3]  ,
                                                Convert.ToDateTime(Read[4]).ToString("dd / MM / yyyy"),
                                              Math.Round(double.Parse(Read["MONTANT"].ToString()), 2) + " DH"

                                      );
                                Total += Math.Round(double.Parse(Read["MONTANT"].ToString()), 2);
                            }
                            i++;
                            if (Number == i)
                            {
                                temp = int.Parse(Read[0].ToString());
                                DisplaytTotal(temp, Total);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void List_CHQ_AllFour_Load(object sender, EventArgs e)
        {
            CustomDateFormat();

            comboBox1.Text = "Tous";
            Search_CHQ(comboBox1.Text);
            FillCombobox();
            comboBox2.Visible = false;
        }

        private int SearshFournisseur(string Four)
        {

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                String Query = "SELECT IDFOUR From FOURNISSEUR WHERE ENTREPRISE = @Four;";
                SqlCommand Cmd = new SqlCommand(Query, Conx);
                Cmd.Parameters.AddWithValue("Four", Four);
                Conx.Open();
                SqlDataReader ReadFour = Cmd.ExecuteReader();


                // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);

                if (ReadFour.HasRows)
                {
                    while (ReadFour.Read())
                    {
                        return int.Parse(ReadFour["IDFOUR"].ToString());
                    }
                    Conx.Close();
                }
                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");
                }
            }
            return 0;

        }
        private void Search_CHQ(string search)
        {

            String Count;

            try
            {
                if (comboBox1.Text == "Tous")
                {
                    Count = $"Select count(*) FROM CHEQUEFOURNISSEUR WHERE Year(CHEQUEFOURNISSEUR.DATEDONNER) = '{int.Parse(dateTimePicker2.Value.Year.ToString())}';";
                    ListCHQ_Search($"EXECUTE CHEQUE_FOURNISSEUR_All '{dateTimePicker2.Value.Year}';", Count);

                }
                else if (comboBox1.Text == "Date Redaction" || comboBox1.Text == "Date Encaissement")
                {

                    if (comboBox1.Text == "Date Redaction")
                    {
                        this.DataGridView.Rows.Clear();
                        this.DataGridView.Columns["DATEDONNEE"].HeaderCell.Style.BackColor = System.Drawing.Color.Green;
                        Count = $"Select count(*) FROM CHEQUEFOURNISSEUR where month(CHEQUEFOURNISSEUR.DATEDONNER) = '{int.Parse(dateTimePicker2.Value.Month.ToString())}' and year(CHEQUEFOURNISSEUR.DATEDONNER) = '{dateTimePicker2.Value.Year}';";
                        ListCHQ_Search($"EXEC CHEQUE_FOURNISSEUR_Redaction '{int.Parse(dateTimePicker2.Value.Month.ToString())}','{dateTimePicker2.Value.Year}' ;", Count);
                    }
                    else if (comboBox1.Text == "Date Encaissement")
                    {
                        this.DataGridView.Columns["DATEPAYER"].HeaderCell.Style.BackColor = System.Drawing.Color.Green;
                        Count = $"Select count(*) FROM CHEQUEFOURNISSEUR where month(CHEQUEFOURNISSEUR.DATEPAYER) = '{int.Parse(dateTimePicker2.Value.Month.ToString())}' and year(CHEQUEFOURNISSEUR.DATEPAYER) = '{dateTimePicker2.Value.Year}';";
                        ListCHQ_Search($"EXEC CHEQUE_FOURNISSEUR_Encaissement '{int.Parse(dateTimePicker2.Value.Month.ToString())}','{dateTimePicker2.Value.Year}';", Count);
                    }
                }
                else if (comboBox1.Text == "Fournisseur")
                {
                    this.DataGridView.Columns["Fournisseur"].HeaderCell.Style.BackColor = System.Drawing.Color.Green;
                    comboBox2.Visible = true;
                    int id = SearshFournisseur(comboBox2.Text);
                    if (id != 0)
                    {

                        Count = $"Select count(*) FROM CHEQUEFOURNISSEUR WHERE IDFOUR ='{id}' and Year(CHEQUEFOURNISSEUR.DATEDONNER) ='{int.Parse(dateTimePicker2.Value.Year.ToString())}' ;";
                        ListCHQ_Search($"EXEC CHEQUE_FOURNISSEUR_FOURNISSEUR '{id}' , '{int.Parse(dateTimePicker2.Value.Year.ToString())}' ;", Count);

                    }
                    else
                    {
                        MessageBox.Show(" Selecter le Fournisseur ");
                        comboBox2.Visible = true;
                        dateTimePicker2.Visible = false;
                    }
                }

                else if (search != string.Empty)
                {

                    if (comboBox1.Text == "N°CHQ")
                    {

                        this.DataGridView.Columns["ID_CHQ_FOUR"].HeaderCell.Style.BackColor = System.Drawing.Color.Green;
                        Count = $"Select count(*) FROM CHEQUEFOURNISSEUR WHERE N_CHQ = '{Search.Text}';";
                        ListCHQ_Search($"EXEC CHEQUE_FOURNISSEUR_NCHQ  '{Search.Text}'; ", Count);

                    }
                    return;

                }
                else if (search == String.Empty && comboBox1.Text != "Date Redaction" && comboBox1.Text != "Date Encaissement")
                {
                    comboBox2.Text = "";

                    MessageBox.Show("Remplir la barre de recherche !!!");
                    Search.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Console.WriteLine("valider");
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search_CHQ(comboBox1.Text);
        }


        private void FillCombobox()
        {
            comboBox2.Items.Clear();

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                String Query = "SELECT * From FOURNISSEUR;";
                SqlCommand Cmd = new SqlCommand(Query, Conx);

                Conx.Open();
                SqlDataReader ReadFour = Cmd.ExecuteReader();


                // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);

                if (ReadFour.HasRows)
                {

                    while (ReadFour.Read())
                    {
                        comboBox2.Items.Add(ReadFour["ENTREPRISE"].ToString());
                    }
                    Conx.Close();

                }
                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");
                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DataGridView.Columns["DATEPAYER"].HeaderCell.Style.BackColor == System.Drawing.Color.Green)
            {

                this.DataGridView.Columns["DATEPAYER"].HeaderCell.Style.BackColor = System.Drawing.Color.White;
            }
            else if (this.DataGridView.Columns["DATEDONNEE"].HeaderCell.Style.BackColor == System.Drawing.Color.Green)
            {

                this.DataGridView.Columns["DATEDONNEE"].HeaderCell.Style.BackColor = System.Drawing.Color.White;

            }
            else if (this.DataGridView.Columns["ID_CHQ_FOUR"].HeaderCell.Style.BackColor == System.Drawing.Color.Green)
            {

                this.DataGridView.Columns["ID_CHQ_FOUR"].HeaderCell.Style.BackColor = System.Drawing.Color.White;

            }
            else if (this.DataGridView.Columns["Fournisseur"].HeaderCell.Style.BackColor == System.Drawing.Color.Green)
            {

                this.DataGridView.Columns["Fournisseur"].HeaderCell.Style.BackColor = System.Drawing.Color.Green;

            }

            if (comboBox1.Text == "Fournisseur")
            {
                this.DataGridView.Columns["Fournisseur"].HeaderCell.Style.BackColor = System.Drawing.Color.Green;
                comboBox2.Visible = true;
                label1.Visible=true;
                FillCombobox();
                dateTimePicker2.Visible = false;
            }
            else if (comboBox1.Text == "Date Redaction" || comboBox1.Text == "Date Encaissement")
            {

                dateTimePicker2.Visible = true;
                Search.Text = "";
                Search_CHQ("");
                comboBox2.Visible = false;
                label1.Visible = false;

            }
            else
            {
                if (comboBox1.Text == "N°CHQ")
                {
                    this.DataGridView.Columns["ID_CHQ_FOUR"].HeaderCell.Style.BackColor = System.Drawing.Color.Green;
                }
                Search_CHQ(Search.Text);
                dateTimePicker2.Visible = true;
                comboBox2.Visible = false;
                label1.Visible = false;

            }
        }

        private void CustomDateFormat()
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MMMM yyyy";
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker2.Visible = true;
            if (comboBox1.Text == "Date Redaction" || comboBox1.Text == "Date Encaissement")
            {
                Search.Text = "";
                Search_CHQ("");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DataGridView.Rows.Count > 0)
            {
                PrintPdfXlsx.Xlsx(DataGridView);
            } 
        }
 
        private void button3_Click(object sender, EventArgs e)
        { 
            if (DataGridView.Rows.Count > 0)
            {
                PrintPdfXlsx.Pdf(DataGridView);
            }   
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
