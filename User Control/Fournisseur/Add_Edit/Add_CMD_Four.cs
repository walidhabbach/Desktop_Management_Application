using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.A_M_D
{
    public partial class Add_CMD_Four : Form
    {

        public int IDFOUR;
        public Add_CMD_Four(int ID)
        {
            InitializeComponent();
            IDFOUR = ID;
        }
        public void CheckBox()
        {
            //DataGridViewCheckBoxColumn Cb = new DataGridViewCheckBoxColumn();
            //DataGridView.Columns.Insert(0, Cb);
        }
        public void Data_Produit()
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
                        this.dataGridView1.Rows.Add(false,ReadProduit[0], ReadProduit[2], String.Format("{0:0.##}", ReadProduit[3]), String.Format("{0:0.##}", ReadProduit[4]), String.Format("{0:0.##}", ReadProduit[5]));                    
                    }

                    dataGridView1.Columns["SELECTER"].Width = 50;
                    
                    dataGridView1.Columns["IDPRODUIT"].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
                    dataGridView1.Columns["PRIXACHAT"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                    dataGridView1.Columns["PRIXVENTE"].DefaultCellStyle.Font = new Font("Tahoma", 12);
                    dataGridView1.Columns["DPRIXVENTE"].DefaultCellStyle.Font = new Font("Tahoma", 12 );
                    dataGridView1.Columns["DESIGNATION"].DefaultCellStyle.Font = new Font("Tahoma", 12 );
                }
                else
                {
                    MessageBox.Show("La Table Produit est vide !!!");
                }
                      
                   
            }
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Data_Produit();
        }

        
    }
}
