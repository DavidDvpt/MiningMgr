using System.Collections.Generic;
using System.Linq;
using WpfApp.Context;
using WpfApp.Model;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.Repositories
{
    public class MaterialRepository : CommunRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(MiningContext ctx)
            : base(ctx)
        {

        }
        public ICollection<Material> GetByModeleId(int id)
        {
            return DbSet.Where(x => x.ModeleId == id).OrderBy(x=>x.Nom).ToList();
        }

        public ICollection<Material> GetByModeleName(string nom)
        {
            return DbSet.Where(x => x.Modele.Nom == nom).OrderBy(x => x.Nom).ToList();
        }
    }
}
