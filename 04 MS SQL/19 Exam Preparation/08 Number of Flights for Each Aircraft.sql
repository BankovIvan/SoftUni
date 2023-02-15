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
-- 8.	Number of Flights for Each Aircraft


--USE Airport;


SELECT
	*
FROM
(
	SELECT DISTINCT
		a.Id AS [AircraftId]
		, a.Manufacturer AS [Manufacturer]
		, a.FlightHours AS [FlightHours]
		, COUNT(d.Id) OVER (PARTITION BY a.Id) AS [FlightDestinationsCount]
		, ROUND(AVG(d.TicketPrice) OVER (PARTITION BY a.Id), 2) AS [AvgPrice]
	FROM
		Aircraft AS a
		LEFT JOIN FlightDestinations AS d
		ON a.Id = d.AircraftId
) 
AS 
	sq1
WHERE
	sq1.[FlightDestinationsCount] >= 2
ORDER BY
	sq1.[FlightDestinationsCount] DESC
	, sq1.[AircraftId] ASC


/*
SELECT 
	a.Id AS [AircraftId]
	--, a.Manufacturer AS [Manufacturer]
	--, a.FlightHours AS [FlightHours]
	, COUNT(*) AS [FlightDestinationsCount]
	, ROUND(AVG(d.TicketPrice), 2)  AS [AvgPrice]
FROM
	Aircraft AS a
	LEFT JOIN FlightDestinations AS d
	ON a.Id = d.AircraftId
GROUP BY 
	a.Id
HAVING
	COUNT(*) >= 2
ORDER BY
	COUNT(*) DESC
	, a.Id ASC
*/














