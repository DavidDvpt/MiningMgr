using WpfApp.Model.Dto;

namespace WpfApp.Repositories.Interfaces
{
    public interface IRepositoriesDtoUoW
    {
        void Commit();

        ICommunRepositoryDto<CategorieDto> CategoriesDto { get; }
        ICommunRepositoryDto<ModeleDto> ModelesDto { get; }
        IRepositoryDto<FinderDto> FindersDto { get; }
        IRepositoryDto<ExcavatorDto> ExcavatorsDto { get; }
        IRepositoryDto<RefinerDto> RefinersDto { get; }
        IRepositoryDto<FinderAmplifierDto> FinderAmplifiersDto { get; }
        IRepositoryDto<SearchModeDto> SearchModesDto { get; }
        IRepositoryDto<SetupDto> SetupsDto { get; }
        IRepositoryDto<PlanetDto> PlanetsDto { get; }
        IRepositoryDto<EnhancerDto> EnhancersDto { get; }
        IRepositoryDto<MaterialDto> MaterialsDto { get; }
        IRepositoryDto<ToolAccessoireDto> ToolAccessoiresDto { get; }
        IRepositoryDto<PlanetMaterialDto> PlanetMaterialsDto { get; }

    }
}
