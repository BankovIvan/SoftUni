------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 19. Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 2. DML (10 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 4.	Delete


--USE Airport;

ALTER TABLE 
	FlightDestinations
ALTER COLUMN
	PassengerId INT NULL


/*
UPDATE FlightDestinations
SET
	PassengerId = NULL
WHERE
	PassengerId IN (SELECT Id FROM Passengers WHERE LEN(FullName) <= 10))
*/


UPDATE d
SET
	d.PassengerId = NULL
FROM
	Passengers AS p
	LEFT JOIN FlightDestinations as d
	ON p.Id = d.PassengerId
WHERE
	LEN(p.FullName) <= 10


DELETE FROM Passengers
WHERE
	LEN(FullName) <= 10


/*
SELECT
	*
FROM
	Passengers AS p
	JOIN FlightDestinations as d
	ON p.Id = d.PassengerId
WHERE
	LEN(p.FullName) <= 10
*/








