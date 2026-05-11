using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using HairSalonApp.Data;
using HairSalonApp.Helpers;

namespace HairSalonApp.Services
{
    public class ServiceService
    {
        private readonly ServiceRepository _repo = new ServiceRepository();

        public List<Service> GetAllServices()
        {
            try { return _repo.GetAll(); }
            catch { return new List<Service>(); }
        }

        public OperationResult SaveService(int? id, string name, decimal price, int duration)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(name))
                return new OperationResult { Success = false, ErrorMessage = "Το όνομα της υπηρεσίας είναι υποχρεωτικό." };

            if (price < 0)
                return new OperationResult { Success = false, ErrorMessage = "Η τιμή δεν μπορεί να είναι αρνητική." };

            var service = new Service
            {
                Id = id ?? 0,
                ServiceName = name.Trim(),
                Price = price,
                DurationMinutes = duration
            };

            try
            {
                if (service.Id == 0)
                {
                    int newId = _repo.Insert(service);
                    return newId > 0 ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Η εισαγωγή απέτυχε." };
                }
                else
                {
                    bool success = _repo.Update(service);
                    return success ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Η ενημέρωση απέτυχε." };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public OperationResult DeleteService(int id)
        {
            try
            {
                bool success = _repo.Delete(id);
                return success ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Η διαγραφή απέτυχε." };
            }
            catch (Exception ex)
            {
                // Εδώ συνήθως "χτυπάει" αν η υπηρεσία χρησιμοποιείται ήδη σε κάποιο ραντεβού
                return new OperationResult { Success = false, ErrorMessage = "Δεν είναι δυνατή η διαγραφή. Η υπηρεσία πιθανώς χρησιμοποιείται σε ραντεβού." };
            }
        }
    }
}