------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exercises: Additional Exercises
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- PART I – Queries for Diablo Database
--
--USE Diablo;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 2.	All User in Games
--


SELECT
	g.Name AS [Game]
	, gt.Name AS [Game Type]
	, u.Username AS [Username]
	, ug.Level AS [Level]
	, ug.Cash AS [Cash]
	, c.Name AS [Character]
FROM
	Games AS g
	LEFT JOIN GameTypes as gt 
	ON g.GameTypeId = gt.Id
	JOIN UsersGames AS ug
	ON g.Id = ug.GameId
	JOIN Users AS u
	ON ug.UserId = u.Id
	LEFT JOIN Characters AS c
	ON ug.CharacterId = c.Id
ORDER BY
	ug.Level DESC
	, u.Username ASC
	, g.Name ASC






