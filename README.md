# ✂️ HairSalon-MVC - Σύστημα Διαχείρισης Κομμωτηρίου

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-00000F?style=for-the-badge&logo=mysql&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)

Μια ολοκληρωμένη desktop εφαρμογή διαχείρισης λειτουργιών κομμωτηρίου, χτισμένη με **C#** και **Windows Forms**. 
Το project αναπτύχθηκε στα πλαίσια του μαθήματος "Τεχνολογία Λογισμικού" του Πανεπιστημίου Δυτικής Αττικής και ακολουθεί αρχιτεκτονική τριών επιπέδων (3-tier) και το πρότυπο MVC (Model-View-Controller) για βέλτιστο διαχωρισμό του UI, της επιχειρησιακής λογικής και της βάσης δεδομένων.

##  Βασικά Χαρακτηριστικά (Features)
- **Διαχείριση Ραντεβού (CRUD):** Κλείσιμο, προβολή, επεξεργασία και ακύρωση ραντεβού με έξυπνο έλεγχο διαθεσιμότητας.
- **Role-Based Access Control (RBAC):** Διαφορετικά δικαιώματα και UI ανάλογα με τον ρόλο του χρήστη (Διαχειριστής ή Γραμματεία).
- **Επιχειρησιακοί Κανόνες (Business Rules):** Απαγόρευση τροποποίησης ή ακύρωσης ραντεβού σε λιγότερο από 24 ώρες.
- **Αρχείο Πελατών & Προσωπικού:** Πλήρης διαχείριση του πελατολογίου, των υπαλλήλων και των παρεχόμενων υπηρεσιών.
- **Αναφορές & Στατιστικά:** Εξαγωγή δεδομένων (έσοδα, δημοφιλείς υπηρεσίες κτλ.) σε αρχεία **Excel** και **PDF**, καθώς και δυνατότητα άμεσης εκτύπωσης.
- **Μοντέρνο UI:** Προσαρμοσμένο Theme με δυναμική πλοήγηση μέσω User Controls (Dashboard).

## Τεχνολογίες & Εργαλεία (Tech Stack)
- **Frontend (UI):** C# / Windows Forms (.NET Framework)
- **Backend (Λογική):** C#
- **Βάση Δεδομένων:** MySQL
- **Βιβλιοθήκες (NuGet Packages):** - `MySql.Data` (Επικοινωνία με τη βάση)
  - `ClosedXML` (Εξαγωγή σε Excel)
  - `iTextSharp` (Δημιουργία & εξαγωγή PDF)
- **Version Control:** Git & GitHub

## Οργάνωση & Ρόλοι Ομάδας
Η ομάδα έχει χωρίσει τις αρμοδιότητες ως εξής:
* **UI/UX Design:** Σχεδιασμός φορμών (Login, Dashboard) και γραφικού περιβάλλοντος.
* **Database Management:** Σχεδιασμός πινάκων στη MySQL και διαχείριση του `.sql` backup.
* **Backend/Controller:** Διαχείριση των Models, Connection String και λογικής (Business/Service Layer).
* **Testing:** Συγγραφή Unit Tests για την επιβεβαίωση της σωστής λειτουργίας του κώδικα.

---

## Οδηγίες Εγκατάστασης (Setup)

Ακολουθήστε τα παρακάτω βήματα για να τρέξετε το project τοπικά στον υπολογιστή σας:

### 1. Προαπαιτούμενα
- Εγκατεστημένο **Visual Studio** (με το workload ".NET desktop development").
- Εγκατεστημένο **XAMPP** (ή αυτόνομο MySQL Server).

### 2. Στήσιμο Βάσης Δεδομένων
1. Ανοίξτε το XAMPP Control Panel και ξεκινήστε τον **Apache** και τη **MySQL**.
2. Ανοίξτε τον browser στο `http://localhost/phpmyadmin/`.
3. Δημιουργήστε μια νέα βάση δεδομένων (π.χ. `hairsalon_db`).
4. Επιλέξτε την καρτέλα **Import (Εισαγωγή)** και ανεβάστε το πιο πρόσφατο αρχείο `.sql` που βρίσκεται στον φάκελο `Database` του repository.

### 3. Εκτέλεση Εφαρμογής
1. Κάντε Clone το repository τοπικά:
   ```bash
   git clone [https://github.com/Username/HairSalon-MVC.git](https://github.com/Username/HairSalon-MVC.git)
