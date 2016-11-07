using EFCodeFirst.Data.Repositories;
using EFCodeFirst.Models;
using System.Linq;

namespace EFCodeFirst.Data.Services
{
    public class ArtistService 
    {
        private readonly IRepositories<Artist> artists;

        public ArtistService(IRepositories<Artist> data)
        {
            this.artists = data;
        }

        public IQueryable<Artist> FindByName(string name)
        {
            return this.artists
                .All()
                .Where(a => a.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
