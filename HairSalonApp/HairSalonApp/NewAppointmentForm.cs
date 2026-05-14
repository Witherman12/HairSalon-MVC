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
            try
            {
                // 1. Ζητάμε από το Service να μας φέρει τα στοιχεία του ραντεβού
                var appointment = _appointmentService.GetAppointmentById(id);

                if (appointment != null)
                {
                    // 2. Γεμίζουμε τα controls της φόρμας με τα δεδομένα του ραντεβού

                    // Ημερομηνία
                    dtpDate.Value = appointment.AppDate;

                    // Επειδή το DateTimePicker περιμένει ολόκληρη ημερομηνία, του δίνουμε το "Σήμερα" συν την Ώρα του ραντεβού
                    dtpTime.Value = DateTime.Today.Add(appointment.AppTime);

                    // Επιλογή στα DropDowns (ComboBoxes)
                    cmbCustomer.SelectedValue = appointment.CustomerId;
                    cmbEmployee.SelectedValue = appointment.EmployeeId;
                    cmbService.SelectedValue = appointment.ServiceId;
                }
                else
                {
                    MessageBox.Show("Το ραντεβού δεν βρέθηκε. Μπορεί να διαγράφηκε από άλλον χρήστη.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Κλείνουμε τη φόρμα αφού δεν υπάρχει το ραντεβού
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά τη φόρτωση του ραντεβού: " + ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Έλεγχος DropDowns
                if (cmbCustomer.SelectedValue == null || cmbEmployee.SelectedValue == null || cmbService.SelectedValue == null)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε Πελάτη, Υπηρεσία και Υπάλληλο.", "Ελλιπή στοιχεία", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TimeSpan parsedTime = dtpTime.Value.TimeOfDay;

                // Έλεγχος Ωραρίου
                if (parsedTime.Hours < 9 || parsedTime.Hours > 21) // π.χ. ωράριο 09:00 - 21:00
                {
                    MessageBox.Show("Η ώρα πρέπει να είναι εντός του ωραρίου λειτουργίας (09:00 - 21:00).", "Εκτός Ωραρίου", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 3. Δημιουργία αντικειμένου Appointment (χρησιμοποιούμε την ασφαλή 'parsedTime')
                var appointment = new Appointment
                {
                    CustomerId = (int)cmbCustomer.SelectedValue,
                    EmployeeId = (int)cmbEmployee.SelectedValue,
                    ServiceId = (int)cmbService.SelectedValue,
                    AppDate = dtpDate.Value.Date,
                    AppTime = parsedTime, // <-- Εδώ μπαίνει η ελεγμένη ώρα!
                    Status = "Ενεργό"
                };

                // 4. Έλεγχος διαθεσιμότητας & Αποθήκευση
                if (cmbService.SelectedItem is Service selectedService)
                {
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

                    // 5. Αποτέλεσμα
                    if (result.Success)
                    {
                        MessageBox.Show("Το ραντεβού αποθηκεύτηκε επιτυχώς!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result.ErrorMessage, "Αδυναμία Αποθήκευσης", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Αυτό πρακτικά δεν θα τρέξει ποτέ λόγω του ελέγχου στην αρχή,
                    // αλλά κλείνει το στόμα του compiler!
                    MessageBox.Show("Παρακαλώ επιλέξτε μια έγκυρη Υπηρεσία.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Εφόσον η ώρα ελέγχεται με το TryParse, δεν χρειαζόμαστε πια το FormatException catch
                MessageBox.Show("Προέκυψε ένα απρόσμενο σφάλμα:\n" + ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}