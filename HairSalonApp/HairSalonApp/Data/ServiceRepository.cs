using MySql.Data.MySqlClient;
using HairSalonApp.Models;

/*
GetAll: Επιστρέφει όλες τις υπηρεσίες.
GetById: Επιστρέφει υπηρεσία με βάση το ID.
Insert: Δημιουργεί νέα υπηρεσία και επιστρέφει το νέο ID.
Update: Ενημερώνει υπάρχουσα υπηρεσία.
Delete: Διαγράφει υπηρεσία με βάση το ID.
*/

namespace HairSalonApp.Data
{
    public class ServiceRepository
    {
        /// <summary>
        /// Επιστρέφει μια λίστα με όλους τις υπηρεσίες από τη βάση δεδομένων.
        /// </summary>
        /// <returns></returns>
        public List<Service> GetAll()
        {
            List<Service> services = new List<Service>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Services.GetAll, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Service service = MapService(reader);
                            services.Add(service);
                        }
                    }
                }
            }

            return services;
        }
        
        /// <summary>
        /// Επιστρέφει μια υπηρεσία με βάση το ID της. Εάν δεν βρεθεί, επιστρέφει null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Service? GetById(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Services.GetById, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapService(reader);
                        }
                    }
                }
            }

            return null;
        }
        
        /// <summary>
        /// Εισάγει μια νέα υπηρεσία στη βάση δεδομένων και επιστρέφει το ID της νέας εγγραφής.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public int Insert(Service service)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Services.Insert, connection))
                {
                    AddServiceParameters(command, service);

                    command.ExecuteNonQuery();
                }

                using (MySqlCommand command = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                {
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        /// <summary>
        /// Ενημερώνει τα στοιχεία μιας υπάρχουσας υπηρεσίας στη βάση δεδομένων.
        /// Επιστρέφει true εάν η ενημέρωση ήταν επιτυχής, διαφορετικά false.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public bool Update(Service service)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Services.Update, connection))
                {
                    command.Parameters.AddWithValue("@Id", service.Id);
                    AddServiceParameters(command, service);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Διαγράφει μια υπηρεσία από τη βάση δεδομένων με βάση το ID της.
        /// Επιστρέφει true εάν η διαγραφή ήταν επιτυχής, διαφορετικά false.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Services.Delete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        ////+++ Τα παρακάτω για εσωτερική χρήση εντός της κλάσης +++//
        /// <summary>
        /// Χρησιμοποιείται για να μετατρέψει τα δεδομένα από τον MySqlDataReader σε ένα αντικείμενο Service.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Service MapService(MySqlDataReader reader)
        {
            Service service = new Service();

            service.Id = Convert.ToInt32(reader["Id"]);
            service.ServiceName = Convert.ToString(reader["ServiceName"]) ?? string.Empty;
            service.Price = Convert.ToDecimal(reader["Price"]);
            service.DurationMinutes = Convert.ToInt32(reader["DurationMinutes"]);

            return service;
        }

        /// <summary>
        /// Προσθέτει τις παραμέτρους ενός αντικειμένου Service σε ένα MySqlCommand.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="service"></param>
        private void AddServiceParameters(MySqlCommand command, Service service)
        {
            command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
            command.Parameters.AddWithValue("@Price", service.Price);
            command.Parameters.AddWithValue("@DurationMinutes", service.DurationMinutes);
        }
    }
}
