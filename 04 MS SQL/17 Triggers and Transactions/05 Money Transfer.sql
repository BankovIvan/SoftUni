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
-- 5.	Money Transfer
--


/*
CREATE OR ALTER PROCEDURE usp_TransferMoney
(
	@SenderId INT
	, @ReceiverId INT
	, @MoneyAmount DECIMAL(18,4)
)
AS
BEGIN TRANSACTION
	
	DECLARE @Result BIT = 0;
	
	EXECUTE usp_WithdrawMoney @SenderId, @MoneyAmount, @Result OUT 

	IF @Result = 0
	BEGIN
		ROLLBACK
		RETURN
	END

	EXECUTE usp_DepositMoney  @ReceiverId, @MoneyAmount, @Result OUT;

	IF @Result = 0
	BEGIN
		ROLLBACK
		RETURN
	END

COMMIT
*/



CREATE OR ALTER PROCEDURE usp_TransferMoney
(
	@SenderId INT
	, @ReceiverId INT
	, @MoneyAmount DECIMAL(18,4)
)
AS
BEGIN TRANSACTION

	DECLARE @OldAmount DECIMAL(18,4) = 0;
	
	SET @OldAmount = (SELECT Balance FROM Accounts WHERE Id = @SenderId)
	EXECUTE usp_WithdrawMoney @SenderId, @MoneyAmount

	IF @OldAmount = (SELECT Balance FROM Accounts WHERE Id = @SenderId)
	BEGIN
		ROLLBACK
		RETURN
	END

	SET @OldAmount = (SELECT Balance FROM Accounts WHERE Id = @ReceiverId)
	EXECUTE usp_DepositMoney  @ReceiverId, @MoneyAmount

	IF @OldAmount = (SELECT Balance FROM Accounts WHERE Id = @ReceiverId)
	BEGIN
		ROLLBACK
		RETURN
	END

COMMIT


-- usp_TransferMoney 5, 1, 5000
/*
SELECT
	Id AS AccountId
	, AccountHolderId AS AccountHolderId
	, Balance AS Balance
FROM
	Accounts
*/




