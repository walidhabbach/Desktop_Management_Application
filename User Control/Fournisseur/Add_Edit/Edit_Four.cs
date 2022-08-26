using Store_Management_System.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.A_M_D
{
    public partial class Edit_Four : Form
    {
        private readonly int ID;
        public Edit_Four(int IDFOUR)
        {
            InitializeComponent();
            ID = IDFOUR;
        }
        public void Display(int IDFOUR)
        {

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                Conx.ConnectionString = MainClass.ConnectionDataBase();
                String Query = $"SELECT * FROM FOURNISSEUR WHERE IDFOUR = '{IDFOUR}';";
                SqlCommand Cmd = new SqlCommand(Query, Conx);

                Conx.Open();
                SqlDataReader ReadFour = Cmd.ExecuteReader();
                while (ReadFour.Read())
                {
                    ENTREPRISE.Text = ReadFour["ENTREPRISE"].ToString();
                    TELEPHONE.Text = ReadFour["TELEPHONE"].ToString();
                    comboBox1.Text = ReadFour["CATEGORIE"].ToString();
                    ADRESSE.Text = ReadFour["ADRESSE"].ToString();
                }
            }


        }

        
        private void Edit_Four_Load(object sender, EventArgs e )
        {
            Display(ID);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();         
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                if (ENTREPRISE.Text != "" && TELEPHONE.Text != "" && comboBox1.Text != "" && ADRESSE.Text != "")
                {
                    if (Add_Four.CheckFour(ENTREPRISE.Text))
                    {
                        MessageBox.Show("Ce Nom d'Entreprise Existe deja dans la base de donne");
                        Display(ID);
                        return;
                    }
                    else
                    {
                        Conx.Open();

                        string Query = "UPDATE FOURNISSEUR SET ENTREPRISE = @ENTREPRISE,TELEPHONE = @TELEPHONE,CATEGORIE = @CATEGORIE,ADRESSE = @ADRESSE WHERE IDFOUR = @IDFOUR;";
                        SqlCommand Cmd = new SqlCommand(Query, Conx);
                        try
                        {
                            Cmd.Parameters.AddWithValue("IDFOUR", ID);
                            Cmd.Parameters.AddWithValue("ENTREPRISE", ENTREPRISE.Text);
                            Cmd.Parameters.AddWithValue("TELEPHONE", TELEPHONE.Text);
                            Cmd.Parameters.AddWithValue("CATEGORIE", comboBox1.Text);
                            Cmd.Parameters.AddWithValue("ADRESSE", ADRESSE.Text);
                            Cmd.ExecuteNonQuery();


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

      
    }
}
