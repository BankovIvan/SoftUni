------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 19. Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 1. DDL (30 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 1.	Database design
--

--CREATE DATABASE Airport; 
--USE Airport;


CREATE TABLE Passengers 
(
	Id INT NOT NULL IDENTITY(1, 1)
	, FullName VARCHAR(100) UNIQUE NOT NULL
	, Email VARCHAR(50) UNIQUE NOT NULL
	, CONSTRAINT PK_Passengers PRIMARY KEY (Id)
);


CREATE TABLE Pilots
(
	Id INT NOT NULL IDENTITY(1, 1)
	, FirstName VARCHAR(30) UNIQUE NOT NULL
	, LastName VARCHAR(30) UNIQUE NOT NULL
	, Age TINYINT NOT NULL
	--, Rating DECIMAL(2,1)
	, Rating FLOAT
	, CONSTRAINT PK_Pilots PRIMARY KEY (Id)
	, CONSTRAINT CHK_Pilots_Age CHECK (Age BETWEEN 21 AND 62)
	, CONSTRAINT CHK_Pilots_Rating CHECK ((Rating BETWEEN 0.0 AND 10.0) OR (Rating IS NULL))
);


CREATE TABLE AircraftTypes
(
	Id INT NOT NULL IDENTITY(1, 1)
	, TypeName VARCHAR(30) UNIQUE NOT NULL 
	, CONSTRAINT PK_AircraftTypes PRIMARY KEY (Id)
);


CREATE TABLE Aircraft
(
	Id INT NOT NULL IDENTITY(1, 1)
	, Manufacturer VARCHAR(25) NOT NULL
	, Model VARCHAR(30) NOT NULL
	, [Year] INT NOT NULL
	, FlightHours INT
	, Condition CHAR NOT NULL
	, TypeId INT NOT NULL
	, CONSTRAINT PK_Aircraft PRIMARY KEY (Id)
	, CONSTRAINT FK_Aircraft_AircraftTypes FOREIGN KEY (TypeId) REFERENCES AircraftTypes(Id)
);


CREATE TABLE PilotsAircraft
(
	AircraftId INT NOT NULL
	, PilotId INT NOT NULL
	, CONSTRAINT PK_PilotsAircraft PRIMARY KEY (AircraftId, PilotId)
	, CONSTRAINT FK_PilotsAircraft_Aircraft FOREIGN KEY (AircraftId) REFERENCES Aircraft(Id)
	, CONSTRAINT FK_PilotsAircraft_Pilots FOREIGN KEY (PilotId) REFERENCES Pilots(Id)
);


CREATE TABLE Airports
(
	Id INT NOT NULL IDENTITY(1, 1)
	, AirportName VARCHAR(70) UNIQUE NOT NULL
	, Country VARCHAR(100) UNIQUE NOT NULL
	, CONSTRAINT PK_Airports PRIMARY KEY (Id)
);


CREATE TABLE FlightDestinations
(
	Id INT NOT NULL IDENTITY(1, 1)
	, AirportId INT NOT NULL
	, [Start] DATETIME NOT NULL
	, AircraftId INT NOT NULL
	, PassengerId INT NOT NULL
	, TicketPrice DECIMAL(18, 2) NOT NULL CONSTRAINT DF_FlightDestinations_TicketPrice DEFAULT 15.0
	, CONSTRAINT PK_FlightDestinations PRIMARY KEY (Id)
	, CONSTRAINT FK_FlightDestinations_Airports FOREIGN KEY (AirportId) REFERENCES Airports(Id)
	, CONSTRAINT FK_FlightDestinations_Aircraft FOREIGN KEY (AircraftId) REFERENCES Aircraft(Id)
	, CONSTRAINT FK_FlightDestinations_Passengers FOREIGN KEY (PassengerId) REFERENCES Passengers(Id)
);










