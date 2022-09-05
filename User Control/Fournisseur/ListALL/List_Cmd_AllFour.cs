using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.List
{
    public partial class List_Cmd_AllFour : UserControl
    {
        public List_Cmd_AllFour()
        {
            InitializeComponent();
        }

        private void List_Cmd_AllFour_Load(object sender, EventArgs e)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                string Statut = "non payée";
                String QueryCmdFour = "SELECT * From COMMANDEFOUR;";

                SqlCommand CmdFour = new SqlCommand(QueryCmdFour, Conx);
                SqlCommand CmdNomFour;


                Conx.Open();
                SqlDataReader ReadCmdFour = CmdFour.ExecuteReader();
                SqlDataReader ReadNomFour;
                if (ReadCmdFour.HasRows)
                {
                    this.DataGridView.Rows.Clear();

                    MainClass.DataGridMod(this.DataGridView);
                    DataGridView.Columns["ID_CMD_FOUR"].Width = 75;
                    DataGridView.Columns["ENTREPRISE"].Width = 150;
                    DataGridView.Columns["ENTREPRISE"].DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);
                    DataGridView.Columns["DESCRIPTION"].Width = 150;
                    DataGridView.Columns["STATUT"].Width = 150;
                    DataGridView.Columns["STATUT"].DefaultCellStyle.BackColor = Color.Red;
                    DataGridView.Columns["DATECMD"].Width = 150;
                    DataGridView.Columns["PESPECE"].Width = 100;
                    DataGridView.Columns["PCHEQUE"].Width = 100;
                    DataGridView.Columns["MONTANT_TOTAL"].Width = 150;
                    DataGridView.Columns["MTRESTE"].Width = 150;
                    DataGridView.Columns["MTAVANCE"].Width = 150;

                    //Button Delete, Edit
                    MainClass.Button_DGV(DataGridView, "Edit", "edit");
                    DataGridView.Columns["Edit"].Width = 50;
                    MainClass.Button_DGV(DataGridView, "Delete", "delete");
                    DataGridView.Columns["Delete"].Width = 50;

                    while (ReadCmdFour.Read())
                    {
                        CmdNomFour = new SqlCommand("SELECT ENTREPRISE FROM FOURNISSEUR WHERE IDFOUR = @IDFOUR;", Conx);
                        CmdNomFour.Parameters.AddWithValue("@IDFour", ReadCmdFour["IDFOUR"]);
                        ReadNomFour = CmdNomFour.ExecuteReader();

                        while (ReadNomFour.Read())
                        {
                            if ((bool)ReadCmdFour["STATUT"])
                            {
                                Statut = "payée";
                                DataGridView.Columns["STATUT"].DefaultCellStyle.BackColor = Color.Green;
                            }
                            this.DataGridView.Rows.Add(
                                ReadCmdFour["ID_CMD_FOUR"],
                                ReadCmdFour["IDFOUR"],
                                ReadNomFour["ENTREPRISE"],
                                ReadCmdFour["DESCRIPTION"],
                                Statut,
                                ReadCmdFour["DATECMD"],
                                ReadCmdFour["PESPECE"],
                                ReadCmdFour["PCHEQUE"],
                                ReadCmdFour["MONTANTTOTAL"],
                                ReadCmdFour["MTRESTE"],
                                ReadCmdFour["MTAVANCE"]

                            );

                        };

                    };
                    Conx.Close();
                }
                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");

                }
            }
        }

        private void Edit(int IDCMDFOUR)
        {
            Edit_CMD_Four Form = new Edit_CMD_Four(IDCMDFOUR);
            Form.Show();
        }
        private void Delete(int IDCMDFour)
        {
            //int position = this.DataGridView.CurrentRow.Index;
            //int IDFour = int.Parse(this.DataGridView.Rows[position].Cells[0].Value);

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                SqlCommand Cmd = new SqlCommand
                {
                    Connection = Conx,
                    CommandText = "DELETE FROM COMMANDEFOUR WHERE ID_CMD_FOUR = @IDCMDFour;"
                };

                try
                {
                    Cmd.Parameters.AddWithValue("@IDCMDFour", IDCMDFour);
                    Conx.Open();
                    Cmd.ExecuteNonQuery();
                    Conx.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int IDCMDFour;
            string NomFour;
            DialogResult Dialog;
            String ColName;
            DataGridViewRow Row;

            if (e.RowIndex >= 0)
            {
                ColName = this.DataGridView.Columns[e.ColumnIndex].Name;
                Row = DataGridView.Rows[e.RowIndex];
                Row.Selected = true;
                IDCMDFour = Convert.ToInt32(Row.Cells["ID_CMD_FOUR"].Value);
                NomFour = Row.Cells["ENTREPRISE"].Value.ToString();
                if (ColName == "Edit")
                {
                    Edit(IDCMDFour);
                }
                else if (ColName == "Delete")
                {

                    Dialog = MessageBox.Show("Do You Want To Delete " + NomFour, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Dialog == DialogResult.No)
                    {
                        return;
                    }
                    Delete(IDCMDFour);

                }
            }
        }

        private void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            String ColName = this.DataGridView.Columns[e.ColumnIndex].Name;

            if (ColName != "BtnEdit" && ColName != "BtnDelete")
            {
                DataGridView.Cursor = Cursors.Default;
            }
            else
            {
                DataGridView.Cursor = Cursors.Hand;
            }

        }
    }


}


