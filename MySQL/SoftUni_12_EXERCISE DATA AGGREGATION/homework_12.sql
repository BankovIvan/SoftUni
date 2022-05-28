-- -----------------------------------------------------------------------------------------------
-- Exercises: Data Aggregation
-- -----------------------------------------------------------------------------------------------
USE `gringotts`;

-- -----------------------------------------------------------------------------------------------
-- 1. Records’ Count
-- -----------------------------------------------------------------------------------------------
SELECT 
	COUNT(*) AS `count`
FROM
	`wizzard_deposits`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 2.	 Longest Magic Wand
-- -----------------------------------------------------------------------------------------------
SELECT 
	MAX(`magic_wand_size`) AS `longest_magic_wand`
FROM
	`wizzard_deposits`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 3. Longest Magic Wand per Deposit Groups
-- -----------------------------------------------------------------------------------------------
SELECT 
	`deposit_group`,
	MAX(`magic_wand_size`) AS `longest_magic_wand`
FROM
	`wizzard_deposits`
GROUP BY
	`deposit_group`
ORDER BY
	`longest_magic_wand`, `deposit_group`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 4.	 Smallest Deposit Group per Magic Wand Size*
-- -----------------------------------------------------------------------------------------------
SELECT 
	`deposit_group`
FROM
	(
	SELECT 
		`deposit_group`,
		AVG(`magic_wand_size`) AS `avg_magic_wand`
	FROM
		`wizzard_deposits`
	GROUP BY
		`deposit_group`
	ORDER BY
		`avg_magic_wand`, `deposit_group`
	LIMIT
		1000
    ) AS `tmp_table`
LIMIT 
	1;

-- -----------------------------------------------------------------------------------------------
-- 5.	 Deposits Sum
-- -----------------------------------------------------------------------------------------------
SELECT 
	`deposit_group`,
	SUM(`deposit_amount`) AS `total_sum`
FROM
	`wizzard_deposits`
GROUP BY
	`deposit_group`
ORDER BY
	`total_sum`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 6.	 Deposits Sum for Ollivander family
-- -----------------------------------------------------------------------------------------------
SELECT 
	`deposit_group`,
	SUM(`deposit_amount`) AS `total_sum`
FROM
	`wizzard_deposits`
WHERE
	`magic_wand_creator` LIKE 'Ollivander family'
GROUP BY
	`deposit_group`
ORDER BY
	`deposit_group`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 7.	Deposits Filter
-- -----------------------------------------------------------------------------------------------
SELECT 
	`deposit_group`,
	SUM(`deposit_amount`) AS `total_sum`
FROM
	`wizzard_deposits`
WHERE
	`magic_wand_creator` LIKE 'Ollivander family'
GROUP BY
	`deposit_group`
HAVING
	`total_sum` < 150000
ORDER BY
	`total_sum` DESC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 8.	 Deposit charge
-- -----------------------------------------------------------------------------------------------
SELECT 
	`deposit_group`,
    `magic_wand_creator`,
	MIN(`deposit_charge`) AS `min_deposit_charge`
FROM
	`wizzard_deposits`
GROUP BY
	`deposit_group`, `magic_wand_creator`
ORDER BY
	`magic_wand_creator`, `deposit_group`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 9. Age Groups
-- -----------------------------------------------------------------------------------------------
/*
SELECT 
	'[0-10]' AS `age_group`,
    COUNT(*) AS `wizard_count`
FROM
	`wizzard_deposits`
WHERE
	`age` BETWEEN 0 AND 10
HAVING
	`wizard_count` > 0
    
	UNION SELECT 
		'[11-20]',
		COUNT(*)
	FROM
		`wizzard_deposits`
	WHERE
		`age` BETWEEN 11 AND 20
        
	UNION SELECT 
		'[21-30]',
		COUNT(*)
	FROM
		`wizzard_deposits`
	WHERE
		`age` BETWEEN 21 AND 30

	UNION SELECT 
		'[31-40]',
		COUNT(*)
	FROM
		`wizzard_deposits`
	WHERE
		`age` BETWEEN 31 AND 40

	UNION SELECT 
		'[41-50]',
		COUNT(*)
	FROM
		`wizzard_deposits`
	WHERE
		`age` BETWEEN 41 AND 50

	UNION SELECT 
		'[51-60]',
		COUNT(*)
	FROM
		`wizzard_deposits`
	WHERE
		`age` BETWEEN 51 AND 60

	UNION SELECT 
		'[61+]',
		COUNT(*)
	FROM
		`wizzard_deposits`
	WHERE
		`age` >= 61

ORDER BY
	`wizard_count`
LIMIT
	1000;
*/

SELECT 
	CASE 
		WHEN `age` BETWEEN 0 AND 10 THEN '[0-10]'
        WHEN `age` BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN `age` BETWEEN 21 AND 30 THEN '[21-30]'
        WHEN `age` BETWEEN 31 AND 40 THEN '[31-40]'
        WHEN `age` BETWEEN 41 AND 50 THEN '[41-50]'
        WHEN `age` BETWEEN 51 AND 60 THEN '[51-60]'
        WHEN `age` >= 61 THEN '[61+]'
        ELSE NULL
	END 
        AS `age_group`,
	COUNT(`age`)
FROM
	`wizzard_deposits`
GROUP BY
	`age_group`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 10. First Letter
-- -----------------------------------------------------------------------------------------------
SELECT 
	LEFT(`first_name`, 1) AS `first_letter`
FROM
	`wizzard_deposits`
WHERE
	`deposit_group` LIKE 'Troll Chest'
GROUP BY
	`first_letter`
ORDER BY
	`first_letter`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 11.	Average Interest 
-- -----------------------------------------------------------------------------------------------
SELECT 
	`deposit_group`,
    `is_deposit_expired`,
	AVG(`deposit_interest`) AS `average_interest`
FROM
	`wizzard_deposits`
WHERE
	`deposit_start_date` > '1985-01-01'
GROUP BY
	`deposit_group`, `is_deposit_expired`
ORDER BY
	`deposit_group` DESC, `is_deposit_expired` ASC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 12.	Rich Wizard, Poor Wizard*
-- -----------------------------------------------------------------------------------------------
/*
-- SET @prev_ammount := (SELECT `deposit_amount` FROM `wizzard_deposits` LIMIT 1);
SELECT @prev_ammount := `deposit_amount` FROM `wizzard_deposits` LIMIT 1;
SELECT
	SUM(`difference`) AS `sum_difference`
FROM
	(
    SELECT 
		@prev_ammount - `deposit_amount` AS `difference`,
		`first_name` AS `host_wizard`,
		@prev_ammount := `deposit_amount` AS `host_wizard_deposit`
	FROM
		`wizzard_deposits`
	)
	AS tmp_table
LIMIT
	1000;
*/

SELECT
	SUM(`tmp_1`.`host_wizard_deposit` - `tmp_1`.`guest_wizard_deposit`) AS `sum_difference`
FROM
	(
    SELECT 
		`wizzard_deposits_2`.`first_name` AS `host_wizard`,
		`wizzard_deposits_2`.`deposit_amount` AS `host_wizard_deposit`,
        -- Name is not required !!!
		(
		SELECT 
			`wizzard_deposits_31`.`first_name`
		FROM
			`wizzard_deposits` AS `wizzard_deposits_31`
		WHERE
			`wizzard_deposits_31`.`id` > `wizzard_deposits_2`.`id`
		LIMIT 1
		) 
			AS `guest_wizard`,
		(
		SELECT 
			`wizzard_deposits_32`.`deposit_amount`
		FROM
			`wizzard_deposits` AS `wizzard_deposits_32`
		WHERE
			`wizzard_deposits_32`.`id` > `wizzard_deposits_2`.`id`
		LIMIT 1
		) 
			AS `guest_wizard_deposit`
	FROM
		`wizzard_deposits` AS `wizzard_deposits_2`
	) AS `tmp_1`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 13.	 Employees Minimum Salaries
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

SELECT
	`department_id`,
    MIN(`salary`) AS `minimum_salary`
FROM
	`employees`
WHERE
	`department_id` IN (2, 5, 7) AND `hire_date` > '2000-01-01'
GROUP BY
	`department_id`
ORDER BY
	`department_id` ASC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 14.	Employees Average Salaries
-- -----------------------------------------------------------------------------------------------
SELECT
	`department_id`,
    AVG(IF(`department_id` = 1, `salary` + 5000, `salary`)) AS `avg_salary`
FROM
	`employees`
WHERE
	`salary` > 30000 AND `manager_id` != 42
GROUP BY
	`department_id`
ORDER BY
	`department_id` ASC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 15. Employees Maximum Salaries
-- -----------------------------------------------------------------------------------------------
SELECT
	`department_id`,
    MAX(`salary`) AS `max_salary`
FROM
	`employees`
GROUP BY
	`department_id`
HAVING
	`max_salary` NOT BETWEEN 30000 AND 70000
ORDER BY
	`department_id` ASC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 16.	Employees Count Salaries
-- -----------------------------------------------------------------------------------------------
SELECT
	COUNT(*)
FROM
	`employees`
WHERE
	`manager_id` IS NULL
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 17.	3rd Highest Salary*
-- -----------------------------------------------------------------------------------------------
SELECT
	`t1`.`department_id`,
    (
	SELECT
		`t2`.`salary`
	FROM
		`employees` AS `t2`
	WHERE
		`t2`.`department_id` = `t1`.`department_id`
	GROUP BY
		-- Judge ignores equal salaries!!!
		`t2`.`salary`
	ORDER BY
		`t2`.`salary` DESC
	LIMIT
		2, 1
    ) AS `third_highest_salary`
FROM
	`employees` AS `t1`
GROUP BY
	`t1`.`department_id`
HAVING
	`third_highest_salary` IS NOT NULL
ORDER BY
	`t1`.`department_id` ASC
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- (18)17.	 Salary Challenge**
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_1`.`first_name`,
    `employees_1`.`last_name`,
	`employees_1`.`department_id`
FROM
	`employees` AS `employees_1`
WHERE
	`employees_1`.`salary` > 
		(
		SELECT
			`tmp2`.`avg_salary`
		FROM
			(
			SELECT
				`employees_3`.`department_id`,
				AVG(`employees_3`.`salary`) AS `avg_salary`
			FROM
				`employees` AS `employees_3`
			GROUP BY
				`employees_3`.`department_id`
			LIMIT
				1000
			) AS `tmp2`
		WHERE
			`tmp2`.`department_id` = `employees_1`.`department_id`
		LIMIT 1
		)
ORDER BY
	`employees_1`.`department_id` ASC, `employees_1`.`employee_id` ASC
LIMIT
	10;

-- -----------------------------------------------------------------------------------------------
-- 19.	Departments Total Salaries
-- -----------------------------------------------------------------------------------------------
SELECT
	`department_id`,
    SUM(`salary`) AS `total_salary`
FROM
	`employees`
GROUP BY
	`department_id`
ORDER BY
	`department_id` ASC
LIMIT
	1000;





