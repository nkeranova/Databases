USE master
GO

-- Create a db 
CREATE DATABASE PeopleDB
GO

USE PeopleDB
GO

-- Create a new table named 'Persons'
CREATE TABLE Persons 
(
	PersonsId int IDENTITY NOT NULL PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN varchar(9) NOT NULL
)
GO

-- Create a new table named 'Accounts'
CREATE TABLE Accounts 
(
	Id int IDENTITY NOT NULL PRIMARY KEY,
	PersonId int NOT NULL FOREIGN KEY REFERENCES Persons(PersonsId),
	Balance money NOT NULL
)
GO

--INSERT some values into both tables and repeat this action a few times
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES('Natalie', 'Klein', '9212315698')

INSERT INTO Accounts(PersonID, Balance)
VALUES (3, 789058.67)

--1.
CREATE PROC dbo.usp_SelectFullNamesOfAllPersons
AS
	SELECT DISTINCT CONCAT(FirstName, LastName) AS [Full Name]
	FROM Persons
GO

--2.
CREATE PROC dbo.usp_ReturnsAllPersonsWithMoreMoneyInAccountsThanGivenParameter
(@givenParameter money)
AS
SELECT CONCAT(p.FirstName, p.LastName) AS [Full Name], a.Balance
FROM Persons p
	JOIN Accounts a
		ON a.PersonID = p.PersonID
WHERE a.Balance > @givenParameter
ORDER BY a.Balance DESC

--3.
CREATE FUNCTION unf_CalculateAndReturnSum(@sum money, @interestRate float, @numberOfMonths int)
RETURNS money
AS

BEGIN
	RETURN @sum * (1 + @interestRate / 12) * @numberOfMonths
END
GO

--Test it
USE PeopleDB
SELECT Balance, ROUND(dbo.unf_CalculateAndReturnSum(Balance, 3.50, 11), 2) AS [Bonus]
FROM Accounts

--4.
USE PeopleDB
GO

CREATE PROC dbo.usp_CalculateInterestRateToAccountPerMonth(@accountId int, @interestRate float)
AS
	DECLARE @balance money
	SELECT @balance = Balance FROM Accounts WHERE PersonID = AccountID

	DECLARE @newBalance money
	SELECT @newBalance = dbo.unf_CalculateAndReturnSum(@balance,  @interestRate, 3)

	SELECT CONCAT(p.FirstName, p.LastName) AS [Full Name], a.Balance, @newBalance AS [New balance]
	FROM Persons p
		JOIN Accounts a
			ON p.PersonID = a.AccountID
	WHERE a.AccountID = @accountId
GO

--Test
EXEC dbo.usp_CalculateInterestRateToAccountPerMonth 1, 0.5
EXEC dbo.usp_CalculateInterestRateToAccountPerMonth 2, 2.5
EXEC dbo.usp_CalculateInterestRateToAccountPerMonth 3, 1.5

--5.
CREATE PROC dbo.usp_WithdrawMoney(@AccountId int, @money money)
AS	
	BEGIN TRANSACTION
		UPDATE Accounts
		SET Balance -= @money
		WHERE AccountID = @AccountId
	COMMIT TRANSACTION
GO

CREATE PROC dbo.usp_DepositMoney(@AccountId int, @money money)
AS	
	BEGIN TRANSACTION
		UPDATE Accounts
		SET Balance += @money
		WHERE AccountID = @AccountId
	COMMIT TRANSACTION
GO

EXEC dbo.usp_WithdrawMoney 5, 678

EXEC dbo.usp_DepositMoney 3, 500

--6.
CREATE TABLE Logs 
(
    LogId int IDENTITY PRIMARY KEY,
    AccountId int NOT NULL FOREIGN KEY REFERENCES Accounts(AccountId),
    OldSum money NOT NULL,
    NewSum money NOT NULL
)

CREATE TRIGGER tr_UpdateAccountBalance ON Accounts FOR UPDATE
AS
    DECLARE @oldSum money;
    SELECT @oldSum = Balance FROM deleted;

    INSERT INTO Logs(AccountId, OldSum, NewSum)
        SELECT AccountId, @oldSum, Balance
        FROM inserted
GO

EXEC usp_WithdrawMoney 1, 500

EXEC usp_DepositMoney 3, 2000

--7.
USE TelerikAcademy
GO

CREATE FUNCTION ufn_SearchForWordsInGivenPattern(@pattern nvarchar(255))
	RETURNS @MatchedNames TABLE (Name varchar(50))
AS
BEGIN
	INSERT @MatchedNames
	SELECT * 
	FROM
		(SELECT e.FirstName FROM Employees e
        UNION
        SELECT e.LastName FROM Employees e
        UNION 
        SELECT t.Name FROM Towns t) as temp(name)
    WHERE PATINDEX('%[' + @pattern + ']', Name) > 0
	RETURN
END
GO

-- Test
-- SELECT * FROM dbo.ufn_SearchForWordsInGivenPattern('oistmiahf')

--8.
DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT emp1.FirstName, emp1.LastName, t1.Name, emp2.FirstName, emp2.LastName
    FROM Employees emp1
    JOIN Addresses a1
        ON emp1.AddressID = a1.AddressID
    JOIN Towns t1
        ON a1.TownID = t1.TownID,
        Employees emp2
    JOIN Addresses a2
        ON emp2.AddressID = a2.AddressID
    JOIN Towns t2
        ON a2.TownID = t2.TownID
    WHERE t1.TownID = t2.TownID AND emp1.EmployeeID != emp2.EmployeeID
    ORDER BY emp1.FirstName, emp2.FirstName

OPEN empCursor

DECLARE @firstName1 nvarchar(50), 
        @lastName1 nvarchar(50),
        @townName nvarchar(50),
        @firstName2 nvarchar(50),
        @lastName2 nvarchar(50)
FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2

DECLARE @counter int;
SET @counter = 0;

WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @counter = @counter + 1;

		PRINT @firstName1 + ' ' + @lastName1 + 
			  '     ' + @townName + '       ' +
			  @firstName2 + ' ' + @lastName2;

		FETCH NEXT FROM empCursor 
		INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2
	END

print 'Total records: ' + CAST(@counter AS nvarchar(10));

CLOSE empCursor
DEALLOCATE empCursor

--9.
IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

-- Remove the aggregate and assembly if they're there
IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'C:\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

--- CURSOR
DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT t.Name, dbo.concat(e.FirstName + ' ' + e.LastName, ', ')
    FROM Towns t
    JOIN Addresses a
        ON t.TownID = a.TownID
    JOIN Employees e
        ON a.AddressID = e.AddressID
    GROUP BY t.Name
    ORDER BY t.Name

OPEN empCursor

DECLARE @townName nvarchar(50), 
        @employeesNames nvarchar(max)        
FETCH NEXT FROM empCursor INTO @townName, @employeesNames

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @townName + ' -> ' + @employeesNames;

    FETCH NEXT FROM empCursor 
    INTO @townName, @employeesNames
END

CLOSE empCursor
DEALLOCATE empCursor
GO

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO

--10.
IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

-- Remove the aggregate and assembly if they're there
IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'C:\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
FROM Employees
GO

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO
























