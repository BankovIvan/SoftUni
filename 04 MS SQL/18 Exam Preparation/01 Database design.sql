------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 1. DDL (30 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 1.	Database design
--

--CREATE DATABASE Zoo; 
--USE Zoo;

/*
CREATE TABLE Passports
(
	PassportID BIGINT IDENTITY(101,1) NOT NULL
	,PassportNumber VARCHAR(8) NOT NULL
	,CONSTRAINT PK_Passports PRIMARY KEY (PassportID)
	,CONSTRAINT UQ_PassportNumber UNIQUE (PassportNumber)
	,CONSTRAINT CHK_PassportNumber_Length CHECK (LEN(PassportNumber) = 8)
);

CREATE TABLE Persons
(
	PersonID BIGINT IDENTITY(1,1) NOT NULL
	,FirstName NVARCHAR(150)
	,Salary NUMERIC(18,2)
	,PassportID BIGINT
	,CONSTRAINT PK_Persons PRIMARY KEY (PersonID)
	,CONSTRAINT FK_Persons_PassportID FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)
);

*/


CREATE TABLE Owners
(
	Id INT NOT NULL IDENTITY(1, 1)
	, [Name] VARCHAR(50) NOT NULL
	, PhoneNumber VARCHAR(15) NOT NULL
	, [Address] VARCHAR(50)
	, CONSTRAINT PK_Owners PRIMARY KEY (Id)
);


CREATE TABLE AnimalTypes
(
	Id INT NOT NULL IDENTITY(1, 1)
	, AnimalType VARCHAR(30) NOT NULL
	, CONSTRAINT PK_AnimalTypes PRIMARY KEY (Id)
);


CREATE TABLE Cages
(
	Id INT NOT NULL IDENTITY(1, 1)
	, AnimalTypeId INT NOT NULL 
	, CONSTRAINT PK_Cages PRIMARY KEY (Id)
	, CONSTRAINT FK_Cages_AnimalTypes FOREIGN KEY (AnimalTypeId) REFERENCES AnimalTypes(Id)
);


CREATE TABLE Animals
(
	Id INT NOT NULL IDENTITY(1, 1)
	, [Name] VARCHAR(30) NOT NULL
	, BirthDate DATE NOT NULL
	, OwnerId INT
	, AnimalTypeId INT NOT NULL 
	, CONSTRAINT PK_Animals PRIMARY KEY (Id)
	, CONSTRAINT FK_Animals_Owners FOREIGN KEY (OwnerId) REFERENCES Owners(Id)
	, CONSTRAINT FK_Animals_AnimalTypes FOREIGN KEY (AnimalTypeId) REFERENCES AnimalTypes(Id)
);


CREATE TABLE AnimalsCages
(
	CageId INT NOT NULL
	, AnimalId INT NOT NULL
	, CONSTRAINT PK_AnimalsCages PRIMARY KEY (CageId, AnimalId)
	, CONSTRAINT FK_AnimalsCages_Cages FOREIGN KEY (CageId) REFERENCES Cages(Id)
	, CONSTRAINT FK_AnimalsCages_Animals FOREIGN KEY (AnimalId) REFERENCES Animals(Id)
);


CREATE TABLE VolunteersDepartments
(
	Id INT NOT NULL IDENTITY(1, 1)
	, DepartmentName VARCHAR(30) NOT NULL
	, CONSTRAINT PK_VolunteersDepartments PRIMARY KEY (Id)
);


CREATE TABLE Volunteers
(
	Id INT NOT NULL IDENTITY(1, 1)
	, [Name] VARCHAR(50) NOT NULL
	, PhoneNumber VARCHAR(15) NOT NULL
	, [Address] VARCHAR(50)
	, AnimalId INT
	, DepartmentId INT NOT NULL
	, CONSTRAINT PK_Volunteers PRIMARY KEY (Id)
	, CONSTRAINT FK_Volunteers_Animals FOREIGN KEY (AnimalId) REFERENCES Animals(Id)
	, CONSTRAINT FK_Volunteers_VolunteersDepartments FOREIGN KEY (DepartmentId) REFERENCES VolunteersDepartments(Id)
);




























