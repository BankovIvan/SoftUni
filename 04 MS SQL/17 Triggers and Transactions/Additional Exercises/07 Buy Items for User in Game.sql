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
-- 7.	Buy Items for User in Game
--

DECLARE @UserGameID INT = 
	(
	SELECT
		ug.Id
	FROM
		UsersGames AS ug
		JOIN Users AS u
		ON ug.UserId = u.Id
		JOIN Games AS g
		ON ug.GameId = g.Id
	WHERE
		u.Username = 'Alex'
		AND g.[Name] = 'Edinburgh'
	)


-----
INSERT INTO UserGameItems 
SELECT
	Id AS [ItemId]
	, @UserGameID AS [UserGameId]
FROM
	Items
WHERE
	[Name] IN (
				'Blackguard'
				, 'Bottomless Potion of Amplification'
				, 'Eye of Etlich (Diablo III)'
				, 'Gem of Efficacious Toxin'
				, 'Golden Gorget of Leoric'
				, 'Hellfire Amulet'
				)


-----
UPDATE UsersGames
SET
	Cash = Cash - (
					SELECT 
						SUM(Price) 
					FROM 
						Items 
					WHERE 
						[Name] IN 
								(
									'Blackguard'
									, 'Bottomless Potion of Amplification'
									, 'Eye of Etlich (Diablo III)'
									, 'Gem of Efficacious Toxin'
									, 'Golden Gorget of Leoric'
									, 'Hellfire Amulet'	)
					)
WHERE
	Id = @UserGameID


-----
SELECT
	u.Username AS [Username]
	, g.[Name] AS [Name]
	, ug.Cash AS [Cash]
	, i.[Name] AS [Name]
	--, DENSE_RANK() OVER (ORDER BY u.Username)
FROM
	Games AS g
	JOIN UsersGames AS ug
	ON g.Id = ug.GameId
	JOIN Users AS u
	ON ug.UserId = u.Id
	JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
	JOIN Items AS i
	ON i.Id = ugi.ItemId
WHERE
	g.[Name] = 'Edinburgh'
ORDER BY
	i.[Name] ASC





