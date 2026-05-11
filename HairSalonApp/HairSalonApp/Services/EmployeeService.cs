using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using HairSalonApp.Data;
using HairSalonApp.Helpers;

namespace HairSalonApp.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repo;

        public EmployeeService()
        {
            _repo = new EmployeeRepository();
        }

        public List<Employee> GetAllEmployees()
        {
            try { return _repo.GetAll(); }
            catch { return new List<Employee>(); }
        }

        public OperationResult SaveEmployee(int? id, string firstName, string lastName, string phone, string specialty)
        {
            // Απλό validation
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                return new OperationResult { Success = false, ErrorMessage = "Όνομα και Επώνυμο είναι υποχρεωτικά." };

            var emp = new Employee
            {
                Id = id ?? 0,
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                Phone = phone?.Trim(),
                Specialty = specialty?.Trim()
            };

            try
            {
                if (emp.Id == 0)
                {
                    int newId = _repo.Insert(emp);
                    return newId > 0 ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την εισαγωγή." };
                }
                else
                {
                    bool success = _repo.Update(emp);
                    return success ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Σφάλμα κατά την ενημέρωση." };
                }
            }
            catch (Exception ex) { return new OperationResult { Success = false, ErrorMessage = ex.Message }; }
        }

        public OperationResult DeleteEmployee(int id)
        {
            try
            {
                bool success = _repo.Delete(id);
                return success ? new OperationResult { Success = true } : new OperationResult { Success = false, ErrorMessage = "Η διαγραφή απέτυχε." };
            }
            catch (Exception ex) { return new OperationResult { Success = false, ErrorMessage = ex.Message }; }
        }
    }
}