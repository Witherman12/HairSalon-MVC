using HairSalonApp.Models;

namespace HairSalonApp.Helpers
{
    public static class UserSession
    {
        // Θα κρατάει τα στοιχεία του χρήστη όσο η εφαρμογή είναι ανοιχτή
        public static User CurrentUser { get; set; }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}