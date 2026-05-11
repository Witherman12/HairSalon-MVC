using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HairSalonApp.Models;
using HairSalonApp.Services;

namespace HairSalonApp
{
    public partial class ServicesUC : UserControl
    {
        // 1. Δήλωση του Service για τις υπηρεσίες
        private readonly ServiceService _serviceService = new ServiceService();

        public ServicesUC()
        {
            InitializeComponent();
            // Φορτώνουμε τις υπηρεσίες μόλις εμφανιστεί το User Control
            LoadServices();
        }

        // 2. Μέθοδος για τη φόρτωση των δεδομένων από τη βάση στο DataGridView
        private void LoadServices()
        {
            try
            {
                // Παίρνουμε τη λίστα των υπηρεσιών από το Service
                List<Service> list = _serviceService.GetAllServices();

                // Σύνδεση με το DataGridView
                dgvServices.DataSource = null;
                dgvServices.DataSource = list;

                // Κρύβουμε τη στήλη Id αν υπάρχει
                if (dgvServices.Columns["Id"] != null)
                    dgvServices.Columns["Id"].Visible = false;

                // Βελτίωση επικεφαλίδων για να φαίνονται όμορφα
                if (dgvServices.Columns["ServiceName"] != null) dgvServices.Columns["ServiceName"].HeaderText = "Υπηρεσία";
                if (dgvServices.Columns["Price"] != null) dgvServices.Columns["Price"].HeaderText = "Τιμή (€)";
                if (dgvServices.Columns["DurationMinutes"] != null) dgvServices.Columns["DurationMinutes"].HeaderText = "Διάρκεια (Λεπτά)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά τη φόρτωση των υπηρεσιών: " + ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewService_Click(object sender, EventArgs e)
        {
            // Ανοίγουμε τη φόρμα για νέα υπηρεσία
            using (ServiceForm form = new ServiceForm())
            {
                form.Text = "Νέα Υπηρεσία";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Αν αποθηκεύτηκε επιτυχώς, ανανεώνουμε τη λίστα
                    LoadServices();
                }
            }
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            // Χρήση ασφαλούς ελέγχου για την επιλεγμένη υπηρεσία
            if (dgvServices.CurrentRow?.DataBoundItem is Service selected)
            {
                using (ServiceForm form = new ServiceForm(selected))
                {
                    form.Text = "Επεξεργασία Υπηρεσίας";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadServices();
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε μια υπηρεσία πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow?.DataBoundItem is Service selected)
            {
                DialogResult result = MessageBox.Show(
                    $"Είστε σίγουροι ότι θέλετε να διαγράψετε την υπηρεσία '{selected.ServiceName}';",
                    "Επιβεβαίωση Διαγραφής",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Κλήση του Service για διαγραφή από τη βάση δεδομένων
                    var opResult = _serviceService.DeleteService(selected.Id);

                    if (opResult.Success)
                    {
                        LoadServices(); // Ανανέωση του Grid
                    }
                    else
                    {
                        MessageBox.Show(opResult.ErrorMessage, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε μία υπηρεσία πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Μέθοδος για το CellContentClick αν χρειαστεί στο μέλλον
        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}