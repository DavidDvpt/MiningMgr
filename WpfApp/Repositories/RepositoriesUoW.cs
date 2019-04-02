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

        private ICommunRepository<CategorieModel> _Categories;
        private ICommunRepository<ModeleModel> _Modeles;
        private IRepository<FinderModel> _Finders;
        private IRepository<ExcavatorModel> _Excavators;
        private IRepository<RefinerModel> _Refiners;
        private IRepository<FinderAmplifier> _FinderAmplifiers;
        private IRepository<SearchModeModel> _SearchModes;
        private IRepository<SetupModel> _Setups;
        private IRepository<PlanetModel> _Planets;
        private IRepository<EnhancerModel> _Enhancers;
        private IRepository<MaterialModel> _Materials;
        private IRepository<ToolAccessoireModel> _ToolAccessoires;
        private IRepository<PlanetMaterial> _PlanetMaterials;

        public ICommunRepository<CategorieModel> Categories
            => _Categories == null? _Categories = new CommunRepository<CategorieModel>(ctx) : _Categories;

        public ICommunRepository<ModeleModel> Modeles
            => _Modeles == null ? _Modeles = new CommunRepository<ModeleModel>(ctx) : _Modeles;

        public IRepository<FinderModel> Finders
            => _Finders == null ? _Finders = new Repository<FinderModel>(ctx) : _Finders;

        public IRepository<ExcavatorModel> Excavators
            => _Excavators == null ? _Excavators = new Repository<ExcavatorModel>(ctx) : _Excavators;

        public IRepository<RefinerModel> Refiners
            => _Refiners == null ? _Refiners = new Repository<RefinerModel>(ctx) : _Refiners;

        public IRepository<FinderAmplifier> FinderAmplifiers
            => _FinderAmplifiers == null ? _FinderAmplifiers = new Repository<FinderAmplifier>(ctx) : _FinderAmplifiers;

        public IRepository<SearchModeModel> SearchModes
            => _SearchModes == null ? _SearchModes = new Repository<SearchModeModel>(ctx) : _SearchModes;

        public IRepository<SetupModel> Setups
            => _Setups == null ? _Setups = new Repository<SetupModel>(ctx) : _Setups;

        public IRepository<PlanetModel> Planets
            => _Planets == null ? _Planets = new Repository<PlanetModel>(ctx) : _Planets;

        public IRepository<EnhancerModel> Enhancers
            => _Enhancers == null? _Enhancers = new Repository<EnhancerModel>(ctx) : _Enhancers;

        public IRepository<MaterialModel> Materials
            => _Materials == null? _Materials = new Repository<MaterialModel>(ctx) : _Materials;

        public IRepository<ToolAccessoireModel> ToolAccessoires
            => _ToolAccessoires == null ? _ToolAccessoires = new Repository<ToolAccessoireModel>(ctx) : _ToolAccessoires;

        public IRepository<PlanetMaterial> PlanetMaterials
            => _PlanetMaterials == null ? _PlanetMaterials = new Repository<PlanetMaterial>(ctx) : _PlanetMaterials;

        public void Commit()
        {
            ctx.SaveChanges();
        }
    }
}
