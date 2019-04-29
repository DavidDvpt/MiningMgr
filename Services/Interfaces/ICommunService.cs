using System.Collections.Generic;
using System.Linq;

namespace Services.Interfaces
{
    public interface ICommunService<T> : IServiceBase
        where T : class, new()
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        T Add(T entity);

        void AddRange(List<T> list);

        void Update(T entity);

        void Delete(int id);

        void Delete(T entity);

        T GetByNom(string nom);
    }
}
