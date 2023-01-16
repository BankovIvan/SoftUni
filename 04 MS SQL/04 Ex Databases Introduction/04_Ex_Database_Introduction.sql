-- MS SQL - януари 2023
-- 04. Exercise: Databases Introduction
--

-- 1.	Create Database

USE Master
DROP DATABASE Minions;

CREATE DATABASE Minions;

USE Minions;

-- 2.	Create Tables
CREATE TABLE Minions 
(
	Id INT NOT NULL,
	[Name] VARCHAR(100),
	Age INT
);

CREATE TABLE Towns 
(
	Id INT NOT NULL,
	[Name] VARCHAR(100)
);

ALTER TABLE Minions
	ADD CONSTRAINT PK_Minion PRIMARY KEY (Id);

ALTER TABLE Towns
	ADD CONSTRAINT PK_Town PRIMARY KEY (Id);

-- 3.	Alter Minions Table
ALTER TABLE Minions
	ADD TownId INT NOT NULL;
ALTER TABLE Minions
	ADD CONSTRAINT FK_TownId FOREIGN KEY (TownId) REFERENCES Towns(Id);

-- 4.	Insert Records in Both Tables
INSERT INTO Towns (Id, [Name])
	VALUES 
		(1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna');

INSERT INTO Minions (Id, [Name], Age, TownId)
	VALUES 
		(1, 'Kevin', 22, 1),
		(2, 'Bob', 15, 3),
		(3, 'Steward', NULL, 2);

SELECT * FROM Minions;

-- 5.	Truncate Table Minions
DELETE FROM Minions;

-- 6.	Drop All Tables
DROP TABLE Minions;
DROP TABLE Towns;

-- 7.	Create Table People
DROP TABLE People;

CREATE TABLE People 
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture image,
	Height NUMERIC(18,2),
	[Weight] NUMERIC(18,2),
	Gender VARCHAR(1) NOT NULL CHECK (Gender IN('m', 'f')),
	Birthdate DATE NOT NULL,
	--Biography NVARCHAR(MAX),
	Biography TEXT,
);

INSERT INTO People ([Name], Gender, Birthdate)
	VALUES 
		('Pesho', 'm', '01-01-1900'),
		('Mincho', 'm', '01-01-2000'),
		('Goshko', 'm', '01-01-2001'),
		('Kaka Kalinka', 'f', '01-01-1900'),
		('Bate Dimo', 'm', '01-01-1901');

-- 8.	Create Table Users
DROP TABLE Users;

CREATE TABLE Users 
(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePictur IMAGE,
	LastLoginTime DATETIME,
	IsDeleted BIT,
	CONSTRAINT PK_Users PRIMARY KEY (Id),
);

INSERT 
	INTO Users 
		(Username, [Password], IsDeleted)
	VALUES 
		('Pesho', 'Maimunata', 0),
		('Mincho', 'Bakshisha', 0),
		('Goshko', 'Mechkata', 1),
		('Kaka Kalinka', 'Na Baba Hubavetza', 0),
		('Bate Dimo', 'Vinkelo', 1);

SELECT * FROM Users;

-- 9.	Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK_Users;

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username);

-- 10.	Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_Password_Len CHECK (LEN([Password]) >= 5);

INSERT 
	INTO Users 
		(Username, [Password], IsDeleted)
	VALUES 
		('Ivancho', '1234', 0),
		('Mariika', '12345', 0);

SELECT * FROM Users;

-- 11.	Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DEF_LastLoginTime DEFAULT CURRENT_TIMESTAMP FOR LastLoginTime;

INSERT 
	INTO Users 
		(Username, [Password], IsDeleted)
	VALUES 
		('John Smith', 'TRUMPH', 0);

SELECT * FROM Users;

-- 12.	Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_Users;

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id);

ALTER TABLE Users
ADD CONSTRAINT UQ_Users UNIQUE (Username);

ALTER TABLE Users
ADD CONSTRAINT CHK_Username_Len CHECK (LEN(Username) >= 3);

INSERT 
	INTO Users 
		(Username, [Password], IsDeleted)
	VALUES 
		--('Jo', 'TRUMPH', 0);
		('John Smith', 'TRUMPH', 0);

--------------------------------------------------------------------
--------------------------------------------------------------------
-- 13.	Movies Database
--USE Master
--DROP DATABASE Movies;

CREATE DATABASE Movies;

USE Movies;

--DROP TABLE Directors 

CREATE TABLE Directors 
(
	Id INT IDENTITY(1,1) NOT NULL,
	DirectorName NVARCHAR(150) NOT NULL,
	Notes TEXT,
	CONSTRAINT PK_Directors PRIMARY KEY (Id),
	CONSTRAINT UQ_DirectorName UNIQUE (DirectorName),
);

INSERT 
	INTO Directors 
		(DirectorName, Notes)
	VALUES 
		('Pesho', 'Maimunata'),
		('Mincho', NULL),
		('Goshko', NULL),
		('Kaka Kalinka', NULL),
		('Bate Dimo', NULL);

--SELECT * FROM Directors;

---------------------------------------
--DROP TABLE Genres 

CREATE TABLE Genres 
(
	Id INT IDENTITY(1,1) NOT NULL,
	GenreName NVARCHAR(150) NOT NULL,
	Notes TEXT,
	CONSTRAINT PK_Genres PRIMARY KEY (Id),
	CONSTRAINT UQ_GenreName UNIQUE (GenreName),
);

INSERT 
	INTO Genres 
		(GenreName, Notes)
	VALUES 
		('KILL', 'Lots of dead people'),
		('LOVE', NULL),
		('DRAMA', NULL),
		('PORN', NULL),
		('COMEDY', 'HA HA HA');

--SELECT * FROM Genres;

-------------------------------------------
--DROP TABLE Categories 

CREATE TABLE Categories 
(
	Id INT IDENTITY(1,1) NOT NULL,
	CategoryName NVARCHAR(150) NOT NULL,
	Notes TEXT,
	CONSTRAINT PK_Categories PRIMARY KEY (Id),
	CONSTRAINT UQ_CategoryName UNIQUE (CategoryName),
);

INSERT 
	INTO Categories 
		(CategoryName, Notes)
	VALUES 
		('A', 'MAMA MIA'),
		('B', NULL),
		('C', NULL),
		('D', NULL),
		('E', 'CANE E GATTO');

--SELECT * FROM Categories;

----------------------------------------
--DROP TABLE Movies 

CREATE TABLE Movies 
(
	Id INT IDENTITY(1,1) NOT NULL,
	Title NVARCHAR(150) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATE,
	[Length] TIME,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes TEXT,
	CONSTRAINT PK_Movies PRIMARY KEY (Id),
	CONSTRAINT UQ_Title UNIQUE (Title),
	CONSTRAINT FK_DirectorId FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
	CONSTRAINT FK_GenreId FOREIGN KEY (GenreId) REFERENCES Genres(Id),
	CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
);

INSERT 
	INTO Movies 
		(Title, DirectorId, GenreId, CategoryId)
	VALUES 
		('KILL BILL 1', 1, 1, 1),
		('KILL BILL 2', 1, 1, 1),
		('KILL BILL 3', 1, 1, 1),
		('KILL BILL 4', 1, 1, 1),
		('KILL BILL 5', 5, 5, 5);

--SELECT * FROM Movies;

--------------------------------------------------------------------
--------------------------------------------------------------------
-- 14.	Car Rental Database
--USE Master
--DROP DATABASE CarRental;

CREATE DATABASE CarRental
	COLLATE Cyrillic_General_CI_AS;

USE CarRental;

-------------------------------------------------------------------
--DROP TABLE Categories 

CREATE TABLE Categories
(
	Id INT IDENTITY(1,1) NOT NULL,
	CategoryName NVARCHAR(150) NOT NULL,
	DailyRate NUMERIC(18,2) NOT NULL,
	WeeklyRate NUMERIC(18,2),
	MonthlyRate NUMERIC(18,2),
	WeekendRate NUMERIC(18,2),
	CONSTRAINT PK_Categories PRIMARY KEY (Id),
	CONSTRAINT UQ_CategoryName UNIQUE (CategoryName),
);

INSERT 
	INTO Categories 
		(CategoryName, DailyRate)
	VALUES 
		--('F1', 100.01),
		--('FAST', 99.01),
		('VERY FAST', 88.01),
		('RALLY', 77.01),
		('ELECTRIC', 0.01);

--SELECT * FROM Categories;

-------------------------------------------------------------------
--DROP TABLE Cars 

CREATE TABLE Cars 
(
	Id INT IDENTITY(1,1) NOT NULL,
	PlateNumber NVARCHAR(16) NOT NULL,
	Manufacturer NVARCHAR(150),
	Model NVARCHAR(150),
	CarYear DATE,
	CategoryId INT NOT NULL,
	Doors INT,
	Picture IMAGE,
	Condition NVARCHAR(150),
	Available BIT NOT NULL,
	CONSTRAINT PK_Cars PRIMARY KEY (Id),
	CONSTRAINT UQ_PlateNumber UNIQUE (PlateNumber),
	CONSTRAINT FK_CarsCategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
);

INSERT 
	INTO Cars 
		(PlateNumber, CategoryId, Available)
	VALUES 
		--('AA 0001 AA', 1, 1),
		--('AA 0002 AA', 2, 1),
		('AA 0003 AA', 1, 1),
		('AA 0004 AA', 2, 1),
		('AA 0005 AA', 3, 0);

--SELECT * FROM Cars;

-------------------------------------------------------------------
--DROP TABLE Employees 

CREATE TABLE Employees 
(
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	Title NVARCHAR(150),
	Notes TEXT,
	CONSTRAINT PK_Employees PRIMARY KEY (Id),
);

INSERT 
	INTO Employees 
		(FirstName, LastName, Title, Notes)
	VALUES 
		('John', 'Smith', 'Sr.', 'The grand father...'),
		('John', 'Smith', 'Jr.', 'The father...'),
		('John', 'Smith', 'Jr. Jr.', 'The son...');
		--('Пешо', 'Маймуната', NULL, NULL),
		--('Марийка', 'Иванчова', 'гжа.', NULL);

--SELECT * FROM Employees;

-------------------------------------------------------------------
--DROP TABLE Customers 

CREATE TABLE Customers 
(
	Id INT IDENTITY(1,1) NOT NULL,
	DriverLicenceNumber NVARCHAR(150) NOT NULL,
	FullName NVARCHAR(150),
	[Address] NVARCHAR(250),
	City NVARCHAR(150),
	ZIPCode NVARCHAR(50),
	Notes TEXT,
	CONSTRAINT PK_Customers PRIMARY KEY (Id),
	CONSTRAINT UQ_DriverLicenceNumber UNIQUE (DriverLicenceNumber),
);

INSERT 
	INTO Customers 
		(DriverLicenceNumber, FullName)
	VALUES 
		('C1234567890', 'John Smith Sr.'),
		('C1234567891', 'John Smith Jr.'),
		('C1234567892', 'John Smith Jr. Jr.');
		--('C1234567893', 'Пешо Маймуната'),
		--('C1234567894', 'Марийка Иванчова');

--SELECT * FROM Customers;


-------------------------------------------------------------------
--DROP TABLE RentalOrders 

CREATE TABLE RentalOrders 
(
	Id INT IDENTITY(1,1) NOT NULL,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel NUMERIC(18,2),
	KilometrageStart NUMERIC(18,2),
	KilometrageEnd NUMERIC(18,2),
	TotalKilometrage NUMERIC(18,2),
	StartDate DATE,
	EndDate DATE,
	TotalDays DATE,
	RateApplied NUMERIC(18,2),
	TaxRate NUMERIC(18,2),
	OrderStatus BIT NOT NULL,
	Notes TEXT,
	CONSTRAINT PK_RentalOrders PRIMARY KEY (Id),
	CONSTRAINT FK_RentalOrdersEmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_RentalOrdersCustomerId FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
	CONSTRAINT FK_RentalOrdersCarId FOREIGN KEY (CarId) REFERENCES Cars(Id),
);

INSERT 
	INTO RentalOrders 
		(EmployeeId, CustomerId, CarId, OrderStatus)
	VALUES 
		(1, 1, 1, 0),
		(2, 2, 2, 0),
		(3, 3, 3, 0);

--SELECT * FROM RentalOrders;


--------------------------------------------------------------------
--------------------------------------------------------------------
-- 15.	Hotel Database
--USE Master
--DROP DATABASE Hotel;

CREATE DATABASE Hotel
	COLLATE Cyrillic_General_CI_AS;

USE Hotel;

-------------------------------------------------------------------
--DROP TABLE Employees 

CREATE TABLE Employees 
(
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	Title NVARCHAR(50),
	Notes TEXT,
	CONSTRAINT PK_Employees PRIMARY KEY (Id),
);

INSERT 
	INTO Employees 
		(FirstName, LastName, Title)
	VALUES 
		('John', 'Smith', 'Sr.'),
		('John', 'Smith', 'Jr.'),
		('John', 'Smith', 'Jr.Jr.');

--SELECT * FROM Employees;

-------------------------------------------------------------------
--DROP TABLE Customers 

CREATE TABLE Customers 
(
	AccountNumber INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	PhoneNumber CHAR(10),
	EmergencyName NVARCHAR(300),
	EmergencyNumber CHAR(10),
	Notes TEXT,
	CONSTRAINT PK_Customers PRIMARY KEY (AccountNumber),
);

INSERT 
	INTO Customers 
		(FirstName, LastName)
	VALUES 
		('Johny', 'Walker'),
		('Ivancho', 'Mariikin'),
		('Pesho', 'The Monkey');

--SELECT * FROM Customers;


-------------------------------------------------------------------
--DROP TABLE RoomStatus 

CREATE TABLE RoomStatus 
(
	Id INT IDENTITY(1,1) NOT NULL,
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes TEXT,
	CONSTRAINT PK_RoomStatus PRIMARY KEY (Id),
	CONSTRAINT UQ_RoomStatus UNIQUE (RoomStatus),
);

INSERT 
	INTO RoomStatus 
		(RoomStatus)
	VALUES 
		('FREE'),
		('OCCUPIED'),
		('CLEANING');

--SELECT * FROM RoomStatus;


-------------------------------------------------------------------
--DROP TABLE RoomTypes 

CREATE TABLE RoomTypes 
(
	Id INT IDENTITY(1,1) NOT NULL,
	RoomType NVARCHAR(50) NOT NULL,
	Notes TEXT,
	CONSTRAINT PK_RoomTypes PRIMARY KEY (Id),
	CONSTRAINT UQ_RoomType UNIQUE (RoomType),
);

INSERT 
	INTO RoomTypes 
		(RoomType)
	VALUES 
		('SINGLE'),
		('DOUBLE'),
		('APARTMENT');

--SELECT * FROM RoomTypes;


-------------------------------------------------------------------
--DROP TABLE BedTypes 

CREATE TABLE BedTypes 
(
	Id INT IDENTITY(1,1) NOT NULL,
	BedType NVARCHAR(50) NOT NULL,
	Notes TEXT,
	CONSTRAINT PK_BedTypes PRIMARY KEY (Id),
	CONSTRAINT UQ_BedType UNIQUE (BedType),
);

INSERT 
	INTO BedTypes 
		(BedType)
	VALUES 
		('KING'),
		('QUEEN'),
		('SINGLE');

--SELECT * FROM BedTypes;


-------------------------------------------------------------------
--DROP TABLE Rooms 

CREATE TABLE Rooms 
(
	Id INT IDENTITY(1,1) NOT NULL,
	RoomNumber NVARCHAR(50) NOT NULL,
	RoomType NVARCHAR(50) NOT NULL,
	BedType NVARCHAR(50) NOT NULL,
	Rate NUMERIC(18,2),
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes TEXT,
	CONSTRAINT PK_Rooms PRIMARY KEY (Id),
	CONSTRAINT FK_RoomsRoomType FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
	CONSTRAINT FK_RoomsBedType FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
	CONSTRAINT FK_RoomsRoomStatus FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus),
	CONSTRAINT UQ_RoomNumber UNIQUE (RoomNumber),
);

INSERT 
	INTO Rooms 
		(RoomNumber, RoomType, BedType, Rate, RoomStatus)
	VALUES 
		('A01', 'SINGLE', 'KING', 100, 'FREE'),
		('A02', 'DOUBLE', 'KING', NULL, 'FREE'),
		('A03', 'APARTMENT', 'QUEEN', NULL, 'OCCUPIED');

--SELECT * FROM Rooms;


-------------------------------------------------------------------
--DROP TABLE Payments 

CREATE TABLE Payments 
(
	Id INT IDENTITY(1,1) NOT NULL,
	EmployeeId INT NOT NULL,
	PaymentDate DATE,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays DATE,
	AmountCharged NUMERIC(18,2),
	TaxRate NUMERIC(18,2),
	TaxAmount NUMERIC(18,2),
	PaymentTotal NUMERIC(18,2) NOT NULL,
	Notes TEXT,
	CONSTRAINT PK_Payments PRIMARY KEY (Id),
	CONSTRAINT FK_PaymentsEmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_PaymentsAccountNumber FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
);

INSERT 
	INTO Payments 
		(EmployeeId, AccountNumber, PaymentTotal)
	VALUES 
		(1, 1, 100.01),
		(2, 2, 100.02),
		(3, 3, 100.03);

--SELECT * FROM Payments;
--SELECT * FROM Rooms;


-------------------------------------------------------------------
--DROP TABLE Occupancies  

CREATE TABLE Occupancies 
(
	Id INT IDENTITY(1,1) NOT NULL,
	EmployeeId INT NOT NULL,
	DateOccupied DATE,
	AccountNumber INT NOT NULL,
	RoomNumber NVARCHAR(50) NOT NULL,
	RateApplied NUMERIC(18,2),
	PhoneCharge NUMERIC(18,2),
	Notes TEXT,
	CONSTRAINT PK_Occupancies PRIMARY KEY (Id),
	CONSTRAINT FK_OccupanciesEmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_OccupanciesAccountNumber FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
	CONSTRAINT FK_OccupanciesRoomNumber FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber),
);

INSERT 
	INTO Occupancies 
		(EmployeeId, AccountNumber, RoomNumber)
	VALUES 
		(1, 1, 'A01'),
		(2, 2, 'A02'),
		(3, 3, 'A03');

--SELECT * FROM Occupancies;


--------------------------------------------------------------------
--------------------------------------------------------------------
-- 16.	Create SoftUni Database
--USE Master
--DROP DATABASE SoftUni;

CREATE DATABASE SoftUni
	COLLATE Cyrillic_General_CI_AS;

USE SoftUni;

-------------------------------------------------------------------
--DROP TABLE Towns 

CREATE TABLE Towns 
(
	Id INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(150) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY (Id),
);

INSERT 
	INTO Towns 
		([Name])
	VALUES 
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas');

--SELECT * FROM Towns;


-------------------------------------------------------------------
--DROP TABLE Addresses 

CREATE TABLE Addresses 
(
	Id INT IDENTITY(1,1) NOT NULL,
	AddressText NVARCHAR(250) NOT NULL,
	TownID INT NOT NULL,
	CONSTRAINT PK_Addresses PRIMARY KEY (Id),
	CONSTRAINT FK_AddressesTownID FOREIGN KEY (TownID) REFERENCES Towns(Id),
);

INSERT 
	INTO Addresses 
		(AddressText, TownID)
	VALUES 
		('Sofia 1', 1),
		('Plovdiv 2', 2),
		('Varna 3', 3),
		('Burgas 4', 4);

--SELECT * FROM Addresses;


-------------------------------------------------------------------
--DROP TABLE Departments 

CREATE TABLE Departments 
(
	Id INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Departments PRIMARY KEY (Id),
);

INSERT 
	INTO Departments 
		([Name])
	VALUES 
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance');

--SELECT * FROM Departments;


-------------------------------------------------------------------
--DROP TABLE Employees  

CREATE TABLE Employees 
(
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(150) NOT NULL,
	MiddleName NVARCHAR(100),
	LastName NVARCHAR(100) NOT NULL,
	JobTitle NVARCHAR(100),
	DepartmentId INT NOT NULL,
	HireDate DATE,
	Salary NUMERIC(18,2),
	AddressId INT NOT NULL,
	CONSTRAINT PK_Employees PRIMARY KEY (Id),
	CONSTRAINT FK_EmployeesDepartmentId FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
	CONSTRAINT FK_EmployeesAddressId FOREIGN KEY (AddressId) REFERENCES Addresses(Id),
);

INSERT 
	INTO Employees 
		(FirstName, LastName, DepartmentId, AddressId)
	VALUES 
		('Ivan', 'Ivanov', 4, 4),
		('Petar', 'Petrov', 1, 1),
		('Maria', 'Ivanova', 5, 1),
		('Georgi', 'Ivanov', 2, 2),
		('Peter', 'Pan', 3, 3);

--SELECT * FROM Employees;


-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
-- 17.	Backup Database
-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
USE master
BACKUP DATABASE SoftUni
TO DISK = 'C:\Temp\SoftUni20230114.bak';

--USE master
--DROP DATABASE Hotel;

USE master
RESTORE DATABASE SoftUni 
FROM DISK = 'C:\Temp\SoftUni20230114.bak'


--------------------------------------------------------------------
--------------------------------------------------------------------
-- 18.	Basic Insert

USE SoftUni;

-- See task 16

-- DELETE FROM Towns;

INSERT 
	INTO Towns 
		([Name])
	VALUES 
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas');

-- DELETE FROM Departments;

INSERT 
	INTO Departments 
		([Name])
	VALUES 
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance');

--SELECT * FROM Departments;

-- DELETE FROM Employees;

INSERT 
	INTO Employees 
		(FirstName, MiddleName, LastName, JobTitle, DepartmentId, AddressId, HireDate, Salary)
	VALUES 
		('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, 4, CONVERT(DATE, '01/02/2013', 103), 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, 1, CONVERT(DATE, '02/03/2004', 103), 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, 1, CONVERT(DATE, '28/08/2016', 103), 525.25),
		('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, 2, CONVERT(DATE, '09/12/2007', 103), 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 3, 3, CONVERT(DATE, '28/08/2016', 103), 599.88);


--SELECT * FROM Employees;


--------------------------------------------------------------------
--------------------------------------------------------------------
-- 19.	Basic Select All Fields

SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;


--------------------------------------------------------------------
--------------------------------------------------------------------
-- 20.	Basic Select All Fields and Order Them

SELECT * FROM Towns
	ORDER BY [Name] ASC;
SELECT * FROM Departments
	ORDER BY [Name] ASC;
SELECT * FROM Employees
	ORDER BY Salary DESC;


--------------------------------------------------------------------
--------------------------------------------------------------------
-- 21.	Basic Select Some Fields

SELECT [Name] FROM Towns
	ORDER BY [Name] ASC;
SELECT [Name] FROM Departments
	ORDER BY [Name] ASC;
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
	ORDER BY Salary DESC;


--------------------------------------------------------------------
--------------------------------------------------------------------
-- 22.	Increase Employees Salary

UPDATE Employees
	SET Salary = Salary * 1.1;

SELECT Salary FROM Employees;


--------------------------------------------------------------------
--------------------------------------------------------------------
-- 23.	Decrease Tax Rate

USE Hotel;

UPDATE Payments
	SET TaxRate = TaxRate * 0.97;

SELECT TaxRate FROM Payments;


--------------------------------------------------------------------
--------------------------------------------------------------------
-- 24.	Delete All Records

USE Hotel;

DELETE FROM Occupancies;

-- SELECT * FROM Occupancies;



