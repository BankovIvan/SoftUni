------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 3. Querying (40 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 10.	Animals for Adoption
--


--USE Zoo;


SELECT
	a.[Name] AS [Name]
	, DATEPART(year, a.BirthDate) AS [BirthYear]
	, t.AnimalType AS [AnimalType]
FROM
	Animals AS a
	JOIN AnimalTypes AS t
	ON t.Id = a.AnimalTypeId
WHERE
	a.OwnerId IS NULL
	AND t.AnimalType != 'Birds'
	AND DATEPART(year, a.BirthDate) > (2022 - 5)
ORDER BY
	a.[Name] ASC













