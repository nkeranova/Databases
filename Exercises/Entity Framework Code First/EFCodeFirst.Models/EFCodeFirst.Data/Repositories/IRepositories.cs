using System.Linq;

namespace EFCodeFirst.Data.Repositories
{
    public interface IRepositories<TEntity>
    {
        IQueryable<TEntity> All();

        TEntity FindById(object id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void SaveChanges();
    }
}
