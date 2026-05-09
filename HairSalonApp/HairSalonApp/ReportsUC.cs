using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ClosedXML.Excel;
using System.IO;

namespace HairSalonApp
{
    public partial class ReportsUC : UserControl
    {
        private void ExportToExcel(DataGridView dgv, string fileName)
        {
            using (var workbook = new XLWorkbook())
            {
                // Δημιουργία ενός WorkSheet με το όνομα της αναφοράς
                var worksheet = workbook.Worksheets.Add("Αναφορά");

                // 1. Τίτλοι Στηλών (Headers)
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dgv.Columns[i].HeaderText;
                    worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // 2. Δεδομένα
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // 3. Αυτόματο ταίριασμα στηλών (για να μην κρύβονται τα γράμματα)
                worksheet.Columns().AdjustToContents();

                // 4. Αποθήκευση με παράθυρο επιλογής
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Workbook|*.xlsx";
                    sfd.FileName = fileName;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Η εξαγωγή ολοκληρώθηκε με επιτυχία!", "Excel Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public ReportsUC()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Απλό μήνυμα για να δούμε ότι δουλεύει!
            MessageBox.Show("Δεδομένα ανανεώθηκαν!", "Επιτυχία");
        }

        private void ReportsUC_Load(object sender, EventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Ελέγχουμε ποια καρτέλα είναι επιλεγμένη στο TabControl
            DataGridView targetGrid;
            string reportName;

            switch (tabControl1.SelectedIndex)
            {
                case 0: targetGrid = dgvAppointmentsByDate; reportName = "Rantevou_Ana_Hmeromhnia"; break;
                case 1: targetGrid = dgvEmployeeAppointments; reportName = "Rantevou_Ana_Ypallhlo"; break;
                case 2: targetGrid = dgvRevenueService; reportName = "Esoda_Ana_Yphresia"; break;
                case 3: targetGrid = dgvServiceUsage; reportName = "Xrhsh_Yphresiwn"; break;
                default: return;
            }

            if (targetGrid.Rows.Count > 0)
            {
                ExportToExcel(targetGrid, reportName);
            }
            else
            {
                MessageBox.Show("Δεν υπάρχουν δεδομένα για εξαγωγή στον πίνακα!", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
