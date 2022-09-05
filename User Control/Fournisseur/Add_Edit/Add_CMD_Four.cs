using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.A_M_D
{
    public partial class Add_CMD_Four : Form
    {

        private readonly int IDFOUR;
        private readonly string ENTREPRISE;
        public Add_CMD_Four(int ID, string NFour)
        {
            InitializeComponent();
            IDFOUR = ID;
            ENTREPRISE = NFour;
        }
        public void CheckBox()
        {
            //DataGridViewCheckBoxColumn Cb = new DataGridViewCheckBoxColumn();
            //DataGridView.Columns.Insert(0, Cb);
        }
        private void Data_Produit()
        {

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                SqlCommand Cmd = new SqlCommand($"SELECT * From PRODUIT WHERE IDFOUR = @IDFOUR;", Conx);
                Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                Conx.Open();
                SqlDataReader ReadProduit = Cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                dataGridView1.AllowUserToAddRows = true;
                if (ReadProduit.HasRows)
                {
                    //Button Delete, Edit
                    MainClass.Button_DGV(dataGridView1, "Edit", "edit");
                    dataGridView1.Columns["Edit"].Width = 50;
                    MainClass.Button_DGV(dataGridView1, "Delete", "delete");
                    dataGridView1.Columns["Delete"].Width = 50;

                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ///dataGridView1.AllowUserToAddRows = true;
                    MainClass.DataGridMod(this.dataGridView1);
                    while (ReadProduit.Read())
                    {
                        this.dataGridView1.Rows.Add(false, ReadProduit[0], ReadProduit[2], String.Format("{0:0.##}", ReadProduit[3]), String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5]));
                    }

                    dataGridView1.Columns["SELECTER"].Width = 40;
                    dataGridView1.Columns[2].Width = 150;

                    dataGridView1.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
                    dataGridView1.Columns["PRIXACHAT"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                    dataGridView1.Columns["PRIXVENTE"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                    dataGridView1.Columns["DPRIXVENTE"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                    dataGridView1.Columns["DESIGNATION"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                }
                else
                {
                    MessageBox.Show("La Table Produit est vide !!!");
                }


            }
        }

        private void Search_Produit(string Search)
        {
            if (Search != "")
            {
                Search.ToCharArray();
                dataGridView1.Rows.Clear();
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    SqlCommand Cmd = new SqlCommand("SELECT * From PRODUIT WHERE IDFOUR = @IDFOUR and DESIGNATION LIKE  '@Search%' ; ", Conx);
                    Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                    Cmd.Parameters.AddWithValue("Search", Search[0]);
                    Conx.Open();
                    SqlDataReader ReadProduit = Cmd.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    dataGridView1.AllowUserToAddRows = true;
                    if (ReadProduit.HasRows)
                    {
                        //Button Delete, Edit
                        MainClass.Button_DGV(dataGridView1, "Edit", "edit");
                        dataGridView1.Columns["Edit"].Width = 50;
                        MainClass.Button_DGV(dataGridView1, "Delete", "delete");
                        dataGridView1.Columns["Delete"].Width = 50;

                        //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        ///dataGridView1.AllowUserToAddRows = true;
                        MainClass.DataGridMod(this.dataGridView1);
                        while (ReadProduit.Read())
                        {
                            this.dataGridView1.Rows.Add(false, ReadProduit[0], ReadProduit[2], String.Format("{0:0.##}", ReadProduit[3]), String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5]));
                        }

                        dataGridView1.Columns["SELECTER"].Width = 40;
                        dataGridView1.Columns[2].Width = 150;

                        dataGridView1.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
                        dataGridView1.Columns["PRIXACHAT"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                        dataGridView1.Columns["PRIXVENTE"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                        dataGridView1.Columns["DPRIXVENTE"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                        dataGridView1.Columns["DESIGNATION"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        MessageBox.Show("La Table Produit est vide !!!");
                    }


                }
            }

        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Search_Produit(Search.Text);
        }
        public void Clear()
        {
            Description.Text = "";
            comboBox.Text = "";
            MONTANTTOTAL.Text = "";
            comboBox.Text = "";
        }
        private void Add_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                if (Description.Text != "" && comboBox.Text != "" && MONTANTTOTAL.Text != "")
                {
                    Conx.Open();
                    string Query = "INSERT INTO COMMANDEFOUR(IDFOUR,DESCRIPTION,STATUT,DATECMD,PESPECE,PCHEQUE,MONTANTTOTAL,MTRESTE,MTAVANCE) values(@IDFOUR,@DESCRIPTION,@STATUT,@DATECMD,@PESPECE,@PCHEQUE,@MONTANTTOTAL,@MTRESTE,@MTAVANCE)";
                    SqlCommand Cmd = new SqlCommand(Query, Conx);
                    try
                    {
                        if (comboBox.Text == "payee")
                        {
                            Cmd.Parameters.AddWithValue("STATUT", true);
                        }
                        else
                        {
                            Cmd.Parameters.AddWithValue("STATUT", false);
                        }
                        Cmd.Parameters.AddWithValue("IDFOUR", IDFOUR);
                        Cmd.Parameters.AddWithValue("DESCRIPTION", Description.Text);
                        Cmd.Parameters.AddWithValue("DATECMD", dateTimePicker2.Text);
                        Cmd.Parameters.AddWithValue("PESPECE", radioButton1);
                        Cmd.Parameters.AddWithValue("PCHEQUE", radioButton);
                        Cmd.Parameters.AddWithValue("MONTANTTOTAL", MONTANTTOTAL.Text);
                        Cmd.Parameters.AddWithValue("MTRESTE", null);
                        Cmd.Parameters.AddWithValue("MTAVANCE", null);
                        Cmd.ExecuteNonQuery();

                        this.Close();
                        Clear();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Produit Form = new Add_Produit(IDFOUR);
            Form.Show();
        }



        private void Add_CMD_Four_Load(object sender, EventArgs e)
        {
            Data_Produit();
            label1.Text = ENTREPRISE;
        }

        
    }
}

