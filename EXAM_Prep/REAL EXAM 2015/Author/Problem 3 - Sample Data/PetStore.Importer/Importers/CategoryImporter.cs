namespace PetStore.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using PetStore.Data;

    public class CategoryImporter : IImporter
    {
        private const int NumberOfCountries = 50;

        public string Message
        {
            get { return "Importing categories"; }
        }

        public int Order
        {
            get { return 4; }
        }

        public Action<PetStoreEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {
                    for (int i = 0; i < NumberOfCountries; i++)
                    {
                        db.Categories.Add(new Category
                        {
                            Name = RandomGenerator.RandomString(5, 20)
                        });

                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db = new PetStoreEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
