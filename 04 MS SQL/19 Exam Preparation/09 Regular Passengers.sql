------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 19. Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 3. Querying (40 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 9.	Regular Passengers


--USE Airport;


SELECT
	p.FullName AS [FullName]
	, COUNT(*) AS [CountOfAircraft]
	, SUM(d.TicketPrice) AS [TotalPayed]
FROM
	Passengers AS p
	JOIN FlightDestinations AS d
	ON d.PassengerId = p.Id
	JOIN Aircraft AS a
	ON d.AircraftId = a.Id
WHERE
	SUBSTRING(TRIM(p.FullName), 2, 1) = 'a'
GROUP BY
	p.Id, 
	p.FullName
HAVING
	COUNT(*) > 1
ORDER BY
	p.FullName










