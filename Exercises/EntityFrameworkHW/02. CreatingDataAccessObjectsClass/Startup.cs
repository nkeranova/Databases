namespace CreatingDataAccessObjectsClass
{
    using System;
    using System.Linq;
    using System.Threading;
    using CreatingNorthwindDbContext;

    internal class Startup
    {
        private static NorthwindEntities db;
        private static int affectedRows;

        private static void Main()
        {
            Console.WriteLine("-- Establishing connection to database Northwind...");
            Thread.Sleep(1000);

            using (db = new NorthwindEntities())
            {
                Console.WriteLine("Executing queries...");
                Thread.Sleep(1000);
                InsertNewCustomersToDb();
                Thread.Sleep(1000);
                ModifyNewInsertedCustomer();
                Thread.Sleep(1000);
                DeleteNewInsertedCustomer();
            }

            Console.WriteLine("-- Closing connection to the database...");
        }

        private static void DeleteNewInsertedCustomer()
        {
            var customer = db.Customers.First();
            db.Customers.Remove(customer);
            affectedRows = db.SaveChanges();
            Console.WriteLine("({0} row(s) affected)", affectedRows);
        }

        private static void ModifyNewInsertedCustomer()
        {
            var customer = db.Customers.First();
            customer.ContactTitle = "Sales Representative";
            affectedRows = db.SaveChanges();
            Console.WriteLine("({0} row(s) affected)", affectedRows);
        }

        private static void InsertNewCustomersToDb()
        {
            var newCustomer = new Customer
            {
                CustomerID = "AAAAA",
                CompanyName = "Lethal Corporation",
                ContactName = "Alfonso Salvarez",
                ContactTitle = "CEO",
                Address = "33 Pedro Almodovar Sq.",
                City = "Ciudad Real",
                PostalCode = "11223",
                Country = "Spain",
                Phone = "030-0023002",
                Fax = "030-0023003"
            };

            db.Customers.Add(newCustomer);
            affectedRows = db.SaveChanges();
            Console.WriteLine("({0} row(s) affected)", affectedRows);
        }
    }
}