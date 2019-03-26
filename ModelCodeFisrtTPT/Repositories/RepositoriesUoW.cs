﻿using ModelCodeFisrtTPT.Dto;
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

        private IRepository<Categorie> _Categories;
        private IRepository<Modele> _Modeles;
        private IRepository<Finder> _Finders;
        private IRepository<Excavator> _Excavators;
        private IRepository<Refiner> _Refiners;
        private IRepository<SearchMode> _SearchModes;
        private IRepository<Setup> _Setups;
        private IRepository<Planet> _Planets;
        private IRepository<Enhancer> _Enhancers;
        private IRepository<Material> _Materials;
        private IRepository<ToolAccessoire> _ToolAccessoires;
        private IRepository<PlanetMaterial> _PlanetMaterials;

        public IRepository<Categorie> Categories
            => _Categories == null? _Categories = new Repository<Categorie>(ctx) : _Categories;

        public IRepository<Modele> Modeles
            => _Modeles == null ? _Modeles = new Repository<Modele>(ctx) : _Modeles;

        public IRepository<Finder> Finders
            => _Finders == null ? _Finders = new Repository<Finder>(ctx) : _Finders;

        public IRepository<Excavator> Excavators
            => _Excavators == null ? _Excavators = new Repository<Excavator>(ctx) : _Excavators;

        public IRepository<Refiner> Refiners
            => _Refiners == null ? _Refiners = new Repository<Refiner>(ctx) : _Refiners;

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