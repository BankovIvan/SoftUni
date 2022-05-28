-- -----------------------------------------------------------------------------------------------
-- Exercises: Built-in Functions
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- Part I – Queries for SoftUni Database
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

-- -----------------------------------------------------------------------------------------------
-- 1.	Find Names of All Employees by First Name
-- -----------------------------------------------------------------------------------------------
SELECT 
	`first_name`, `last_name`
FROM
	`employees`
WHERE
	`first_name` LIKE 'sa%'
ORDER BY
	`employee_id`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 2.	Find Names of All employees by Last Name 
-- -----------------------------------------------------------------------------------------------
SELECT 
	`first_name`, `last_name`
FROM
	`employees`
WHERE
	`last_name` LIKE '%ei%'
ORDER BY
	`employee_id`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 3.	Find First Names of All Employees
-- -----------------------------------------------------------------------------------------------
SELECT 
	`first_name`
FROM
	`employees`
WHERE
	`department_id` IN (3, 10) AND 
--    DATE(`hire_date`) BETWEEN DATE('1995-1-1') AND DATE('2005-12-31')
	YEAR(`hire_date`) BETWEEN 1995 AND 2005
ORDER BY
	`employee_id`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 4.	Find All Employees Except Engineers
-- -----------------------------------------------------------------------------------------------
SELECT 
	`first_name`, `last_name`
FROM
	`employees`
WHERE
	`job_title` NOT LIKE '%engineer%'
ORDER BY
	`employee_id`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 5.	Find Towns with Name Length
-- -----------------------------------------------------------------------------------------------
SELECT 
	`name`
FROM
	`towns`
WHERE
	CHAR_LENGTH(`name`) BETWEEN 5 AND 6
ORDER BY
	`name`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 6.	 Find Towns Starting With
-- -----------------------------------------------------------------------------------------------
SELECT 
	`town_id`, `name`
FROM
	`towns`
WHERE
	LEFT(`name`, 1) IN ('M', 'K', 'B', 'E')
ORDER BY
	`name`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 7.	 Find Towns Not Starting With
-- -----------------------------------------------------------------------------------------------
SELECT 
	`town_id`, `name`
FROM
	`towns`
WHERE
	NOT LEFT(`name`, 1) IN ('R', 'B', 'D')
ORDER BY
	`name`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 8.	Create View Employees Hired After 2000 Year
-- -----------------------------------------------------------------------------------------------
CREATE OR REPLACE VIEW v_employees_hired_after_2000 AS
SELECT 
	`first_name`, `last_name`
FROM
	`employees`
WHERE
	YEAR(`hire_date`) > 2000
-- ORDER BY
-- 	`name`
LIMIT
	1000;

SELECT * FROM soft_uni.v_employees_hired_after_2000;

-- -----------------------------------------------------------------------------------------------
-- 9.	Length of Last Name
-- -----------------------------------------------------------------------------------------------
SELECT 
	`first_name`, `last_name`
FROM
	`employees`
WHERE
	CHAR_LENGTH(`last_name`) = 5
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- Part II – Queries for Geography Database 
-- -----------------------------------------------------------------------------------------------
USE `geography`;

-- -----------------------------------------------------------------------------------------------
-- 10.	Countries Holding ‘A’ 3 or More Times
-- -----------------------------------------------------------------------------------------------
SELECT 
	`country_name`, `iso_code`
FROM
	`countries`
WHERE
	`country_name` LIKE '%a%a%a%'
ORDER BY
	`iso_code`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 11.	 Mix of Peak and River Names
-- -----------------------------------------------------------------------------------------------
SELECT 
    `peaks`.`peak_name`,
    `rivers`.`river_name`,
    LOWER(
		CONCAT(
			`peaks`.`peak_name`,
			SUBSTRING(`rivers`.`river_name`, 2)
		)
	)
    AS `mix`
FROM
    `peaks` INNER JOIN `rivers`
WHERE
    RIGHT(`peaks`.`peak_name`, 1) = LEFT(`rivers`.`river_name`, 1)
ORDER BY `mix`
LIMIT 1000;

-- -----------------------------------------------------------------------------------------------
-- Part III – Queries for Diablo Database
-- -----------------------------------------------------------------------------------------------
USE `diablo`;

-- -----------------------------------------------------------------------------------------------
-- 12.	Games from 2011 and 2012 year
-- -----------------------------------------------------------------------------------------------
SELECT 
    `name`, DATE_FORMAT(`start`, '%Y-%m-%d') AS 'start'
FROM
    `games`
WHERE
    YEAR(`start`) IN(2011, 2012)
ORDER BY 
	`start`, `name`
LIMIT 
	50;

-- -----------------------------------------------------------------------------------------------
-- 13.	 User Email Providers
-- -----------------------------------------------------------------------------------------------
SELECT 
    `user_name`, SUBSTR(`email`, INSTR(`email`, '@') + 1) AS `Email Provider`
FROM
    `users`
ORDER BY 
	`Email Provider`, `user_name`
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- 14.	 Get Users with IP Address Like Pattern
-- -----------------------------------------------------------------------------------------------
SELECT 
    `user_name`, `ip_address`
FROM
    `users`
WHERE
	`ip_address` LIKE '___.1%.%.___'
ORDER BY 
	`user_name`
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- 15.	 Show All Games with Duration and Part of the Day
-- -----------------------------------------------------------------------------------------------
SELECT 
    `name` AS `game`,
    CASE  
		WHEN HOUR(`start`) < 12 THEN 'Morning'
        WHEN HOUR(`start`) >= 12 AND HOUR(`start`) < 18 THEN 'Afternoon'
        WHEN HOUR(`start`) >= 18 THEN 'Evening'
	END
		AS `Part of the Day`, 
    CASE  
		WHEN `duration` <= 3 THEN 'Extra Short'
        WHEN `duration` > 3 AND `duration` <= 6 THEN 'Short'
        WHEN `duration` > 6 AND `duration` <= 10 THEN 'Long'
        ELSE 'Extra Long'
	END
		AS `Duration`
FROM
    `games`
LIMIT 
	1000;

-- -----------------------------------------------------------------------------------------------
-- Part IV – Date Functions Queries
-- -----------------------------------------------------------------------------------------------
-- NO DB!!!!!

-- -----------------------------------------------------------------------------------------------
-- 16.	 Orders Table
-- -----------------------------------------------------------------------------------------------
SELECT 
    `product_name`,
    `order_date`,
    DATE_ADD(`order_date`,INTERVAL 3 DAY) AS `pay_due`,
    DATE_ADD(`order_date`,INTERVAL 1 MONTH) AS `deliver_due`
FROM
    `orders`
LIMIT 
	1000;




