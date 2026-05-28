using MySql.Data.MySqlClient;
using HairSalonApp.Models;

/*
Login: Ελέγχει στοιχεία σύνδεσης και επιστρέφει τον χρήστη.
GetAll: Επιστρέφει όλους τους χρήστες.
GetById: Επιστρέφει χρήστη με βάση το ID.
Insert: Δημιουργεί νέο χρήστη και επιστρέφει το νέο ID.
Update: Ενημερώνει υπάρχοντα χρήστη.
Delete: Διαγράφει χρήστη με βάση το ID.
*/

namespace HairSalonApp.Data
{
    public class UserRepository
    {
        /// <summary>
        /// Επιστρέφει έναν χρήστη με βάση το όνομα χρήστη και τον κωδικό πρόσβασης.
        /// Εάν δεν βρεθεί, επιστρέφει null.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual User? Login(string username, string password)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Users.Login, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUser(reader);
                        }
                    }
                }
            }

            return null;
        }

        // =========================================================================
        // ΝΕΑ ΜΕΘΟΔΟΣ ΓΙΑ ΤΟ BCRYPT (Βρίσκει τον χρήστη ΜΟΝΟ από το Username)
        // =========================================================================
        /// <summary>
        /// Επιστρέφει έναν χρήστη με βάση ΜΟΝΟ το όνομα χρήστη. 
        /// Χρησιμοποιείται για την επαλήθευση κωδικού με BCrypt.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public virtual User? GetByUsername(string username)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Users.GetByUsername, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUser(reader);
                        }
                    }
                }
            }

            return null;
        }
        // =========================================================================

        /// <summary>
        /// Επιστρέφει μια λίστα με όλους τους χρήστες από τη βάση δεδομένων.
        /// </summary>
        /// <returns></returns>
        public virtual List<User> GetAll()
        {
            List<User> users = new List<User>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Users.GetAll, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = MapUser(reader);
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        /// <summary>
        /// Επιστρέφει έναν χρήστη με βάση το ID του.
        /// Εάν δεν βρεθεί, επιστρέφει null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual User? GetById(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Users.GetById, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUser(reader);
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Εισάγει έναν νέο χρήστη στη βάση δεδομένων και επιστρέφει το ID της νέας εγγραφής.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual int Insert(User user)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Users.Insert, connection))
                {
                    AddUserParameters(command, user);

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
        /// Ενημερώνει τα στοιχεία ενός υπάρχοντος χρήστη στη βάση δεδομένων.
        /// Επιστρέφει true εάν η ενημέρωση ήταν επιτυχής, διαφορετικά false.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Users.Update, connection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    AddUserParameters(command, user);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Διαγράφει έναν χρήστη από τη βάση δεδομένων με βάση το ID του.
        /// Επιστρέφει true εάν η διαγραφή ήταν επιτυχής, διαφορετικά false.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Users.Delete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        
        //+++ Τα παρακάτω για εσωτερική χρήση εντός της κλάσης +++//
        /// <summary>
        /// Χρησιμοποιείται για να μετατρέψει τα δεδομένα από τον MySqlDataReader σε ένα αντικείμενο User.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private User MapUser(MySqlDataReader reader)
        {
            User user = new User();

            user.Id = Convert.ToInt32(reader["Id"]);
            user.Username = Convert.ToString(reader["Username"]) ?? string.Empty;
            user.Password = HasColumn(reader, "Password") && reader["Password"] != DBNull.Value
                ? Convert.ToString(reader["Password"]) ?? string.Empty
                : string.Empty;
            user.Role = Convert.ToString(reader["Role"]) ?? string.Empty;

            return user;
        }

        private bool HasColumn(MySqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (string.Equals(reader.GetName(i), columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Προσθέτει τις παραμέτρους ενός αντικειμένου User σε ένα MySqlCommand.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="user"></param>
        private void AddUserParameters(MySqlCommand command, User user)
        {
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Role", user.Role);
        }
    }
}