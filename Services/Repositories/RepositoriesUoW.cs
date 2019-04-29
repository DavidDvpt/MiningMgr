using Services.Context;
using Services.Interfaces;

namespace Services.Repositories
{
    public class RepositoriesUoW : IRepositoriesUoW
    {
        #region Champs

        private MiningContext ctx;

        #endregion

        #region Constructeurs

        public RepositoriesUoW()
        {
            CreateDbContext();
        }

        public RepositoriesUoW(MiningContext context)
        {
            ctx = context;
        }

        #endregion

        public void Commit()
        {
            ctx.SaveChanges();
        }

        public MiningContext GetContext()
        {
            return ctx;
        }

        //public ICategorieService CategorieService { get; private set; } = new CategorieService(ctx);
        //public IModeleService ModeleService { get; private set; } = new ModeleService(ctx);
        //public IFinderService FinderService { get; private set; } = new FinderService(ctx);
        //public IExcavatorService ExcavatorService { get; private set; } = new ExcavatorService(ctx);
        //public IRefinerService RefinerService { get; private set; } = new RefinerService(ctx);
        //public IFinderAmplifierService FinderAmplifierService { get; private set; } = new FinderAmplifierService(ctx);
        //public ISearchModeService SearchModeService { get; private set; } = new SearchModeService(ctx);
        //public ISetupService SetupService { get; private set; } = new SetupService(ctx);
        //public IPlanetService PlanetService { get; private set; } = new PlanetService(ctx);
        //public IEnhancerService EnhancerService { get; private set; } = new EnhancerService(ctx);
        //public IMaterialService MaterialService { get; private set; } = new MaterialService(ctx);
        //public IToolAccessoireService ToolAccessoireService { get; private set; } = new ToolAccessoireService(ctx);
        //public IPlanetMaterialService PlanetMaterialService { get; private set; } = new PlanetMaterialService(ctx);
        //public IRefinableService RefinableService { get; private set; } = new Refinables(ctx);
        //public IStockMaterialService StockMaterialService { get; private set; } = new StockMaterialService(ctx);
        //public ITradeMaterialService TradeMaterialService { get; private set; } = new TradeMaterialService(ctx);
        //public ITradeStateService TradeStateService { get; private set; } = new TradeStateService(ctx);

        #region private

        private void CreateDbContext()
        {
            ctx = new MiningContext();
        }

        #endregion

        /*public ICommunService<Categorie> Categories
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
            => _TradeStates == null ? _TradeStates = new CommunRepository<TradeState>(ctx) : _TradeStates;*/


    }
}
