using System;
using Store_Management_System.Class;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Store_Management_System.User_Control.Fournisseur.A_M_D
{
    public partial class Add_Four : Form
    {
        public Add_Four()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            ENTREPRISE.Text = "";
            TELEPHONE.Text = "";
            ADRESSE.Text = "";
            comboBox1.Text = "";
        }
        public static bool CheckFour(string NomFour)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                Conx.Open();
                String Query = "SELECT * FROM FOURNISSEUR;";
                SqlCommand Cmd = new SqlCommand(Query , Conx);
                SqlDataReader RFour = Cmd.ExecuteReader();
                while (RFour.Read())
                {
                    if (RFour["ENTREPRISE"].ToString().ToLower() == NomFour.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
             using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
             {
                  if(ENTREPRISE.Text!="" && TELEPHONE.Text != "" && comboBox1.Text != "" && ADRESSE.Text != "")
                  {
                    if (CheckFour(ENTREPRISE.Text))
                    {
                        MessageBox.Show("Ce Nom d'Entreprise Existe deja dans la base de donne");
                        Clear();
                    }
                    else
                    {   Conx.Open();
                        string Query = "INSERT into FOURNISSEUR(ENTREPRISE,TELEPHONE,CATEGORIE,ADRESSE) values(@ENTREPRISE,@TELEPHONE,@CATEGORIE,@ADRESSE)";
                        SqlCommand Cmd = new SqlCommand(Query, Conx);
                        try
                        {
                            Cmd.Parameters.AddWithValue("ENTREPRISE", ENTREPRISE.Text);
                            Cmd.Parameters.AddWithValue("TELEPHONE", TELEPHONE.Text);
                            Cmd.Parameters.AddWithValue("CATEGORIE", comboBox1.Text);
                            Cmd.Parameters.AddWithValue("ADRESSE", ADRESSE.Text);
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

  
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
