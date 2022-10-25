CREATE DATABASE MyDatabase
USE MyDatabase
show tables

CREATE TABLE users (
	Id Tinyint auto_increment NOT NULL,
    Name VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(50),
    Phone INT,
    Address VARCHAR(50),
    DateIn Datetime,
    primary key(Id)
) 

INSERT INTO users (Name, LastName, Email, Phone, Address, DateIn)
VALUES ('John', 'Doe', 'johndoe@gmail.com', 60606060, 'Miami, FL', '2021-10-10')	

SELECT * FROM users

CALL spInsertUser('Jason', 'Taylor', 'jason.taylor@gmail.com', 61616161, 'Scottdale, AR', '2020-11-11');

CALL spGetUsers();

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertUser`(IN pName VARCHAR(50), 
								 IN pLastname VARCHAR(50),
                                 IN pEmail VARCHAR(50),
                                 IN pPhone INT,
                                 IN pAddress VARCHAR(50),
                                 IN pDateIn Datetime)
BEGIN

	INSERT INTO users (Name, 
					   LastName, 
                       Email, 
                       Phone, 
                       Address, 
                       DateIn)
	VALUES (pName, 
			pLastname, 
            pEmail, 
            pPhone, 
            pAddress, 
            pDateIn);
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetUsers`()
BEGIN
	SELECT * FROM users;
END$$
DELIMITER ;



