using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HairSalonApp
{
    public partial class CustomersUC : UserControl
    {
        public CustomersUC()
        {
            InitializeComponent();

            // 1. Δημιουργία Στηλών για τους Πελάτες
            dgvCustomers.Columns.Add("Name", "Ονοματεπώνυμο");
            dgvCustomers.Columns.Add("Phone", "Τηλέφωνο");
            dgvCustomers.Columns.Add("Email", "Email");
            dgvCustomers.Columns.Add("Notes", "Σημειώσεις");

            // 2. Προσθήκη ψεύτικων δεδομένων για την παρουσίαση
            dgvCustomers.Rows.Add("Μαρία Παπαδοπούλου", "6971234567", "maria@email.com", "Αλλεργία στη βαφή Χ");
            dgvCustomers.Rows.Add("Γιώργος Αντωνίου", "6989876543", "giorgos@email.com", "-");
            dgvCustomers.Rows.Add("Άννα Γεωργίου", "2101234567", "anna@email.com", "Προτιμάει πρωινά ραντεβού");

            // 3. Ύψος γραμμών για καλύτερη ανάγνωση
            dgvCustomers.RowTemplate.Height = 40;
        }
    }
}
