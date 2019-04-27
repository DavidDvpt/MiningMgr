using System.Collections.Generic;
using Model;

namespace Services.Repositories.Interfaces
{
    public interface IModeleRepository : ICommunRepository<Modele>
    {
        ICollection<Modele> GetByCategorieName(string nom);
        ICollection<Modele> GetByCategorieId(int id);
    }
}
