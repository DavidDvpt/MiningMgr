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
        private IModeleRepositoryDto _ModelesDto;
        private ICommunRepositoryDto<FinderDto> _FindersDto;
        private ICommunRepositoryDto<ExcavatorDto> _ExcavatorsDto;
        private ICommunRepositoryDto<RefinerDto> _RefinersDto;
        private ICommunRepositoryDto<FinderAmplifierDto> _FinderAmplifiersDto;
        private ICommunRepositoryDto<SearchModeDto> _SearchModesDto;
        private ICommunRepositoryDto<SetupDto> _SetupsDto;
        private ICommunRepositoryDto<PlanetDto> _PlanetsDto;
        private ICommunRepositoryDto<EnhancerDto> _EnhancersDto;
        private IMaterialRepositoryDto _MaterialsDto;
        private IRepositoryDto<ToolAccessoireDto> _ToolAccessoiresDto;
        private IRepositoryDto<PlanetMaterialDto> _PlanetMaterialsDto;
        private IRepositoryDto<RefinableDto> _RefinablesDto;

        public ICommunRepositoryDto<CategorieDto> CategoriesDto
            => _CategoriesDto == null? _CategoriesDto = new CommunRepositoryDto<CategorieDto>(ctx) : _CategoriesDto;

        public IModeleRepositoryDto ModelesDto
            => _ModelesDto == null ? _ModelesDto = new ModeleRepositoryDto(ctx) : _ModelesDto;

        public ICommunRepositoryDto<FinderDto> FindersDto
            => _FindersDto == null ? _FindersDto = new CommunRepositoryDto<FinderDto>(ctx) : _FindersDto;

        public ICommunRepositoryDto<ExcavatorDto> ExcavatorsDto
            => _ExcavatorsDto == null ? _ExcavatorsDto = new CommunRepositoryDto<ExcavatorDto>(ctx) : _ExcavatorsDto;

        public ICommunRepositoryDto<RefinerDto> RefinersDto
            => _RefinersDto == null ? _RefinersDto = new CommunRepositoryDto<RefinerDto>(ctx) : _RefinersDto;

        public ICommunRepositoryDto<FinderAmplifierDto> FinderAmplifiersDto
            => _FinderAmplifiersDto == null ? _FinderAmplifiersDto = new CommunRepositoryDto<FinderAmplifierDto>(ctx) : _FinderAmplifiersDto;

        public ICommunRepositoryDto<SearchModeDto> SearchModesDto
            => _SearchModesDto == null ? _SearchModesDto = new CommunRepositoryDto<SearchModeDto>(ctx) : _SearchModesDto;

        public ICommunRepositoryDto<SetupDto> SetupsDto
            => _SetupsDto == null ? _SetupsDto = new CommunRepositoryDto<SetupDto>(ctx) : _SetupsDto;

        public ICommunRepositoryDto<PlanetDto> PlanetsDto
            => _PlanetsDto == null ? _PlanetsDto = new CommunRepositoryDto<PlanetDto>(ctx) : _PlanetsDto;

        public ICommunRepositoryDto<EnhancerDto> EnhancersDto
            => _EnhancersDto == null? _EnhancersDto = new CommunRepositoryDto<EnhancerDto>(ctx) : _EnhancersDto;

        public IMaterialRepositoryDto MaterialsDto
            => _MaterialsDto == null? _MaterialsDto = new MaterialRepositoryDto(ctx) : _MaterialsDto;

        public IRepositoryDto<ToolAccessoireDto> ToolAccessoiresDto
            => _ToolAccessoiresDto == null ? _ToolAccessoiresDto = new RepositoryDto<ToolAccessoireDto>(ctx) : _ToolAccessoiresDto;

        public IRepositoryDto<PlanetMaterialDto> PlanetMaterialsDto
            => _PlanetMaterialsDto == null ? _PlanetMaterialsDto = new RepositoryDto<PlanetMaterialDto>(ctx) : _PlanetMaterialsDto;

        public IRepositoryDto<RefinableDto> RefinablesDto
            => _RefinablesDto == null ? _RefinablesDto = new RepositoryDto<RefinableDto>(ctx) : _RefinablesDto;

        public void Commit()
        {
            ctx.SaveChanges();
        }

        public MiningContext GetContext()
        {
            return ctx;
        }
    }
}
