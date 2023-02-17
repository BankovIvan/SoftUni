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
-- 4.	*User in Games with Their Statistics
--


SELECT
	u.Username AS [Username]
	, g.[Name] AS [Game]
	--, g.Id AS [Game Id]
	, MAX(c.[Name]) AS [Character] 
	, MAX(s.Strength) + MAX(sgt.Strength) + SUM(si.Strength) AS [Strength]
	, MAX(s.Defence) + MAX(sgt.Defence) + SUM(si.Defence) AS [Defence]
	, MAX(s.Speed) + MAX(sgt.Speed) + SUM(si.Speed) AS [Speed]
	, MAX(s.Mind) + MAX(sgt.Mind) + SUM(si.Mind) AS [Mind]
	, MAX(s.Luck) + MAX(sgt.Luck) + SUM(si.Luck) AS [Luck]
FROM
	Users AS u
	JOIN UsersGames AS ug
	ON u.Id = ug.UserId
	JOIN Games AS g
	ON g.Id = ug.GameId
	JOIN Characters AS c
	ON c.Id = ug.CharacterId
	JOIN [Statistics] AS s
	ON c.StatisticId = s.Id

	JOIN GameTypes AS gt
	ON g.GameTypeId = gt.Id

	JOIN [Statistics] AS sgt
	ON gt.BonusStatsId = sgt.Id

	JOIN UserGameItems AS ugi
	--ON g.Id = ugi.UserGameId
	-- ALWAYS 'ON' OVER THE RELATION LINK !!!
	-- STUPID MISTAKE !!!
	-- https://github.com/KiroKirilov/SoftUni/tree/master/ProfessionalModules/C%23DBFundamentals/DatabasesBasics/AdditionalExercises/AdditionalExercises
	ON ug.Id = ugi.UserGameId

	JOIN [Items] AS i
	ON ugi.ItemId = i.Id
	JOIN [Statistics] AS si
	ON i.StatisticId = si.Id
--WHERE
--	u.Username = 'skippingside'
GROUP BY
	u.Username
	, g.[Name]
ORDER BY
	MAX(s.Strength) + MAX(sgt.Strength) + SUM(si.Strength) DESC
	, MAX(s.Defence) + MAX(sgt.Defence) + SUM(si.Defence) DESC
	, MAX(s.Speed) + MAX(sgt.Speed) + SUM(si.Speed) DESC
	, MAX(s.Mind) + MAX(sgt.Mind) + SUM(si.Mind) DESC
	, MAX(s.Luck) + MAX(sgt.Luck) + SUM(si.Luck) DESC













