using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HairSalonApp
{
    public partial class EmployeesUC : UserControl
    {
        public EmployeesUC()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm popup = new EmployeeForm();
            popup.Text = "Νέος Υπάλληλος";
            popup.ShowDialog();
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            // Ελέγχουμε αν έχει επιλεγεί γραμμή
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                EmployeeForm popup = new EmployeeForm();
                popup.Text = "Επεξεργασία Υπαλλήλου";
                popup.ShowDialog();
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε έναν υπάλληλο πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            // Ελέγχουμε αν έχει επιλεγεί γραμμή
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Είστε σίγουροι ότι θέλετε να διαγράψετε τον επιλεγμένο υπάλληλο;",
                    "Επιβεβαίωση Διαγραφής",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Προσωρινή διαγραφή από το UI (μέχρι να συνδεθεί το Backend)
                    dgvEmployees.Rows.RemoveAt(dgvEmployees.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε έναν υπάλληλο πρώτα.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
