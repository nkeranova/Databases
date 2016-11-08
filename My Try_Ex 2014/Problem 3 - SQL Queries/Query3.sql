SELECT
	[Employees].[FirstName] + ' ' + [Employees].[LastName] AS [EmployeeName],
	[Projects].[Name] AS [ProjectName],
	[Departments].[Name] AS [DepartmentName],
	StartDate, EndDate
	,(SELECT COUNT(*)
		FROM [Reports]
		WHERE [Time] BETWEEN [EmployeesInProjects].StartDate AND [EmployeesInProjects].EndDate
	) AS [ReportsCount]
FROM [Employees]
	LEFT JOIN [Departments] ON [Departments].[Id] = [Employees].[DepartmentId]
	LEFT JOIN [EmployeesInProjects] ON [EmployeesInProjects].[EmployeeId] = [Employees].[Id]
	LEFT JOIN [Projects] ON [Projects].[Id] = [EmployeesInProjects].ProjectId
ORDER BY [EmployeeId], [ProjectId]
