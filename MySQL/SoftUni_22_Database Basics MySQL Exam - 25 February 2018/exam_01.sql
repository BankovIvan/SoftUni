-- -----------------------------------------------------------------------------------------------
-- Database Basics MySQL Exam - 25 February 2018
-- -----------------------------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `Buhtig`;
CREATE SCHEMA `Buhtig`;
USE `Buhtig`;
-- -----------------------------------------------------------------------------------------------
-- Section 1: Data Definition Language (DDL) – 40 pts
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 01.	Table Design
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `users`
(
	`id` INT(11) AUTO_INCREMENT,
    `username` VARCHAR(30) NOT NULL,
    `password` VARCHAR(30) NOT NULL,
    `email` VARCHAR(50) NOT NULL,
    CONSTRAINT `pk_users` PRIMARY KEY (`id`),
    CONSTRAINT `uk_users_username` UNIQUE (`username`)
);

CREATE TABLE `repositories`
(
	`id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL,
    CONSTRAINT `pk_repositories` PRIMARY KEY (`id`)
);

CREATE TABLE `repositories_contributors`
(
	`repository_id` INT(11),
    `contributor_id` INT(11),
    CONSTRAINT `fk_repositories_contributors_repository_id` 
		FOREIGN KEY (`repository_id`)
        REFERENCES `repositories`(`id`),
	CONSTRAINT `fk_repositories_contributors_contributor_id` 
		FOREIGN KEY (`contributor_id`)
        REFERENCES `users`(`id`)
);

CREATE TABLE `issues`
(
	`id` INT(11) AUTO_INCREMENT,
    `title` VARCHAR(255) NOT NULL,
    `issue_status` VARCHAR(6) NOT NULL,
	`repository_id` INT(11) NOT NULL,
    `assignee_id` INT(11) NOT NULL,
    CONSTRAINT `pk_issues` PRIMARY KEY (`id`),
    CONSTRAINT `fk_issues_repository_id` 
		FOREIGN KEY (`repository_id`)
        REFERENCES `repositories`(`id`),
	CONSTRAINT `fk_issues_assignee_id` 
		FOREIGN KEY (`assignee_id`)
        REFERENCES `users`(`id`)
);

CREATE TABLE `commits`
(
	`id` INT(11) AUTO_INCREMENT,
    `message` VARCHAR(255) NOT NULL,
    `issue_id` INT(11),
	`repository_id` INT(11) NOT NULL,
    `contributor_id` INT(11) NOT NULL,
    CONSTRAINT `pk_commits` PRIMARY KEY (`id`),
    CONSTRAINT `fk_commits_issue_id` 
		FOREIGN KEY (`issue_id`)
        REFERENCES `issues`(`id`),
	CONSTRAINT `fk_commits_repository_id` 
		FOREIGN KEY (`repository_id`)
        REFERENCES `repositories`(`id`),
	CONSTRAINT `fk_commits_contributor_id` 
		FOREIGN KEY (`contributor_id`)
        REFERENCES `users`(`id`)
);

CREATE TABLE `files`
(
	`id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(100) NOT NULL,
    `size` DECIMAL(10,2) NOT NULL,
	`parent_id` INT(11),
    `commit_id` INT(11) NOT NULL,
    CONSTRAINT `pk_files` PRIMARY KEY (`id`),
    CONSTRAINT `fk_files_parent_id` 
		FOREIGN KEY (`parent_id`)
        REFERENCES `files`(`id`),
	CONSTRAINT `fk_files_commit_id` 
		FOREIGN KEY (`commit_id`)
        REFERENCES `commits`(`id`)
);

/*
ALTER TABLE `repositories_contributors`
	ADD CONSTRAINT `fk_repositories_contributors_repository_id` 
		FOREIGN KEY (`repository_id`)
        REFERENCES `repositories`(`id`),
	ADD CONSTRAINT `fk_repositories_contributors_contributor_id` 
		FOREIGN KEY (`contributor_id`)
        REFERENCES `users`(`id`);

ALTER TABLE `issues`
	ADD CONSTRAINT `fk_issues_repository_id` 
		FOREIGN KEY (`repository_id`)
        REFERENCES `repositories`(`id`),
	ADD CONSTRAINT `fk_issues_assignee_id` 
		FOREIGN KEY (`assignee_id`)
        REFERENCES `users`(`id`);

ALTER TABLE `commits`
	ADD CONSTRAINT `fk_commits_issue_id` 
		FOREIGN KEY (`issue_id`)
        REFERENCES `issues`(`id`),
	ADD CONSTRAINT `fk_commits_repository_id` 
		FOREIGN KEY (`repository_id`)
        REFERENCES `repositories`(`id`),
	ADD CONSTRAINT `fk_commits_contributor_id` 
		FOREIGN KEY (`contributor_id`)
        REFERENCES `users`(`id`);

ALTER TABLE `files`
	ADD CONSTRAINT `fk_files_parent_id` 
		FOREIGN KEY (`parent_id`)
        REFERENCES `files`(`id`),
	ADD CONSTRAINT `fk_files_commit_id` 
		FOREIGN KEY (`commit_id`)
        REFERENCES `commits`(`id`);
*/

-- -----------------------------------------------------------------------------------------------
-- Section 2: Data Manipulation Language (DML) – 30 pts
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 02.	Data Insertion
-- -----------------------------------------------------------------------------------------------
INSERT INTO `issues`
	(`title`, `issue_status`, `repository_id`, `assignee_id`)


SELECT 
	CONCAT('Critical Problem With ', `files_t1`.`name`, '!') AS `title`,
    'open' AS `issue_status`,
    CEIL((`files_t1`.`id` * 2) / 3) AS `repository_id`,
    `commits_t1`.`contributor_id` AS `assignee_id`

FROM
	`files` AS `files_t1`
    
    INNER JOIN `commits` AS `commits_t1`
    ON `files_t1`.`commit_id` = `commits_t1`.`id`
    
WHERE
	`files_t1`.`id` BETWEEN 46 AND 50
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 03.	Data Update
-- -----------------------------------------------------------------------------------------------
UPDATE
	`repositories_contributors` AS `repositories_contributors_t1`
SET
	`repositories_contributors_t1`.`contributor_id` = 6
WHERE
	`repositories_contributors_t1`.`repository_id` = `repositories_contributors_t1`.`contributor_id`
LIMIT
	10000;






SELECT
	`repositories_contributors_t1`.`contributor_id`
FROM
	`repositories_contributors` AS `repositories_contributors_t1`
WHERE
	`repositories_contributors_t1`.`repository_id` = `repositories_contributors_t1`.`contributor_id`
LIMIT
	10000;
    
 		SELECT
			`repositories_t1`.`id` AS `RepID`
		FROM
			`repositories` AS `repositories_t1`

			LEFT JOIN `commits` AS `commits_t1`
			ON `commits_t1`.`repository_id` = `repositories_t1`.`id`

		WHERE
			`commits_t1`.`repository_id` IS NULL
		ORDER BY
			`repositories_t1`.`id` ASC
		LIMIT
			1;   
    
    
	SELECT
			`commits_t1`.`repository_id`
		FROM
			`commits` AS `commits_t1`

		WHERE
			`repositories_t1`.`id` IS NULLcommits
		ORDER BY
			`users_t1`.`id` ASC
		LIMIT
			1;
    
-- -----------------------------------------------------------------------------------------------
-- 04.	Data Deletion
-- -----------------------------------------------------------------------------------------------
DELETE
FROM
	`repositories`
WHERE
    (SELECT
		`issues`.`id`
	FROM
		`issues`
	WHERE
		`issues`.`repository_id` = `repositories`.`id`
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
    `users_t1`.`username` AS `name`
FROM
	`users` AS `users_t1`
ORDER BY
	`users_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 06.	Lucky Numbers
-- -----------------------------------------------------------------------------------------------
SELECT
	`repositories_contributors_t1`.`repository_id` AS `repository_id`,
    `repositories_contributors_t1`.`contributor_id` AS `contributor_id`
FROM
	`repositories_contributors` AS `repositories_contributors_t1`
WHERE
	`repositories_contributors_t1`.`repository_id` = `repositories_contributors_t1`.`contributor_id`
ORDER BY
	`repositories_contributors_t1`.`repository_id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 07.	Heavy HTML
-- -----------------------------------------------------------------------------------------------
SELECT
	`files_t1`.`id` AS `id`,
    `files_t1`.`name` AS `name`,
    `files_t1`.`size` AS `size`
FROM
	`files` AS `files_t1`
WHERE
	`files_t1`.`size` > 1000
    AND `files_t1`.`name` LIKE '%html%'
ORDER BY
	`files_t1`.`size` DESC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 08.	Issues and Users
-- -----------------------------------------------------------------------------------------------
SELECT
	`issues_t1`.`id` AS `id`,
    CONCAT (`users_t1`.`username`, ' : ', `issues_t1`.`title`) AS `issue_assignee`
FROM
	`issues` AS `issues_t1`
    
    LEFT JOIN `users` AS `users_t1`
    ON `issues_t1`.`assignee_id` = `users_t1`.`id`

ORDER BY
	`issues_t1`.`id` DESC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 09.	Non-Directory Files
-- -----------------------------------------------------------------------------------------------
SELECT
	`files_t1`.`id` AS `id`,
    `files_t1`.`name` AS `name`,
    CONCAT(`files_t1`.`size`, 'KB') AS `size`
FROM
	`files` AS `files_t1`
    
    LEFT JOIN `files` AS `files_t2`
    ON `files_t1`.`id` = `files_t2`.`parent_id`
    
WHERE
	`files_t2`.`id` IS NULL
ORDER BY
	`files_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 10.	Active Repositories
-- -----------------------------------------------------------------------------------------------
SELECT
	`repositories_t1`.`id` AS `id`,
    `repositories_t1`.`name` AS `name`,
    COUNT(`repositories_t1`.`id`) AS `issues`
FROM
	`repositories` AS `repositories_t1`
    
    INNER JOIN `issues` AS `issues_t1`
    ON `repositories_t1`.`id` = `issues_t1`.`repository_id`
    
GROUP BY
	`repositories_t1`.`id`
ORDER BY
	`issues` DESC,
	`repositories_t1`.`id` ASC
LIMIT
	5;

-- -----------------------------------------------------------------------------------------------
-- 11.	Most Contributed Repository
-- -----------------------------------------------------------------------------------------------
SELECT
	`repositories_contributors_count`.`repositories_contributors_id` AS `id`,
    `repositories_contributors_count`.`repositories_contributors_name` AS `name`,
     `commits_count`.`commits` AS `commits`,
    `repositories_contributors_count`.`contributors` AS `contributors`
FROM

		(
			SELECT
				`repositories_t1`.`id` AS `repositories_contributors_id`,
				`repositories_t1`.`name` AS `repositories_contributors_name`,
				COUNT(`repositories_contributors_t1`.`contributor_id`) AS `contributors`
			FROM
				`repositories` AS `repositories_t1`
				
				LEFT JOIN `repositories_contributors` AS `repositories_contributors_t1`
				ON `repositories_t1`.`id` = `repositories_contributors_t1`.`repository_id`

			GROUP BY
				`repositories_t1`.`id`
			LIMIT
				10000
		) 
			AS `repositories_contributors_count`
        
	INNER JOIN
		(
			SELECT
				`repositories_t1`.`id` AS `commits_count_id`,
				COUNT(`commits_t1`.`repository_id`) AS `commits`
			FROM
				`repositories` AS `repositories_t1`
				
				LEFT JOIN `commits` AS `commits_t1`
				ON `repositories_t1`.`id` = `commits_t1`.`repository_id`

			GROUP BY
				`repositories_t1`.`id`
			LIMIT
				10000
		)
			AS `commits_count`    
    
	ON `repositories_contributors_count`.`repositories_contributors_id` = `commits_count`.`commits_count_id`
    
    
ORDER BY
	`contributors` DESC,
	`id` ASC
LIMIT
	1;

-- -----------------------------------------------------------------------------------------------
-- 12.	Fixing My Own Problems
-- -----------------------------------------------------------------------------------------------
SELECT
	`users_t1`.`id` AS `id`,
    `users_t1`.`username` AS `name`,
    COUNT(`commits_t1`.`id`) AS `commits`
FROM
	`users` AS `users_t1`
    
	LEFT JOIN `issues` AS `issues_t1`
    ON `users_t1`.`id` = `issues_t1`.`assignee_id`
    
    LEFT JOIN `commits` AS `commits_t1`
    ON `issues_t1`.`id` = `commits_t1`.`issue_id`
    AND `users_t1`.`id` = `commits_t1`.`contributor_id`

GROUP BY
	`users_t1`.`id`
ORDER BY
	`commits` DESC,
	`users_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 13.	Recursive Commits
-- -----------------------------------------------------------------------------------------------
SELECT
	SUBSTR(`files_t1`.`name`, 1, INSTR(`files_t1`.`name`, '.') - 1) AS `file`,
    COUNT(`commits_t1`.`message`) AS `recursive_count`
FROM
	`files` AS `files_t1`
    
    LEFT JOIN `files` AS `files_t2`
    ON `files_t1`.`id` = `files_t2`.`parent_id`
		AND `files_t1`.`parent_id` = `files_t2`.`id`
        AND `files_t1`.`id` <> `files_t2`.`id`
        
	LEFT JOIN `commits` AS `commits_t1`
	ON `commits_t1`.`message` LIKE CONCAT('%', `files_t1`.`name`, '%')
    
WHERE
	`files_t2`.`id` IS NOT NULL
GROUP BY
	`files_t1`.`id`
ORDER BY
	`file` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- 14.	Repositories and Commits
-- -----------------------------------------------------------------------------------------------
SELECT
	`repositories_t1`.`id` AS `id`,
    `repositories_t1`.`name` AS `name`,
    COUNT(DISTINCT `commits_t1`.`contributor_id`) AS `users`
FROM
	`repositories` AS `repositories_t1`
    
    LEFT JOIN `commits` AS `commits_t1`
    ON `repositories_t1`.`id` = `commits_t1`.`repository_id`
   
GROUP BY
 	`repositories_t1`.`id`
ORDER BY
	`users` DESC,
	`repositories_t1`.`id` ASC
LIMIT
	10000;

-- -----------------------------------------------------------------------------------------------
-- Section 4: Programmability – 30 pts
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- 15.	Commit
-- -----------------------------------------------------------------------------------------------
USE `Buhtig`;
DROP PROCEDURE IF EXISTS `udp_commit`;

DELIMITER $$
USE `Buhtig`$$
CREATE PROCEDURE `udp_commit` 
(
	in_username VARCHAR(30),
    in_password VARCHAR(30),
    in_message VARCHAR(255),
    in_issue_id INT(11)
)
BEGIN
	
    -- START TRANSACTION;
    
	IF (SELECT `username` FROM `users` WHERE `username` = in_username) IS NULL THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'No such user!';
            
		-- ROLLBACK;
    
    ELSEIF (SELECT `password` FROM `users` WHERE `username` = in_username LIMIT 1) NOT LIKE in_password THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Password is incorrect!';
            
		-- ROLLBACK;
        
	ELSEIF (SELECT `id` FROM `issues` WHERE `id` = in_issue_id) IS NULL THEN
		SIGNAL 
			SQLSTATE '45000'
            SET MESSAGE_TEXT = 'The issue does not exist!';
            
		-- ROLLBACK;
        
	ELSE
		INSERT INTO `commits`
			(`message`, `issue_id`, `repository_id`, `contributor_id`)
		VALUES
			(
				in_message, 
                in_issue_id, 
                (SELECT `repository_id` FROM `issues` WHERE `id` = in_issue_id LIMIT 1), 
                (SELECT `id` FROM `users` WHERE `username` = in_username LIMIT 1)
			);
        
	END IF;
        
END
$$

DELIMITER ;

CALL udp_commit ('WhoDenoteBel', 'ajmISQi*', 'Fixed issue: Invalid welcoming message in READ.html', 2);

-- -----------------------------------------------------------------------------------------------
-- 16.	Filter Extensions
-- -----------------------------------------------------------------------------------------------	
USE `Buhtig`;
DROP PROCEDURE IF EXISTS `udp_findbyextension`;

DELIMITER $$
USE `Buhtig`$$
CREATE PROCEDURE `udp_findbyextension` 
(
	in_extension VARCHAR(100)
)
BEGIN
	
	SELECT
		`files_t1`.`id` AS `id`,
        `files_t1`.`name` AS `caption`,
        CONCAT(`files_t1`.`size`, 'KB') AS `user`
	FROM
		`files` AS `files_t1`
	WHERE
		`files_t1`.`name` LIKE CONCAT('%', in_extension)
	ORDER BY
		`files_t1`.`id` ASC
	LIMIT
		1000;
	
        
END
$$

DELIMITER ;

CALL udp_findbyextension ('html');
























