USE Company;
GO
CREATE PROCEDURE uspCreateCacheTable 
AS 
	CREATE TABLE Query3CacheTable
	(
		EmployeeName nvarchar(41),
		ProjectsName nvarchar(50),
		DepartmentName nvarchar(50),
		StartDate date,
		EndDate date,
		ReportsCount int,
	);
GO
EXECUTE uspCreateCacheTable;
GO
CREATE PROCEDURE uspUpdateCacheTable
AS
	DELETE FROM Query3CacheTable;
	INSERT INTO Query3CacheTable
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
GO
EXECUTE uspUpdateCacheTable;
GO
