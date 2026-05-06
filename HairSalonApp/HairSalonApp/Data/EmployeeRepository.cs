/*
GetAll: Επιστρέφει όλους τους υπαλλήλους.
GetById: Επιστρέφει υπάλληλο με βάση το ID.
Insert: Δημιουργεί νέο υπάλληλο και επιστρέφει το νέο ID.
Update: Ενημερώνει υπάρχοντα υπάλληλο.
Delete: Διαγράφει υπάλληλο με βάση το ID.
*/

using MySql.Data.MySqlClient;
using HairSalonApp.Models;

namespace HairSalonApp.Data
{
    public class EmployeeRepository
    {
        /// <summary>
        /// Επιστρέφει μια λίστα με όλους τους υπαλλήλους από τη βάση δεδομένων.
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Employees.GetAll, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = MapEmployee(reader);
                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }

        /// <summary>
        /// Επιστρέφει έναν υπάλληλο με βάση το ID του.
        /// Εάν δεν βρεθεί, επιστρέφει null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee? GetById(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Employees.GetById, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapEmployee(reader);
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Εισάγει έναν νέο υπάλληλο στη βάση δεδομένων και επιστρέφει το ID της νέας εγγραφής.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int Insert(Employee employee)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Employees.Insert, connection))
                {
                    AddEmployeeParameters(command, employee);

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
        /// Ενημερώνει τα στοιχεία ενός υπάρχοντος υπαλλήλου στη βάση δεδομένων.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Update(Employee employee)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Employees.Update, connection))
                {
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    AddEmployeeParameters(command, employee);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Διαγράφει έναν υπάλληλο από τη βάση δεδομένων με βάση το ID του.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(SqlQueries.Employees.Delete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        //+++ Τα παρακάτω για εσωτερική χρήση εντός της κλάσης +++//
        /// <summary>
        /// Χαρτογραφεί τα δεδομένα από τον MySqlDataReader σε ένα αντικείμενο Employee.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Employee MapEmployee(MySqlDataReader reader)
        {
            Employee employee = new Employee();

            employee.Id = Convert.ToInt32(reader["Id"]);
            employee.FirstName = Convert.ToString(reader["FirstName"]) ?? string.Empty;
            employee.LastName = Convert.ToString(reader["LastName"]) ?? string.Empty;

            if (reader["Specialty"] == DBNull.Value)
            {
                employee.Specialty = null;
            }
            else
            {
                employee.Specialty = Convert.ToString(reader["Specialty"]);
            }

            if (reader["Phone"] == DBNull.Value)
            {
                employee.Phone = null;
            }
            else
            {
                employee.Phone = Convert.ToString(reader["Phone"]);
            }

            return employee;
        }

        /// <summary>
        /// Προσθέτει τις παραμέτρους ενός αντικειμένου Employee σε ένα MySqlCommand.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="employee"></param>
        private void AddEmployeeParameters(MySqlCommand command, Employee employee)
        {
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);

            if (string.IsNullOrWhiteSpace(employee.Specialty))
            {
                command.Parameters.AddWithValue("@Specialty", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Specialty", employee.Specialty);
            }

            if (string.IsNullOrWhiteSpace(employee.Phone))
            {
                command.Parameters.AddWithValue("@Phone", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Phone", employee.Phone);
            }
        }
    }
}
