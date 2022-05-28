-- -----------------------------------------------------------------------------------------------
-- Databases MySQL Exam - 24 Jun 2017
-- -----------------------------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `closed_judge_system`;
CREATE SCHEMA `closed_judge_system`;
USE `closed_judge_system`;
-- -----------------------------------------------------------------------------------------------
-- CJS
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- Data Definition Language (DDL) – 40 pts
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 01.	Table Design
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `users`
(
	`id` INT(11) AUTO_INCREMENT,
    `username` VARCHAR(30) NOT NULL,
    `password` VARCHAR(30) NOT NULL,
    `email` VARCHAR(50),
    CONSTRAINT `pk_users` PRIMARY KEY (`id`),
    CONSTRAINT `unique_users_username` UNIQUE (`username`)
);

CREATE TABLE `categories`
(
	`id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL,
	`parent_id` INT(11),
    CONSTRAINT `pk_categories` PRIMARY KEY (`id`)
);

CREATE TABLE `contests`
(
	`id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL,
	`category_id` INT(11),
    CONSTRAINT `pk_contests` PRIMARY KEY (`id`)
);

CREATE TABLE `problems`
(
	`id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(100) NOT NULL,
    `points` INT(11) NOT NULL,
    `tests` INT(11) DEFAULT 0,
	`contest_id` INT(11),
    CONSTRAINT `pk_problems` PRIMARY KEY (`id`)
);

CREATE TABLE `submissions`
(
	`id` INT(11) AUTO_INCREMENT,
    `passed_tests` INT(11) NOT NULL,
    `problem_id` INT(11),
	`user_id` INT(11),
    CONSTRAINT `pk_submissions` PRIMARY KEY (`id`)
);

CREATE TABLE `users_contests`
(
	`user_id` INT(11),
	`contest_id` INT(11),
    CONSTRAINT `pk_users_contests` PRIMARY KEY (`user_id`, `contest_id`)
);

ALTER TABLE `categories`
	ADD CONSTRAINT `fk_category_parent` 
		FOREIGN KEY (`parent_id`)
		REFERENCES `categories`(`id`);

ALTER TABLE `contests`
	ADD CONSTRAINT `fk_contest_category` 
		FOREIGN KEY (`category_id`)
		REFERENCES `categories`(`id`);

ALTER TABLE `problems`
	ADD CONSTRAINT `fk_problem_contest` 
		FOREIGN KEY (`contest_id`)
		REFERENCES `contests`(`id`);

ALTER TABLE `submissions`
	ADD CONSTRAINT `fk_submission_problem` 
		FOREIGN KEY (`problem_id`)
		REFERENCES `problems`(`id`);

ALTER TABLE `submissions`
	ADD CONSTRAINT `fk_submission_user` 
		FOREIGN KEY (`user_id`)
		REFERENCES `users`(`id`);

ALTER TABLE `users_contests`
	ADD CONSTRAINT `fk_users_contests_user` 
		FOREIGN KEY (`user_id`)
		REFERENCES `users`(`id`);
        -- ON UPDATE CASCADE
        -- ON DELETE CASCADE;

ALTER TABLE `users_contests`
	ADD CONSTRAINT `fk_users_contests_contest` 
		FOREIGN KEY (`contest_id`)
		REFERENCES `contests`(`id`);
        -- ON UPDATE CASCADE
        -- ON DELETE CASCADE;

-- -----------------------------------------------------------------------------------------------
-- Section 2: Data Manipulation Language (DML) – 30 pts
-- -----------------------------------------------------------------------------------------------
INSERT INTO `submissions`
	(`passed_tests`, `problem_id`, `user_id`)
SELECT 
	CEILING(SQRT(POWER(CHAR_LENGTH(`problems_t1`.`name`), 3))) - CHAR_LENGTH(`problems_t1`.`name`) AS `passed_tests`,
	`problems_t1`.`id` AS `problem_id`,
	CEILING(`problems_t1`.`id` * 3 / 2) AS `user_id`
FROM
	`problems` AS `problems_t1`
WHERE
	`problems_t1`.`id` >= 1
	AND `problems_t1`.`id` <= 10
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 03.	Data Update
-- -----------------------------------------------------------------------------------------------
UPDATE
	`problems` AS `problems_t1`
SET
	`problems_t1`.`tests` = 
    
		CASE MOD(`problems_t1`.`id`,3)
			
            WHEN 0 THEN

				(SELECT 
					CHAR_LENGTH(`categories_t2`.`name`) AS `name`
				FROM
					`contests` AS `contests_t2`
					
					INNER JOIN `categories` AS `categories_t2`
						ON `contests_t2`.`category_id` = `categories_t2`.`id`
						
				WHERE
					`contests_t2`.`id` = `problems_t1`.`contest_id`
				LIMIT
					10000)
			

			WHEN 1 THEN
			
				(SELECT 
					SUM(`submissions_t2`.`id`) AS `name`
				FROM
					`submissions` AS `submissions_t2`
					
				WHERE
					`submissions_t2`.`problem_id` = `problems_t1`.`id`
				GROUP BY
					`submissions_t2`.`problem_id`
				LIMIT
					10000)
		
			WHEN 2 THEN
				
				(SELECT 
					CHAR_LENGTH(`contests_t2`.`name`) AS `name`
				FROM
					`contests` AS `contests_t2`
						
				WHERE
					`contests_t2`.`id` = `problems_t1`.`contest_id`
				LIMIT
					10000)        
			
		END
    
WHERE
	`problems_t1`.`tests` = 0
LIMIT
	10000;

/*
SELECT

	CASE MOD(`problems_t1`.`id`,3)
		WHEN 0 THEN

		(SELECT 
			CHAR_LENGTH(`categories_t2`.`name`) AS `name`
		FROM
			`contests` AS `contests_t2`
			
			INNER JOIN `categories` AS `categories_t2`
				ON `contests_t2`.`category_id` = `categories_t2`.`id`
				
		WHERE
			`contests_t2`.`id` = `problems_t1`.`contest_id`
		LIMIT
			10000)
        

	WHEN 1 THEN
    
		(SELECT 
			SUM(`submissions_t2`.`id`) AS `name`
		FROM
			`submissions` AS `submissions_t2`
			
		WHERE
			`submissions_t2`.`problem_id` = `problems_t1`.`id`
		GROUP BY
			`submissions_t2`.`problem_id`
		LIMIT
			10000)
	
    WHEN 2 THEN
        
		(SELECT 
			CHAR_LENGTH(`contests_t2`.`name`) AS `name`
		FROM
			`contests` AS `contests_t2`
				
		WHERE
			`contests_t2`.`id` = `problems_t1`.`contest_id`
		LIMIT
			10000)        
		
	END AS `set_value`

FROM
	`problems` AS `problems_t1`
WHERE
	`problems_t1`.`tests` = 0
LIMIT
	10000;
*/

-- -----------------------------------------------------------------------------------------------
-- 04.	Date Deletion
-- -----------------------------------------------------------------------------------------------
DELETE
FROM
	`users`
WHERE
    (SELECT
		`users_contests`.`contest_id`
	FROM
		`users_contests`
	WHERE
		`users_contests`.`user_id` = `users`.`id`
	LIMIT 1)
    
		IS NULL
        
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- Section 3: Querying – 100 pts
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 05.	Users
-- -----------------------------------------------------------------------------------------------
SELECT 
	`users_t1`.`id` AS `id`,
    `users_t1`.`username` AS `username`,
    `users_t1`.`email` AS `email`
FROM
	`users` AS `users_t1`
ORDER BY
	`users_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 06.	Root Categories
-- -----------------------------------------------------------------------------------------------
SELECT 
	`categories_t1`.`id` AS `id`,
    `categories_t1`.`name` AS `name`
FROM
	`categories` AS `categories_t1`
WHERE
	`categories_t1`.`parent_id` IS NULL
ORDER BY
	`categories_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 07.	Well Tested Problems
-- -----------------------------------------------------------------------------------------------
SELECT 
	`problems_t1`.`id` AS `id`,
    `problems_t1`.`name` AS `name`,
    `problems_t1`.`tests` AS `tests`
FROM
	`problems` AS `problems_t1`
WHERE
	`problems_t1`.`tests` > `problems_t1`.`points`
    AND TRIM(`problems_t1`.`name`) LIKE '% %'
ORDER BY
	`problems_t1`.`id` DESC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 08.	Full Path Problems
-- -----------------------------------------------------------------------------------------------
SELECT 
	`problems_t1`.`id` AS `id`,
    CONCAT(`categories_t1`.`name`, ' - ', `contests_t1`.`name`, ' - ', `problems_t1`.`name`) AS `name`
FROM
	`problems` AS `problems_t1`
    
    LEFT JOIN `contests` AS `contests_t1`
		ON `problems_t1`.`contest_id` = `contests_t1`.`id`
	
	LEFT JOIN `categories` AS `categories_t1`
		ON `contests_t1`.`category_id` = `categories_t1`.`id`
    
ORDER BY
	`problems_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 09.	Leaf Categories
-- -----------------------------------------------------------------------------------------------
SELECT 
	`categories_t1`.`id` AS `id`,
    `categories_t1`.`name` AS `name`
FROM
	`categories` AS `categories_t1`
    
    LEFT JOIN `categories` AS `categories_t2`
		ON `categories_t1`.`id` = `categories_t2`.`parent_id`
WHERE
	`categories_t2`.`parent_id` IS NULL
-- HAVING
-- 	`categories_t2`.`parent_id` IS NULL
ORDER BY
	`categories_t1`.`name` ASC,
	`categories_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 10.	Mainstream Passwords
-- -----------------------------------------------------------------------------------------------
SELECT -- DISTINCT
	`users_t1`.`id` AS `id`,
    `users_t1`.`username` AS `username`,
    `users_t1`.`password` AS `password`
FROM
	`users` AS `users_t1`

	INNER JOIN `users` AS `users_t2`
		ON `users_t1`.`password` = `users_t2`.`password`
		AND `users_t1`.`id` != `users_t2`.`id`
GROUP BY
	`users_t1`.`id`
ORDER BY
	`users_t1`.`username` ASC,
	`users_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 11.	Most Participated Contests
-- -----------------------------------------------------------------------------------------------
SELECT
	`contests_t2`.`id` AS `id`,
	`contests_t2`.`name` AS `name`,
	`contests_t2`.`contestants_count` AS `contestants`
FROM
	(
		SELECT
			`contests_t1`.`id` AS `id`,
			`contests_t1`.`name` AS `name`,
			COUNT(`users_contests_t1`.`user_id`) AS `contestants_count`
		FROM
			`contests` AS `contests_t1`

			LEFT JOIN `users_contests` AS `users_contests_t1`
				ON `contests_t1`.`id` = `users_contests_t1`.`contest_id`

		GROUP BY
			`contests_t1`.`id`
		ORDER BY
			`contestants_count` DESC,
            `contests_t1`.`id` ASC
		LIMIT
			5
    ) AS `contests_t2`
ORDER BY
	`contests_t2`.`contestants_count` ASC,
	`contests_t2`.`id` ASC
LIMIT
	5;

-- -----------------------------------------------------------------------------------------------
-- 12.	Most Valuable Person
-- -----------------------------------------------------------------------------------------------
SELECT
	`submissions_t1`.`id` AS `id`,
    `users_t1`.`username` AS `username`,
    `problems_t1`.`name` AS `name`,
    CONCAT(`submissions_t1`.`passed_tests`, ' / ', `problems_t1`.`tests`) AS `result`
FROM
	(
		-- User with max contests
		SELECT
			`users_contests_t2`.`user_id` AS `max_contests_user_id`,
			COUNT(`users_contests_t2`.`contest_id`) AS `max_contests_count`
		FROM
			`users_contests` AS `users_contests_t2`
		GROUP BY
			`users_contests_t2`.`user_id`
		ORDER BY
			`max_contests_count` DESC
		LIMIT
			1
    ) AS `max_contests`
	
	INNER JOIN `submissions` AS `submissions_t1`
		ON `max_contests`.`max_contests_user_id` = `submissions_t1`.`user_id`

	INNER JOIN `users` AS `users_t1`
		ON `submissions_t1`.`user_id` = `users_t1`.`id`

	INNER JOIN `problems` AS `problems_t1`
		ON `submissions_t1`.`problem_id` = `problems_t1`.`id`
        
ORDER BY
	`submissions_t1`.`id` DESC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 13.	Contests Maximum Points
-- -----------------------------------------------------------------------------------------------
SELECT
	`contests_t1`.`id` AS `id`,
    `contests_t1`.`name` AS `name`,
    SUM(`problems_t1`.`points`) `maximum_points`
FROM
	`contests` AS `contests_t1`
    
    LEFT JOIN `problems` AS `problems_t1`
		ON `contests_t1`.`id` = `problems_t1`.`contest_id`

WHERE
	`problems_t1`.`points` IS NOT NULL
GROUP BY
	`contests_t1`.`id`
ORDER BY
	`maximum_points` DESC,
    `contests_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 14.	Contestants’ Submissions
-- -----------------------------------------------------------------------------------------------
SELECT
	`contests_t1`.`id` AS `id`,
    `contests_t1`.`name` AS `name`,
    COUNT(`submissions_t1`.`id`) AS `submissions`
FROM
	`contests` AS `contests_t1`
    
    LEFT JOIN `problems` AS `problems_t1`
		ON `contests_t1`.`id` = `problems_t1`.`contest_id`
        
	LEFT JOIN `submissions` AS `submissions_t1`
		ON `problems_t1`.`id` = `submissions_t1`.`problem_id`
        
	INNER JOIN `users_contests` AS `users_contests_t1`
		ON `contests_t1`.`id` = `users_contests_t1`.`contest_id`
        AND `submissions_t1`.`user_id` = `users_contests_t1`.`user_id`
        
GROUP BY
	`contests_t1`.`id`
ORDER BY
	`submissions` DESC,
    `contests_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- Section 4: Programmability – 30 pts
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 15.	Login
-- -----------------------------------------------------------------------------------------------
USE `closed_judge_system`;
DROP PROCEDURE IF EXISTS `udp_login`;

DELIMITER $$
USE `closed_judge_system`$$
CREATE PROCEDURE `udp_login` 
(
	in_username VARCHAR(30), 
    in_password VARCHAR(30)
)
BEGIN

	IF (SELECT `username` FROM `users` WHERE `username` = in_username) IS NULL
	THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Username does not exist!';
            
	ELSEIF (SELECT `password` FROM `users` WHERE `username` = in_username) != in_password
	THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Password is incorrect!';
    
	ELSEIF (SELECT `username` FROM `logged_in_users` WHERE `username` = in_username) IS NOT NULL
	THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'User is already logged in!';
	
    ELSE
		INSERT INTO `logged_in_users`
			(`id`, `username`, `password`, `email`)
		SELECT 
			`id`, `username`, `password`, `email`
		FROM
			`users`
		WHERE
			`users`.`username` = in_username
		LIMIT
			1;
    END IF;
    
END$$

DELIMITER ;

CALL udp_login('doge', 'doge');
SELECT * FROM logged_in_users;

-- -----------------------------------------------------------------------------------------------
-- 16.	Evaluate Submission
-- -----------------------------------------------------------------------------------------------
USE `closed_judge_system`;
DROP PROCEDURE IF EXISTS `udp_evaluate`;

DELIMITER $$
USE `closed_judge_system`$$
CREATE PROCEDURE `udp_evaluate` 
(
	in_id INT(11)
)
BEGIN

	IF (SELECT `problem_id` FROM `submissions` WHERE `id` = in_id) IS NULL
	THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Submission does not exist!';
            
    ELSE
		INSERT INTO `evaluated_submissions`
			(`id`, `problem`, `user`, `result`)
		SELECT 
			`submissions_t1`.`id`,
			`problems_t1`.`name`,
            `users_t1`.`username`,
			FLOOR(`problems_t1`.`points` / `problems_t1`.`tests` * `submissions_t1`.`passed_tests`)
		FROM 
			`submissions` AS `submissions_t1`
            
			INNER JOIN `problems` AS `problems_t1`
				ON `submissions_t1`.`problem_id` = `problems_t1`.`id`
			
			INNER JOIN `users` AS `users_t1`
				ON `submissions_t1`.`user_id` = `users_t1`.`id`
                
		WHERE 
			`submissions_t1`.`id` = in_id
		LIMIT
			1;
            
    END IF;
    
END$$

DELIMITER ;

CALL udp_evaluate(1);
SELECT * FROM evaluated_submissions;

-- -----------------------------------------------------------------------------------------------
-- Section 5: Bonus – 20 pts
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 17.	Check Constraint
-- -----------------------------------------------------------------------------------------------
USE `closed_judge_system`;
DROP TRIGGER IF EXISTS `reports_close_date_AFTER_UPDATE`;

DELIMITER $$
USE `closed_judge_system`$$
CREATE TRIGGER `problems_AFTER_INSERT` BEFORE INSERT ON `problems` FOR EACH ROW
BEGIN

	IF `NEW`.`name` NOT LIKE '% %' 
	THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'The given name is invalid!';
            
	ELSEIF `NEW`.`points` <= 0
	THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'The problem’s points cannot be less or equal to 0!';
    
	ELSEIF `NEW`.`tests` <= 0
	THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'The problem’s tests cannot be less or equal to 0!';
	
    END IF;

END
$$
DELIMITER ;


















