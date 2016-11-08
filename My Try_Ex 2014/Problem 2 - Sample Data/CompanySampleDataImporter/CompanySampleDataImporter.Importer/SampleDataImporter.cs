using CompanySampleDataImporter.Data;
using CompanySampleDataImporter.Importer.Importer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompanySampleDataImporter.Importer
{
    public class SampleDataImporter
    {
        private TextWriter textWriter;

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        private SampleDataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public void Import()
        {
            //това е Рефлекшън, чрез който прихващаме всички класове които имплементират интерфейса
            Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => typeof(IImporter).IsAssignableFrom(t)
                    && !t.IsInterface && !t.IsAbstract)
                    .Select(Activator.CreateInstance) //(t => (IImporter)Activator.CreateInstance(t))
                    .OfType<IImporter>()
                    .OrderBy(i => i.Order)
                    .ToList()
                    .ForEach(i =>
                    {
                        textWriter.Write(i.Message);

                        var db = new CompanyEntities();
                        i.Get(db, this.textWriter);
                    });
        }
    }
}
