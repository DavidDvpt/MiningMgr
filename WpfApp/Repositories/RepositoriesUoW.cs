using WpfApp.Context;
using WpfApp.Model.Dto;
using WpfApp.Model.Poco;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.Repositories
{
    public class RepositoriesUoW : IRepositoriesUoW
    {
        private MiningContext ctx;

        public RepositoriesUoW()
        {
            CreateDbContext();
        }

        public RepositoriesUoW(MiningContext context)
        {
            ctx = context;
        }

        private void CreateDbContext()
        {
            ctx = new MiningContext();
        }

        private ICommunRepository<CategorieDto, CategoriePoco> _CategoriesPoco;
        private ICommunRepository<ModeleDto, ModelePoco> _ModelesPoco;
        private IRepository<FinderDto, FinderPoco> _FindersPoco;
        private IRepository<ExcavatorDto, ExcavatorPoco> _ExcavatorsPoco;
        private IRepository<RefinerDto, RefinerPoco> _RefinersPoco;
        private IRepository<FinderAmplifierDto, FinderAmplifierPoco> _FinderAmplifiersPoco;
        private IRepository<SearchModeDto, SearchModePoco> _SearchModesPoco;
        private IRepository<SetupDto, SetupPoco> _SetupsPoco;
        private IRepository<PlanetDto, PlanetPoco> _PlanetsPoco;
        private IRepository<EnhancerDto, EnhancerPoco> _EnhancersPoco;
        private IRepository<MaterialDto, MaterialPoco> _MaterialsPoco;
        private IRepository<ToolAccessoireDto, ToolAccessoirePoco> _ToolAccessoiresPoco;
        private IRepository<PlanetMaterialDto, PlanetMaterialPoco> _PlanetMaterialsPoco;

        public ICommunRepository<CategorieDto, CategoriePoco> CategoriesPoco
            => _CategoriesPoco == null? _CategoriesPoco = new CommunRepository<CategorieDto, CategoriePoco>(ctx) : _CategoriesPoco;

        public ICommunRepository<ModeleDto, ModelePoco> ModelesPoco
            => _ModelesPoco == null ? _ModelesPoco = new CommunRepository<ModeleDto, ModelePoco>(ctx) : _ModelesPoco;

        public IRepository<FinderDto, FinderPoco> FindersPoco
            => _FindersPoco == null ? _FindersPoco = new Repository<FinderDto, FinderPoco>(ctx) : _FindersPoco;

        public IRepository<ExcavatorDto, ExcavatorPoco> ExcavatorsPoco
            => _ExcavatorsPoco == null ? _ExcavatorsPoco = new Repository<ExcavatorDto, ExcavatorPoco>(ctx) : _ExcavatorsPoco;

        public IRepository<RefinerDto, RefinerPoco> RefinersPoco
            => _RefinersPoco == null ? _RefinersPoco = new Repository<RefinerDto, RefinerPoco>(ctx) : _RefinersPoco;

        public IRepository<FinderAmplifierDto, FinderAmplifierPoco> FinderAmplifiersPoco
            => _FinderAmplifiersPoco == null ? _FinderAmplifiersPoco = new Repository<FinderAmplifierDto, FinderAmplifierPoco>(ctx) : _FinderAmplifiersPoco;

        public IRepository<SearchModeDto, SearchModePoco> SearchModesPoco
            => _SearchModesPoco == null ? _SearchModesPoco = new Repository<SearchModeDto, SearchModePoco>(ctx) : _SearchModesPoco;

        public IRepository<SetupDto, SetupPoco> SetupsPoco
            => _SetupsPoco == null ? _SetupsPoco = new Repository<SetupDto, SetupPoco>(ctx) : _SetupsPoco;

        public IRepository<PlanetDto, PlanetPoco> PlanetsPoco
            => _PlanetsPoco == null ? _PlanetsPoco = new Repository<PlanetDto, PlanetPoco>(ctx) : _PlanetsPoco;

        public IRepository<EnhancerDto, EnhancerPoco> EnhancersPoco
            => _EnhancersPoco == null? _EnhancersPoco = new Repository<EnhancerDto, EnhancerPoco>(ctx) : _EnhancersPoco;

        public IRepository<MaterialDto, MaterialPoco> MaterialsPoco
            => _MaterialsPoco == null? _MaterialsPoco = new Repository<MaterialDto, MaterialPoco>(ctx) : _MaterialsPoco;

        public IRepository<ToolAccessoireDto, ToolAccessoirePoco> ToolAccessoiresPoco
            => _ToolAccessoiresPoco == null ? _ToolAccessoiresPoco = new Repository<ToolAccessoireDto, ToolAccessoirePoco>(ctx) : _ToolAccessoiresPoco;

        public IRepository<PlanetMaterialDto, PlanetMaterialPoco> PlanetMaterialsPoco
            => PlanetMaterialPoco == null ? PlanetMaterialPoco = new Repository<PlanetMaterialDto, PlanetMaterialPoco>(ctx) : _PlanetMaterialsPoco;

        public void Commit()
        {
            ctx.SaveChanges();
        }
    }
}
