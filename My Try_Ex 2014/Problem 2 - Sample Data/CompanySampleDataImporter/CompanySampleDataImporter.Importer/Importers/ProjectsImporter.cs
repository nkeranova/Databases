using CompanySampleDataImporter.Data;
using CompanySampleDataImporter.Importer.Importer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySampleDataImporter.Importer.Importers
{
    public class ProjectsImporter : IImporter
    {
        private const int NumberOfProjects = 1000;

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var employeesId = db.Employees
                        .OrderBy(e => Guid.NewGuid())
                        .Select(e => e.Id)
                        .ToList();

                    var currentEmployeeIndex = 0;

                    for (int i = 0; i < NumberOfProjects; i++)
                    {
                        var currentProject = new Project
                        {
                            Name = RandomGenerator.GetRandomString(5, 50)
                        };

                        var numberOfEmployeesPerProject = RandomGenerator.GetRandomNumber(2, 8);

                        for (int j = 0; j < numberOfEmployeesPerProject; j++)
                        {
                            if (j + currentEmployeeIndex >= employeesId.Count())
                            {
                                break;
                            }

                            var currentEmployeeId = employeesId[currentEmployeeIndex];

                            var startDate = RandomGenerator.GetRandomDate(before: DateTime.Now.AddDays(-100));

                            currentProject.EmployeesProjects.Add(new EmployeesProject
                            {
                                EmployeeId = currentEmployeeId,
                                StartingDate = startDate,
                                EndingDate = RandomGenerator.GetRandomDate(after: startDate)
                            });

                            currentEmployeeIndex++;
                        }

                        db.Projects.Add(currentProject);

                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing Projects";
            }
        }

        public int Order
        {
            get
            {
                return 4;
            }
        }
    }
}
