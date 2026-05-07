using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HairSalonApp
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        // Βοηθητική μέθοδος για να φορτώνει τα User Controls στο κεντρικό Panel
        private void LoadUserControl(UserControl uc)
        {
            // 1. Καθαρίζει το Panel από ότι είχε πριν (π.χ. αν ήσουν στους Πελάτες και πατάς Ραντεβού)
            MainPanel.Controls.Clear();

            // 2. Λέει στο User Control να απλωθεί και να πιάσει όλο τον διαθέσιμο χώρο
            uc.Dock = DockStyle.Fill;

            // 3. Εμφανίζει το User Control μέσα στο Panel
            MainPanel.Controls.Add(uc);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblCurrentUser_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Φτιάχνει την φόρμα των ραντεβού
            AppointmentsUC uc = new AppointmentsUC();

            // Την φορτώνει στο MainPanel
            LoadUserControl(uc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomersUC uc = new CustomersUC();
            LoadUserControl(uc);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeesUC uc = new EmployeesUC();
            LoadUserControl(uc);
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            // Ενημερώνει την ώρα (π.χ. 17:13:45)
            lblLiveTime.Text = DateTime.Now.ToString("HH:mm:ss");

            // Ενημερώνει την ημερομηνία σε αριθμητική μορφή (π.χ. 07/05/2026)
            lblLiveDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void Sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sidebar_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
