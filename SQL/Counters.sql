if db_id('Counters') is not null
	print 'db exists'
else
	Create Database [Counters]

USE Counters

	--Create Personal Account table
DROP TABLE IF EXISTS PersonalAccount; 

CREATE TABLE PersonalAccount
(
	AccountID INT NOT NULL PRIMARY KEY,
	DateOfCreation DATETIME
);

--Create Counter Options table
DROP TABLE IF EXISTS CounterOptions

CREATE TABLE CounterOptions
(
	CounterID INT NOT NULL PRIMARY KEY,
	CounterType VARCHAR(15) NOT NULL CHECK (CounterType IN ('Вода', 'Электричество')),
	CounterDescription varchar(255)
);

--Create Counter Value table
DROP TABLE IF EXISTS CounterValue

CREATE TABLE CounterValue
(
	CounterValudId INT NOT NULL PRIMARY KEY,
	AccountID INT,
	CounterID INT,
	CounterValue INT,
	Unit VARCHAR(15),
	DateOfEnterValue DATETIME
);

INSERT INTO PersonalAccount (AccountID, DateOfCreation) VALUES ('15', '2016-23-12');
INSERT INTO PersonalAccount (AccountID, DateOfCreation) VALUES ('5', '2016-24-12');
INSERT INTO PersonalAccount (AccountID, DateOfCreation) VALUES ('0', '2016-25-12');

INSERT INTO CounterOptions (CounterID, CounterType, CounterDescription) VALUES ('0', 'Вода', 'Счетчик воды');
INSERT INTO CounterOptions (CounterID, CounterType, CounterDescription) VALUES ('4', 'Электричество', 'Счетчик электричества');
INSERT INTO CounterOptions (CounterID, CounterType, CounterDescription) VALUES ('8', 'Вода', 'Счетчик воды');

INSERT INTO CounterValue (CounterValudId, AccountID, CounterID, CounterValue, Unit, DateOfEnterValue) VALUES ('0', '15', '0', '4', 'Кубы', '2016-10-25');