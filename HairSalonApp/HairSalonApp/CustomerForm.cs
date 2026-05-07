using System;
using System.Windows.Forms;
using HairSalonApp.Services; // Για να βλέπει το CustomerService
using HairSalonApp.Models;   // Για να βλέπει το Customer

namespace HairSalonApp
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerService _customerService;
        private int? _currentCustomerId = null;

        // Ο constructor παίρνει προαιρετικά ένα ID. 
        // Αν περάσουμε ID, σημαίνει "Επεξεργασία". Αν όχι, σημαίνει "Νέος πελάτης".
        public CustomerForm(int? customerId = null)
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _currentCustomerId = customerId;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // Αν ανοίγουμε τη φόρμα για επεξεργασία, γεμίζουμε τα TextBoxes
            if (_currentCustomerId.HasValue)
            {
                var customer = _customerService.GetCustomerById(_currentCustomerId.Value);
                if (customer != null)
                {
                    txtFirstName.Text = customer.FirstName;
                    txtLastName.Text = customer.LastName;
                    txtPhone.Text = customer.Phone;
                    txtEmail.Text = customer.Email;
                    txtNotes.Text = customer.Notes;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Καλούμε το BLL να κάνει τα πάντα (Validation & Αποθήκευση)
            var result = _customerService.SaveCustomer(
                _currentCustomerId,
                txtFirstName.Text,
                txtLastName.Text,
                txtPhone.Text,
                txtEmail.Text,
                txtNotes.Text
            );

            if (!result.Success)
            {
                // Αν κάτι πήγε στραβά (π.χ. κενό όνομα), δείχνουμε το μήνυμα και σταματάμε
                MessageBox.Show(result.ErrorMessage, "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Αν όλα πήγαν καλά
            MessageBox.Show("Η αποθήκευση ολοκληρώθηκε επιτυχώς!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK; // Ενημερώνουμε ότι κλείσαμε με επιτυχία
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}