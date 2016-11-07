namespace PetStore.Importer.Importers
{
    using System;
    using System.IO;
    using PetStore.Data;

    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<PetStoreEntities, TextWriter> Import { get; }
    }
}
