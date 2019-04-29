using System.Collections.Generic;
using System.Linq;
using Services.Context;
using Model;
using Services.Repositories.Interfaces;

namespace WpfApp.Repositories
{
    public class ModeleService : CommunService, IModeleRepository
    {
        public ModeleService(MiningContext ctx)
            : base(ctx)
        {

        }

        public ICollection<Modele> GetModelesByCategorieId(int id)
        {
            return DbSet.Where(x => x.Categorie.Id == id).ToList();
        }

        public ICollection<Modele> GetModelesByCategorieName(string nom)
        {
            return DbSet.Where(x => x.Categorie.Nom == nom).ToList();
        }
    }
}
