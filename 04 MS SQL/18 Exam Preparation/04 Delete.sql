------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 2. DML (10 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 4.	Delete
--


--USE Zoo;


DECLARE @DeptId INT = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant')
 

ALTER TABLE 
	Volunteers
ALTER COLUMN
	DepartmentId INT NULL

UPDATE Volunteers
SET
	DepartmentId = NULL
WHERE
	DepartmentId = @DeptId


DELETE FROM
	VolunteersDepartments
WHERE
	Id = @DeptId

















