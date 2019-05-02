using Model;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IMaterialService : IInWorldService<Material>
    {
        ICollection<Material> GetByModeleName(string nom);
        ICollection<Material> GetByModeleId(int id);
    }
}
