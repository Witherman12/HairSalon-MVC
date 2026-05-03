# HairSalon-MVC
## Hair Salon Management App:
Μια  desktop εφαρμογή διαχείρισης κομμωτηρίου, χτισμένη με C# και Windows Forms. 
Το project ακολουθεί αρχιτεκτονική MVC (Model-View-Controller) / 3-tier για σωστό διαχωρισμό του UI από τη λογική και τη βάση δεδομένων.

## Stack:
- Frontend (UI): C# / Windows Forms (Custom Dark Theme)
- Backend (Λογική): C# (.NET)
- Βάση Δεδομένων: MySQL (μέσω XAMPP)
- Version Control: Git & GitHub

## Οργάνωση & Ρόλοι
Η ομάδα έχει χωρίσει τις αρμοδιότητες ως εξής:
- UI/UX Design: Σχεδιασμός φορμών (Login, Dashboard) και γραφικού περιβάλλοντος.
- Database Management: Σχεδιασμός πινάκων στη MySQL και διαχείριση του .sql backup.
- Backend / Controller: Διαχείριση των Models, Connection String και λογικής (Business Logic).
- Testing: Συγγραφή Unit Tests για την επιβεβαίωση της σωστής λειτουργίας του κώδικα.

## Οδηγίες Εγκατάστασης (Setup)
Για να τρέξετε το project τοπικά στον υπολογιστή σας:
- Βάση Δεδομένων:
Ανοίξτε το XAMPP και ξεκινήστε τον Apache και τη MySQL.
Ανοίξτε το phpMyAdmin, δημιουργήστε μια νέα βάση και κάντε Import το πιο πρόσφατο αρχείο .sql της ομάδας.
- Εφαρμογή:
Κάντε Clone το repository τοπικά.
Ανοίξτε το αρχείο HairSalonApp.sln στο Visual Studio.
Βεβαιωθείτε ότι το Connection String στον κώδικα δείχνει στον δικό σας τοπικό server.

Πατήστε Start (F5) για να τρέξετε την εφαρμογή!
