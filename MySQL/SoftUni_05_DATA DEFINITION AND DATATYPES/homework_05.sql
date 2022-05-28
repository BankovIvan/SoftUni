
-- 1
DROP TABLE people;

CREATE TABLE people
(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	email VARCHAR(50) UNIQUE,
    first_name VARCHAR(50),
	middle_name VARCHAR(50),
	last_name VARCHAR(50),
	salary DECIMAL(7, 2) UNSIGNED DEFAULT 0,
	date_of_birth DATE
);


-- 2
INSERT INTO people
(
	email,
    first_name,
    middle_name,
    last_name,
    salary,
    date_of_birth
)
VALUES
(
	'someone@somewhere.com',
    'Bai',
    'Ivan',
    'Pi4',
    1000,
    '1997-12-31'
);


-- 3
ALTER TABLE people
	MODIFY COLUMN email VARCHAR(100) UNIQUE;

ALTER TABLE people
	ADD COLUMN full_name VARCHAR(150);
    
ALTER TABLE people
	DROP COLUMN full_name;  
    
