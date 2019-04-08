using WpfApp.Context;
using WpfApp.Model.Dto;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.Repositories
{
    public class RepositoriesDtoUoW : IRepositoriesDtoUoW
    {
        private MiningContext ctx;

        public RepositoriesDtoUoW()
        {
            CreateDbContext();
        }

        public RepositoriesDtoUoW(MiningContext context)
        {
            ctx = context;
        }

        private void CreateDbContext()
        {
            ctx = new MiningContext();
        }

        private ICommunRepositoryDto<CategorieDto> _CategoriesDto;
        private ICommunRepositoryDto<ModeleDto> _ModelesDto;
        private IRepositoryDto<FinderDto> _FindersDto;
        private IRepositoryDto<ExcavatorDto> _ExcavatorsDto;
        private IRepositoryDto<RefinerDto> _RefinersDto;
        private IRepositoryDto<FinderAmplifierDto> _FinderAmplifiersDto;
        private IRepositoryDto<SearchModeDto> _SearchModesDto;
        private IRepositoryDto<SetupDto> _SetupsDto;
        private IRepositoryDto<PlanetDto> _PlanetsDto;
        private IRepositoryDto<EnhancerDto> _EnhancersDto;
        private IRepositoryDto<MaterialDto> _MaterialsDto;
        private IRepositoryDto<ToolAccessoireDto> _ToolAccessoiresDto;
        private IRepositoryDto<PlanetMaterialDto> _PlanetMaterialsDto;

        public ICommunRepositoryDto<CategorieDto> CategoriesDto
            => _CategoriesDto == null? _CategoriesDto = new CommunRepositoryDto<CategorieDto>(ctx) : _CategoriesDto;

        public ICommunRepositoryDto<ModeleDto> ModelesDto
            => _ModelesDto == null ? _ModelesDto = new CommunRepositoryDto<ModeleDto>(ctx) : _ModelesDto;

        public IRepositoryDto<FinderDto> FindersDto
            => _FindersDto == null ? _FindersDto = new RepositoryDto<FinderDto>(ctx) : _FindersDto;

        public IRepositoryDto<ExcavatorDto> ExcavatorsDto
            => _ExcavatorsDto == null ? _ExcavatorsDto = new RepositoryDto<ExcavatorDto>(ctx) : _ExcavatorsDto;

        public IRepositoryDto<RefinerDto> RefinersDto
            => _RefinersDto == null ? _RefinersDto = new RepositoryDto<RefinerDto>(ctx) : _RefinersDto;

        public IRepositoryDto<FinderAmplifierDto> FinderAmplifiersDto
            => _FinderAmplifiersDto == null ? _FinderAmplifiersDto = new RepositoryDto<FinderAmplifierDto>(ctx) : _FinderAmplifiersDto;

        public IRepositoryDto<SearchModeDto> SearchModesDto
            => _SearchModesDto == null ? _SearchModesDto = new RepositoryDto<SearchModeDto>(ctx) : _SearchModesDto;

        public IRepositoryDto<SetupDto> SetupsDto
            => _SetupsDto == null ? _SetupsDto = new RepositoryDto<SetupDto>(ctx) : _SetupsDto;

        public IRepositoryDto<PlanetDto> PlanetsDto
            => _PlanetsDto == null ? _PlanetsDto = new RepositoryDto<PlanetDto>(ctx) : _PlanetsDto;

        public IRepositoryDto<EnhancerDto> EnhancersDto
            => _EnhancersDto == null? _EnhancersDto = new RepositoryDto<EnhancerDto>(ctx) : _EnhancersDto;

        public IRepositoryDto<MaterialDto> MaterialsDto
            => _MaterialsDto == null? _MaterialsDto = new RepositoryDto<MaterialDto>(ctx) : _MaterialsDto;

        public IRepositoryDto<ToolAccessoireDto> ToolAccessoiresDto
            => _ToolAccessoiresDto == null ? _ToolAccessoiresDto = new RepositoryDto<ToolAccessoireDto>(ctx) : _ToolAccessoiresDto;

        public IRepositoryDto<PlanetMaterialDto> PlanetMaterialsDto
            => _PlanetMaterialsDto == null ? _PlanetMaterialsDto = new RepositoryDto<PlanetMaterialDto>(ctx) : _PlanetMaterialsDto;

        public void Commit()
        {
            ctx.SaveChanges();
        }
    }
}
