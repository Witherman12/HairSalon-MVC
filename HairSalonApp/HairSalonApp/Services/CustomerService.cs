using System;
using System.Text.RegularExpressions;
using HairSalonApp.Models;
using HairSalonApp.Data;
using HairSalonApp.Helpers;

namespace HairSalonApp.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        // Ανάκτηση όλων των πελατών
        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _customerRepository.GetAll();
            }
            catch (Exception)
            {
                // Αν σκάσει η βάση, επιστρέφουμε μια άδεια λίστα για να μην κρασάρει το UI
                return new List<Customer>();
            }
        }

        // Εύρεση πελάτη βάσει ID (Για το Edit)
        public Customer? GetCustomerById(int id)
        {
            try
            {
                return _customerRepository.GetById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Αναζήτηση πελατών
        public List<Customer> SearchCustomers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllCustomers(); // Αν το πεδίο αναζήτησης είναι κενό, φέρε τους όλους
            }

            try
            {
                return _customerRepository.Search(keyword.Trim());
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }

        // Διαγραφή Πελάτη
        public OperationResult DeleteCustomer(int id)
        {
            try
            {
                // ΣΗΜΕΙΩΣΗ: Εδώ στο μέλλον μπορούμε να προσθέσουμε έλεγχο 
                // αν ο πελάτης έχει ενεργά ραντεβού πριν τον διαγράψουμε!

                bool isDeleted = _customerRepository.Delete(id);

                if (isDeleted)
                {
                    return new OperationResult { Success = true };
                }

                return new OperationResult { Success = false, ErrorMessage = "Ο πελάτης δεν βρέθηκε. Ίσως έχει ήδη διαγραφεί." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την διαγραφή: " + ex.Message };
            }
        }

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public OperationResult SaveCustomer(int? id, string firstName, string lastName, string phone, string email, string notes)
        {
            // 1. Καθαρισμός δεδομένων
            firstName = firstName?.Trim() ?? "";
            lastName = lastName?.Trim() ?? "";
            phone = phone?.Trim() ?? "";
            email = email?.Trim() ?? "";
            notes = notes?.Trim() ?? "";

            // 2. Validation
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return new OperationResult { Success = false, ErrorMessage = "Το Όνομα του πελάτη είναι υποχρεωτικό." };
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                return new OperationResult { Success = false, ErrorMessage = "Το Τηλέφωνο είναι υποχρεωτικό." };
            }

            if (!Regex.IsMatch(phone, @"^[0-9]{10}$"))
            {
                return new OperationResult { Success = false, ErrorMessage = "Το τηλέφωνο πρέπει να αποτελείται ακριβώς από 10 ψηφία." };
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return new OperationResult { Success = false, ErrorMessage = "Το Email δεν έχει έγκυρη μορφή." };
                }
            }

            // 3. Δημιουργία του Model
            var customer = new Customer
            {
                Id = id ?? 0,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Email = email,
                Notes = notes
            };

            // 4. Επικοινωνία με το Data Access Layer με βάση το screenshot σου
            try
            {
                if (customer.Id == 0) // Νέος πελάτης
                {
                    int newId = _customerRepository.Insert(customer);
                    if (newId <= 0)
                    {
                        return new OperationResult { Success = false, ErrorMessage = "Η αποθήκευση απέτυχε. Δοκιμάστε ξανά." };
                    }
                }
                else // Υπάρχων πελάτης
                {
                    bool isUpdated = _customerRepository.Update(customer);
                    if (!isUpdated)
                    {
                        return new OperationResult { Success = false, ErrorMessage = "Δεν βρέθηκε ο πελάτης για ενημέρωση (ίσως έχει διαγραφεί)." };
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