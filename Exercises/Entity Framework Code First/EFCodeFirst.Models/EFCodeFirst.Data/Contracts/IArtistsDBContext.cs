using EFCodeFirst.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EFCodeFirst.Data
{
    public interface IArtistsDBContext
    {
        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}