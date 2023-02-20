------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Database Basics MS SQL Exam – 12 Feb 2023
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 3. Querying (40 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 8.	First 5 Boardgames
--

--USE Boardgames;


SELECT TOP(5)
	b.[Name] AS [Name]
	, b.Rating AS [Rating]
	, c.[Name] AS [CategoryName]
FROM
	Boardgames AS b
	LEFT JOIN PlayersRanges AS pr
	ON b.PlayersRangeId = pr.Id
	LEFT JOIN Categories AS c
	ON b.CategoryId = c.Id
WHERE
	(b.Rating > 7.00 AND b.[Name] LIKE '%a%')
	OR (b.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5)
ORDER BY
	b.[Name] ASC
	, b.Rating



