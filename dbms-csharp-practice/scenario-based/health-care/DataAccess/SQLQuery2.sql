CREATE DATABASE HealthCareClinicDB;
GO
USE HealthCareClinicDB;
GO
CREATE TABLE Specialties (
    specialty_id INT IDENTITY PRIMARY KEY,
    specialty_name VARCHAR(100) NOT NULL UNIQUE,
    description VARCHAR(255)
);

CREATE TABLE Patients (
    patient_id INT IDENTITY PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    dob DATE NOT NULL,
    gender CHAR(1),
    phone VARCHAR(15) UNIQUE NOT NULL,
    email VARCHAR(100) UNIQUE,
    address VARCHAR(255),
    blood_group VARCHAR(5),
    created_at DATETIME DEFAULT GETDATE()
);
CREATE INDEX idx_patient_phone ON Patients(phone);
CREATE INDEX idx_patient_name ON Patients(full_name);

CREATE TABLE Doctors (
    doctor_id INT IDENTITY PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    specialty_id INT NOT NULL,
    phone VARCHAR(15),
    email VARCHAR(100),
    consultation_fee DECIMAL(10,2) NOT NULL,
    is_active BIT DEFAULT 1,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (specialty_id) REFERENCES Specialties(specialty_id)
);

CREATE TABLE Appointments (
    appointment_id INT IDENTITY PRIMARY KEY,
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    appointment_date DATE NOT NULL,
    appointment_time TIME NOT NULL,
    status VARCHAR(20) 
        CHECK (status IN ('SCHEDULED','CANCELLED','COMPLETED','RESCHEDULED')),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (patient_id) REFERENCES Patients(patient_id),
    FOREIGN KEY (doctor_id) REFERENCES Doctors(doctor_id)
);

CREATE INDEX idx_appointment_date ON Appointments(appointment_date);
CREATE INDEX idx_doctor_date ON Appointments(doctor_id, appointment_date);

CREATE TABLE Appointment_Audit (
    audit_id INT IDENTITY PRIMARY KEY,
    appointment_id INT,
    action VARCHAR(50),
    action_date DATETIME DEFAULT GETDATE(),
    remarks VARCHAR(255)
);

CREATE TABLE Visits (
    visit_id INT IDENTITY PRIMARY KEY,
    appointment_id INT UNIQUE,
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    visit_date DATETIME DEFAULT GETDATE(),
    diagnosis VARCHAR(255),
    notes VARCHAR(500),
    FOREIGN KEY (appointment_id) REFERENCES Appointments(appointment_id),
    FOREIGN KEY (patient_id) REFERENCES Patients(patient_id),
    FOREIGN KEY (doctor_id) REFERENCES Doctors(doctor_id)
);

CREATE TABLE Prescriptions (
    prescription_id INT IDENTITY PRIMARY KEY,
    visit_id INT NOT NULL,
    medicine_name VARCHAR(100) NOT NULL,
    dosage VARCHAR(50),
    duration VARCHAR(50),
    FOREIGN KEY (visit_id) REFERENCES Visits(visit_id)
);

CREATE TABLE Bills (
    bill_id INT IDENTITY PRIMARY KEY,
    visit_id INT UNIQUE NOT NULL,
    total_amount DECIMAL(10,2) NOT NULL,
    payment_status VARCHAR(10) 
        CHECK (payment_status IN ('PAID','UNPAID')),
    created_at DATETIME DEFAULT GETDATE(),
    payment_date DATETIME,
    payment_mode VARCHAR(50),
    FOREIGN KEY (visit_id) REFERENCES Visits(visit_id)
);

CREATE TABLE Payment_Transactions (
    transaction_id INT IDENTITY PRIMARY KEY,
    bill_id INT NOT NULL,
    amount DECIMAL(10,2),
    payment_mode VARCHAR(50),
    transaction_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (bill_id) REFERENCES Bills(bill_id)
);

CREATE TABLE Audit_Log (
    audit_id INT IDENTITY PRIMARY KEY,
    table_name VARCHAR(50),
    action_type VARCHAR(10),
    record_id INT,
    action_date DATETIME DEFAULT GETDATE(),
    performed_by VARCHAR(100)
);

CREATE TRIGGER trg_patient_insert
ON Patients
AFTER INSERT
AS
BEGIN
    INSERT INTO Audit_Log (table_name, action_type, record_id)
    SELECT 'Patients', 'INSERT', patient_id FROM inserted;
END;
