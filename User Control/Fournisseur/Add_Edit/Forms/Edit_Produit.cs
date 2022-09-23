using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.ListALL;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms
{
    public partial class Edit_Produit : Form
    {
        private readonly int IDPROD;
        private readonly int IDFOUR;
        private readonly string NOMFOUR;
        private Panel panel;
        public Edit_Produit(int id, int FOUR,Panel panel)
        {
            InitializeComponent();
            this.IDPROD = id;
            this.IDFOUR = FOUR;
            this.NOMFOUR = MainFournisseur.ENTREPRISE;
            this.panel = panel; 
        }

        private void Edit_Produit_Load(object sender, EventArgs e)
        {
            textBox1.Text = NOMFOUR;
            Display();
        }
        public void Display()
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    Conx.ConnectionString = MainClass.ConnectionDataBase();
                    String Query = $"SELECT * FROM PRODUIT WHERE ID_PRODUIT = '{IDPROD}';";
                    SqlCommand Cmd = new SqlCommand(Query, Conx);

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();
                    if (Read.HasRows)
                    {
                        while (Read.Read())
                        {
                            IDPRODUIT.Text = Read["IDPRODUIT"].ToString();
                            DESIGNATION.Text = Read["DESIGNATION"].ToString();
                            PRIXACHAT.Text = Read["PRIXACHAT"].ToString();
                            PRIXVENTE.Text = Read["PRIXVENTE"].ToString();
                            DPRIXVENTE.Text = Read["DPRIXVENTE"].ToString();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private  bool CheckIdProduit(int id, string id_Produit)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    Conx.Open();
                    SqlCommand Cmd = new SqlCommand($"SELECT * FROM PRODUIT WHERE IDFOUR = '{IDFOUR}';", Conx);
                    SqlDataReader RFour = Cmd.ExecuteReader();
                    while (RFour.Read())
                    {
                        if (RFour["IDPRODUIT"].ToString().ToLower() == id_Produit.ToLower() && id != int.Parse(RFour["ID_PRODUIT"].ToString()))
                        {
                            return true;
                        }
                    }
                    return false;
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return false;
            }
      

        }
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    if (IDPRODUIT.Text != "" && DESIGNATION.Text != "" && PRIXACHAT.Text != "")
                    {
                        if (CheckIdProduit(IDPROD,IDPRODUIT.Text))
                        {
                            MessageBox.Show("ID produit Existe deja dans la base de donne");
                            IDPRODUIT.Focus();
                        }
                        else
                        {
                            Conx.Open();
                            string Query = $"UPDATE PRODUIT SET IDPRODUIT = @IDPRODUIT,DESIGNATION = @DESIGNATION,PRIXACHAT = @PRIXACHAT,PRIXVENTE = @PRIXVENTE,DPRIXVENTE = @DPRIXVENTE WHERE ID_PRODUIT = '{IDPROD}';";
                            SqlCommand Cmd = new SqlCommand(Query, Conx);
                            try
                            {
                                Cmd.Parameters.AddWithValue("IDPRODUIT", IDPRODUIT.Text);
                                Cmd.Parameters.AddWithValue("DESIGNATION", DESIGNATION.Text);
                                Cmd.Parameters.AddWithValue("PRIXACHAT", double.Parse(PRIXACHAT.Text));
                                Cmd.Parameters.AddWithValue("PRIXVENTE", double.Parse(PRIXVENTE.Text));
                                Cmd.Parameters.AddWithValue("DPRIXVENTE", double.Parse(PRIXVENTE.Text));
                                Cmd.ExecuteNonQuery();

                                List_Main_Four ListProduit = new List_Main_Four(IDFOUR, panel, 2);
                                MainClass.ShowControl(ListProduit, panel);

                                this.Close();

                                Conx.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
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
