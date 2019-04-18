using System.Collections.Generic;
using System.Linq;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : class, new()
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        void AddRange(List<T> list);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        void SaveChanges();
    }
}
