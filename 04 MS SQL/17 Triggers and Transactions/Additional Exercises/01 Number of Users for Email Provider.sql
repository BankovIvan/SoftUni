------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exercises: Additional Exercises
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- PART I – Queries for Diablo Database
--
--USE Diablo;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 1.	Number of Users for Email Provider
--


SELECT
	RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
	, COUNT(*) AS [Number Of Users]
FROM
	Users
GROUP BY
	RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
ORDER BY
	COUNT(*) DESC
	, RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) ASC





