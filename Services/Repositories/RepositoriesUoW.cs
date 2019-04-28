using Services.Context;
using Model;
using Services.Repositories.Interfaces;

namespace Services.Repositories
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

        private ICommunService<Categorie> _Categories;
        private IModeleService _Modeles;
        private ICommunService<Finder> _Finders;
        private ICommunService<Excavator> _Excavators;
        private ICommunService<Refiner> _Refiners;
        private ICommunService<FinderAmplifier> _FinderAmplifiers;
        private ICommunService<SearchMode> _SearchModes;
        private ICommunService<Setup> _Setups;
        private ICommunService<Planet> _Planets;
        private ICommunService<Enhancer> _Enhancers;
        private IMaterialRepository _Materials;
        private IRepository<ToolAccessoire> _ToolAccessoires;
        private IRepository<PlanetMaterial> _PlanetMaterials;
        private IRepository<Refinable> _Refinables;
        private IRepository<StockMaterial> _StockMaterials;
        private IRepository<TradeMaterial> _TradeMaterials;
        private ICommunService<TradeState> _TradeStates;

        public ICommunService<Categorie> Categories
            => _Categories == null? _Categories = new CommunRepository<Categorie>(ctx) : _Categories;

        public IModeleService Modeles
            => _Modeles == null ? _Modeles = new ModeleRepository(ctx) : _Modeles;

        public ICommunService<Finder> Finders
            => _Finders == null ? _Finders = new CommunRepository<Finder>(ctx) : _Finders;

        public ICommunService<Excavator> Excavators
            => _Excavators == null ? _Excavators = new CommunRepository<Excavator>(ctx) : _Excavators;

        public ICommunService<Refiner> Refiners
            => _Refiners == null ? _Refiners = new CommunRepository<Refiner>(ctx) : _Refiners;

        public ICommunService<FinderAmplifier> FinderAmplifiers
            => _FinderAmplifiers == null ? _FinderAmplifiers = new CommunRepository<FinderAmplifier>(ctx) : _FinderAmplifiers;

        public ICommunService<SearchMode> SearchModes
            => _SearchModes == null ? _SearchModes = new CommunRepository<SearchMode>(ctx) : _SearchModes;

        public ICommunService<Setup> Setups
            => _Setups == null ? _Setups = new CommunRepository<Setup>(ctx) : _Setups;

        public ICommunService<Planet> Planets
            => _Planets == null ? _Planets = new CommunRepository<Planet>(ctx) : _Planets;

        public ICommunService<Enhancer> Enhancers
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

        public ICommunService<TradeState> TradeStates
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
