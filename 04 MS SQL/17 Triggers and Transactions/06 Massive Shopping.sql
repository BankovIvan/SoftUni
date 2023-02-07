------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exercises: Triggers and Transactions
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part II - Queries for Diablo Database
--
--USE Diablo;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 7.	*Massive Shopping
--
--
-- https://github.com/stefkavasileva/SoftUni-Software-Engineering/blob/master/DBFundamentals/Databases-Basics/08.Triggers%20and%20Transactions/Triggers%20and%20Transactions/07.%20Massive%20Shopping.sql
--
-- Note that Judge crashes on ROLLBACK command!
-- Thus it is not used.
--


DECLARE @UserGameId INT = 
	(
	SELECT 
		ug.Id 
	FROM
		Games AS g
		JOIN UsersGames AS ug
		ON g.Id = ug.GameId
		JOIN Users AS u
		ON ug.UserId = u.Id
	WHERE
		u.FirstName = 'Stamat'
		AND g.Name = 'Safflower'
	);

DECLARE @GameId INT = 
	(
	SELECT 
		ug.GameId 
	FROM
		UsersGames AS ug
	WHERE
		ug.Id = @UserGameId
	);

DECLARE @UserId INT = 
	(
	SELECT 
		ug.UserId 
	FROM
		UsersGames AS ug
	WHERE
		ug.Id = @UserGameId
	);

DECLARE @TotalCach MONEY = 
	(
	SELECT
		SUM(Price)
	FROM
		Items AS i
	WHERE
		i.MinLevel IN (11, 12)
		AND NOT EXISTS (SELECT * FROM UserGameItems WHERE ItemId = i.Id AND UserGameId = @UserGameId)
	);

--SELECT @UserGameId AS UserGameId, @GameId AS GameId, @UserId AS UserId

--BEGIN TRANSACTION t1

	--SELECT  @TotalCach1112 AS NewCash, (SELECT Cash FROM UsersGames WHERE Id = @UserGameId) AS OldCash

	IF(@TotalCach <= (SELECT Cash FROM UsersGames WHERE Id = @UserGameId))
	BEGIN
		BEGIN TRANSACTION t1
		--SELECT * FROM UserGameItems WHERE UserGameId = @UserGameId

		INSERT INTO
			UserGameItems
		SELECT
			Id,
			@UserGameId
		FROM
			Items AS i
		WHERE
			MinLevel IN (11, 12)
			AND NOT EXISTS (SELECT * FROM UserGameItems AS g WHERE g.ItemID = i.Id AND g.UserGameId = @GameId);
		
		--SELECT * FROM UserGameItems WHERE UserGameId = @UserGameId
		
		--SELECT Cash FROM UsersGames WHERE Id = @UserGameId

		UPDATE
			UsersGames
		SET
			Cash = Cash - @TotalCach
		WHERE
			Id = @UserGameId;
		
		--SELECT Cash FROM UsersGames WHERE Id = @UserGameId

		COMMIT TRAN t1;
		--ROLLBACK

	END;

	--ELSE
	--BEGIN
		--ROLLBACK TRAN t1

	--END


--BEGIN TRANSACTION t2

	SET @TotalCach = 
		(
		SELECT
			SUM(Price)
		FROM
			Items AS i
		WHERE
			i.MinLevel IN (19, 20, 21)
			AND NOT EXISTS (SELECT * FROM UserGameItems WHERE ItemId = i.Id AND UserGameId = @UserGameId)
		);


	IF(@TotalCach <= (SELECT Cash FROM UsersGames WHERE Id = @UserGameId))
	BEGIN
		
		BEGIN TRANSACTION t2
		INSERT INTO
			UserGameItems
		SELECT
			Id,
			@UserGameId
		FROM
			Items AS i
		WHERE
			MinLevel IN (19, 20, 21)
			AND NOT EXISTS (SELECT * FROM UserGameItems AS g WHERE g.ItemID = i.Id AND g.UserGameId = @GameId);

			
		UPDATE
			UsersGames
		SET
			Cash = Cash - @TotalCach
		WHERE
			Id = @UserGameId;

		COMMIT TRAN t2;

	END;

	--ELSE
	--BEGIN
		--ROLLBACK TRAN t2

	--END;


SELECT
	i.Name AS [Item Name]
FROM
	UserGameItems AS ui
	JOIN Items AS i
	ON ui.ItemId = i.Id
WHERE
	ui.UserGameId = @UserGameId
ORDER BY
	i.Name ASC;


