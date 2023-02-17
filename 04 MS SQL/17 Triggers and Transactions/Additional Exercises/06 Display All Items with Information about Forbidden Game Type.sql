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
-- 6.	Display All Items with Information about Forbidden Game Type
--


SELECT
	i.[Name] AS [Item]
	, i.Price AS [Price]
	, i.MinLevel AS [MinLevel]
	, t.[Name] AS [Forbidden Game Type]
FROM
	[Items] AS i
	LEFT JOIN GameTypeForbiddenItems AS f
	ON i.Id = f.ItemId
	LEFT JOIN GameTypes AS t
	ON f.GameTypeId = t.Id
ORDER BY
	t.[Name] DESC
	, i.[Name] ASC






