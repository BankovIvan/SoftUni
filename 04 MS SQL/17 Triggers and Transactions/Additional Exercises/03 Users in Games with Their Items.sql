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
-- 3.	Users in Games with Their Items
--


SELECT
	u.Username AS [Username]
	, g.Name AS [Game]
	, COUNT(*)
	, SUM(i.Price)
FROM
	Games AS g
	JOIN UsersGames AS ug
	ON g.Id = ug.GameId
	JOIN Users AS u
	ON ug.UserId = u.Id
	LEFT JOIN UserGameItems AS ugi
	ON ug.Id = ugi.UserGameId
	LEFT JOIN Items AS i
	ON ugi.ItemId = i.Id
GROUP BY
	u.Username
	, g.Name
HAVING
	COUNT(*) >= 10
ORDER BY
	COUNT(*) DESC
	, SUM(i.Price) DESC
	, u.Username ASC






