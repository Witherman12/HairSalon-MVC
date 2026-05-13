using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClosedXML.Excel;
using HairSalonApp.Services;
using HairSalonApp.Models;

namespace HairSalonApp
{
    public partial class ReportsUC : UserControl
    {
        private readonly ReportService _reportService = new ReportService();

        public ReportsUC()
        {
            InitializeComponent();

            // Ρύθμιση των Grid να γεμίζουν την οθόνη
            SetupGrids();
        }

        private void ReportsUC_Load(object sender, EventArgs e)
        {
            LoadAllReports();
        }

        private void SetupGrids()
        {
            // Κάνουμε όλα τα Grid να γεμίζουν το χώρο (Fill)
            dgvAppointmentsByDate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployeeAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevenueService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServiceUsage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadAllReports()
        {
            try
            {
                // 1. Ραντεβού ανά Ημερομηνία
                dgvAppointmentsByDate.DataSource = null;
                dgvAppointmentsByDate.DataSource = _reportService.GetAppointmentsByDate();
                if (dgvAppointmentsByDate.Columns["AppDate"] != null) dgvAppointmentsByDate.Columns["AppDate"].HeaderText = "Ημερομηνία";
                if (dgvAppointmentsByDate.Columns["TotalAppointments"] != null) dgvAppointmentsByDate.Columns["TotalAppointments"].HeaderText = "Πλήθος Ραντεβού";

                // 2. Ραντεβού ανά Υπάλληλο
                dgvEmployeeAppointments.DataSource = null;
                dgvEmployeeAppointments.DataSource = _reportService.GetAppointmentsByEmployee();
                if (dgvEmployeeAppointments.Columns["EmployeeName"] != null) dgvEmployeeAppointments.Columns["EmployeeName"].HeaderText = "Υπάλληλος";
                if (dgvEmployeeAppointments.Columns["TotalAppointments"] != null) dgvEmployeeAppointments.Columns["TotalAppointments"].HeaderText = "Σύνολο Ραντεβού";

                // 3. Έσοδα ανά Υπηρεσία
                dgvRevenueService.DataSource = null;
                dgvRevenueService.DataSource = _reportService.GetRevenueByService();
                if (dgvRevenueService.Columns["ServiceName"] != null) dgvRevenueService.Columns["ServiceName"].HeaderText = "Υπηρεσία";
                if (dgvRevenueService.Columns["CompletedAppointments"] != null) dgvRevenueService.Columns["CompletedAppointments"].HeaderText = "Ολοκληρωμένα";
                if (dgvRevenueService.Columns["Revenue"] != null) dgvRevenueService.Columns["Revenue"].HeaderText = "Έσοδα (€)";

                // 4. Χρήση Υπηρεσιών (Δημοφιλείς)
                dgvServiceUsage.DataSource = null;
                dgvServiceUsage.DataSource = _reportService.GetPopularServices();
                if (dgvServiceUsage.Columns["ServiceName"] != null) dgvServiceUsage.Columns["ServiceName"].HeaderText = "Υπηρεσία";
                if (dgvServiceUsage.Columns["TotalAppointments"] != null) dgvServiceUsage.Columns["TotalAppointments"].HeaderText = "Φορές που επιλέχθηκε";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά τη φόρτωση των αναφορών: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllReports();
            MessageBox.Show("Τα δεδομένα ανανεώθηκαν επιτυχώς!", "Ενημέρωση", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataGridView targetGrid;
            string reportName;

            // Επιλογή του σωστού Grid βάσει του Tab που βλέπει ο χρήστης
            switch (tabControl1.SelectedIndex)
            {
                case 0: targetGrid = dgvAppointmentsByDate; reportName = "Rantevou_Ana_Hmeromhnia"; break;
                case 1: targetGrid = dgvEmployeeAppointments; reportName = "Rantevou_Ana_Ypallhlo"; break;
                case 2: targetGrid = dgvRevenueService; reportName = "Esoda_Ana_Yphresia"; break;
                case 3: targetGrid = dgvServiceUsage; reportName = "Dhmofileis_Yphresies"; break;
                default: return;
            }

            if (targetGrid.Rows.Count > 0)
            {
                ExportToExcel(targetGrid, reportName);
            }
            else
            {
                MessageBox.Show("Δεν υπάρχουν δεδομένα στον πίνακα για εξαγωγή!", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportToExcel(DataGridView dgv, string fileName)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Report");

                    // Headers
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dgv.Columns[i].HeaderText;
                        worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                        worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightBlue;
                    }

                    // Data
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    worksheet.Columns().AdjustToContents();

                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "Excel Workbook|*.xlsx";
                        sfd.FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd");

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Η εξαγωγή ολοκληρώθηκε!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά την εξαγωγή: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Η λειτουργία εκτύπωσης θα είναι διαθέσιμη σύντομα μέσω PDF εξαγωγής.", "Πληροφορία");
        }

        // Κενές μέθοδοι για αποφυγή σφαλμάτων αν είναι συνδεδεμένες στο UI
        private void dgvAppointmentsByDate_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgvRevenueService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}