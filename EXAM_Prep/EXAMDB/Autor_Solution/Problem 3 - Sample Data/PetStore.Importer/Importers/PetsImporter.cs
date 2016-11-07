namespace PetStore.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using PetStore.Data;

    public class PetsImporter : IImporter
    {
        private const int NumberOfPets = 5000;

        public string Message
        {
            get { return "Importing pets"; }
        }

        public int Order
        {
            get { return 3; }
        }

        public Action<PetStoreEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;

                    var speciesIds = db.Species.Select(s => s.Id).ToList();
                    var colorIds = db.Colors.Select(c => c.Id).ToList();

                    var addedPets = 0;
                    foreach (var speciesId in speciesIds)
                    {
                        var petsPerSpecies = RandomGenerator.RandomNumber(25, 75);

                        if (addedPets + 75 >= NumberOfPets)
                        {
                            petsPerSpecies = NumberOfPets - addedPets;
                        }

                        for (int i = 0; i < petsPerSpecies; i++)
                        {
                            this.AddSpecies(db, speciesId, colorIds[RandomGenerator.RandomNumber(0, colorIds.Count - 1)]);

                            addedPets++;
                        }

                        tr.Write(".");
                        db.SaveChanges();
                        db = new PetStoreEntities();
                        db.Configuration.AutoDetectChangesEnabled = false;
                        db.Configuration.ValidateOnSaveEnabled = false;
                    }

                    if (addedPets < NumberOfPets)
                    {
                        var leftPets = NumberOfPets - addedPets;
                        for (int i = 0; i < leftPets; i++)
                        {
                            this.AddSpecies(
                                db,
                                speciesIds[RandomGenerator.RandomNumber(0, speciesIds.Count - 1)],
                                colorIds[RandomGenerator.RandomNumber(0, colorIds.Count - 1)]);

                            addedPets++;
                        }
                    }

                    db.SaveChanges();
                    db.Configuration.AutoDetectChangesEnabled = true;
                    db.Configuration.ValidateOnSaveEnabled = true;
                };
            }
        }

        private void AddSpecies(PetStoreEntities db, int speciesId, int colorId)
        {
            db.Pets.Add(new Pet
            {
                BirthTime = RandomGenerator.RandomDateTime(),
                Breed = RandomGenerator.RandomString(5, 30),
                ColorId = colorId,
                Price = RandomGenerator.RandomNumber(5, 2500),
                SpeciesId = speciesId
            });
        }
    }
}
