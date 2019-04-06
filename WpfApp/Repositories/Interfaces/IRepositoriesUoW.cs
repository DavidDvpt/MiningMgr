using WpfApp.Model.Dto;
using WpfApp.Model.Poco;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepositoriesUoW
    {
        void Commit();

        ICommunRepository<CategorieDto, CategoriePoco> CategoriesPoco { get; }
        ICommunRepository<ModeleDto, ModelePoco> ModelesPoco { get; }
        IRepository<FinderDto, FinderPoco> FindersPoco { get; }
        IRepository<ExcavatorDto, ExcavatorPoco> ExcavatorsPoco { get; }
        IRepository<RefinerDto, RefinerPoco> RefinersPoco { get; }
        IRepository<FinderAmplifierDto, FinderAmplifierPoco> FinderAmplifiersPoco { get; }
        IRepository<SearchModeDto, SearchModePoco> SearchModesPoco { get; }
        IRepository<SetupDto, SetupPoco> SetupsPoco { get; }
        IRepository<PlanetDto, PlanetPoco> PlanetsPoco { get; }
        IRepository<EnhancerDto, EnhancerPoco> EnhancersPoco { get; }
        IRepository<MaterialDto, MaterialPoco> MaterialsPoco { get; }
        IRepository<ToolAccessoireDto, ToolAccessoirePoco> ToolAccessoiresPoco { get; }
        IRepository<PlanetMaterialDto, PlanetMaterialPoco> PlanetMaterialsPoco { get; }

    }
}
