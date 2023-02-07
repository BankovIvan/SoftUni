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
-- 3.	Deposit Money
--


CREATE OR ALTER PROC usp_DepositMoney
(
	@AccountId INT
	, @MoneyAmount DECIMAL(18,4)
	, @Status BIT = 0 OUT
)
AS
BEGIN

	IF(@MoneyAmount <= 0.0000) 
		RETURN

	UPDATE 
		Accounts 
	SET 
		Balance = Balance + @MoneyAmount
	WHERE 
		Id = @AccountId

	SET @Status = 1

END 


-- usp_DepositMoney 1, 10
/*
SELECT
	Id AS AccountId
	, AccountHolderId AS AccountHolderId
	, Balance AS Balance
FROM
	Accounts
*/




