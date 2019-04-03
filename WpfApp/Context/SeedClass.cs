﻿using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;
using System.Data.Entity;
using WpfApp.Model;
using System;

namespace WpfApp.Context
{
    public class SeedClass : DropCreateDatabaseAlways<MiningContext>
    {
        private IRepositoriesUoW repositories;

        protected override void Seed(MiningContext ctx)
        {
            repositories = new RepositoriesUoW(ctx);

            SeedLauch();

            base.Seed(ctx);
        }

        private void SeedLauch()
        {
            AddCategories(repositories);
            AddModeles(repositories);
            AddToolAccessoire(repositories);
            AddPlanets(repositories);
            AddFinders(repositories);
            AddExcavators(repositories);
            AddRefiners(repositories);
            AddFinderAmplifiers(repositories);
            AddEnhancers(repositories);
            //AddMaterials(repositories);
            //AddPlanetMaterial(repositories);

            AddSearchModes(repositories);
        }

        private void AddCategories(IRepositoriesUoW repositories)
        {
            repositories.Categories.Add(new CategorieModel() { Nom = "Tool" });
            repositories.Categories.Add(new CategorieModel() { Nom = "Accessoire" });
            repositories.Categories.Add(new CategorieModel() { Nom = "Material" });
        }

        private void AddModeles(IRepositoriesUoW repositories)
        {
            int id = repositories.Categories.GetByNom("Tool").Id;
            repositories.Modeles.Add(new ModeleModel() { Nom = "Finder", IsStackable = false, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Excavator", IsStackable = false, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Refiner", IsStackable = false, CategorieId = id });

            id = repositories.Categories.GetByNom("Accessoire").Id;
            repositories.Modeles.Add(new ModeleModel() { Nom = "Finder Amplifier", IsStackable = false, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Finder Depth Enhancer", IsStackable = true, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Finder Range Enhancer", IsStackable = true, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Finder Skill Enhancer", IsStackable = true, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Excavator Speed Enhancer", IsStackable = true, CategorieId = id });

            id = repositories.Categories.GetByNom("Material").Id;
            repositories.Modeles.Add(new ModeleModel() { Nom = "Ore", IsStackable = true, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Enmatter", IsStackable = true, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Treasure", IsStackable = true, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Refined Ore", IsStackable = true, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Refined Enmatter", IsStackable = true, CategorieId = id });
            repositories.Modeles.Add(new ModeleModel() { Nom = "Refined Treasure", IsStackable = true, CategorieId = id });
        }

        private void AddToolAccessoire(IRepositoriesUoW repositories)
        {
            int tId = repositories.Modeles.GetByNom("Finder").Id;
            repositories.ToolAccessoires.Add(new ToolAccessoireModel() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Amplifier").Id });
            repositories.ToolAccessoires.Add(new ToolAccessoireModel() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Depth Enhancer").Id });
            repositories.ToolAccessoires.Add(new ToolAccessoireModel() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Range Enhancer").Id });
            repositories.ToolAccessoires.Add(new ToolAccessoireModel() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Skill Enhancer").Id });

            tId = repositories.Modeles.GetByNom("Excavator").Id;
            repositories.ToolAccessoires.Add(new ToolAccessoireModel() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Excavator Speed Enhancer").Id });
        }

        private void AddPlanets(IRepositoriesUoW repositories)
        {
            repositories.Planets.Add(new PlanetModel() { Nom = "Calypso" });
            repositories.Planets.Add(new PlanetModel() { Nom = "Arkadia" });
            repositories.Planets.Add(new PlanetModel() { Nom = "F.O.M.A." });
            repositories.Planets.Add(new PlanetModel() { Nom = "Toulan" });
            repositories.Planets.Add(new PlanetModel() { Nom = "Rocktropia" });
        }

        private void AddFinders(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Finder").Id;
            repositories.Finders.Add(new FinderModel() { Nom = "A.R.C. Finder 0001 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.25M, Range = 54, Depth = 204, UsePerMin = 9, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "CDF Finder z10 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 1, Decay = 0, Range = 54, Depth = 223.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "CDF Finder z25 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 2, Decay = 0.56M, Range = 54.2M, Depth = 422.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "CDF Finder z40 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 4, Decay = 0, Range = 54.6M, Depth = 741.3M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Demonic Detector MK-I (L)", Code = "", IsLimited = true, ModeleId = id, Value = 4.75M, Decay = 0.5M, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "DSEC Seeker L2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 18.6M, Decay = 0, Range = 55, Depth = 213.9M, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "DSEC Seeker L12 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 49, Decay = 2.29M, Range = 55, Depth = 462.7M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "DSEC Seeker L30 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 136, Decay = 3.96M, Range = 55, Depth = 820.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "eMINE FS (L)", Code = "", IsLimited = true, ModeleId = id, Value = 122, Decay = 1.743M, Range = 54, Depth = 676.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-101", Code = "F101", IsLimited = false, ModeleId = id, Value = 5.5M, Decay = 1, Range = 54, Depth = 263.7M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-102", Code = "F102", IsLimited = false, ModeleId = id, Value = 30, Decay = 1.15M, Range = 54, Depth = 323.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-103", Code = "F103", IsLimited = false, ModeleId = id, Value = 55, Decay = 1.45M, Range = 54.5M, Depth = 363.2M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-104", Code = "F104", IsLimited = false, ModeleId = id, Value = 66.6M, Decay = 1.63M, Range = 54.5M, Depth = 432.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-105", Code = "F105", IsLimited = false, ModeleId = id, Value = 82, Decay = 2.05M, Range = 55, Depth = 522.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-105 TEN Edition", Code = "", IsLimited = false, ModeleId = id, Value = 82, Decay = 2, Range = 55, Depth = 552.3M, UsePerMin = 9, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-106", Code = "", IsLimited = false, ModeleId = id, Value = 79.95M, Decay = 1.799M, Range = 55, Depth = 582.1M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-210 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 105, Decay = 1.25M, Range = 54, Depth = 383.1M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-211 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 121.2M, Decay = 1.306M, Range = 55, Depth = 472.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-212 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 155.2M, Decay = 1.343M, Range = 55, Depth = 592, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-212, SGA Edition (L)", Code = "", IsLimited = true, ModeleId = id, Value = 155.2M, Decay = 0, Range = 55, Depth = 612, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-213 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 201.2M, Decay = 1.66M, Range = 54.5M, Depth = 631.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-213 (L) Adapted", Code = "", IsLimited = true, ModeleId = id, Value = 678, Decay = 2.33M, Range = 54, Depth = 811, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-213 (L) Customized", Code = "", IsLimited = true, ModeleId = id, Value = 2678, Decay = 2.68M, Range = 55, Depth = 850.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Finder F-214 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 231.2M, Decay = 0, Range = 54, Depth = 651.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Genesis Rookie Finder (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.06M, Decay = 0.239M, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Genesis Star Rookie Finder (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Imperium Detectonator X2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 170M, Decay = 7, Range = 54, Depth = 626.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Imperium Trainee Finder (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.52M, Range = 54, Depth = 204, UsePerMin = 9, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Island Ziplex Z1 Seeker", Code = "", IsLimited = false, ModeleId = id, Value = 2.4M, Decay = 0.751M, Range = 55, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Lost Soul Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 48, Decay = 3.7M, Range = 54.8M, Depth = 721, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "NI Finder New Settler Issue (L)", Code = "", IsLimited = true, ModeleId = id, Value = 1, Decay = 0, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Omegaton Detectonator MD-1 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.239M, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Sabad Finder M1 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 2, Decay = 0.751M, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Sabad Finder M2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 26, Decay = 0, Range = 55, Depth = 303.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Sabad Finder M3 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Sabad Finder M4 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 78, Decay = 0, Range = 55, Depth = 477.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Sabad Finder M5 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 1 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 2.5M, Decay = 1.5M, Range = 55, Depth = 206, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 2.2M, Range = 55, Depth = 408, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 3 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 95, Decay = 3.225M, Range = 55, Depth = 631.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 3 Gold Rush", Code = "", IsLimited = false, ModeleId = id, Value = 95, Decay = 3.225M, Range = 55, Depth = 631.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 4 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 150, Decay = 3.72M, Range = 55, Depth = 741.3M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 5 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 205, Decay = 4.125M, Range = 55, Depth = 830.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 6 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 260, Decay = 4.372M, Range = 55, Depth = 885.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 7 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 320, Decay = 4.552M, Range = 55, Depth = 925.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 8 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 390, Decay = 4.89M, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster 8 Gold Rush", Code = "", IsLimited = false, ModeleId = id, Value = 390, Decay = 0, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster Trainer (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.4M, Decay = 0.75M, Range = 55, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "TerraMaster TT (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.239M, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A10 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 50, Decay = 1.5M, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A13 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 51, Decay = 0, Range = 54, Depth = 223.9M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A16 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 52, Decay = 0, Range = 54, Depth = 253.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A19 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 53, Decay = 1.8M, Range = 55, Depth = 303.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A22 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 54, Decay = 1.9M, Range = 55, Depth = 403, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A25 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 2, Range = 55.1M, Depth = 502.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A28 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 56, Decay = 0, Range = 55.2M, Depth = 602, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A31 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 57, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A33 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 58, Decay = 0, Range = 55.2M, Depth = 801, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex A35 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 59, Decay = 0, Range = 55.2M, Depth = 900.5M, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex B35 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 50, Decay = 3, Range = 55, Depth = 502.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex B40 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 51, Decay = 0, Range = 55.1M, Depth = 522.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex B50 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 52, Decay = 3.2M, Range = 55.2M, Depth = 542.3M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex B60 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 53, Decay = 0, Range = 55.2M, Depth = 562.2M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex B70 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 54, Decay = 3, Range = 55.2M, Depth = 582.1M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex C50 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 40, Decay = 0, Range = 55.2M, Depth = 283.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex C65 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 44, Decay = 1.2M, Range = 55.2M, Depth = 313.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex C70 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 46, Decay = 1.2M, Range = 55.2M, Depth = 363.2M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex D33 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 44, Decay = 3.6M, Range = 54, Depth = 801, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex D44 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 46, Decay = 3.2M, Range = 54, Depth = 900.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex D52 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 3, Range = 54.5M, Depth = 990, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex P20 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex P30 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0.16M, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex P50 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex P85 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex P160 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0.7M, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex TK120 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 218.6M, Decay = 1.803M, Range = 55, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex TK220 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 264.8M, Decay = 3.96M, Range = 55, Depth = 776.1M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex TK320 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 311, Decay = 4.303M, Range = 55, Depth = 850.8M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex TK320 Seeker, SGA Edition (L)", Code = "", IsLimited = true, ModeleId = id, Value = 233.25M, Decay = 0, Range = 55, Depth = 870.7M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex VRX2000 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 339, Decay = 4.651M, Range = 55, Depth = 925.4M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex VRX3000 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 387, Decay = 5.01M, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex Z1 Seeker", Code = "", IsLimited = false, ModeleId = id, Value = 2.4M, Decay = 1.501M, Range = 55, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex Z5 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 29.8M, Decay = 1.855M, Range = 55, Depth = 303.5M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex Z10 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 2.209M, Range = 55, Depth = 403, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex Z10 Seeker, SGA Edition (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex Z15 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 80, Decay = 2.557M, Range = 55, Depth = 477.6M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex Z20 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 126.2M, Decay = 1.452M, Range = 55, Depth = 552.3M, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new FinderModel() { Nom = "Ziplex Z25 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 172.4M, Decay = 3.251M, Range = 55, Depth = 626.9M, UsePerMin = 8, BasePecSearch = 50 });
        }

        private void AddExcavators(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Excavator").Id;
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "ARD Excavator A-100 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "ARD Excavator Beginner (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.5M, Decay = 0, Efficienty = 1.2M, UsePerMin = 17 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "ARD Excavator M1 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 2.4M, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "ARD Excavator M2 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 54, Decay = 0, Efficienty = 9.2M, UsePerMin = 24 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "ARD Excavator M3 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "ARD Excavator M4 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "ARD Excavator M5 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 132, Decay = 2.336M, Efficienty = 12.8M, UsePerMin = 26 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Demonic Excavator MK-I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 5, Decay = 0.1M, Efficienty = 0.6M, UsePerMin = 17 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Earth Excavator ME/01", ModeleId = id, Code = "", IsLimited = false, Value = 2.4M, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "eMINE E (L)", ModeleId = id, Code = "", IsLimited = true, Value = 85, Decay = 2.101M, Efficienty = 12, UsePerMin = 27 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Rookie Extractor (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.01M, Decay = 0, Efficienty = 1.2M, UsePerMin = 17 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Basic Excavator (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Earth Excavator ME/02", ModeleId = id, Code = "", IsLimited = false, Value = 8, Decay = 0.5M, Efficienty = 7.2M, UsePerMin = 22 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Earth Excavator ME/03", ModeleId = id, Code = "", IsLimited = false, Value = 41, Decay = 0.75M, Efficienty = 7.2M, UsePerMin = 22 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Earth Excavator ME/04", ModeleId = id, Code = "", IsLimited = false, Value = 55, Decay = 0.85M, Efficienty = 8, UsePerMin = 23 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Earth Excavator ME/05", ModeleId = id, Code = "", IsLimited = false, Value = 66, Decay = 1, Efficienty = 8.8M, UsePerMin = 23 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Earth Excavator ME/05, SGA Edition", ModeleId = id, Code = "", IsLimited = false, Value = 66, Decay = 0.8M, Efficienty = 8.8M, UsePerMin = 33 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Excavator Adjusted", ModeleId = id, Code = "", IsLimited = false, Value = 18, Decay = 0.5M, Efficienty = 12.8M, UsePerMin = 23 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Excavator Improved", ModeleId = id, Code = "", IsLimited = false, Value = 27, Decay = 0.5M, Efficienty = 15.2M, UsePerMin = 24 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Excavator Modified", ModeleId = id, Code = "", IsLimited = false, Value = 4362, Decay = 3.212M, Efficienty = 20.8M, UsePerMin = 27 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Genesis Star Rookie Extractor (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.1M, Decay = 0, Efficienty = 1.2M, UsePerMin = 17 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Imperium Extirpater v1", ModeleId = id, Code = "", IsLimited = false, Value = 2.2M, Decay = 0.34M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Initiate''s Excavator (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Island Earth Excavator ME/01", ModeleId = id, Code = "", IsLimited = false, Value = 2.4M, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Lost Soul Savior (L)", ModeleId = id, Code = "", IsLimited = true, Value = 64, Decay = 0, Efficienty = 19.2M, UsePerMin = 26 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "NI Basic Excavator (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "NI Extractor  New Settler Issue  (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.1M, Decay = 0, Efficienty = 1.2M, UsePerMin = 24 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Punk Digger (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-101", ModeleId = id, Code = "", IsLimited = false, Value = 4, Decay = 0.6M, Efficienty = 7.2M, UsePerMin = 20 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-102", ModeleId = id, Code = "", IsLimited = false, Value = 12.6M, Decay = 1.2M, Efficienty = 8, UsePerMin = 22 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-103", ModeleId = id, Code = "", IsLimited = false, Value = 50, Decay = 1.5M, Efficienty = 8.4M, UsePerMin = 23 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-104", ModeleId = id, Code = "", IsLimited = false, Value = 65, Decay = 1.73M, Efficienty = 9.6M, UsePerMin = 24 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-105", ModeleId = id, Code = "", IsLimited = false, Value = 80, Decay = 2.22M, Efficienty = 10.8M, UsePerMin = 26 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-201 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 89, Decay = 1.29M, Efficienty = 9.2M, UsePerMin = 25 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-202 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 110, Decay = 1.6M, Efficienty = 10.4M, UsePerMin = 25 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-203 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 185, Decay = 2.06M, Efficienty = 11.6M, UsePerMin = 25 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-204 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 195, Decay = 2.331M, Efficienty = 12.8M, UsePerMin = 26 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-204 Adapted (L)", ModeleId = id, Code = "", IsLimited = true, Value = 195, Decay = 2.331M, Efficienty = 12.8M, UsePerMin = 34 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-205 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 83, Decay = 2.5M, Efficienty = 14, UsePerMin = 24 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Resource Extractor RE-301 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 83, Decay = 2.503M, Efficienty = 14, UsePerMin = 24 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Rock Ripper 1 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.28M, Efficienty = 6.6M, UsePerMin = 22 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Rock Ripper 2 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 22, Decay = 1.129M, Efficienty = 7.7M, UsePerMin = 24 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Rock Ripper 3 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 44, Decay = 1.454M, Efficienty = 8.8M, UsePerMin = 24 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Rock Ripper 3 Gold Rush", ModeleId = id, Code = "", IsLimited = false, Value = 44, Decay = 0.833M, Efficienty = 8.5M, UsePerMin = 29 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Rock Ripper 4 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Rock Ripper Trainer (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.2M, Decay = 0.274M, Efficienty = 6, UsePerMin = 17 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Rock Ripper TT (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Rookie Rock Ripper", ModeleId = id, Code = "", IsLimited = false, Value = 1, Decay = 0.274M, Efficienty = 6, UsePerMin = 17 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Training Mineral Extractor (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.1M, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            repositories.Excavators.Add(new ExcavatorModel() { Nom = "Xtreme Excavator MK-I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 5, Decay = 0, Efficienty = 7.6M, UsePerMin = 17 });
        }

        private void AddRefiners(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Refiner").Id;
            repositories.Refiners.Add(new RefinerModel() { Nom = "Chikara Refiner Adjusted", ModeleId = id, Code = "", IsLimited = true, Value = 24, Decay = 0.015M, UsePerMin = 22 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Chikara Refiner Modified", ModeleId = id, Code = "", IsLimited = true, Value = 41, Decay = .013M, UsePerMin = 25 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Chikara Refiner MR200", ModeleId = id, Code = "", IsLimited = true, Value = 16, Decay = 0.023M, UsePerMin = 20 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Chikara Refiner MR300", ModeleId = id, Code = "", IsLimited = true, Value = 35, Decay = 0.022M, UsePerMin = 21 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Chikara Refiner MR400", ModeleId = id, Code = "", IsLimited = true, Value = 48, Decay = 0.02M, UsePerMin = 30 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Demonic Refiner MK-I (L)", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.03M, UsePerMin = 0 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Genesis Rookie OreRefiner (L)", ModeleId = id, Code = "", IsLimited = false, Value = 0.01M, Decay = 0.11M, UsePerMin = 0 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Genesis Star Basic Refiner", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.031M, UsePerMin = 20 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Imperium Resource Refiner 1A", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0.03M, UsePerMin = 0 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Imperium Resource Refiner B1", ModeleId = id, Code = "", IsLimited = true, Value = 6, Decay = 0.022M, UsePerMin = 21 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Initiate's Refiner", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "NI Basic Refiner", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "NI Refiner New Settler Issue", ModeleId = id, Code = "", IsLimited = true, Value = 1, Decay = 0, UsePerMin = 20 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "PTech Refiner 1", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.03M, UsePerMin = 0 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "PTech Refiner TT", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Punk Blender", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Refiner MR100", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.031M, UsePerMin = 20 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Transformer T-101", ModeleId = id, Code = "", IsLimited = true, Value = 8, Decay = 0.03M, UsePerMin = 20 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Transformer T-102", ModeleId = id, Code = "", IsLimited = true, Value = 22.75M, Decay = 0.028M, UsePerMin = 21 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Transformer T-103", ModeleId = id, Code = "", IsLimited = true, Value = 45.5M, Decay = 0.026M, UsePerMin = 22 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Transformer T-104", ModeleId = id, Code = "", IsLimited = true, Value = 55.3M, Decay = 0.023M, UsePerMin = 34 });
            repositories.Refiners.Add(new RefinerModel() { Nom = "Transformer T-105", ModeleId = id, Code = "", IsLimited = true, Value = 75, Decay = 0.021M, UsePerMin = 36 });

        }

        private void AddFinderAmplifiers(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Finder Amplifier").Id;
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Cheeky Finder Amp (L)", ModeleId = id, Code = "", IsLimited = true, Value = 50, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "D-Class Mining Amp (L)", ModeleId = id, Code = "", IsLimited = true, Value = 160, Decay = 400, Coefficient = 20M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "DSEC Seeker Amplifier II (L)", ModeleId = id, Code = "", IsLimited = true, Value = 125, Decay = 133, Coefficient = 6.7M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "DSEC Seeker Amplifier III (L)", ModeleId = id, Code = "", IsLimited = true, Value = 268, Decay = 285, Coefficient = 14.3M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "eMINE Amplifier I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 105, Decay = 75, Coefficient = 3.8M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "eMINE Amplifier II (L)", ModeleId = id, Code = "", IsLimited = true, Value = 105, Decay = 150, Coefficient = 7.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 1 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 78, Decay = 25, Coefficient = 1.3M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 1 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 78, Decay = 25, Coefficient = 1.3M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 1 Finder Amplifier Light (L)", ModeleId = id, Code = "", IsLimited = true, Value = 30, Decay = 25, Coefficient = 1.3M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 2 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 78, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 2 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 100, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 2 Finder Amplifier, SGA Edition", ModeleId = id, Code = "", IsLimited = false, Value = 78, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 2 Finder Amplifier Light (L)", ModeleId = id, Code = "", IsLimited = true, Value = 50, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 3 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 100, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 3 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 114, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 3 Finder Amplifier, SGA Edition", ModeleId = id, Code = "", IsLimited = false, Value = 114, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 3 Finder Amplifier Light (L)", ModeleId = id, Code = "", IsLimited = true, Value = 75, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 4 Finder Amplifier (L)", ModeleId = id, Code = "LVL4", IsLimited = true, Value = 150, Decay = 150, Coefficient = 7.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 5 Finder Amplifier", ModeleId = id, Code = "LVL5", IsLimited = false, Value = 113, Decay = 200, Coefficient = 10 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 5 Finder Amplifier (L)", ModeleId = id, Code = "LVL5", IsLimited = true, Value = 200, Decay = 200, Coefficient = 10 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 6 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 250, Decay = 250, Coefficient = 12.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 7 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 120, Decay = 300, Coefficient = 15 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 7 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 120, Decay = 300, Coefficient = 15 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 8 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 160, Decay = 400, Coefficient = 20 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 8 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 160, Decay = 400, Coefficient = 20 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 9 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 260, Decay = 500, Coefficient = 25 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 10 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 300, Decay = 750, Coefficient = 37.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 11 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 350, Decay = 1000, Coefficient = 50 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 12 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 255, Decay = 1500, Coefficient = 75 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level 13 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 340, Decay = 2000, Coefficient = 100 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level I Finder Amplifier 'Achilles' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 89, Decay = 25, Coefficient = 1.3M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level II Finder Amplifier 'Achilles' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 115, Decay = 50, Coefficient = 2.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level II Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 82, Decay = 60, Coefficient = 3 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level III Finder Amplifier 'Achilles' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 131, Decay = 100, Coefficient = 5 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level III Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 102, Decay = 80, Coefficient = 4 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level V Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 178, Decay = 220, Coefficient = 11 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level VII Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 198, Decay = 320, Coefficient = 16 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Level VIII Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 208, Decay = 380, Coefficient = 19 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 1 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 45, Decay = 80, Coefficient = 4 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 1 Gold Rush", ModeleId = id, Code = "", IsLimited = false, Value = 45, Decay = 80, Coefficient = 4 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 2 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 195, Decay = 160, Coefficient = 8 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 3 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 300, Decay = 250, Coefficient = 12.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 4 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 315, Decay = 350, Coefficient = 17.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 5 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 325, Decay = 450, Coefficient = 22.5M });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 6 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 338, Decay = 600, Coefficient = 30 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 7 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 360, Decay = 900, Coefficient = 45 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 8 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 385, Decay = 1200, Coefficient = 60 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 9 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 400, Decay = 1600, Coefficient = 80 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp 10 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 442, Decay = 2000, Coefficient = 100 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp I 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 64, Decay = 40, Coefficient = 2 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp IV 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 134, Decay = 120, Coefficient = 6 });
            repositories.FinderAmplifiers.Add(new FinderAmplifierModel() { Nom = "Terra Amp VI 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 188, Decay = 260, Coefficient = 13 });
        }

        private void AddEnhancers(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Finder Depth Enhancer").Id;
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Depth Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });


            id = repositories.Modeles.GetByNom("Finder Range Enhancer").Id;
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Range Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });


            id = repositories.Modeles.GetByNom("Finder Skill Enhancer").Id;
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Finder Skill Modification Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });

            id = repositories.Modeles.GetByNom("Excavator Speed Enhancer").Id;
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new EnhancerModel() { Nom = "Mining Excavator Speed Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
        }

        private void AddMaterials(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Material").Id;

        }

        private void AddPlanetMaterial(IRepositoriesUoW repositories)
        {
            throw new NotImplementedException();
        }

        private void AddSearchModes(IRepositoriesUoW repositories)
        {
            repositories.SearchModes.Add(new SearchModeModel() { Nom = "Ores", Abbrev = "O", Multiplicateur = 2 });
            repositories.SearchModes.Add(new SearchModeModel() { Nom = "Enmatters", Abbrev = "E", Multiplicateur = 1 });
            repositories.SearchModes.Add(new SearchModeModel() { Nom = "Treasures", Abbrev = "T", Multiplicateur = 3 });
            repositories.SearchModes.Add(new SearchModeModel() { Nom = "Ores, Enmatters", Abbrev = "OE", Multiplicateur = 3 });
            repositories.SearchModes.Add(new SearchModeModel() { Nom = "Ores, Treasures", Abbrev = "OT", Multiplicateur = 2.5M });
            repositories.SearchModes.Add(new SearchModeModel() { Nom = "Enmatters, Treasures", Abbrev = "ET", Multiplicateur = 2 });
            repositories.SearchModes.Add(new SearchModeModel() { Nom = "Ores, Enmatters, Treasures", Abbrev = "OET", Multiplicateur = 3 });

        }
    }
}

