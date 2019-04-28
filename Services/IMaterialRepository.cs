using System.Collections.Generic;
using Model;

namespace Services.Repositories.Interfaces
{
    public interface IMaterialRepository : ICommunRepository<Material>
    {
        ICollection<Material> GetByModeleName(string nom);
        ICollection<Material> GetByModeleId(int id);
    }
}
