-- -----------------------------------------------------------------------------------------------
-- Exercises: Table Relations
-- -----------------------------------------------------------------------------------------------
DROP DATABASE `temp`;
CREATE DATABASE `temp`;
USE `temp`;

-- -----------------------------------------------------------------------------------------------
-- 1.	One-To-One Relationship
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `persons`
(
	`person_id` INT(11) UNSIGNED AUTO_INCREMENT,
    `first_name` VARCHAR(30),
    `salary` DECIMAL(10, 2),
    `passport_id` INT(11) UNSIGNED,
    CONSTRAINT `pk_persons` PRIMARY KEY (`person_id`),
    CONSTRAINT `unique_passport_id` UNIQUE (`passport_id`)
);

CREATE TABLE `passports`
(
	`passport_id` INT(11) UNSIGNED AUTO_INCREMENT,
    `passport_number` VARCHAR(30),
    CONSTRAINT `pk_passports` PRIMARY KEY (`passport_id`)
);

INSERT INTO `persons` (`person_id`, `first_name`, `salary`, `passport_id`)
	VALUES 	(1, 	'Roberto', 	43300.00, 	102),
			(2, 	'Tom', 		56100.00, 	103),
            (3, 	'Yana', 	60200.00, 	101);

INSERT INTO `passports` (`passport_id`, `passport_number`)
	VALUES 	(101, 	'N34FG21B'),
			(102, 	'K65LO4R7'),
            (103, 	'ZE657QP2');

ALTER TABLE `persons`
	ADD CONSTRAINT `fk_passport_id` FOREIGN KEY (`passport_id`) REFERENCES `passports`(`passport_id`);

-- -----------------------------------------------------------------------------------------------
-- 2.	One-To-Many Relationship
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `manufacturers`
(
	`manufacturer_id` INT(11) UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(50),
    `established_on` DATE,
    CONSTRAINT `pk_manufacturers` PRIMARY KEY (`manufacturer_id`)
);

CREATE TABLE `models`
(
	`model_id` INT(11) UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(50),
    `manufacturer_id` INT(11) UNSIGNED,
    CONSTRAINT `pk_models` PRIMARY KEY (`model_id`)
);

INSERT INTO `manufacturers` (`manufacturer_id`, `name`, `established_on`)
	VALUES 	(1, 	'BMW', 		STR_TO_DATE('01/03/1916', '%d/%m/%Y')),
			(2, 	'Tesla', 	STR_TO_DATE('01/01/2003', '%d/%m/%Y')),
            (3, 	'Lada', 	STR_TO_DATE('01/05/1966', '%d/%m/%Y'));
            
INSERT INTO `models` (`model_id`, `name`, `manufacturer_id`)
	VALUES 	(101, 	'X1', 		1),
			(102, 	'i6', 		1),
            (103, 	'Model S', 	2),
            (104, 	'Model X', 	2),
            (105, 	'Model 3', 	2),
            (106, 	'Nova', 	3);

ALTER TABLE `models`
	ADD CONSTRAINT `fk_manufacturer` FOREIGN KEY (`manufacturer_id`) REFERENCES `manufacturers`(`manufacturer_id`);

-- -----------------------------------------------------------------------------------------------
-- 3.	Many-To-Many Relationship
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `students`
(
	`student_id` INT(11) UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(250),
    CONSTRAINT `pk_students` PRIMARY KEY (`student_id`)
);

CREATE TABLE `exams`
(
	`exam_id` INT(11) UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(250),
    CONSTRAINT `pk_exams` PRIMARY KEY (`exam_id`)
);

CREATE TABLE `students_exams`
(
	`student_id` INT(11) UNSIGNED,
    `exam_id` INT(11) UNSIGNED,
    CONSTRAINT `pk_students_exams` PRIMARY KEY (`student_id`, `exam_id`)
);

INSERT INTO `students` (`student_id`, `name`)
	VALUES 	(1, 	'Mila'),
			(2, 	'Toni'),
            (3, 	'Ron');
            
INSERT INTO `exams` (`exam_id`, `name`)
	VALUES 	(101, 	'Spring MVC'),
			(102, 	'Neo4j'),
            (103, 	'Oracle 11g');

INSERT INTO `students_exams` (`student_id`, `exam_id`)
	VALUES 	(1, 	101),
			(1, 	102),
            (2, 	101),
            (3, 	103),
            (2, 	102),
            (2, 	103);

ALTER TABLE `students_exams`
	ADD CONSTRAINT `fk_students` FOREIGN KEY (`student_id`) REFERENCES `students`(`student_id`),
    ADD CONSTRAINT `fk_exams` FOREIGN KEY (`exam_id`) REFERENCES `exams`(`exam_id`);

-- -----------------------------------------------------------------------------------------------
-- 4.	Self-Referencing
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `teachers`
(
	`teacher_id` INT(11) UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(250),
    `manager_id` INT(11) UNSIGNED,
    CONSTRAINT `pk_teachers` PRIMARY KEY (`teacher_id`)
);

INSERT INTO `teachers` (`teacher_id`, `name`, `manager_id`)
	VALUES 	(101, 'John', 		NULL),
			(102, 'Maya', 		106),
            (103, 'Silvia', 	106),
            (104, 'Ted', 		105),
            (105, 'Mark', 		101),
            (106, 'Greta', 		101);

ALTER TABLE `teachers`
    ADD CONSTRAINT `fk_manager` FOREIGN KEY (`manager_id`) REFERENCES `teachers`(`teacher_id`);

-- -----------------------------------------------------------------------------------------------
-- 5.	Online Store Database
-- -----------------------------------------------------------------------------------------------
DROP DATABASE `temp`;
CREATE DATABASE `temp`;
USE `temp`;

CREATE TABLE `item_types`
(
	`item_type_id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(50),
    CONSTRAINT `pk_item_types` PRIMARY KEY (`item_type_id`)
);

CREATE TABLE `items`
(
	`item_id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(50),
    `item_type_id` INT(11),
    CONSTRAINT `pk_items` PRIMARY KEY (`item_id`)
);

CREATE TABLE `order_items`
(
	`order_id` INT(11),
	`item_id` INT(11),
    CONSTRAINT `pk_orders_items` PRIMARY KEY (`order_id`, `item_id`)
);

CREATE TABLE `orders`
(
	`order_id` INT(11),
	`customer_id` INT(11),
    CONSTRAINT `pk_orders` PRIMARY KEY (`order_id`)
);

CREATE TABLE `customers`
(
	`customer_id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(50),
    `birthday` DATE,
    `city_id` INT(11),
    CONSTRAINT `pk_customers` PRIMARY KEY (`customer_id`)
);

CREATE TABLE `cities`
(
	`city_id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(50),
    CONSTRAINT `pk_cities` PRIMARY KEY (`city_id`)
);

ALTER TABLE `items`
    ADD CONSTRAINT `fk_item_type_id` FOREIGN KEY (`item_type_id`) REFERENCES `item_types`(`item_type_id`);

ALTER TABLE `order_items`
    ADD CONSTRAINT `fk_order_id` FOREIGN KEY (`order_id`) REFERENCES `orders`(`order_id`),
    ADD CONSTRAINT `fk_item_id` FOREIGN KEY (`item_id`) REFERENCES `items`(`item_id`);

ALTER TABLE `orders`
    ADD CONSTRAINT `fk_customer_id` FOREIGN KEY (`customer_id`) REFERENCES `customers`(`customer_id`);

ALTER TABLE `customers`
    ADD CONSTRAINT `fk_city_id` FOREIGN KEY (`city_id`) REFERENCES `cities`(`city_id`);

-- -----------------------------------------------------------------------------------------------
-- 6.	University Database
-- -----------------------------------------------------------------------------------------------
DROP DATABASE `temp`;
CREATE DATABASE `temp`;
USE `temp`;

CREATE TABLE `subjects`
(
	`subject_id` INT(11) AUTO_INCREMENT,
    `subject_name` VARCHAR(50),
    CONSTRAINT `pk_subjects` PRIMARY KEY (`subject_id`)
);

CREATE TABLE `agenda`
(
	`student_id` INT(11),
	`subject_id` INT(11),
    CONSTRAINT `pk_agenda` PRIMARY KEY (`student_id`, `subject_id`)
);

CREATE TABLE `students`
(
	`student_id` INT(11) AUTO_INCREMENT,
    `student_number` VARCHAR(12),
    `student_name` VARCHAR(50),
    `major_id` INT(11),
    CONSTRAINT `pk_students` PRIMARY KEY (`student_id`)
);

CREATE TABLE `majors`
(
	`major_id` INT(11) AUTO_INCREMENT,
    `name` VARCHAR(50),
    CONSTRAINT `pk_majors` PRIMARY KEY (`major_id`)
);

CREATE TABLE `payments`
(
	`payment_id` INT(11) AUTO_INCREMENT,
    `payment_date` DATE,
    `payment_amount` DECIMAL(8, 2),
    `student_id` INT(11),
    CONSTRAINT `pk_majors` PRIMARY KEY (`payment_id`)
);

ALTER TABLE `agenda`
    ADD CONSTRAINT `fk_student_agenda` FOREIGN KEY (`student_id`) REFERENCES `students`(`student_id`),
    ADD CONSTRAINT `fk_subject_agenda` FOREIGN KEY (`subject_id`) REFERENCES `subjects`(`subject_id`);
    
ALTER TABLE `students`
    ADD CONSTRAINT `fk_major_students` FOREIGN KEY (`major_id`) REFERENCES `majors`(`major_id`);

ALTER TABLE `payments`
    ADD CONSTRAINT `fk_student_payments` FOREIGN KEY (`student_id`) REFERENCES `students`(`student_id`);

-- -----------------------------------------------------------------------------------------------
-- 9.	Peaks in Rila
-- -----------------------------------------------------------------------------------------------
USE `geography`;

SELECT 
	`mountains_t1`.`mountain_range` AS `mountain_range`,
    `peaks_t1`.`peak_name` AS `peak_name`,
    `elevation` AS `peak_elevation`
FROM
	`mountains` AS `mountains_t1` INNER JOIN `peaks` AS `peaks_t1` ON `mountains_t1`.`id` = `peaks_t1`.`mountain_id`
HAVING
	`mountain_range` LIKE 'Rila'
ORDER BY
	`peak_elevation` DESC
LIMIT
	1000;




