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
-- 10.	Full Info for Flight Destinations


--USE Airport;


SELECT
	l.AirportName AS [AirportName]
	, d.[Start] AS [DayTime]
	, d.TicketPrice AS [TicketPrice]
	, p.FullName AS [FullName]
	, a.Manufacturer AS [Manufacturer]
	, a.Model AS [Model]
FROM
	FlightDestinations AS d
	LEFT JOIN Airports AS l
	ON d.AirportId = l.Id
	LEFT JOIN Passengers AS p
	ON d.PassengerId = p.Id
	LEFT JOIN Aircraft AS a
	ON d.AircraftId = a.Id
WHERE
	CAST(d.[Start] AS TIME) BETWEEN '06:00' AND '20:00'
	AND d.TicketPrice > 2500
ORDER BY
	a.Model ASC











