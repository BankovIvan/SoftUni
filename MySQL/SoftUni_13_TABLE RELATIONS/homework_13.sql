-- -----------------------------------------------------------------------------------------------
-- Lab: Table Relations
-- -----------------------------------------------------------------------------------------------
CREATE DATABASE camp;
use camp;

CREATE TABLE rooms(
	id INT PRIMARY KEY,
	occupation VARCHAR(20) not null,
	beds_count int not null
);

CREATE TABLE vehicles(
	id int primary key auto_increment not null,
	driver_id int not null,
	vehicle_type varchar(30) not null,
	passengers int not null
);

CREATE TABLE campers(
	id INT PRIMARY KEY auto_increment,
	first_name varchar(20) not null,
	last_name varchar(20) not null,
	age int not null,
	room int,
	vehicle_id int,
	CONSTRAINT fk_room_id FOREIGN KEY(room) REFERENCES rooms(id),
  	CONSTRAINT fk_vehicle_id FOREIGN KEY(vehicle_id) REFERENCES vehicles(id) on delete cascade
);

CREATE TABLE routes(
	id INT PRIMARY KEY auto_increment,
	starting_point varchar(30) not null,
	end_point varchar(30) not null,
	leader_id int not null,
	route_time TIME NOT NULL,	
	CONSTRAINT fk_leader_id FOREIGN KEY(leader_id) REFERENCES campers(id)
);

insert into rooms(id,occupation,beds_count) values(101,"occupied",3),
(102,"free",3),
(103,"free",3),
(104,"free",2),
(105,"free",2),
(201,"free",3),
(202,"free",3),
(203,"free",2),
(204,"free",3),
(205,"free",3),
(301,"free",2),
(302,"free",2),
(303,"free",2),
(304,"free",3),
(305,"free",3);

insert into campers(first_name, last_name, age,room) values("Simo", "Sheytanov", 20,101),
("Roli", "Dimitrova", 27,102),
("RoYaL", "Yonkov", 25,301),
("Ivan", "Ivanov", 28,301),
("Alisa", "Terzieva", 25,102),
("Asya", "Ivanova", 26,102),
("Dimitar", "Verbov", 21,301),
("Iskren", "Ivanov", 28,302),
("Bojo", "Gevechanov", 28,302);

insert into vehicles(driver_id,vehicle_type,passengers) values
(1,"bus",20),
(2,"van",10),
(1,"van",10),
(4,"car",5),
(5,"car",5),
(6,"car",4),
(7,"car",3),
(8,"bus",3);

insert into routes(starting_point,end_point,leader_id,route_time) values
("Hotel Malyovitsa", "Malyovitsa Peak", 3, '02:00:00'),
("Hotel Malyovitsa", "Malyovitsa Hut", 3, '00:40:00'),
("Ribni Ezera Hut", "Rila Monastery", 3, '06:00:00'),
("Borovets", "Musala Peak", 4, '03:30:00');

-- -----------------------------------------------------------------------------------------------
-- 1.	 Mountains and Peaks
-- -----------------------------------------------------------------------------------------------
CREATE DATABASE temp;
use temp;
/*
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
*/

CREATE TABLE `Mountains`
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(50),
    CONSTRAINT `pk_Mountains` PRIMARY KEY (`id`)
    -- ,
    -- CONSTRAINT `unique_Mountains` UNIQUE (`name`)
);

CREATE TABLE `Peaks`
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(50),
    `mountain_id` INT UNSIGNED,
    CONSTRAINT `pk_Peaks` PRIMARY KEY (`id`),
    CONSTRAINT `fk_Mountains` FOREIGN KEY (`mountain_id`) REFERENCES `Mountains` (`id`)
);

-- -----------------------------------------------------------------------------------------------
-- 2.	 Posts and Authors
-- -----------------------------------------------------------------------------------------------
CREATE TABLE `Authors`
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(50),
    CONSTRAINT `pk_Authors` PRIMARY KEY (`id`)
);

CREATE TABLE `Books`
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `name` VARCHAR(50),
    `author_id` INT UNSIGNED,
    CONSTRAINT `pk_Books` PRIMARY KEY (`id`),
    CONSTRAINT `fk_Authors` FOREIGN KEY (`author_id`) 
		REFERENCES `Authors` (`id`) 
        ON DELETE CASCADE
);

-- -----------------------------------------------------------------------------------------------
-- 3.	 Trip Organization
-- -----------------------------------------------------------------------------------------------
USE `camp`;

SELECT
	`vehicles_t1`.`driver_id`,
    `vehicles_t1`.`vehicle_type`,
    CONCAT(`campers_t1`.`first_name`, ' ', `campers_t1`.`last_name`) AS `driver_name`
FROM
	`campers` AS `campers_t1` JOIN `vehicles` AS `vehicles_t1` ON `campers_t1`.`id` = `vehicles_t1`.`driver_id`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 4.	 SoftUni Hiking
-- -----------------------------------------------------------------------------------------------
SELECT
	`routes_t1`.`starting_point` AS `route_starting_point`,
    `routes_t1`.`end_point` AS `route_ending_point`,
    `routes_t1`.`leader_id`,
    CONCAT(`campers_t1`.`first_name`, ' ', `campers_t1`.`last_name`) AS `leader_name`
FROM
	`campers` AS `campers_t1` JOIN `routes` AS `routes_t1` ON `campers_t1`.`id` = `routes_t1`.`leader_id`
LIMIT
	1000;

-- -----------------------------------------------------------------------------------------------
-- 5.	 Project Management DB*
-- -----------------------------------------------------------------------------------------------
CREATE DATABASE `Project Management`;
USE `Project Management`;

CREATE TABLE `employees`
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `first_name` VARCHAR(30),
    `last_name` VARCHAR(30),
    `project_id` INT UNSIGNED,
    CONSTRAINT `pk_employees` PRIMARY KEY (`id`)
);

CREATE TABLE `projects`
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `client_id` INT UNSIGNED,
    `project_lead_id` INT UNSIGNED,
    CONSTRAINT `pk_projects` PRIMARY KEY (`id`)
);

CREATE TABLE `clients`
(
	`id` INT UNSIGNED AUTO_INCREMENT,
    `client_name` VARCHAR(100),
    `project_id` INT UNSIGNED,
    CONSTRAINT `pk_clients` PRIMARY KEY (`id`)
    
);

ALTER TABLE `employees`
    ADD CONSTRAINT `fk_employee_projects` FOREIGN KEY (`project_id`) REFERENCES `projects` (`id`);

ALTER TABLE `projects`
	ADD CONSTRAINT `fk_project_clients` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`),
    ADD CONSTRAINT `fk_project_lead` FOREIGN KEY (`project_lead_id`) REFERENCES `clients` (`id`);
    
ALTER TABLE `clients`
	ADD CONSTRAINT `fk_client_projects` FOREIGN KEY (`project_id`) REFERENCES `projects` (`id`);


