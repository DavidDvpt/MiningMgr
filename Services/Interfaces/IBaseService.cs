using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services.Interfaces
{
    public interface IBaseService<T>
        where T : class, new()
    {
        DbSet<T> DbSet { get; }

        T GetById(int Id);

        IQueryable<T> GetAll();

        T Add(T entity);

        void AddRange(List<T> entities);

        void Update(T entity);

        void Delete(int id);

        void Delete(T entity);

        void Commit();

        //MiningContext GetContext();
    }
}
