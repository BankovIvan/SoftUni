-- -----------------------------------------------------------------------------------------------
-- Exercises: Subqueries and JOINs
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

-- -----------------------------------------------------------------------------------------------
-- 1.	Employee Address
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`employee_id` AS `employee_id`,
    `employees_t1`.`job_title` AS `job_title`,
    `employees_t1`.`address_id` AS `address_id`,
    `addresses_t1`.`address_text` AS `address_text`
FROM
	`employees` AS `employees_t1` INNER JOIN `addresses` AS `addresses_t1` 
		ON `employees_t1`.`address_id` = `addresses_t1`.`address_id`
ORDER BY
	`employees_t1`.`address_id` ASC
LIMIT
	5;

-- -----------------------------------------------------------------------------------------------
-- 2.	Addresses with Towns
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`first_name` AS `first_name`,
    `employees_t1`.`last_name` AS `last_name`,
    `towns_t1`.`name` AS `town`,
    `addresses_t1`.`address_text` AS `address_text`
FROM
	(`employees` AS `employees_t1` INNER JOIN `addresses` AS `addresses_t1` 
		ON `employees_t1`.`address_id` = `addresses_t1`.`address_id`)
        INNER JOIN `towns` AS `towns_t1` 
        ON `addresses_t1`.`town_id` = `towns_t1`.`town_id`
ORDER BY
	`employees_t1`.`first_name` ASC, `employees_t1`.`last_name`
LIMIT
	5;

-- -----------------------------------------------------------------------------------------------
-- 3.	Sales Employee
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`employee_id` AS `employee_id`,
	`employees_t1`.`first_name` AS `first_name`,
    `employees_t1`.`last_name` AS `last_name`,
    `departments_t1`.`name` AS `department_name`
FROM
	`employees` AS `employees_t1` INNER JOIN `departments` AS `departments_t1` 
		ON `employees_t1`.`department_id` = `departments_t1`.`department_id`
WHERE
	`departments_t1`.`name` LIKE 'Sales'
ORDER BY
	`employees_t1`.`employee_id` DESC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 4.	Employee Departments
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`employee_id` AS `employee_id`,
	`employees_t1`.`first_name` AS `first_name`,
    `employees_t1`.`salary` AS `salary`,
    `departments_t1`.`name` AS `department_name`
FROM
	`employees` AS `employees_t1` INNER JOIN `departments` AS `departments_t1` 
		ON `employees_t1`.`department_id` = `departments_t1`.`department_id`
WHERE
	`employees_t1`.`salary` > 15000
ORDER BY
	`departments_t1`.`department_id` DESC
LIMIT
	5;

-- -----------------------------------------------------------------------------------------------
-- 5.	Employees Without Project
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`employee_id` AS `employee_id`,
	`employees_t1`.`first_name` AS `first_name`
FROM
	`employees` AS `employees_t1` LEFT JOIN `employees_projects` AS `employees_projects_t1` 
		ON `employees_t1`.`employee_id` = `employees_projects_t1`.`employee_id`
WHERE
	`employees_projects_t1`.`project_id` IS NULL
ORDER BY
	`employees_t1`.`employee_id` DESC
LIMIT
	3;

-- -----------------------------------------------------------------------------------------------
-- 6.	Employees Hired After
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`first_name` AS `first_name`,
    `employees_t1`.`last_name` AS `last_name`,
    `employees_t1`.`hire_date` AS `hire_date`,
    `departments_t1`.`name` AS `dept_name`
FROM
	`employees` AS `employees_t1` INNER JOIN `departments` AS `departments_t1` 
		ON `employees_t1`.`department_id` = `departments_t1`.`department_id`
WHERE
	`employees_t1`.`hire_date` >= '1999-1-2' AND
    (`departments_t1`.`name` LIKE 'Sales' OR
    `departments_t1`.`name` LIKE 'Finance')
ORDER BY
	`employees_t1`.`hire_date` ASC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 7.	Employees with Project
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`employee_id` AS `employee_id`,
	`employees_t1`.`first_name` AS `first_name`,
    `projects_t1`.`name` AS `project_name`
FROM
	(
    `employees` AS `employees_t1` INNER JOIN `employees_projects` AS `employees_projects_t1` 
		ON `employees_t1`.`employee_id` = `employees_projects_t1`.`employee_id`
	)
	INNER JOIN `projects` AS `projects_t1`
		ON `employees_projects_t1`.`project_id` = `projects_t1`.`project_id`
WHERE
	`projects_t1`.`start_date` >= '2002-08-14' 
    AND `projects_t1`.`end_date` IS NULL
ORDER BY
	`employees_t1`.`first_name` ASC, `projects_t1`.`name` ASC
LIMIT
	5;

-- -----------------------------------------------------------------------------------------------
-- 8.	Employee 24
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`employee_id` AS `employee_id`,
	`employees_t1`.`first_name` AS `first_name`,
    IF(`projects_t1`.`start_date` >= '2005-01-01', NULL, `projects_t1`.`name`) AS `project_name`
FROM
	(
    `employees` AS `employees_t1` INNER JOIN `employees_projects` AS `employees_projects_t1` 
		ON `employees_t1`.`employee_id` = `employees_projects_t1`.`employee_id`
	)
	INNER JOIN `projects` AS `projects_t1`
		ON `employees_projects_t1`.`project_id` = `projects_t1`.`project_id`
WHERE
	`employees_t1`.`employee_id` = 24
ORDER BY
	`project_name` ASC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 9.	Employee Manager
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`employee_id` AS `employee_id`,
	`employees_t1`.`first_name` AS `first_name`,
    `employees_t2`.`employee_id` AS `manager_id`,
    `employees_t2`.`first_name` AS `manager_name`
FROM
	`employees` AS `employees_t1` LEFT JOIN `employees` AS `employees_t2` 
		ON `employees_t1`.`manager_id` = `employees_t2`.`employee_id`
WHERE
	`employees_t1`.`manager_id` IN (3, 7)
ORDER BY
	`employees_t1`.`first_name` ASC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 10.	Employee Summary
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1a`.`employee_id` AS `employee_id`,
	CONCAT(`employees_t1a`.`first_name`, ' ', `employees_t1a`.`last_name`) AS `employee_name`,
    CONCAT(`employees_t1b`.`first_name`, ' ', `employees_t1b`.`last_name`) AS `manager_name`,
	`departments_t1`.`name` AS `department_name`
FROM
	(`employees` AS `employees_t1a` LEFT JOIN `employees` AS `employees_t1b` 
		ON `employees_t1a`.`manager_id` = `employees_t1b`.`employee_id`)
	LEFT JOIN `departments` AS `departments_t1`
		ON `employees_t1a`.`department_id` = `departments_t1`.`department_id`
WHERE
	`employees_t1a`.`manager_id` IS NOT NULL
ORDER BY
	`employees_t1a`.`employee_id` ASC
LIMIT
	5;

-- -----------------------------------------------------------------------------------------------
-- 11.	Min Average Salary
-- -----------------------------------------------------------------------------------------------
SELECT
	MIN(`average_salary_t2`.`average_salary`) AS `min_average_salary`
FROM
	(
    SELECT
		AVG(`employees_t1`.`salary`) AS `average_salary`
	FROM
		`employees` AS `employees_t1` LEFT JOIN `departments` AS `departments_t1`
			ON `employees_t1`.`department_id` = `departments_t1`.`department_id`
	GROUP BY
		`employees_t1`.`department_id`
	ORDER BY
		`employees_t1`.`department_id` ASC
	LIMIT
		1000
	) AS `average_salary_t2`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 12.	Highest Peaks in Bulgaria
-- -----------------------------------------------------------------------------------------------
USE `geography`;

SELECT
	`mountains_countries_t1`.`country_code` AS `country_code`,
    `mountains_t1`.`mountain_range` AS `mountain_range`,
    `peaks_t1`.`peak_name` AS `peak_name`,
    `peaks_t1`.`elevation` AS `elevation`
FROM
	`mountains_countries` AS `mountains_countries_t1` 
	INNER JOIN `mountains` AS `mountains_t1`
		ON `mountains_countries_t1`.`mountain_id` = `mountains_t1`.`id`        
	INNER JOIN `peaks` AS `peaks_t1`
		ON `mountains_countries_t1`.`mountain_id` = `peaks_t1`.`mountain_id`
WHERE
	`mountains_countries_t1`.`country_code` LIKE 'BG'
    AND `peaks_t1`.`elevation` > 2835
ORDER BY
	`peaks_t1`.`elevation` DESC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 13.	Count Mountain Ranges
-- -----------------------------------------------------------------------------------------------
SELECT
	`mountains_countries_t1`.`country_code` AS `country_code`,
    COUNT(*) AS `mountain_range`
FROM
	`mountains_countries` AS `mountains_countries_t1` 
	INNER JOIN `mountains` AS `mountains_t1`
		ON `mountains_countries_t1`.`mountain_id` = `mountains_t1`.`id`        
WHERE
	`mountains_countries_t1`.`country_code` IN ('BG', 'RU', 'US')
GROUP BY
	`mountains_countries_t1`.`country_code`
ORDER BY
	`mountain_range` DESC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 14.	Countries with Rivers
-- -----------------------------------------------------------------------------------------------
SELECT
	`countries_t1`.`country_name` AS `country_name`,
    `rivers_t1`.`river_name` AS `river_name`
FROM
	`countries` AS `countries_t1` 
	LEFT JOIN `countries_rivers` AS `countries_rivers_t1`
		ON `countries_t1`.`country_code` = `countries_rivers_t1`.`country_code`
	LEFT JOIN `rivers` AS `rivers_t1`
		ON `countries_rivers_t1`.`river_id` = `rivers_t1`.`id`
WHERE
	`countries_t1`.`continent_code` LIKE 'AF'
ORDER BY
	`countries_t1`.`country_name` ASC
LIMIT
	5;

-- -----------------------------------------------------------------------------------------------
-- 15.	*Continents and Currencies
-- -----------------------------------------------------------------------------------------------
/*
-- Not working - only one MAX value is returned...
SELECT
	`continents_currencies_t2`.`continent_code` AS `continent_code`,
	`continents_currencies_t2`.`currency_code` AS `currency_code`,
    MAX(`continents_currencies_t2`.`currency_usage`) AS `currency_usage`
FROM
	(SELECT
		`continents_t1`.`continent_code` AS `continent_code`,
		`countries_t1`.`currency_code` AS `currency_code`,
		COUNT(`countries_t1`.`currency_code`) AS `currency_usage`
	FROM
		`continents` AS `continents_t1` 
		INNER JOIN `countries` AS `countries_t1`
			ON `continents_t1`.`continent_code` = `countries_t1`.`continent_code`
	GROUP BY
		`continents_t1`.`continent_code`, `countries_t1`.`currency_code`
	HAVING
		`currency_usage` > 1
	ORDER BY
		`continents_t1`.`continent_code`, `countries_t1`.`country_code`
	LIMIT
		1000)
	AS `continents_currencies_t2`
GROUP BY
	`continents_currencies_t2`.`continent_code`
LIMIT
	1000;
*/

SELECT
	`continents_currencies_t3a`.`continent_code` AS `continent_code`,
	`continents_currencies_t3a`.`currency_code` AS `currency_code`,
    `continents_currencies_t3a`.`currency_usage` AS `currency_usage`
FROM
	(
    SELECT
		`continents_t1`.`continent_code` AS `continent_code`,
		`countries_t1`.`currency_code` AS `currency_code`,
		COUNT(`countries_t1`.`currency_code`) AS `currency_usage`
	FROM
		`continents` AS `continents_t1` 
		INNER JOIN `countries` AS `countries_t1`
			ON `continents_t1`.`continent_code` = `countries_t1`.`continent_code`
	GROUP BY
		`continents_t1`.`continent_code`, `countries_t1`.`currency_code`
	HAVING
		`currency_usage` > 1
	ORDER BY
		`continents_t1`.`continent_code`, `countries_t1`.`country_code`
	LIMIT
		1000
	) AS `continents_currencies_t3a`
    
    INNER JOIN

	(
    SELECT
		`continents_currencies_t2`.`continent_code` AS `continent_code`,
		`continents_currencies_t2`.`currency_code` AS `currency_code`,
		MAX(`continents_currencies_t2`.`currency_usage`) AS `currency_usage`
	FROM
		(SELECT
			`continents_t1`.`continent_code` AS `continent_code`,
			`countries_t1`.`currency_code` AS `currency_code`,
			COUNT(`countries_t1`.`currency_code`) AS `currency_usage`
		FROM
			`continents` AS `continents_t1` 
			INNER JOIN `countries` AS `countries_t1`
				ON `continents_t1`.`continent_code` = `countries_t1`.`continent_code`
		GROUP BY
			`continents_t1`.`continent_code`, `countries_t1`.`currency_code`
		HAVING
			`currency_usage` > 1
		ORDER BY
			`continents_t1`.`continent_code`, `countries_t1`.`country_code`
		LIMIT
			1000)
		AS `continents_currencies_t2`
	GROUP BY
		`continents_currencies_t2`.`continent_code`
	LIMIT
		1000
	) AS `continents_currencies_t3b`
    
    ON `continents_currencies_t3a`.`continent_code` = `continents_currencies_t3b`.`continent_code` 
		AND `continents_currencies_t3a`.`currency_usage` = `continents_currencies_t3b`.`currency_usage`
    
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 16.	Countries without any Mountains
-- -----------------------------------------------------------------------------------------------
SELECT
	COUNT(*) AS `country_count`
FROM
	`countries` AS `countries_t1` 
	LEFT JOIN `mountains_countries` AS `mountains_countries_t1`
		ON `countries_t1`.`country_code` = `mountains_countries_t1`.`country_code`
WHERE
	`mountains_countries_t1`.`country_code` IS NULL
LIMIT
	5;

-- -----------------------------------------------------------------------------------------------
-- 17.	Highest Peak and Longest River by Country
-- -----------------------------------------------------------------------------------------------


SELECT
	`peaks_t2`.`country_name` AS `country_name`,
    `peaks_t2`.`highest_peak_elevation` AS `highest_peak_elevation`,
    `rivers_t2`.`longest_river_length` AS `longest_river_length`
FROM

	(
	SELECT
		`countries_t1`.`country_code`,
		`countries_t1`.`country_name` AS `country_name`,
		MAX(`peaks_t1`.`elevation`) AS `highest_peak_elevation`
	FROM
		`countries` AS `countries_t1`
		
		INNER JOIN `mountains_countries` AS `mountains_countries_t1`
			ON `countries_t1`.`country_code` = `mountains_countries_t1`.`country_code`
			
		INNER JOIN `peaks` AS `peaks_t1`
			ON `peaks_t1`.`mountain_id` = `mountains_countries_t1`.`mountain_id`
			
	GROUP BY
		`countries_t1`.`country_code`
	LIMIT
		1000
	) AS `peaks_t2`
		
		
		
	INNER JOIN


	(
	SELECT
		`countries_t1`.`country_code`,
		`countries_t1`.`country_name` AS `country_name`,
		MAX(`rivers_t1`.`length`) AS `longest_river_length`
	FROM
		`countries` AS `countries_t1`
		
		INNER JOIN `countries_rivers` AS `countries_rivers_t1`
			ON `countries_t1`.`country_code` = `countries_rivers_t1`.`country_code`
			
		INNER JOIN `rivers` AS `rivers_t1`
			ON `rivers_t1`.`id` = `countries_rivers_t1`.`river_id`
			
	GROUP BY
		`countries_t1`.`country_code`
	LIMIT
		1000
	) AS `rivers_t2`


	ON `peaks_t2`.`country_code` = `rivers_t2`.`country_code`

ORDER BY
	`peaks_t2`.`highest_peak_elevation` DESC,
    `rivers_t2`.`longest_river_length` DESC,
    `peaks_t2`.`country_name` ASC
LIMIT
	5;
	












