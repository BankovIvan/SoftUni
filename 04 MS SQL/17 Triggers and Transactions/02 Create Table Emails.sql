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
-- 2.	Create Table Emails
--


/*
CREATE TABLE NotificationEmails
(
	NotificationId INT NOT NULL IDENTITY(1, 1)
	, Recipient INT NOT NULL
	, Subject NVARCHAR(250)
	, Body NVARCHAR(MAX)
	, CONSTRAINT PK_NotificationEmails PRIMARY KEY (NotificationId)
);
*/


CREATE OR ALTER TRIGGER tr_LogNotificationEmails
ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails
	(
		Recipient
		, [Subject]
		, Body
	)


		SELECT
			AccountId
			, CONCAT('Balance change for account: ', AccountId)
			, CONCAT('On ', FORMAT(SYSDATETIME(), 'MMM dd yyyy h:mmtt'), ' your balance was changed from ', FORMAT(OldSum, '#.##'), ' to ', FORMAT(NewSum, '#.##'), '.')
		FROM 
			inserted
			--Logs
		--ORDER BY
			--LogId DESC








