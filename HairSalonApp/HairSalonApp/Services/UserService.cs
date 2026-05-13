using System;
using HairSalonApp.Models;
using HairSalonApp.Data;     // Για το UserRepository
using HairSalonApp.Helpers;  // Για το OperationResult και UserSession

namespace HairSalonApp.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public OperationResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return new OperationResult { Success = false, ErrorMessage = "Παρακαλώ συμπληρώστε το Όνομα Χρήστη και τον Κωδικό." };
            }

            try
            {
                // 1. Ζητάμε από το Repository να φέρει τον χρήστη ΜΟΝΟ με το όνομα
                var user = _userRepository.GetByUsername(username.Trim());

                if (user == null)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Λάθος όνομα χρήστη." };
                }

                // 2. Συγκρίνουμε τον απλό κωδικό με το Hash της βάσης
                bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (!isPasswordCorrect)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Λάθος κωδικός πρόσβασης." };
                }

                // 3. Επιτυχία
                UserSession.CurrentUser = user;
                return new OperationResult { Success = true };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = "Σφάλμα επικοινωνίας με τη βάση: " + ex.Message };
            }
        }
    }
}