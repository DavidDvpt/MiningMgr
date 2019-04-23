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

        private ICommunRepository<Categorie> _Categories;
        private IModeleRepository _Modeles;
        private ICommunRepository<Finder> _Finders;
        private ICommunRepository<Excavator> _Excavators;
        private ICommunRepository<Refiner> _Refiners;
        private ICommunRepository<FinderAmplifier> _FinderAmplifiers;
        private ICommunRepository<SearchMode> _SearchModes;
        private ICommunRepository<Setup> _Setups;
        private ICommunRepository<Planet> _Planets;
        private ICommunRepository<Enhancer> _Enhancers;
        private IMaterialRepository _Materials;
        private IRepository<ToolAccessoire> _ToolAccessoires;
        private IRepository<PlanetMaterial> _PlanetMaterials;
        private IRepository<Refinable> _Refinables;
        private IRepository<StockMaterial> _StockMaterials;
        private IRepository<TradeMaterial> _TradeMaterials;
        private ICommunRepository<TradeState> _TradeStates;

        public ICommunRepository<Categorie> Categories
            => _Categories == null? _Categories = new CommunRepository<Categorie>(ctx) : _Categories;

        public IModeleRepository Modeles
            => _Modeles == null ? _Modeles = new ModeleRepository(ctx) : _Modeles;

        public ICommunRepository<Finder> Finders
            => _Finders == null ? _Finders = new CommunRepository<Finder>(ctx) : _Finders;

        public ICommunRepository<Excavator> Excavators
            => _Excavators == null ? _Excavators = new CommunRepository<Excavator>(ctx) : _Excavators;

        public ICommunRepository<Refiner> Refiners
            => _Refiners == null ? _Refiners = new CommunRepository<Refiner>(ctx) : _Refiners;

        public ICommunRepository<FinderAmplifier> FinderAmplifiers
            => _FinderAmplifiers == null ? _FinderAmplifiers = new CommunRepository<FinderAmplifier>(ctx) : _FinderAmplifiers;

        public ICommunRepository<SearchMode> SearchModes
            => _SearchModes == null ? _SearchModes = new CommunRepository<SearchMode>(ctx) : _SearchModes;

        public ICommunRepository<Setup> Setups
            => _Setups == null ? _Setups = new CommunRepository<Setup>(ctx) : _Setups;

        public ICommunRepository<Planet> Planets
            => _Planets == null ? _Planets = new CommunRepository<Planet>(ctx) : _Planets;

        public ICommunRepository<Enhancer> Enhancers
            => _Enhancers == null? _Enhancers = new CommunRepository<Enhancer>(ctx) : _Enhancers;

        public IMaterialRepository Materials
            => _Materials == null? _Materials = new MaterialRepository(ctx) : _Materials;

        public IRepository<ToolAccessoire> ToolAccessoires
            => _ToolAccessoires == null ? _ToolAccessoires = new Repository<ToolAccessoire>(ctx) : _ToolAccessoires;

        public IRepository<PlanetMaterial> PlanetMaterials
            => _PlanetMaterials == null ? _PlanetMaterials = new Repository<PlanetMaterial>(ctx) : _PlanetMaterials;

        public IRepository<Refinable> Refinables
            => _Refinables == null ? _Refinables = new Repository<Refinable>(ctx) : _Refinables;

        public IRepository<StockMaterial> StockMaterials
            => _StockMaterials == null ? _StockMaterials = new Repository<StockMaterial>(ctx) : _StockMaterials;

        public IRepository<TradeMaterial> TradeMaterials
            => _TradeMaterials == null ? _TradeMaterials = new Repository<TradeMaterial>(ctx) : _TradeMaterials;

        public ICommunRepository<TradeState> TradeStates
            => _TradeStates == null ? _TradeStates = new CommunRepository<TradeState>(ctx) : _TradeStates;

        public void Commit()
        {
            ctx.SaveChanges();
        }

        public MiningContext GetContext()
        {
            return ctx;
        }
    }
}
