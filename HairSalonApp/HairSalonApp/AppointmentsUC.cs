using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HairSalonApp.Services;
using HairSalonApp.Models;
using System.Linq;

namespace HairSalonApp
{
    public partial class AppointmentsUC : UserControl
    {
        private readonly AppointmentService _appointmentService = new AppointmentService();

        public AppointmentsUC()
        {
            InitializeComponent();

            // 1. Ρύθμιση του Grid για να πιάνει όλη την οθόνη
            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.RowTemplate.Height = 45;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 2. Δημιουργία Στηλών (Όπως στον Customer/Employee)
            ConfigureColumns();

            // 3. Φόρτωση Δεδομένων
            LoadAppointments();
        }

        private void ConfigureColumns()
        {
            dgvAppointments.Columns.Clear();

            // Κρυφό ID
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });

            // Εμφανή δεδομένα (από το AppointmentView model)
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ημερομηνία", DataPropertyName = "AppDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ώρα", DataPropertyName = "AppTime" });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Πελάτης", DataPropertyName = "CustomerName" });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Υπηρεσία", DataPropertyName = "ServiceName" });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Υπάλληλος", DataPropertyName = "EmployeeName" });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Κατάσταση", DataPropertyName = "Status" });
        }

        private void LoadAppointments()
        {
            try
            {
                var list = _appointmentService.GetAllAppointments();

                // Ταξινόμηση: Πρώτα ανά Ημερομηνία και μετά ανά Ώρα
                var sortedList = list.OrderBy(a => a.AppDate)
                                     .ThenBy(a => a.AppTime)
                                     .ToList();

                dgvAppointments.DataSource = null;
                dgvAppointments.DataSource = sortedList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα φόρτωσης: " + ex.Message);
            }
        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            using (NewAppointmentForm popup = new NewAppointmentForm())
            {
                popup.Text = "Νέο Ραντεβού";
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    LoadAppointments();
                }
            }
        }

        private void btnEditAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow?.DataBoundItem is AppointmentView selected)
            {
                // Εδώ θα περνούσες το selected.Id στη φόρμα σου
                using (NewAppointmentForm popup = new NewAppointmentForm(selected.Id))
                {
                    popup.Text = "Επεξεργασία Ραντεβού";
                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        LoadAppointments();
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε ένα ραντεβού.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            // Χρησιμοποιούμε το SelectedRows[0] ή το CurrentRow για μεγαλύτερη ασφάλεια
            if (dgvAppointments.CurrentRow != null && dgvAppointments.CurrentRow.DataBoundItem is AppointmentView selected)
            {
                DialogResult result = MessageBox.Show(
                    $"Θέλετε σίγουρα να διαγράψετε οριστικά το ραντεβού του/της {selected.CustomerName};",
                    "Επιβεβαίωση Διαγραφής",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Εδώ κάλεσε την DeleteAppointment αντί για την Cancel αν θες να σβηστεί τελείως από τη βάση
                    var op = _appointmentService.DeleteAppointment(selected.Id);

                    if (op.Success)
                    {
                        MessageBox.Show("Το ραντεβού διαγράφηκε!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAppointments(); // Φρεσκάρισμα του Grid
                    }
                    else
                    {
                        MessageBox.Show("Σφάλμα: " + op.ErrorMessage, "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε πρώτα ένα ραντεβού από τη λίστα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Αυτό το κουμπί δεν υπήρχε αλλά είναι χρήσιμο για την ολοκλήρωση (Status = Ολοκληρώθηκε)
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow?.DataBoundItem is AppointmentView selected)
            {
                var op = _appointmentService.CompleteAppointment(selected.Id);
                if (op.Success) LoadAppointments();
            }
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Προαιρετικά: Επιλογή ολόκληρης της γραμμής με απλό κλικ
            if (e.RowIndex >= 0) dgvAppointments.Rows[e.RowIndex].Selected = true;
        }

        private void dtpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // 1. Παίρνουμε την ημερομηνία που επέλεξε ο χρήστης στο ημερολόγιο
                DateTime selectedDate = dtpDateFilter.Value.Date;

                // 2. Καλούμε το Service για να φέρει τα ραντεβού ΜΟΝΟ για αυτή την ημερομηνία
                var filteredList = _appointmentService.GetAppointmentsByDate(selectedDate);

                // 3. Ταξινομούμε τη λίστα ανά Ώρα (AppTime) για να φαίνονται με τη σωστή σειρά
                var sortedList = filteredList.OrderBy(a => a.AppTime).ToList();

                // 4. Ενημερώνουμε το DataGridView
                dgvAppointments.DataSource = null;
                dgvAppointments.DataSource = sortedList;

                // Προαιρετικό: Αν η λίστα είναι άδεια, εμφάνιση μηνύματος στην μπάρα κατάστασης ή τίτλο
                if (sortedList.Count == 0)
                {
                    // Μπορείς να προσθέσεις ένα Label που να λέει "Δεν υπάρχουν ραντεβού"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά το φιλτράρισμα: " + ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}