using System;
using System.Windows.Forms;
using HairSalonApp.Models;
using HairSalonApp.Services;

namespace HairSalonApp
{
    public partial class ServiceForm : Form
    {
        // 1. Δήλωση του Service και της μεταβλητής Id
        private readonly ServiceService _serviceService = new ServiceService();
        private int? _serviceId = null;

        // Κανονικός Constructor (Για Νέα Υπηρεσία)
        public ServiceForm()
        {
            InitializeComponent();
        }

        // Δεύτερος Constructor (Για Επεξεργασία - Δέχεται πλέον όλο το αντικείμενο Service)
        public ServiceForm(Service service) : this()
        {
            _serviceId = service.Id;
            txtServiceName.Text = service.ServiceName;
            numPrice.Value = service.Price;
            numDuration.Value = service.DurationMinutes;
        }

        // Κουμπί Αποθήκευσης
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 2. Κλήση του Service για αποθήκευση/ενημέρωση στη βάση
            // Παίρνουμε τις τιμές απευθείας από τα controls
            var result = _serviceService.SaveService(
                _serviceId,
                txtServiceName.Text,
                numPrice.Value,
                (int)numDuration.Value
            );

            // 3. Έλεγχος αποτελέσματος
            if (result.Success)
            {
                MessageBox.Show("Η υπηρεσία αποθηκεύτηκε επιτυχώς!", "Ενημέρωση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Κουμπί Ακύρωσης
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {

        }
    }
}