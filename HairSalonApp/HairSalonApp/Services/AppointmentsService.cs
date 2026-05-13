using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using HairSalonApp.Data;
using HairSalonApp.Helpers;

namespace HairSalonApp.Services
{
    public class AppointmentService
    {
        private readonly AppointmentRepository _appointmentRepository;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        // Ανάκτηση ενός ραντεβού βάσει ID (Για την επεξεργασία)
        public AppointmentView? GetAppointmentById(int id)
        {
            try
            {
                // Το Service απλά ζητάει το ραντεβού από το Data Layer (Repository)
                return _appointmentRepository.GetAppointmentViewById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Ανάκτηση όλων των ραντεβού (σε μορφή View με ονόματα)
        public List<AppointmentView> GetAllAppointments()
        {
            try
            {
                return _appointmentRepository.GetAll();
            }
            catch (Exception)
            {
                // Αν σκάσει η βάση, επιστρέφουμε μια άδεια λίστα για να μην κρασάρει το UI
                return new List<AppointmentView>();
            }
        }

        // Ανάκτηση ραντεβού βάσει συγκεκριμένης ημερομηνίας
        public List<AppointmentView> GetAppointmentsByDate(DateTime date)
        {
            try
            {
                return _appointmentRepository.GetByDate(date);
            }
            catch (Exception)
            {
                return new List<AppointmentView>();
            }
        }

        // Δημιουργία νέου ραντεβού
        public OperationResult AddAppointment(Appointment app, int durationMinutes)
        {
            // 1. Καθαρισμός δεδομένων
            app.Status = app.Status?.Trim() ?? "Ενεργό";

            // 2. Validation
            if (app.CustomerId <= 0)
            {
                return new OperationResult { Success = false, ErrorMessage = "Παρακαλώ επιλέξτε πελάτη." };
            }
            if (app.EmployeeId <= 0)
            {
                return new OperationResult { Success = false, ErrorMessage = "Παρακαλώ επιλέξτε υπάλληλο." };
            }
            if (app.ServiceId <= 0)
            {
                return new OperationResult { Success = false, ErrorMessage = "Παρακαλώ επιλέξτε υπηρεσία." };
            }
            if (durationMinutes <= 0)
            {
                return new OperationResult { Success = false, ErrorMessage = "Η διάρκεια της υπηρεσίας δεν είναι έγκυρη." };
            }

            // 3. Έλεγχος Διαθεσιμότητας
            try
            {
                bool isAvailable = _appointmentRepository.IsAvailable(app.EmployeeId, app.AppDate, app.AppTime, durationMinutes);

                if (!isAvailable)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Ο υπάλληλος δεν είναι διαθέσιμος αυτή την ώρα." };
                }

                // 4. Επικοινωνία με το Data Access Layer
                int newId = _appointmentRepository.Insert(app);
                if (newId <= 0)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Η αποθήκευση απέτυχε. Δοκιμάστε ξανά." };
                }

                return new OperationResult { Success = true };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την αποθήκευση στη βάση: " + ex.Message };
            }
        }

        // Ενημέρωση υπάρχοντος ραντεβού
        public OperationResult UpdateAppointment(Appointment app, int durationMinutes)
        {
            // 1. Καθαρισμός δεδομένων
            app.Status = app.Status?.Trim() ?? "";

            // 2. Validation
            if (app.Id <= 0) return new OperationResult { Success = false, ErrorMessage = "Μη έγκυρο ραντεβού." };
            if (app.CustomerId <= 0) return new OperationResult { Success = false, ErrorMessage = "Παρακαλώ επιλέξτε πελάτη." };
            if (app.EmployeeId <= 0) return new OperationResult { Success = false, ErrorMessage = "Παρακαλώ επιλέξτε υπάλληλο." };
            if (app.ServiceId <= 0) return new OperationResult { Success = false, ErrorMessage = "Παρακαλώ επιλέξτε υπηρεσία." };

            // 3. Έλεγχος Διαθεσιμότητας (εξαιρείται το τρέχον ραντεβού)
            try
            {
                bool isAvailable = _appointmentRepository.IsAvailableForUpdate(app.Id, app.EmployeeId, app.AppDate, app.AppTime, durationMinutes);

                if (!isAvailable)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Ο υπάλληλος έχει άλλο ραντεβού εκείνη την ώρα." };
                }

                // 4. Επικοινωνία με το Data Access Layer
                bool isUpdated = _appointmentRepository.Update(app);
                if (!isUpdated)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Δεν βρέθηκε το ραντεβού για ενημέρωση (ίσως έχει διαγραφεί)." };
                }

                return new OperationResult { Success = true };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την ενημέρωση στη βάση: " + ex.Message };
            }
        }

        // Ακύρωση Ραντεβού
        public OperationResult CancelAppointment(int id)
        {
            try
            {
                bool isCanceled = _appointmentRepository.Cancel(id);

                if (isCanceled)
                {
                    return new OperationResult { Success = true };
                }

                return new OperationResult { Success = false, ErrorMessage = "Το ραντεβού δεν βρέθηκε." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την ακύρωση: " + ex.Message };
            }
        }

        // Ολοκλήρωση Ραντεβού
        public OperationResult CompleteAppointment(int id)
        {
            try
            {
                bool isCompleted = _appointmentRepository.Complete(id);

                if (isCompleted)
                {
                    return new OperationResult { Success = true };
                }

                return new OperationResult { Success = false, ErrorMessage = "Το ραντεβού δεν βρέθηκε." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την ολοκλήρωση: " + ex.Message };
            }
        }

        // Επαναφορά Ραντεβού σε Ενεργό (Untick CheckBox)
        public OperationResult ReactivateAppointment(int id)
        {
            try
            {
                bool isReactivated = _appointmentRepository.Reactivate(id);

                if (isReactivated)
                {
                    return new OperationResult { Success = true };
                }

                return new OperationResult { Success = false, ErrorMessage = "Το ραντεβού δεν βρέθηκε." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την επαναφορά: " + ex.Message };
            }
        }

        // Διαγραφή Ραντεβού
        public OperationResult DeleteAppointment(int id)
        {
            try
            {
                bool isDeleted = _appointmentRepository.Delete(id);

                if (isDeleted)
                {
                    return new OperationResult { Success = true };
                }

                return new OperationResult { Success = false, ErrorMessage = "Το ραντεβού δεν βρέθηκε. Ίσως έχει ήδη διαγραφεί." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την διαγραφή: " + ex.Message };
            }
        }
    }
}