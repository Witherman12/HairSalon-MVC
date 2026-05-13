using HairSalonApp.Data;
using HairSalonApp.Helpers;
using HairSalonApp.Models;
using System;
using System.Collections.Generic;

namespace HairSalonApp.Services
{
    public class AppointmentService
    {
        private readonly AppointmentRepository _repo = new AppointmentRepository();

        /// <summary>
        /// Επιστρέφει όλα τα ραντεβού σε μορφή View (με ονόματα).
        /// </summary>
        public List<AppointmentView> GetAllAppointments()
        {
            try
            {
                return _repo.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching appointments: " + ex.Message);
                return new List<AppointmentView>();
            }
        }

        /// <summary>
        /// Επιστρέφει τα ραντεβού μιας συγκεκριμένης ημέρας.
        /// </summary>
        public List<AppointmentView> GetAppointmentsByDate(DateTime date)
        {
            try
            {
                return _repo.GetByDate(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching appointments by date: " + ex.Message);
                return new List<AppointmentView>();
            }
        }

        /// <summary>
        /// Δημιουργεί ένα νέο ραντεβού αφού ελέγξει τη διαθεσιμότητα.
        /// </summary>
        public OperationResult AddAppointment(Appointment app, int durationMinutes)
        {
            try
            {
                // 1. Έλεγχος αν ο υπάλληλος είναι διαθέσιμος
                bool available = _repo.IsAvailable(app.EmployeeId, app.AppDate, app.AppTime, durationMinutes);

                if (!available)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Ο υπάλληλος δεν είναι διαθέσιμος αυτή την ώρα." };
                }

                // 2. Αποθήκευση
                int newId = _repo.Insert(app);
                return new OperationResult { Success = true };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την αποθήκευση: " + ex.Message };
            }
        }

        /// <summary>
        /// Ενημερώνει ένα ραντεβού ελέγχοντας τη διαθεσιμότητα (εκτός του εαυτού του).
        /// </summary>
        public OperationResult UpdateAppointment(Appointment app, int durationMinutes)
        {
            try
            {
                // 1. Έλεγχος διαθεσιμότητας για update
                bool available = _repo.IsAvailableForUpdate(app.Id, app.EmployeeId, app.AppDate, app.AppTime, durationMinutes);

                if (!available)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Ο υπάλληλος έχει άλλο ραντεβού εκείνη την ώρα." };
                }

                bool updated = _repo.Update(app);
                return updated ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Δεν βρέθηκε το ραντεβού προς ενημέρωση." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την ενημέρωση: " + ex.Message };
            }
        }

        /// <summary>
        /// Ακυρώνει ένα ραντεβού (Status = "Ακυρώθηκε").
        /// </summary>
        public OperationResult CancelAppointment(int id)
        {
            try
            {
                bool result = _repo.Cancel(id);
                return result ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Αποτυχία ακύρωσης." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        /// <summary>
        /// Ολοκληρώνει ένα ραντεβού (Status = "Ολοκληρώθηκε").
        /// </summary>
        public OperationResult CompleteAppointment(int id)
        {
            try
            {
                bool result = _repo.Complete(id);
                return result ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Αποτυχία ολοκλήρωσης." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        /// <summary>
        /// Διαγράφει οριστικά ένα ραντεβού.
        /// </summary>
        public OperationResult DeleteAppointment(int id)
        {
            try
            {
                bool result = _repo.Delete(id);
                return result ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Αποτυχία διαγραφής." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }
    }
}