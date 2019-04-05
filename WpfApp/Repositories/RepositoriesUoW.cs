using WpfApp.Context;
using WpfApp.Model;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.Repositories
{
    public class RepositoriesUoW : IRepositoriesUoW
    {
        private MiningContext ctx;

        public RepositoriesUoW()
        {
            CreateDbContext();
        }

        public RepositoriesUoW(MiningContext context)
        {
            ctx = context;
        }

        private void CreateDbContext()
        {
            ctx = new MiningContext();
        }

        private ICommunRepository<CategorieDto> _Categories;
        private ICommunRepository<ModeleDto> _Modeles;
        private IRepository<FinderDto> _Finders;
        private IRepository<ExcavatorDto> _Excavators;
        private IRepository<RefinerDto> _Refiners;
        private IRepository<FinderAmplifierDto> _FinderAmplifiers;
        private IRepository<SearchModeDto> _SearchModes;
        private IRepository<SetupDto> _Setups;
        private IRepository<PlanetDto> _Planets;
        private IRepository<EnhancerDto> _Enhancers;
        private IRepository<MaterialDto> _Materials;
        private IRepository<ToolAccessoireDto> _ToolAccessoires;
        private IRepository<PlanetMaterialDto> _PlanetMaterials;

        public ICommunRepository<CategorieDto> Categories
            => _Categories == null? _Categories = new CommunRepository<CategorieDto>(ctx) : _Categories;

        public ICommunRepository<ModeleDto> Modeles
            => _Modeles == null ? _Modeles = new CommunRepository<ModeleDto>(ctx) : _Modeles;

        public IRepository<FinderDto> Finders
            => _Finders == null ? _Finders = new Repository<FinderDto>(ctx) : _Finders;

        public IRepository<ExcavatorDto> Excavators
            => _Excavators == null ? _Excavators = new Repository<ExcavatorDto>(ctx) : _Excavators;

        public IRepository<RefinerDto> Refiners
            => _Refiners == null ? _Refiners = new Repository<RefinerDto>(ctx) : _Refiners;

        public IRepository<FinderAmplifierDto> FinderAmplifiers
            => _FinderAmplifiers == null ? _FinderAmplifiers = new Repository<FinderAmplifierDto>(ctx) : _FinderAmplifiers;

        public IRepository<SearchModeDto> SearchModes
            => _SearchModes == null ? _SearchModes = new Repository<SearchModeDto>(ctx) : _SearchModes;

        public IRepository<SetupDto> Setups
            => _Setups == null ? _Setups = new Repository<SetupDto>(ctx) : _Setups;

        public IRepository<PlanetDto> Planets
            => _Planets == null ? _Planets = new Repository<PlanetDto>(ctx) : _Planets;

        public IRepository<EnhancerDto> Enhancers
            => _Enhancers == null? _Enhancers = new Repository<EnhancerDto>(ctx) : _Enhancers;

        public IRepository<MaterialDto> Materials
            => _Materials == null? _Materials = new Repository<MaterialDto>(ctx) : _Materials;

        public IRepository<ToolAccessoireDto> ToolAccessoires
            => _ToolAccessoires == null ? _ToolAccessoires = new Repository<ToolAccessoireDto>(ctx) : _ToolAccessoires;

        public IRepository<PlanetMaterialDto> PlanetMaterials
            => _PlanetMaterials == null ? _PlanetMaterials = new Repository<PlanetMaterialDto>(ctx) : _PlanetMaterials;

        public void Commit()
        {
            ctx.SaveChanges();
        }
    }
}
