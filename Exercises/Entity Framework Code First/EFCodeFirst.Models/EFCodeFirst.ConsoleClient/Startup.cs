using EFCodeFirst.Data;
using EFCodeFirst.Data.Migrations;
using EFCodeFirst.Data.Repositories;
using EFCodeFirst.Models;
using System.Data.Entity;

namespace EFCodeFirst.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistsDBContext, Configuration>());

            //IArtistsDBContext db = new ArtistsDBContext();

            //db.Album.Add(new Album());

            //позволява да изпълним команда
            //db.Database.ExecuteSqlCommand();

            //рядко се ползва
            //db.Configuration.LazyLoadingEnabled = false;
            //db.Configuration.ValidateOnSaveEnabled = false;

            /*
            var artist = new Artist
            {
                Name = "Tosho",
                Gender = GenderType.Male
            };

            db.Artists.Add(artist);
            db.SaveChanges();
            */

            //Console.WriteLine(db.Artists.Count());

            //рядко се ползва
            //db.Configuration.LazyLoadingEnabled = true;
            //db.Configuration.ValidateOnSaveEnabled = true;

            IRepositories<Artist> artistRepo = new EfRepository<Artist>();

            //Console.WriteLine(artistRepo.All().Count());

            artistRepo.Add(new Artist
            {
                Name = "PeshoPetrov"
            });

            artistRepo.SaveChanges();
        }
    }
}
