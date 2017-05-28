--Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN)
--and Accounts(Id(PK), PersonId(FK), Balance)
--    Insert few records for testing.
--    Write a stored procedure that selects the full names of all persons.
CREATE DATABASE MyDatabase
GO

USE MyDatabase

CREATE TABLE Persons(
	Id int PRIMARY KEY IDENTITY,
	FirstName nvarchar(20) NOT NULL, CHECK(LEN(FirstName) > 1),
	LastName nvarchar(20) NOT NULL, CHECK(LEN(LastName) > 1),
	SSN nvarchar(20) NOT NULL
)
GO

CREATE TABLE Accounts(
	Id int PRIMARY KEY IDENTITY,
	Balance money NOT NULL,
	PersonId int FOREIGN KEY REFERENCES Persons(Id) NOT NULL
)
GO

INSERT INTO Persons
VALUES 
('Ivan', 'Petkanov', '111215018'), 
('Pesho','Petrov','0001110101'),
('Mitko', 'Ivanov', '672089138');
GO

INSERT INTO Accounts
VALUES 
(200.50, 1), 
(600.23, 2),
(1000, 3);
GO

CREATE PROCEDURE usp_FullNamesOfPersons
AS
	BEGIN
		SELECT FirstName + ' ' + LastName AS FullName FROM Persons
	END
GO

EXEC usp_FullNamesOfPersons
GO

--Create a stored procedure that accepts a number as a parameter and returns
--all persons who have more money in their accounts than the supplied number
CREATE PROCEDURE usp_GetPersonsRicherThanAmount(@moneyAmount money)
AS
	BEGIN
		 SELECT FirstName, LastName, SSN, Balance FROM Persons p
			JOIN Accounts a
			ON p.Id = a.PersonId
				AND a.Balance > @moneyAmount
	END
GO

EXEC usp_GetPersonsRicherThanAmount 200.80
GO

--Create a function that accepts as parameters – sum, yearly interest rate and number of months
--    It should calculate and return the new sum.
--    Write a SELECT to test whether the function works as expected
CREATE FUNCTION fn_CalculateSum(@sum money, @yearlyInterestRate money, @monthsNumber int)
	RETURNS money
	BEGIN
		DECLARE @coefficient money = @yearlyInterestRate / 12 / 100 * @monthsNumber
		RETURN (@sum * (1 + @coefficient))
	END
GO

--Create a stored procedure that uses the function from the previous example
-- to give an interest to a person's account for one month.
--    It should take the AccountId and the interest rate as parameters
CREATE PROCEDURE usp_GetBalanceAfterOneMonth(@accountId int, @rate decimal)
AS
	BEGIN
		UPDATE Accounts
		SET Balance = dbo.fn_CalculateSum(Balance, @rate, 1)
		WHERE Id = @accountId
	END
GO

EXEC dbo.usp_GetBalanceAfterOneMonth 3, 120
GO

SELECT * FROM Persons p
JOIN Accounts a
ON p.Id = a.PersonId AND a.Id = 3
GO

--Add two more stored procedures WithdrawMoney(AccountId, money) and
--DepositMoney(AccountId, money) that operate in transactions
CREATE PROCEDURE usp_WithdrawMoney(@accountId int, @sum money)
AS
	BEGIN
		BEGIN TRAN

		DECLARE @balance money = (SELECT Balance FROM Accounts WHERE Id = @accountId)
		IF(@balance >= @sum)
			BEGIN
				UPDATE Accounts
				SET Balance = (Balance - @sum)
				WHERE Id = @accountId

				COMMIT
			END
		ELSE
			BEGIN
				PRINT 'Not enogh money in the balance!'	
				
				ROLLBACK			
			END
	END
GO

CREATE PROCEDURE usp_DepositMoney(@accountId int, @money money)
AS
	BEGIN
		BEGIN TRAN

		UPDATE Accounts
		SET Balance = (Balance + @money)
		WHERE Id = @accountId

		COMMIT
	END
GO

--Create another table – Logs(LogID, AccountID, OldSum, NewSum)
--    Add a trigger to the Accounts table that enters a new entry into the Logs
--	table every time the sum on an account changes.
CREATE TABLE Logs(
	Id int PRIMARY KEY IDENTITY,
	OldSum money NOT NULL,
	NewSum money NOT NULL,
	AccountId int FOREIGN KEY REFERENCES Accounts(Id) NOT NULL
)
GO

CREATE TRIGGER utr_AccountsLog ON Accounts AFTER UPDATE
AS
	BEGIN
		DECLARE @before money = (SELECT Balance FROM deleted),
			@after money = (SELECT Balance FROM inserted),
			@id int = (SELECT Id FROM inserted)

		INSERT INTO Logs
		VALUES(@before, @after, @id)
	END
GO

EXEC dbo.usp_WithdrawMoney 3, 200
GO

--Define a function in the database TelerikAcademy that returns all Employee's names
--(first or middle or last name) and all town's names that are comprised of given set of letters.
--    Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'
USE TelerikAcademy
GO

CREATE FUNCTION ufn_CheckLettersForName(@letters nvarchar(50), @name nvarchar(50))
RETURNS int
AS
	BEGIN
		DECLARE @index int = 1,
				@length int = LEN(@name),
				@currentChar nvarchar(1)
			
		WHILE(@index <= @length)
			BEGIN
				SET @currentChar = SUBSTRING(@name, @index, 1)
				IF(CHARINDEX(@currentChar, @letters) = 0)
					BEGIN
						RETURN 0
					END
								
				SET @index = @index + 1
			END

		RETURN 1
	END
GO

CREATE FUNCTION ufn_SearchFromLetters(@letters nvarchar(50))
RETURNS TABLE
AS 	
	RETURN (
		SELECT FirstName AS Name FROM Employees
			WHERE dbo.ufn_CheckLettersForName(@letters, FirstName) = 1
		UNION
		SELECT MiddleName AS Name FROM Employees
			WHERE MiddleName IS NOT NULL AND dbo.ufn_CheckLettersForName(@letters, MiddleName) = 1
		UNION
		SELECT LastName AS Name FROM Employees
			WHERE dbo.ufn_CheckLettersForName(@letters, LastName) = 1			
		UNION
		SELECT Name FROM Towns
			WHERE dbo.ufn_CheckLettersForName(@letters, Name) = 1
	)	
GO

SELECT * FROM ufn_SearchFromLetters('lBohReTwN')
GO