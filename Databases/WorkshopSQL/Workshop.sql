USE NORTHWND

--Create table Cities with (CityId, Name)
CREATE TABLE Cities(
	CityId INT PRIMARY KEY IDENTITY,
	Name nvarchar(30) NOT NULL
)

--Insert into Cities all the Cities from Employees, Suppliers, Customers tables 
--(RESULT: 95 row(s) affected)
INSERT INTO Cities
SELECT DISTINCT City FROM Employees
UNION
SELECT DISTINCT City FROM Suppliers
UNION
SELECT DISTINCT City FROM Customers

--Add CityId into Employees, Suppliers, Customers tables which is Foreign Key to CityId in Cities
ALTER TABLE Employees
ADD CityId int FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Suppliers
ADD CityId int FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Customers
ADD CityId int FOREIGN KEY REFERENCES Cities(CityId)

--Update Employees, Suppliers, Customers tables with CityId which is in the Cities table
UPDATE Employees
SET CityId = (SELECT CityId FROM Cities
				WHERE City = Name)

UPDATE Suppliers
SET CityId = (SELECT CityId FROM Cities
				WHERE City = Name)

UPDATE Customers
SET CityId = (SELECT CityId FROM Cities
				WHERE City = Name)

--Make the column Name in Cities Unique
ALTER TABLE Cities
ADD UNIQUE(Name)

--Now after looking at the database again we found there are Cities (ShipCity) in the 
--Orders table as well :D (always read before start coding). Insert those cities please.
-- (RESULT: 1 row(s) affected)
INSERT INTO Cities
SELECT DISTINCT ShipCity FROM Orders o
WHERE NOT EXISTS (SELECT * FROM Cities c
				WHERE c.Name = o.ShipCity)

--Add CityId column in Orders with Foreign Key to CityId in Cities
ALTER TABLE Orders
ADD CityId int FOREIGN KEY REFERENCES Cities(CityId)

--Now rename that column to be ShipCityId to be consistent (use stored procedure :) )
EXEC sp_RENAME 'Orders.CityId', 'ShipCityId', 'COLUMN'

--Update ShipCityId in Orders table with values from Cities table (RESULT: 830 row(s) affected)
UPDATE Orders
SET ShipCityId = (SELECT CityId FROM Cities
				WHERE ShipCity = Name)

--Drop column ShipCity from Orders
ALTER TABLE Orders
DROP COLUMN ShipCity

--Create table Countries with columns CountryId and Name (Unique)
CREATE TABLE Countries(
	CountryId int PRIMARY KEY IDENTITY,
	Name nvarchar(30) UNIQUE NOT NULL
)

--Add CountryId to Cities with Foreign Key to CountryId in Countries
ALTER TABLE Cities
ADD CountryId int FOREIGN KEY REFERENCES Countries(CountryId)

--Insert all the Countries from Employees, Customers, Suppliers and Orders 
--(RESULT: 25 row(s) affected)
INSERT INTO Countries
SELECT DISTINCT Country FROM Employees
UNION
SELECT DISTINCT Country FROM Customers
UNION
SELECT DISTINCT Country FROM Suppliers
UNION
SELECT DISTINCT ShipCountry AS Country FROM Orders

--Update CountryId in Cities table with values from Countries table
UPDATE Cities
SET CountryId = c.CountryId
FROM Countries c
	JOIN Employees e
	ON c.Name = e.Country
WHERE e.City = Cities.Name

UPDATE Cities
SET CountryId = c.CountryId
FROM Countries c
	JOIN Customers e
	ON c.Name = e.Country
WHERE e.City = Cities.Name

UPDATE Cities
SET CountryId = c.CountryId
FROM Countries c
	JOIN Suppliers e
	ON c.Name = e.Country
WHERE e.City = Cities.Name

UPDATE Cities
SET CountryId = c.CountryId
FROM Countries c
	JOIN Orders e
	ON c.Name = e.ShipCountry
WHERE e.ShipCityId = Cities.CityId

--Drop column City and ShipCity from Employees, Suppliers, Customers and Orders tables
ALTER TABLE Employees
DROP COLUMN City

ALTER TABLE Suppliers
DROP COLUMN City

DROP INDEX City ON Customers
ALTER TABLE Customers
DROP COLUMN City

ALTER TABLE Orders
DROP COLUMN ShipCity

--Drop column Country and ShipCountry from Employees, Customers, Suppliers and Orders tables
ALTER TABLE Employees
DROP COLUMN Country

ALTER TABLE Customers
DROP COLUMN Country

ALTER TABLE Suppliers
DROP COLUMN Country

ALTER TABLE Orders
DROP COLUMN ShipCountry