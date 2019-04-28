using System.Collections.Generic;
using System.Linq;
using Services.Context;
using Model;
using Services.Repositories.Interfaces;

namespace WpfApp.Repositories
{
    public class ModeleRepository : CommunRepository<Modele>, IModeleRepository
    {
        public ModeleRepository(MiningContext ctx)
            : base(ctx)
        {

        }

        public ICollection<Modele> GetByCategorieId(int id)
        {
            return DbSet.Where(x => x.Categorie.Id == id).ToList();
        }

        public ICollection<Modele> GetByCategorieName(string nom)
        {
            return DbSet.Where(x => x.Categorie.Nom == nom).ToList();
        }
    }
}
