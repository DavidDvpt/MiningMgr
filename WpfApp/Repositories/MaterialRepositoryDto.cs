using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Context;
using WpfApp.Model.Dto;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.Repositories
{
    public class MaterialRepositoryDto : CommunRepositoryDto<MaterialDto>, IMaterialRepositoryDto
    {
        public MaterialRepositoryDto(MiningContext ctx)
            : base(ctx)
        {

        }
        public ICollection<MaterialDto> GetByModeleId(int id)
        {
            return DbSet.Where(x => x.ModeleId == id).OrderBy(x=>x.Nom).ToList();
        }

        public ICollection<MaterialDto> GetByModeleName(string nom)
        {
            return DbSet.Where(x => x.Modele.Nom == nom).OrderBy(x => x.Nom).ToList();
        }
    }
}
