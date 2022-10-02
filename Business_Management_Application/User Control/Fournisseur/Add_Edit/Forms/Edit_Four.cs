using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Store_Management_System.User_Control.Fournisseur.ListALL;

namespace Store_Management_System.User_Control.Fournisseur.A_M_D
{
    public partial class Edit_Four : Form
    {
        private readonly int ID;
        Panel MainPanel_Four;
        Panel PanelFourList;
        public Edit_Four(int IDFOUR, Panel MainPanel_Four,Panel PanelFourListe)
        {
            InitializeComponent();
            ID = IDFOUR;
            this.MainPanel_Four = MainPanel_Four;
            this.PanelFourList = PanelFourListe;

        }
        public void Display(int IDFOUR)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        private void Edit_Four_Load(object sender, EventArgs e)
        {
            Display(ID);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    if (ENTREPRISE.Text != "" && TELEPHONE.Text != "" && comboBox1.Text != "" && ADRESSE.Text != "")
                    {
                        if (Add_Four.CheckFour(ID, ENTREPRISE.Text))
                        {
                            MessageBox.Show("Ce Nom d'Entreprise Existe deja dans la base de donne");
                            ENTREPRISE.Focus();
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
                               
                                ListFour LFour = new ListFour(MainPanel_Four, PanelFourList);
                                MainClass.ShowControl(LFour, PanelFourList);

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
