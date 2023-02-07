------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exercises: Triggers and Transactions
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part I - Queries for Bank Database
--
--USE Bank;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 1.	Create Table Logs
--


/*
CREATE TABLE Logs
(
	LogId INT NOT NULL IDENTITY(1, 1)
	, AccountId INT NOT NULL
	, OldSum DECIMAL(18,4)
	, NewSum DECIMAL (18, 4)
	, CONSTRAINT PK_Logs PRIMARY KEY (LogId)
);
*/


CREATE OR ALTER TRIGGER tr_LogAccountsBalance
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs
	(
		AccountId
		, OldSum
		, NewSum
	)

		SELECT 
			i.Id AS AccountId
			, d.Balance AS OldSum
			, i.Balance AS NewSum
		FROM 
			inserted as i
			JOIN deleted as d
			ON i.Id  = d.Id 
		WHERE
			i.Balance != d.Balance

GO






