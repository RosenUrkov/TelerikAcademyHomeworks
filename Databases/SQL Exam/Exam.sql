USE SuperheroesUniverse

--List all superheroes in Earth
SELECT DISTINCT s.Id, s.Name FROM Superheroes s
	JOIN PlanetSuperheroes ps
	ON s.Id = ps.Superhero_Id
	JOIN Planets p
	ON ps.Planet_Id = p.Id
WHERE P.Name = 'Earth'
ORDER BY Id
GO

--List all superheroes with their powers and powerTypes
 SELECT s.Name AS Superhero, p.Name + ' (' + pt.Name + ')' AS Power
 FROM Superheroes s
	JOIN PowerSuperheroes ps
	ON s.Id = ps.Superhero_Id
	JOIN Powers p
	ON ps.Power_Id = p.Id
	JOIN PowerTypes pt
	ON p.PowerTypeId = pt.Id
GO

--List the top 5 planets, sorted by count of superheroes with alignment 'Good', then by Planet Name
SELECT TOP 5 p.Name AS Planet, COUNT(CASE WHEN a.Name = 'Good' THEN 1 ELSE NULL END) AS Protectors
FROM Planets p
	JOIN PlanetSuperheroes ps
	ON p.Id = ps.Planet_Id
	JOIN Superheroes s
	ON s.Id = ps.Superhero_Id
	JOIN Alignments a
	ON s.Alignment_Id = a.Id
GROUP BY p.Name
ORDER BY Protectors DESC, p.Name 
GO

--Create a stored procedure to edit superheroes Bio, by provided Superhero's Id and the new bio
CREATE PROCEDURE usp_UpdateSuperheroBio(@superheroId int, @bio ntext)
AS
	BEGIN
		UPDATE Superheroes
		SET Bio = @bio
		WHERE Id = @superheroId
	END
GO

--Create a stored prodecure, that gives full information about a superhero, by provided Superhero's Id
CREATE PROCEDURE usp_GetSuperheroInfo(@superheroId int)
AS
	BEGIN
		SELECT s.Id, s.Name, s.SecretIdentity AS [Secret Identity], s.Bio, 
			a.Name AS Alignment, p.Name AS Planet, pw.Name AS Power
		FROM Superheroes s
			JOIN Alignments a
			ON s.Alignment_Id = a.Id
			JOIN PlanetSuperheroes ps
			ON s.Id = ps.Superhero_Id
			JOIN Planets p
			ON ps.Planet_Id = p.Id
			JOIN PowerSuperheroes pws
			ON s.Id = pws.Superhero_Id
			JOIN Powers pw
			ON pws.Power_Id = pw.Id
		WHERE s.Id = @superheroId
	END
GO

EXEC usp_GetSuperheroInfo 5
GO

--Create a stored procedure that prints the number of heroes with 
--Good, Evil and Neutral alignment for each Planet
CREATE PROCEDURE usp_GetPlanetsWithHeroesCount
AS
	BEGIN
		SELECT p.Name AS Planet,
		COUNT(CASE WHEN a.Name = 'Good' THEN 1 ELSE NULL END) AS [Good heroes],
		COUNT(CASE WHEN a.Name = 'Neutral' THEN 1 ELSE NULL END) AS [Neutral heroes],
		COUNT(CASE WHEN a.Name = 'Evil' THEN 1 ELSE NULL END) AS [Evil heroes]
		FROM Planets p
			JOIN PlanetSuperheroes ps
			ON p.Id = ps.Planet_Id
			JOIN Superheroes s
			ON ps.Superhero_Id = s.Id
			JOIN Alignments a
			ON s.Alignment_Id = a.Id
		GROUP BY p.Name
		ORDER BY COUNT(a.Name) DESC
	END
GO

EXEC usp_GetPlanetsWithHeroesCount
GO

--Create a stored procedure for creating a Superhero, with provided name, secret identity,
--bio, alignment, a planet and 3 powers (with their types)
CREATE PROCEDURE usp_InsertNewPowerType(@powerTypeName nvarchar(40))
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM PowerTypes WHERE Name = @powerTypeName)
		INSERT INTO PowerTypes
		VALUES(@powerTypeName)
	END
GO

CREATE PROCEDURE usp_InsertNewPower(@powerName nvarchar(40), @powerTypeId int, @superheroId int)
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM Powers WHERE Name = @powerName)
		INSERT INTO Powers
		VALUES(@powerName, @powerTypeId)

		DECLARE @powerId int = (SELECT Id FROM Powers WHERE Name = @powerName)		
		INSERT INTO PowerSuperheroes
		VALUES (@powerId, @superheroId)
	END
GO

CREATE PROCEDURE usp_CreateSuperhero
	(@name nvarchar(40), @secretIdentity nvarchar(40), @bio ntext,
	 @alignment nvarchar(40), @planet nvarchar(40),
	 @firstPowerName nvarchar(40), @firstPowerTypeName nvarchar(40),
	 @secondPowerName nvarchar(40), @secondPowerTypeName nvarchar(40),
	 @thirdPowerName nvarchar(40), @thirdPowerTypeName nvarchar(40))
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM Alignments WHERE Name = @alignment)
		INSERT INTO Alignments
		VALUES(@alignment)

		IF NOT EXISTS (SELECT * FROM Planets WHERE Name = @planet)
		INSERT INTO Planets
		VALUES(@planet)

		DECLARE @alignmentId INT = (SELECT Id FROM Alignments WHERE Name = @alignment)
		INSERT INTO Superheroes
		VALUES (@name, @secretIdentity, @alignmentId, @bio)		

		EXEC usp_InsertNewPowerType @firstPowerTypeName
		EXEC usp_InsertNewPowerType @secondPowerTypeName
		EXEC usp_InsertNewPowerType @thirdPowerTypeName

		DECLARE @superheroId INT = (SELECT Id FROM Superheroes WHERE Name = @name)
		DECLARE @powerTypeId INT = (SELECT Id FROM PowerTypes WHERE Name = @firstPowerTypeName)
		EXEC usp_InsertNewPower @firstPowerName, @powerTypeId, @superheroId

		SET @powerTypeId = (SELECT Id FROM PowerTypes WHERE Name = @secondPowerTypeName)
		EXEC usp_InsertNewPower @secondPowerName, @powerTypeId, @superheroId

		SET @powerTypeId = (SELECT Id FROM PowerTypes WHERE Name = @thirdPowerTypeName)
		EXEC usp_InsertNewPower @thirdPowerName, @powerTypeId, @superheroId		

		DECLARE @planetId INT = (SELECT Id FROM Planets WHERE Name = @planet)
		INSERT INTO PlanetSuperheroes
		VALUES (@planetId, @superheroId)
	END
GO

EXEC usp_CreateSuperhero 'Gosho', 'Wonder Woman', NULL, 'Neutral', 'Earth', 'Armored Suit', 'Magic', 'Speed', 'Tech', 'Yolo', 'Indeed'  
GO

--Create a stored procedure that prints the number of powers by alignment of their superheroes
CREATE PROCEDURE usp_PowersUsageByAlignment
AS
	BEGIN
		SELECT a.Name AS Alignment, COUNT(DISTINCT p.Id) AS [Powers Count] FROM Alignments a
			JOIN Superheroes s
			ON a.Id = s.Alignment_Id
			JOIN PowerSuperheroes ps
			ON s.Id = ps.Superhero_Id
			JOIN Powers p
			ON ps.Power_Id = p.Id
		GROUP BY a.Name
	END
GO

EXEC usp_PowersUsageByAlignment
GO