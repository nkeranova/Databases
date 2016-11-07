namespace PetStore.Importer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using PetStore.Data;
    using PetStore.Importer.Importers;

    public class PetStoreImporter
    {
        private TextWriter textWriter;

        private PetStoreImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public static PetStoreImporter Create(TextWriter textWriter)
        {
            return new PetStoreImporter(textWriter);
        }

        public void Import()
        {
            Assembly.GetAssembly(typeof(IImporter))
                .GetTypes()
                .Where(t => typeof(IImporter).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .Select(t => (IImporter)Activator.CreateInstance(t))
                .OrderBy(i => i.Order)
                .ToList()
                .ForEach(i =>
                {
                    this.textWriter.Write(i.Message);
                    i.Import(new PetStoreEntities(), this.textWriter);
                    this.textWriter.WriteLine();
                });
        }
    }
}
