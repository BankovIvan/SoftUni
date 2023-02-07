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
-- 4.	Withdraw Money Procedure
--


CREATE OR ALTER PROCEDURE usp_WithdrawMoney
(
	@AccountId INT
	, @MoneyAmount DECIMAL(18,4)
	, @Status BIT = 0 OUT  -- 0 = Incorrect Data, 1 = Status OK
)
AS
BEGIN
	DECLARE @NewAmount DECIMAL(18,4) = 
		(
		SELECT
			(Balance - @MoneyAmount)
		FROM	
			Accounts 
		WHERE 
			Id = @AccountId
		)
	
	IF @NewAmount < 0.0000
		RETURN

	UPDATE 
		Accounts 
	SET 
		Balance = @NewAmount
	WHERE 
		Id = @AccountId

	SET @Status = 1

END

/*
DECLARE @Result BIT = 0
EXECUTE usp_WithdrawMoney 5, 25, @Result OUT
SELECT @Result
*/

-- usp_WithdrawMoney 5, 25
-- usp_WithdrawMoney 1, 143.1201
-- usp_WithdrawMoney 1, 143.1200
/*
SELECT
	Id AS AccountId
	, AccountHolderId AS AccountHolderId
	, Balance AS Balance
FROM
	Accounts
*/




