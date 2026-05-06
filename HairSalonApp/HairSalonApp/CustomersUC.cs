using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HairSalonApp
{
    public partial class CustomersUC : UserControl
    {
        public CustomersUC()
        {
            InitializeComponent();

            // 1. Δημιουργία Στηλών για τους Πελάτες
            dgvCustomers.Columns.Add("Name", "Ονοματεπώνυμο");
            dgvCustomers.Columns.Add("Phone", "Τηλέφωνο");
            dgvCustomers.Columns.Add("Email", "Email");
            dgvCustomers.Columns.Add("Notes", "Σημειώσεις");

            // 2. Προσθήκη ψεύτικων δεδομένων για την παρουσίαση
            dgvCustomers.Rows.Add("Μαρία Παπαδοπούλου", "6971234567", "maria@email.com", "Αλλεργία στη βαφή Χ");
            dgvCustomers.Rows.Add("Γιώργος Αντωνίου", "6989876543", "giorgos@email.com", "-");
            dgvCustomers.Rows.Add("Άννα Γεωργίου", "2101234567", "anna@email.com", "Προτιμάει πρωινά ραντεβού");

            // 3. Ύψος γραμμών για καλύτερη ανάγνωση
            dgvCustomers.RowTemplate.Height = 40;
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            // 1. Ελέγχουμε ΠΡΩΤΑ αν έχει επιλεγεί έστω και μία γραμμή
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                // 2. Εφόσον έχει επιλέξει, βγάζουμε το μήνυμα επιβεβαίωσης
                DialogResult result = MessageBox.Show(
                    "Είστε σίγουροι ότι θέλετε να διαγράψετε τον επιλεγμένο πελάτη;",
                    "Επιβεβαίωση Διαγραφής",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // 3. Αν απαντήσει "Ναι", το διαγράφουμε
                if (result == DialogResult.Yes)
                {
                    dgvCustomers.Rows.RemoveAt(dgvCustomers.SelectedRows[0].Index);
                }
            }
            else
            {
                // Αν πατήσει το κουμπί ΧΩΡΙΣ να έχει επιλέξει πελάτη:
                MessageBox.Show("Παρακαλώ επιλέξτε έναν πελάτη πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm popup = new CustomerForm();
            popup.Text = "Νέος Πελάτης";
            popup.ShowDialog();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                CustomerForm popup = new CustomerForm();
                popup.Text = "Επεξεργασία Πελάτη";
                popup.ShowDialog();
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε έναν πελάτη πρώτα.");
            }
        }
    }
}