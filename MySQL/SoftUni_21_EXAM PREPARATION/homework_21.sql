-- -----------------------------------------------------------------------------------------------
-- DATABASE EXAM (Databases Sample Exam - 12 October 2016)
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- Konare Trade Bank(KTB)
-- -----------------------------------------------------------------------------------------------
USE bank;

-- -----------------------------------------------------------------------------------------------
-- Section 1. DDL
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `deposit_types`
(
	`deposit_type_id` INT(11),
    `name` VARCHAR(20),
    CONSTRAINT `pk_deposit_types` PRIMARY KEY (`deposit_type_id`)
);

CREATE TABLE `deposits`
(
	`deposit_id` INT(11) AUTO_INCREMENT,
    `amount` DECIMAL(10,2),
    `start_date` DATE,
    `end_date` DATE,
    `deposit_type_id` INT(11),
    `customer_id` INT(11),
    CONSTRAINT `pk_deposits` PRIMARY KEY (`deposit_id`),
    CONSTRAINT `fk_deposits_deposit_type` 
		FOREIGN KEY (`deposit_type_id`)
		REFERENCES `deposit_types`(`deposit_type_id`),
	CONSTRAINT `fk_deposits_customer_id` 
		FOREIGN KEY (`customer_id`)
		REFERENCES `customers`(`customer_id`)
);

CREATE TABLE `employees_deposits`
(
	`employee_id` INT(11),
	`deposit_id` INT(11),
    CONSTRAINT `pk_employees_deposits` PRIMARY KEY (`employee_id`, `deposit_id`),
    CONSTRAINT `fk_employees_deposits_employee_id` 
		FOREIGN KEY (`employee_id`)
		REFERENCES `employees`(`employee_id`),
    CONSTRAINT `fk_employees_deposits_deposit_id` 
		FOREIGN KEY (`deposit_id`)
		REFERENCES `deposits`(`deposit_id`)
);

CREATE TABLE `credit_history`
(
	`credit_history_id` INT(11),
    `mark` CHAR(1),
    `start_date` DATE,
    `end_date` DATE,
    `customer_id` INT(11),
    CONSTRAINT `pk_credit_history` PRIMARY KEY (`credit_history_id`),
    CONSTRAINT `fk_credit_history_customer_id` 
		FOREIGN KEY (`customer_id`)
		REFERENCES `customers`(`customer_id`)
);

CREATE TABLE `payments`
(
	`payement_id` INT(11),
    `date` DATE,
    `amount` DECIMAL(10,2),
    `loan_id` INT(11),
    CONSTRAINT `pk_payments` PRIMARY KEY (`payement_id`),
    CONSTRAINT `fk_payments_loan_id` 
		FOREIGN KEY (`loan_id`)
		REFERENCES `loans`(`loan_id`)
);

CREATE TABLE `users`
(
	`user_id` INT(11),
    `user_name` VARCHAR(20),
    `password` VARCHAR(20),
    `customer_id` INT(11),
    CONSTRAINT `pk_users` PRIMARY KEY (`user_id`),
    CONSTRAINT `uk_users_customer_id` UNIQUE (`customer_id`),
    CONSTRAINT `fk_users_customer_id` 
		FOREIGN KEY (`customer_id`)
		REFERENCES `customers`(`customer_id`)
);

ALTER TABLE `employees`
	ADD `manager_id` INT(11),
	ADD CONSTRAINT `fk_employees_manager_id` 
		FOREIGN KEY (`manager_id`)
		REFERENCES `employees`(`employee_id`);

-- -----------------------------------------------------------------------------------------------
-- Section 2. DML
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 1.	Insert data into the following tables 
-- -----------------------------------------------------------------------------------------------
INSERT INTO `deposit_types`
	(`deposit_type_id`, `deposit_name`)
VALUES
	(1,		'Time Deposit'),
	(2,		'Call Deposit'),
	(3,		'Free Deposit');

-- -----------------------------------------------------------------------------------------------
INSERT INTO `deposits`
	(`amount`, `start_date`, `deposit_type_id`, `customer_id`)
SELECT 
	IF(`customers_t1`.`date_of_birth` >= '1980-01-01', 1000, 1500) 
		+ IF(`customers_t1`.`gender` = 'm', 100, 200) 
			AS `amount`,
    DATE(NOW()) AS `start_date`,
    IF(
		`customers_t1`.`customer_id` IN (1, 3, 5, 7, 9, 11, 13, 15), 
        1, 
        IF(`customers_t1`.`customer_id` IN (2, 4, 6, 8, 10, 12, 14), 2, 3)) 
			AS `deposit_type_id`,
    `customers_t1`.`customer_id` AS `customer_id`
FROM
	`customers` AS `customers_t1`
WHERE
	`customers_t1`.`customer_id` < 20
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
INSERT INTO `employees_deposits`
	(`employee_id`, `deposit_id`)
VALUES
	(15,	4),
	(20,	15),
	(8,		7),
	(4,		8),
	(3,		13),
	(3,		8),
	(4,		10),
	(10,	1),
	(13,	4),
	(14,	9);

-- -----------------------------------------------------------------------------------------------
-- 2.	Update Employees
-- -----------------------------------------------------------------------------------------------
UPDATE
	`employees` AS `employees_t1`
SET
	`employees_t1`.`manager_id` = 
		(CASE 
            WHEN `employees_t1`.`employee_id` BETWEEN 2 AND 10 THEN 1
			WHEN `employees_t1`.`employee_id` BETWEEN 12 AND 20 THEN 11
			WHEN `employees_t1`.`employee_id` BETWEEN 22 AND 30 THEN 21
			WHEN `employees_t1`.`employee_id` IN (11, 21) THEN 1
		END)
    
WHERE
	TRUE
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 3.	Delete Records
-- -----------------------------------------------------------------------------------------------
DELETE
FROM
	`employees_deposits`
WHERE
    `employees_deposits`.`deposit_id` = 9
	OR `employees_deposits`.`employee_id` = 3
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- Section 3. Querying
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 1.	Employees’ Salary
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`employee_id` AS `employee_id`,
    `employees_t1`.`hire_date` AS `hire_date`,
    `employees_t1`.`salary` AS `salary`,
    `employees_t1`.`branch_id` AS `branch_id`
FROM
	`employees` AS `employees_t1`
WHERE
	`employees_t1`.`salary` > 2000
    AND `employees_t1`.`hire_date` > '2009-06-15'
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 2.	Customer Age
-- -----------------------------------------------------------------------------------------------
SELECT
	`customers_t1`.`first_name` AS `first_name`,
    `customers_t1`.`date_of_birth` AS `date_of_birth`,
    FLOOR((TO_DAYS('2016-10-01') - TO_DAYS(`customers_t1`.`date_of_birth`)) / 360) AS `age`
FROM
	`customers` AS `customers_t1`
HAVING
	`age` > 40 AND `age` < 50
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 3.	Customer City
-- -----------------------------------------------------------------------------------------------
SELECT
	`customers_t1`.`customer_id` AS `customer_id`,
	`customers_t1`.`first_name` AS `first_name`,
    `customers_t1`.`last_name` AS `Last_name`,
    `customers_t1`.`gender` AS `gender`,
    `cities_t1`.`city_name` AS `city_name`
FROM
	`customers` AS `customers_t1`
    
    INNER JOIN `cities` AS `cities_t1`
		ON `customers_t1`.`city_id` = `cities_t1`.`city_id`
    
WHERE
	(
		`customers_t1`.`last_name` LIKE 'Bu%'
		OR `customers_t1`.`first_name` LIKE '%a'
	)
    AND CHAR_LENGTH(`cities_t1`.`city_name`) >= 8
ORDER BY
	`customers_t1`.`customer_id` ASC
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 4.	Employee Accounts
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`employee_id` AS `employee_id`,
	`employees_t1`.`first_name` AS `first_name`,
    `accounts_t1`.`account_number` AS `account_number`
FROM
	`employees` AS `employees_t1`
    
    INNER JOIN `employees_accounts` AS `employees_accounts_t1`
		ON `employees_t1`.`employee_id` = `employees_accounts_t1`.`employee_id`

    INNER JOIN `accounts` AS `accounts_t1`
		ON `employees_accounts_t1`.`account_id` = `accounts_t1`.`account_id`
        
WHERE
	`accounts_t1`.`start_date` >= '2013-01-01'
GROUP BY
	`employees_t1`.`employee_id`
ORDER BY
	`employees_t1`.`first_name` DESC
LIMIT 
	5;

-- -----------------------------------------------------------------------------------------------
-- 5.	Employee Cities
-- -----------------------------------------------------------------------------------------------
SELECT
	`cities_t1`.`city_name` AS `city_name`,
	-- `employees_t1`.`first_name` AS `name`,
    `branches_t1`.`name` AS `name`,
    COUNT(`employees_t1`.`employee_id`) AS `employees_count`
FROM
	`cities` AS `cities_t1`
    
    INNER JOIN `branches` AS `branches_t1`
		ON `cities_t1`.`city_id` = `branches_t1`.`city_id`
    
    INNER JOIN `employees` AS `employees_t1`
		ON `branches_t1`.`branch_id` = `employees_t1`.`branch_id`
        
WHERE
	`cities_t1`.`city_id` NOT IN(4, 5)
GROUP BY
	`cities_t1`.`city_name`, `branches_t1`.`name`
HAVING
	`employees_count` >= 3
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 6.	Loan Statistics
-- -----------------------------------------------------------------------------------------------
SELECT
	SUM(`loans_t1`.`amount`),
    MAX(`loans_t1`.`interest`),
    MIN(`employees_t1`.`salary`)
FROM
	`loans` AS `loans_t1`
    
    INNER JOIN `employees_loans` AS `employees_loans_t1`
		ON `loans_t1`.`loan_id` = `employees_loans_t1`.`loan_id`
    
    INNER JOIN `employees` AS `employees_t1`
		ON `employees_loans_t1`.`employee_id` = `employees_t1`.`employee_id`
WHERE
	`employees_t1`.`employee_id` IS NOT NULL
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 7.	Unite People
-- -----------------------------------------------------------------------------------------------
SELECT 
	* 
FROM
	(
	SELECT
		`employees_t1`.`first_name` AS `first_name`,
		`cities_t1`.`city_name` AS `city_name`
	FROM
		`employees` AS `employees_t1`
		
		INNER JOIN `branches` AS `branches_t1`
			ON `employees_t1`.`branch_id` = `branches_t1`.`branch_id`
		
		INNER JOIN `cities` AS `cities_t1`
			ON `branches_t1`.`city_id` = `cities_t1`.`city_id`
	LIMIT 
		3
	) AS `employees_t2`

UNION

SELECT 
	*
FROM
	(
	SELECT
		`customers_t1`.`first_name` AS `first_name`,
		`cities_t1`.`city_name` AS `city_name`
	FROM
		`customers` AS `customers_t1`
		
		INNER JOIN `cities` AS `cities_t1`
			ON `customers_t1`.`city_id` = `cities_t1`.`city_id`
	LIMIT 
		3
	) AS `customers_t2`

LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 8.	Customers without Accounts
-- -----------------------------------------------------------------------------------------------
SELECT
	`customers_t1`.`customer_id` AS `customer_id`,
    `customers_t1`.`height` AS `height`
FROM
	`customers` AS `customers_t1`
    
    LEFT JOIN `accounts` AS `accounts_t1`
		ON `customers_t1`.`customer_id` = `accounts_t1`.`customer_id`

WHERE
	`accounts_t1`.`account_id` IS NULL
    AND `customers_t1`.`height` BETWEEN 1.74 AND 2.04
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 9.	Customers without Accounts (Section 3: Querying - P09. Average Loans)
-- -----------------------------------------------------------------------------------------------
SELECT
	`customers_t1`.`customer_id` AS `customer_id`,
    `loans_t1`.`amount` AS `amount`
FROM
	`customers` AS `customers_t1`
    
    INNER JOIN `loans` AS `loans_t1`
		ON `customers_t1`.`customer_id` = `loans_t1`.`customer_id`

WHERE
	`loans_t1`.`amount` >
		(
		SELECT
			AVG(`loans_t2`.`amount`)
		FROM
			`customers` AS `customers_t2`
			
			INNER JOIN `loans` AS `loans_t2`
				ON `customers_t2`.`customer_id` = `loans_t2`.`customer_id`
		WHERE
			`customers_t2`.`gender` = 'm'
		)
ORDER BY
	`customers_t1`.`last_name` ASC
LIMIT 
	5;

-- -----------------------------------------------------------------------------------------------
-- 10.	Oldest Account
-- -----------------------------------------------------------------------------------------------
SELECT
	`customers_t1`.`customer_id` AS `customer_id`,
    `customers_t1`.`first_name` AS `first_name`,
    `accounts_t1`.`start_date` AS `start_date`
FROM
	`customers` AS `customers_t1`
    
    INNER JOIN `accounts` AS `accounts_t1`
		ON `customers_t1`.`customer_id` = `accounts_t1`.`customer_id`

ORDER BY
	`accounts_t1`.`start_date` ASC
LIMIT 
	1;

-- -----------------------------------------------------------------------------------------------
-- Section 4. Programmability
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 1.	String Joiner Function
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP FUNCTION IF EXISTS `udf_concat_string`;

DELIMITER $$
USE `bank`$$
CREATE FUNCTION `udf_concat_string` 
(
	string1 VARCHAR(200),
    string2 VARCHAR(200)
)
RETURNS VARCHAR(200) 
BEGIN
    RETURN CONCAT(REVERSE(string1), REVERSE(string2));
    
END$$

DELIMITER ;

SELECT udf_concat_string('abc', 'def');

-- -----------------------------------------------------------------------------------------------
-- 2.	Unexpired Loans Procedure
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP PROCEDURE IF EXISTS `usp_customers_with_unexpired_loans`;

DELIMITER $$
USE `bank`$$
CREATE PROCEDURE `usp_customers_with_unexpired_loans` 
(
	in_customer_id INT(11)
)
BEGIN
	
	SELECT 
		`customers_t1`.`customer_id` AS `customer_id`,
		`customers_t1`.`first_name` AS `first_name`,
		`loans_t1`.`loan_id` AS `loan_id`
	FROM
		`customers` AS `customers_t1`
        
        INNER JOIN `loans` AS `loans_t1`
			ON `customers_t1`.`customer_id` = `loans_t1`.`customer_id`
            
	WHERE
		`loans_t1`.`expiration_date` IS NULL
        AND `customers_t1`.`customer_id` = in_customer_id
	LIMIT
		10000;
        
END$$

DELIMITER ;

CALL usp_customers_with_unexpired_loans(9);

-- -----------------------------------------------------------------------------------------------
-- 3.	Take Loan Procedure
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP PROCEDURE IF EXISTS `usp_take_loan`;

DELIMITER $$
USE `bank`$$
CREATE PROCEDURE `usp_take_loan` 
(
	in_customer_id INT(11),
    in_loan_amount decimal(18,2),
    in_interest decimal(4,2),
    in_start_date date
)
BEGIN
	
    START TRANSACTION;
    
	IF NOT (in_loan_amount >= 0.01 AND in_loan_amount <= 100000) THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Invalid Loan Amount.';
            
		ROLLBACK;
        
	ELSE
		INSERT INTO `loans`
			(`start_date`, `amount`, `interest`, `customer_id`)
		VALUES
			(in_start_date, in_loan_amount, in_interest, in_customer_id);
        
	END IF;
        
END$$

DELIMITER ;

CALL usp_take_loan (1, 500, 1,'20160915');

-- -----------------------------------------------------------------------------------------------
-- 4.	Trigger Hire Employee
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP TRIGGER IF EXISTS `employees_AFTER_INSERT`;

DELIMITER $$
USE `bank`$$
CREATE TRIGGER `employees_AFTER_INSERT` AFTER INSERT ON `employees` FOR EACH ROW
BEGIN
	DECLARE last_employees_loans_id INT;
    SET last_employees_loans_id := 
		(SELECT `employee_id` FROM `employees_loans` ORDER BY `employee_id` DESC, `loan_id` DESC LIMIT 1);
    
	UPDATE 
		`employees_loans`
	SET 
		`employee_id` = `NEW`.`employee_id`
	WHERE
		`employee_id` = last_employees_loans_id;

END
$$
DELIMITER ;

INSERT INTO employees 
	(employee_id, 	first_name, 	hire_date, 		salary, 	branch_id)
values 
	(31,' 			Jake ',			'2016-12-12',	500,		2);

-- -----------------------------------------------------------------------------------------------
-- Section 5. Bonus
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 1.	Delete Trigger
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `account_logs` LIKE `accounts`;

USE `bank`;
DROP TRIGGER IF EXISTS `accounts_AFTER_DELETE`;

DELIMITER $$
USE `bank`$$
CREATE TRIGGER `accounts_AFTER_DELETE` BEFORE DELETE ON `accounts` FOR EACH ROW
BEGIN
    DELETE FROM employees_accounts
    WHERE account_id = old.account_id;
	INSERT INTO `account_logs`
		(`account_id`, `account_number`, `start_date`, `customer_id`)
	VALUES 
		(`OLD`.`account_id`, `OLD`.`account_number`, `OLD`.`start_date`, `OLD`.`customer_id`);

END
$$
DELIMITER ;

DELETE FROM accounts
WHERE account_id = 5;







