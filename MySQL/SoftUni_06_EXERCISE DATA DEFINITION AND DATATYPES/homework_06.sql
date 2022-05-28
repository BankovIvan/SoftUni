-- 1.	Create Database
CREATE DATABASE `db_minions`;
USE `db_minions`;

-- 2.	Create Tables
CREATE TABLE `minions` 
(
	`id` INT,
    `name` VARCHAR(50),
    `age` INT,
    CONSTRAINT `pk_minions` PRIMARY KEY (`id`)
);
CREATE TABLE `towns` 
(
	`id` INT,
    `name` VARCHAR(50),
    CONSTRAINT `pk_towns` PRIMARY KEY (`id`)
);

-- 3.	Alter Minions Table
ALTER TABLE `minions` 
	ADD `town_id` INT, 
    ADD CONSTRAINT `fk_minionTown` FOREIGN KEY (`town_id`) REFERENCES `towns`(`id`);
    
-- 4.	Insert Records in Both Tables
INSERT INTO `towns` (`id`, `name`)
	VALUES 	(1, 'Sofia'),
			(2, 'Plovdiv'),
            (3, 'Varna');
INSERT INTO `minions` (`id`, `name`, `age`, `town_id`)
	VALUES 	(1, 'Kevin', 22, 1),
			(2, 'Bob', 15, 3),
            (3, 'Steward', null, 2);
            
-- 5.	Truncate Table Minions
TRUNCATE `minions`;

-- 6.	Drop All Tables
DROP TABLE `minions`, `towns`;

-- 7.	Create Table People
CREATE TABLE `people` 
(
	`id` INT AUTO_INCREMENT,
    `name` VARCHAR(200) NOT NULL,
    `picture` BLOB,
    `height` DOUBLE(3, 2),
    `weight` DOUBLE(5, 2),
    `gender` ENUM('m', 'f') NOT NULL,
    `birthdate` DATE NOT NULL,
    `biography` LONGTEXT,
    CONSTRAINT `pk_People` PRIMARY KEY (`id`)
);
INSERT INTO `people` (`name`, `gender`, `birthdate`)
	VALUES 	('Kevin', 'm', '2013-12-31'),
			('Bob', 'm', '2014-12-31'),
            ('Steward', 'm', '2015-12-31'),
            ('Петрунка', 'f', '2016-12-31'),
            ('Azis', 'f', '2017-12-31');

-- 8.	Create Table Users
CREATE TABLE `users` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `username` CHAR(30) NOT NULL,
    `password` CHAR(26) NOT NULL,
    `profile_picture` BLOB,
    `last_login_time` DATE,
    `is_deleted` BOOL DEFAULT FALSE,
    CONSTRAINT `pk_users` PRIMARY KEY (`id`),
    CONSTRAINT `unique_users` UNIQUE(`username`)
);
INSERT INTO `users` (`username`, `password`)
	VALUES 	('Kevin@nasa.gov', 'password1'),
			('Bob@nasa.gov', 'password2'),
            ('Steward@nasa.gov', 'password3'),
            ('Петрунка@nasa.gov', 'password4'),
            ('Azis@nasa.gov', 'password5');

-- 9.	Change Primary Key
-- ALTER TABLE `users`
-- 	MODIFY `id` INT UNSIGNED,
-- 	DROP PRIMARY KEY, 
--  MODIFY `id` INT UNSIGNED AUTO_INCREMENT,
--  ADD CONSTRAINT `pk_users` PRIMARY KEY (`id`, `username`);
    
ALTER TABLE `users`
	DROP PRIMARY KEY,
    DROP INDEX `unique_users`,
	ADD CONSTRAINT `pk_users` PRIMARY KEY (`id`, `username`);
    
-- 10.	Set Default Value of a Field
ALTER TABLE `users`
	MODIFY `last_login_time` TIMESTAMP DEFAULT CURRENT_TIMESTAMP;

-- 11.	 Set Unique Field
-- ALTER TABLE `users`
--  DROP PRIMARY KEY,
--  MODIFY `id` INT UNSIGNED AUTO_INCREMENT,
--  MODIFY `username` CHAR(30) UNIQUE NOT NULL,
--  ADD CONSTRAINT `pk_users` PRIMARY KEY (`id`);

ALTER TABLE `users`
	DROP PRIMARY KEY,
    ADD CONSTRAINT `pk_users` PRIMARY KEY (`id`),
    ADD CONSTRAINT `unique_users` UNIQUE(`username`);

-- 12.	Movies Database
CREATE DATABASE `Movies`;
USE `Movies`;

CREATE TABLE `directors` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `director_name` VARCHAR(256) NOT NULL,
    `NOTES` TEXT,
    CONSTRAINT `pk_directors` PRIMARY KEY (`id`)
);
INSERT INTO `directors` (`director_name`)
	VALUES 	('Kevin'),
			('Bob'),
            ('Steward'),
            ('Петрунка'),
            ('Azis');

CREATE TABLE `genres` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `genre_name` VARCHAR(256) NOT NULL,
    `NOTES` TEXT,
    CONSTRAINT `pk_genres` PRIMARY KEY (`id`)
);
INSERT INTO `genres` (`genre_name`)
	VALUES 	('science fiction'),
			('documentary'),
            ('drama'),
            ('western'),
            ('comedy');

CREATE TABLE `categories` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `category_name` VARCHAR(256) NOT NULL,
    `NOTES` TEXT,
    CONSTRAINT `pk_categories` PRIMARY KEY (`id`)
);
INSERT INTO `categories` (`category_name`)
	VALUES 	('science fiction 1'),
			('documentary 1'),
            ('drama 1'),
            ('western 1'),
            ('comedy 1');

CREATE TABLE `movies` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `title` VARCHAR(256) NOT NULL,
    `director_id` INT UNSIGNED,
    `copyright_year` TIMESTAMP,
    `length` TIMESTAMP,
    `genre_id` INT UNSIGNED,
    `category_id` INT UNSIGNED,
    `rating` INT UNSIGNED,
    `NOTES` TEXT,
    CONSTRAINT `pk_movies` PRIMARY KEY (`id`)
);
INSERT INTO `movies` (`title`)
	VALUES 	('Movie1'),
			('Movie2'),
            ('Movie3'),
            ('Movie4'),
            ('Movie5');

-- -----------------------------------------------------------------------------------------------
-- 13.	Car Rental Database
-- -----------------------------------------------------------------------------------------------
CREATE DATABASE `car_rental`;
USE `car_rental`;

CREATE TABLE `categories` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `category` VARCHAR(50) NOT NULL,
    `daily_rate` DOUBLE DEFAULT 0.0, 
    `weekly_rate` DOUBLE DEFAULT 0.0, 
    `monthly_rate` DOUBLE DEFAULT 0.0, 
    `weekend_rate` DOUBLE DEFAULT 0.0,
    CONSTRAINT `pk_categories` PRIMARY KEY (`id`)
);
INSERT INTO `categories` (`category`)
	VALUES 	('SUV'),
			('Sedan'),
            ('Van');

CREATE TABLE `cars` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `plate_number` VARCHAR(50) NOT NULL,
    `make` VARCHAR(50), 
    `model` VARCHAR(50),
    `car_year` INT UNSIGNED, 
    `category_id` INT UNSIGNED,
    `doors` INT UNSIGNED,
    `picture` BLOB,
    `car_condition` TEXT,
    `available` BOOL NOT NULL,
    CONSTRAINT `pk_cars` PRIMARY KEY (`id`),
    CONSTRAINT `unique_cars` UNIQUE (`plate_number`)
);
INSERT INTO `cars` (`plate_number`, `available`)
	VALUES 	('AA 0001 AA', TRUE),
			('AA 0002 AA', TRUE),
            ('AA 0003 AA', TRUE);

CREATE TABLE `employees` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `first_name` VARCHAR(50) NOT NULL,
    `last_name` VARCHAR(50) NOT NULL, 
    `title` VARCHAR(50), 
    `notes` TEXT,
    CONSTRAINT `pk_employees` PRIMARY KEY (`id`)
);
INSERT INTO `employees` (`first_name`, `last_name`, `title`)
	VALUES 	('John', 'Smith', NULL),
			('John', 'Smith', 'Jr.'),
            ('John', 'Smith', 'Sr.');

CREATE TABLE `customers` 
(
	-- id, driver_licence_number, full_name, address, city, zip_code, notes
	`id` INT UNSIGNED AUTO_INCREMENT,
    `driver_licence_number` VARCHAR(25) NOT NULL,
    `full_name` VARCHAR(250) NOT NULL, 
    `address` TEXT, 
    `city` VARCHAR(50), 
    `zip_code` VARCHAR(25), 
    `notes` TEXT,
    CONSTRAINT `pk_customers` PRIMARY KEY (`id`)
    -- ,CONSTRAINT `unique_customers` UNIQUE (`driver_licence_number`)
);
INSERT INTO `customers` (`driver_licence_number`, `full_name`)
	VALUES 	('12345678', 'John Smith'),
			('1234567890', 'John Smith Jr.'),
            ('1234567890123456', 'John Smith Sr.');

CREATE TABLE `rental_orders` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `employee_id` INT UNSIGNED,
    `customer_id` INT UNSIGNED,
    `car_id` INT UNSIGNED,
    `car_condition` VARCHAR(50), 
    `tank_level` INT UNSIGNED, 
    `kilometrage_start` INT8 UNSIGNED, 
    `kilometrage_end` INT8 UNSIGNED,
    `total_kilometrage` INT8 UNSIGNED,
    `start_date` TIMESTAMP, 
    `end_date` TIMESTAMP, 
	`total_days` INT, 
    `rate_applied` DOUBLE,
    `tax_rate` DOUBLE,
    `order_status` VARCHAR(50),
    `notes` TEXT,
    CONSTRAINT `pk_rental_orders` PRIMARY KEY (`id`)
);
INSERT INTO `rental_orders` (`employee_id`, `customer_id`, `car_id`)
	VALUES 	(1, 1, 1),
			(2, 2, 2),
            (3, 3, 3);

-- -----------------------------------------------------------------------------------------------
-- 14.	Hotel Database
-- -----------------------------------------------------------------------------------------------
CREATE DATABASE `Hotel`;
USE `Hotel`;

CREATE TABLE `employees` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `first_name` VARCHAR(50) NOT NULL,
    `last_name` VARCHAR(50) NOT NULL,
    `title` VARCHAR(10), 
    `notes` TEXT,
    CONSTRAINT `pk_employees` PRIMARY KEY (`id`)
);
INSERT INTO `employees` (`first_name`, `last_name`)
	VALUES 	('John', 'Smith'),
			('Васил', 'Найденов'),
            ('Лили', 'Иванова');

CREATE TABLE `customers` 
(
    `account_number` INT UNSIGNED,
    `first_name` VARCHAR(250) NOT NULL, 
    `last_name` VARCHAR(250) NOT NULL, 
    `phone_number` VARCHAR(50), 
    `emergency_name` VARCHAR(50), 
    `emergency_number` VARCHAR(50),
    `notes` TEXT,
    CONSTRAINT `pk_customers` PRIMARY KEY (`account_number`)
);
INSERT INTO `customers` (`account_number`, `first_name`, `last_name`)
	VALUES 	(1, 'John', 'Smith'),
			(2, 'John', 'Smith Jr.'),
            (3, 'John', 'Smith Sr.');

CREATE TABLE `room_status` 
(
    `room_status` VARCHAR(50) PRIMARY KEY,
    `notes` TEXT
);
INSERT INTO `room_status` (`room_status`)
	VALUES 	('occupied'), 
			('free'), 
            ('maintenance');

CREATE TABLE `room_types` 
(
    `room_type` VARCHAR(50) PRIMARY KEY,
    `notes` TEXT
);
INSERT INTO `room_types` (`room_type`)
	VALUES 	('Single'),
			('Double'),
            ('Presidenial Appartment');

CREATE TABLE `bed_types` 
(
    `bed_type` VARCHAR(50) PRIMARY KEY,
    `notes` TEXT
);
INSERT INTO `bed_types` (`bed_type`)
	VALUES 	('Single'),
			('Double'),
            ('Sofa');

CREATE TABLE `rooms` 
(
    `room_number` INT UNSIGNED,
    `room_type`  VARCHAR(50),
    `bed_type`  VARCHAR(50),
    `rate` DOUBLE,
    `room_status`  VARCHAR(50),
    `notes` TEXT,
    CONSTRAINT `pk_rooms` PRIMARY KEY (`room_number`)
);
INSERT INTO `rooms` (`room_number`, `room_type`, `bed_type`, `room_status`)
	VALUES 	(1, 'Single', 'Single', 'occupied'),
			(2, 'Double', 'Double', 'free'),
            (3, 'Presidenial Appartment', 'Sofa', 'free');

CREATE TABLE `payments` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `employee_id` INT UNSIGNED NOT NULL,
    `payment_date` TIMESTAMP NOT NULL,
    `account_number` INT UNSIGNED NOT NULL,
    `first_date_occupied` TIMESTAMP,
    `last_date_occupied` TIMESTAMP,
    `total_days` TIMESTAMP,
    `amount_charged` DOUBLE,
    `tax_rate` DOUBLE,
    `tax_amount` DOUBLE,
    `payment_total` DOUBLE NOT NULL,
    `notes` TEXT,
    CONSTRAINT `pk_payments` PRIMARY KEY (`id`)
);
INSERT INTO `payments` (`employee_id`, `payment_date`, `account_number`, `payment_total`)
	VALUES 	(1, CURRENT_TIMESTAMP, 1, 100.10),
			(2, CURRENT_TIMESTAMP, 2, 200.20),
            (3, CURRENT_TIMESTAMP, 3, 300.30);

CREATE TABLE `occupancies` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `employee_id` INT UNSIGNED NOT NULL,
    `date_occupied` TIMESTAMP NOT NULL,
    `account_number` INT UNSIGNED NOT NULL,
    `room_number` INT UNSIGNED NOT NULL,
    `rate_applied` DOUBLE,
    `phone_charge` DOUBLE,
    `notes` TEXT,
    CONSTRAINT `pk_occupancies` PRIMARY KEY (`id`)
);
INSERT INTO `occupancies` (`employee_id`, `date_occupied`, `account_number`, `room_number`)
	VALUES 	(1, CURRENT_TIMESTAMP, 1, 1),
			(2, CURRENT_TIMESTAMP, 2, 2),
            (3, CURRENT_TIMESTAMP, 3, 3);

-- -----------------------------------------------------------------------------------------------
-- 15.	Create SoftUni Database
-- -----------------------------------------------------------------------------------------------
CREATE DATABASE `soft_uni`;
USE `soft_uni`;

CREATE TABLE `towns` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL,
    CONSTRAINT `pk_towns` PRIMARY KEY (`id`)
    -- , CONSTRAINT `unique_towns` UNIQUE(`name`)
);

CREATE TABLE `addresses` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `address_text` TEXT NOT NULL,
    `town_id` INT UNSIGNED,
    CONSTRAINT `pk_addresses` PRIMARY KEY (`id`),
    CONSTRAINT `fk_town` FOREIGN KEY (`town_id`) REFERENCES `towns`(`id`)
);

CREATE TABLE `departments` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(250) NOT NULL,
    CONSTRAINT `pk_departments` PRIMARY KEY (`id`)
);

CREATE TABLE `employees` 
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `first_name` VARCHAR(50),
    `middle_name` VARCHAR(50),
    `last_name` VARCHAR(50),
    `job_title` VARCHAR(250),
    `department_id` INT UNSIGNED,
    `hire_date` TIMESTAMP,
    `salary` DOUBLE,
    `address_id` INT UNSIGNED,
    CONSTRAINT `pk_employees` PRIMARY KEY (`id`),
    CONSTRAINT `fk_department` FOREIGN KEY (`department_id`) REFERENCES `departments`(`id`),
    CONSTRAINT `fk_address` FOREIGN KEY (`address_id`) REFERENCES `addresses`(`id`)
);

-- -----------------------------------------------------------------------------------------------
-- 17.	Basic Insert
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

INSERT INTO `towns` (`name`)
	VALUES 	('Sofia'),
			('Plovdiv'),
            ('Varna'),
            ('Burgas');

INSERT INTO `departments` (`name`)
	VALUES 	('Engineering'),
			('Sales'),
            ('Marketing'),
            ('Software Development'),
            ('Quality Assurance');

INSERT INTO `employees` (`first_name`, `middle_name`, `last_name`, `job_title`, `department_id`, `hire_date`, `salary`)
	VALUES 	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
			('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
            ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
            ('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
            ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);

-- -----------------------------------------------------------------------------------------------
-- 18.	Basic Select All Fields
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

SELECT * FROM towns;
SELECT * FROM departments;
SELECT * FROM employees;

-- -----------------------------------------------------------------------------------------------
-- 19.	Basic Select All Fields and Order Them
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

SELECT * FROM towns ORDER BY `name`;
SELECT * FROM departments ORDER BY `name`;
SELECT * FROM employees ORDER BY `salary` DESC;

-- -----------------------------------------------------------------------------------------------
-- 20.	Basic Select Some Fields
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

SELECT `name` FROM towns ORDER BY `name`;
SELECT `name` FROM departments ORDER BY `name`;
SELECT `first_name`, `last_name`, `job_title`, `salary` FROM employees ORDER BY `salary` DESC;

-- -----------------------------------------------------------------------------------------------
-- 21.	Increase Employees Salary
-- -----------------------------------------------------------------------------------------------
USE `soft_uni`;

UPDATE `employees` SET `salary` = `salary` + (0.1 * `salary`);
SELECT `salary` FROM `employees`;

-- -----------------------------------------------------------------------------------------------
-- 22.	Decrease Tax Rate
-- -----------------------------------------------------------------------------------------------
USE `Hotel`;

UPDATE `payments` SET `tax_rate` = `tax_rate` - (0.03 * `tax_rate`);
SELECT `tax_rate` FROM `payments`;

-- -----------------------------------------------------------------------------------------------
-- 23.	Delete All Records
-- -----------------------------------------------------------------------------------------------
USE `Hotel`;

TRUNCATE TABLE `occupancies`;
-- SELECT `tax_rate` FROM `payments`;






