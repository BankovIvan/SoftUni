------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 4. Programmability (20 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 12.	Animals with Owner or Not
--


--USE Zoo;


CREATE PROCEDURE usp_AnimalsWithOwnersOrNot 
(
	@AnimalName VARCHAR(30)
)
AS
BEGIN

	SELECT
		a.[Name] AS [Name]
		, IIF(o.[Name] IS NULL, 'For adoption', o.[Name]) AS [OwnersName]
	FROM
		Animals AS a
		LEFT JOIN Owners AS o
		ON a.OwnerId = o.Id
	WHERE
		a.[Name] = @AnimalName
		--a.[Name] = 'Pumpkinseed Sunfish'

END;
	
-- EXECUTE usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
-- EXECUTE usp_AnimalsWithOwnersOrNot 'Hippo'
-- EXECUTE usp_AnimalsWithOwnersOrNot 'Brown bear'










