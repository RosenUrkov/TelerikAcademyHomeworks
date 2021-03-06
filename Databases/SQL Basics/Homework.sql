USE TelerikAcademy

--Write a SQL query to find all information about all departments
SELECT * FROM Departments

--Write a SQL query to find all department names
SELECT Name FROM Departments

--Write a SQL query to find the salary of each employee
SELECT Salary FROM Employees

--Write a SQL to find the full name of each employee
SELECT FirstName + ' ' + LastName AS FullName FROM Employees

--Write a SQL query to find the email addresses of each employee (by his first and last name). 
--Consider that the mail domain is telerik.com. Emails should look like �John.Doe@telerik.com". 
--The produced column should be named "Full Email Addresses"
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses] 
FROM Employees

--Write a SQL query to find all different employee salaries
SELECT DISTINCT Salary FROM Employees

--Write a SQL query to find all information about the employees whose job title is �Sales Representative�
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

--Write a SQL query to find the names of all employees whose first name starts with "SA"
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

--Write a SQL query to find the names of all employees whose last name contains "ei"
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

--Write a SQL query to find the salary of all employees whose salary is in the range [20000�30000]
SELECT Salary FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600
SELECT FirstName, LastName FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--Write a SQL query to find all employees that do not have manager
SELECT FirstName, LastName FROM Employees
WHERE ManagerID IS NULL

--Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--Write a SQL query to find the top 5 best paid employees
SELECT TOP 5 FirstName, LastName, Salary 
FROM Employees
ORDER BY Salary DESC

--Write a SQL query to find all employees along with their address. Use inner join with ON clause
SELECT FirstName + ' ' + LastName AS FullName, a.AddressText 
FROM Employees e
	JOIN Addresses a 
	ON e.AddressID = a.AddressID

--Write a SQL query to find all employees and their address. Use equijoins
SELECT e.FirstName + ' ' + e.LastName AS Name, a.AddressText 
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

--Write a SQL query to find all employees along with their manager
SELECT e.FirstName + ' ' + e.LastName AS EmploeeName, emp.FirstName + ' ' + emp.LastName AS ManagerName 
FROM Employees e
	JOIN Employees emp
	ON e.ManagerID = emp.EmployeeID

--Write a SQL query to find all employees, along with their manager and their address. 
--Join the 3 tables: Employees e, Employees m and Addresses a
SELECT		e.FirstName + ' ' + e.LastName AS EmploeeName,
		m.FirstName + ' ' + m.LastName AS ManagerName,
		a.AddressText
FROM Employees e
	JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
	ON e.AddressID = a.AddressID

--Write a SQL query to find all departments and all town names as a single list. Use UNION
SELECT Name
FROM Departments
UNION
SELECT Name
FROM Towns

--Write a SQL query to find all the employees and the manager for each of them along with the employees
--that do not have manager. Use right outer join. Rewrite the query to use left outer join
--// RIGHT OUTER JOIN
SELECT  	e.FirstName + ' ' + e.LastName AS EmploeeName,
		m.FirstName + ' ' + m.LastName AS ManagerName
FROM Employees m
	RIGHT OUTER JOIN Employees e
	ON e.ManagerID = m.EmployeeID

--// LEFT OUTER JOIN
SELECT 		e.FirstName + ' ' + e.LastName AS EmploeeName,
		m.FirstName + ' ' + m.LastName AS ManagerName
FROM Employees e
	LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

--Write a SQL query to find the names of all employees from the departments
--"Sales" and "Finance" whose hire year is between 1995 and 2005
SELECT e.FirstName + ' ' + e.LastName AS EmploeeName
FROM Employees e
	JOIN Departments d
	ON (e.DepartmentID = d.DepartmentID
	AND d.Name IN ('Sales','Finance')
	AND e.HireDate BETWEEN '1/1/1995' AND '1/1/2005')