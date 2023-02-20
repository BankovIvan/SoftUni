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
-- 9.	Creators with Emails
--

--USE Boardgames;


SELECT
	CONCAT_WS(' ', cr.FirstName, cr.LastName) AS [FullName]
	, cr.Email AS [Email]
	, MAX(b.Rating) AS [Rating] --OVER (PARTITION BY cr.Id ORDER BY b.Rating)
FROM
	Creators AS cr
	JOIN CreatorsBoardgames AS cb
	ON cr.Id = cb.CreatorId
	JOIN Boardgames AS b
	ON b.Id = cb.BoardgameId
WHERE
	RIGHT(cr.Email, 4) = '.com'
GROUP BY
	cr.Id 
	, CONCAT_WS(' ', cr.FirstName, cr.LastName)
	, cr.Email
ORDER BY
	CONCAT_WS(' ', cr.FirstName, cr.LastName) ASC

