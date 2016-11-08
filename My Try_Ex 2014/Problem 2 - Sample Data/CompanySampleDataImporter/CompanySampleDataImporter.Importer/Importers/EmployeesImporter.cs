using CompanySampleDataImporter.Importer.Importer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySampleDataImporter.Data;
using System.IO;

namespace CompanySampleDataImporter.Importer.Importers
{
    public class EmployeesImporter : IImporter
    {
        private const int NumberOfEmployees = 500; //5000 employees
        public string Message
        {
            get { return $"Importing Employees!"; }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var departmentsId = db.Departments
                        .Select(d => d.Id)
                        .ToList();

                    for (int i = 0; i < NumberOfEmployees; i++)
                    {
                        db.Employees.Add(new Employee
                        {
                            FirstName = RandomGenerator.GetRandomString(5, 20),
                            LastName = RandomGenerator.GetRandomString(5, 20),
                            YearSalary = RandomGenerator.GetRandomNumber(50000, 200000)
                        });

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
    }
}
