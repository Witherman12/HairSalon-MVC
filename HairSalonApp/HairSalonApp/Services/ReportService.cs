using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using HairSalonApp.Data;

namespace HairSalonApp.Services
{
    public class ReportService
    {
        private readonly ReportRepository _reportRepo = new ReportRepository();

        /// <summary>
        /// Επιστρέφει το συνολικό έσοδο από ολοκληρωμένα ραντεβού.
        /// </summary>
        public decimal GetTotalRevenue()
        {
            try
            {
                return _reportRepo.GetTotalRevenue();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetTotalRevenue: " + ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Επιστρέφει πλήθος ραντεβού ανά ημερομηνία.
        /// </summary>
        public List<AppointmentsByDateReport> GetAppointmentsByDate()
        {
            try
            {
                return _reportRepo.GetAppointmentsByDate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAppointmentsByDate: " + ex.Message);
                return new List<AppointmentsByDateReport>();
            }
        }

        /// <summary>
        /// Επιστρέφει πλήθος ραντεβού ανά υπάλληλο.
        /// </summary>
        public List<EmployeeAppointmentsReport> GetAppointmentsByEmployee()
        {
            try
            {
                return _reportRepo.GetAppointmentsByEmployee();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAppointmentsByEmployee: " + ex.Message);
                return new List<EmployeeAppointmentsReport>();
            }
        }

        /// <summary>
        /// Επιστρέφει τις πιο δημοφιλείς υπηρεσίες βάσει χρήσης.
        /// </summary>
        public List<ServiceUsageReport> GetPopularServices()
        {
            try
            {
                return _reportRepo.GetPopularServices();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetPopularServices: " + ex.Message);
                return new List<ServiceUsageReport>();
            }
        }

        /// <summary>
        /// Επιστρέφει έσοδα ανά υπηρεσία.
        /// </summary>
        public List<RevenueByServiceReport> GetRevenueByService()
        {
            try
            {
                return _reportRepo.GetRevenueByService();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetRevenueByService: " + ex.Message);
                return new List<RevenueByServiceReport>();
            }
        }
    }
}