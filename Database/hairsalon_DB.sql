CREATE DATABASE IF NOT EXISTS hair_salon_db
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE hair_salon_db;

CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Role VARCHAR(20) NOT NULL
);

CREATE TABLE Customers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Email VARCHAR(100),
    Notes TEXT
);

CREATE TABLE Employees (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Specialty VARCHAR(100),
    Phone VARCHAR(20)
);

CREATE TABLE Services (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ServiceName VARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    DurationMinutes INT NOT NULL
);

CREATE TABLE Appointments (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CustomerId INT NOT NULL,
    EmployeeId INT NOT NULL,
    ServiceId INT NOT NULL,
    AppDate DATE NOT NULL,
    AppTime TIME NOT NULL,
    Status VARCHAR(20) NOT NULL DEFAULT 'Ενεργό',

    CONSTRAINT fk_appointments_customers
        FOREIGN KEY (CustomerId)
        REFERENCES Customers(Id),

    CONSTRAINT fk_appointments_employees
        FOREIGN KEY (EmployeeId)
        REFERENCES Employees(Id),

    CONSTRAINT fk_appointments_services
        FOREIGN KEY (ServiceId)
        REFERENCES Services(Id)
);

-- Προσθήκη προκαθορισμένων χρηστών - ΠΡΟΣΩΡΙΝΑ

-- (Username: admin, Password: 01234) 
INSERT INTO `users` (`Username`, `Password`, `Role`) 
VALUES ('admin', '$2a$12$vgO1pta34Wmn.huuG3SmxeJ20My4wee0wTwibqnAGB0jZ8SWOuwZC', 'Admin');

-- (Username: secr, Password: 56789) 
INSERT INTO `users` (`Username`, `Password`, `Role`) 
VALUES ('secr', '$2a$12$8IQVHSBAudLlKR3ULu5bjOEe3dkAZN91JZUqw/dU8QHndQnlSElhm', 'Secretary');