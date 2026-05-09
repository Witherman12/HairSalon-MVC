using System;
using System.Windows.Forms;
using HairSalonApp.Services; // Προσθήκη για να βλέπει το Business Logic

namespace HairSalonApp
{
    public partial class LoginForm : Form
    {
        // 1. Δήλωση του Service
        private readonly UserService _userService;

        public LoginForm()
        {
            InitializeComponent();

            // 2. Αρχικοποίηση του Service
            _userService = new UserService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var result = _userService.Login(txtUsername.Text, txtPassword.Text);

            if (result.Success)
            {
                // Το Login πέτυχε. Ενημερώνουμε ότι η φόρμα κλείνει επιτυχώς.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Αν απέτυχε (λάθος κωδικός ή άδεια πεδία)
                MessageBox.Show(result.ErrorMessage, "Αποτυχία Σύνδεσης", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus(); // Βάζουμε ξανά τον κέρσορα στον κωδικό
            }
        }

        // Αυτό το κομμάτι κάνει στα Windows να κουνιέται η φόρμα
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84)
            {
                if ((int)m.Result == 0x1)
                    m.Result = (IntPtr)0x2;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}