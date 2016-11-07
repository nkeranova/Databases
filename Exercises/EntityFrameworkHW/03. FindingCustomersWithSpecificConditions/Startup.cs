namespace FindingCustomersWithSpecificConditions
{
    using System;
    using System.Linq;
    using CreatingNorthwindDbContext;

    internal class Startup
    {
        private static NorthwindEntities db;

        private static void Main()
        {
            using (db = new NorthwindEntities())
            {
                var customers = db.Customers
                    .Join(db.Orders,
                        (c => c.CustomerID),
                        (o => o.CustomerID),
                        (c, o) => new
                        {
                            CustomerName = c.ContactName,
                            OrderYear = o.OrderDate.Value.Year,
                            o.ShipCountry
                        })
                    .ToList()
                    .FindAll(c => c.OrderYear == 1997 && c.ShipCountry == "Canada")
                    .ToList();

                customers.ForEach(Console.WriteLine);

                // Select only distinct customers with specific conditions
                //customers.Distinct().ToList().ForEach(Console.WriteLine);
            }
        }
    }
}