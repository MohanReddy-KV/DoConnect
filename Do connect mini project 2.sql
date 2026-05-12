CREATE DATABASE DOCONNECT2DB
use DOCONNECT2DB


-- User table

CREATE TABLE USERTABLE (

    Id INT IDENTITY (1,1) PRIMARY KEY,

    Username VARCHAR(50) NOT NULL,

    Password VARCHAR(50) NOT NULL,

	Email varchar(50) NOT NULL
);


-- Register new user

INSERT INTO USERTABLE VALUES ('Oviya', 'Oviya123','John@gmail.com');
INSERT INTO USERTABLE VALUES ('Mohan', 'Mohan123','Mohan@gmail.com');

-- Login

SELECT * FROM USERTABLE WHERE Username = 'Oviya' AND Password = 'Oviya123';



-- Question table

CREATE TABLE Question (

    Id INT IDENTITY(1,1)PRIMARY KEY,

    Question VARCHAR(255) NOT NULL,

    Category VARCHAR(50) NOT NULL,

    UserName varchar(50) NOT NULL,


);

-- Create new question

INSERT INTO Question  VALUES ('How do I learn C#?', 'Programming', 'Mohan');
INSERT INTO Question  VALUES ('How do I learn ASP.net?', 'Programming', 'Vamsi');
INSERT INTO Question  VALUES ('How do I learn MVC?', 'Programming','Oviya');

-- Get all questions

SELECT * FROM Question;


-- Get questions by category

SELECT * FROM Question WHERE Category = 'Programming';


-- Get questions by search string

SELECT * FROM Question WHERE Question LIKE '%C#%';

-- Answer table

CREATE TABLE Answer (

    Id INT IDENTITY(1,1) PRIMARY KEY,

    Answer VARCHAR(255) NOT NULL,

    QuestionId INT NOT NULL,

    UserName Varchar(50) NOT NULL,

    
);


-- Create new answer

INSERT INTO Answer  VALUES ('You can learn C# by reading books and practicing coding.', 1, 'Mohan');


-- Get all answers for a question

SELECT * FROM Answer WHERE QuestionId = 1;

-- Create Tbale for ADMIN

CREATE TABLE ADMINTABLE(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Username varchar(50) NOT NULL,
	Password varchar(50) NOT NULL
	)
	
	-- Add new Admin

	insert into ADMINTABLE values ('Mohan','Mohan123')

	--Select all admin details
	
	SELECT * FROM ADMINTABLE