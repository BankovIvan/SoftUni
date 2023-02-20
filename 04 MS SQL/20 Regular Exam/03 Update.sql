------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Database Basics MS SQL Exam � 12 Feb 2023
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 2. DML (10 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 3.	Update
--

--USE Boardgames;


UPDATE PlayersRanges
SET	
	PlayersMax = 3
WHERE
	PlayersMin = 2
	AND PlayersMax = 2


UPDATE Boardgames
SET	
	[Name] = CONCAT([Name], 'V2')
WHERE
	YearPublished >= 2020





