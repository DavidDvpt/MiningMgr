using WpfApp.Context;
using WpfApp.Model.Dto;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepositoriesDtoUoW
    {
        void Commit();

        MiningContext GetContext();

        ICommunRepositoryDto<CategorieDto> CategoriesDto { get; }
        IModeleRepositoryDto ModelesDto { get; }
        ICommunRepositoryDto<FinderDto> FindersDto { get; }
        ICommunRepositoryDto<ExcavatorDto> ExcavatorsDto { get; }
        ICommunRepositoryDto<RefinerDto> RefinersDto { get; }
        ICommunRepositoryDto<FinderAmplifierDto> FinderAmplifiersDto { get; }
        ICommunRepositoryDto<SearchModeDto> SearchModesDto { get; }
        ICommunRepositoryDto<SetupDto> SetupsDto { get; }
        ICommunRepositoryDto<PlanetDto> PlanetsDto { get; }
        ICommunRepositoryDto<EnhancerDto> EnhancersDto { get; }
        IMaterialRepositoryDto MaterialsDto { get; }
        IRepositoryDto<ToolAccessoireDto> ToolAccessoiresDto { get; }
        IRepositoryDto<PlanetMaterialDto> PlanetMaterialsDto { get; }

    }
}
