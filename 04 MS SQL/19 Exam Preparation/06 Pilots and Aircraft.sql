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
-- 6.	Pilots and Aircraft


--USE Airport;


SELECT
	p.FirstName AS [FirstName]
	, p.LastName AS [LastName]
	, a.Manufacturer AS [Manufacturer]
	, a.Model AS [Model]
	, a.FlightHours AS [FlightHours]
FROM
	Pilots AS p
	JOIN PilotsAircraft AS pa
	ON p.Id = pa.PilotId
	JOIN Aircraft AS a
	ON a.Id = pa.AircraftId
WHERE
	a.FlightHours < 304
ORDER BY
	a.FlightHours DESC
	, p.FirstName ASC














