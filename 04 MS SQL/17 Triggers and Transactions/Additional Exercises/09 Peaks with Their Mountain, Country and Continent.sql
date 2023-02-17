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
-- 9.	Peaks with Their Mountain, Country and Continent
--


SELECT
	p.PeakName AS [PeakName]
	, m.MountainRange AS [Mountain]
	, c.CountryName AS [CountryName]
	, ct.ContinentName AS [ContinentName]
FROM
	Peaks AS p
	JOIN Mountains AS m
	ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc
	ON m.Id = mc.MountainId
	JOIN Countries AS c 
	ON mc.CountryCode = c.CountryCode
	JOIN Continents AS ct
	ON c.ContinentCode = ct.ContinentCode
ORDER BY
	p.PeakName ASC
	, c.CountryName ASC



