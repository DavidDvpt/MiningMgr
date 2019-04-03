using WpfApp.Model;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepositoriesUoW
    {
        void Commit();

        ICommunRepository<CategorieModel> Categories { get; }
        ICommunRepository<ModeleModel> Modeles { get; }
        IRepository<FinderModel> Finders { get; }
        IRepository<ExcavatorModel> Excavators { get; }
        IRepository<RefinerModel> Refiners { get; }
        IRepository<FinderAmplifierModel> FinderAmplifiers { get; }
        IRepository<SearchModeModel> SearchModes { get; }
        IRepository<SetupModel> Setups { get; }
        IRepository<PlanetModel> Planets { get; }
        IRepository<EnhancerModel> Enhancers { get; }
        IRepository<MaterialModel> Materials { get; }
        IRepository<ToolAccessoireModel> ToolAccessoires { get; }
        IRepository<PlanetMaterialModel> PlanetMaterials { get; }

    }
}
