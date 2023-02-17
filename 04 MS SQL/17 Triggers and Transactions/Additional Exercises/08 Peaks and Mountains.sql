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
-- 8.	Peaks and Mountains
--


SELECT
	p.PeakName AS [PeakName]
	, m.MountainRange AS [Mountain]
	, p.Elevation AS [Elevation]
FROM
	Peaks AS p
	JOIN Mountains AS m
	ON p.MountainId = m.Id
ORDER BY
	p.Elevation DESC



