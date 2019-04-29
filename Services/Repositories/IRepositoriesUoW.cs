using Services.Context;

namespace Services.Repositories
{
    public interface IRepositoriesUoW
    {
        void Commit();

        MiningContext GetContext();

        ICategorieService CategorieService { get; }
        IModeleService ModeleService { get; }
        IFinderService FinderService { get; }
        IExcavatorService ExcavatorService { get; }
        IRefinerService RefinerService { get; }
        IFinderAmplifierService FinderAmplifierService { get; }
        ISearchModeService SearchModeService { get; }
        ISetupService SetupService { get; }
        IPlanetService PlanetService { get; }
        IEnhancerService EnhancerService { get; }
        I MaterialServiceService { get; }
        IToolAccessoireService ToolAccessoireService { get; }
        IPlanetMaterialService PlanetMaterialService { get; }
        IRefinableService RefinableService { get; }
        IStockMaterialService StockMaterialService { get; }
        ITradeMaterialService TradeMaterialService { get; }
        ITradeStateService TradeStateService { get; }
    }
}
