------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exercises: Additional Exercises
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- PART II – Queries for Geography Database
--
--USE Geography;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 14.	Monasteries by Continents and Countries
--


UPDATE Countries
SET
	CountryName = 'Burma'
WHERE
	CountryName = 'Myanmar'


INSERT INTO Monasteries
(
	[Name]
	, CountryCode
) 
VALUES
	('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))
	, ('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar')) -- Myanmar / Burma ???



SELECT
	ct.ContinentName AS [ContinentName] 
	, c.CountryName AS [CountryName]
	, COUNT(m.CountryCode) AS [MonasteriesCount]
FROM
	Countries AS c
	LEFT JOIN Continents AS ct
	ON c.ContinentCode = ct.ContinentCode
	LEFT JOIN Monasteries AS m
	ON c.CountryCode = m.CountryCode
WHERE
	c.IsDeleted = 0
GROUP BY
	ct.ContinentCode
	, ct.ContinentName
	, c.CountryCode
	, c.CountryName
ORDER BY
	COUNT(m.CountryCode) DESC
	, c.CountryName ASC




