namespace PetStore.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using PetStore.Data;

    public class SpeciesImporter : IImporter
    {
        private const int NumberOfSpecies = 100;

        public string Message
        {
            get { return "Importing species"; }
        }

        public int Order
        {
            get { return 2; }
        }

        public Action<PetStoreEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {
                    var uniqueSpecies = new HashSet<string>();
                    
                    while (uniqueSpecies.Count < NumberOfSpecies)
                    {
                        uniqueSpecies.Add(RandomGenerator.RandomString(5, 50));
                    }

                    var countryIds = db.Countries.Select(c => c.Id).ToList();
                    var uniqueSpeciesList = uniqueSpecies.ToList();
                    var currentSpeciesIndex = 0;

                    foreach (var countryId in countryIds)
                    {
                        var numberOfSpeciesPerCountry = RandomGenerator.RandomNumber(2, 8);

                        if (currentSpeciesIndex + 8 >= uniqueSpeciesList.Count)
                        {
                            numberOfSpeciesPerCountry = uniqueSpeciesList.Count - currentSpeciesIndex;
                        }

                        for (int i = 0; i < numberOfSpeciesPerCountry; i++)
                        {
                            this.AddSpecies(db, uniqueSpeciesList[currentSpeciesIndex], countryId);

                            currentSpeciesIndex++;

                            if (currentSpeciesIndex % 10 == 0)
                            {
                                tr.Write(".");
                            }

                            if (currentSpeciesIndex % 100 == 0)
                            {
                                db.SaveChanges();
                                db = new PetStoreEntities();
                            }
                        }
                    }

                    if (currentSpeciesIndex < uniqueSpeciesList.Count)
                    {
                        var leftSpecies = uniqueSpeciesList.Count - currentSpeciesIndex;
                        for (int i = 0; i < leftSpecies; i++)
                        {
                            this.AddSpecies(db, uniqueSpeciesList[currentSpeciesIndex], countryIds[RandomGenerator.RandomNumber(0, countryIds.Count - 1)]);
                            currentSpeciesIndex++;
                        }
                    }

                    db.SaveChanges();
                };
            }
        }

        private void AddSpecies(PetStoreEntities db, string name, int countryId)
        {
            db.Species.Add(new Species
            {
                Name = name,
                CountryId = countryId
            });
        }
    }
}
