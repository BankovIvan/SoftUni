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
-- 7.	Top 20 Flight Destinations


--USE Airport;


SELECT TOP(20)
	d.Id AS [DestinationId]
	, d.Start AS [Start]
	, p.FullName AS [FullName]
	, l.AirportName AS [AirportName]
	, d.TicketPrice AS [TicketPrice]
FROM
	FlightDestinations AS d
	LEFT JOIN Passengers AS p
	ON d.PassengerId = p.Id 
	LEFT JOIN Airports AS l
	ON d.AirportId = l.Id
WHERE
	DATEPART(day, d.Start) % 2 = 0
ORDER BY
	d.TicketPrice DESC
	, l.AirportName ASC















