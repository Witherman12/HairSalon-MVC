namespace HairSalonApp.Data
{
    /// <summary>
    /// Centralized SQL query strings for the Hair Salon Appointment Management application.
    /// The parameter names are written for use with MySqlCommand.Parameters.
    /// </summary>
    public static class SqlQueries
    {

        // ++ USERS TABLE QUERIES ++ //
        public static class Users
        {
            public const string Login = @"
                SELECT Id, Username, Role
                FROM Users
                WHERE Username = @Username
                AND `Password` = @Password;";

            public const string GetAll = @"
                SELECT Id, Username, Role
                FROM Users
                ORDER BY Id;";

            public const string GetById = @"
                SELECT Id, Username, Role
                FROM Users
                WHERE Id = @Id;";

            // +++ ΝΕΟ QUERY ΓΙΑ ΤΟ BCRYPT +++
            public const string GetByUsername = @"
                SELECT Id, Username, `Password`, Role
                FROM Users
                WHERE Username = @Username
                LIMIT 1;";

            public const string Insert = @"
                INSERT INTO Users (Username, `Password`, Role)
                VALUES (@Username, @Password, @Role);";

            public const string Update = @"
                UPDATE Users
                SET Username = @Username,
                    `Password` = @Password,
                    Role = @Role
                WHERE Id = @Id;";

            public const string Delete = @"
                DELETE FROM Users
                WHERE Id = @Id;";
        }

        // +++ CUSTOMERS TABLE QUERIES +++ //
        public static class Customers
        {
            public const string GetAll = @"
                SELECT Id, FirstName, LastName, Phone, Email, Notes
                FROM Customers
                ORDER BY LastName, FirstName;";

            public const string GetById = @"
                SELECT Id, FirstName, LastName, Phone, Email, Notes
                FROM Customers
                WHERE Id = @Id;";

            public const string Search = @"
                SELECT Id, FirstName, LastName, Phone, Email, Notes
                FROM Customers
                WHERE FirstName LIKE CONCAT('%', @SearchText, '%')
                OR LastName LIKE CONCAT('%', @SearchText, '%')
                OR Phone LIKE CONCAT('%', @SearchText, '%')
                ORDER BY LastName, FirstName;";

            public const string Insert = @"
                INSERT INTO Customers (FirstName, LastName, Phone, Email, Notes)
                VALUES (@FirstName, @LastName, @Phone, @Email, @Notes);";

            public const string Update = @"
                UPDATE Customers
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    Phone = @Phone,
                    Email = @Email,
                    Notes = @Notes
                WHERE Id = @Id;";

            public const string Delete = @"
                DELETE FROM Customers
                WHERE Id = @Id;";
        }

        // +++ EMPLOYEES TABLE QUERIES +++ //
        public static class Employees
        {
            public const string GetAll = @"
                SELECT Id, FirstName, LastName, Specialty, Phone
                FROM Employees
                ORDER BY LastName, FirstName;";

            public const string GetById = @"
                SELECT Id, FirstName, LastName, Specialty, Phone
                FROM Employees
                WHERE Id = @Id;";

            public const string Search = @"
                SELECT Id, FirstName, LastName, Specialty, Phone
                FROM Employees
                WHERE FirstName LIKE CONCAT('%', @SearchText, '%')
                OR LastName LIKE CONCAT('%', @SearchText, '%')
                OR Specialty LIKE CONCAT('%', @SearchText, '%')
                OR Phone LIKE CONCAT('%', @SearchText, '%')
                ORDER BY LastName, FirstName;";

            public const string Insert = @"
                INSERT INTO Employees (FirstName, LastName, Specialty, Phone)
                VALUES (@FirstName, @LastName, @Specialty, @Phone);";

            public const string Update = @"
                UPDATE Employees
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    Specialty = @Specialty,
                    Phone = @Phone
                WHERE Id = @Id;";

            public const string Delete = @"
                DELETE FROM Employees
                WHERE Id = @Id;";
        }

        // +++ SERVICES TABLE QUERIES +++ //
        public static class Services
        {
            public const string GetAll = @"
                SELECT Id, ServiceName, Price, DurationMinutes
                FROM Services
                ORDER BY ServiceName;";

            public const string GetById = @"
                SELECT Id, ServiceName, Price, DurationMinutes
                FROM Services
                WHERE Id = @Id;";

            public const string Search = @"
                SELECT Id, ServiceName, Price, DurationMinutes
                FROM Services
                WHERE ServiceName LIKE CONCAT('%', @SearchText, '%')
                ORDER BY ServiceName;";

            public const string Insert = @"
                INSERT INTO Services (ServiceName, Price, DurationMinutes)
                VALUES (@ServiceName, @Price, @DurationMinutes);";

            public const string Update = @"
                UPDATE Services
                SET ServiceName = @ServiceName,
                    Price = @Price,
                    DurationMinutes = @DurationMinutes
                WHERE Id = @Id;";

            public const string Delete = @"
                DELETE FROM Services
                WHERE Id = @Id;";
        }

        // +++ APPOINTMENTS TABLE QUERIES +++ //
        public static class Appointments
        {
            public const string GetAll = @"
                SELECT 
                    a.Id,
                    a.AppDate,
                    a.AppTime,
                    a.Status,

                    c.Id AS CustomerId,
                    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                    c.Phone AS CustomerPhone,

                    e.Id AS EmployeeId,
                    CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,

                    s.Id AS ServiceId,
                    s.ServiceName,
                    s.Price,
                    s.DurationMinutes
                FROM Appointments a
                INNER JOIN Customers c ON a.CustomerId = c.Id
                INNER JOIN Employees e ON a.EmployeeId = e.Id
                INNER JOIN Services s ON a.ServiceId = s.Id
                ORDER BY a.AppDate, a.AppTime;";

            public const string GetById = @"
                SELECT 
                    a.Id,
                    a.AppDate,
                    a.AppTime,
                    a.Status,

                    c.Id AS CustomerId,
                    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                    c.Phone AS CustomerPhone,

                    e.Id AS EmployeeId,
                    CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,

                    s.Id AS ServiceId,
                    s.ServiceName,
                    s.Price,
                    s.DurationMinutes
                FROM Appointments a
                INNER JOIN Customers c ON a.CustomerId = c.Id
                INNER JOIN Employees e ON a.EmployeeId = e.Id
                INNER JOIN Services s ON a.ServiceId = s.Id
                WHERE a.Id = @Id;";

            public const string GetByDate = @"
                SELECT 
                    a.Id,
                    a.AppDate,
                    a.AppTime,
                    a.Status,
                    c.Id AS CustomerId,
                    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                    c.Phone AS CustomerPhone,
                    e.Id AS EmployeeId,
                    CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
                    s.Id AS ServiceId,
                    s.ServiceName,
                    s.Price,
                    s.DurationMinutes
                FROM Appointments a
                INNER JOIN Customers c ON a.CustomerId = c.Id
                INNER JOIN Employees e ON a.EmployeeId = e.Id
                INNER JOIN Services s ON a.ServiceId = s.Id
                WHERE a.AppDate = @AppDate
                ORDER BY a.AppTime;";

            public const string GetByEmployee = @"
                SELECT 
                    a.Id,
                    a.AppDate,
                    a.AppTime,
                    a.Status,
                    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                    s.ServiceName,
                    s.DurationMinutes
                FROM Appointments a
                INNER JOIN Customers c ON a.CustomerId = c.Id
                INNER JOIN Services s ON a.ServiceId = s.Id
                WHERE a.EmployeeId = @EmployeeId
                ORDER BY a.AppDate, a.AppTime;";

            public const string GetByCustomer = @"
                SELECT 
                    a.Id,
                    a.AppDate,
                    a.AppTime,
                    a.Status,
                    CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
                    s.ServiceName,
                    s.Price,
                    s.DurationMinutes
                FROM Appointments a
                INNER JOIN Employees e ON a.EmployeeId = e.Id
                INNER JOIN Services s ON a.ServiceId = s.Id
                WHERE a.CustomerId = @CustomerId
                ORDER BY a.AppDate, a.AppTime;";

            public const string Insert = @"
                INSERT INTO Appointments 
                (CustomerId, EmployeeId, ServiceId, AppDate, AppTime, Status)
                VALUES
                (@CustomerId, @EmployeeId, @ServiceId, @AppDate, @AppTime, 'Ενεργό');";

            public const string Update = @"
                UPDATE Appointments
                SET CustomerId = @CustomerId,
                    EmployeeId = @EmployeeId,
                    ServiceId = @ServiceId,
                    AppDate = @AppDate,
                    AppTime = @AppTime,
                    Status = @Status
                WHERE Id = @Id;";

            public const string Cancel = @"
                UPDATE Appointments
                SET Status = 'Ακυρωμένο'
                WHERE Id = @Id;";

            public const string Complete = @"
                UPDATE Appointments
                SET Status = 'Ολοκληρώθηκε'
                WHERE Id = @Id;";

            public const string Delete = @"
                DELETE FROM Appointments
                WHERE Id = @Id;";

            // +++ ΝΕΟ QUERY +++
            public const string Reactivate = @"
                UPDATE Appointments
                SET Status = 'Ενεργό'
                WHERE Id = @Id;";

            /// <summary>
            /// Checks whether an employee already has an active appointment that overlaps
            /// with the new appointment time. The new appointment duration is passed as minutes.
            /// If this query returns rows, the appointment slot is not available.
            /// Parameters: @EmployeeId, @AppDate, @NewStartTime, @NewDurationMinutes.
            /// </summary>
            public const string CheckAvailability = @"
                SELECT a.Id
                FROM Appointments a
                INNER JOIN Services s ON a.ServiceId = s.Id
                WHERE a.EmployeeId = @EmployeeId
                AND a.AppDate = @AppDate
                AND a.Status = 'Ενεργό'
                AND (
                        @NewStartTime < ADDTIME(a.AppTime, SEC_TO_TIME(s.DurationMinutes * 60))
                        AND ADDTIME(@NewStartTime, SEC_TO_TIME(@NewDurationMinutes * 60)) > a.AppTime
                    );";

            public const string CheckAvailabilityForUpdate = @"
                SELECT COUNT(*)
                FROM Appointments a
                INNER JOIN Services s ON a.ServiceId = s.Id
                WHERE a.EmployeeId = @EmployeeId
                AND a.AppDate = @AppDate
                AND a.Status = 'Ενεργό'
                AND a.Id <> @AppointmentId
                AND (
                        @NewStartTime < ADDTIME(a.AppTime, SEC_TO_TIME(s.DurationMinutes * 60))
                        AND ADDTIME(@NewStartTime, SEC_TO_TIME(@NewDurationMinutes * 60)) > a.AppTime
                    );
            ";
        }

        /// <summary>
        /// Predefined SQL queries for generating reports and analytics in the application.
        /// </summary>
        public static class Reports
        {
            public const string AppointmentsByDate = @"
                SELECT AppDate, COUNT(*) AS TotalAppointments
                FROM Appointments
                GROUP BY AppDate
                ORDER BY AppDate;";

            public const string AppointmentsByDateFiltered = @"
                SELECT AppDate, COUNT(*) AS TotalAppointments
                FROM Appointments
                WHERE AppDate >= @FromDate AND AppDate <= @ToDate
                GROUP BY AppDate
                ORDER BY AppDate;";

            public const string TotalRevenue = @"
                SELECT SUM(s.Price) AS TotalRevenue
                FROM Appointments a
                INNER JOIN Services s ON a.ServiceId = s.Id
                WHERE a.Status = 'Ολοκληρώθηκε';";

            public const string AppointmentsByEmployee = @"
                SELECT 
                    CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
                    COUNT(a.Id) AS TotalAppointments
                FROM Employees e
                LEFT JOIN Appointments a ON e.Id = a.EmployeeId
                GROUP BY e.Id, e.FirstName, e.LastName
                ORDER BY TotalAppointments DESC;";

            // +++++ ΝΕΟ ΦΙΛΤΡΑΡΙΣΜΕΝΟ QUERY ΓΙΑ ΤΟ ΚΙΤΡΙΝΟ ΚΟΥΜΠΙ +++++
            public const string AppointmentsByEmployeeFiltered = @"
                SELECT 
                    CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, 
                    COUNT(a.Id) AS TotalAppointments
                FROM Employees e
                INNER JOIN Appointments a ON e.Id = a.EmployeeId
                WHERE a.AppDate >= @FromDate 
                  AND a.AppDate <= @ToDate
                GROUP BY e.Id, e.FirstName, e.LastName
                ORDER BY TotalAppointments DESC;";

            public const string PopularServices = @"
                SELECT 
                    s.ServiceName,
                    COUNT(a.Id) AS TotalAppointments
                FROM Services s
                LEFT JOIN Appointments a ON s.Id = a.ServiceId
                GROUP BY s.Id, s.ServiceName
                ORDER BY TotalAppointments DESC;";

            public const string RevenueByService = @"
                SELECT
                    s.ServiceName,
                    COUNT(a.Id) AS CompletedAppointments,
                    SUM(s.Price) AS Revenue
                FROM Services s
                LEFT JOIN Appointments a ON s.Id = a.ServiceId
                WHERE a.Status = 'Ολοκληρώθηκε'
                GROUP BY s.Id, s.ServiceName
                ORDER BY Revenue DESC;";
        }

        public static class Common
        {
            public const string LastInsertId = @"
                SELECT LAST_INSERT_ID();
            ";
        }
    }
}
