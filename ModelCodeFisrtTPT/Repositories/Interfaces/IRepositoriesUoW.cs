using ModelCodeFisrtTPT.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Repositories.Interfaces
{
    public interface IRepositoriesUoW
    {
        void Commit();

        IRepository<Categorie> Categories { get; }
        IRepository<Modele> Modeles { get; }
        IRepository<Finder> Finders { get; }
        IRepository<Excavator> Excavators { get; }
        IRepository<Refiner> Refiners { get; }
        IRepository<SearchMode> SearchModes { get; }
        IRepository<Setup> Setups { get; }
        IRepository<Planet> Planets { get; }
        IRepository<Enhancer> Enhancers { get; }
        IRepository<Material> Materials { get; }
        IRepository<ToolAccessoire> ToolAccessoires { get; }
        IRepository<PlanetMaterial> PlanetMaterials { get; }

    }
}
