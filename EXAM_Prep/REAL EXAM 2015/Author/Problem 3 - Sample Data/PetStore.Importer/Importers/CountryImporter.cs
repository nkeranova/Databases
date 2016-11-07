namespace PetStore.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using PetStore.Data;

    public class CountryImporter : IImporter
    {
        private const int NumberOfCountries = 20;

        public string Message
        {
            get { return "Importing countries"; }
        }

        public int Order
        {
            get { return 1; }
        }

        public Action<PetStoreEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {
                    var uniqueCountries = new HashSet<string>();

                    while (uniqueCountries.Count < NumberOfCountries)
                    {
                        uniqueCountries.Add(RandomGenerator.RandomString(5, 50));
                    }

                    var addedCountries = 0;
                    foreach (var country in uniqueCountries)
                    {
                        db.Countries.Add(new Country
                        {
                            Name = country
                        });

                        if (addedCountries % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (addedCountries % 100 == 0)
                        {
                            db.SaveChanges();
                            db = new PetStoreEntities();
                        }

                        addedCountries++;
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
