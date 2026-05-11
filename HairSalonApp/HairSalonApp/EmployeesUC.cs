using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HairSalonApp.Models;
using HairSalonApp.Services;

namespace HairSalonApp
{
    public partial class EmployeesUC : UserControl
    {
        private readonly EmployeeService _employeeService;

        public EmployeesUC()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();

            // 1. Ρύθμιση Στηλών (Όπως στον Customer)
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.Columns.Clear();

            // Προσθήκη κρυφής στήλης για το ID
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });

            // Δημιουργία των στηλών και σύνδεση με τα properties του Employee Model
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ονοματεπώνυμο", DataPropertyName = "FullName" });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ειδικότητα", DataPropertyName = "Specialty" });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Τηλέφωνο", DataPropertyName = "Phone" });

            // 2. Ρύθμιση Εμφάνισης (Fill και Ύψος)
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.RowTemplate.Height = 40;

            // 3. Φόρτωση δεδομένων
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _employeeService.GetAllEmployees();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            using (EmployeeForm popup = new EmployeeForm())
            {
                popup.Text = "Νέος Υπάλληλος";
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees();
                }
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            // Ελέγχουμε αν έχει επιλεγεί γραμμή (is Employee selected για ασφάλεια)
            if (dgvEmployees.CurrentRow?.DataBoundItem is Employee selected)
            {
                using (EmployeeForm popup = new EmployeeForm(selected))
                {
                    popup.Text = "Επεξεργασία Υπαλλήλου";
                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        LoadEmployees();
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε έναν υπάλληλο πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow?.DataBoundItem is Employee selected)
            {
                DialogResult result = MessageBox.Show(
                    $"Είστε σίγουροι ότι θέλετε να διαγράψετε τον υπάλληλο {selected.FullName};",
                    "Επιβεβαίωση Διαγραφής",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var operation = _employeeService.DeleteEmployee(selected.Id);

                    if (operation.Success)
                    {
                        LoadEmployees();
                    }
                    else
                    {
                        MessageBox.Show(operation.ErrorMessage, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε έναν υπάλληλο πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Κενό για μελλοντική χρήση
        }
    }
}