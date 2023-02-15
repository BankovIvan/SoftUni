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
-- 11.	Find all Destinations by Email Address


--USE Airport;


CREATE FUNCTION udf_FlightDestinationsByEmail
(
	@email VARCHAR(50)
) 
RETURNS
	INT
AS
	BEGIN

	DECLARE @FlightDestinations INT = 0;

	SET @FlightDestinations = 
		(
		SELECT
			COUNT(*)
		FROM
			FlightDestinations AS d
			JOIN Passengers AS p
			ON d.PassengerId = p.Id
		WHERE
			p.Email = @email
			--p.Email = 'PierretteDunmuir@gmail.com'
			--p.Email = 'Montacute@gmail.com'
			--p.Email = 'KUR'
		);

	RETURN @FlightDestinations;

	END


-- SELECT dbo.udf_FlightDestinationsByEmail('PierretteDunmuir@gmail.com')
-- SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
-- SELECT dbo.udf_FlightDestinationsByEmail('KUR')
-- SELECT dbo.udf_FlightDestinationsByEmail(NULL)
