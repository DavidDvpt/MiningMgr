using System.Linq;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepository<TDto, TPoco>
        where TDto : class, new()
        where TPoco : class, new()
    {
        IQueryable<TPoco> GetAll();
        TPoco GetById(int id);
        TPoco Add(TPoco entity);
        void Update(TPoco entity);
        void Delete(int id);
        void Delete(TPoco entity);
        void SaveChanges();
    }
}
