USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Name], Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

--2.
DECLARE @MinSalary int = (SELECT MIN(Salary) FROM Employees)
SELECT FirstName + ' ' + LastName AS [Name], Salary
FROM Employees
--WHERE Salary = 1.1 * @MinSalary
WHERE Salary BETWEEN @MinSalary AND 1.1 * @MinSalary

--3.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary, d.Name AS Department
FROM Employees e
	JOIN Departments d
		ON (e.DepartmentID = d.DepartmentID
		AND Salary BETWEEN @MinSalary AND 1.1 * @MinSalary)
ORDER BY e.Salary

--OR
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name], e.Salary, d.Name
	FROM Employees e 
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
    WHERE Salary =
        (SELECT MIN(Salary) FROM Employees emp
        WHERE emp.DepartmentID = d.DepartmentID)
    ORDER BY Salary

--4.
SELECT AVG(Salary) AS [Avarage Salary]
FROM Employees
WHERE DepartmentID = 1

--5.
SELECT AVG(e.Salary) AS [Avarage Salary]
FROM Employees e
	JOIN Departments d
		ON(d.DepartmentID = e.DepartmentID
		AND d.Name = 'Sales')

--6.
SELECT COUNT(*) AS [Number of employees]
FROM Employees e
	JOIN Departments d
	ON (d.DepartmentID = e.EmployeeID)
WHERE d.Name = 'Sales'

--7.
SELECT COUNT(*) AS [Number of employees that have Manager]
FROM Employees
WHERE ManagerID IS NOT NULL

--8.
SELECT COUNT(*) AS [Number of employees that dont have Manager]
FROM Employees
WHERE ManagerID IS NULL

--9.
SELECT AVG(Salary) AS [Avarage salary], d.Name AS [Department name]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name
ORDER BY [Avarage salary]

--10.
SELECT COUNT(e.EmployeeID) AS [Employees count], t.Name AS [Town], d.Name AS [Department]
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY [Employees count] DESC

--11.
SELECT e.EmployeeID AS [Manager ID],
	   CONCAT(e.FirstName, ' ', e.LastName) AS [Manager Name],
	   COUNT(e.EmployeeID) AS [Employees Count]
	FROM Employees e
	JOIN Employees emp
		ON emp.ManagerID = e.EmployeeID
	GROUP BY e.EmployeeID, e.FirstName, e.LastName
	HAVING COUNT(e.EmployeeID) = 5

--12.
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Employee Name],
		COALESCE(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager Name]
FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID

--13.
SELECT CONCAT(FirstName, ' ', LastName) AS [Employee Name with 5 chars in Last Name]
FROM Employees
WHERE LEN(LastName) = 5	
ORDER BY FirstName

--14.
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff') AS [Current Date]

--OR
SELECT CONVERT(varchar(10), GETDATE(), 104) AS [New Date]

--15.
CREATE TABLE UsersNewest
(
	UsersID int IDENTITY NOT NULL PRIMARY KEY,
	Username nvarchar(30) NOT NULL UNIQUE, 
	Pass nvarchar(30) NOT NULL CHECK(LEN(Pass) = 5), 
	FullName nvarchar(30) NOT NULL,
	LastLogin DATETIME NOT NULL 
);

--16.
USE TelerikAcademy
GO

CREATE VIEW [Logged Users Today] AS
SELECT Username
FROM UsersNewest
WHERE DATEDIFF(DAY, LastLogin, GETDATE()) = 0

--17.
CREATE TABLE Groups
(
	GroupID int identity not null PRIMARY KEY,
	Name nvarchar(30) not null UNIQUE
);

--18.
ALTER TABLE UsersNewest
	ADD GroupID int NOT NULL
GO

ALTER TABLE UsersNewest
	ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupId)
	REFERENCES Groups(GroupId)
GO

--19.
INSERT INTO Groups VALUES
	('TU Sofia'),
    ('SU Sofia'),
    ('Code school'),
    ('Gmail'),
    ('Telerik Academy'),
    ('SoftUni')

INSERT INTO Users
	VALUES
	('username1', 'qwerty1', 'Unnamed1', '2010-3-06 00:00:00', 1),
    ('username2', 'qwerty2', 'Unnamed2', '2010-3-07 00:00:00', 2),
    ('username3', 'qwerty3', 'Unnamed3', '2010-3-08 00:00:00', 3),
    ('username4', 'qwerty4', 'Unnamed4', '2010-3-09 00:00:00', 4),
    ('username5', 'qwerty5', 'Unnamed5', '2010-3-10 00:00:00', 5),
    ('username6', 'qwerty6', 'Unnamed6', '2010-3-11 00:00:00', 6),
    ('username7', 'qwerty7', 'Unnamed7', '2010-3-12 00:00:00', 7),
    ('username8', 'qwerty8', 'Unnamed8', '2010-3-13 00:00:00', 8),
    ('username9', 'qwerty9', 'Unnamed9', '2010-3-14 00:00:00', 9)

--20.
UPDATE Users
	SET Pass = REPLACE(Pass, 'qwerty6', 'newPass')
	WHERE FullName = 'Unnamed6'

--21.
DELETE FROM Users
WHERE Pass = 'newPass'

DELETE FROM Groups
WHERE Name = 'TU Sofia'

DELETE FROM Users
    WHERE GroupId IN (5, 7, 9)

--22.
INSERT INTO Users (Username, FullName, Pass)
        (SELECT LOWER(CONCAT(FirstName, '.', LastName)),
                CONCAT(FirstName, ' ', LastName),
                LOWER(CONCAT(FirstName, '.', LastName))
        FROM Employees)
GO

--23.
UPDATE Users
    SET Pass = NULL
    WHERE DATEDIFF(day, LastLoginTime, '2010-3-10 00:00:00') > 0


--24.
DELETE * FROM Users
WHERE Pass IS NULL

--25.
SELECT AVG(Salary) AS [Average Salary], d.Name AS [Department Name], e.JobTitle
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY AVG(Salary) DESC

--26.
SELECT MIN(Salary) AS [Minimum Salary], d.Name AS [Department Name], e.JobTitle, MIN(CONCAT(e.FirstName, e.LastName)) AS [Full Name]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY MIN(Salary)

--27.
SELECT TOP 1 t.Name AS [Town], COUNT(e.EmployeeID) AS [Employees count]
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
			JOIN Towns t
				ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Employees count] --DESC

--28.
SELECT TOP 1 t.Name AS [Town], COUNT(e.EmployeeID) AS [Manager count]
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
			JOIN Towns t
				ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Manager count] DESC

--29.
--- TABLE: WorkHours
CREATE TABLE WorkHours (
    WorkReportId int IDENTITY,
    EmployeeId Int NOT NULL,
    OnDate DATETIME NOT NULL,
    Task nvarchar(256) NOT NULL,
    Hours Int NOT NULL,
    Comments nvarchar(256),
    CONSTRAINT PK_Id PRIMARY KEY(WorkReportId),
    CONSTRAINT FK_Employees_WorkHours 
        FOREIGN KEY (EmployeeId)
        REFERENCES Employees(EmployeeId)
) 
GO

--- INSERT
DECLARE @counter int;
SET @counter = 20;
WHILE @counter > 0
BEGIN
    INSERT INTO WorkHours(EmployeeId, OnDate, Task, [Hours])
    VALUES (@counter, GETDATE(), 'TASK: ' + CONVERT(varchar(10), @counter), @counter)
    SET @counter = @counter - 1
END

--- UPDATE
UPDATE WorkHours
    SET Comments = 'Work hard or go home!'
    WHERE [Hours] > 10

--- DELETE
DELETE 
    FROM WorkHours
    WHERE EmployeeId IN (1, 3, 5, 7, 13)

--- TABLE: WorkHoursLogs
CREATE TABLE WorkHoursLogs (
    WorkLogId int,
    EmployeeId Int NOT NULL,
    OnDate DATETIME NOT NULL,
    Task nvarchar(256) NOT NULL,
    Hours Int NOT NULL,
    Comments nvarchar(256),
    [Action] nvarchar(50) NOT NULL,
    CONSTRAINT FK_Employees_WorkHoursLogs
        FOREIGN KEY (EmployeeId)
        REFERENCES Employees(EmployeeId),
    CONSTRAINT [CC_WorkReportsLogs] CHECK ([Action] IN ('Insert', 'Delete', 'DeleteUpdate', 'InsertUpdate'))
) 
GO

--- TRIGGER FOR INSERT
CREATE TRIGGER tr_InsertWorkReports ON WorkHours FOR INSERT
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'Insert'
    FROM inserted
GO

--- TRIGGER FOR DELETE
CREATE TRIGGER tr_DeleteWorkReports ON WorkHours FOR DELETE
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'Delete'
    FROM deleted
GO

--- TRIGGER FOR UPDATE
CREATE TRIGGER tr_UpdateWorkReports ON WorkHours FOR UPDATE
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'InsertUpdate'
    FROM inserted

INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'DeleteUpdate'
    FROM deleted
GO

--- TEST TRIGGERS
DELETE 
    FROM WorkHoursLogs

INSERT INTO WorkHours(EmployeeId, OnDate, Task, [Hours])
    VALUES (25, GETDATE(), 'TASK: 25', 25)

DELETE 
    FROM WorkHours
    WHERE EmployeeId = 25

UPDATE WorkHours
    SET Comments = 'Updated'
    WHERE EmployeeId = 2

--30.
BEGIN TRAN

    ALTER TABLE Departments
        DROP CONSTRAINT FK_Departments_Employees
    GO

    DELETE *
        FROM Employees e
        JOIN Departments d
            ON e.DepartmentID = d.DepartmentID
        WHERE d.Name = 'Sales'

ROLLBACK TRAN

--31.
BEGIN TRANSACTION

    DROP TABLE EmployeesProjects

ROLLBACK TRANSACTION

--32.
BEGIN TRANSACTION

    SELECT * 
        INTO #TempEmployeesProjects  --- Create new table
        FROM EmployeesProjects

    DROP TABLE EmployeesProjects

    SELECT * 
        INTO EmployeesProjects --- Create new table
        FROM #TempEmployeesProjects

    DROP TABLE #TempEmployeesProjects

ROLLBACK TRANSACTION