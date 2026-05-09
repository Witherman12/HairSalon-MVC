using HairSalonApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HairSalonApp
{
    public partial class ServicesUC : UserControl
    {
        public ServicesUC()
        {
            InitializeComponent();
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            // Ελέγχουμε αν έχει επιλεγεί γραμμή
            if (dgvServices.SelectedRows.Count > 0)
            {
                ServiceForm popup = new ServiceForm();
                popup.Text = "Επεξεργασία Υπηρεσίας";
                popup.ShowDialog();
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε μια υπηρεσία πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNewService_Click(object sender, EventArgs e)
        {
            // Ανοίγουμε το παραθυράκι
            using (ServiceForm form = new ServiceForm())
            {
                // Αν ο χρήστης πάτησε "Αποθήκευση" (και όχι το Χ ή Ακύρωση)
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Παίρνουμε τα δεδομένα που πληκτρολόγησε
                    string newName = form.ServiceNameValue;
                    decimal newPrice = form.PriceValue;
                    int newDuration = form.DurationValue;

                    // Δοκιμαστικό μήνυμα για να δούμε ότι δουλεύει! 
                    // (Αργότερα εδώ θα γράφουμε τον κώδικα για αποθήκευση στη Βάση)
                    MessageBox.Show($"Αποθηκεύτηκε: {newName} | Τιμή: {newPrice}€ | Διάρκεια: {newDuration} λεπτά", "Επιτυχία");
                }
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            // Ελέγχουμε αν έχει επιλεγεί γραμμή
            if (dgvServices.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Είστε σίγουροι ότι θέλετε να διαγράψετε την επιλεγμένη υπηρεσία;",
                    "Επιβεβαίωση Διαγραφής",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Προσωρινή διαγραφή από το UI (μέχρι να συνδεθεί το Backend)
                    dgvServices.Rows.RemoveAt(dgvServices.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε μία υπηρεσία πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
