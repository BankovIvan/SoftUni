------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exercises: Additional Exercises
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- PART II – Queries for Geography Database
--
--USE Geography;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 13.	Monasteries by Country
--


CREATE TABLE Monasteries
(
	Id INT NOT NULL IDENTITY(1, 1)
	, [Name] NVARCHAR(150) NOT NULL
	, CountryCode CHAR(2)
	, CONSTRAINT PK_Monasteries PRIMARY KEY (Id)
	, CONSTRAINT FK_Monasteries_Countries FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
)


INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')


/*
ALTER TABLE Countries
ADD
	IsDeleted BIT NOT NULL DEFAULT 0
*/


UPDATE c1
SET
	c1.IsDeleted = 1
FROM
	Countries AS c1
	JOIN (


SELECT
	c.CountryCode AS [CountryCode]
	, COUNT(cr.RiverId) AS [RiversCount]
FROM
	Countries AS c
	JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
GROUP BY
	c.CountryCode
	, c.CountryName
HAVING
	COUNT(cr.RiverId) > 3


			) AS c2
	
	
	ON c1.CountryCode = c2.CountryCode




SELECT
	m.[Name] AS [Monastery]
	, c.CountryName AS [Country]
FROM
	Monasteries AS m
	JOIN Countries AS c
	ON m.CountryCode = c.CountryCode
WHERE
	c.IsDeleted = 0
ORDER BY
	m.[Name]









