using Model;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IModeleService : ICommunService<Modele>
    {
        ICollection<Modele> GetModelesByCategorieName(string nom);

        ICollection<Modele> GetModelesByCategorieId(int id);
    }
}
