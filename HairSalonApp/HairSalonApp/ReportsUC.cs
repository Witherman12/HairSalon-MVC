using ClosedXML.Excel;
using HairSalonApp.Models;
using HairSalonApp.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data;
using HairSalonApp.Data;

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

        // Η μέθοδος που μετατρέπει τον πίνακα σε PDF
        private void ExportToPdf(DataGridView dgv, string fileName, bool openAfterSave)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.FileName = fileName + "_" + DateTime.Now.ToString("ddMMyyyy");

                string filePath = "";

                // Αν πατήσαμε "Εκτύπωση", το σώζουμε σε προσωρινό φάκελο (Temp) για να ανοίξει αμέσως.
                // Αν πατήσαμε "Εξαγωγή PDF", ρωτάμε το χρήστη πού να το αποθηκεύσει.
                if (openAfterSave)
                {
                    filePath = Path.Combine(Path.GetTempPath(), sfd.FileName + ".pdf");
                }
                else
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        filePath = sfd.FileName;
                    }
                    else
                    {
                        return; // Ο χρήστης πάτησε ακύρωση
                    }
                }

                // Δημιουργία του εγγράφου PDF
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 10f);
                PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
                pdfDoc.Open();

                // Φόρτωση της γραμματοσειράς Arial για να διαβάζονται τα Ελληνικά
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font greekFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);

                // Τίτλος του PDF
                Paragraph title = new Paragraph("Αναφορά: " + fileName.Replace("_", " "), headerFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 15f;
                pdfDoc.Add(title);

                // Δημιουργία του πίνακα στο PDF με τον αριθμό των στηλών του DataGridView
                PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
                pdfTable.WidthPercentage = 100;

                // Προσθήκη Επικεφαλίδων
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                    cell.BackgroundColor = new BaseColor(240, 240, 240); // Ελαφρύ γκρι
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }

                // Προσθήκη Δεδομένων
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string cellValue = cell.Value != null ? cell.Value.ToString() : "";
                        PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, greekFont));
                        pdfTable.AddCell(pdfCell);
                    }
                }

                pdfDoc.Add(pdfTable);
                pdfDoc.Close();

                // Αν πατήσαμε Εκτύπωση, ανοίγουμε αυτόματα το αρχείο (το οποίο θα έχει κουμπί εκτύπωσης)
                if (openAfterSave)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Η εξαγωγή σε PDF ολοκληρώθηκε!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά την εξαγωγή PDF: " + ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            DataGridView targetGrid = null;
            string reportName = "";

            // Βρίσκουμε ποιο grid είναι ανοιχτό
            switch (tabControl1.SelectedIndex)
            {
                case 0: targetGrid = dgvAppointmentsByDate; reportName = "Ραντεβού_Ανά_Ημερομηνία"; break;
                case 1: targetGrid = dgvEmployeeAppointments; reportName = "Ραντεβού_Ανά_Υπάλληλο"; break;
                case 2: targetGrid = dgvRevenueService; reportName = "Έσοδα_Ανά_Υπηρεσία"; break;
                case 3: targetGrid = dgvServiceUsage; reportName = "Δημοφιλείς_Υπηρεσίες"; break;
                default: return;
            }

            if (targetGrid != null && targetGrid.Rows.Count > 0)
            {
                // openAfterSave: false γιατί θέλουμε απλά να το αποθηκεύσει
                ExportToPdf(targetGrid, reportName, false);
            }
            else
            {
                MessageBox.Show("Δεν υπάρχουν δεδομένα στον πίνακα για εξαγωγή!", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Αντικατέστησε το παλιό σου btnPrint_Click με αυτό!
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataGridView targetGrid = null;
            string reportName = "";

            switch (tabControl1.SelectedIndex)
            {
                case 0: targetGrid = dgvAppointmentsByDate; reportName = "Εκτύπωση_Ραντεβού_Ημερομηνίας"; break;
                case 1: targetGrid = dgvEmployeeAppointments; reportName = "Εκτύπωση_Ραντεβού_Υπαλλήλου"; break;
                case 2: targetGrid = dgvRevenueService; reportName = "Εκτύπωση_Εσόδων"; break;
                case 3: targetGrid = dgvServiceUsage; reportName = "Εκτύπωση_Χρήσης_Υπηρεσιών"; break;
                default: return;
            }

            if (targetGrid != null && targetGrid.Rows.Count > 0)
            {
                // openAfterSave: true για να δημιουργήσει το αρχείο αόρατα και να το ανοίξει κατευθείαν για εκτύπωση
                ExportToPdf(targetGrid, reportName, true);
            }
            else
            {
                MessageBox.Show("Δεν υπάρχουν δεδομένα για εκτύπωση!", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Κενές μέθοδοι για αποφυγή σφαλμάτων αν είναι συνδεδεμένες στο UI
        private void dgvAppointmentsByDate_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvRevenueService_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            // Αν το panel είναι κρυφό το εμφανίζει, αν είναι ορατό το κρύβει
            panelFilters.Visible = !panelFilters.Visible;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1).AddTicks(-1);

            if (fromDate > toDate)
            {
                MessageBox.Show("Η αρχική ημερομηνία δεν μπορεί να είναι μεγαλύτερη από την τελική.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ReportRepository repo = new ReportRepository();

                // 1. Ενημερώνουμε τον πίνακα "Ανά Υπάλληλο"
                var filteredEmployees = repo.GetAppointmentsByEmployee(fromDate, toDate);
                dgvEmployeeAppointments.DataSource = filteredEmployees;

                // 2. Ενημερώνουμε τον πίνακα "Ανά Ημερομηνία"
                var filteredDates = repo.GetAppointmentsByDate(fromDate, toDate);
                dgvAppointmentsByDate.DataSource = filteredDates;

                // Κρύβουμε το panel με τα φίλτρα
                panelFilters.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά τη φόρτωση: " + ex.Message);
            }
        }
    }
}