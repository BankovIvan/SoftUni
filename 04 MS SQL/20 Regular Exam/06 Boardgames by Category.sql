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
-- 6.	Boardgames by Category
--

--USE Boardgames;


SELECT
	b.Id
	, b.[Name]
	, b.YearPublished
	, c.[Name] AS CategoryName
FROM
	Boardgames AS b
	JOIN Categories AS c
	ON b.CategoryId = c.Id
WHERE
	c.[Name] IN ('Strategy Games', 'Wargames')
ORDER BY
	b.YearPublished DESC



