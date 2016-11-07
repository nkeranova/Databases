using EFCodeFirst.Models;
using System.Data.Entity;

namespace EFCodeFirst.Data
{
    // inherit DbContext
    public class ArtistsDBContext : DbContext, IArtistsDBContext
    {
        public ArtistsDBContext()
            : base("ArtistsDatabase")
        {
            //use it only for performance optimisation
            //this.Configuration.LazyLoadingEnabled = false;
        }

        //use DbSet<> - good practice is to use IDbSet<>, and to make it public virtual - its important for Mocking and Unit Testing
        //public DbSet<Album> Album { get; set; }
        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.
                Entity<Artist>()
                .HasKey(a => a.Id);

            modelBuilder.
               Entity<Artist>()
               .Property(a => a.Name)
               .HasMaxLength(100);

            modelBuilder.
              Entity<Artist>()
              .Property(a => a.Name)
              .IsUnicode();

            modelBuilder.
              Entity<Artist>()
              .HasMany(c => c.Albums)
              .WithRequired();

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
