-- First Solution (Q in Q departments)
SELECT
	[Name],
	(SELECT COUNT(*) FROM [Employees] WHERE [DepartmentId] = [Departments].Id) AS [Count]
FROM [Departments]
ORDER BY [Count] DESC


-- Second solution (Q in Q employees)
SELECT
	(SELECT [Name] FROM [Departments] WHERE [Id] = [DepartmentId]) AS [Name],
	COUNT(*) AS [Count]
FROM [Employees]
GROUP BY [DepartmentId]
ORDER BY [Count] DESC


-- Third solution (JOIN)
SELECT [Departments].[Name],
	COUNT([Employees].[Id]) AS [Count]
	FROM Departments
		INNER JOIN Employees
		ON [Employees].DepartmentId = Departments.Id
	GROUP BY [DepartmentId], [Departments].Name
	ORDER BY [Count] DESC
