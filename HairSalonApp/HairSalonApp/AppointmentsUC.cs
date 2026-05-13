using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HairSalonApp.Services;
using HairSalonApp.Models;
using System.Linq;
using System.Drawing;

namespace HairSalonApp
{
    public partial class AppointmentsUC : UserControl
    {
        private readonly AppointmentService _appointmentService = new AppointmentService();

        public AppointmentsUC()
        {
            InitializeComponent();

            // 1. Ρυθμίσεις εμφάνισης
            dgvAppointments.AutoGenerateColumns = false; // Τώρα το κλείνουμε γιατί θα τις φτιάξουμε εμείς σωστά
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.RowTemplate.Height = 45;
            dgvAppointments.AllowUserToAddRows = false;

            // 2. Σύνδεση Events (με object? για να μην έχεις warnings)
            dgvAppointments.DataBindingComplete += dgvAppointments_DataBindingComplete;
            dgvAppointments.CellContentClick += dgvAppointments_CellContentClick;
            dtpDateFilter.ValueChanged += dtpDateFilter_ValueChanged;

            // 3. Προετοιμασία
            ConfigureColumns();
            LoadAppointments();
        }

        private void ConfigureColumns()
        {
            dgvAppointments.Columns.Clear();

            // Στήλη CheckBox
            dgvAppointments.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colCompleteCheck",
                HeaderText = "Ολοκλ.",
                Width = 60
            });

            // Κρυφό ID (για να το βρίσκει ο κώδικας)
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            // Δεδομένα από το AppointmentView (Προσοχή: Τα DataPropertyName είναι ακριβώς όπως στο .cs αρχείο σου)
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ημερομηνία", DataPropertyName = "AppDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ώρα", DataPropertyName = "AppTime" });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Πελάτης", DataPropertyName = "CustomerName" });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Υπηρεσία", DataPropertyName = "ServiceName" });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Υπάλληλος", DataPropertyName = "EmployeeName" });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Κατάσταση", DataPropertyName = "Status" });
        }

        private void LoadAppointments()
        {
            try
            {
                // Επαναφέρουμε το φίλτρο ημερομηνίας!
                DateTime selectedDate = dtpDateFilter.Value.Date;
                var filteredList = _appointmentService.GetAppointmentsByDate(selectedDate);

                var sortedList = filteredList.OrderBy(a => a.AppTime).ToList();

                dgvAppointments.DataSource = null;
                dgvAppointments.DataSource = sortedList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα: " + ex.Message);
            }
        }

        private void dgvAppointments_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                if (row.DataBoundItem is AppointmentView app)
                {
                    // Ενημέρωση CheckBox
                    row.Cells["colCompleteCheck"].Value = (app.Status == "Ολοκληρώθηκε");

                    // Χρωματισμός
                    if (app.Status == "Ολοκληρώθηκε")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void dgvAppointments_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAppointments.Columns[e.ColumnIndex].Name == "colCompleteCheck")
            {
                dgvAppointments.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool isChecked = Convert.ToBoolean(dgvAppointments.Rows[e.RowIndex].Cells["colCompleteCheck"].Value);

                if (dgvAppointments.Rows[e.RowIndex].DataBoundItem is AppointmentView selected)
                {
                    if (isChecked) _appointmentService.CompleteAppointment(selected.Id);
                    else _appointmentService.ReactivateAppointment(selected.Id);

                    LoadAppointments(); // Refresh για να ενημερωθεί το Status text και το χρώμα
                }
            }
        }

        private void dtpDateFilter_ValueChanged(object? sender, EventArgs e)
        {
            LoadAppointments();
        }

        // --- Λοιπά Κουμπιά ---

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            using (NewAppointmentForm popup = new NewAppointmentForm())
            {
                if (popup.ShowDialog() == DialogResult.OK) LoadAppointments();
            }
        }

        private void btnEditAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow?.DataBoundItem is AppointmentView selected)
            {
                using (NewAppointmentForm popup = new NewAppointmentForm(selected.Id))
                {
                    if (popup.ShowDialog() == DialogResult.OK) LoadAppointments();
                }
            }
        }

        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow?.DataBoundItem is AppointmentView selected)
            {
                if (selected.Status == "Ολοκληρώθηκε")
                {
                    MessageBox.Show("Δεν μπορείτε να διαγράψετε ολοκληρωμένο ραντεβού.", "Απαγόρευση", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show($"Οριστική διαγραφή ραντεβού για {selected.CustomerName};", "Επιβεβαίωση", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _appointmentService.DeleteAppointment(selected.Id);
                    LoadAppointments();
                }
            }
        }
    }
}