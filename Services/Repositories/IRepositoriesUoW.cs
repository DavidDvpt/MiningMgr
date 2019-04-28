using Services.Context;
using Model;

namespace Services.Repositories
{
    public interface IRepositoriesUoW
    {
        void Commit();

        MiningContext GetContext();

        ICommunService<Categorie> Categories { get; }
        IModeleService Modeles { get; }
        ICommunService<Finder> Finders { get; }
        ICommunService<Excavator> Excavators { get; }
        ICommunService<Refiner> Refiners { get; }
        ICommunService<FinderAmplifier> FinderAmplifiers { get; }
        ICommunService<SearchMode> SearchModes { get; }
        ICommunService<Setup> Setups { get; }
        ICommunService<Planet> Planets { get; }
        ICommunService<Enhancer> Enhancers { get; }
        IMaterialRepository Materials { get; }
        IRepository<ToolAccessoire> ToolAccessoires { get; }
        IRepository<PlanetMaterial> PlanetMaterials { get; }
        IRepository<Refinable> Refinables { get; }
        IRepository<StockMaterial> StockMaterials { get; }
        IRepository<TradeMaterial> TradeMaterials { get; }
        ICommunService<TradeState> TradeStates { get; }
    }
}
