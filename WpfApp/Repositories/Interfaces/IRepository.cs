using System.Linq;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepository<TDto, TPoco>
        where TDto : class, new()
        where TPoco : IPoco<TDto>, new()
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
