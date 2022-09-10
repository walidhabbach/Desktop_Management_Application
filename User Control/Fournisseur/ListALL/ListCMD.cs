using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.A_M_D;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.ListALL
{
    public partial class ListCMD : UserControl
    {
        private readonly int IDFOUR;
        private  Panel Content;
        public ListCMD(int ID, Panel content)
        {
            InitializeComponent();
            IDFOUR = ID;
            Content = content;
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

                    this.dataGridView2.ColumnCount = 6;
                    this.dataGridView2.Columns[0].Name = "IDCMD";
                    this.dataGridView2.Columns[1].Name = "DESCRIPTION";
                    this.dataGridView2.Columns[2].Name = "STATUT";
                    this.dataGridView2.Columns[3].Name = "DATECMD";
                    this.dataGridView2.Columns[4].Name = "Mode de Paiement";
                    this.dataGridView2.Columns[5].Name = "MONTANT TOTAL";


                    MainClass.DataGridMod(this.dataGridView2);

                    dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.Red;


                    //Button Delete, Edit
                    MainClass.Button_DGV(dataGridView2, "Edit", "edit");
                    dataGridView2.Columns["Edit"].Width = 70;
                    MainClass.Button_DGV(dataGridView2, "Delete", "delete");
                    dataGridView2.Columns["Delete"].Width = 70;

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
                            ReadCmdFour["ID_CMD_FOUR"],
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


        private void Edit(int IDCMD)
        {
            Content.Controls.Clear();
            Edit_CMD_Four ECmd = new Edit_CMD_Four(IDCMD,IDFOUR);
            MainClass.ShowControl(ECmd, Content);
        }
        private void Delete(int IDCMD)
        {
            //int position = this.DataGridView.CurrentRow.Index;
            //int IDFour = int.Parse(this.DataGridView.Rows[position].Cells[0].Value);

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                SqlCommand Cmd = new SqlCommand
                {
                    Connection = Conx,
                    CommandText = "DELETE FROM COMMANDEFOUR WHERE ID_CMD_FOUR = @IDCMD;"
                };

                try
                {
                    Cmd.Parameters.AddWithValue("@IDCMD", IDCMD);
                    Conx.Open();
                    Cmd.ExecuteNonQuery();
                    Conx.Close();
                    List_Cmd_Four(IDFOUR);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                int IDCMD;
                DialogResult Dialog;
                String ColName;
                DataGridViewRow Row;

                Row = dataGridView2.Rows[e.RowIndex];
                Row.Selected = true;
                IDCMD = Convert.ToInt32(Row.Cells[0].Value.ToString());
                ColName = this.dataGridView2.Columns[e.ColumnIndex].Name;
                if (ColName == "Edit")
                {
                    Edit(IDCMD);
                }
                else if (ColName == "Delete")
                {

                     Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells[0].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Dialog == DialogResult.No)
                    {
                        return;
                    }
                    Delete(IDCMD);

                }
            }
        }



        private void dataGridView2_CellMouseEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string ColName = this.dataGridView2.Columns[e.ColumnIndex].Name;

                if (ColName != "BtnEdit" && ColName != "BtnDelete")
                {
                    dataGridView2.Cursor = Cursors.Default;
                }
                else
                {
                    dataGridView2.Cursor = Cursors.Hand;
                }
            }
        }

        private void dataGridView2_Move(object sender, EventArgs e)
        {

        }
    }
}
