using System.Collections.Generic;
using WpfApp.Model;

namespace WpfApp.Repositories.Interfaces
{
    public interface IModeleRepository : ICommunRepository<Modele>
    {
        ICollection<Modele> GetByCategorieName(string nom);
        ICollection<Modele> GetByCategorieId(int id);
    }
}
