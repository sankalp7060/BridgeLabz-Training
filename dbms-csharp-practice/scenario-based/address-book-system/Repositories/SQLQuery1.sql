CREATE DATABASE AddressBookDB;
GO
USE AddressBookDB;

CREATE TABLE AddressBook (
    AddressBookId INT IDENTITY PRIMARY KEY,
    Name VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE Contact (
    ContactId INT IDENTITY PRIMARY KEY,
    AddressBookId INT FOREIGN KEY REFERENCES AddressBook(AddressBookId),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Address VARCHAR(200),
    City VARCHAR(50),
    State VARCHAR(50),
    Zip VARCHAR(20),
    Phone VARCHAR(20),
    Email VARCHAR(100)
);

CREATE UNIQUE INDEX UQ_Person
ON Contact(AddressBookId, FirstName, LastName);