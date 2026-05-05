using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HairSalonApp
{
    public partial class AppointmentsUC : UserControl
    {
        public AppointmentsUC()
        {
            InitializeComponent();

            // --- ΔΟΚΙΜΑΣΤΙΚΑ ΔΕΔΟΜΕΝΑ (Μόνο για το UI Design) ---

            // 1. Δημιουργούμε τις στήλες (Τίτλοι)
            dgvAppointments.Columns.Add("Time", "Ώρα");
            dgvAppointments.Columns.Add("Customer", "Πελάτης");
            dgvAppointments.Columns.Add("Service", "Υπηρεσία");
            dgvAppointments.Columns.Add("Employee", "Υπάλληλος");

            // 2. Προσθέτουμε 4 ψεύτικα ραντεβού (Γραμμές)
            dgvAppointments.Rows.Add("10:00", "Μαρία Παπαδοπούλου", "Βαφή & Κούρεμα", "Ελένη");
            dgvAppointments.Rows.Add("11:30", "Γιώργος Αντωνίου", "Ανδρικό Κούρεμα", "Κώστας");
            dgvAppointments.Rows.Add("12:00", "Άννα Γεωργίου", "Χτένισμα", "Ελένη");
            dgvAppointments.Rows.Add("14:30", "Νίκος Δημητρίου", "Παιδικό Κούρεμα", "Κώστας");

            // 3. Κάνουμε τις γραμμές λίγο πιο ψηλές για να αναπνέει το κείμενο
            dgvAppointments.RowTemplate.Height = 40;
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            // 1. Δημιουργεί ένα αντίγραφο από το παραθυράκι
            NewAppointmentForm popup = new NewAppointmentForm();

            // 2. Το εμφανίζει στην οθόνη ως Pop-up
            popup.ShowDialog();
        }
    }
}
