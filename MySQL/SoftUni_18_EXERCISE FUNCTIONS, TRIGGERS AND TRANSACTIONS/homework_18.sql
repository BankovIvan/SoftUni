-- -----------------------------------------------------------------------------------------------
-- Exercises: Functions, Triggers and Transactions
-- -----------------------------------------------------------------------------------------------
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping structure for table bank.accounts
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE IF NOT EXISTS `accounts` (
  `id` int(11) NOT NULL,
  `account_holder_id` int(11) NOT NULL,
  `balance` decimal(19,4) DEFAULT '0.0000',
  PRIMARY KEY (`id`),
  KEY `fk_accounts_account_holders` (`account_holder_id`),
  CONSTRAINT `fk_accounts_account_holders` FOREIGN KEY (`account_holder_id`) REFERENCES `account_holders` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table bank.accounts: ~18 rows (approximately)
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` (`id`, `account_holder_id`, `balance`) VALUES
	(1, 1, 123.1200),
	(2, 3, 4354.2300),
	(3, 12, 6546543.2300),
	(4, 9, 15345.6400),
	(5, 11, 36521.2000),
	(6, 8, 5436.3400),
	(7, 10, 565649.2000),
	(8, 11, 999453.5000),
	(9, 1, 5349758.2300),
	(10, 2, 543.3000),
	(11, 3, 10.2000),
	(12, 7, 245656.2300),
	(13, 5, 5435.3200),
	(14, 4, 1.2300),
	(15, 6, 0.1900),
	(16, 2, 5345.3400),
	(17, 11, 76653.2000),
	(18, 1, 235469.8900);
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;


-- Dumping structure for table bank.account_holders
DROP TABLE IF EXISTS `account_holders`;
CREATE TABLE IF NOT EXISTS `account_holders` (
  `id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `ssn` char(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table bank.account_holders: ~12 rows (approximately)
/*!40000 ALTER TABLE `account_holders` DISABLE KEYS */;
INSERT INTO `account_holders` (`id`, `first_name`, `last_name`, `ssn`) VALUES
	(1, 'Susan', 'Cane', '1234567890'),
	(2, 'Kim', 'Novac', '1234567890'),
	(3, 'Jimmy', 'Henderson', '1234567890'),
	(4, 'Steve', 'Stevenson', '1234567890'),
	(5, 'Bjorn', 'Sweden', '1234567890'),
	(6, 'Kiril', 'Petrov', '1234567890'),
	(7, 'Petar', 'Kirilov', '1234567890'),
	(8, 'Michka', 'Tsekova', '1234567890'),
	(9, 'Zlatina', 'Pateva', '1234567890'),
	(10, 'Monika', 'Miteva', '1234567890'),
	(11, 'Zlatko', 'Zlatyov', '1234567890'),
	(12, 'Petko', 'Petkov Junior', '1234567890');
/*!40000 ALTER TABLE `account_holders` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;

-- -----------------------------------------------------------------------------------------------
-- Part I – Queries for SoftUni Database
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

-- -----------------------------------------------------------------------------------------------
-- 1.	Employees with Salary Above 35000
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP PROCEDURE IF EXISTS `usp_get_employees_salary_above_35000`;

DELIMITER $$
USE `soft_uni`$$
CREATE PROCEDURE `usp_get_employees_salary_above_35000` ()
BEGIN
    SELECT 
		`employees_t1`.`first_name`,
		`employees_t1`.`last_name`
	FROM
		`employees` AS `employees_t1`
	WHERE
		`employees_t1`.`salary` > 35000
	ORDER BY
		`employees_t1`.`first_name` ASC, `employees_t1`.`last_name` ASC, `employees_t1`.`salary` ASC
	LIMIT
		1000;
    
END$$

DELIMITER ;

CALL `usp_get_employees_salary_above_35000` ();

-- -----------------------------------------------------------------------------------------------
-- 2.	Employees with Salary Above Number
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP PROCEDURE IF EXISTS `usp_get_employees_salary_above`;

DELIMITER $$
USE `soft_uni`$$
CREATE PROCEDURE `usp_get_employees_salary_above` (`salary_limit` decimal(19,4))
BEGIN
    SELECT 
		`employees_t1`.`first_name`,
		`employees_t1`.`last_name`
	FROM
		`employees` AS `employees_t1`
	WHERE
		`employees_t1`.`salary` >= `salary_limit`
	ORDER BY
		`employees_t1`.`first_name` ASC, `employees_t1`.`last_name` ASC, `employees_t1`.`salary` ASC
	LIMIT
		1000;
    
END$$

DELIMITER ;

CALL `usp_get_employees_salary_above` (48100);

-- -----------------------------------------------------------------------------------------------
-- 3.	Town Names Starting With
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP PROCEDURE IF EXISTS `usp_get_towns_starting_with`;

DELIMITER $$
USE `soft_uni`$$
CREATE PROCEDURE `usp_get_towns_starting_with` (`town_start_letters` varchar(50))
BEGIN
	DECLARE `num_letters` INT;
    SET `num_letters` = CHARACTER_LENGTH(`town_start_letters`);
    SELECT 
		`towns_t1`.`name`
	FROM
		`towns` AS `towns_t1`
	WHERE
		LEFT(`towns_t1`.`name`, `num_letters`) LIKE `town_start_letters` COLLATE 'utf8_general_ci'
	ORDER BY
		`towns_t1`.`name` ASC
	LIMIT
		1000;
    
END$$

DELIMITER ;

CALL `usp_get_towns_starting_with` ('b');

-- -----------------------------------------------------------------------------------------------
-- 4.	Employees from Town
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP PROCEDURE IF EXISTS `usp_get_employees_from_town`;

DELIMITER $$
USE `soft_uni`$$
CREATE PROCEDURE `usp_get_employees_from_town` (`town_name` varchar(50))
BEGIN
    SELECT 
		`employees_t1`.`first_name`,
		`employees_t1`.`last_name`
	FROM
		`employees` AS `employees_t1`
        INNER JOIN `addresses` AS `addresses_t1`
			ON `employees_t1`.`address_id` = `addresses_t1`.`address_id`
        INNER JOIN `towns` AS `towns_t1`
			ON `addresses_t1`.`town_id` = `towns_t1`.`town_id`
	WHERE
		`towns_t1`.`name` LIKE `town_name` COLLATE 'utf8_general_ci'
	ORDER BY
		`employees_t1`.`first_name` ASC, `employees_t1`.`last_name` ASC, `employees_t1`.`salary` ASC
	LIMIT
		1000;
    
END$$

DELIMITER ;

CALL `usp_get_employees_from_town` ('Sofia');

-- -----------------------------------------------------------------------------------------------
-- 5.	Salary Level Function
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP FUNCTION IF EXISTS `ufn_get_salary_level`;

DELIMITER $$
USE `soft_uni`$$
CREATE FUNCTION `ufn_get_salary_level` (`salary_in` decimal(19,4))
RETURNS VARCHAR(50)
BEGIN
    DECLARE ret VARCHAR(50);
    SET ret := 
    (
		SELECT
			CASE 
				WHEN `salary_in` < 30000 THEN 'Low'
                WHEN `salary_in` >= 30000 AND `salary_in` <= 50000 THEN 'Average'
                ELSE 'High'
			END
	);
    
    RETURN ret;
    
END$$

DELIMITER ;

SELECT `ufn_get_salary_level` (125500.00);

-- -----------------------------------------------------------------------------------------------
-- 6.	Employees by Salary Level
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP PROCEDURE IF EXISTS `usp_get_employees_by_salary_level`;

DELIMITER $$
USE `soft_uni`$$
CREATE PROCEDURE `usp_get_employees_by_salary_level` (`salary_level` VARCHAR(50))
BEGIN
    SELECT 
		`employees_t1`.`first_name`,
		`employees_t1`.`last_name`
	FROM
		`employees` AS `employees_t1`
	WHERE
		`salary_level` LIKE `ufn_get_salary_level` (`employees_t1`.`salary`)
	ORDER BY
		`employees_t1`.`first_name` DESC, `employees_t1`.`last_name` DESC
	LIMIT
		1000;
    
END$$

DELIMITER ;

CALL `usp_get_employees_by_salary_level` ('High');

-- -----------------------------------------------------------------------------------------------
-- 7.	Define Function
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;
DROP FUNCTION IF EXISTS `ufn_is_word_comprised`;

DELIMITER $$
USE `soft_uni`$$
CREATE FUNCTION `ufn_is_word_comprised` (`set_of_letters` varchar(500), `word` varchar(500))
RETURNS INT
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE j INT DEFAULT 0;

	label1: LOOP
		SET i := i + 1;        
		IF i <= CHARACTER_LENGTH(`word`) THEN
			SET j:= INSTR(`set_of_letters`,  SUBSTRING(`word` FROM i FOR 1));
			IF j = 0 THEN
				RETURN 0;
			ELSE
            /*
				SET `set_of_letters` := 
					CONCAT(
						SUBSTRING(`set_of_letters` FROM 1 FOR j - 1), 
                        SUBSTRING(`set_of_letters` FROM j + 1)
                        );
            */
				ITERATE label1;
            END IF;
            
		END IF;
		LEAVE label1;
    END LOOP label1;
	    
    RETURN 1;
    
END$$

DELIMITER ;

SELECT `ufn_is_word_comprised` ('oistmiahf', 'Sofiai');

SELECT `ufn_is_word_comprised` ('a', 'AAA');
SELECT `ufn_is_word_comprised` ('cba', 'ABC');

-- -----------------------------------------------------------------------------------------------
-- PART II – Queries for Bank Database
-- -----------------------------------------------------------------------------------------------
USE `bank`;

-- -----------------------------------------------------------------------------------------------
-- 8.	Find Full Name (09)
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP PROCEDURE IF EXISTS `usp_get_holders_full_name`;

DELIMITER $$
USE `bank`$$
CREATE PROCEDURE `usp_get_holders_full_name` ()
BEGIN
    SELECT 
		CONCAT(`account_holders_t1`.`first_name`, ' ', `account_holders_t1`.`last_name`) AS `full_name`
	FROM
		`account_holders` AS `account_holders_t1`
	ORDER BY
		`full_name` ASC, `account_holders_t1`.`id` ASC
	LIMIT
		1000;
    
END$$

DELIMITER ;

CALL `usp_get_holders_full_name` ();

-- -----------------------------------------------------------------------------------------------
-- 9.	People with Balance Higher Than (10)
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP PROCEDURE IF EXISTS `usp_get_holders_with_balance_higher_than`;

DELIMITER $$
USE `bank`$$
CREATE PROCEDURE `usp_get_holders_with_balance_higher_than` (balance_limit decimal(19,4))
BEGIN
    SELECT 
		`account_holders_t1`.`first_name`,
        `account_holders_t1`.`last_name`
	FROM
		`account_holders` AS `account_holders_t1`
        INNER JOIN `accounts` AS `accounts_t1`
			ON `account_holders_t1`.`id` = `accounts_t1`.`account_holder_id`
	GROUP BY
		`account_holders_t1`.`id`
	HAVING
		SUM(`accounts_t1`.`balance`) > balance_limit
	ORDER BY
		-- `account_holders_t1`.`first_name` ASC, 
        -- `account_holders_t1`.`last_name` ASC,
        `accounts_t1`.`id` ASC
	LIMIT
		1000;
    
END$$

DELIMITER ;

CALL `usp_get_holders_with_balance_higher_than` (7000);

-- -----------------------------------------------------------------------------------------------
-- 10.	Future Value Function (11)
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP FUNCTION IF EXISTS `ufn_calculate_future_value`;

DELIMITER $$
USE `bank`$$
CREATE FUNCTION `ufn_calculate_future_value` 
(
	I decimal(19,4), -- sum
    R decimal(19,4), -- yearly interest rate
    T decimal(19,4)  -- number of years
)
-- DOUBLE for Judge test (11);  
-- decimal(19,4) for Judge test (12);
RETURNS DOUBLE 
-- RETURNS decimal(19,4)
BEGIN
	DECLARE ret decimal(19,4) DEFAULT NULL;
    
    SET ret := I * POWER(1 + R, T);
    
    -- ROUND for Judge test (11);  
    -- Do Not ROUND for Judge test (12);  
    SET ret := ROUND(ret, 2);
    
    RETURN ret;
    
END$$

DELIMITER ;

SELECT `ufn_calculate_future_value` (1000, 0.1, 5);

-- -----------------------------------------------------------------------------------------------
-- 11.	Calculating Interest (12)
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP PROCEDURE IF EXISTS `usp_calculate_future_value_for_account`;

DELIMITER $$
USE `bank`$$
CREATE PROCEDURE `usp_calculate_future_value_for_account` 
(
	account_id_in INT,
	interest_rate decimal(19,4)
)
BEGIN
    SELECT 
		`accounts_t1`.`id` AS `account_id`,
		`account_holders_t1`.`first_name`,
        `account_holders_t1`.`last_name`,
        `accounts_t1`.`balance` AS `current_balance`,
		`ufn_calculate_future_value` (`accounts_t1`.`balance`, interest_rate, 5) AS `balance_in_5_years`
	FROM
		`account_holders` AS `account_holders_t1`
        INNER JOIN `accounts` AS `accounts_t1`
			ON `account_holders_t1`.`id` = `accounts_t1`.`account_holder_id`
	WHERE
		`accounts_t1`.`id` = account_id_in
	LIMIT
		1000;
    
END$$

DELIMITER ;

CALL `usp_calculate_future_value_for_account` (1, 0.1);

-- -----------------------------------------------------------------------------------------------
-- 12.	Deposit Money (13)
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP PROCEDURE IF EXISTS `usp_deposit_money`;

DELIMITER $$
USE `bank`$$
CREATE PROCEDURE `usp_deposit_money` 
(
	account_id_in INT,
	money_amount decimal(19,4)
)
usp_deposit_money_begin_label:
BEGIN
	/*
    IF (SELECT `id` FROM `accounts` WHERE account_id_in = `id`) IS NULL THEN
		LEAVE usp_deposit_money_begin_label;
    END IF;

	IF money_amount <= 0.0000 THEN
		LEAVE usp_deposit_money_begin_label;
    END IF;
    */
    
    START TRANSACTION;
    
	IF (SELECT COUNT(`id`) FROM `accounts` WHERE account_id_in = `id`) <> 1 
	OR money_amount <= 0.0000 THEN
		ROLLBACK;
	
    ELSE
    	UPDATE
			`accounts` AS `accounts_t1`
		SET 
			`accounts_t1`.`balance` = `accounts_t1`.`balance` + money_amount
		WHERE
			`accounts_t1`.`id` = account_id_in
		LIMIT
			1000;
    
    END IF;
	
    /*
	SELECT 
		`accounts_t1`.`id` AS `account_id`,
		`accounts_t1`.`account_holder_id`,
        `accounts_t1`.`balance`
	FROM
		`accounts` AS `accounts_t1`
	WHERE
		`accounts_t1`.`id` = account_id_in
	LIMIT
		1000;
	*/
    
END$$

DELIMITER ;

CALL `usp_deposit_money` (1, 10);

-- -----------------------------------------------------------------------------------------------
-- 13.	Withdraw Money (14)
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP PROCEDURE IF EXISTS `usp_withdraw_money`;

DELIMITER $$
USE `bank`$$
CREATE PROCEDURE `usp_withdraw_money` 
(
	account_id_in INT,
	money_amount decimal(19,4)
)
BEGIN

    START TRANSACTION;
    
	IF (SELECT COUNT(`id`) FROM `accounts` WHERE account_id_in = `id`) <> 1 
	OR money_amount <= 0.0000 
    OR (SELECT `balance` FROM `accounts` WHERE account_id_in = `id`) <= money_amount THEN
		ROLLBACK;
	
    ELSE
    	UPDATE
			`accounts` AS `accounts_t1`
		SET 
			`accounts_t1`.`balance` = `accounts_t1`.`balance` - money_amount
		WHERE
			`accounts_t1`.`id` = account_id_in
		LIMIT
			1000;
    
    END IF;
	
    /*
	SELECT 
		`accounts_t1`.`id` AS `account_id`,
		`accounts_t1`.`account_holder_id`,
        `accounts_t1`.`balance`
	FROM
		`accounts` AS `accounts_t1`
	WHERE
		`accounts_t1`.`id` = account_id_in
	LIMIT
		1000;
	*/
    
END$$

DELIMITER ;

CALL `usp_withdraw_money` (1, 10);

-- -----------------------------------------------------------------------------------------------
-- 14.	Money Transfer (15)
-- -----------------------------------------------------------------------------------------------
USE `bank`;
DROP PROCEDURE IF EXISTS `usp_transfer_money`;

DELIMITER $$
USE `bank`$$
CREATE PROCEDURE `usp_transfer_money` 
(
	from_account_id INT,
    to_account_id INT,
	amount decimal(19,4)
)
BEGIN

    START TRANSACTION;
    
	IF from_account_id = to_account_id
    OR(SELECT COUNT(`id`) FROM `accounts` WHERE from_account_id = `id`) <> 1 
    OR (SELECT COUNT(`id`) FROM `accounts` WHERE to_account_id = `id`) <> 1
	OR amount < 0.0000 
    OR (SELECT `balance` FROM `accounts` WHERE from_account_id = `id`) < amount 
    THEN
		ROLLBACK;
	
    ELSE
    	UPDATE
			`accounts` AS `accounts_t1`
		SET 
			`accounts_t1`.`balance` = `accounts_t1`.`balance` - amount
		WHERE
			`accounts_t1`.`id` = from_account_id
		LIMIT
			1000;
    
		UPDATE
			`accounts` AS `accounts_t1`
		SET 
			`accounts_t1`.`balance` = `accounts_t1`.`balance` + amount
		WHERE
			`accounts_t1`.`id` = to_account_id
		LIMIT
			1000;
            
    END IF;
	
    /*
    SELECT 
		`accounts_t1`.`id` AS `account_id`,
		`accounts_t1`.`account_holder_id`,
        `accounts_t1`.`balance`
	FROM
		`accounts` AS `accounts_t1`
	WHERE
		`accounts_t1`.`id` IN (from_account_id, to_account_id)
	LIMIT
		1000;
	*/
    
END$$

DELIMITER ;

CALL `usp_transfer_money` (1, 2, 10);

-- -----------------------------------------------------------------------------------------------
-- 15.	Log Accounts Trigger (16)
-- -----------------------------------------------------------------------------------------------
USE `bank`;
CREATE TABLE `logs`
(
	`log_id` INT(11) UNSIGNED AUTO_INCREMENT,
    `account_id` INT(11) UNSIGNED,
    `old_sum` decimal(19,4),
    `new_sum` decimal(19,4),
    CONSTRAINT `pk_logs` PRIMARY KEY (`log_id`)
);

USE `bank`;
DROP TRIGGER IF EXISTS `accounts_AFTER_UPDATE`;

DELIMITER $$
USE `bank`$$
CREATE TRIGGER `accounts_AFTER_UPDATE` AFTER UPDATE ON `accounts` FOR EACH ROW
BEGIN
	INSERT 
		INTO `logs`     
        (
			`account_id`,
            `old_sum`,
            `new_sum`
		)
		VALUES
        (
			`OLD`.`id`,
            `OLD`.`balance`,
            `NEW`.`balance`
		);

END
$$
DELIMITER ;

-- -----------------------------------------------------------------------------------------------
-- 16.	Emails Trigger (17)
-- -----------------------------------------------------------------------------------------------
USE `bank`;
CREATE TABLE `notification_emails`
(
	`id` INT(11) UNSIGNED AUTO_INCREMENT,
    `recipient` INT(11) UNSIGNED,
    `subject` TEXT,
    `body` TEXT,
    CONSTRAINT `pk_logs` PRIMARY KEY (`id`)
);

USE `bank`;
DROP TRIGGER IF EXISTS `logs_AFTER_INSERT`;

DELIMITER $$
USE `bank`$$
CREATE TRIGGER `logs_AFTER_INSERT` AFTER INSERT ON `logs` FOR EACH ROW
BEGIN
	INSERT 
		INTO `notification_emails`     
        (
			`recipient`,
            `subject`,
            `body`
		)
		VALUES
        (
			`NEW`.`account_id`,
            concat('Balance change for account: ', `NEW`.`account_id`),
            concat('On ', current_date(), ' your balance was changed from ', `NEW`.`old_sum`, ' to ', `NEW`.`new_sum`, '.')
		);

END
$$
DELIMITER ;





