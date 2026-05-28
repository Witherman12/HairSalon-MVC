using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using HairSalonApp.Data;

namespace HairSalonApp.Services
{
    public class ReportService
    {
        private readonly ReportRepository _reportRepository;

        public ReportService()
        {
            _reportRepository = new ReportRepository();
        }

        public ReportService(ReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        // Επιστρέφει το συνολικό έσοδο από ολοκληρωμένα ραντεβού
        public decimal GetTotalRevenue()
        {
            try
            {
                return _reportRepository.GetTotalRevenue();
            }
            catch (Exception)
            {
                // Αν σκάσει η βάση, επιστρέφουμε 0 για να μην κρασάρει το UI
                return 0;
            }
        }

        // Επιστρέφει πλήθος ραντεβού ανά ημερομηνία
        public List<AppointmentsByDateReport> GetAppointmentsByDate()
        {
            try
            {
                return _reportRepository.GetAppointmentsByDate();
            }
            catch (Exception)
            {
                return new List<AppointmentsByDateReport>();
            }
        }

        // Επιστρέφει πλήθος ραντεβού ανά υπάλληλο
        public List<EmployeeAppointmentsReport> GetAppointmentsByEmployee()
        {
            try
            {
                return _reportRepository.GetAppointmentsByEmployee();
            }
            catch (Exception)
            {
                return new List<EmployeeAppointmentsReport>();
            }
        }

        // Επιστρέφει τις πιο δημοφιλείς υπηρεσίες βάσει χρήσης
        public List<ServiceUsageReport> GetPopularServices()
        {
            try
            {
                return _reportRepository.GetPopularServices();
            }
            catch (Exception)
            {
                return new List<ServiceUsageReport>();
            }
        }

        // Επιστρέφει έσοδα ανά υπηρεσία
        public List<RevenueByServiceReport> GetRevenueByService()
        {
            try
            {
                return _reportRepository.GetRevenueByService();
            }
            catch (Exception)
            {
                return new List<RevenueByServiceReport>();
            }
        }
    }
}