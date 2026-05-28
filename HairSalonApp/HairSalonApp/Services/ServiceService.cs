using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using HairSalonApp.Data;
using HairSalonApp.Helpers;

namespace HairSalonApp.Services
{
    public class ServiceService
    {
        private readonly ServiceRepository _serviceRepository;

        public ServiceService()
        {
            _serviceRepository = new ServiceRepository();
        }

        public ServiceService(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // Ανάκτηση όλων των υπηρεσιών
        public List<Service> GetAllServices()
        {
            try
            {
                return _serviceRepository.GetAll();
            }
            catch (Exception)
            {
                // Αν σκάσει η βάση, επιστρέφουμε μια άδεια λίστα για να μην κρασάρει το UI
                return new List<Service>();
            }
        }

        // Εύρεση υπηρεσίας βάσει ID (Για το Edit)
        public Service? GetServiceById(int id)
        {
            try
            {
                return _serviceRepository.GetById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Διαγραφή Υπηρεσίας
        public OperationResult DeleteService(int id)
        {
            try
            {
                bool isDeleted = _serviceRepository.Delete(id);

                if (isDeleted)
                {
                    return new OperationResult { Success = true };
                }

                return new OperationResult { Success = false, ErrorMessage = "Η υπηρεσία δεν βρέθηκε. Ίσως έχει ήδη διαγραφεί." };
            }
            catch (Exception)
            {
                // Εδώ συνήθως "χτυπάει" αν η υπηρεσία χρησιμοποιείται ήδη σε κάποιο ραντεβού
                return new OperationResult { Success = false, ErrorMessage = "Δεν είναι δυνατή η διαγραφή. Η υπηρεσία πιθανώς χρησιμοποιείται σε ραντεβού." };
            }
        }

        // Αποθήκευση Υπηρεσίας (Νέας ή Ενημέρωση)
        public OperationResult SaveService(int? id, string name, decimal price, int duration)
        {
            // 1. Καθαρισμός δεδομένων
            name = name?.Trim() ?? "";

            // 2. Validation
            if (string.IsNullOrWhiteSpace(name))
            {
                return new OperationResult { Success = false, ErrorMessage = "Το όνομα της υπηρεσίας είναι υποχρεωτικό." };
            }

            if (price < 0)
            {
                return new OperationResult { Success = false, ErrorMessage = "Η τιμή δεν μπορεί να είναι αρνητική." };
            }

            if (duration <= 0)
            {
                return new OperationResult { Success = false, ErrorMessage = "Η διάρκεια της υπηρεσίας πρέπει να είναι μεγαλύτερη από μηδέν." };
            }

            // 3. Δημιουργία του Model
            var service = new Service
            {
                Id = id ?? 0,
                ServiceName = name,
                Price = price,
                DurationMinutes = duration
            };

            // 4. Επικοινωνία με το Data Access Layer
            try
            {
                if (service.Id == 0) // Νέα υπηρεσία
                {
                    int newId = _serviceRepository.Insert(service);
                    if (newId <= 0)
                    {
                        return new OperationResult { Success = false, ErrorMessage = "Η αποθήκευση απέτυχε. Δοκιμάστε ξανά." };
                    }
                }
                else // Υπάρχουσα υπηρεσία
                {
                    bool isUpdated = _serviceRepository.Update(service);
                    if (!isUpdated)
                    {
                        return new OperationResult { Success = false, ErrorMessage = "Δεν βρέθηκε η υπηρεσία για ενημέρωση (ίσως έχει διαγραφεί)." };
                    }
                }

                return new OperationResult { Success = true };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την αποθήκευση στη βάση: " + ex.Message };
            }
        }
    }
}