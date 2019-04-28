using Model;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IModeleService : ICommunService<Modele>
    {
        ICollection<Modele> GetByCategorieName(string nom);

        ICollection<Modele> GetByCategorieId(int id);
    }
}
