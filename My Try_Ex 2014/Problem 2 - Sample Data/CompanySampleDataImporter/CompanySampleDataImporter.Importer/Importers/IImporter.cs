using CompanySampleDataImporter.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySampleDataImporter.Importer.Importer
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }
        Action<CompanyEntities, TextWriter> Get { get; }
    }
}
