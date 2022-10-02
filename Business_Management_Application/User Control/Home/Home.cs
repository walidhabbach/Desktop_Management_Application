using Store_Management_System.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Home
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            DateNow.Text = DateTime.Now.ToString("dd MMMM yyyy");
            ListCHQ();
        }
        private void ListCHQ()
        {
            try
            {
                this.DataGridView.Rows.Clear();

                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    
                    SqlCommand Cmd = new SqlCommand($"EXECUTE CHEQUE_FOURNISSEUR_DateNow @day, @month, @year ;", Conx);
                    SqlCommand CmdCount = new SqlCommand("SELECT count(*) FROM CHEQUEFOURNISSEUR WHERE day(DATEPAYER)= @day and month(DATEPAYER)= @month and year(DATEPAYER)= @year; ", Conx);

                    Cmd.Parameters.AddWithValue("day", Convert.ToDateTime(DateNow.Text).Day);
                    Cmd.Parameters.AddWithValue("month", Convert.ToDateTime(DateNow.Text).Month);
                    Cmd.Parameters.AddWithValue("year", Convert.ToDateTime(DateNow.Text).Year);

                    CmdCount.Parameters.AddWithValue("day", Convert.ToDateTime(DateNow.Text).Day);
                    CmdCount.Parameters.AddWithValue("month", Convert.ToDateTime(DateNow.Text).Month);
                    CmdCount.Parameters.AddWithValue("year", Convert.ToDateTime(DateNow.Text).Year);

                    int i = 0;
                    double Total = 0;
                    int temp = 0;
                    int Number = 0;

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();
                    SqlDataReader Count = CmdCount.ExecuteReader();


                    // DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


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
                                           Convert.ToDateTime(Read[1]).ToString("dd MMMM yyyy"),
                                           Read[2],
                                           Read[3],
                                             Convert.ToDateTime(Read[4]).ToString("dd MMMM yyyy"),
                                           Math.Round(double.Parse(Read["MONTANT"].ToString()), 2) + " DH"

                                   );
                                Total += Math.Round(double.Parse(Read["MONTANT"].ToString()), 2);
                            }
                            else
                            {

                                this.DataGridView.Rows.Add(

                                           "la somme des Chèques d'aujourd'hui ",
                                            "",
                                            "",
                                            "",
                                           Total + " DH"

                                   );
                                DataGridView.Rows[DataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                                Total = 0;
                                temp = int.Parse(Read[0].ToString());
                                this.DataGridView.Rows.Add(
                                              Convert.ToDateTime(Read[1]).ToString("dd MMMM yyyy"),
                                              Read[2],
                                              Read[3],
                                                Convert.ToDateTime(Read[4]).ToString("dd MMMM yyyy"),
                                              Math.Round(double.Parse(Read["MONTANT"].ToString()), 2) + " DH"

                                      );
                                Total += Math.Round(double.Parse(Read["MONTANT"].ToString()), 2);
                            }
                            i++;
                            if (Number == i)
                            {
                                temp = int.Parse(Read[0].ToString());
                                this.DataGridView.Rows.Add(
                                             "la somme des Chèques d'aujourd'hui = ",
                                            "",
                                            "",
                                            "",
                                         Total + " DH"

                                 ); DataGridView.Rows[DataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                            }


                        }
                        Conx.Close();



                    }
                    else
                    {
                        MessageBox.Show(" No check to pay today !!!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
