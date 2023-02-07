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
-- 6.	Animals data
--


--USE Zoo;


SELECT 
	a.[Name] AS [Name]
	, at.AnimalType AS [AnimalType]
	, FORMAT(a.BirthDate, 'dd.MM.yyyy')  AS [BirthDate]
FROM
	Animals AS a
	LEFT JOIN AnimalTypes AS at
	ON a.AnimalTypeId = at.Id
ORDER BY
	[Name] ASC

















