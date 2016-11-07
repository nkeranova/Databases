namespace FindingRegionWithSpecificConditions
{
    using System;
    using System.Linq;
    using CreatingNorthwindDbContext;

    internal class Startup
    {
        private static void Main()
        {
            const string region = "SP";
            var startDate = new DateTime(1995, 5, 10);
            var endDate = new DateTime(1996, 12, 4);

            using (var db = new NorthwindEntities())
            {
                var sales = db.Orders
                    .Where(o => o.ShipRegion == region &&
                                o.OrderDate >= startDate &&
                                o.OrderDate <= endDate)
                    .ToList();

                foreach (var sale in sales)
                {
                    Console.WriteLine("{0} | {1}", sale.ShipRegion, sale.OrderDate);
                }
            }
        }
    }
}