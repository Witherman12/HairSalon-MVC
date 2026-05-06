using MySql.Data.MySqlClient;

/*
GetConnection: Δημιουργεί και επιστρέφει MySqlConnection για τη βάση.
TestConnection: Ελέγχει αν η σύνδεση με τη βάση λειτουργεί και επιστρέφει μήνυμα.
*/

namespace HairSalonApp.Data
{
    public static class Database
    {
        private const string ConnectionString =
            "server=localhost;" +
            "port=3306;" +
            "database=hair_salon_db;" +
            "uid=root;" +
            "pwd=;" +
            "charset=utf8mb4;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static bool TestConnection(out string message)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    message = "Η σύνδεση με τη βάση δεδομένων ήταν επιτυχής.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = "Σφάλμα σύνδεσης με τη βάση δεδομένων: " + ex.Message;
                return false;
            }
        }
    }
}
