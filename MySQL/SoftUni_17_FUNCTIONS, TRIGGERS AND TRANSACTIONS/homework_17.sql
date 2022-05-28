-- -----------------------------------------------------------------------------------------------
-- Lab: Functions, Triggers and Transactions
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

-- -----------------------------------------------------------------------------------------------
-- 1.	Count Employees by Town
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP FUNCTION IF EXISTS `ufn_count_employees_by_town`;

DELIMITER $$
USE `soft_uni`$$
CREATE FUNCTION `ufn_count_employees_by_town`(`town_name` VARCHAR(50))
RETURNS DOUBLE
BEGIN
	DECLARE `e_count` DOUBLE;
	SET `e_count` := 
		(
        SELECT
			Count(*) AS `count`
		FROM
			`employees` AS `employees_t1`
            
            INNER JOIN `addresses` AS `addresses_t1`
				ON `employees_t1`.`address_id` = `addresses_t1`.`address_id`
                
			INNER JOIN `towns` AS `towns_t1`
				ON `addresses_t1`.`town_id` = `towns_t1`.`town_id`
		
        WHERE
			`towns_t1`.`name` LIKE `town_name`
		LIMIT 
			1000
		);
	RETURN `e_count`;
 
END$$
delimiter ;

SELECT `ufn_count_employees_by_town` ('Sofia');

-- -----------------------------------------------------------------------------------------------
-- 2.	Employees Promotion
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP PROCEDURE IF EXISTS `usp_raise_salaries`;

DELIMITER $$
USE `soft_uni`$$
CREATE PROCEDURE `usp_raise_salaries` (`department_name` VARCHAR(50))
BEGIN
	DECLARE `department_id_data` INT(11);
    SET `department_id_data` := 
		(
        SELECT
			`department_id`
		FROM
			`departments`
		WHERE
			`name` LIKE `department_name`
		LIMIT
			1
		);
    
    /*
    SELECT `department_id_data`;
    */
    
    UPDATE
		`employees`
	SET 
		`salary` = `salary` * 1.05
	WHERE
		`department_id` = `department_id_data`
	LIMIT
		1000;
	
    /*
    SELECT 
		`employees_t1`.`first_name`,
		`employees_t1`.`salary`
	FROM
		`employees` AS `employees_t1`
		INNER JOIN `departments` AS `departments_t1`
			ON `employees_t1`.`department_id` = `departments_t1`.`department_id`
	WHERE
		`departments_t1`.`name` LIKE `department_name`
	ORDER BY
		`employees_t1`.`first_name`, `employees_t1`.`salary`
	LIMIT
		1000;
	*/
    
END$$

DELIMITER ;

CALL `usp_raise_salaries` ('Finance');

-- -----------------------------------------------------------------------------------------------
-- 3.	Employees Promotion By ID
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP PROCEDURE IF EXISTS `usp_raise_salary_by_id`;

DELIMITER $$
USE `soft_uni`$$
CREATE PROCEDURE `usp_raise_salary_by_id` (`id` INT(11))
BEGIN
    UPDATE
		`employees`
	SET 
		`salary` = `salary` * 1.05
	WHERE
		`employee_id` = `id`
	LIMIT
		1000;
    
    /*
	SELECT
		`salary`
	FROM
		`employees`
	WHERE
		`employee_id` = `id`
	LIMIT
		1000;
	*/
        
END$$

DELIMITER ;

CALL `usp_raise_salary_by_id` (1000);

-- -----------------------------------------------------------------------------------------------
-- 4.	Triggered
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `employees1` AS SELECT * FROM `employees`;

CREATE TABLE `deleted_employees`
(
	`employee_id` INT(11) UNSIGNED AUTO_INCREMENT,
    `first_name` VARCHAR(50),
    `last_name` VARCHAR(50),
    `middle_name` VARCHAR(50),
    `job_title` VARCHAR(50),
    `department_id` INT(10),
    `salary` DECIMAL(10, 2),
    CONSTRAINT `pk_deleted_employees` PRIMARY KEY (`employee_id`)
);

DROP TRIGGER IF EXISTS `soft_uni`.`employees1_AFTER_DELETE`;

DELIMITER $$
USE `soft_uni`$$
-- CREATE DEFINER = CURRENT_USER TRIGGER `soft_uni`.`employees1_AFTER_DELETE` AFTER DELETE ON `employees1` FOR EACH ROW
CREATE TRIGGER `soft_uni`.`tr_deleted_employees` 
	AFTER DELETE 
    ON `employees1` 
    FOR EACH ROW
BEGIN
	INSERT
		INTO `deleted_employees`
		(
			`first_name`,
			`last_name`,
			`middle_name`,
			`job_title`,
			`department_id`,
			`salary`
		)
		VALUES
		(
			`OLD`.`first_name`,
			`OLD`.`last_name`,
			`OLD`.`middle_name`,
			`OLD`.`job_title`,
			`OLD`.`department_id`,
			`OLD`.`salary`
        );
END
$$
DELIMITER ;

DELETE 
	FROM 
		`employees1`
	WHERE
		`employees1`.`employee_id` = 5;
    





