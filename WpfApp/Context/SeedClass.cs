using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;
using System.Data.Entity;
using WpfApp.Model.Dto;
using System;

namespace WpfApp.Context
{
    public class SeedClass : CreateDatabaseIfNotExists<MiningContext>
    {
        private IRepositoriesDtoUoW repositories;

        protected override void Seed(MiningContext ctx)
        {
            repositories = new RepositoriesDtoUoW(ctx);

            SeedLauch();

            base.Seed(ctx);
        }

        private void SeedLauch()
        {
            AddCategories();
            AddModeles();
            AddDtolAccessoire();
            AddPlanets();
            AddFinders();
            AddExcavators();
            AddRefiners();
            AddFinderAmplifiers();
            AddEnhancers();
            AddEnmatters();
            //AddOres();
            //AddTreasures();
            //AddPlanetMaterial(repositories);

            AddSearchModes();
        }

        private void AddCategories()
        {
            repositories.CategoriesDto.Add(new CategorieDto() { Nom = "Tool" });
            repositories.CategoriesDto.Add(new CategorieDto() { Nom = "Accessoire" });
            repositories.CategoriesDto.Add(new CategorieDto() { Nom = "Material" });
        }

        private void AddModeles()
        {
            int id = repositories.CategoriesDto.GetByNom("Tool").Id;
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Finder", IsStackable = false, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Excavator", IsStackable = false, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Refiner", IsStackable = false, CategorieId = id });

            id = repositories.CategoriesDto.GetByNom("Accessoire").Id;
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Finder Amplifier", IsStackable = false, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Finder Depth Enhancer", IsStackable = true, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Finder Range Enhancer", IsStackable = true, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Finder Skill Enhancer", IsStackable = true, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Excavator Speed Enhancer", IsStackable = true, CategorieId = id });

            id = repositories.CategoriesDto.GetByNom("Material").Id;
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Ore", IsStackable = true, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Enmatter", IsStackable = true, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Treasure", IsStackable = true, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Refined Ore", IsStackable = true, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Refined Enmatter", IsStackable = true, CategorieId = id });
            repositories.ModelesDto.Add(new ModeleDto() { Nom = "Refined Treasure", IsStackable = true, CategorieId = id });
        }

        private void AddDtolAccessoire()
        {
            int tId = repositories.ModelesDto.GetByNom("Finder").Id;
            repositories.ToolAccessoiresDto.Add(new ToolAccessoireDto() { ToolId = tId, AccessoireId = repositories.ModelesDto.GetByNom("Finder Amplifier").Id });
            repositories.ToolAccessoiresDto.Add(new ToolAccessoireDto() { ToolId = tId, AccessoireId = repositories.ModelesDto.GetByNom("Finder Depth Enhancer").Id });
            repositories.ToolAccessoiresDto.Add(new ToolAccessoireDto() { ToolId = tId, AccessoireId = repositories.ModelesDto.GetByNom("Finder Range Enhancer").Id });
            repositories.ToolAccessoiresDto.Add(new ToolAccessoireDto() { ToolId = tId, AccessoireId = repositories.ModelesDto.GetByNom("Finder Skill Enhancer").Id });

            tId = repositories.ModelesDto.GetByNom("Excavator").Id;
            repositories.ToolAccessoiresDto.Add(new ToolAccessoireDto() { ToolId = tId, AccessoireId = repositories.ModelesDto.GetByNom("Excavator Speed Enhancer").Id });
        }

        private void AddPlanets()
        {
            repositories.PlanetsDto.Add(new PlanetDto() { Nom = "Calypso" });
            repositories.PlanetsDto.Add(new PlanetDto() { Nom = "Arkadia" });
            repositories.PlanetsDto.Add(new PlanetDto() { Nom = "F.O.M.A." });
            repositories.PlanetsDto.Add(new PlanetDto() { Nom = "Toulan" });
            repositories.PlanetsDto.Add(new PlanetDto() { Nom = "Rocktropia" });
        }

        private void AddFinders()
        {
            int id = repositories.ModelesDto.GetByNom("Finder").Id;
            repositories.FindersDto.Add(new FinderDto() { Nom = "A.R.C. Finder 0001 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.25M, Range = 54, Depth = 204, UsePerMin = 9, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "CDF Finder z10 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 1, Decay = 0, Range = 54, Depth = 223.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "CDF Finder z25 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 2, Decay = 0.56M, Range = 54.2M, Depth = 422.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "CDF Finder z40 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 4, Decay = 0, Range = 54.6M, Depth = 741.3M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Demonic Detector MK-I (L)", Code = "", IsLimited = true, ModeleId = id, Value = 4.75M, Decay = 0.5M, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "DSEC Seeker L2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 18.6M, Decay = 0, Range = 55, Depth = 213.9M, UsePerMin = 0, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "DSEC Seeker L12 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 49, Decay = 2.29M, Range = 55, Depth = 462.7M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "DSEC Seeker L30 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 136, Decay = 3.96M, Range = 55, Depth = 820.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "eMINE FS (L)", Code = "", IsLimited = true, ModeleId = id, Value = 122, Decay = 1.743M, Range = 54, Depth = 676.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-101", Code = "F101", IsLimited = false, ModeleId = id, Value = 5.5M, Decay = 1, Range = 54, Depth = 263.7M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-102", Code = "F102", IsLimited = false, ModeleId = id, Value = 30, Decay = 1.15M, Range = 54, Depth = 323.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-103", Code = "F103", IsLimited = false, ModeleId = id, Value = 55, Decay = 1.45M, Range = 54.5M, Depth = 363.2M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-104", Code = "F104", IsLimited = false, ModeleId = id, Value = 66.6M, Decay = 1.63M, Range = 54.5M, Depth = 432.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-105", Code = "F105", IsLimited = false, ModeleId = id, Value = 82, Decay = 2.05M, Range = 55, Depth = 522.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-105 TEN Edition", Code = "", IsLimited = false, ModeleId = id, Value = 82, Decay = 2, Range = 55, Depth = 552.3M, UsePerMin = 9, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-106", Code = "", IsLimited = false, ModeleId = id, Value = 79.95M, Decay = 1.799M, Range = 55, Depth = 582.1M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-210 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 105, Decay = 1.25M, Range = 54, Depth = 383.1M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-211 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 121.2M, Decay = 1.306M, Range = 55, Depth = 472.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-212 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 155.2M, Decay = 1.343M, Range = 55, Depth = 592, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-212, SGA Edition (L)", Code = "", IsLimited = true, ModeleId = id, Value = 155.2M, Decay = 0, Range = 55, Depth = 612, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-213 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 201.2M, Decay = 1.66M, Range = 54.5M, Depth = 631.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-213 (L) Adapted", Code = "", IsLimited = true, ModeleId = id, Value = 678, Decay = 2.33M, Range = 54, Depth = 811, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-213 (L) Customized", Code = "", IsLimited = true, ModeleId = id, Value = 2678, Decay = 2.68M, Range = 55, Depth = 850.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Finder F-214 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 231.2M, Decay = 0, Range = 54, Depth = 651.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Genesis Rookie Finder (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.06M, Decay = 0.239M, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Genesis Star Rookie Finder (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Imperium Detectonator X2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 170M, Decay = 7, Range = 54, Depth = 626.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Imperium Trainee Finder (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.52M, Range = 54, Depth = 204, UsePerMin = 9, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Island Ziplex Z1 Seeker", Code = "", IsLimited = false, ModeleId = id, Value = 2.4M, Decay = 0.751M, Range = 55, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Lost Soul Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 48, Decay = 3.7M, Range = 54.8M, Depth = 721, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "NI Finder New Settler Issue (L)", Code = "", IsLimited = true, ModeleId = id, Value = 1, Decay = 0, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Omegaton Detectonator MD-1 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.239M, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Sabad Finder M1 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 2, Decay = 0.751M, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Sabad Finder M2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 26, Decay = 0, Range = 55, Depth = 303.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Sabad Finder M3 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Sabad Finder M4 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 78, Decay = 0, Range = 55, Depth = 477.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Sabad Finder M5 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 1 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 2.5M, Decay = 1.5M, Range = 55, Depth = 206, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 2.2M, Range = 55, Depth = 408, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 3 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 95, Decay = 3.225M, Range = 55, Depth = 631.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 3 Gold Rush", Code = "", IsLimited = false, ModeleId = id, Value = 95, Decay = 3.225M, Range = 55, Depth = 631.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 4 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 150, Decay = 3.72M, Range = 55, Depth = 741.3M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 5 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 205, Decay = 4.125M, Range = 55, Depth = 830.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 6 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 260, Decay = 4.372M, Range = 55, Depth = 885.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 7 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 320, Decay = 4.552M, Range = 55, Depth = 925.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 8 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 390, Decay = 4.89M, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster 8 Gold Rush", Code = "", IsLimited = false, ModeleId = id, Value = 390, Decay = 0, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster Trainer (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.4M, Decay = 0.75M, Range = 55, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "TerraMaster TT (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.239M, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A10 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 50, Decay = 1.5M, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A13 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 51, Decay = 0, Range = 54, Depth = 223.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A16 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 52, Decay = 0, Range = 54, Depth = 253.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A19 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 53, Decay = 1.8M, Range = 55, Depth = 303.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A22 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 54, Decay = 1.9M, Range = 55, Depth = 403, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A25 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 2, Range = 55.1M, Depth = 502.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A28 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 56, Decay = 0, Range = 55.2M, Depth = 602, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A31 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 57, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A33 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 58, Decay = 0, Range = 55.2M, Depth = 801, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex A35 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 59, Decay = 0, Range = 55.2M, Depth = 900.5M, UsePerMin = 0, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex B35 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 50, Decay = 3, Range = 55, Depth = 502.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex B40 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 51, Decay = 0, Range = 55.1M, Depth = 522.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex B50 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 52, Decay = 3.2M, Range = 55.2M, Depth = 542.3M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex B60 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 53, Decay = 0, Range = 55.2M, Depth = 562.2M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex B70 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 54, Decay = 3, Range = 55.2M, Depth = 582.1M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex C50 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 40, Decay = 0, Range = 55.2M, Depth = 283.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex C65 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 44, Decay = 1.2M, Range = 55.2M, Depth = 313.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex C70 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 46, Decay = 1.2M, Range = 55.2M, Depth = 363.2M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex D33 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 44, Decay = 3.6M, Range = 54, Depth = 801, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex D44 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 46, Decay = 3.2M, Range = 54, Depth = 900.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex D52 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 3, Range = 54.5M, Depth = 990, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex P20 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex P30 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0.16M, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex P50 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex P85 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex P160 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0.7M, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex TK120 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 218.6M, Decay = 1.803M, Range = 55, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex TK220 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 264.8M, Decay = 3.96M, Range = 55, Depth = 776.1M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex TK320 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 311, Decay = 4.303M, Range = 55, Depth = 850.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex TK320 Seeker, SGA Edition (L)", Code = "", IsLimited = true, ModeleId = id, Value = 233.25M, Decay = 0, Range = 55, Depth = 870.7M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex VRX2000 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 339, Decay = 4.651M, Range = 55, Depth = 925.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex VRX3000 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 387, Decay = 5.01M, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex Z1 Seeker", Code = "", IsLimited = false, ModeleId = id, Value = 2.4M, Decay = 1.501M, Range = 55, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex Z5 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 29.8M, Decay = 1.855M, Range = 55, Depth = 303.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex Z10 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 2.209M, Range = 55, Depth = 403, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex Z10 Seeker, SGA Edition (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex Z15 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 80, Decay = 2.557M, Range = 55, Depth = 477.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex Z20 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 126.2M, Decay = 1.452M, Range = 55, Depth = 552.3M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.FindersDto.Add(new FinderDto() { Nom = "Ziplex Z25 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 172.4M, Decay = 3.251M, Range = 55, Depth = 626.9M, UsePerMin = 8, BasePecSearch = 50 });
        }

        private void AddExcavators()
        {
            int id = repositories.ModelesDto.GetByNom("Excavator").Id;
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "ARD Excavator A-100 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "ARD Excavator Beginner (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.5M, Decay = 0, Efficienty = 1.2M, UsePerMin = 17 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "ARD Excavator M1 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 2.4M, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "ARD Excavator M2 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 54, Decay = 0, Efficienty = 9.2M, UsePerMin = 24 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "ARD Excavator M3 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "ARD Excavator M4 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "ARD Excavator M5 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 132, Decay = 2.336M, Efficienty = 12.8M, UsePerMin = 26 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Demonic Excavator MK-I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 5, Decay = 0.1M, Efficienty = 0.6M, UsePerMin = 17 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Earth Excavator ME/01", ModeleId = id, Code = "", IsLimited = false, Value = 2.4M, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "eMINE E (L)", ModeleId = id, Code = "", IsLimited = true, Value = 85, Decay = 2.101M, Efficienty = 12, UsePerMin = 27 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Rookie Extractor (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.01M, Decay = 0, Efficienty = 1.2M, UsePerMin = 17 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Basic Excavator (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Earth Excavator ME/02", ModeleId = id, Code = "", IsLimited = false, Value = 8, Decay = 0.5M, Efficienty = 7.2M, UsePerMin = 22 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Earth Excavator ME/03", ModeleId = id, Code = "", IsLimited = false, Value = 41, Decay = 0.75M, Efficienty = 7.2M, UsePerMin = 22 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Earth Excavator ME/04", ModeleId = id, Code = "", IsLimited = false, Value = 55, Decay = 0.85M, Efficienty = 8, UsePerMin = 23 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Earth Excavator ME/05", ModeleId = id, Code = "", IsLimited = false, Value = 66, Decay = 1, Efficienty = 8.8M, UsePerMin = 23 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Earth Excavator ME/05, SGA Edition", ModeleId = id, Code = "", IsLimited = false, Value = 66, Decay = 0.8M, Efficienty = 8.8M, UsePerMin = 33 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Excavator Adjusted", ModeleId = id, Code = "", IsLimited = false, Value = 18, Decay = 0.5M, Efficienty = 12.8M, UsePerMin = 23 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Excavator Improved", ModeleId = id, Code = "", IsLimited = false, Value = 27, Decay = 0.5M, Efficienty = 15.2M, UsePerMin = 24 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Excavator Modified", ModeleId = id, Code = "", IsLimited = false, Value = 4362, Decay = 3.212M, Efficienty = 20.8M, UsePerMin = 27 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Genesis Star Rookie Extractor (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.1M, Decay = 0, Efficienty = 1.2M, UsePerMin = 17 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Imperium Extirpater v1", ModeleId = id, Code = "", IsLimited = false, Value = 2.2M, Decay = 0.34M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Initiate''s Excavator (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Island Earth Excavator ME/01", ModeleId = id, Code = "", IsLimited = false, Value = 2.4M, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Lost Soul Savior (L)", ModeleId = id, Code = "", IsLimited = true, Value = 64, Decay = 0, Efficienty = 19.2M, UsePerMin = 26 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "NI Basic Excavator (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "NI Extractor  New Settler Issue  (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.1M, Decay = 0, Efficienty = 1.2M, UsePerMin = 24 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Punk Digger (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-101", ModeleId = id, Code = "", IsLimited = false, Value = 4, Decay = 0.6M, Efficienty = 7.2M, UsePerMin = 20 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-102", ModeleId = id, Code = "", IsLimited = false, Value = 12.6M, Decay = 1.2M, Efficienty = 8, UsePerMin = 22 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-103", ModeleId = id, Code = "", IsLimited = false, Value = 50, Decay = 1.5M, Efficienty = 8.4M, UsePerMin = 23 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-104", ModeleId = id, Code = "", IsLimited = false, Value = 65, Decay = 1.73M, Efficienty = 9.6M, UsePerMin = 24 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-105", ModeleId = id, Code = "", IsLimited = false, Value = 80, Decay = 2.22M, Efficienty = 10.8M, UsePerMin = 26 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-201 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 89, Decay = 1.29M, Efficienty = 9.2M, UsePerMin = 25 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-202 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 110, Decay = 1.6M, Efficienty = 10.4M, UsePerMin = 25 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-203 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 185, Decay = 2.06M, Efficienty = 11.6M, UsePerMin = 25 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-204 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 195, Decay = 2.331M, Efficienty = 12.8M, UsePerMin = 26 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-204 Adapted (L)", ModeleId = id, Code = "", IsLimited = true, Value = 195, Decay = 2.331M, Efficienty = 12.8M, UsePerMin = 34 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-205 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 83, Decay = 2.5M, Efficienty = 14, UsePerMin = 24 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Resource Extractor RE-301 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 83, Decay = 2.503M, Efficienty = 14, UsePerMin = 24 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Rock Ripper 1 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.28M, Efficienty = 6.6M, UsePerMin = 22 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Rock Ripper 2 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 22, Decay = 1.129M, Efficienty = 7.7M, UsePerMin = 24 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Rock Ripper 3 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 44, Decay = 1.454M, Efficienty = 8.8M, UsePerMin = 24 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Rock Ripper 3 Gold Rush", ModeleId = id, Code = "", IsLimited = false, Value = 44, Decay = 0.833M, Efficienty = 8.5M, UsePerMin = 29 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Rock Ripper 4 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Rock Ripper Trainer (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.2M, Decay = 0.274M, Efficienty = 6, UsePerMin = 17 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Rock Ripper TT (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Rookie Rock Ripper", ModeleId = id, Code = "", IsLimited = false, Value = 1, Decay = 0.274M, Efficienty = 6, UsePerMin = 17 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Training Mineral Extractor (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.1M, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.ExcavatorsDto.Add(new ExcavatorDto() { Nom = "Xtreme Excavator MK-I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 5, Decay = 0, Efficienty = 7.6M, UsePerMin = 17 });
        }

        private void AddRefiners()
        {
            int id = repositories.ModelesDto.GetByNom("Refiner").Id;
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Chikara Refiner Adjusted", ModeleId = id, Code = "", IsLimited = false, Value = 24, Decay = 0.015M, UsePerMin = 22 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Chikara Refiner Modified", ModeleId = id, Code = "", IsLimited = false, Value = 41, Decay = .013M, UsePerMin = 25 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Chikara Refiner MR200", ModeleId = id, Code = "", IsLimited = false, Value = 16, Decay = 0.023M, UsePerMin = 20 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Chikara Refiner MR300", ModeleId = id, Code = "", IsLimited = false, Value = 35, Decay = 0.022M, UsePerMin = 21 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Chikara Refiner MR400", ModeleId = id, Code = "", IsLimited = false, Value = 48, Decay = 0.02M, UsePerMin = 30 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Demonic Refiner MK-I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.03M, UsePerMin = 0 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Genesis Rookie OreRefiner (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.01M, Decay = 0.11M, UsePerMin = 0 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Genesis Star Basic Refiner", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 20 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Imperium Resource Refiner 1A", ModeleId = id, Code = "", IsLimited = false, Value = 3, Decay = 0.03M, UsePerMin = 0 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Imperium Resource Refiner B1", ModeleId = id, Code = "", IsLimited = false, Value = 6, Decay = 0.022M, UsePerMin = 21 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Initiate's Refiner", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "NI Basic Refiner", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "NI Refiner New Settler Issue", ModeleId = id, Code = "", IsLimited = false, Value = 1, Decay = 0, UsePerMin = 20 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "PTech Refiner 1", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.03M, UsePerMin = 0 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "PTech Refiner TT", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Punk Blender", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Refiner MR100", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 20 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Transformer T-101", ModeleId = id, Code = "", IsLimited = false, Value = 8, Decay = 0.03M, UsePerMin = 20 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Transformer T-102", ModeleId = id, Code = "", IsLimited = false, Value = 22.75M, Decay = 0.028M, UsePerMin = 21 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Transformer T-103", ModeleId = id, Code = "", IsLimited = false, Value = 45.5M, Decay = 0.026M, UsePerMin = 22 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Transformer T-104", ModeleId = id, Code = "", IsLimited = false, Value = 55.3M, Decay = 0.023M, UsePerMin = 34 });
            repositories.RefinersDto.Add(new RefinerDto() { Nom = "Transformer T-105", ModeleId = id, Code = "", IsLimited = false, Value = 75, Decay = 0.021M, UsePerMin = 36 });

        }

        private void AddFinderAmplifiers()
        {
            int id = repositories.ModelesDto.GetByNom("Finder Amplifier").Id;
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Cheeky Finder Amp (L)", ModeleId = id, Code = "", IsLimited = true, Value = 50, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "D-Class Mining Amp (L)", ModeleId = id, Code = "", IsLimited = true, Value = 160, Decay = 400, Coefficient = 20M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "DSEC Seeker Amplifier II (L)", ModeleId = id, Code = "", IsLimited = true, Value = 125, Decay = 133, Coefficient = 6.7M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "DSEC Seeker Amplifier III (L)", ModeleId = id, Code = "", IsLimited = true, Value = 268, Decay = 285, Coefficient = 14.3M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "eMINE Amplifier I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 105, Decay = 75, Coefficient = 3.8M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "eMINE Amplifier II (L)", ModeleId = id, Code = "", IsLimited = true, Value = 105, Decay = 150, Coefficient = 7.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 1 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 78, Decay = 25, Coefficient = 1.3M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 1 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 78, Decay = 25, Coefficient = 1.3M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 1 Finder Amplifier Light (L)", ModeleId = id, Code = "", IsLimited = true, Value = 30, Decay = 25, Coefficient = 1.3M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 2 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 78, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 2 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 100, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 2 Finder Amplifier, SGA Edition", ModeleId = id, Code = "", IsLimited = false, Value = 78, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 2 Finder Amplifier Light (L)", ModeleId = id, Code = "", IsLimited = true, Value = 50, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 3 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 100, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 3 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 114, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 3 Finder Amplifier, SGA Edition", ModeleId = id, Code = "", IsLimited = false, Value = 114, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 3 Finder Amplifier Light (L)", ModeleId = id, Code = "", IsLimited = true, Value = 75, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 4 Finder Amplifier (L)", ModeleId = id, Code = "LVL4", IsLimited = true, Value = 150, Decay = 150, Coefficient = 7.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 5 Finder Amplifier", ModeleId = id, Code = "LVL5", IsLimited = false, Value = 113, Decay = 200, Coefficient = 10 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 5 Finder Amplifier (L)", ModeleId = id, Code = "LVL5", IsLimited = true, Value = 200, Decay = 200, Coefficient = 10 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 6 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 250, Decay = 250, Coefficient = 12.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 7 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 120, Decay = 300, Coefficient = 15 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 7 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 120, Decay = 300, Coefficient = 15 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 8 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 160, Decay = 400, Coefficient = 20 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 8 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 160, Decay = 400, Coefficient = 20 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 9 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 260, Decay = 500, Coefficient = 25 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 10 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 300, Decay = 750, Coefficient = 37.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 11 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 350, Decay = 1000, Coefficient = 50 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 12 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 255, Decay = 1500, Coefficient = 75 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level 13 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 340, Decay = 2000, Coefficient = 100 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level I Finder Amplifier 'Achilles' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 89, Decay = 25, Coefficient = 1.3M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level II Finder Amplifier 'Achilles' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 115, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level II Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 82, Decay = 60, Coefficient = 3 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level III Finder Amplifier 'Achilles' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 131, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level III Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 102, Decay = 80, Coefficient = 4 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level V Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 178, Decay = 220, Coefficient = 11 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level VII Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 198, Decay = 320, Coefficient = 16 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Level VIII Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 208, Decay = 380, Coefficient = 19 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 1 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 45, Decay = 80, Coefficient = 4 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 1 Gold Rush", ModeleId = id, Code = "", IsLimited = false, Value = 45, Decay = 80, Coefficient = 4 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 2 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 195, Decay = 160, Coefficient = 8 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 3 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 300, Decay = 250, Coefficient = 12.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 4 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 315, Decay = 350, Coefficient = 17.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 5 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 325, Decay = 450, Coefficient = 22.5M });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 6 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 338, Decay = 600, Coefficient = 30 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 7 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 360, Decay = 900, Coefficient = 45 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 8 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 385, Decay = 1200, Coefficient = 60 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 9 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 400, Decay = 1600, Coefficient = 80 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp 10 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 442, Decay = 2000, Coefficient = 100 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp I 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 64, Decay = 40, Coefficient = 2 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp IV 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 134, Decay = 120, Coefficient = 6 });
            repositories.FinderAmplifiersDto.Add(new FinderAmplifierDto() { Nom = "Terra Amp VI 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 188, Decay = 260, Coefficient = 13 });
        }

        private void AddEnhancers()
        {
            int id = repositories.ModelesDto.GetByNom("Finder Depth Enhancer").Id;
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Depth Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });


            id = repositories.ModelesDto.GetByNom("Finder Range Enhancer").Id;
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Range Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });


            id = repositories.ModelesDto.GetByNom("Finder Skill Enhancer").Id;
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Finder Skill Modification Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });

            id = repositories.ModelesDto.GetByNom("Excavator Speed Enhancer").Id;
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.EnhancersDto.Add(new EnhancerDto() { Nom = "Mining Excavator Speed Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
        }

        private void AddEnmatters()
        {
            // Enmatters
            int idU = repositories.ModelesDto.GetByNom("Enmatter").Id;
            int idR = repositories.ModelesDto.GetByNom("Refined Enmatter").Id;

            repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Force Nexus", ModeleId = idU, Value = 0.01M });
            repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Growth Molecules", ModeleId = idU, Value = 0.47M });
            repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Sweetstuff", ModeleId = idU, Value = 0.01M });

            repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Energized Fertilizer", ModeleId = idR, Value = 0.47M });
            repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Aurilinin Gel", ModeleId = idR, Value = 4.04M });
            repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Chilling Agent", ModeleId = idR, Value = 0M });
            repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Distilled Sweat Crystal", ModeleId = idR, Value = 1.1106M });
            repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Magtonium Dust", ModeleId = idR, Value = 0M });
            repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zincalicid Energy Crystal", ModeleId = idR, Value = 4.24M });

            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Acid Root", ModeleId = idU, Value = 0.32M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Root Acid", ModeleId = idR, Value = 0.64M }),
                Quantity = 2});
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Alicenies Liquid", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Alicenies Gel", ModeleId = idR, Value = 0.1M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Angelic Grit", ModeleId = idU, Value = 0.5M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Angelic Flakes", ModeleId = idR, Value = 1M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Angel Scales", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Light Mail", ModeleId = idR, Value = 0.02M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ares Head", ModeleId = idU, Value = 0.26M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ares Powder", ModeleId = idR, Value = 0.52M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Azur Pearls", ModeleId = idU, Value = 0.96M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Pearl Sand", ModeleId = idR, Value = 1.92M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Binary Fluid", ModeleId = idU, Value = 0.75M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Binary Energy", ModeleId = idR, Value = 1.5M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Blood Moss", ModeleId = idU, Value = 0.09M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Medical Compress", ModeleId = idR, Value = 0.18M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cave Sap", ModeleId = idU, Value = 0.39M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Putty", ModeleId = idR, Value = 0.78M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Crude Oil", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Oil", ModeleId = idR, Value = 0.02M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Devil's Tail", ModeleId = idU, Value = 0.47M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Chalmon", ModeleId = idR, Value = 0.94M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Dianthus Liquid", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Dianthus Crystal Powder", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Dunkel Particle", ModeleId = idU, Value = 0.55M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Dunkel Plastix", ModeleId = idR, Value = 1.1M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Energized Crystal", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Energized Crystal Cell", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ferrum Nuts", ModeleId = idU, Value = 1 }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Antimagnetic Oil", ModeleId = idR, Value = 2M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Fire Root Globule", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Fire Root Pellet", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Garcen Grease", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Garcen Lubricant", ModeleId = idR, Value = 0.2M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Henren Stems", ModeleId = idU, Value = 0.63M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Henren Cube", ModeleId = idR, Value = 1.26M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lumis Leach", ModeleId = idU, Value = 0.42M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Light Liquid", ModeleId = idR, Value = 0.84M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Magerian Mist", ModeleId = idU, Value = 0.25M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Magerian Spray", ModeleId = idR, Value = 0.5M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Melchi Water", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Melchi Crystal", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lytairian Dust", ModeleId = idU, Value = 0.19M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lytairian Powder", ModeleId = idR, Value = 0.38M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Solis Beans", ModeleId = idU, Value = 0.78M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Solis Paste", ModeleId = idR, Value = 1.56M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Vegatation Spores", ModeleId = idU, Value = 0.4M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Inhaler", ModeleId = idR, Value = 0.8M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Typonolic Steam", ModeleId = idU, Value = 0.15M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Typonolic Gas", ModeleId = idR, Value = 0.3M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Black Russian Cocktail Mix", ModeleId = idU, Value = 0.03M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Black Russian Cocktail", ModeleId = idR, Value = 0.06M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Blue Crystal", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hardening Agent", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Bodai Dust", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Bodai Filler", ModeleId = idR, Value = 0.4M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Clear Crystal", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lightening Agent", ModeleId = idR, Value = 0.2M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Edres Resin", ModeleId = idU, Value = 0.13M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Edres Varnish", ModeleId = idR, Value = 0.26M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Florican Mist", ModeleId = idU, Value = 0.27M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Florican Spray", ModeleId = idR, Value = 0.54M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ghali", ModeleId = idU, Value = 0.16M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ghali Powder", ModeleId = idR, Value = 0.32M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Gorbek Emulsion", ModeleId = idU, Value = 0.4M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Gorbek Tallow", ModeleId = idR, Value = 0.8M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Green Crystal", ModeleId = idU, Value = 0.03M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Life Essence", ModeleId = idR, Value = 0.06M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Harvey Wallbanger Cocktail Mix", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Harvey Wallbanger Cocktail", ModeleId = idR, Value = 0.08M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hazy Crystal", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Reflecting Agent", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hurricane Cocktail Mix", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hurricane Cocktail", ModeleId = idR, Value = 0.02M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hydrogen Steam", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hydrogen Gas", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kamikaze Cocktail Mix", ModeleId = idU, Value = 0.085M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kamikaze Cocktail", ModeleId = idR, Value = 0.17M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Long Island Ice Tea Cocktail Mix", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Long Island Ice Tea Cocktail", ModeleId = idR, Value = 0.1M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lotium Fluid", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lotium Gel", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Mai Tai Cocktail Mix", ModeleId = idU, Value = 0.015M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Mai Tai Cocktail", ModeleId = idR, Value = 0.03M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Mamnoon", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Mamnoon Mist", ModeleId = idR, Value = 0.16M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Mojito Cocktail Mix", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Mojito Cocktail", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Nawa Drops", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Nawa Vial", ModeleId = idR, Value = 0.02M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Nirvana Cocktail Mix", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Nirvana Cocktail", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Orange Crystal", ModeleId = idU, Value = 0.07M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Softening Agent", ModeleId = idR, Value = 0.14M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Pel Crystals", ModeleId = idU, Value = 0.5M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Pel Liquid", ModeleId = idR, Value = 1M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Pina Colada Cocktail Mix", ModeleId = idU, Value = 0.025M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Pina Colada Cocktail", ModeleId = idR, Value = 0.05M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Purple Crystal", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Darkening Agent", ModeleId = idR, Value = 0.16M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Qaz Worm", ModeleId = idU, Value = 0.06M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hareer Thread", ModeleId = idR, Value = 0.24M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Quil Sap", ModeleId = idU, Value = 0.25M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Quil Rubber", ModeleId = idR, Value = 0.5M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Rainbow Crystal", ModeleId = idU, Value = 0.15M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Color Enhancing Agent", ModeleId = idR, Value = 0.3M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Red Molten Crystal", ModeleId = idU, Value = 0.5M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Heating Agent", ModeleId = idR, Value = 0M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Sham", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Sham Sand", ModeleId = idR, Value = 0.01M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Somin Tar", ModeleId = idU, Value = 0.06M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Somin Glue", ModeleId = idR, Value = 0.12M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Star Particles", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Star Dust", ModeleId = idR, Value = 0.16M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Vorn Pellets", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Vorn Plastic", ModeleId = idR, Value = 0.4M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Whiskey Sour Cocktail Mix", ModeleId = idU, Value = 0.075M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Whiskey Sour Cocktail", ModeleId = idR, Value = 0.15M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Xelo Haze", ModeleId = idU, Value = 0.39M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Xelo Vapour", ModeleId = idR, Value = 0.78M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Yashib Stone", ModeleId = idU, Value = 0.13M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Yashib Ingot", ModeleId = idR, Value = 0.26M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Yellow Crystal", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Super Adhesive", ModeleId = idR, Value = 0.02M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Youd", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Youd Bottle", ModeleId = idR, Value = 0.08M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zoldenite Dust", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zoldenite Crystal", ModeleId = idR, Value = 0.08M }),
                Quantity = 2
            });
            repositories.RefinablesDto.Add(new RefinableDto()
            {
                UnrefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zolphic Oil", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zolphic Grease", ModeleId = idR, Value = 0.08M }),
                Quantity = 2
            });
        }

        private void AddOres()
        {
            int idU = repositories.ModelesDto.GetByNom("Ore").Id;
            int idR = repositories.ModelesDto.GetByNom("Refined Ore").Id;
            //repositories.RefinablesDto.Add(new RefinableDto()
            //{
            //    UnrefinedMaterial = ,
            //        RefinedMaterial = ,
            //        Quantity = 2
            //    });
            //    // Ores
            //    int id = repositories.ModelesDto.GetByNom("Enmatter").Id;
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Adomasite Stone", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Alferix Stone", ModeleId = id, Value = 0.95M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Alternative Rock", ModeleId = id, Value = 0.01M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Aqeeq Stone", ModeleId = id, Value = 0.02M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arekite Stone", ModeleId = id, Value = 0.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Azzurdite Stone", ModeleId = id, Value = 1.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Banite Stones", ModeleId = id, Value = 0.08M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Blausariam Stone", ModeleId = id, Value = 0.04M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Blues Rock", ModeleId = id, Value = 0.02M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Caldorite stone", ModeleId = id, Value = 0.17M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cobalt Stone", ModeleId = id, Value = 0.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Copper Stone", ModeleId = id, Value = 0.16M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cordul Stone", ModeleId = id, Value = 0.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cumbriz Stone", ModeleId = id, Value = 0.15M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cyrenium Ore", ModeleId = id, Value = 0.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Dark Lysterium", ModeleId = id, Value = 0.02M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Dianum Ore", ModeleId = id, Value = 1.25M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Durulium Stone", ModeleId = id, Value = 0.8M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Erdorium Stone", ModeleId = id, Value = 0.4M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Erionite Stone", ModeleId = id, Value = 0.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Fairuz Stone", ModeleId = id, Value = 0.05M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Folk Rock", ModeleId = id, Value = 0.03M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Frakite Stone", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Frigulite Stone", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ganganite Stone", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Gazzurdite Stone", ModeleId = id, Value = 0.25M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Glam Rock", ModeleId = id, Value = 0.04M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Gold Stone", ModeleId = id, Value = 1 });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Grunge Rock", ModeleId = id, Value = 0.04M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hansidian Rock", ModeleId = id, Value = 0.01M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hard Rock", ModeleId = id, Value = 0.05M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hebredite Stones", ModeleId = id, Value = 0.25M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Himi Rock", ModeleId = id, Value = 0.142M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ignisium Stone", ModeleId = id, Value = 0.7M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Iolite Stone", ModeleId = id, Value = 0.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Iridium Ore", ModeleId = id, Value = 0.05M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Iron Stone", ModeleId = id, Value = 0.13M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Jazz Rock", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kaisenite Stone", ModeleId = id, Value = 0.02M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kanerium Ore", ModeleId = id, Value = 2.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kaz Stones", ModeleId = id, Value = 0.04M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kirtz Stone", ModeleId = id, Value = 5.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Langotz Ore", ModeleId = id, Value = 0.9M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lanorium Stone", ModeleId = id, Value = 0.22M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lidacon Stones", ModeleId = id, Value = 1.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lulu Stone", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lysterium Stone", ModeleId = id, Value = 0.01M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Maganite Ore", ModeleId = id, Value = 1.05M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Maladrite Stone", ModeleId = id, Value = 0.04M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Maro Stone", ModeleId = id, Value = 0.13M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Megan Stone", ModeleId = id, Value = 0.18M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Melatinum Stone", ModeleId = id, Value = 0.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Morpheus Stone", ModeleId = id, Value = 0.83M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Motorhead Keg", ModeleId = id, Value = 0.01M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Narcanisum Stone", ModeleId = id, Value = 0.08M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Niksarium Stone", ModeleId = id, Value = 0.65M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Nosifer Stone", ModeleId = id, Value = 0.08M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Olerin Stone", ModeleId = id, Value = 0.07M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ospra Stones", ModeleId = id, Value = 0.02M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Petonium Stone", ModeleId = id, Value = 1.79M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Platinum Stone", ModeleId = id, Value = 3 });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Praetonium", ModeleId = id, Value = 0.02M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Punk Rock", ModeleId = id, Value = 0.07M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Pyrite Stone", ModeleId = id, Value = 0.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Qasdeer Stone", ModeleId = id, Value = 0.25M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Quantium Stone", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Redulite Ore", ModeleId = id, Value = 2.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Reggea Rock", ModeleId = id, Value = 0.08M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Rugaritz Ore", ModeleId = id, Value = 1.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Sothorite Ore", ModeleId = id, Value = 0.09M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Sunburst Stone", ModeleId = id, Value = 0.11M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Tananite Ore", ModeleId = id, Value = 0.15M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Techno Rock", ModeleId = id, Value = 0.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Telfium Stones", ModeleId = id, Value = 0.14M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Terrudite Stone", ModeleId = id, Value = 1.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Tridenite Ore", ModeleId = id, Value = 2 });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Valurite Stone", ModeleId = id, Value = 6 });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Veda Stones", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Vesperdite Ore", ModeleId = id, Value = 1.8M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Wenrex Stones", ModeleId = id, Value = 0.17M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Wiles Stone", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Xeremite Ore", ModeleId = id, Value = 4 });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Yulerium Stones", ModeleId = id, Value = 0.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zanderium Ore", ModeleId = id, Value = 2.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zinc Stone", ModeleId = id, Value = 0.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zircon Stone", ModeleId = id, Value = 0.05M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zorn Star Ore", ModeleId = id, Value = 0.01M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zulax Stones", ModeleId = id, Value = 0.65M });



            //    Refined Ores
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Adomasite Ingot", ModeleId = id, Value = 1.8M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Alferix Ingot", ModeleId = id, Value = 2.85M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Alternative Ingot", ModeleId = id, Value = 0.03M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Aqeeq Ingot", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arekite Ingot", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Aumorphite Ingot", ModeleId = id, Value = 8.09M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Azzurdite Ingot", ModeleId = id, Value = 3.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Banite Ingot", ModeleId = id, Value = 0.24M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Belkar Ingot", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Blausariam Ingot", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Blues Ingot", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Caldorite Ingot", ModeleId = id, Value = 0.51M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Chalinum Alloy", ModeleId = id, Value = 2.601M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cobalt Ingot", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cobaltium Ingot", ModeleId = id, Value = 2.001M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Copper Ingot", ModeleId = id, Value = 0.48M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cordul Ingot", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cumbriz Ingot", ModeleId = id, Value = 0.45M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Cyrenium Ingot", ModeleId = id, Value = 1.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Dark Lysterium Bar", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Dianum Ingot", ModeleId = id, Value = 3.75M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Durulium Ingot", ModeleId = id, Value = 2.4M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Erdorium Ingot", ModeleId = id, Value = 1.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Erionite Ingot", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Fairuz Ingot", ModeleId = id, Value = 0.15M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Folk Ingot", ModeleId = id, Value = 0.09M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Frakite Ingot", ModeleId = id, Value = 0.9M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Frigulerian Dust", ModeleId = id, Value = 3.4405M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Frigulite Ingot", ModeleId = id, Value = 0.36M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Galaurphite Ingot", ModeleId = id, Value = 14.7353M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Galvesperdite Ingot", ModeleId = id, Value = 6.3625M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ganganite Ingot", ModeleId = id, Value = 0.36M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Gazzurdite Ingot", ModeleId = id, Value = 0.75M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Glam Ingot", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Gold Ingot", ModeleId = id, Value = 3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Grunge Ingot", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hansidian Ingot", ModeleId = id, Value = 0.03M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hard Ingot", ModeleId = id, Value = 0.15M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hebredite Ingot", ModeleId = id, Value = 0.75M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Himi Ingot", ModeleId = id, Value = 0.426M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ignisium Ingot", ModeleId = id, Value = 2.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Iolite Ingot", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Iridium Ingot", ModeleId = id, Value = 0.15M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Iron Ingot", ModeleId = id, Value = 0.39M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Jazz Ingot", ModeleId = id, Value = 0.18M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kaisenite Ingot", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kanerium Ingot", ModeleId = id, Value = 7.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kaz Ingot", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Kirtz Ingot", ModeleId = id, Value = 16.8M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Langotz Ingot", ModeleId = id, Value = 2.7M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lanorium Ingot", ModeleId = id, Value = 0.66M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Leethiz Ingot", ModeleId = id, Value = 0.45M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lidacon Ingot", ModeleId = id, Value = 4.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lulu pearl", ModeleId = id, Value = 0.36M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lysterium Ingot", ModeleId = id, Value = 0.03M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Lystionite Steel Ingot", ModeleId = id, Value = 4.0146M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Maganite Ingot", ModeleId = id, Value = 3.15M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Maladrite Ingot", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Maro Ingot", ModeleId = id, Value = 0.52M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Megan Ingot", ModeleId = id, Value = 0.54M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Melatinum Ingot", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Morpheus Ingot", ModeleId = id, Value = 2.49M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Narcanisum Ingot", ModeleId = id, Value = 0.24M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Niksarium Ingot", ModeleId = id, Value = 1.95M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Nosi Ingot", ModeleId = id, Value = 0.24M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Olerin Ingot", ModeleId = id, Value = 0.21M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ospra Ingot", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Petonium Ingot", ModeleId = id, Value = 5.37M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Platinum Ingot", ModeleId = id, Value = 9M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Praetonium Ingot", ModeleId = id, Value = 0.04M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Punk Ingot", ModeleId = id, Value = 0.21M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Pyrite Ingot", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Qasdeer Ingot", ModeleId = id, Value = 0.75M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Quantium Ingot", ModeleId = id, Value = 1.8M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Redulite Ingot", ModeleId = id, Value = 6.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Reggea Ingot", ModeleId = id, Value = 0.24M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Rugaritz Ingot", ModeleId = id, Value = 4.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Solares Ingot", ModeleId = id, Value = 3.59M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Sothorite Ingot", ModeleId = id, Value = 0.27M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Sunburst Ingot", ModeleId = id, Value = 0.77M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Techno Ingot", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Telfium Ingot", ModeleId = id, Value = 0.42M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Terrudite Ingot", ModeleId = id, Value = 3.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Tridenite Ingot", ModeleId = id, Value = 6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Valurite Ingot", ModeleId = id, Value = 18M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Veda Ingot", ModeleId = id, Value = 0.18M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Vesperdite Ingot", ModeleId = id, Value = 5.4M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Wenrex Ingot", ModeleId = id, Value = 0.51M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Wiley Ingot", ModeleId = id, Value = 0.9M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Xeremite Ingot", ModeleId = id, Value = 12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Yashib Ingot", ModeleId = id, Value = 0.65M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Ycy Ingot", ModeleId = id, Value = 1.05M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Yulerium Ingot", ModeleId = id, Value = 1.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zanderium Ingot", ModeleId = id, Value = 7.5M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zinc Ingot", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zircon Ingot", ModeleId = id, Value = 0.15M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zorn Star Ingot", ModeleId = id, Value = 0.03M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Zulax Ingot", ModeleId = id, Value = 1.95M });
            }

        private void AddTreasures()
        {
            int idU = repositories.ModelesDto.GetByNom("Treasure").Id;
            int idR = repositories.ModelesDto.GetByNom("Refined Treasure").Id;
            //repositories.RefinablesDto.Add(new RefinableDto()
            //{
            //    UnrefinedMaterial = ,
            //        RefinedMaterial = ,
            //        Quantity = 2
            //    });
            //    // Treasure
            //    id = repositories.ModelesDto.GetByNom("Treasure").Id;
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Aakas Alloy", ModeleId = id, Value = 0.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Aarkan Pellets", ModeleId = id, Value = 0.02M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Alkar Crystals", ModeleId = id, Value = 0.05M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Barrel", ModeleId = id, Value = 18M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Bearings", ModeleId = id, Value = 2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Codex Chamber", ModeleId = id, Value = 40M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Cog", ModeleId = id, Value = 10M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Gears", ModeleId = id, Value = 1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Housing", ModeleId = id, Value = 30M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Inner Ring", ModeleId = id, Value = 20M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Interface", ModeleId = id, Value = 12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Outer Ring", ModeleId = id, Value = 30M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Arkadian Golden Key Power Source", ModeleId = id, Value = 6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Bismuth Fragment", ModeleId = id, Value = 0.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "ChemSet", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Diagen Firedrops", ModeleId = id, Value = 0.04M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hexra Gems", ModeleId = id, Value = 0.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Khorudoul Extrusion", ModeleId = id, Value = 0.08M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Khorum Alloy", ModeleId = id, Value = 0.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Part Of Brass Alloy", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Part Of Bronze Alloy", ModeleId = id, Value = 0.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Part Of Flint Arrow Head", ModeleId = id, Value = 0.08M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Part Of Flint Axe Head", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Part Of Fly Amber", ModeleId = id, Value = 0.1M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Part Of Fossil Ammonite", ModeleId = id, Value = 0.02M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Part Of Fossil Tooth", ModeleId = id, Value = 0.01M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Part Of Mosquito Amber", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Pirrel Pellets", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Quenta Flux", ModeleId = id, Value = 0.15M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Regula Lode", ModeleId = id, Value = 0.2M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Songkra Alloy", ModeleId = id, Value = 0.25M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Songtil Agent", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Starrix Nodes", ModeleId = id, Value = 0.25M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Vedacore Fibre", ModeleId = id, Value = 0.15M });


            //    // Refined Treasure
            //    id = repositories.ModelesDto.GetByNom("Refined Treasure").Id;
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Aakas Plating", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Aarkan Polymer", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Alkar Lattice", ModeleId = id, Value = 0.15M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Balancing Agent", ModeleId = id, Value = 0.18M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Binding Epoxy", ModeleId = id, Value = 0.9M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Bismuth Plating", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Brass Alloy", ModeleId = id, Value = 0.36M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Bronze Alloy", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Diagen Matrix", ModeleId = id, Value = 0.12M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Flint Arrow Head", ModeleId = id, Value = 0.24M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Flint Axe Head", ModeleId = id, Value = 0.18M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Fly Amber", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Fossil Ammonite", ModeleId = id, Value = 0.06M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Fossil Tooth", ModeleId = id, Value = 0.03M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Hexra Electroplate", ModeleId = id, Value = 0.3M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Khorudoul Polymer", ModeleId = id, Value = 0.24M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Khorum Plating", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Mosquito Amber", ModeleId = id, Value = 0.9M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Pirrel Hexaton", ModeleId = id, Value = 0.9M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Quenta Panel", ModeleId = id, Value = 0.45M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Regula Powder", ModeleId = id, Value = 0.6M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Songkra Plating", ModeleId = id, Value = 0.75M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Starrix Quilting", ModeleId = id, Value = 0.75M });
            //    repositories.MaterialsDto.Add(new MaterialDto() { Nom = "Vedacore Sheeting", ModeleId = id, Value = 0.45M });
        }
        private void AddPlanetMaterial()
        {
            throw new NotImplementedException();
        }

        private void AddSearchModes()
        {
            repositories.SearchModesDto.Add(new SearchModeDto() { Nom = "Ores", Abbrev = "O", Multiplicateur = 2 });
            repositories.SearchModesDto.Add(new SearchModeDto() { Nom = "Enmatters", Abbrev = "E", Multiplicateur = 1 });
            repositories.SearchModesDto.Add(new SearchModeDto() { Nom = "Treasures", Abbrev = "T", Multiplicateur = 3 });
            repositories.SearchModesDto.Add(new SearchModeDto() { Nom = "Ores, Enmatters", Abbrev = "OE", Multiplicateur = 3 });
            repositories.SearchModesDto.Add(new SearchModeDto() { Nom = "Ores, Treasures", Abbrev = "OT", Multiplicateur = 2.5M });
            repositories.SearchModesDto.Add(new SearchModeDto() { Nom = "Enmatters, Treasures", Abbrev = "ET", Multiplicateur = 2 });
            repositories.SearchModesDto.Add(new SearchModeDto() { Nom = "Ores, Enmatters, Treasures", Abbrev = "OET", Multiplicateur = 3 });

        }
    }
}

