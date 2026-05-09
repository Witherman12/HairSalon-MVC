//using System.Text;
using System;
using System.Windows.Forms;
using HairSalonApp.Data; // Απαραίτητο για να βλέπει την κλάση Database

namespace HairSalonApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            /*
                //Aν τα ελληνικά εμφανίζονται σπασμένα, κάνε uncomment εδώ και το using System.Text
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;
            */

            // Αρχικοποίηση ρυθμίσεων (DPI, fonts κτλ)
            ApplicationConfiguration.Initialize();

            // 1. Έλεγχος αν η βάση δεδομένων είναι διαθέσιμη
            string dbMessage;
            bool isConnected = Database.TestConnection(out dbMessage);

            if (isConnected)
            {
                // Εμφάνιση της φόρμας Login
                using (var loginForm = new LoginForm())
                {
                    DialogResult result = loginForm.ShowDialog();

                    // Αν το Login πετύχει (επέστρεψε OK από το btnLogin_Click)
                    if (result == DialogResult.OK)
                    {
                        // 2. Αν το login ήταν επιτυχές, ξεκινάμε το Dashboard
                        Application.Run(new DashboardForm());
                    }
                    // Αν ο χρήστης πατήσει το "Χ" στο Login, η εφαρμογή τερματίζει ομαλά.
                }
            }
            else
            {
                // 3. Αν η σύνδεση απέτυχε, δείχνουμε μήνυμα και η εφαρμογή τερματίζει ομαλά
                MessageBox.Show(
                    "Δεν ήταν δυνατή η σύνδεση με την Βάση Δεδομένων. " +
                    "Παρακαλώ βεβαιωθείτε ότι το XAMPP (MySQL) είναι ανοιχτό.\n\n" +
                    "Λεπτομέρειες σφάλματος:\n" + dbMessage,
                    "Σφάλμα Σύνδεσης",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                // Η εφαρμογή θα κλείσει αυτόματα εδώ γιατί δεν καλέσαμε το Application.Run()
            }
        }
    }
}