-- First solution
SELECT ([FirstName] + ' ' + [LastName]) AS [FullName], [Salary]
FROM [Employees]
WHERE [Salary] BETWEEN 100000 AND 150000
ORDER BY [Salary] ASC


-- Second solution
SELECT ([FirstName] + ' ' + [LastName]) AS [FullName], [Salary]
FROM [Employees]
WHERE [Salary] >= 100000 AND [Salary] <= 150000
ORDER BY [Salary] ASC
