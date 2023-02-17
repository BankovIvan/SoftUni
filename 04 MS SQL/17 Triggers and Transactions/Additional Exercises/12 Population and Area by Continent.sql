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
-- 12.	Population and Area by Continent
--


SELECT
	ct.ContinentName AS [ContinentName]
	, SUM(CAST(c.AreaInSqKm AS BIGINT)) AS [CountriesArea]
	, SUM(CAST(c.[Population] AS BIGINT)) AS [CountriesPopulation]
FROM
	Continents AS ct
	LEFT JOIN Countries AS c
	ON ct.ContinentCode = c.ContinentCode
GROUP BY
	ct.ContinentCode
	, ct.ContinentName
ORDER BY
	SUM(CAST(c.[Population] AS BIGINT)) DESC




