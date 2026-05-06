using MySql.Data.MySqlClient;
using HairSalonApp.Models;

/*
GetAppointmentsByDate: Επιστρέφει πλήθος ραντεβού ανά ημερομηνία.
GetTotalRevenue: Υπολογίζει τα συνολικά έσοδα από ολοκληρωμένα ραντεβού.
GetAppointmentsByEmployee: Επιστρέφει πλήθος ραντεβού ανά υπάλληλο.
GetPopularServices: Επιστρέφει τις υπηρεσίες με βάση τη χρήση τους.
GetRevenueByService: Επιστρέφει έσοδα ανά υπηρεσία.
*/

namespace HairSalonApp.Data
{
    public class ReportRepository
    {
        /// <summary>
        /// Επιστρέφει μια λίστα με τον αριθμό των ραντεβού ανά ημερομηνία.
        /// Κάθε αντικείμενο στη λίστα περιέχει την ημερομηνία και τον συνολικό αριθμό ραντεβού για αυτήν την ημερομηνία.
        /// </summary>
        /// <returns></returns>
        public List<AppointmentsByDateReport> GetAppointmentsByDate()
        {
            List<AppointmentsByDateReport> reports = new List<AppointmentsByDateReport>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Reports.AppointmentsByDate, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AppointmentsByDateReport report = new AppointmentsByDateReport();

                            report.AppDate = Convert.ToDateTime(reader["AppDate"]);
                            report.TotalAppointments = Convert.ToInt32(reader["TotalAppointments"]);

                            reports.Add(report);
                        }
                    }
                }
            }

            return reports;
        }

        /// <summary>
        /// Επιστρέφει το συνολικό έσοδο από όλα τα ραντεβού που έχουν ολοκληρωθεί.
        /// Εάν δεν υπάρχουν ολοκληρωμένα ραντεβού, επιστρέφει 0.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalRevenue()
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Reports.TotalRevenue, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        return 0;
                    }

                    return Convert.ToDecimal(result);
                }
            }
        }

        /// <summary>
        /// Επιστρέφει μια λίστα με τον αριθμό των ραντεβού ανά εργαζόμενο.
        /// Κάθε αντικείμενο στη λίστα περιέχει το όνομα του εργαζόμενου και τον συνολικό αριθμό ραντεβού του.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeAppointmentsReport> GetAppointmentsByEmployee()
        {
            List<EmployeeAppointmentsReport> reports = new List<EmployeeAppointmentsReport>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Reports.AppointmentsByEmployee, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeAppointmentsReport report = new EmployeeAppointmentsReport();

                            report.EmployeeName = Convert.ToString(reader["EmployeeName"]) ?? string.Empty;
                            report.TotalAppointments = Convert.ToInt32(reader["TotalAppointments"]);

                            reports.Add(report);
                        }
                    }
                }
            }

            return reports;
        }

        /// <summary>
        /// Επιστρέφει μια λίστα με τις πιο δημοφιλείς υπηρεσίες, δηλαδή τις υπηρεσίες που έχουν τον μεγαλύτερο αριθμό ραντεβού.
        /// Κάθε αντικείμενο στη λίστα περιέχει το όνομα της υπηρεσίας και τον συνολικό αριθμό ραντεβού που έχει αυτή η υπηρεσία.
        /// Η λίστα είναι ταξινομημένη κατά φθίνουσα σειρά του αριθμού ραντεβού.
        /// </summary>
        /// <returns></returns>
        public List<ServiceUsageReport> GetPopularServices()
        {
            List<ServiceUsageReport> reports = new List<ServiceUsageReport>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Reports.PopularServices, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ServiceUsageReport report = new ServiceUsageReport();

                            report.ServiceName = Convert.ToString(reader["ServiceName"]) ?? string.Empty;
                            report.TotalAppointments = Convert.ToInt32(reader["TotalAppointments"]);

                            reports.Add(report);
                        }
                    }
                }
            }

            return reports;
        }

        /// <summary>
        /// Επιστρέφει μια λίστα με τα έσοδα ανά υπηρεσία.
        /// </summary>
        /// <returns></returns>
        public List<RevenueByServiceReport> GetRevenueByService()
        {
            List<RevenueByServiceReport> reports = new List<RevenueByServiceReport>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Reports.RevenueByService, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RevenueByServiceReport report = new RevenueByServiceReport();

                            report.ServiceName = Convert.ToString(reader["ServiceName"]) ?? string.Empty;
                            report.CompletedAppointments = Convert.ToInt32(reader["CompletedAppointments"]);
                            report.Revenue = Convert.ToDecimal(reader["Revenue"]);

                            reports.Add(report);
                        }
                    }
                }
            }

            return reports;
        }
    }
}
