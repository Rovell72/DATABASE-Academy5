CREATE DATABASE Academy5;
GO

USE Academy5;
GO

CREATE TABLE Faculties
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
        CHECK (Name <> '')
);

CREATE TABLE Departments
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
        CHECK (Name <> ''),
    Financing MONEY NOT NULL DEFAULT 0
        CHECK (Financing >= 0)
);

CREATE TABLE Groups
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(10) NOT NULL UNIQUE
        CHECK (Name <> ''),
    Rating INT NOT NULL
        CHECK (Rating BETWEEN 0 AND 5),
    [Year] INT NOT NULL
        CHECK ([Year] BETWEEN 1 AND 5)
);

CREATE TABLE Teachers
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL
        CHECK (Name <> ''),
    Surname NVARCHAR(MAX) NOT NULL
        CHECK (Surname <> ''),
    Salary MONEY NOT NULL
        CHECK (Salary > 0),
    Premium MONEY NOT NULL DEFAULT 0
        CHECK (Premium >= 0),
    EmploymentDate DATE NOT NULL
        CHECK (EmploymentDate >= '1990-01-01')
);