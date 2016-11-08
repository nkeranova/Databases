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
    public class ManagerImporter : IImporter
    {
        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var levels = new[] { 5, 5, 10, 10, 10, 15, 15, 15, 15 }; // First 5% does not have a manager

                    // Random sort from the DB
                    var allEmployees = db.Employees
                        .OrderBy(e => Guid.NewGuid())
                        .Select(e => e.Id)
                        .ToList();

                    var currentPercentage = 0;
                    List<int> previousManagers = null;
                    for (int i = 0; i < levels.Length; i++)
                    {
                        var level = levels[i];

                        var skip = (int)((currentPercentage * allEmployees.Count) / 100.0);
                        var take = (int)((level * allEmployees.Count) / 100.0);

                        var currentEmployeesId = allEmployees
                            .Skip(skip)
                            .Take(take)
                            .ToList();

                        var employees = db.Employees
                            .Where(e => currentEmployeesId.Contains(e.Id))
                            .ToList();

                        foreach (var emp in employees)
                        {
                            emp.ManagerId =
                                previousManagers == null ? null : (int?)previousManagers[RandomGenerator.GetRandomNumber(0, previousManagers.Count() - 1)];

                        }

                        tr.Write(".");

                        db.SaveChanges();
                        db.Dispose();
                        db = new CompanyEntities();

                        previousManagers = currentEmployeesId;
                        currentPercentage += level;
                    }
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing Managers";
            }
        }

        public int Order
        {
            get
            {
                return 3;
            }
        }
    }
}
