USE TelerikAcademy
SELECT * 
FROM Departments

--5. 
SELECT Name
FROM Departments

--6. 
SELECT Salary
FROM Employees

--7.
SELECT FirstName + ' ' + LastName as [Full Name]
FROM Employees

--8. 
SELECT FirstName + '.' + LastName + '@telerik.com' AS 'Full Email Addresses'
FROM Employees

--9.
SELECT DISTINCT Salary
FROM Employees

--10. 
SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative'

--11.
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE FirstName LIKE 'SA%' 

--12.
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE LastName LIKE '%ei%'

--13.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--14.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--15.
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE ManagerID IS NULL

--16.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--17.
SELECT TOP (5) FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
ORDER BY Salary DESC

--18.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.AddressText AS [Address]
FROM Employees e
INNER JOIN Addresses a
ON e.AddressID = a.AddressID

--19.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.AddressText AS [People Address]
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

--20.
SELECT e.FirstName + ' ' + e.LastName AS Employe, m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e
	LEFT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

--21. 
SELECT e.FirstName + ' ' + e.LastName AS [Employe], a.AddressText AS [Address], m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
			JOIN Employees m
				ON e.ManagerID = m.EmployeeID

--22.
SELECT Name AS [Department/Town Name] FROM Departments
UNION
SELECT Name AS [Department/Town Name] FROM Towns

--23.
SELECT e.FirstName + ' ' + e.LastName AS Employe, m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e
	RIGHT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS Employe, m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e
	LEFT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

--24.
SELECT e.FirstName + ' ' + e.LastName AS 'Employe Name', e.HireDate AS [Date], d.Name AS [Department]
FROM Employees e
	JOIN Departments d
		ON (e.DepartmentID = d.DepartmentID
		AND d.Name = 'Sales' OR d.Name = 'Finance'
		AND e.HireDate BETWEEN '1995-01-01' AND '2005-12-31')
ORDER BY e.HireDate
