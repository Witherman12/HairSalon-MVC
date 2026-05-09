using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HairSalonApp.Services; // Προσθήκη του Service

namespace HairSalonApp
{
    public partial class CustomersUC : UserControl
    {
        private readonly CustomerService _customerService;

        public CustomersUC()
        {
            InitializeComponent();
            _customerService = new CustomerService();

            // 1. Ρύθμιση Στηλών
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Clear();

            // Προσθήκη κρυφής στήλης για το ID (απαραίτητο για Edit/Delete)
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });

            // Δημιουργία των στηλών σου και σύνδεση με τα properties του Model (DataPropertyName)
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ονοματεπώνυμο", DataPropertyName = "FullName" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Τηλέφωνο", DataPropertyName = "Phone" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Σημειώσεις", DataPropertyName = "Notes" });

            // 2. Ύψος γραμμών για καλύτερη ανάγνωση
            dgvCustomers.RowTemplate.Height = 40;

            // 3. Φόρτωση πραγματικών δεδομένων από τη βάση
            LoadCustomers();
        }

        // Βοηθητική μέθοδος για να φέρνει τα δεδομένα και να ανανεώνει το Grid
        private void LoadCustomers()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = _customerService.GetAllCustomers();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            // 1. Ελέγχουμε αν έχει επιλεγεί έστω και μία γραμμή
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                // 2. Εφόσον έχει επιλέξει, βγάζουμε το μήνυμα επιβεβαίωσης
                DialogResult result = MessageBox.Show(
                    "Είστε σίγουροι ότι θέλετε να διαγράψετε τον επιλεγμένο πελάτη;",
                    "Επιβεβαίωση Διαγραφής",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // 3. Αν απαντήσει "Ναι", το διαγράφουμε από τη βάση
                if (result == DialogResult.Yes)
                {
                    // Παίρνουμε το κρυφό ID της επιλεγμένης γραμμής
                    int selectedId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);

                    var operation = _customerService.DeleteCustomer(selectedId);

                    if (operation.Success)
                    {
                        LoadCustomers(); // Ανανέωση του DataGridView
                    }
                    else
                    {
                        MessageBox.Show(operation.ErrorMessage, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε έναν πελάτη πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm popup = new CustomerForm(); // Χωρίς ID = Νέος
            popup.Text = "Νέος Πελάτης";

            if (popup.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers(); // Ανανεώνουμε την λίστα αν αποθηκεύτηκε επιτυχώς
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            // Ελέγχουμε αν έχει επιλεγεί γραμμή
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                CustomerForm popup = new CustomerForm();
                popup.Text = "Επεξεργασία Πελάτη";
                popup.ShowDialog();
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε έναν πελάτη πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}