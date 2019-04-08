using System.Linq;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepositoryDto<TDto>
        where TDto : class, new()
    {
        IQueryable<TDto> GetAll();
        TDto GetById(int id);
        TDto Add(TDto entity);
        void Update(TDto entity);
        void Delete(int id);
        void Delete(TDto entity);
        void SaveChanges();
    }
}
