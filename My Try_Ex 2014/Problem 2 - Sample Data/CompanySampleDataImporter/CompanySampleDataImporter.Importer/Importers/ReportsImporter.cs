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
    public class ReportsImporter : IImporter
    {
        private const int NumberOfReports = 250000;
        private const int ReportsPerEmployee = 50;

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var employeesId = db.Employees
                        .Select(e => e.Id)
                        .ToList();

                    // var currentEmployeeIndex = 0;

                    for (int i = 0; i < employeesId.Count(); i++)
                    {
                        var numberOfReports = RandomGenerator.GetRandomNumber(25, 70);

                        for (int j = 0; j < numberOfReports; j++)
                        {
                            db.Reports.Add(new Report
                            {
                                EmployeId = employeesId[i],
                                Time = DateTime.Now
                            });

                            tr.Write(".");

                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }

                        //db.SaveChanges();
                        //db.Dispose();
                        //db = new CompanyEntities();
                        //
                        //tr.Write(".");
                    }
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing report";
            }
        }

        public int Order
        {
            get
            {
                return 5;
            }
        }
    }
}
