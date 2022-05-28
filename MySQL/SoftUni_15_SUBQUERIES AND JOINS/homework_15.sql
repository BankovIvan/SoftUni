-- -----------------------------------------------------------------------------------------------
-- Lab: Subqueries and JOINs
-- -----------------------------------------------------------------------------------------------
-- DROP DATABASE `temp`;
-- CREATE DATABASE `temp`;
-- USE `temp`;
USE `soft_uni`;

-- -----------------------------------------------------------------------------------------------
-- 1.	Managers
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees`.`employee_id`,
    CONCAT(
		`employees`.`first_name`, 
        -- IF(`employees`.`middle_name` IS NULL, ' ', CONCAT(' ', `employees`.`middle_name`, ' ')), 
        ' ',
        `employees`.`last_name`)
        AS `full_name`,
	`departments`.`department_id`,
    `departments`.`name`
FROM
	`departments` INNER JOIN `employees` ON `departments`.`manager_id` = `employees`.`employee_id`
ORDER BY
	`departments`.`manager_id`
LIMIT 
	5;

-- -----------------------------------------------------------------------------------------------
-- 2.	Towns Adresses
-- -----------------------------------------------------------------------------------------------
SELECT
	`towns`.`town_id` AS `town_id`,
    `towns`.`name` AS `town_name`,
	`addresses`.`address_text` AS `address_text`
FROM
	`towns` INNER JOIN `addresses` ON `towns`.`town_id` = `addresses`.`town_id`
WHERE
	`towns`.`name` LIKE 'San Francisco' OR
    `towns`.`name` LIKE 'Sofia' OR
    `towns`.`name` LIKE 'Carnation'
ORDER BY
	`towns`.`town_id`, `addresses`.`address_id`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 3.	Employees Without Managers
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees`.`employee_id` AS `employee_id`,
    `employees`.`first_name` AS `first_name`,
	`employees`.`last_name` AS `last_name`,
    `employees`.`department_id` AS `department_id`,
    `employees`.`salary` AS `salary`
FROM
	`employees`
WHERE
	`employees`.`manager_id` IS NULL
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 4.	Higher Salary
-- -----------------------------------------------------------------------------------------------
SELECT
	count(*)
FROM
	`employees` AS `employees_t1`
WHERE
	`employees_t1`.`salary` > (SELECT AVG(`employees_t2`.`salary`) FROM `employees` AS `employees_t2`)
LIMIT
	1000;






