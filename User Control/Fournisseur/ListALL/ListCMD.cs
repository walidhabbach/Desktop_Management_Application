using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.ListALL
{
    public partial class ListCMD : UserControl
    {
        private readonly int IDFOUR;
        public ListCMD(int ID)
        {
            InitializeComponent();
            IDFOUR = ID;
        }

        private void ListCMD_Load(object sender, EventArgs e)
        {
            List_Cmd_Four(IDFOUR);
        }
        private void List_Cmd_Four(int IDFOUR)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                string Statut = "non payée";
                string MPaiement = "PESPECE";
                String QueryCmdFour = "SELECT * From COMMANDEFOUR WHERE IDFOUR = @IDFOUR;";

                SqlCommand CmdFour = new SqlCommand(QueryCmdFour, Conx);
                CmdFour.Parameters.AddWithValue("IDFOUR", IDFOUR);

                Conx.Open();
                SqlDataReader ReadCmdFour = CmdFour.ExecuteReader();
                if (ReadCmdFour.HasRows)
                {
                    this.dataGridView2.Rows.Clear();
                    this.dataGridView2.Columns.Clear();
                    this.dataGridView2.ColumnCount = 5;
                    this.dataGridView2.Columns[0].Name = "DESCRIPTION";
                    this.dataGridView2.Columns[1].Name = "STATUT";
                    this.dataGridView2.Columns[2].Name = "DATECMD";
                    this.dataGridView2.Columns[3].Name = "Mode de Paiement";
                    this.dataGridView2.Columns[4].Name = "MONTANT TOTAL";


                    MainClass.DataGridMod(this.dataGridView2);

                    dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.Red;


                    //Button Delete, Edit
                    MainClass.Button_DGV(dataGridView2, "Edit", "edit");
                    dataGridView2.Columns["Edit"].Width = 50;
                    MainClass.Button_DGV(dataGridView2, "Delete", "delete");
                    dataGridView2.Columns["Delete"].Width = 50;

                    while (ReadCmdFour.Read())
                    {
                        if ((bool)ReadCmdFour["STATUT"])
                        {
                            Statut = "payée";
                            this.dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.Green;
                        }
                        if ((bool)ReadCmdFour["PCHEQUE"])
                        {
                            MPaiement = "CHEQUE";
                        }
                        this.dataGridView2.Rows.Add(
                            ReadCmdFour["DESCRIPTION"],
                            Statut,
                            string.Format("{0:0.##}",ReadCmdFour["DATECMD"].ToString()),
                            MPaiement,
                            ReadCmdFour["MONTANTTOTAL"]
                        );

                    };

                }

                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");

                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
