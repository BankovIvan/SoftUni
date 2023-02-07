------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exam Preparation
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 3. Querying (40 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 9.	Volunteers in Sofia
--


--USE Zoo;


SELECT
	v.[Name] AS [Name]
	, v.PhoneNumber AS [PhoneNumber]
	, TRIM(SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + 1, 100)) AS [Address]
FROM
	Volunteers AS v
	JOIN VolunteersDepartments AS vd
	ON vd.Id = v.DepartmentId
WHERE
	vd.DepartmentName = 'Education program assistant' 
	AND v.[Address] LIKE '%Sofia%,%'
ORDER BY
	v.[Name] ASC













