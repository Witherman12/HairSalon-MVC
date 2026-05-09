using System;
using System.Windows.Forms;

namespace HairSalonApp
{
    public partial class ServiceForm : Form
    {
        // Φτιάχνουμε 3 μεταβλητές (Properties)
        // Για να μπορεί το κεντρικό μενού να πάρει τις τιμές όταν κλείσει αυτό το παραθυράκι.
        public string ServiceNameValue { get; private set; } = string.Empty;
        public decimal PriceValue { get; private set; }
        public int DurationValue { get; private set; }

        // Κανονικός Constructor (Για Νέα Υπηρεσία)
        public ServiceForm()
        {
            InitializeComponent();
        }

        // Δεύτερος Constructor (Για Επεξεργασία Υπάρχουσας Υπηρεσίας)
        public ServiceForm(string name, decimal price, int duration)
        {
            InitializeComponent();

            // Γεμίζουμε τα πεδία με τα υπάρχοντα δεδομένα
            txtServiceName.Text = name;
            numPrice.Value = price;
            numDuration.Value = duration;
        }

        // Κουμπί Αποθήκευσης
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Έλεγχος: Μήπως ξέχασε να βάλει όνομα;
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το όνομα της υπηρεσίας.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Σταματάει εδώ τον κώδικα
            }

            // 2. Αποθήκευση των τιμών στις μεταβλητές μας
            ServiceNameValue = txtServiceName.Text;
            PriceValue = numPrice.Value;
            DurationValue = (int)numDuration.Value;

            // 3. Λέμε στο σύστημα ότι πατήθηκε το "OK" και κλείνουμε τη φόρμα
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Κουμπί Ακύρωσης
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Λέμε στο σύστημα ότι πατήθηκε "Ακύρωση" και κλείνουμε
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}