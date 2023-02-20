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
-- 7.	Creators without Boardgames
--

--USE Boardgames;


SELECT
	c.Id
	, CONCAT_WS(' ', c.FirstName, c.LastName) AS CreatorName
	, c.Email
FROM
	Creators AS c
	LEFT JOIN CreatorsBoardgames AS cb
	ON c.Id = cb.CreatorId
WHERE
	cb.CreatorId IS NULL
ORDER BY
	CONCAT_WS(' ', c.FirstName, c.LastName) ASC



