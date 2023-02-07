------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 4. Programmability (20 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 11.	All Volunteers in a Department
--


--USE Zoo;


CREATE FUNCTION udf_GetVolunteersCountFromADepartment 
(
	@VolunteersDepartment VARCHAR(30)
)
RETURNS
	INT
BEGIN
	DECLARE @Ret INT = 0;

	SET @Ret = 
	(
	SELECT
		COUNT(*)
	FROM
		VolunteersDepartments AS d
		JOIN Volunteers AS v
		ON d.Id = v.DepartmentId
	WHERE
		d.DepartmentName = @VolunteersDepartment
		--d.DepartmentName = 'Education program assistant'
	);

	RETURN @Ret;
END;
	
-- SELECT dbo.udf_GetVolunteersCountFromADepartment('Education program assistant')











