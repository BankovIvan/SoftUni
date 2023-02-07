------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 3. Querying (40 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 8.	Owners, Animals and Cages
--


--USE Zoo;


SELECT
	CONCAT(o.[Name], '-', a.[Name]) AS [OwnersAnimals] 
	, o.PhoneNumber  AS [PhoneNumber]
	, ac.CageId AS [CageId]
FROM
	Owners AS o
	JOIN Animals AS a
	ON a.OwnerId = o.Id
	JOIN AnimalsCages AS ac
	ON a.Id = ac.AnimalId
	JOIN AnimalTypes AS at
	ON a.AnimalTypeId = at.Id
WHERE
	at.AnimalType = 'mammals'
ORDER BY
	o.[Name] ASC
	, a.[Name] DESC













