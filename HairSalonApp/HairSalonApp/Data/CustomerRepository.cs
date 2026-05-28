using MySql.Data.MySqlClient;
using HairSalonApp.Models;

/*
GetAll: Επιστρέφει όλους τους πελάτες.
GetById: Επιστρέφει πελάτη με βάση το ID.
Search: Αναζητά πελάτες με βάση κείμενο.
Insert: Δημιουργεί νέο πελάτη και επιστρέφει το νέο ID.
Update: Ενημερώνει υπάρχοντα πελάτη.
Delete: Διαγράφει πελάτη με βάση το ID.
*/

namespace HairSalonApp.Data
{
    public class CustomerRepository
    {
        /// <summary>
        /// Επιστρέφει μια λίστα με όλους τους πελάτες από τη βάση δεδομένων.
        /// </summary>
        /// <returns></returns>
        public virtual List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Customers.GetAll, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = MapCustomer(reader);
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }

        /// <summary>
        /// Επιστρέφει έναν πελάτη με βάση το ID του. Εάν δεν βρεθεί, επιστρέφει null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Customer? GetById(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Customers.GetById, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapCustomer(reader);
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Επιστρέφει μια λίστα με πελάτες που ταιριάζουν με το κείμενο αναζήτησης.
        /// Η αναζήτηση γίνεται στα πεδία FirstName, LastName και Phone.
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public virtual List<Customer> Search(string searchText)
        {
            List<Customer> customers = new List<Customer>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Customers.Search, connection))
                {
                    command.Parameters.AddWithValue("@SearchText", searchText);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = MapCustomer(reader);
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }

        /// <summary>
        /// Εισάγει έναν νέο πελάτη στη βάση δεδομένων και επιστρέφει το ID του νέου πελάτη.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public virtual int Insert(Customer customer)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Customers.Insert, connection))
                {
                    AddCustomerParameters(command, customer);

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
        /// Ενημερώνει τα στοιχεία ενός υπάρχοντος πελάτη στη βάση δεδομένων.
        /// Επιστρέφει true εάν η ενημέρωση ήταν επιτυχής, διαφορετικά false.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public virtual bool Update(Customer customer)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Customers.Update, connection))
                {
                    command.Parameters.AddWithValue("@Id", customer.Id);
                    AddCustomerParameters(command, customer);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Διαγράφει έναν πελάτη από τη βάση δεδομένων με βάση το ID του.
        /// Επιστρέφει true εάν η διαγραφή ήταν επιτυχής, διαφορετικά false.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Customers.Delete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        //+++ Τα παρακάτω για εσωτερική χρήση εντός της κλάσης +++//
        /// <summary>
        /// Χρησιμοποιείται για να μετατρέψει τα δεδομένα από τον MySqlDataReader σε ένα αντικείμενο Customer.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Customer MapCustomer(MySqlDataReader reader)
        {
            Customer customer = new Customer();

            customer.Id = Convert.ToInt32(reader["Id"]);
            customer.FirstName = Convert.ToString(reader["FirstName"]) ?? string.Empty;
            customer.LastName = Convert.ToString(reader["LastName"]) ?? string.Empty;
            customer.Phone = Convert.ToString(reader["Phone"]) ?? string.Empty;

            if (reader["Email"] == DBNull.Value)
            {
                customer.Email = null;
            }
            else
            {
                customer.Email = Convert.ToString(reader["Email"]);
            }

            if (reader["Notes"] == DBNull.Value)
            {
                customer.Notes = null;
            }
            else
            {
                customer.Notes = Convert.ToString(reader["Notes"]);
            }

            return customer;
        }

        /// <summary>
        /// Χρησιμοποιείται για να προσθέσει τις παραμέτρους ενός αντικειμένου Customer σε ένα MySqlCommand.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="customer"></param>
        private void AddCustomerParameters(MySqlCommand command, Customer customer)
        {
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@Phone", customer.Phone);

            if (string.IsNullOrWhiteSpace(customer.Email))
            {
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", customer.Email);
            }

            if (string.IsNullOrWhiteSpace(customer.Notes))
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", customer.Notes);
            }
        }
    }
}
