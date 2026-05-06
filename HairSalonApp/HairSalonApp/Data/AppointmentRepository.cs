using MySql.Data.MySqlClient;
using HairSalonApp.Models;

/*
GetAll: Επιστρέφει όλα τα ραντεβού σε μορφή AppointmentView.
GetById: Επιστρέφει ένα ραντεβού με βάση το ID.
GetByDate: Επιστρέφει τα ραντεβού συγκεκριμένης ημερομηνίας.
GetByEmployee: Επιστρέφει τα ραντεβού συγκεκριμένου υπαλλήλου.
Insert: Δημιουργεί νέο ραντεβού και επιστρέφει το νέο ID.
Update: Ενημερώνει υπάρχον ραντεβού.
Cancel: Ακυρώνει ραντεβού αλλάζοντας την κατάστασή του.
Complete: Ολοκληρώνει ραντεβού αλλάζοντας την κατάστασή του.
Delete: Διαγράφει ραντεβού με βάση το ID.
IsAvailable: Ελέγχει διαθεσιμότητα υπαλλήλου για νέο ραντεβού.
IsAvailableForUpdate: Ελέγχει διαθεσιμότητα υπαλλήλου κατά την ενημέρωση ραντεβού.
*/

namespace HairSalonApp.Data
{
    public class AppointmentRepository
    {
        /// <summary>
        /// Επιστρέφει μια λίστα με όλα τα ραντεβού από τη βάση δεδομένων,
        /// </summary>
        /// <returns></returns>
        public List<AppointmentView> GetAll()
        {
            List<AppointmentView> appointments = new List<AppointmentView>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.GetAll, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AppointmentView appointment = MapAppointmentView(reader);
                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        /// <summary>
        /// Επιστρέφει ένα ραντεβού με βάση το ID του.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Appointment? GetById(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.GetById, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapAppointment(reader);
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Επιστρέφει μια λίστα με όλα τα ραντεβού για μια συγκεκριμένη ημερομηνία.
        /// </summary>
        /// <param name="appDate"></param>
        /// <returns></returns>
        public List<AppointmentView> GetByDate(DateTime appDate)
        {
            List<AppointmentView> appointments = new List<AppointmentView>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.GetByDate, connection))
                {
                    command.Parameters.AddWithValue("@AppDate", appDate.Date);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AppointmentView appointment = MapAppointmentView(reader);
                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        /// <summary>
        /// Επιστρέφει μια λίστα με όλα τα ραντεβού για έναν συγκεκριμένο υπάλληλο.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public List<AppointmentView> GetByEmployee(int employeeId)
        {
            List<AppointmentView> appointments = new List<AppointmentView>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.GetByEmployee, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AppointmentView appointment = MapAppointmentView(reader);
                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        /// <summary>
        /// Επιστρέφει μια λίστα με όλα τα ραντεβού για έναν συγκεκριμένο πελάτη.
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public int Insert(Appointment appointment)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.Insert, connection))
                {
                    AddAppointmentParameters(command, appointment);

                    command.ExecuteNonQuery();
                }

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Common.LastInsertId, connection))
                {
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        /// <summary>
        /// Ενημερώνει τα στοιχεία ενός υπάρχοντος ραντεβού στη βάση δεδομένων.
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public bool Update(Appointment appointment)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.Update, connection))
                {
                    command.Parameters.AddWithValue("@Id", appointment.Id);
                    AddAppointmentParameters(command, appointment);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Διαγράφει ένα ραντεβού από τη βάση δεδομένων με βάση το ID του.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Cancel(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.Cancel, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Ενημερώνει την κατάσταση ενός ραντεβού σε "Ολοκληρωμένο" με βάση το ID του.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Complete(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.Complete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Διαγράφει ένα ραντεβού από τη βάση δεδομένων με βάση το ID του.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.Delete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Ελέγχει αν ένας υπάλληλος έχει ήδη ένα ενεργό ραντεβού που επικαλύπτεται
        /// με την νέα ώρα ραντεβού. Η διάρκεια του νέου ραντεβού περνάει ως λεπτά.
        /// Εάν αυτή η μέθοδος επιστρέψει false, τότε το slot ραντεβού δεν είναι διαθέσιμο.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="appDate"></param>
        /// <param name="newStartTime"></param>
        /// <param name="newDurationMinutes"></param>
        /// <returns></returns>
        public bool IsAvailable(int employeeId, DateTime appDate, TimeSpan newStartTime, int newDurationMinutes)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.CheckAvailability, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@AppDate", appDate.Date);
                    command.Parameters.AddWithValue("@NewStartTime", newStartTime);
                    command.Parameters.AddWithValue("@NewDurationMinutes", newDurationMinutes);

                    object result = command.ExecuteScalar();
                    int conflicts = Convert.ToInt32(result);

                    return conflicts == 0;
                }
            }
        }

        /// <summary>
        /// Ελέγχει αν ένας υπάλληλος έχει ήδη ένα ενεργό ραντεβού που επικαλύπτεται
        /// με τη νέα ώρα ραντεβού, εξαιρώντας το τρέχον ραντεβού που ενημερώνεται. Η διάρκεια του νέου ραντεβού περνάει ως λεπτά.
        /// Εάν αυτή η μέθοδος επιστρέψει false, τότε το slot ραντεβού δεν είναι διαθέσιμο.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="employeeId"></param>
        /// <param name="appDate"></param>
        /// <param name="newStartTime"></param>
        /// <param name="newDurationMinutes"></param>
        /// <returns></returns>
        public bool IsAvailableForUpdate(int appointmentId, int employeeId, DateTime appDate, TimeSpan newStartTime, int newDurationMinutes)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Appointments.CheckAvailabilityForUpdate, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@AppDate", appDate.Date);
                    command.Parameters.AddWithValue("@NewStartTime", newStartTime);
                    command.Parameters.AddWithValue("@NewDurationMinutes", newDurationMinutes);

                    object result = command.ExecuteScalar();
                    int conflicts = Convert.ToInt32(result);

                    return conflicts == 0;
                }
            }
        }
        
        //+++ Τα παρακάτω για εσωτερική χρήση εντός της κλάσης +++//
        /// <summary>
        /// Χρησιμοποιείται για να μετατρέψει τα δεδομένα από τον MySqlDataReader σε ένα αντικείμενο Appointment.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Appointment MapAppointment(MySqlDataReader reader)
        {
            Appointment appointment = new Appointment();

            appointment.Id = Convert.ToInt32(reader["Id"]);
            appointment.CustomerId = Convert.ToInt32(reader["CustomerId"]);
            appointment.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
            appointment.ServiceId = Convert.ToInt32(reader["ServiceId"]);
            appointment.AppDate = Convert.ToDateTime(reader["AppDate"]);
            appointment.AppTime = GetTimeSpan(reader["AppTime"]);
            appointment.Status = Convert.ToString(reader["Status"]) ?? string.Empty;

            return appointment;
        }

        /// <summary>
        /// Χρησιμοποιείται για να μετατρέψει τα δεδομένα από τον MySqlDataReader σε ένα αντικείμενο AppointmentView,
        /// το οποίο περιλαμβάνει και ονόματα πελάτη, υπαλλήλου και υπηρεσίας.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private AppointmentView MapAppointmentView(MySqlDataReader reader)
        {
            AppointmentView appointment = new AppointmentView();

            appointment.Id = Convert.ToInt32(reader["Id"]);
            appointment.AppDate = Convert.ToDateTime(reader["AppDate"]);
            appointment.AppTime = GetTimeSpan(reader["AppTime"]);
            appointment.Status = Convert.ToString(reader["Status"]) ?? string.Empty;

            appointment.CustomerId = Convert.ToInt32(reader["CustomerId"]);
            appointment.CustomerName = Convert.ToString(reader["CustomerName"]) ?? string.Empty;
            appointment.CustomerPhone = Convert.ToString(reader["CustomerPhone"]) ?? string.Empty;

            appointment.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
            appointment.EmployeeName = Convert.ToString(reader["EmployeeName"]) ?? string.Empty;

            appointment.ServiceId = Convert.ToInt32(reader["ServiceId"]);
            appointment.ServiceName = Convert.ToString(reader["ServiceName"]) ?? string.Empty;
            appointment.Price = Convert.ToDecimal(reader["Price"]);
            appointment.DurationMinutes = Convert.ToInt32(reader["DurationMinutes"]);

            return appointment;
        }

        /// <summary>
        /// Χρησιμοποιείται για να προσθέσει τις παραμέτρους ενός αντικειμένου Appointment σε ένα MySqlCommand.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="appointment"></param>
        private void AddAppointmentParameters(MySqlCommand command, Appointment appointment)
        {
            command.Parameters.AddWithValue("@CustomerId", appointment.CustomerId);
            command.Parameters.AddWithValue("@EmployeeId", appointment.EmployeeId);
            command.Parameters.AddWithValue("@ServiceId", appointment.ServiceId);
            command.Parameters.AddWithValue("@AppDate", appointment.AppDate.Date);
            command.Parameters.AddWithValue("@AppTime", appointment.AppTime);

            if (string.IsNullOrWhiteSpace(appointment.Status))
            {
                command.Parameters.AddWithValue("@Status", "Ενεργό");
            }
            else
            {
                command.Parameters.AddWithValue("@Status", appointment.Status);
            }
        }

        /// <summary>
        /// Ελέγχει αν ένας υπάλληλος έχει ήδη ένα ενεργό ραντεβού που επικαλύπτεται
        /// με τη νέα ώρα ραντεβού, εξαιρώντας το τρέχον ραντεβού που ενημερώνεται. Η διάρκεια του νέου ραντεβού περνάει ως λεπτά.
        /// Εάν αυτή η μέθοδος επιστρέψει false, τότε το slot ραντεβού δεν είναι διαθέσιμο.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private TimeSpan GetTimeSpan(object value)
        {
            if (value is TimeSpan)
            {
                return (TimeSpan)value;
            }

            string? text = value.ToString();
            return string.IsNullOrWhiteSpace(text) ? TimeSpan.Zero : TimeSpan.Parse(text);
        }
    }
}
