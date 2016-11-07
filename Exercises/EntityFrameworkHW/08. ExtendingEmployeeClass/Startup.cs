namespace ExtendingEmployeeClass
{
    using System;
    using System.Linq;
    using CreatingNorthwindDbContext;

    internal class Startup
    {
        private static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                foreach (var employee in db.Employees.Include("Territories"))
                {
                    var correspondingTerritories = employee.Territories.Select(c => c.TerritoryID);
                    var correspondingTerritoriesAsString = string.Join(", ", correspondingTerritories);
                    Console.WriteLine("{0} -> Territory IDs: {1}", employee.FirstName, correspondingTerritoriesAsString);
                }
            }
        }
    }
}