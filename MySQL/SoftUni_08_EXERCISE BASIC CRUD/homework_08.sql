-- -----------------------------------------------------------------------------------------------
-- Exercises: Basic CRUD
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- Part I – Queries for SoftUni Database
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

-- -----------------------------------------------------------------------------------------------
-- 1.	Find All Information About Departments
-- -----------------------------------------------------------------------------------------------
SELECT * FROM `departments` ORDER BY `department_id` LIMIT 1000;

-- -----------------------------------------------------------------------------------------------
-- 2.	Find all Department Names
-- -----------------------------------------------------------------------------------------------
SELECT DISTINCT `name` FROM `departments` ORDER BY `department_id` LIMIT 1000;

-- -----------------------------------------------------------------------------------------------
-- 3.	Find salary of Each Employee
-- -----------------------------------------------------------------------------------------------
SELECT DISTINCT `first_name`, `last_name`, `salary` FROM `employees` ORDER BY `employee_id` LIMIT 1000;

-- -----------------------------------------------------------------------------------------------
-- 4.	Find Full Name of Each Employee
-- -----------------------------------------------------------------------------------------------
SELECT DISTINCT `first_name`, `middle_name`, `last_name` FROM `employees` ORDER BY `employee_id` LIMIT 1000;

-- -----------------------------------------------------------------------------------------------
-- 5.	Find Email Address of Each Employee
-- -----------------------------------------------------------------------------------------------
SELECT concat(`first_name`, '.', `last_name`, '@softuni.bg') AS `full_email_address` FROM `employees` LIMIT 1000;

-- -----------------------------------------------------------------------------------------------
-- 6.	Find All Different Employee’s Salaries
-- -----------------------------------------------------------------------------------------------
SELECT DISTINCT `salary` FROM `employees` ORDER BY `employee_id` LIMIT 1000;

-- -----------------------------------------------------------------------------------------------
-- 7.	Find all Information About Employees
-- -----------------------------------------------------------------------------------------------
SELECT * FROM `employees` WHERE `job_title` = 'Sales Representative' ORDER BY `employee_id` LIMIT 1000;

-- -----------------------------------------------------------------------------------------------
-- 8.	Find Names of All Employees by salary in Range
-- -----------------------------------------------------------------------------------------------
SELECT
    `first_name`, `last_name`, `job_title`
FROM
    `employees`
WHERE 
	`salary` BETWEEN 20000 AND 30000
ORDER BY 
	`employee_id`
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- 9.	Find Names of All Employees  
-- -----------------------------------------------------------------------------------------------
SELECT
    concat(`first_name`, ' ', LEFT(`middle_name`, 1), ' ', `last_name`) AS 'full_name'
FROM
    `employees`
WHERE 
	`salary` IN (25000, 14000, 12500, 23600)
ORDER BY 
	`employee_id`
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- 10.	Find All Employees Without Manager 
-- -----------------------------------------------------------------------------------------------
SELECT
    `first_name`, `last_name`
FROM
    `employees`
WHERE 
	`manager_id` IS NULL
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- 11.	Find All Employees with salary More Than 50000
-- -----------------------------------------------------------------------------------------------
SELECT
    `first_name`, `last_name`, `salary`
FROM
    `employees`
WHERE 
	`salary` > 50000.00
ORDER BY 
	`salary` DESC
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- 12.	Find 5 Best Paid Employees
-- -----------------------------------------------------------------------------------------------
SELECT
    `first_name`, `last_name`
FROM
    `employees`
ORDER BY 
	`salary` DESC
LIMIT 
	5;

-- -----------------------------------------------------------------------------------------------
-- 13.	Find All Employees Except Marketing
-- -----------------------------------------------------------------------------------------------
SELECT
    `employees`.`first_name`, `employees`.`last_name`
FROM
    `employees`
WHERE
	NOT `employees`.`department_id` = 4
LIMIT
	1000;

-- SELECT
--     `employees`.`first_name`, `employees`.`last_name`
-- FROM
--     `employees` INNER JOIN `departments`
-- WHERE
-- 	`employees`.`department_id` = `departments`.`department_id` AND NOT `departments`.`name` = 'Marketing'
-- LIMIT 
-- 	1000;

-- -----------------------------------------------------------------------------------------------
-- 14.	Sort Employees Table
-- -----------------------------------------------------------------------------------------------
SELECT
    *
FROM
    `employees`
ORDER BY 
	`salary` DESC, `first_name` ASC, `last_name` DESC, `middle_name` ASC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 15.	Create View Employees with Salaries
-- -----------------------------------------------------------------------------------------------
CREATE VIEW v_employees_salaries AS
SELECT
    `first_name`, `last_name`, `salary`
FROM
    `employees`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 16.	Create View Employees with Job Titles
-- -----------------------------------------------------------------------------------------------
CREATE VIEW v_employees_job_titles AS
SELECT
    concat(`first_name`, ' ', IFNULL(`middle_name`, ''), ' ', `last_name`) AS 'full_name', `job_title`
FROM
    `employees`
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- 17.	 Distinct Job Titles
-- -----------------------------------------------------------------------------------------------
SELECT DISTINCT
    `job_title`
FROM
    `employees`
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- 18.	Find First 10 Started Projects
-- -----------------------------------------------------------------------------------------------
SELECT
    *
FROM
    `projects`
ORDER BY
	`start_date`, `name`
LIMIT 
	10;

-- -----------------------------------------------------------------------------------------------
-- 19.	 Last 7 Hired Employees
-- -----------------------------------------------------------------------------------------------
SELECT
    `first_name`, `last_name`, `hire_date`
FROM
    `employees`
ORDER BY
	`hire_date` DESC
LIMIT 
	7;

-- -----------------------------------------------------------------------------------------------
-- 20.	Increase Salaries
-- -----------------------------------------------------------------------------------------------
/*
CREATE OR REPLACE VIEW `v_departmetnt_ids` AS
SELECT
	`department_id`
FROM
	`departments`
WHERE
	`name` = 'Engineering' OR `departments`.`name` = 'Tool Design' OR `departments`.`name` = 'Marketing' OR `departments`.`name` = 'Information Services'
LIMIT 
	1000;
-- SELECT * FROM `v_departmetnt_ids`;

UPDATE 
	`employees` 
SET 
    `salary` = `salary`*1.12
WHERE
	`department_id` IN 	(SELECT * FROM `v_departmetnt_ids`)
LIMIT 
	1000;

SELECT
    `salary`
FROM
    `employees`
LIMIT 
	1000;
*/

UPDATE 
	`employees` 
SET 
    `salary` = `salary`*1.12
WHERE
	`department_id` IN 	(1, 2, 4, 11)
LIMIT 
	1000;

SELECT
    `salary`
FROM
    `employees`
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- Part II – Queries for Geography Database
-- -----------------------------------------------------------------------------------------------
USE `geography`;

-- -----------------------------------------------------------------------------------------------
-- 21.	 All Mountain Peaks
-- -----------------------------------------------------------------------------------------------
SELECT
    `peak_name`
FROM
    `peaks`
ORDER BY
	`peak_name` ASC
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- 22.	 Biggest Countries by Population
-- -----------------------------------------------------------------------------------------------
SELECT
    `country_name`, `population`
FROM
    `countries`
WHERE
	`continent_code` = 'EU'
ORDER BY
	`population` DESC, `country_name` ASC
LIMIT 
	30;

-- -----------------------------------------------------------------------------------------------
-- 23.	 Countries and Currency (Euro / Not Euro)
-- -----------------------------------------------------------------------------------------------
SELECT
    `country_name`, `country_code`, IF(`currency_code` = 'EUR', 'Euro', 'Not Euro') AS `currency`
FROM
    `countries`
ORDER BY
	`country_name` ASC
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- Part III – Queries for Diablo Database
-- -----------------------------------------------------------------------------------------------
USE `diablo`;

-- -----------------------------------------------------------------------------------------------
-- 24.	 All Diablo Characters
-- -----------------------------------------------------------------------------------------------
SELECT
    `name`
FROM
    `characters`
ORDER BY
	`name` ASC
LIMIT 
	1000;
