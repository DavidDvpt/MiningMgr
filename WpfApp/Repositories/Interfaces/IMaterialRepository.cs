using System.Collections.Generic;
using WpfApp.Model;

namespace WpfApp.Repositories.Interfaces
{
    public interface IMaterialRepository : ICommunRepository<Material>
    {
        ICollection<Material> GetByModeleName(string nom);
        ICollection<Material> GetByModeleId(int id);
    }
}
