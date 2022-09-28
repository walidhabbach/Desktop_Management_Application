using ClosedXML.Excel;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Save
{
    internal class PrintPdfXlsx
    {


        public static void Xlsx(DataGridView DataGridView)
        {

            try
            {

                DataTable Dt = new DataTable();
                foreach (DataGridViewColumn col in DataGridView.Columns)
                {
                    Dt.Columns.Add(col.Name);
                }

                foreach (DataGridViewRow row in DataGridView.Rows)
                {
                    DataRow dRow = Dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    Dt.Rows.Add(dRow);
                }

                
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            if (sfd.FileName != null)
                            {
                                try
                                {
                                    using (XLWorkbook workbook = new XLWorkbook())
                                    {
                                        workbook.Worksheets.Add(Dt, "Cheques");
                                        workbook.SaveAs(sfd.FileName);
                                    }
                                    MessageBox.Show("You have succesfully expoted your data to an excel file.,", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void Pdf(DataGridView DataGridView)
        {
            if (DataGridView.Rows.Count > 0)
            {
                try
                {
                    DGVPrinter printer = new DGVPrinter();

                    printer.Title = "Liste des Chéques ";
                    printer.SubTitle = String.Format("Date : {0}", DateTime.Now.Date.ToString("dd MMMM yyyy"));
                    printer.TitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Ameublement El Yasmine";
                    printer.FooterColor = System.Drawing.Color.LightGray;
                    printer.SubTitleSpacing = 15;
                    printer.FooterSpacing = 15;
                    printer.SubTitleColor = System.Drawing.Color.Gray;

                    printer.printDocument.DefaultPageSettings.Landscape = true;
                    //printer.PrintDataGridView(DataGridView);
                    printer.PrintPreviewDataGridView(DataGridView); 
               

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

    }
}
