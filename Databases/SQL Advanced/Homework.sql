USE TelerikAcademy

--Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees)

--Write a SQL query to find the names and salaries of the employees that have a 
--salary that is up to 10% higher than the minimal salary for the company
SELECT FirstName, LastName, Salary
FROM Employees
	WHERE Salary <= 
	((SELECT MIN(Salary) FROM Employees)*11/10)

--Write a SQL query to find the full name, salary and department of the employees 
--that take the minimal salary in their department
SELECT FirstName + ' ' + LastName AS FullName, Salary, d.Name AS DepartmentName
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	AND Salary = (SELECT MIN(Salary) FROM Employees emp WHERE e.DepartmentID = emp.DepartmentID)

--Write a SQL query to find the average salary in the department #1
SELECT AVG(Salary) 
FROM Employees
WHERE DepartmentID = 1

--Write a SQL query to find the average salary in the "Sales" department
SELECT AVG(Salary) 
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	AND d.Name = 'Sales'

--Write a SQL query to find the number of employees in the "Sales" department
SELECT COUNT(*)
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	AND d.Name = 'Sales'

--Write a SQL query to find the number of all employees that have manager
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NOT NULL

--Write a SQL query to find the number of all employees that have no manager
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL

--Write a SQL query to find all departments and the average salary for each of them
SELECT AVG(Salary)
FROM Employees e
GROUP BY e.DepartmentID

--Write a SQL query to find the count of all employees in each department and for each town
SELECT COUNT(*) AS [Count]
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
GROUP BY DepartmentID, TownID

--Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name
SELECT m.FirstName + ' ' + m.LastName AS ManagerName
FROM Employees e
	JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5

--Write a SQL query to find all employees along with their managers. For employees
--that do not have manager display the value "(no manager)"
SELECT e.FirstName + ' ' + e.LastName AS EmploeeName,
	   ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS ManagarName
FROM Employees e
	LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

--Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
--Use the built-in LEN(str) function
SELECT e.FirstName + ' ' + e.LastName AS EmploeeName
FROM Employees e
WHERE LEN(e.LastName) = 5

--Write a SQL query to display the current date and time in the following format
--"day.month.year hour:minutes:seconds:milliseconds"
SELECT 
CONVERT(varchar(20), GETDATE(), 104)
 + ' ' +
CONVERT(varchar(20), GETDATE(), 114) 
AS Date

--Write a SQL statement to create a table Users. Users should have username, password, full name and last login time
--    Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--    Define the primary key column as identity to facilitate inserting records.
--    Define unique constraint to avoid repeating usernames.
--    Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users(
	Id int IDENTITY,
	Username nvarchar(20) NOT NULL UNIQUE,
	Password nvarchar(20) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastLoginTime datetime NULL,

	CONSTRAINT PK_Users PRIMARY KEY(Id),
	CHECK(LEN(Password)>=5)
)

--Write a SQL statement to create a view that displays the users from the Users table that have been in the system today
CREATE VIEW [UsersView] AS
SELECT * FROM Users
WHERE DAY(LastLoginTime) = DAY(GETDATE())

--Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint)
CREATE TABLE Groups (
	Id  int IDENTITY,
	Name nvarchar(50) UNIQUE NOT NULL,
	CONSTRAINT PK_Groups PRIMARY KEY(Id)
)

--Write a SQL statement to add a column GroupID to the table Users
--    Fill some data in this new column and as well in the `Groups table.
--    Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

ALTER TABLE Users
ADD GroupId int
CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupId)
	REFERENCES Groups(Id)

UPDATE Users
SET GroupId = 1

--Write SQL statements to insert several records in the Users and Groups tables
INSERT INTO Users
VALUES ('Vankata','vani156','Ivan Petkanov','2017/05/15', 2)

INSERT INTO Groups
VALUES ('Physics')

--Write SQL statements to update some of the records in the Users and Groups tables
UPDATE Users
SET Username = 'Anonymous'
WHERE FullName LIKE '%Negoshov'

UPDATE Groups
SET Name = 'Psychology'
WHERE Name = 'Physics'

--Write SQL statements to delete some of the records from the Users and Groups tables
DELETE FROM Users
WHERE GroupId = 2

DELETE FROM Groups
WHERE Name = 'Psychology'

--Write SQL statements to insert in the Users table the names of all employees from the Employees table
--    Combine the first and last names as a full name.
--    For username use the first letter of the first name + the last name (in lowercase).
--    Use the same for the password, and NULL for last login time.

INSERT INTO Homework.dbo.Users
SELECT 
SUBSTRING(e.FirstName,0,2) + ' ' + e.LastName,
SUBSTRING(e.FirstName,0,2) + ' ' + e.LastName,
e.FirstName +' ' + e.LastName,
NULL,
1
FROM Employees e

--Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010
UPDATE Homework.dbo.Users
SET Password = NULL
WHERE LastLoginTime < CONVERT(nvarchar(20),'10.03.2010')

--Write a SQL statement that deletes all users without passwords (NULL password)
DELETE FROM Users
WHERE Password IS NULL

--Write a SQL query to display the average employee salary by department and job title
SELECT AVG(Salary) FROM Employees
GROUP BY DepartmentID, JobTitle

--Write a SQL query to display the minimal employee salary by department and job title along with the
--name of some of the employees that take it
SELECT FirstName, LastName, Salary FROM Employees e
WHERE Salary = (
	SELECT MIN(Salary) FROM Employees emp
	GROUP BY DepartmentID, JobTitle
	HAVING e.DepartmentID = emp.DepartmentID AND e.JobTitle = emp.JobTitle
)

--Write a SQL query to display the town where maximal number of employees work
SELECT TOP 1 Name FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(*)

--Write a SQL query to display the number of managers from each town
SELECT COUNT(DISTINCT e.ManagerID) AS [ManagersCount] FROM Employees e
	JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
	ON m.AddressID = a.AddressID
GROUP BY a.TownID
ORDER BY [ManagersCount]

--Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments)
--    Don't forget to define identity, primary key and appropriate foreign key.
--    Issue few SQL statements to insert, update and delete of some data in the table.

CREATE TABLE WorkHours(
	Id int IDENTITY,
	Task nvarchar(30),
	Date date NOT NULL,
	Hours int NOT NULL,
	Comments nvarchar(100),
	EmployeeId int NOT NULL,

	CONSTRAINT PK_WorkHours PRIMARY KEY(Id),
	CONSTRAINT FK_WorkHours_Employee FOREIGN KEY(EmployeeId)
		REFERENCES Employees(EmployeeID)
)

INSERT INTO WorkHours
SELECT e.JobTitle + 'ing', GETDATE(), 8, NULL, e.EmployeeID FROM Employees e

UPDATE WorkHours
SET Comments = 'Great worker!'
WHERE EmployeeId % 5 = 0

DELETE FROM WorkHours
WHERE EmployeeId % 10 = 0

--Start a database transaction, delete all employees from the 'Sales' department along
--with all dependent records from the pother tables. At the end rollback the transaction
BEGIN TRAN
DELETE Employees
FROM TelerikAcademy.dbo.Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ROLLBACK TRAN

--Start a database transaction and drop the table EmployeesProjects
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN