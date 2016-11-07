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
SELECT COUNT(*) AS [Number of employees that don't have Manager]
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
