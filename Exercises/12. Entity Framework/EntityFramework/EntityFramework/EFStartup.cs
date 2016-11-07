using System;
using System.Data.Entity;
using System.Linq;

namespace EntityFramework
{
    public class EFStartup
    {
        static void Main()
        {
            //селектира от таблицата това, което е с ID=1
            using (var db = new TelerikAcademyEntities())
            {
                var project = db.Projects
                            .Where(pr => pr.ProjectID == 1)
                            .FirstOrDefault();

                Console.WriteLine(project.Name);

                var projectCount = db.Projects.ToList();

                Console.WriteLine(projectCount.Count);
            }

            using (var db = new TelerikAcademyEntities())
            {
                var project = db.Projects.Find(2);

                Console.WriteLine(project);
            }

            //Create, Update, Delete using Entity Framework

            //Add
            using (var db = new TelerikAcademyEntities())
            {
                var town = new Town
                {
                    Name = "London"
                };

                var address = new Address
                {
                    AddressText = "Mladost 4",
                    Town = town
                };

                //db.Towns.Add(town);
                db.Addresses.Add(address);

                db.SaveChanges();
            }

            //Delete
            using (var db = new TelerikAcademyEntities())
            {
                //Add some town
                var town = new Town
                {
                    Name = "Town going to be deleted"
                };

                db.Towns.Add(town);
                db.SaveChanges();

                //Remove
                var townToDelete = db.Towns.Where(t => t.Name.Contains("deleted")).FirstOrDefault();

                db.Towns.Remove(townToDelete);
                db.SaveChanges();
            }

            //view all information - бърз начин с .Select(t => new {..}), което прави
            //една заявка с join и е много по-добре от към performance
            using (var db = new TelerikAcademyEntities())
            {
                var towns = db.Towns
                    .Where(t => t.Addresses.Any())
                    .Select(t => new
                    {
                        t.Name,
                        Addresses = t.Addresses.Select(a => a.AddressText)
                    })
                    .ToList();

                foreach (var town in towns)
                {
                    Console.WriteLine(town.Name);
                  
                    foreach (var address in town.Addresses)
                    {
                        Console.WriteLine(address);
                    }

                    Console.WriteLine("-----------------------");
                }
            }


            //view all information - тромав начин прави много заявки и прави същото, като горната заявкабн
            using (var db = new TelerikAcademyEntities())
            {
                var towns = db.Towns.Where(t => t.Addresses.Any()).ToList();

                Console.WriteLine(towns.Count);

                foreach (var town in towns)
                {
                    Console.WriteLine(town.Name);
                    var addresses = town.Addresses;

                    foreach (var address in addresses)
                    {
                        Console.WriteLine(address.AddressText);
                    }

                    Console.WriteLine("-----------------------");
                }
            }

            //use Extended partial class, to add new functionallity
            using (var db = new TelerikAcademyEntities())
            {
                var employee = db.Employees.ToList().Select(e => e.FullName);

                foreach (var empl in employee)
                {
                    Console.WriteLine(empl);
                }
            }


            var dbo = new TelerikAcademyEntities();

            //Executing Native SQL Queries
            var empls = dbo.Database.SqlQuery(typeof(Project), "SELECT * FROM dbo.Projects");

            //Joining Tables in EF

            //чрез анонимен обект
            dbo.Towns
                .Select(t => new
                {
                    Name = t.Name,
                    Address = t.Addresses.Select(a => a.AddressText)
                });

            //или може да е мапнат към конкретен клас
            var result = dbo.Towns
              .Select(t => new TownDataModel
              {
                  Name = t.Name,
                  Address = t.Addresses.Select(a => a.AddressText)
              });

            Console.WriteLine(result);

            //when we use JOIN
            var secondResult = dbo.Towns
                .Join(
                dbo.Addresses,
                t => t.TownID, a => a.TownID,
                (t, a) => new
                {
                    TownName = t.Name,
                    AddressTexts= a.AddressText
                })
                .ToList();


            //Join with linq
            var employe = dbo.Employees
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    Town = e.Address.Town.Name,
                    Address = e.Address.AddressText,
                    Project = e.Projects.Select(pr => pr.Name).FirstOrDefault(),
                    Department = e.Department.Name
                });

            Console.WriteLine(employe);

            //Group
            var emplGroups = dbo.Employees
                .GroupBy(e => e.Department.Name)
                .ToList();

            foreach (var empplGr in emplGroups)
            {
                Console.WriteLine(empplGr.Key);

                foreach (var emp in empplGr)
                {
                    Console.WriteLine(emp.FirstName);
                }

                Console.WriteLine("============================");
            }

            //Groupby more than 1 thing
            var emplsGroups = dbo.Employees
               .GroupBy(e => new { e.Department.Name, TownName = e.Address.Town.Name })
               .ToList();

            //UPDATE
            // за целта трябва да се ползва оригиналния обект
            var updateEmpl = dbo.Employees.FirstOrDefault();

            //може да правим колкото искаме промени
            updateEmpl.FirstName = "Pesho";

            dbo.SaveChanges();

            //Attaching Detached Objects
            var em = dbo.Employees.FirstOrDefault();

            var dbEntry = dbo.Entry(em);

            //нов обект, токущо добавен
            dbEntry.State = EntityState.Added;

            //изтрии този обект
            dbEntry.State = EntityState.Deleted;

            //спри да се занимаваш с този обект
            dbEntry.State = EntityState.Detached;

            //променен този обект
            dbEntry.State = EntityState.Modified;

            //непроменен обект, скипни промените и го следи отново
            dbEntry.State = EntityState.Unchanged;

            dbo.SaveChanges();

            //Attaching - ръчно 
            //ако имаме праймъри кй, то тогава променяме наличното в базата
            //ако нямаме добавяме нов обект

            var e = new Employee
            {
                EmployeeID = 5,
                JobTitle = "Dev"
            };

            dbo.Employees.Attach(e);
        }
    }
}
