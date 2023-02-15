------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 19. Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 4. Programmability (20 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 12.	Full Info for Airports


--USE Airport;


CREATE PROCEDURE usp_SearchByAirportName
(
	@airportName VARCHAR(70)
) 
AS
	BEGIN

	SELECT
		l.AirportName AS [AirportName]
		, p.FullName AS [FullName]
		--, d.TicketPrice AS [LevelOfTickerPrice]
		, (CASE
			WHEN d.TicketPrice <= 400 THEN 'Low'
			WHEN d.TicketPrice > 1500 THEN 'High'
			ELSE 'Medium'
			END)
			AS [LevelOfTickerPrice]
		, a.Manufacturer AS [Manufacturer]
		, a.Condition AS [Condition]
		, t.TypeName AS [TypeName]
	FROM
		Airports AS l
		LEFT JOIN FlightDestinations AS d
		ON d.AirportId = l.Id
		LEFT JOIN Passengers AS p
		ON d.PassengerId = p.Id
		LEFT JOIN Aircraft AS a
		ON d.AircraftId = a.Id
		LEFT JOIN AircraftTypes AS t
		ON a.TypeId = t.Id
	WHERE
		l.AirportName = @airportName
		--l.AirportName = 'Sir Seretse Khama International Airport'
	ORDER BY
		a.Manufacturer ASC
		, p.FullName ASC

	END


-- EXECUTE usp_SearchByAirportName 'Sir Seretse Khama International Airport'
