using HairSalonApp.Helpers;
using HairSalonApp.Models;
using HairSalonApp.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HairSalonApp
{
    public partial class NewAppointmentForm : Form
    {
        private readonly CustomerService _customerService = new CustomerService();
        private readonly EmployeeService _employeeService = new EmployeeService();
        private readonly ServiceService _serviceService = new ServiceService();
        private readonly AppointmentService _appointmentService = new AppointmentService();

        private int? _editAppointmentId = null; // Αν έχει τιμή, είμαστε σε λειτουργία επεξεργασίας

        // Constructor για ΝΕΟ ραντεβού
        public NewAppointmentForm()
        {
            InitializeComponent();
            LoadFormData();
        }

        // Constructor για ΕΠΕΞΕΡΓΑΣΙΑ υπάρχοντος ραντεβού
        public NewAppointmentForm(int appointmentId) : this()
        {
            _editAppointmentId = appointmentId;
            LoadAppointmentForEdit(appointmentId);
        }

        private void LoadFormData()
        {
            try
            {
                // Γέμισμα Πελατών
                cmbCustomer.DataSource = _customerService.GetAllCustomers();
                cmbCustomer.DisplayMember = "FullName";
                cmbCustomer.ValueMember = "Id";

                // Γέμισμα Υπαλλήλων
                cmbEmployee.DataSource = _employeeService.GetAllEmployees();
                cmbEmployee.DisplayMember = "FullName";
                cmbEmployee.ValueMember = "Id";

                // Γέμισμα Υπηρεσιών
                cmbService.DataSource = _serviceService.GetAllServices();
                cmbService.DisplayMember = "ServiceName";
                cmbService.ValueMember = "Id";

                // Προεπιλεγμένη ημερομηνία η σημερινή
                dtpDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά τη φόρτωση των δεδομένων: " + ex.Message);
            }
        }

        private void LoadAppointmentForEdit(int id)
        {
            // Εδώ θα έπρεπε να υπάρχει μια μέθοδος GetById στο Service
            // Αν δεν την έχεις φτιάξει ακόμα, μπορείς να την παραλείψεις προσωρινά
            // ή να πάρεις το αντικείμενο από τη λίστα του προηγούμενου Grid.
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Έλεγχος αν έχουν επιλεγεί τα απαραίτητα
                if (cmbCustomer.SelectedValue == null || cmbEmployee.SelectedValue == null || cmbService.SelectedValue == null)
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία.");
                    return;
                }

                // 2. Δημιουργία αντικειμένου Appointment
                var appointment = new Appointment
                {
                    CustomerId = (int)cmbCustomer.SelectedValue,
                    EmployeeId = (int)cmbEmployee.SelectedValue,
                    ServiceId = (int)cmbService.SelectedValue,
                    AppDate = dtpDate.Value.Date,
                    AppTime = TimeSpan.Parse(txtTime.Text), // Υποθέτουμε format HH:mm π.χ. 14:30
                    Status = "Ενεργό"
                };

                // 3. Παίρνουμε τη διάρκεια της υπηρεσίας για τον έλεγχο διαθεσιμότητας
                var selectedService = (Service)cmbService.SelectedItem;
                int duration = selectedService.DurationMinutes;

                OperationResult result;

                if (_editAppointmentId.HasValue)
                {
                    appointment.Id = _editAppointmentId.Value;
                    result = _appointmentService.UpdateAppointment(appointment, duration);
                }
                else
                {
                    result = _appointmentService.AddAppointment(appointment, duration);
                }

                if (result.Success)
                {
                    MessageBox.Show("Το ραντεβού αποθηκεύτηκε επιτυχώς!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Παρακαλώ εισάγετε σωστή ώρα (π.χ. 10:30).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}