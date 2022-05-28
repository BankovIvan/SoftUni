-- 4.1
SELECT * FROM minions;

-- 4.2
SELECT m.name FROM minions AS m
ORDER BY m.name ASC;

-- 6
UPDATE minions
	SET minions.age = minions.age + 1
    WHERE minions.age IS NOT NULL;
    
