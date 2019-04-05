using WpfApp.Model;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepositoriesUoW
    {
        void Commit();

        ICommunRepository<CategorieDto> Categories { get; }
        ICommunRepository<ModeleDto> Modeles { get; }
        IRepository<FinderDto> Finders { get; }
        IRepository<ExcavatorDto> Excavators { get; }
        IRepository<RefinerDto> Refiners { get; }
        IRepository<FinderAmplifierDto> FinderAmplifiers { get; }
        IRepository<SearchModeDto> SearchModes { get; }
        IRepository<SetupDto> Setups { get; }
        IRepository<PlanetDto> Planets { get; }
        IRepository<EnhancerDto> Enhancers { get; }
        IRepository<MaterialDto> Materials { get; }
        IRepository<ToolAccessoireDto> ToolAccessoires { get; }
        IRepository<PlanetMaterialDto> PlanetMaterials { get; }

    }
}
