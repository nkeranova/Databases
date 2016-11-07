using System.Data.Entity;
using System.Linq;

namespace EFCodeFirst.Data.Repositories
{
    public class EfRepository<TEntity> : IRepositories<TEntity>
        where TEntity : class
    {
        private readonly IArtistsDBContext data;
        private readonly IDbSet<TEntity> set;

        public EfRepository()
            :this(new ArtistsDBContext())
        {

        }

        public EfRepository(IArtistsDBContext data)
        {
            this.data = data;
            this.set = data.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            //var dbEntry = this.data.Entry(entity);
            //dbEntry.State = EntityState.Added;

            //or
            //this.set.Add(entity);

            this.ChangeState(entity, EntityState.Added);
        }

        public IQueryable<TEntity> All()
        {
            return this.set;
        }

        public TEntity FindById(object id)
        {
            return this.set.Find(id);
        }

        public void Remove(TEntity entity)
        {
            //var dbEntry = this.data.Entry(entity);
            //dbEntry.State = EntityState.Deleted;

            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Update(TEntity entity)
        {
            //var dbEntry = this.data.Entry(entity);
            //dbEntry.State = EntityState.Modified;

            this.ChangeState(entity, EntityState.Modified);
        }

        public void SaveChanges()
        {
            this.data.SaveChanges();
        }

        //obsht metod za da go preizpolzwame
        private void ChangeState(TEntity entity, EntityState state)
        {
            var dbEntry = this.data.Entry(entity);
            dbEntry.State = state;
        }
    }
}
