namespace DbContextMultithreading
{
    using System;
    using System.Threading;
    using CreatingNorthwindDbContext;

    internal class Startup
    {
        private static void Main()
        {
            Console.WriteLine("-- Establishing first connection to database Northwind...");
            Thread.Sleep(1000);
            using (var firstDb = new NorthwindEntities())
            {
                var firstCategory = firstDb.Categories.Find(4);
                Console.WriteLine("Initial category description: {0}", firstCategory.Description);
                Thread.Sleep(1000);

                firstCategory.Description = "Cheese and many more";
                Console.WriteLine("Category description after changing: {0}", firstCategory.Description);
                Thread.Sleep(1000);

                Console.WriteLine("-- Establishing second connection to database Northwind...");
                Thread.Sleep(1000);
                using (var secondDb = new NorthwindEntities())
                {
                    var secondCategory = secondDb.Categories.Find(4);
                    Console.WriteLine("Initial category description: {0}", secondCategory.Description);
                    Thread.Sleep(1000);

                    secondCategory.Description = "Cheese and many, many more";
                    Console.WriteLine("Category description after changing: {0}", secondCategory.Description);
                    Thread.Sleep(1000);

                    firstDb.SaveChanges();
                    secondDb.SaveChanges();

                    Console.WriteLine("Category description after saving: {0}", secondCategory.Description);
                    Thread.Sleep(1000);
                }

                Console.WriteLine("-- Closing second connection to the database...");
                Thread.Sleep(1000);

                Console.WriteLine("Category description after saving: {0}", firstCategory.Description);
                Thread.Sleep(1000);
            }

            Console.WriteLine("-- Closing first connection to the database...");

            using (var db = new NorthwindEntities())
            {
                Console.WriteLine("Actual result: {0}", db.Categories.Find(4).Description);
            }
        }
    }
}