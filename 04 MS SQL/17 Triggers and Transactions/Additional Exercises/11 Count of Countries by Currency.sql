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
-- 11.	Count of Countries by Currency
--


SELECT
	cur.CurrencyCode AS [CurrencyCode]
	, cur.[Description] AS [Currency]
	, COUNT(c.CountryCode) AS [NumberOfCountries]
FROM
	Currencies AS cur
	LEFT JOIN Countries AS c
	ON c.CurrencyCode = cur.CurrencyCode
GROUP BY
	cur.CurrencyCode
	, cur.[Description]
ORDER BY
	COUNT(c.CountryCode) DESC
	, cur.[Description] ASC



