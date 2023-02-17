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
-- 10.	Rivers by Country
--


SELECT
	c.CountryName AS [CountryName]
	, ct.ContinentName AS [ContinentName]
	, COUNT(r.Id) AS [RiversCount]
	, ISNULL(SUM(r.[Length]), 0) AS [TotalLength]
FROM
	Countries AS c 
	LEFT JOIN Continents AS ct
	ON c.ContinentCode = ct.ContinentCode
	LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
GROUP BY
	ct.ContinentCode
	, ct.ContinentName
	, c.CountryCode
	, c.CountryName
ORDER BY
	COUNT(r.Id) DESC
	, SUM(r.[Length]) DESC
	, c.CountryName ASC



