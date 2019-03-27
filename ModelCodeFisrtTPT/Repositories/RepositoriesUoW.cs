using ModelCodeFisrtTPT.Dto;
using ModelCodeFisrtTPT.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Repositories
{
    public class RepositoriesUoW : IRepositoriesUoW
    {
        private Context ctx;

        public RepositoriesUoW()
        {
            CreateDbContext();
        }

        public RepositoriesUoW(Context context)
        {
            ctx = context;
        }

        private void CreateDbContext()
        {
            ctx = new Context();
        }

        private ICommunRepository<Categorie> _Categories;
        private ICommunRepository<Modele> _Modeles;
        private IRepository<Finder> _Finders;
        private IRepository<Excavator> _Excavators;
        private IRepository<Refiner> _Refiners;
        private IRepository<FinderAmplifier> _FinderAmplifiers;
        private IRepository<SearchMode> _SearchModes;
        private IRepository<Setup> _Setups;
        private IRepository<Planet> _Planets;
        private IRepository<Enhancer> _Enhancers;
        private IRepository<Material> _Materials;
        private IRepository<ToolAccessoire> _ToolAccessoires;
        private IRepository<PlanetMaterial> _PlanetMaterials;

        public ICommunRepository<Categorie> Categories
            => _Categories == null? _Categories = new CommunRepository<Categorie>(ctx) : _Categories;

        public ICommunRepository<Modele> Modeles
            => _Modeles == null ? _Modeles = new CommunRepository<Modele>(ctx) : _Modeles;

        public IRepository<Finder> Finders
            => _Finders == null ? _Finders = new Repository<Finder>(ctx) : _Finders;

        public IRepository<Excavator> Excavators
            => _Excavators == null ? _Excavators = new Repository<Excavator>(ctx) : _Excavators;

        public IRepository<Refiner> Refiners
            => _Refiners == null ? _Refiners = new Repository<Refiner>(ctx) : _Refiners;

        public IRepository<FinderAmplifier> FinderAmplifiers
            => _FinderAmplifiers == null ? _FinderAmplifiers = new Repository<FinderAmplifier>(ctx) : _FinderAmplifiers;

        public IRepository<SearchMode> SearchModes
            => _SearchModes == null ? _SearchModes = new Repository<SearchMode>(ctx) : _SearchModes;

        public IRepository<Setup> Setups
            => _Setups == null ? _Setups = new Repository<Setup>(ctx) : _Setups;

        public IRepository<Planet> Planets
            => _Planets == null ? _Planets = new Repository<Planet>(ctx) : _Planets;

        public IRepository<Enhancer> Enhancers
            => _Enhancers == null? _Enhancers = new Repository<Enhancer>(ctx) : _Enhancers;

        public IRepository<Material> Materials
            => _Materials == null? _Materials = new Repository<Material>(ctx) : _Materials;

        public IRepository<ToolAccessoire> ToolAccessoires
            => _ToolAccessoires == null ? _ToolAccessoires = new Repository<ToolAccessoire>(ctx) : _ToolAccessoires;

        public IRepository<PlanetMaterial> PlanetMaterials
            => _PlanetMaterials == null ? _PlanetMaterials = new Repository<PlanetMaterial>(ctx) : _PlanetMaterials;

        public void Commit()
        {
            ctx.SaveChanges();
        }
    }
}
