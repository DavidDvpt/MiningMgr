using WpfApp.Context;
using WpfApp.Model;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepositoriesUoW
    {
        void Commit();

        MiningContext GetContext();

        ICommunRepository<Categorie> Categories { get; }
        IModeleRepository Modeles { get; }
        ICommunRepository<Finder> Finders { get; }
        ICommunRepository<Excavator> Excavators { get; }
        ICommunRepository<Refiner> Refiners { get; }
        ICommunRepository<FinderAmplifier> FinderAmplifiers { get; }
        ICommunRepository<SearchMode> SearchModes { get; }
        ICommunRepository<Setup> Setups { get; }
        ICommunRepository<Planet> Planets { get; }
        ICommunRepository<Enhancer> Enhancers { get; }
        IMaterialRepository Materials { get; }
        IRepository<ToolAccessoire> ToolAccessoires { get; }
        IRepository<PlanetMaterial> PlanetMaterials { get; }
        IRepository<Refinable> Refinables { get; }
    }
}
