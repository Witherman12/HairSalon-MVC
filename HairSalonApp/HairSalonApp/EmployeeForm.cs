using System;
using System.Windows.Forms;
using HairSalonApp.Models;
using HairSalonApp.Services;

namespace HairSalonApp
{
    public partial class EmployeeForm : Form
    {
        // 1. Δήλωση του Service και της μεταβλητής Id
        private readonly EmployeeService _employeeService = new EmployeeService();
        private int? _employeeId = null;

        // Constructor για ΝΕΟ υπάλληλο
        public EmployeeForm()
        {
            InitializeComponent();
        }

        // 2. Constructor για ΕΠΕΞΕΡΓΑΣΙΑ (τον καλούμε από το UC)
        public EmployeeForm(Employee employee) : this()
        {
            _employeeId = employee.Id;
            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtPhone.Text = employee.Phone;
            txtSpecialty.Text = employee.Specialty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 3. Καλούμε το Service για αποθήκευση στη βάση
            var result = _employeeService.SaveEmployee(
                _employeeId,
                txtFirstName.Text,
                txtLastName.Text,
                txtPhone.Text,
                txtSpecialty.Text
            );

            // 4. Έλεγχος αποτελέσματος
            if (result.Success)
            {
                MessageBox.Show("Η αποθήκευση ολοκληρώθηκε επιτυχώς!", "Ενημέρωση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Επιστρέφει OK στο UC για να κάνει Refresh το Grid
                this.Close();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
