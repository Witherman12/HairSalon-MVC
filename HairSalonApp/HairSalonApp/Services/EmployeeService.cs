using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using HairSalonApp.Data;
using HairSalonApp.Helpers;

namespace HairSalonApp.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Ανάκτηση όλων των υπαλλήλων
        public List<Employee> GetAllEmployees()
        {
            try
            {
                return _employeeRepository.GetAll();
            }
            catch (Exception)
            {
                // Αν σκάσει η βάση, επιστρέφουμε μια άδεια λίστα για να μην κρασάρει το UI
                return new List<Employee>();
            }
        }

        // Εύρεση υπαλλήλου βάσει ID (Για το Edit)
        public Employee? GetEmployeeById(int id)
        {
            try
            {
                return _employeeRepository.GetById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Διαγραφή Υπαλλήλου
        public OperationResult DeleteEmployee(int id)
        {
            try
            {

                bool isDeleted = _employeeRepository.Delete(id);

                if (isDeleted)
                {
                    return new OperationResult { Success = true };
                }

                return new OperationResult { Success = false, ErrorMessage = "Ο υπάλληλος δεν βρέθηκε. Ίσως έχει ήδη διαγραφεί." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την διαγραφή: " + ex.Message };
            }
        }

        // Αποθήκευση Υπαλλήλου (Νέου ή Ενημέρωση)
        public OperationResult SaveEmployee(int? id, string firstName, string lastName, string phone, string specialty)
        {
            // 1. Καθαρισμός δεδομένων
            firstName = firstName?.Trim() ?? "";
            lastName = lastName?.Trim() ?? "";
            phone = phone?.Trim() ?? "";
            specialty = specialty?.Trim() ?? "";

            // 2. Validation
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return new OperationResult { Success = false, ErrorMessage = "Το Όνομα του υπαλλήλου είναι υποχρεωτικό." };
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                return new OperationResult { Success = false, ErrorMessage = "Το Επώνυμο του υπαλλήλου είναι υποχρεωτικό." };
            }

            // --- ΝΕΟΣ ΕΛΕΓΧΟΣ ΤΗΛΕΦΩΝΟΥ ---
            if (!string.IsNullOrWhiteSpace(phone)) // Αν έχει γράψει κάτι (αν δεν είναι κενό)
            {
                // Ελέγχουμε αν έχει ακριβώς 10 χαρακτήρες ΚΑΙ αν είναι όλοι αριθμοί (digits)
                if (phone.Length != 10 || !System.Linq.Enumerable.All(phone, char.IsDigit))
                {
                    return new OperationResult { Success = false, ErrorMessage = "Το τηλέφωνο πρέπει να αποτελείται από ακριβώς 10 ψηφία (χωρίς κενά ή γράμματα)." };
                }

                // Ελέγχουμε αν ξεκινάει από τα σωστά νούμερα για Ελλάδα
                if (!phone.StartsWith("69") && !phone.StartsWith("2"))
                {
                    return new OperationResult { Success = false, ErrorMessage = "Το τηλέφωνο πρέπει να ξεκινάει από '2' (σταθερό) ή '69' (κινητό)." };
                }
            }

            // 3. Δημιουργία του Model
            var employee = new Employee
            {
                Id = id ?? 0,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Specialty = specialty
            };

            // 4. Επικοινωνία με το Data Access Layer
            try
            {
                if (employee.Id == 0) // Νέος υπάλληλος
                {
                    int newId = _employeeRepository.Insert(employee);
                    if (newId <= 0)
                    {
                        return new OperationResult { Success = false, ErrorMessage = "Η αποθήκευση απέτυχε. Δοκιμάστε ξανά." };
                    }
                }
                else // Υπάρχων υπάλληλος
                {
                    bool isUpdated = _employeeRepository.Update(employee);
                    if (!isUpdated)
                    {
                        return new OperationResult { Success = false, ErrorMessage = "Δεν βρέθηκε ο υπάλληλος για ενημέρωση (ίσως έχει διαγραφεί)." };
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