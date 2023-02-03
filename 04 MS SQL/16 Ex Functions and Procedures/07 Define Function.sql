-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 16. Exercises: Functions and Stored Procedures
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part I – Queries for SoftUni Database
--
--USE SoftUni;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 7.	Define Function
--
CREATE OR ALTER FUNCTION ufn_IsWordComprised
(
	@setOfLetters NVARCHAR(250)
	, @word NVARCHAR(250)
)
RETURNS
	BIT
AS
BEGIN
	DECLARE @LetterIndex INT = 1;

	IF @setOfLetters IS NULL
		RETURN 0

	IF @word IS NULL
		RETURN 0

	WHILE @LetterIndex <= LEN(@word)
	BEGIN
		IF @setOfLetters NOT LIKE CONCAT('%', SUBSTRING(@word, @LetterIndex, 1), '%')
			RETURN 0;

		SET @LetterIndex = @LetterIndex + 1
	END

	RETURN 1
END;

-- SELECT dbo.ufn_IsWordComprised('A', 'a')