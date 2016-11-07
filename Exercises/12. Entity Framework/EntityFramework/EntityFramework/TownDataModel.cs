using System.Collections.Generic;

namespace EntityFramework
{
    public class TownDataModel
    {
        public string Name { get; set; }

        public IEnumerable<string> Address { get; set; }
    }
}
