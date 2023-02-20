------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Database Basics MS SQL Exam – 12 Feb 2023
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 2. DML (10 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 4.	Delete
--

--USE Boardgames;



ALTER TABLE Publishers
ALTER COLUMN
	AddressId INT NULL;


UPDATE p
SET
	p.AddressId = NULL
FROM
	Publishers AS p
	JOIN Addresses AS a
	ON p.AddressId = a.Id
WHERE
	--LEFT(a.Town, 1) = 'L'
	a.Country IN (SELECT Country FROM Addresses WHERE LEFT(Town, 1) = 'L' GROUP BY Country)


DELETE FROM Addresses
WHERE
	--LEFT(Town, 1) = 'L'
	Country IN (SELECT Country FROM Addresses WHERE LEFT(Town, 1) = 'L' GROUP BY Country)


