-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 8. Exercises: Table Relations
--

--CREATE DATABASE ExTableRelations
--	COLLATE Cyrillic_General_CI_AS;
--USE ExTableRelations;

-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 1.	One-To-One Relationship
--
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

INSERT INTO Passports
	(PassportNumber)
	VALUES
		('N34FG21B')
		,('K65LO4R7')
		,('ZE657QP2');

-- SELECT * FROM Passports

INSERT INTO Persons
	(FirstName, Salary, PassportID)
	VALUES
		('Roberto', 43300.00, 102)
		,('Tom', 56100.00, 103)
		,('Yana', 60200.00, 101);

-- SELECT * FROM Persons


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 2.	One-To-Many Relationship
--
CREATE TABLE Manufacturers
(
	ManufacturerID BIGINT IDENTITY(1,1) NOT NULL
	,[Name] VARCHAR(150) NOT NULL
	,EstablishedOn DATE
	,CONSTRAINT PK_Manufacturers PRIMARY KEY (ManufacturerID)
);

CREATE TABLE Models
(
	ModelID BIGINT IDENTITY(101,1) NOT NULL
	,[Name] VARCHAR(150) NOT NULL
	,ManufacturerID BIGINT NOT NULL
	,CONSTRAINT PK_Models PRIMARY KEY (ModelID)
	,CONSTRAINT FK_Models_ManufacturerID FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
);

INSERT INTO Manufacturers
	([Name], EstablishedOn)
	VALUES
		('BMW', '07/03/1916')
		,('Tesla', '01/01/2003')
		,('Lada', '01/05/1966');

-- SELECT * FROM Manufacturers

INSERT INTO Models
	([Name], ManufacturerID)
	VALUES
		('X1', 1)
		,('i6',	1)
		,('Model S', 2)
		,('Model X', 2)
		,('Model 3', 2)
		,('Nova	3', 3);

-- SELECT * FROM Models


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 3.	Many-To-Many Relationship
--
CREATE TABLE Students
(
	StudentID BIGINT IDENTITY(1,1) NOT NULL
	,[Name] NVARCHAR(150) NOT NULL
	,CONSTRAINT PK_Students PRIMARY KEY (StudentID)
);

CREATE TABLE Exams
(
	ExamID BIGINT IDENTITY(101,1) NOT NULL
	,[Name] NVARCHAR(150) NOT NULL
	,CONSTRAINT PK_Exams PRIMARY KEY (ExamID)
);

CREATE TABLE StudentsExams
(
	StudentID BIGINT NOT NULL
	,ExamID BIGINT NOT NULL
	,CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID)
	,CONSTRAINT FK_StudentsExams_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
	,CONSTRAINT FK_StudentsExams_ExamID FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);

INSERT INTO Students
	([Name])
	VALUES
		('Mila')                              
		,('Toni')
		,('Ron');

-- SELECT * FROM Students

INSERT INTO Exams
	([Name])
	VALUES
		('SpringMVC')                              
		,('Neo4j')
		,('Oracle 11g');

-- SELECT * FROM Exams

INSERT INTO StudentsExams
	(StudentID, ExamID)
	VALUES
		(1, 101)                              
		,(1, 102)
		,(2, 101)
		,(3, 103)
		,(2, 102)
		,(2, 103)
		;

-- SELECT * FROM StudentsExams


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 4.	Self-Referencing 
--
CREATE TABLE Teachers
(
	TeacherID BIGINT IDENTITY(101,1) NOT NULL
	,[Name] NVARCHAR(150) NOT NULL
	,ManagerID BIGINT
	,CONSTRAINT PK_Teachers PRIMARY KEY (TeacherID)
	,CONSTRAINT FK_Teachers_Managers FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
);

INSERT INTO Teachers
	([Name], ManagerID)
	VALUES
		('John', NULL)                              
		,('Maya', 106)
		,('Silvia', 106)
		,('Ted', 105)
		,('Mark', 101)
		,('Greta', 101)
		;

-- SELECT * FROM Teachers


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 5.	Online Store Database 
--
--CREATE DATABASE OnlineStore
--	COLLATE Cyrillic_General_CI_AS;
--USE OnlineStore;

CREATE TABLE ItemTypes
(
	ItemTypeID BIGINT IDENTITY(1,1) NOT NULL
	,[Name] NVARCHAR(150)
	,CONSTRAINT PK_ItemTypes PRIMARY KEY (ItemTypeID)
);

CREATE TABLE Items
(
	ItemID BIGINT IDENTITY(1,1) NOT NULL
	,[Name] NVARCHAR(150)
	,ItemTypeID BIGINT NOT NULL
	,CONSTRAINT PK_Items PRIMARY KEY (ItemID)
	,CONSTRAINT FK_Items_ItemTypeID FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
);

CREATE TABLE Cities
(
	CityID BIGINT IDENTITY(1,1) NOT NULL
	,[Name] NVARCHAR(150)
	,CONSTRAINT PK_Cities PRIMARY KEY (CityID)
);

CREATE TABLE Customers
(
	CustomerID BIGINT IDENTITY(1,1) NOT NULL
	,[Name] NVARCHAR(150)
	,Birthday DATE
	,CityID BIGINT NOT NULL
	,CONSTRAINT PK_Customers PRIMARY KEY (CustomerID)
	,CONSTRAINT FK_Customers_CityID FOREIGN KEY (CityID) REFERENCES Cities(CityID)
);

CREATE TABLE Orders
(
	OrderID BIGINT IDENTITY(1,1) NOT NULL
	,CustomerID BIGINT NOT NULL
	,CONSTRAINT PK_Orders PRIMARY KEY (OrderID)
	,CONSTRAINT FK_Orders_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems
(
	OrderID BIGINT NOT NULL
	,ItemID BIGINT NOT NULL
	,CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID)
	,CONSTRAINT FK_OrderItems_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
	,CONSTRAINT FK_OrderItems_ItemID FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
);


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 6.	University Database
--
--CREATE DATABASE University
--	COLLATE Cyrillic_General_CI_AS;
--USE University;

CREATE TABLE Majors
(
	MajorID BIGINT IDENTITY(1,1) NOT NULL
	,[Name] NVARCHAR(150) NOT NULL
	,CONSTRAINT PK_Majors PRIMARY KEY (MajorID)
);

CREATE TABLE Students
(
	StudentID BIGINT IDENTITY(1,1) NOT NULL
	,StudentNumber VARCHAR(20) NOT NULL
	,StudentName NVARCHAR(150) NOT NULL
	,MajorID BIGINT NOT NULL
	,CONSTRAINT PK_Students PRIMARY KEY (StudentID)
	,CONSTRAINT FK_Students_MajorID FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
);

CREATE TABLE Payments
(
	PaymentID BIGINT IDENTITY(1,1) NOT NULL
	,PaymentDate DATE
	,PaymentAmmount NUMERIC(18,5)
	,StudentID BIGINT NOT NULL
	,CONSTRAINT PK_Payments PRIMARY KEY (PaymentID)
	,CONSTRAINT FK_Payments_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
);

CREATE TABLE Subjects
(
	SubjectID BIGINT IDENTITY(1,1) NOT NULL
	,SubjectName NVARCHAR(150) NOT NULL
	,CONSTRAINT PK_Subjects PRIMARY KEY (SubjectID)
);

CREATE TABLE Agenda
(
	StudentID BIGINT NOT NULL
	,SubjectID BIGINT NOT NULL
	,CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
	,CONSTRAINT FK_Agenda_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
	,CONSTRAINT FK_Agenda_SubjectID FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 9.	*Peaks in Rila
--
-- USE Geography;
SELECT m.MountainRange, p.PeakName, p.Elevation 
FROM Peaks AS p
INNER JOIN Mountains AS m
ON m.MountainRange = 'Rila' AND p.MountainId = m.Id
--WHERE
--	m.MountainRange = 'Rila'
ORDER BY
	p.Elevation DESC;



