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
            string phone = txtPhone.Text.Trim(); // Υποθέτω το TextBox λέγεται txtPhone

            // Γρήγορος έλεγχος στο UI
            if (!string.IsNullOrWhiteSpace(phone))
            {
                if (phone.Length != 10 || !System.Linq.Enumerable.All(phone, char.IsDigit))
                {
                    MessageBox.Show("Το τηλέφωνο πρέπει να αποτελείται ακριβώς από 10 ψηφία.", "Λάθος Τηλέφωνο", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    txtPhone.SelectAll();
                    return; // Σταματάμε εδώ!
                }
            }

            var result = _employeeService.SaveEmployee(
                _employeeId,
                txtFirstName.Text,
                txtLastName.Text,
                txtPhone.Text,
                txtSpecialty.Text);

            if (result.Success)
            {
                MessageBox.Show("Ο υπάλληλος αποθηκεύτηκε επιτυχώς!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
