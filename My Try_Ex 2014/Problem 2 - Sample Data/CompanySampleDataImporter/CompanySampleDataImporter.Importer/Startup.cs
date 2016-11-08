using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySampleDataImporter.Importer
{
    public class Startup
    {
        public static void Main()
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
