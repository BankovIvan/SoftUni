-- -----------------------------------------------------------------------------------------------
-- Database Basics MS SQL Exam – 22 Oct 2017
-- -----------------------------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `report service`;
CREATE SCHEMA `report service`;
USE `report service`;
-- -----------------------------------------------------------------------------------------------
-- Report Service
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- Section 1. DDL (30 pts)
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 1.	Table design
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `users`
(
	`id` INT(11) UNSIGNED AUTO_INCREMENT,
    `username` VARCHAR(30) NOT NULL,
    `password` VARCHAR(50) NOT NULL,
    `name` VARCHAR(50),
    `gender` VARCHAR(1),
    `birthdate` DATETIME,
    `age` INT(11) UNSIGNED,
    `email` VARCHAR(50) NOT NULL,
    CONSTRAINT `pk_users` PRIMARY KEY (`id`),
    CONSTRAINT `unique_users_username` UNIQUE (`username`)
);

CREATE TABLE `departments`
(
	`id` INT(11) UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL,
    CONSTRAINT `pk_departments` PRIMARY KEY (`id`)
);

CREATE TABLE `employees`
(
	`id` INT(11) UNSIGNED AUTO_INCREMENT,
    `first_name` VARCHAR(25),
    `last_name` VARCHAR(25),
    `gender` VARCHAR(1),
    `birthdate` DATETIME,
    `age` INT(11) UNSIGNED,
    `department_id` INT(11) UNSIGNED NOT NULL,
    CONSTRAINT `pk_employees` PRIMARY KEY (`id`)
);

CREATE TABLE `categories`
(
	`id` INT(11) UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL,
	`department_id` INT(11) UNSIGNED,
    CONSTRAINT `pk_categories` PRIMARY KEY (`id`)
);

CREATE TABLE `status`
(
	`id` INT(11) UNSIGNED AUTO_INCREMENT,
    `label` VARCHAR(30) NOT NULL,
    CONSTRAINT `pk_status` PRIMARY KEY (`id`)
);

CREATE TABLE `reports`
(
	`id` INT(11) UNSIGNED AUTO_INCREMENT,
    `category_id` INT(11) UNSIGNED NOT NULL,
    `status_id` INT(11) UNSIGNED NOT NULL,
    `open_date` DATETIME,
    `close_date` DATETIME,
    `description` VARCHAR(200),
    `user_id` INT(11) UNSIGNED NOT NULL,
	`employee_id` INT(11) UNSIGNED,
    CONSTRAINT `pk_reports` PRIMARY KEY (`id`)
);

ALTER TABLE `employees`
	ADD CONSTRAINT `fk_employees_departments` 
		FOREIGN KEY (`department_id`)
		REFERENCES `departments`(`id`)
        ON DELETE CASCADE;

ALTER TABLE `categories`
	ADD CONSTRAINT `fk_categories_departments` 
		FOREIGN KEY (`department_id`)
		REFERENCES `departments`(`id`);

ALTER TABLE `reports`
	ADD CONSTRAINT `fk_reports_categories` 
		FOREIGN KEY (`category_id`)
		REFERENCES `categories`(`id`);
ALTER TABLE `reports`
	ADD CONSTRAINT `fk_reports_status` 
		FOREIGN KEY (`status_id`)
		REFERENCES `status`(`id`);
ALTER TABLE `reports`
	ADD CONSTRAINT `fk_reports_users` 
		FOREIGN KEY (`user_id`)
		REFERENCES `users`(`id`);
ALTER TABLE `reports`
	ADD CONSTRAINT `fk_reports_employees` 
		FOREIGN KEY (`employee_id`)
		REFERENCES `employees`(`id`);

-- -----------------------------------------------------------------------------------------------
-- Section 2. DML (10 pts)
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 2.	Insert
-- -----------------------------------------------------------------------------------------------
INSERT INTO `employees`
	(`first_name`, `last_name`, `gender`, `birthdate`, `department_id`)
VALUES
    ('Marlo', 		'O\'Malley', 	'M', 	STR_TO_DATE('9/21/1958','%m/%d/%Y'), 	1),
    ('Niki', 		'Stanaghan', 	'F', 	STR_TO_DATE('11/26/1969','%m/%d/%Y'), 	4),
    ('Ayrton', 		'Senna', 		'M', 	STR_TO_DATE('03/21/1960','%m/%d/%Y'), 	9),
    ('Ronnie', 		'Peterson', 	'M', 	STR_TO_DATE('02/14/1944','%m/%d/%Y'), 	9),
    ('Giovanna', 	'Amati', 		'M', 	STR_TO_DATE('07/20/1959','%m/%d/%Y'), 	5);

INSERT INTO `reports`
	(`category_id`, `status_id`, `open_date`, `close_date`, `description`, `user_id`, `employee_id`)
VALUES
    (1,	1, STR_TO_DATE('04/13/2017','%m/%d/%Y'), NULL, 									'Stuck Road on Str.133', 			6, 2),
    (6,	3, STR_TO_DATE('09/05/2015','%m/%d/%Y'), STR_TO_DATE('12/06/2015','%m/%d/%Y'), 	'Charity trail running', 			3, 5),
    (14,2, STR_TO_DATE('09/07/2015','%m/%d/%Y'), NULL, 									'Falling bricks on Str.58', 		5, 2),
    (4, 3, STR_TO_DATE('07/03/2017','%m/%d/%Y'), STR_TO_DATE('07/06/2017','%m/%d/%Y'), 	'Cut off streetlight on Str.11', 	1, 1);

-- -----------------------------------------------------------------------------------------------
-- 3.	Update
-- -----------------------------------------------------------------------------------------------
UPDATE
	`reports`
SET
	`status_id` = 2
WHERE
	`reports`.`status_id` = 1
    AND `reports`.`category_id` = 4
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 4.	Delete
-- -----------------------------------------------------------------------------------------------
DELETE
FROM
	`reports`
WHERE
	`reports`.`status_id` = 4
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- Section 3. Querying (40 pts)
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 5.	Users by Age
-- -----------------------------------------------------------------------------------------------
SELECT
	`users_t1`.`username` AS `username`,
    `users_t1`.`age` AS `age`
FROM
	`users` AS `users_t1`
ORDER BY
	`users_t1`.`age` ASC,
    `users_t1`.`username` DESC
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 6.	Unassigned Reports
-- -----------------------------------------------------------------------------------------------
SELECT
	`reports_t1`.`description` AS `description`,
    `reports_t1`.`open_date` AS `open_date`
FROM
	`reports` AS `reports_t1`
WHERE
	`reports_t1`.`employee_id` IS NULL
ORDER BY
	`reports_t1`.`open_date` ASC,
    `reports_t1`.`description`
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 7.	Employees & Reports
-- -----------------------------------------------------------------------------------------------
SELECT
	`employees_t1`.`first_name` AS `first_name`,
    `employees_t1`.`last_name` AS `last_name`,
	`reports_t1`.`description` AS `description`,
    DATE_FORMAT(`reports_t1`.`open_date`, '%Y-%m-%d') AS `open_date`
FROM
	`reports` AS `reports_t1`
    -- LEFT JOIN does not work!
    INNER JOIN `employees` AS `employees_t1`
		ON `reports_t1`.`employee_id` = `employees_t1`.`id`
WHERE
	`reports_t1`.`employee_id` IS NOT NULL
ORDER BY
	`reports_t1`.`employee_id` ASC,
	`reports_t1`.`open_date` ASC,
    `reports_t1`.`id` ASC
LIMIT 
	10000;

-- Also working;
SELECT
	`employees_t1`.`first_name` AS `first_name`,
    `employees_t1`.`last_name` AS `last_name`,
	`reports_t1`.`description` AS `description`,
    DATE_FORMAT(`reports_t1`.`open_date`, '%Y-%m-%d') AS `open_date`
FROM
	`employees` AS `employees_t1`
	INNER JOIN `reports` AS `reports_t1`
		ON `reports_t1`.`employee_id` = `employees_t1`.`id`
ORDER BY
	`reports_t1`.`employee_id` ASC,
	`reports_t1`.`open_date` ASC,
    `reports_t1`.`id` ASC
LIMIT 
	10000;


-- -----------------------------------------------------------------------------------------------
-- 8.	Most reported Category
-- -----------------------------------------------------------------------------------------------
SELECT
	`categories_t1`.`name` AS `category_name`,
    COUNT(*) AS `reports_number`
FROM
	`reports` AS `reports_t1`
    LEFT JOIN `categories` AS `categories_t1`
		ON `reports_t1`.`category_id` = `categories_t1`.`id`
GROUP BY
	`reports_t1`.`category_id`
ORDER BY
	`reports_number` ASC,
	`categories_t1`.`name` ASC
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 9.	Employees in Category
-- -----------------------------------------------------------------------------------------------
SELECT
	`categories_t1`.`name` AS `category_name`,
    COUNT(*) AS `employees_number`
FROM
	`categories` AS `categories_t1`
    INNER JOIN `departments` AS `departments_t1`
		ON `categories_t1`.`department_id` = `departments_t1`.`id`
    INNER JOIN `employees` AS `employees_t1`
		ON `employees_t1`.`department_id` = `departments_t1`.`id`	
GROUP BY
 	`categories_t1`.`id`
ORDER BY
	`categories_t1`.`name` ASC
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 10.	Birthday Report
-- -----------------------------------------------------------------------------------------------
SELECT
	`categories_t1`.`name` AS `category_name`
FROM
	`users` AS `users_t1`
    INNER JOIN `reports` AS `reports_t1`
		ON `reports_t1`.`user_id` = `users_t1`.`id`     
	INNER JOIN `categories` AS `categories_t1`
		ON `reports_t1`.`category_id` = `categories_t1`.`id`
WHERE
	DAY(`reports_t1`.`open_date`) = DAY(`users_t1`.`birthdate`) AND MONTH(`reports_t1`.`open_date`) = MONTH(`users_t1`.`birthdate`)
GROUP BY
	`categories_t1`.`id`
ORDER BY
	`categories_t1`.`name` ASC
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 11.	Users per Employee 
-- -----------------------------------------------------------------------------------------------
SELECT
	CONCAT(`employees_t1`.`first_name`, ' ', `employees_t1`.`last_name`) AS `name`,
    COUNT(DISTINCT `reports_t1`.`user_id`) AS `users_count`
FROM
	`employees` AS `employees_t1`
    LEFT JOIN `reports` AS `reports_t1`
		ON `reports_t1`.`employee_id` = `employees_t1`.`id`     
GROUP BY
	`employees_t1`.`id`
ORDER BY
	`users_count` DESC,
	`name` ASC 
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 12.	Emergency Patrol
-- -----------------------------------------------------------------------------------------------
SELECT
	`reports_t1`.`open_date` AS `open_date`,
    `reports_t1`.`description` AS `description`,
    `users_t1`.`email` AS `reporter_email`
FROM
	`reports` AS `reports_t1`
    INNER JOIN `users` AS `users_t1`
		ON `reports_t1`.`user_id` = `users_t1`.`id`
	INNER JOIN `categories` AS `categories_t1`
		ON `reports_t1`.`category_id` = `categories_t1`.`id`
	INNER JOIN `departments` AS `departments_t1`
		ON `categories_t1`.`department_id` = `departments_t1`.`id`
WHERE
	`reports_t1`.`close_date` IS NULL
    AND character_length(`reports_t1`.`description`) > 20 AND `reports_t1`.`description` LIKE '%str%'
    AND `departments_t1`.`name` IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
ORDER BY
	`reports_t1`.`open_date` ASC,
	`users_t1`.`email` ASC,
    `users_t1`.`id` ASC
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 13.	Numbers Coincidence
-- -----------------------------------------------------------------------------------------------
SELECT
	DISTINCT `users_t1`.`username` AS `username`
FROM
	`users` AS `users_t1`
	INNER JOIN `reports` AS `reports_t1`
		ON `reports_t1`.`user_id` = `users_t1`.`id`
WHERE
-- 	`users_t1`.`username` LIKE CONCAT(`reports_t1`.`category_id`, '%')
--     OR `users_t1`.`username` LIKE CONCAT('%', `reports_t1`.`category_id`)
	CAST(`reports_t1`.`category_id` as char(50)) = LEFT(`users_t1`.`username`, 1) OR
	CAST(`reports_t1`.`category_id` as char(50)) = RIGHT(`users_t1`.`username`, 1)
ORDER BY
	`users_t1`.`username` ASC
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 14.	Open/Closed Statistics
-- -----------------------------------------------------------------------------------------------
SELECT
	`t1`.`name` AS `name`,
    CONCAT(`t1`.`count_close`, '/', `t1`.`count_open`) AS `closed_open_reports`
FROM

	(
    SELECT
		CONCAT(`employees_t1`.`first_name`, ' ', `employees_t1`.`last_name`) AS `name`,
		SUM(IF(`reports_t1`.`close_date` >= '2016-01-01' AND `reports_t1`.`close_date` < '2017-01-01', 1, 0)) AS `count_close`,
		SUM(IF(`reports_t1`.`open_date` >= '2016-01-01' AND `reports_t1`.`open_date` < '2017-01-01', 1, 0)) AS `count_open`
	FROM 
		`employees` AS `employees_t1`
		INNER JOIN `reports` AS `reports_t1`
			ON `reports_t1`.`employee_id` = `employees_t1`.`id`
	GROUP BY
		`reports_t1`.`employee_id`
	HAVING
		`count_close` > 0 OR `count_open` > 0
	ORDER BY
		`name` ASC
	LIMIT 
		10000
	) AS `t1`
   
LIMIT 10000;

-- -----------------------------------------------------------------------------------------------
-- 15.	Average Closing Time
-- -----------------------------------------------------------------------------------------------
SELECT
	`departments_t1`.`name` AS `department_name`,
    IFNULL(TRUNCATE(AVG(DATEDIFF(`reports_t1`.`close_date`, `reports_t1`.`open_date`)), 0), 'no info') AS `average_duration`
FROM
	`departments` AS `departments_t1`
    
    INNER JOIN `categories` AS `categories_t1`
		ON `departments_t1`.`id` = `categories_t1`.`department_id`
        
    INNER JOIN `reports` AS `reports_t1`
		ON `categories_t1`.`id` = `reports_t1`.`category_id`
GROUP BY
	`departments_t1`.`id`
        
ORDER BY
   `departments_t1`.`name`
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 15.	Average Closing Time
-- -----------------------------------------------------------------------------------------------
SELECT
	`departments_t1`.`name` AS `department_name`,
    IFNULL(TRUNCATE(AVG(DATEDIFF(`reports_t1`.`close_date`, `reports_t1`.`open_date`)), 0), 'no info') AS `average_duration`
FROM
	`departments` AS `departments_t1`
    
    INNER JOIN `categories` AS `categories_t1`
		ON `departments_t1`.`id` = `categories_t1`.`department_id`
        
    INNER JOIN `reports` AS `reports_t1`
		ON `categories_t1`.`id` = `reports_t1`.`category_id`
GROUP BY
	`departments_t1`.`id`
        
ORDER BY
   `departments_t1`.`name`
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- 16.	Most Reported Category
-- -----------------------------------------------------------------------------------------------
SELECT
	`category_total`.`department_name` AS `department_name`,
    `category_total`.`category_name` AS `category_name`,
    ROUND((`category_total`.`value` * 100 / `department_total`.`value`), 0) AS `percentage`


FROM
	(
	SELECT
		`departments_t1`.`name` AS `department_name`,
		`categories_t1`.`name` AS `category_name`,
		COUNT(*) AS `value`
	FROM
		`departments` AS `departments_t1`
		
		INNER JOIN `categories` AS `categories_t1`
			ON `departments_t1`.`id` = `categories_t1`.`department_id`
			
		INNER JOIN `reports` AS `reports_t1`
			ON `categories_t1`.`id` = `reports_t1`.`category_id`

	GROUP BY
		`departments_t1`.`name`,
		`categories_t1`.`name`

	LIMIT 
		10000
	) AS `category_total`
    
    INNER JOIN
    
    (
	SELECT
		`departments_t1`.`name` AS `department_name`,
		COUNT(*) AS `value`
	FROM
		`departments` AS `departments_t1`
		
		INNER JOIN `categories` AS `categories_t1`
			ON `departments_t1`.`id` = `categories_t1`.`department_id`
			
		INNER JOIN `reports` AS `reports_t1`
			ON `categories_t1`.`id` = `reports_t1`.`category_id`

	GROUP BY
		`departments_t1`.`name`

	LIMIT 
		10000
	) `department_total`
    
    ON `category_total`.`department_name` = `department_total`.`department_name`

ORDER BY
	`category_total`.`department_name` ASC,
    `category_total`.`category_name` ASC,
    `percentage` ASC
LIMIT 
	10000;

-- -----------------------------------------------------------------------------------------------
-- Section 4. Programmability (20 pts)
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 17.	Get Reports
-- -----------------------------------------------------------------------------------------------
USE `report service`;
DROP FUNCTION IF EXISTS `udf_get_reports_count`;

DELIMITER $$
USE `report service`$$
CREATE FUNCTION `udf_get_reports_count` 
(
	employee_id INT,
    status_id INT
)
RETURNS INT(11) 
BEGIN
	DECLARE ret INT(11) DEFAULT NULL;
    
    SET ret := 
		(
        
		SELECT
			COUNT(*) AS `employee_report_status`
		FROM
			`reports` AS `reports_t1`
		WHERE
			`reports_t1`.`employee_id` = employee_id
			AND `reports_t1`.`status_id` = status_id
		GROUP BY
			`reports_t1`.`employee_id`
		LIMIT 
			1);
	
    SET ret := IFNULL(ret, 0);
    
    RETURN ret;
    
END$$

DELIMITER ;

SELECT id, first_name, last_name, udf_get_reports_count(id, 2) AS reports_count
FROM employees AS e
ORDER BY e.id;

-- -----------------------------------------------------------------------------------------------
-- 18.	Assign Employee
-- -----------------------------------------------------------------------------------------------
USE `report service`;
DROP PROCEDURE IF EXISTS `usp_assign_employee_to_report`;

DELIMITER $$
USE `report service`$$
CREATE PROCEDURE `usp_assign_employee_to_report` 
(
	employee_id INT, 
    report_id INT
)
BEGIN
    DECLARE employee_department INT(11) UNSIGNED DEFAULT NULL;
	DECLARE report_department INT(11) UNSIGNED DEFAULT NULL;
	
	SET employee_department := 
		(
		SELECT
			`employees_t1`.`department_id`
        FROM
			`employees` AS `employees_t1`
		WHERE
			`employees_t1`.`id` = employee_id
        LIMIT
			1
		);
        
    SET report_department := 
		(
		SELECT
			`categories_t1`.`department_id`
        FROM
			`reports` AS `reports_t1`
            INNER JOIN `categories` AS `categories_t1`
            ON `reports_t1`.`category_id` = `categories_t1`.`id`
		WHERE
			`reports_t1`.`id` = report_id
        LIMIT
			1
		);

    START TRANSACTION;
    
	IF employee_department != report_department
		OR employee_department IS NULL
		OR report_department IS NULL
    THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Employee doesn\'t belong to the appropriate department!';
            
		ROLLBACK;
	
    ELSE
    	UPDATE
			`reports` AS `reports_t1`
		SET 
			`reports_t1`.`employee_id` = employee_id
		WHERE
			`reports_t1`.`id` = report_id
		LIMIT
			1000;
           
    END IF;
    
END$$

DELIMITER ;

CALL usp_assign_employee_to_report(30, 1);
SELECT employee_id FROM reports WHERE id = 2;

CALL usp_assign_employee_to_report(17, 2);
SELECT employee_id FROM reports WHERE id = 2;

-- -----------------------------------------------------------------------------------------------
-- 19.	Close Reports
-- -----------------------------------------------------------------------------------------------
USE `report service`;
DROP TRIGGER IF EXISTS `reports_close_date_AFTER_UPDATE`;

DELIMITER $$
USE `report service`$$
CREATE TRIGGER `reports_close_date_AFTER_UPDATE` BEFORE UPDATE ON `reports` FOR EACH ROW
BEGIN
	DECLARE status_id_completed INT(11) UNSIGNED DEFAULT NULL;
    
    SET status_id_completed :=
		(
        SELECT
			`status_t1`.`id`
		FROM
			`status` AS `status_t1`
		WHERE
			`status_t1`.`label` = 'completed'
		LIMIT
			1
		);

	IF `NEW`.`status_id` != status_id_completed
		AND `NEW`.`close_date` IS NOT NULL
        AND status_id_completed IS NOT NULL
	THEN
    	SET `NEW`.`status_id` := status_id_completed;
           
    END IF;

END
$$
DELIMITER ;

UPDATE reports
SET close_date = now()
WHERE employee_id = 8;

-- -----------------------------------------------------------------------------------------------
-- Section 5. Bonus (10 pts)
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 20.	Categories Revision
-- -----------------------------------------------------------------------------------------------
SELECT
    `categories_t1`.`name` AS `category_name`,
    IFNULL(`reports_waiting`.`reports_number`, 0) + IFNULL(`reports_inprogress`.`reports_number`, 0) AS `reports_number`,
	CASE 
		WHEN IFNULL(`reports_waiting`.`reports_number`, 0) > IFNULL(`reports_inprogress`.`reports_number`, 0) THEN 'waiting'
		WHEN IFNULL(`reports_waiting`.`reports_number`, 0) < IFNULL(`reports_inprogress`.`reports_number`, 0) THEN 'in progress'
        ELSE 'equal'
	END AS `main_status`
FROM
	`categories` AS `categories_t1`


    LEFT JOIN 
		(
		SELECT
			`categories_t1`.`id` AS `category_id`,
			COUNT(*) AS `reports_number`
		FROM
			`categories` AS `categories_t1`

			INNER JOIN `reports` AS `reports_t1`
				ON `categories_t1`.`id` = `reports_t1`.`category_id`
				
			INNER JOIN `status` AS `status_t1`
				ON `reports_t1`.`status_id` = `status_t1`.`id`
				
		WHERE
			`status_t1`.`label` IN ('waiting') 
		GROUP BY
			`categories_t1`.`id`
		LIMIT
			1000
        ) AS `reports_waiting`
		
        
        ON `categories_t1`.`id` = `reports_waiting`.`category_id`
        
        
    LEFT JOIN
		(
		SELECT
			`categories_t1`.`id` AS `category_id`,
			COUNT(*) AS `reports_number`
		FROM
			`categories` AS `categories_t1`

			INNER JOIN `reports` AS `reports_t1`
				ON `categories_t1`.`id` = `reports_t1`.`category_id`
				
			INNER JOIN `status` AS `status_t1`
				ON `reports_t1`.`status_id` = `status_t1`.`id`
				
		WHERE
			`status_t1`.`label` IN ('in progress') 
		GROUP BY
			`categories_t1`.`id`
		LIMIT
			1000
		) AS `reports_inprogress`
        
        
		ON `categories_t1`.`id` = `reports_inprogress`.`category_id`
        
WHERE
	`reports_waiting`.`reports_number` > 0
	OR `reports_inprogress`.`reports_number` > 0
ORDER BY
	`categories_t1`.`name`
LIMIT
	1000;







SELECT
    `categories_t1`.`id` AS `category_id`,
    COUNT(*) AS `reports_number`
FROM
	`categories` AS `categories_t1`

    INNER JOIN `reports` AS `reports_t1`
		ON `categories_t1`.`id` = `reports_t1`.`category_id`
        
    INNER JOIN `status` AS `status_t1`
		ON `reports_t1`.`status_id` = `status_t1`.`id`
        
WHERE
    `status_t1`.`label` IN ('waiting') 
GROUP BY
	`categories_t1`.`id`
LIMIT
	1000;

SELECT
    `categories_t1`.`id` AS `category_id`,
    COUNT(*) AS `reports_number`
FROM
	`categories` AS `categories_t1`

    INNER JOIN `reports` AS `reports_t1`
		ON `categories_t1`.`id` = `reports_t1`.`category_id`
        
    INNER JOIN `status` AS `status_t1`
		ON `reports_t1`.`status_id` = `status_t1`.`id`
        
WHERE
    `status_t1`.`label` IN ('in progress') 
GROUP BY
	`categories_t1`.`id`
LIMIT
	1000;
