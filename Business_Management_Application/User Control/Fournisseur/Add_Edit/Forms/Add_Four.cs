using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Store_Management_System.User_Control.Fournisseur.ListALL;

namespace Store_Management_System.User_Control.Fournisseur.A_M_D
{
    public partial class Add_Four : Form
    {  
        Panel MainPanel_Four;
        Panel PanelFourListe;
        public Add_Four(Panel MainPanel_Four, Panel PanelFourListe)
        {
            InitializeComponent();
            this.MainPanel_Four = MainPanel_Four;
            this.PanelFourListe = PanelFourListe;
        }
        private void Clear()
        {
            ENTREPRISE.Text = "";
            TELEPHONE.Text = "";
            ADRESSE.Text = "";
            comboBox1.Text = "";
        }
        public static bool CheckFour(int ID, string NomFour)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    Conx.Open();
                    String Query = "SELECT * FROM FOURNISSEUR;";
                    SqlCommand Cmd = new SqlCommand(Query, Conx);
                    SqlDataReader RFour = Cmd.ExecuteReader();
                    while (RFour.Read())
                    {
                        if (RFour["ENTREPRISE"].ToString().ToLower() == NomFour.ToLower() && ID != int.Parse(RFour["IDFOUR"].ToString()))
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
                    if (ENTREPRISE.Text != "" && TELEPHONE.Text != "" && comboBox1.Text != "" && ADRESSE.Text != "")
                    {
                        if (CheckFour(0, ENTREPRISE.Text))
                        {
                            MessageBox.Show("Ce Nom d'Entreprise Existe deja dans la base de donne");
                            ENTREPRISE.Text = String.Empty;
                            ENTREPRISE.Focus();
                        }
                        else
                        {
                            Conx.Open();
                            string Query = "INSERT into FOURNISSEUR(ENTREPRISE,TELEPHONE,CATEGORIE,ADRESSE) values(@ENTREPRISE,@TELEPHONE,@CATEGORIE,@ADRESSE)";
                            SqlCommand Cmd = new SqlCommand(Query, Conx);
                            try
                            {
                                Cmd.Parameters.AddWithValue("ENTREPRISE", ENTREPRISE.Text);
                                Cmd.Parameters.AddWithValue("TELEPHONE", TELEPHONE.Text);
                                Cmd.Parameters.AddWithValue("CATEGORIE", comboBox1.Text);
                                Cmd.Parameters.AddWithValue("ADRESSE", ADRESSE.Text);
                                Cmd.ExecuteNonQuery();

                                ListFour LFour = new ListFour(MainPanel_Four,PanelFourListe);
                                MainClass.ShowControl(LFour, PanelFourListe);


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ENTREPRISE_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
