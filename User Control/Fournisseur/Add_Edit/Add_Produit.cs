using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.A_M_D;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit
{
    public partial class Add_Produit : Form
    {
        private readonly int IDFOUR;
        private readonly string ENTREPRISE;
        public Add_Produit(int ID , string Four)
        {
            InitializeComponent();
            IDFOUR = ID;
            ENTREPRISE = Four;
        }


        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            DESIGNATION.Text = "";
            PRIXACHAT.Text = "";
            IDPRODUIT.Text = "";
            DPRIXVENTE.Text = "";
            PRIXVENTE.Text = "";
        }
        private void Add_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                if (IDPRODUIT.Text != "" && DESIGNATION.Text != "" && PRIXACHAT.Text != "" )
                {
                    if (CheckIdProduit(IDPRODUIT.Text , IDFOUR))
                    {
                        MessageBox.Show("ID produit Existe deja dans la base de donne");
                       
                    }
                    else
                    {
                        Conx.Open();
                        string Query = "INSERT into PRODUIT(IDPRODUIT,IDFOUR,DESIGNATION,PRIXACHAT,PRIXVENTE,DPRIXVENTE) values(@IDPRODUIT,@IDFOUR,@DESIGNATION,@PRIXACHAT,@PRIXVENTE,@DPRIXVENTE)";
                        SqlCommand Cmd = new SqlCommand(Query, Conx);
                        try
                        {
                            
                            Cmd.Parameters.AddWithValue("IDPRODUIT", IDPRODUIT.Text);
                            Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                            Cmd.Parameters.AddWithValue("DESIGNATION", DESIGNATION.Text);
                            Cmd.Parameters.AddWithValue("PRIXACHAT", PRIXACHAT.Text);
                            Cmd.Parameters.AddWithValue("PRIXVENTE", PRIXVENTE.Text);
                            Cmd.Parameters.AddWithValue("DPRIXVENTE", DPRIXVENTE.Text);
                            Cmd.ExecuteNonQuery();
                           
                            this.Close();
                            Clear();
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
      
        private bool CheckIdProduit(string ID  , int IDFour)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                Conx.Open();
                SqlCommand Cmd = new SqlCommand("SELECT * FROM PRODUIT;", Conx);
                SqlDataReader Read = Cmd.ExecuteReader();
                while (Read.Read())
                {
                    if (ID.ToLower() == Read["IDPRODUIT"].ToString().ToLower() && IDFour == int.Parse(Read["IDFOUR"].ToString()))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private void Add_Produit_Load(object sender, EventArgs e)
        {
            textBox1.Text =  ENTREPRISE;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
