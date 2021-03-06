﻿using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;
using System.Data.Entity;
using WpfApp.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;

namespace WpfApp.Context
{
    public class SeedClass : CreateDatabaseIfNotExists<MiningContext>
    {
        private IRepositoriesUoW repositories;

        protected override void Seed(MiningContext ctx)
        {
            repositories = new RepositoriesUoW(ctx);

            //SeedLauch();
            SqlScript();
            base.Seed(ctx);
        }

        private void SqlScript()
        {
            string script = File.ReadAllText(@"H:\Data\script.sql");
            repositories.GetContext().Database.ExecuteSqlCommand(script);
        }

        private void SeedLauch()
        {
            //AddCategories();
            //AddModeles();
            //AddlAccessoire();
            //AddPlanets();
            //AddFinders();
            //AddExcavators();
            //AddRefiners();
            //AddFinderAmplifiers();
            //AddEnhancers();
            //AddEnmatters();
            //AddOres();
            //AddTreasures();
            //AddPlanetMaterial(repositories);

            AddSearchModes();
        }

        private void AddCategories()
        {
            List<Categorie> list = new List<Categorie>();

            list.Add(new Categorie() { Nom = "Tool" });
            list.Add(new Categorie() { Nom = "Accessoire" });
            list.Add(new Categorie() { Nom = "Material" });

            repositories.Categories.AddRange(list);
        }

        private void AddModeles()
        {
            List<Modele> list = new List<Modele>();

            int id = repositories.Categories.GetByNom("Tool").Id;
            list.Add(new Modele() { Nom = "Finder", IsStackable = false, CategorieId = id });
            list.Add(new Modele() { Nom = "Excavator", IsStackable = false, CategorieId = id });
            list.Add(new Modele() { Nom = "Refiner", IsStackable = false, CategorieId = id });

            id = repositories.Categories.GetByNom("Accessoire").Id;
            list.Add(new Modele() { Nom = "Finder Amplifier", IsStackable = false, CategorieId = id });
            list.Add(new Modele() { Nom = "Finder Depth Enhancer", IsStackable = true, CategorieId = id });
            list.Add(new Modele() { Nom = "Finder Range Enhancer", IsStackable = true, CategorieId = id });
            list.Add(new Modele() { Nom = "Finder Skill Enhancer", IsStackable = true, CategorieId = id });
            list.Add(new Modele() { Nom = "Excavator Speed Enhancer", IsStackable = true, CategorieId = id });

            id = repositories.Categories.GetByNom("Material").Id;
            list.Add(new Modele() { Nom = "Ore", IsStackable = true, CategorieId = id });
            list.Add(new Modele() { Nom = "Enmatter", IsStackable = true, CategorieId = id });
            list.Add(new Modele() { Nom = "Treasure", IsStackable = true, CategorieId = id });
            list.Add(new Modele() { Nom = "Refined Ore", IsStackable = true, CategorieId = id });
            list.Add(new Modele() { Nom = "Refined Enmatter", IsStackable = true, CategorieId = id });
            list.Add(new Modele() { Nom = "Refined Treasure", IsStackable = true, CategorieId = id });

            repositories.Modeles.AddRange(list);
        }

        private void AddlAccessoire()
        {
            List<ToolAccessoire> list = new List<ToolAccessoire>();

            int tId = repositories.Modeles.GetByNom("Finder").Id;
            list.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Amplifier").Id });
            list.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Depth Enhancer").Id });
            list.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Range Enhancer").Id });
            list.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Skill Enhancer").Id });

            tId = repositories.Modeles.GetByNom("Excavator").Id;
            list.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Excavator Speed Enhancer").Id });

            repositories.ToolAccessoires.AddRange(list);
        }

        private void AddPlanets()
        {
            List<Planet> list = new List<Planet>();

            list.Add(new Planet() { Nom = "Calypso" });
            list.Add(new Planet() { Nom = "Arkadia" });
            list.Add(new Planet() { Nom = "F.O.M.A." });
            list.Add(new Planet() { Nom = "Toulan" });
            list.Add(new Planet() { Nom = "Rocktropia" });

            repositories.Planets.AddRange(list);
        }

        private void AddFinders()
        {
            List<Finder> list = new List<Finder>();

            int id = repositories.Modeles.GetByNom("Finder").Id;
            list.Add(new Finder() { Nom = "A.R.C. Finder 0001 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.25M, Range = 54, Depth = 204, UsePerMin = 9, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "CDF Finder z10 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 1, Decay = 0, Range = 54, Depth = 223.9M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "CDF Finder z25 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 2, Decay = 0.56M, Range = 54.2M, Depth = 422.9M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "CDF Finder z40 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 4, Decay = 0, Range = 54.6M, Depth = 741.3M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Demonic Detector MK-I (L)", Code = "", IsLimited = true, ModeleId = id, Value = 4.75M, Decay = 0.5M, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "DSEC Seeker L2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 18.6M, Decay = 0, Range = 55, Depth = 213.9M, UsePerMin = 0, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "DSEC Seeker L12 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 49, Decay = 2.29M, Range = 55, Depth = 462.7M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "DSEC Seeker L30 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 136, Decay = 3.96M, Range = 55, Depth = 820.9M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "eMINE FS (L)", Code = "", IsLimited = true, ModeleId = id, Value = 122, Decay = 1.743M, Range = 54, Depth = 676.6M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-101", Code = "F101", IsLimited = false, ModeleId = id, Value = 5.5M, Decay = 1, Range = 54, Depth = 263.7M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-102", Code = "F102", IsLimited = false, ModeleId = id, Value = 30, Decay = 1.15M, Range = 54, Depth = 323.4M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-103", Code = "F103", IsLimited = false, ModeleId = id, Value = 55, Decay = 1.45M, Range = 54.5M, Depth = 363.2M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-104", Code = "F104", IsLimited = false, ModeleId = id, Value = 66.6M, Decay = 1.63M, Range = 54.5M, Depth = 432.9M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-105", Code = "F105", IsLimited = false, ModeleId = id, Value = 82, Decay = 2.05M, Range = 55, Depth = 522.4M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-105 TEN Edition", Code = "", IsLimited = false, ModeleId = id, Value = 82, Decay = 2, Range = 55, Depth = 552.3M, UsePerMin = 9, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-106", Code = "", IsLimited = false, ModeleId = id, Value = 79.95M, Decay = 1.799M, Range = 55, Depth = 582.1M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-210 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 105, Decay = 1.25M, Range = 54, Depth = 383.1M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-211 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 121.2M, Decay = 1.306M, Range = 55, Depth = 472.6M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-212 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 155.2M, Decay = 1.343M, Range = 55, Depth = 592, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-212, SGA Edition (L)", Code = "", IsLimited = true, ModeleId = id, Value = 155.2M, Decay = 0, Range = 55, Depth = 612, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-213 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 201.2M, Decay = 1.66M, Range = 54.5M, Depth = 631.8M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-213 (L) Adapted", Code = "", IsLimited = true, ModeleId = id, Value = 678, Decay = 2.33M, Range = 54, Depth = 811, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-213 (L) Customized", Code = "", IsLimited = true, ModeleId = id, Value = 2678, Decay = 2.68M, Range = 55, Depth = 850.8M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Finder F-214 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 231.2M, Decay = 0, Range = 54, Depth = 651.8M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Genesis Rookie Finder (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.06M, Decay = 0.239M, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Genesis Star Rookie Finder (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Imperium Detectonator X2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 170M, Decay = 7, Range = 54, Depth = 626.9M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Imperium Trainee Finder (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.52M, Range = 54, Depth = 204, UsePerMin = 9, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Island Ziplex Z1 Seeker", Code = "", IsLimited = false, ModeleId = id, Value = 2.4M, Decay = 0.751M, Range = 55, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Lost Soul Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 48, Decay = 3.7M, Range = 54.8M, Depth = 721, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "NI Finder New Settler Issue (L)", Code = "", IsLimited = true, ModeleId = id, Value = 1, Decay = 0, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Omegaton Detectonator MD-1 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.239M, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Sabad Finder M1 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 2, Decay = 0.751M, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Sabad Finder M2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 26, Decay = 0, Range = 55, Depth = 303.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Sabad Finder M3 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Sabad Finder M4 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 78, Decay = 0, Range = 55, Depth = 477.6M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Sabad Finder M5 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 1 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 2.5M, Decay = 1.5M, Range = 55, Depth = 206, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 2 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 2.2M, Range = 55, Depth = 408, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 3 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 95, Decay = 3.225M, Range = 55, Depth = 631.8M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 3 Gold Rush", Code = "", IsLimited = false, ModeleId = id, Value = 95, Decay = 3.225M, Range = 55, Depth = 631.8M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 4 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 150, Decay = 3.72M, Range = 55, Depth = 741.3M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 5 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 205, Decay = 4.125M, Range = 55, Depth = 830.8M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 6 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 260, Decay = 4.372M, Range = 55, Depth = 885.6M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 7 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 320, Decay = 4.552M, Range = 55, Depth = 925.4M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 8 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 390, Decay = 4.89M, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster 8 Gold Rush", Code = "", IsLimited = false, ModeleId = id, Value = 390, Decay = 0, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster Trainer (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.4M, Decay = 0.75M, Range = 55, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "TerraMaster TT (L)", Code = "", IsLimited = true, ModeleId = id, Value = 0.1M, Decay = 0.239M, Range = 54, Depth = 104.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A10 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 50, Decay = 1.5M, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A13 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 51, Decay = 0, Range = 54, Depth = 223.9M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A16 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 52, Decay = 0, Range = 54, Depth = 253.8M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A19 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 53, Decay = 1.8M, Range = 55, Depth = 303.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A22 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 54, Decay = 1.9M, Range = 55, Depth = 403, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A25 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 2, Range = 55.1M, Depth = 502.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A28 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 56, Decay = 0, Range = 55.2M, Depth = 602, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A31 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 57, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A33 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 58, Decay = 0, Range = 55.2M, Depth = 801, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex A35 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 59, Decay = 0, Range = 55.2M, Depth = 900.5M, UsePerMin = 0, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex B35 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 50, Decay = 3, Range = 55, Depth = 502.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex B40 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 51, Decay = 0, Range = 55.1M, Depth = 522.4M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex B50 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 52, Decay = 3.2M, Range = 55.2M, Depth = 542.3M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex B60 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 53, Decay = 0, Range = 55.2M, Depth = 562.2M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex B70 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 54, Decay = 3, Range = 55.2M, Depth = 582.1M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex C50 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 40, Decay = 0, Range = 55.2M, Depth = 283.6M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex C65 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 44, Decay = 1.2M, Range = 55.2M, Depth = 313.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex C70 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 46, Decay = 1.2M, Range = 55.2M, Depth = 363.2M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex D33 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 44, Decay = 3.6M, Range = 54, Depth = 801, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex D44 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 46, Decay = 3.2M, Range = 54, Depth = 900.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex D52 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 3, Range = 54.5M, Depth = 990, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex P20 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex P30 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0.16M, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex P50 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex P85 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex P160 (L)", Code = "", IsLimited = true, ModeleId = id, Value = 10, Decay = 0.7M, Range = 55.2M, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex TK120 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 218.6M, Decay = 1.803M, Range = 55, Depth = 701.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex TK220 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 264.8M, Decay = 3.96M, Range = 55, Depth = 776.1M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex TK320 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 311, Decay = 4.303M, Range = 55, Depth = 850.8M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex TK320 Seeker, SGA Edition (L)", Code = "", IsLimited = true, ModeleId = id, Value = 233.25M, Decay = 0, Range = 55, Depth = 870.7M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex VRX2000 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 339, Decay = 4.651M, Range = 55, Depth = 925.4M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex VRX3000 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 387, Decay = 5.01M, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex Z1 Seeker", Code = "", IsLimited = false, ModeleId = id, Value = 2.4M, Decay = 1.501M, Range = 55, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex Z5 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 29.8M, Decay = 1.855M, Range = 55, Depth = 303.5M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex Z10 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 2.209M, Range = 55, Depth = 403, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex Z10 Seeker, SGA Edition (L)", Code = "", IsLimited = true, ModeleId = id, Value = 55, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex Z15 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 80, Decay = 2.557M, Range = 55, Depth = 477.6M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex Z20 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 126.2M, Decay = 1.452M, Range = 55, Depth = 552.3M, UsePerMin = 8, BasePecSearch = 50 });
            list.Add(new Finder() { Nom = "Ziplex Z25 Seeker (L)", Code = "", IsLimited = true, ModeleId = id, Value = 172.4M, Decay = 3.251M, Range = 55, Depth = 626.9M, UsePerMin = 8, BasePecSearch = 50 });

            repositories.Finders.AddRange(list);
        }

        private void AddExcavators()
        {
            List<Excavator> list = new List<Excavator>();

            int id = repositories.Modeles.GetByNom("Excavator").Id;
            list.Add(new Excavator() { Nom = "ARD Excavator A-100 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "ARD Excavator Beginner (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.5M, Decay = 0, Efficienty = 1.2M, UsePerMin = 17 });
            list.Add(new Excavator() { Nom = "ARD Excavator M1 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 2.4M, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "ARD Excavator M2 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 54, Decay = 0, Efficienty = 9.2M, UsePerMin = 24 });
            list.Add(new Excavator() { Nom = "ARD Excavator M3 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            list.Add(new Excavator() { Nom = "ARD Excavator M4 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            list.Add(new Excavator() { Nom = "ARD Excavator M5 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 132, Decay = 2.336M, Efficienty = 12.8M, UsePerMin = 26 });
            list.Add(new Excavator() { Nom = "Demonic Excavator MK-I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 5, Decay = 0.1M, Efficienty = 0.6M, UsePerMin = 17 });
            list.Add(new Excavator() { Nom = "Earth Excavator ME/01", ModeleId = id, Code = "", IsLimited = false, Value = 2.4M, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "eMINE E (L)", ModeleId = id, Code = "", IsLimited = true, Value = 85, Decay = 2.101M, Efficienty = 12, UsePerMin = 27 });
            list.Add(new Excavator() { Nom = "Genesis Rookie Extractor (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.01M, Decay = 0, Efficienty = 1.2M, UsePerMin = 17 });
            list.Add(new Excavator() { Nom = "Genesis Star Basic Excavator (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/02", ModeleId = id, Code = "", IsLimited = false, Value = 8, Decay = 0.5M, Efficienty = 7.2M, UsePerMin = 22 });
            list.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/03", ModeleId = id, Code = "", IsLimited = false, Value = 41, Decay = 0.75M, Efficienty = 7.2M, UsePerMin = 22 });
            list.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/04", ModeleId = id, Code = "", IsLimited = false, Value = 55, Decay = 0.85M, Efficienty = 8, UsePerMin = 23 });
            list.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/05", ModeleId = id, Code = "", IsLimited = false, Value = 66, Decay = 1, Efficienty = 8.8M, UsePerMin = 23 });
            list.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/05, SGA Edition", ModeleId = id, Code = "", IsLimited = false, Value = 66, Decay = 0.8M, Efficienty = 8.8M, UsePerMin = 33 });
            list.Add(new Excavator() { Nom = "Genesis Star Excavator Adjusted", ModeleId = id, Code = "", IsLimited = false, Value = 18, Decay = 0.5M, Efficienty = 12.8M, UsePerMin = 23 });
            list.Add(new Excavator() { Nom = "Genesis Star Excavator Improved", ModeleId = id, Code = "", IsLimited = false, Value = 27, Decay = 0.5M, Efficienty = 15.2M, UsePerMin = 24 });
            list.Add(new Excavator() { Nom = "Genesis Star Excavator Modified", ModeleId = id, Code = "", IsLimited = false, Value = 4362, Decay = 3.212M, Efficienty = 20.8M, UsePerMin = 27 });
            list.Add(new Excavator() { Nom = "Genesis Star Rookie Extractor (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.1M, Decay = 0, Efficienty = 1.2M, UsePerMin = 17 });
            list.Add(new Excavator() { Nom = "Imperium Extirpater v1", ModeleId = id, Code = "", IsLimited = false, Value = 2.2M, Decay = 0.34M, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "Initiate''s Excavator (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "Island Earth Excavator ME/01", ModeleId = id, Code = "", IsLimited = false, Value = 2.4M, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "Lost Soul Savior (L)", ModeleId = id, Code = "", IsLimited = true, Value = 64, Decay = 0, Efficienty = 19.2M, UsePerMin = 26 });
            list.Add(new Excavator() { Nom = "NI Basic Excavator (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "NI Extractor  New Settler Issue  (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.1M, Decay = 0, Efficienty = 1.2M, UsePerMin = 24 });
            list.Add(new Excavator() { Nom = "Punk Digger (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-101", ModeleId = id, Code = "", IsLimited = false, Value = 4, Decay = 0.6M, Efficienty = 7.2M, UsePerMin = 20 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-102", ModeleId = id, Code = "", IsLimited = false, Value = 12.6M, Decay = 1.2M, Efficienty = 8, UsePerMin = 22 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-103", ModeleId = id, Code = "", IsLimited = false, Value = 50, Decay = 1.5M, Efficienty = 8.4M, UsePerMin = 23 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-104", ModeleId = id, Code = "", IsLimited = false, Value = 65, Decay = 1.73M, Efficienty = 9.6M, UsePerMin = 24 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-105", ModeleId = id, Code = "", IsLimited = false, Value = 80, Decay = 2.22M, Efficienty = 10.8M, UsePerMin = 26 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-201 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 89, Decay = 1.29M, Efficienty = 9.2M, UsePerMin = 25 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-202 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 110, Decay = 1.6M, Efficienty = 10.4M, UsePerMin = 25 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-203 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 185, Decay = 2.06M, Efficienty = 11.6M, UsePerMin = 25 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-204 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 195, Decay = 2.331M, Efficienty = 12.8M, UsePerMin = 26 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-204 Adapted (L)", ModeleId = id, Code = "", IsLimited = true, Value = 195, Decay = 2.331M, Efficienty = 12.8M, UsePerMin = 34 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-205 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 83, Decay = 2.5M, Efficienty = 14, UsePerMin = 24 });
            list.Add(new Excavator() { Nom = "Resource Extractor RE-301 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 83, Decay = 2.503M, Efficienty = 14, UsePerMin = 24 });
            list.Add(new Excavator() { Nom = "Rock Ripper 1 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.28M, Efficienty = 6.6M, UsePerMin = 22 });
            list.Add(new Excavator() { Nom = "Rock Ripper 2 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 22, Decay = 1.129M, Efficienty = 7.7M, UsePerMin = 24 });
            list.Add(new Excavator() { Nom = "Rock Ripper 3 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 44, Decay = 1.454M, Efficienty = 8.8M, UsePerMin = 24 });
            list.Add(new Excavator() { Nom = "Rock Ripper 3 Gold Rush", ModeleId = id, Code = "", IsLimited = false, Value = 44, Decay = 0.833M, Efficienty = 8.5M, UsePerMin = 29 });
            list.Add(new Excavator() { Nom = "Rock Ripper 4 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            list.Add(new Excavator() { Nom = "Rock Ripper Trainer (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.2M, Decay = 0.274M, Efficienty = 6, UsePerMin = 17 });
            list.Add(new Excavator() { Nom = "Rock Ripper TT (L)", ModeleId = id, Code = "", IsLimited = true, Value = 3, Decay = 0.3M, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "Rookie Rock Ripper", ModeleId = id, Code = "", IsLimited = false, Value = 1, Decay = 0.274M, Efficienty = 6, UsePerMin = 17 });
            list.Add(new Excavator() { Nom = "Training Mineral Extractor (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.1M, Decay = 0, Efficienty = 6.8M, UsePerMin = 19 });
            list.Add(new Excavator() { Nom = "Xtreme Excavator MK-I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 5, Decay = 0, Efficienty = 7.6M, UsePerMin = 17 });

            repositories.Excavators.AddRange(list);
        }

        private void AddRefiners()
        {
            List<Refiner> list = new List<Refiner>();

            int id = repositories.Modeles.GetByNom("Refiner").Id;
            list.Add(new Refiner() { Nom = "Chikara Refiner Adjusted", ModeleId = id, Code = "", IsLimited = false, Value = 24, Decay = 0.015M, UsePerMin = 22 });
            list.Add(new Refiner() { Nom = "Chikara Refiner Modified", ModeleId = id, Code = "", IsLimited = false, Value = 41, Decay = .013M, UsePerMin = 25 });
            list.Add(new Refiner() { Nom = "Chikara Refiner MR200", ModeleId = id, Code = "", IsLimited = false, Value = 16, Decay = 0.023M, UsePerMin = 20 });
            list.Add(new Refiner() { Nom = "Chikara Refiner MR300", ModeleId = id, Code = "", IsLimited = false, Value = 35, Decay = 0.022M, UsePerMin = 21 });
            list.Add(new Refiner() { Nom = "Chikara Refiner MR400", ModeleId = id, Code = "", IsLimited = false, Value = 48, Decay = 0.02M, UsePerMin = 30 });
            list.Add(new Refiner() { Nom = "Demonic Refiner MK-I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 2, Decay = 0.03M, UsePerMin = 0 });
            list.Add(new Refiner() { Nom = "Genesis Rookie OreRefiner (L)", ModeleId = id, Code = "", IsLimited = true, Value = 0.01M, Decay = 0.11M, UsePerMin = 0 });
            list.Add(new Refiner() { Nom = "Genesis Star Basic Refiner", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 20 });
            list.Add(new Refiner() { Nom = "Imperium Resource Refiner 1A", ModeleId = id, Code = "", IsLimited = false, Value = 3, Decay = 0.03M, UsePerMin = 0 });
            list.Add(new Refiner() { Nom = "Imperium Resource Refiner B1", ModeleId = id, Code = "", IsLimited = false, Value = 6, Decay = 0.022M, UsePerMin = 21 });
            list.Add(new Refiner() { Nom = "Initiate's Refiner", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            list.Add(new Refiner() { Nom = "NI Basic Refiner", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            list.Add(new Refiner() { Nom = "NI Refiner New Settler Issue", ModeleId = id, Code = "", IsLimited = false, Value = 1, Decay = 0, UsePerMin = 20 });
            list.Add(new Refiner() { Nom = "PTech Refiner 1", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.03M, UsePerMin = 0 });
            list.Add(new Refiner() { Nom = "PTech Refiner TT", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            list.Add(new Refiner() { Nom = "Punk Blender", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 0 });
            list.Add(new Refiner() { Nom = "Refiner MR100", ModeleId = id, Code = "", IsLimited = false, Value = 2, Decay = 0.031M, UsePerMin = 20 });
            list.Add(new Refiner() { Nom = "Transformer T-101", ModeleId = id, Code = "", IsLimited = false, Value = 8, Decay = 0.03M, UsePerMin = 20 });
            list.Add(new Refiner() { Nom = "Transformer T-102", ModeleId = id, Code = "", IsLimited = false, Value = 22.75M, Decay = 0.028M, UsePerMin = 21 });
            list.Add(new Refiner() { Nom = "Transformer T-103", ModeleId = id, Code = "", IsLimited = false, Value = 45.5M, Decay = 0.026M, UsePerMin = 22 });
            list.Add(new Refiner() { Nom = "Transformer T-104", ModeleId = id, Code = "", IsLimited = false, Value = 55.3M, Decay = 0.023M, UsePerMin = 34 });
            list.Add(new Refiner() { Nom = "Transformer T-105", ModeleId = id, Code = "", IsLimited = false, Value = 75, Decay = 0.021M, UsePerMin = 36 });

            repositories.Refiners.AddRange(list);
        }

        private void AddFinderAmplifiers()
        {
            List<FinderAmplifier> list = new List<FinderAmplifier>();

            int id = repositories.Modeles.GetByNom("Finder Amplifier").Id;
            list.Add(new FinderAmplifier() { Nom = "Cheeky Finder Amp (L)", ModeleId = id, Code = "", IsLimited = true, Value = 50, Decay = 50, Coefficient = 2.5M });
            list.Add(new FinderAmplifier() { Nom = "D-Class Mining Amp (L)", ModeleId = id, Code = "", IsLimited = true, Value = 160, Decay = 400, Coefficient = 20M });
            list.Add(new FinderAmplifier() { Nom = "DSEC Seeker Amplifier II (L)", ModeleId = id, Code = "", IsLimited = true, Value = 125, Decay = 133, Coefficient = 6.7M });
            list.Add(new FinderAmplifier() { Nom = "DSEC Seeker Amplifier III (L)", ModeleId = id, Code = "", IsLimited = true, Value = 268, Decay = 285, Coefficient = 14.3M });
            list.Add(new FinderAmplifier() { Nom = "eMINE Amplifier I (L)", ModeleId = id, Code = "", IsLimited = true, Value = 105, Decay = 75, Coefficient = 3.8M });
            list.Add(new FinderAmplifier() { Nom = "eMINE Amplifier II (L)", ModeleId = id, Code = "", IsLimited = true, Value = 105, Decay = 150, Coefficient = 7.5M });
            list.Add(new FinderAmplifier() { Nom = "Level 1 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 78, Decay = 25, Coefficient = 1.3M });
            list.Add(new FinderAmplifier() { Nom = "Level 1 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 78, Decay = 25, Coefficient = 1.3M });
            list.Add(new FinderAmplifier() { Nom = "Level 1 Finder Amplifier Light (L)", ModeleId = id, Code = "", IsLimited = true, Value = 30, Decay = 25, Coefficient = 1.3M });
            list.Add(new FinderAmplifier() { Nom = "Level 2 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 78, Decay = 50, Coefficient = 2.5M });
            list.Add(new FinderAmplifier() { Nom = "Level 2 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 100, Decay = 50, Coefficient = 2.5M });
            list.Add(new FinderAmplifier() { Nom = "Level 2 Finder Amplifier, SGA Edition", ModeleId = id, Code = "", IsLimited = false, Value = 78, Decay = 50, Coefficient = 2.5M });
            list.Add(new FinderAmplifier() { Nom = "Level 2 Finder Amplifier Light (L)", ModeleId = id, Code = "", IsLimited = true, Value = 50, Decay = 50, Coefficient = 2.5M });
            list.Add(new FinderAmplifier() { Nom = "Level 3 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 100, Decay = 100, Coefficient = 5 });
            list.Add(new FinderAmplifier() { Nom = "Level 3 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 114, Decay = 100, Coefficient = 5 });
            list.Add(new FinderAmplifier() { Nom = "Level 3 Finder Amplifier, SGA Edition", ModeleId = id, Code = "", IsLimited = false, Value = 114, Decay = 100, Coefficient = 5 });
            list.Add(new FinderAmplifier() { Nom = "Level 3 Finder Amplifier Light (L)", ModeleId = id, Code = "", IsLimited = true, Value = 75, Decay = 100, Coefficient = 5 });
            list.Add(new FinderAmplifier() { Nom = "Level 4 Finder Amplifier (L)", ModeleId = id, Code = "LVL4", IsLimited = true, Value = 150, Decay = 150, Coefficient = 7.5M });
            list.Add(new FinderAmplifier() { Nom = "Level 5 Finder Amplifier", ModeleId = id, Code = "LVL5", IsLimited = false, Value = 113, Decay = 200, Coefficient = 10 });
            list.Add(new FinderAmplifier() { Nom = "Level 5 Finder Amplifier (L)", ModeleId = id, Code = "LVL5", IsLimited = true, Value = 200, Decay = 200, Coefficient = 10 });
            list.Add(new FinderAmplifier() { Nom = "Level 6 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 250, Decay = 250, Coefficient = 12.5M });
            list.Add(new FinderAmplifier() { Nom = "Level 7 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 120, Decay = 300, Coefficient = 15 });
            list.Add(new FinderAmplifier() { Nom = "Level 7 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 120, Decay = 300, Coefficient = 15 });
            list.Add(new FinderAmplifier() { Nom = "Level 8 Finder Amplifier", ModeleId = id, Code = "", IsLimited = false, Value = 160, Decay = 400, Coefficient = 20 });
            list.Add(new FinderAmplifier() { Nom = "Level 8 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 160, Decay = 400, Coefficient = 20 });
            list.Add(new FinderAmplifier() { Nom = "Level 9 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 260, Decay = 500, Coefficient = 25 });
            list.Add(new FinderAmplifier() { Nom = "Level 10 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 300, Decay = 750, Coefficient = 37.5M });
            list.Add(new FinderAmplifier() { Nom = "Level 11 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 350, Decay = 1000, Coefficient = 50 });
            list.Add(new FinderAmplifier() { Nom = "Level 12 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 255, Decay = 1500, Coefficient = 75 });
            list.Add(new FinderAmplifier() { Nom = "Level 13 Finder Amplifier (L)", ModeleId = id, Code = "", IsLimited = true, Value = 340, Decay = 2000, Coefficient = 100 });
            list.Add(new FinderAmplifier() { Nom = "Level I Finder Amplifier 'Achilles' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 89, Decay = 25, Coefficient = 1.3M });
            list.Add(new FinderAmplifier() { Nom = "Level II Finder Amplifier 'Achilles' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 115, Decay = 50, Coefficient = 2.5M });
            list.Add(new FinderAmplifier() { Nom = "Level II Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 82, Decay = 60, Coefficient = 3 });
            list.Add(new FinderAmplifier() { Nom = "Level III Finder Amplifier 'Achilles' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 131, Decay = 100, Coefficient = 5 });
            list.Add(new FinderAmplifier() { Nom = "Level III Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 102, Decay = 80, Coefficient = 4 });
            list.Add(new FinderAmplifier() { Nom = "Level V Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 178, Decay = 220, Coefficient = 11 });
            list.Add(new FinderAmplifier() { Nom = "Level VII Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 198, Decay = 320, Coefficient = 16 });
            list.Add(new FinderAmplifier() { Nom = "Level VIII Finder Amplifier 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 208, Decay = 380, Coefficient = 19 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 1 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 45, Decay = 80, Coefficient = 4 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 1 Gold Rush", ModeleId = id, Code = "", IsLimited = false, Value = 45, Decay = 80, Coefficient = 4 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 2 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 195, Decay = 160, Coefficient = 8 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 3 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 300, Decay = 250, Coefficient = 12.5M });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 4 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 315, Decay = 350, Coefficient = 17.5M });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 5 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 325, Decay = 450, Coefficient = 22.5M });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 6 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 338, Decay = 600, Coefficient = 30 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 7 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 360, Decay = 900, Coefficient = 45 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 8 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 385, Decay = 1200, Coefficient = 60 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 9 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 400, Decay = 1600, Coefficient = 80 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp 10 (L)", ModeleId = id, Code = "", IsLimited = true, Value = 442, Decay = 2000, Coefficient = 100 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp I 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 64, Decay = 40, Coefficient = 2 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp IV 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 134, Decay = 120, Coefficient = 6 });
            list.Add(new FinderAmplifier() { Nom = "Terra Amp VI 'Athena' (L)", ModeleId = id, Code = "", IsLimited = true, Value = 188, Decay = 260, Coefficient = 13 });

            repositories.FinderAmplifiers.AddRange(list);
        }

        private void AddEnhancers()
        {
            List<Enhancer> list = new List<Enhancer>();

            int id = repositories.Modeles.GetByNom("Finder Depth Enhancer").Id;
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Depth Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 7.43M, BonusValue2 = 0, Value = 0.8M });


            id = repositories.Modeles.GetByNom("Finder Range Enhancer").Id;
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Range Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 1, BonusValue2 = 10, Value = 1 });


            id = repositories.Modeles.GetByNom("Finder Skill Enhancer").Id;
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Finder Skill Modification Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 0.5M, BonusValue2 = 0, Value = 0.6M });

            id = repositories.Modeles.GetByNom("Excavator Speed Enhancer").Id;
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer I", ModeleId = id, Slot = 1, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer II", ModeleId = id, Slot = 2, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer III", ModeleId = id, Slot = 3, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer IV", ModeleId = id, Slot = 4, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer IX", ModeleId = id, Slot = 9, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer V", ModeleId = id, Slot = 5, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer VI", ModeleId = id, Slot = 6, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer VII", ModeleId = id, Slot = 7, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer VIII", ModeleId = id, Slot = 8, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });
            repositories.Enhancers.Add(new Enhancer() { Nom = "Mining Excavator Speed Enhancer X", ModeleId = id, Slot = 10, BonusValue1 = 10, BonusValue2 = 0, Value = 0.2M });

            repositories.Enhancers.AddRange(list);
        }

        private void AddEnmatters()
        {
            List<Refinable> list = new List<Refinable>();
            // Enmatters
            int idU = repositories.Modeles.GetByNom("Enmatter").Id;
            int idR = repositories.Modeles.GetByNom("Refined Enmatter").Id;

            repositories.Materials.Add(new Material() { Nom = "Force Nexus", ModeleId = idU, Value = 0.01M });
            repositories.Materials.Add(new Material() { Nom = "Growth Molecules", ModeleId = idU, Value = 0.47M });
            repositories.Materials.Add(new Material() { Nom = "Sweetstuff", ModeleId = idU, Value = 0.01M });

            repositories.Materials.Add(new Material() { Nom = "Energized Fertilizer", ModeleId = idR, Value = 0.47M });
            repositories.Materials.Add(new Material() { Nom = "Aurilinin Gel", ModeleId = idR, Value = 4.04M });
            repositories.Materials.Add(new Material() { Nom = "Chilling Agent", ModeleId = idR, Value = 0M });
            repositories.Materials.Add(new Material() { Nom = "Distilled Sweat Crystal", ModeleId = idR, Value = 1.1106M });
            repositories.Materials.Add(new Material() { Nom = "Magtonium Dust", ModeleId = idR, Value = 0M });
            repositories.Materials.Add(new Material() { Nom = "Zincalicid Energy Crystal", ModeleId = idR, Value = 4.24M });

            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Acid Root", ModeleId = idU, Value = 0.32M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Root Acid", ModeleId = idR, Value = 0.64M }),
                Quantity = 2});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Alicenies Liquid", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Alicenies Gel", ModeleId = idR, Value = 0.1M }),
                Quantity = 2});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Angelic Grit", ModeleId = idU, Value = 0.5M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Angelic Flakes", ModeleId = idR, Value = 1M }),
                Quantity = 2});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Angel Scales", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Light Mail", ModeleId = idR, Value = 0.02M }),
                Quantity = 2});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ares Head", ModeleId = idU, Value = 0.26M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ares Powder", ModeleId = idR, Value = 0.52M }),
                Quantity = 2});
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Azur Pearls", ModeleId = idU, Value = 0.96M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Pearl Sand", ModeleId = idR, Value = 1.92M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Binary Fluid", ModeleId = idU, Value = 0.75M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Binary Energy", ModeleId = idR, Value = 1.5M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Blood Moss", ModeleId = idU, Value = 0.09M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Medical Compress", ModeleId = idR, Value = 0.18M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Cave Sap", ModeleId = idU, Value = 0.39M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Putty", ModeleId = idR, Value = 0.78M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Crude Oil", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Oil", ModeleId = idR, Value = 0.02M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Devil's Tail", ModeleId = idU, Value = 0.47M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Chalmon", ModeleId = idR, Value = 0.94M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Dianthus Liquid", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Dianthus Crystal Powder", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Dunkel Particle", ModeleId = idU, Value = 0.55M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Dunkel Plastix", ModeleId = idR, Value = 1.1M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Energized Crystal", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Energized Crystal Cell", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ferrum Nuts", ModeleId = idU, Value = 1 }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Antimagnetic Oil", ModeleId = idR, Value = 2M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Fire Root Globule", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Fire Root Pellet", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Garcen Grease", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Garcen Lubricant", ModeleId = idR, Value = 0.2M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Henren Stems", ModeleId = idU, Value = 0.63M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Henren Cube", ModeleId = idR, Value = 1.26M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lumis Leach", ModeleId = idU, Value = 0.42M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Light Liquid", ModeleId = idR, Value = 0.84M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Magerian Mist", ModeleId = idU, Value = 0.25M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Magerian Spray", ModeleId = idR, Value = 0.5M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Melchi Water", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Melchi Crystal", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lytairian Dust", ModeleId = idU, Value = 0.19M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lytairian Powder", ModeleId = idR, Value = 0.38M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Solis Beans", ModeleId = idU, Value = 0.78M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Solis Paste", ModeleId = idR, Value = 1.56M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Vegatation Spores", ModeleId = idU, Value = 0.4M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Inhaler", ModeleId = idR, Value = 0.8M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Typonolic Steam", ModeleId = idU, Value = 0.15M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Typonolic Gas", ModeleId = idR, Value = 0.3M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Black Russian Cocktail Mix", ModeleId = idU, Value = 0.03M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Black Russian Cocktail", ModeleId = idR, Value = 0.06M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Blue Crystal", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hardening Agent", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Bodai Dust", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Bodai Filler", ModeleId = idR, Value = 0.4M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Clear Crystal", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lightening Agent", ModeleId = idR, Value = 0.2M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Edres Resin", ModeleId = idU, Value = 0.13M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Edres Varnish", ModeleId = idR, Value = 0.26M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Florican Mist", ModeleId = idU, Value = 0.27M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Florican Spray", ModeleId = idR, Value = 0.54M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ghali", ModeleId = idU, Value = 0.16M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ghali Powder", ModeleId = idR, Value = 0.32M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Gorbek Emulsion", ModeleId = idU, Value = 0.4M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Gorbek Tallow", ModeleId = idR, Value = 0.8M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Green Crystal", ModeleId = idU, Value = 0.03M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Life Essence", ModeleId = idR, Value = 0.06M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Harvey Wallbanger Cocktail Mix", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Harvey Wallbanger Cocktail", ModeleId = idR, Value = 0.08M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hazy Crystal", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Reflecting Agent", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hurricane Cocktail Mix", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hurricane Cocktail", ModeleId = idR, Value = 0.02M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hydrogen Steam", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hydrogen Gas", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kamikaze Cocktail Mix", ModeleId = idU, Value = 0.085M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kamikaze Cocktail", ModeleId = idR, Value = 0.17M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Long Island Ice Tea Cocktail Mix", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Long Island Ice Tea Cocktail", ModeleId = idR, Value = 0.1M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lotium Fluid", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lotium Gel", ModeleId = idR, Value = 0.6M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Mai Tai Cocktail Mix", ModeleId = idU, Value = 0.015M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Mai Tai Cocktail", ModeleId = idR, Value = 0.03M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Mamnoon", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Mamnoon Mist", ModeleId = idR, Value = 0.16M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Mojito Cocktail Mix", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Mojito Cocktail", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Nawa Drops", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Nawa Vial", ModeleId = idR, Value = 0.02M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Nirvana Cocktail Mix", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Nirvana Cocktail", ModeleId = idR, Value = 0.04M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Orange Crystal", ModeleId = idU, Value = 0.07M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Softening Agent", ModeleId = idR, Value = 0.14M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Pel Crystals", ModeleId = idU, Value = 0.5M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Pel Liquid", ModeleId = idR, Value = 1M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Pina Colada Cocktail Mix", ModeleId = idU, Value = 0.025M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Pina Colada Cocktail", ModeleId = idR, Value = 0.05M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Purple Crystal", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Darkening Agent", ModeleId = idR, Value = 0.16M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Qaz Worm", ModeleId = idU, Value = 0.06M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hareer Thread", ModeleId = idR, Value = 0.24M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Quil Sap", ModeleId = idU, Value = 0.25M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Quil Rubber", ModeleId = idR, Value = 0.5M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Rainbow Crystal", ModeleId = idU, Value = 0.15M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Color Enhancing Agent", ModeleId = idR, Value = 0.3M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Red Molten Crystal", ModeleId = idU, Value = 0.5M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Heating Agent", ModeleId = idR, Value = 0M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Sham", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Sham Sand", ModeleId = idR, Value = 0.01M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Somin Tar", ModeleId = idU, Value = 0.06M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Somin Glue", ModeleId = idR, Value = 0.12M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Star Particles", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Star Dust", ModeleId = idR, Value = 0.16M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Vorn Pellets", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Vorn Plastic", ModeleId = idR, Value = 0.4M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Whiskey Sour Cocktail Mix", ModeleId = idU, Value = 0.075M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Whiskey Sour Cocktail", ModeleId = idR, Value = 0.15M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Xelo Haze", ModeleId = idU, Value = 0.39M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Xelo Vapour", ModeleId = idR, Value = 0.78M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Yashib Stone", ModeleId = idU, Value = 0.13M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Yashib Ingot", ModeleId = idR, Value = 0.26M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Yellow Crystal", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Super Adhesive", ModeleId = idR, Value = 0.02M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Youd", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Youd Bottle", ModeleId = idR, Value = 0.08M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zoldenite Dust", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zoldenite Crystal", ModeleId = idR, Value = 0.08M }),
                Quantity = 2
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zolphic Oil", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zolphic Grease", ModeleId = idR, Value = 0.08M }),
                Quantity = 2
            });

            repositories.Refinables.AddRange(list);
        }

        private void AddOres()
        {
            List<Refinable> list = new List<Refinable>();

            int idU = repositories.Modeles.GetByNom("Ore").Id;
            int idR = repositories.Modeles.GetByNom("Refined Ore").Id;
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Adomasite Stone", ModeleId = idU, Value = 0.6M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Adomasite Ingot", ModeleId = idR, Value = 1.8M }),
                Quantity = 3});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Alferix Stone", ModeleId = idU, Value = 0.95M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Alferix Ingot", ModeleId = idR, Value = 2.85M }),
                Quantity = 3});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Azzurdite Stone", ModeleId = idU, Value = 1.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Azzurdite Ingot", ModeleId = idR, Value = 3.6M }),
                Quantity = 3});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Belkar Stone", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Belkar Ingot", ModeleId = idR, Value = 0.06M }),
                Quantity = 3});
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Blausariam Stone", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Blausariam Ingot", ModeleId = idR, Value = 0.12M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Caldorite stone", ModeleId = idU, Value = 0.17M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Caldorite Ingot", ModeleId = idR, Value = 0.51M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Cobalt Stone", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Cobalt Ingot", ModeleId = idR, Value = 0.6M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Copper Stone", ModeleId = idU, Value = 0.16M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Copper Ingot", ModeleId = idR, Value = 0.48M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Cumbriz Stone", ModeleId = idU, Value = 0.15M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Cumbriz Ingot", ModeleId = idR, Value = 0.45M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Dianum Ore", ModeleId = idU, Value = 1.25M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Dianum Ingot", ModeleId = idR, Value = 3.75M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Durulium Stone", ModeleId = idU, Value = 0.8M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Durulium Ingot", ModeleId = idR, Value = 2.4M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Erdorium Stone", ModeleId = idU, Value = 0.4M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Erdorium Ingot", ModeleId = idR, Value = 1.2M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Erionite Stone", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Erionite Ingot", ModeleId = idR, Value = 0.6M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Frigulite Stone", ModeleId = idU, Value = 0.12M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Frigulite Ingot", ModeleId = idR, Value = 0.36M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ganganite Stone", ModeleId = idU, Value = 0.12M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ganganite Ingot", ModeleId = idR, Value = 0.36M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Gazzurdite Stone", ModeleId = idU, Value = 0.25M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Gazzurdite Ingot", ModeleId = idR, Value = 0.75M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Gold Stone", ModeleId = idU, Value = 1 }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Gold Ingot", ModeleId = idR, Value = 3M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hansidian Rock", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hansidian Ingot", ModeleId = idR, Value = 0.03M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Himi Rock", ModeleId = idU, Value = 0.142M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Himi Ingot", ModeleId = idR, Value = 0.426M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ignisium Stone", ModeleId = idU, Value = 0.7M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ignisium Ingot", ModeleId = idR, Value = 2.1M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Iolite Stone", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Iolite Ingot", ModeleId = idR, Value = 0.6M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Iron Stone", ModeleId = idU, Value = 0.13M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Iron Ingot", ModeleId = idR, Value = 0.39M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kanerium Ore", ModeleId = idU, Value = 2.5M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kanerium Ingot", ModeleId = idR, Value = 7.5M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kirtz Stone", ModeleId = idU, Value = 5.6M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kirtz Ingot", ModeleId = idR, Value = 16.8M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Langotz Ore", ModeleId = idU, Value = 0.9M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Langotz Ingot", ModeleId = idR, Value = 2.7M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lanorium Stone", ModeleId = idU, Value = 0.22M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lanorium Ingot", ModeleId = idR, Value = 0.66M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lysterium Stone", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lysterium Ingot", ModeleId = idR, Value = 0.03M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Maganite Ore", ModeleId = idU, Value = 1.05M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Maganite Ingot", ModeleId = idR, Value = 3.15M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Megan Stone", ModeleId = idU, Value = 0.18M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Megan Ingot", ModeleId = idR, Value = 0.54M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Morpheus Stone", ModeleId = idU, Value = 0.83M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Morpheus Ingot", ModeleId = idR, Value = 2.49M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Narcanisum Stone", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Narcanisum Ingot", ModeleId = idR, Value = 0.24M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Niksarium Stone", ModeleId = idU, Value = 0.65M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Niksarium Ingot", ModeleId = idR, Value = 1.95M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Petonium Stone", ModeleId = idU, Value = 1.79M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Petonium Ingot", ModeleId = idR, Value = 5.37M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Platinum Stone", ModeleId = idU, Value = 3 }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Platinum Ingot", ModeleId = idR, Value = 9M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Pyrite Stone", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Pyrite Ingot", ModeleId = idR, Value = 0.6M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Quantium Stone", ModeleId = idU, Value = 0.6M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Quantium Ingot", ModeleId = idR, Value = 1.8M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Redulite Ore", ModeleId = idU, Value = 2.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Redulite Ingot", ModeleId = idR, Value = 6.6M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Rugaritz Ore", ModeleId = idU, Value = 1.5M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Rugaritz Ingot", ModeleId = idR, Value = 4.5M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Terrudite Stone", ModeleId = idU, Value = 1.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Terrudite Ingot", ModeleId = idR, Value = 3.3M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Tridenite Ore", ModeleId = idU, Value = 2 }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Tridenite Ingot", ModeleId = idR, Value = 6M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Valurite Stone", ModeleId = idU, Value = 6 }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Valurite Ingot", ModeleId = idR, Value = 18M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Vesperdite Ore", ModeleId = idU, Value = 1.8M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Vesperdite Ingot", ModeleId = idR, Value = 5.4M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Xeremite Ore", ModeleId = idU, Value = 4 }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Xeremite Ingot", ModeleId = idR, Value = 12M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zanderium Ore", ModeleId = idU, Value = 2.5M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zanderium Ingot", ModeleId = idR, Value = 7.5M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zinc Stone", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zinc Ingot", ModeleId = idR, Value = 0.3M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Alternative Rock", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Alternative Ingot", ModeleId = idR, Value = 0.03M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Aqeeq Stone", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Aqeeq Ingot", ModeleId = idR, Value = 0.06M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Arekite Stone", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Arekite Ingot", ModeleId = idR, Value = 0.3M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Banite Stones", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Banite Ingot", ModeleId = idR, Value = 0.24M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Blues Rock", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Blues Ingot", ModeleId = idR, Value = 0.06M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Cordul Stone", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Cordul Ingot", ModeleId = idR, Value = 0.6M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Cyrenium Ore", ModeleId = idU, Value = 0.5M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Cyrenium Ingot", ModeleId = idR, Value = 1.5M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Dark Lysterium", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Dark Lysterium Bar", ModeleId = idR, Value = 0.06M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Fairuz Stone", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Fairuz Ingot", ModeleId = idR, Value = 0.15M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Folk Rock", ModeleId = idU, Value = 0.03M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Folk Ingot", ModeleId = idR, Value = 0.09M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Frakite Stone", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Frakite Ingot", ModeleId = idR, Value = 0.9M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Glam Rock", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Glam Ingot", ModeleId = idR, Value = 0.12M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Grunge Rock", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Grunge Ingot", ModeleId = idR, Value = 0.12M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hard Rock", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hard Ingot", ModeleId = idR, Value = 0.15M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hebredite Stones", ModeleId = idU, Value = 0.25M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hebredite Ingot", ModeleId = idR, Value = 0.75M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Iridium Ore", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Iridium Ingot", ModeleId = idR, Value = 0.15M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Jazz Rock", ModeleId = idU, Value = 0.06M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Jazz Ingot", ModeleId = idR, Value = 0.18M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kaisenite Stone", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kaisenite Ingot", ModeleId = idR, Value = 0.06M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kaz Stones", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Kaz Ingot", ModeleId = idR, Value = 0.12M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lidacon Stones", ModeleId = idU, Value = 1.5M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lidacon Ingot", ModeleId = idR, Value = 4.5M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lulu Stone", ModeleId = idU, Value = 0.12M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Lulu pearl", ModeleId = idR, Value = 0.36M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Maladrite Stone", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Maladrite Ingot", ModeleId = idR, Value = 0.12M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Maro Stone", ModeleId = idU, Value = 0.13M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Maro Ingot", ModeleId = idR, Value = 0.52M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Melatinum Stone", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Melatinum Ingot", ModeleId = idR, Value = 0.3M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Olerin Stone", ModeleId = idU, Value = 0.07M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Olerin Ingot", ModeleId = idR, Value = 0.21M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ospra Stones", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Ospra Ingot", ModeleId = idR, Value = 0.06M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Praetonium", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Praetonium Ingot", ModeleId = idR, Value = 0.04M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Punk Rock", ModeleId = idU, Value = 0.07M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Punk Ingot", ModeleId = idR, Value = 0.21M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Qasdeer Stone", ModeleId = idU, Value = 0.25M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Qasdeer Ingot", ModeleId = idR, Value = 0.75M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Reggea Rock", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Reggea Ingot", ModeleId = idR, Value = 0.24M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Sothorite Ore", ModeleId = idU, Value = 0.09M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Sothorite Ingot", ModeleId = idR, Value = 0.27M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Sunburst Stone", ModeleId = idU, Value = 0.11M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Sunburst Ingot", ModeleId = idR, Value = 0.77M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Tananite Ore", ModeleId = idU, Value = 0.15M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Leethiz Ingot", ModeleId = idR, Value = 0.45M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Techno Rock", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Techno Ingot", ModeleId = idR, Value = 0.3M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Telfium Stones", ModeleId = idU, Value = 0.14M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Telfium Ingot", ModeleId = idR, Value = 0.42M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Veda Stones", ModeleId = idU, Value = 0.06M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Veda Ingot", ModeleId = idR, Value = 0.18M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Wenrex Stones", ModeleId = idU, Value = 0.17M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Wenrex Ingot", ModeleId = idR, Value = 0.51M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Wiles Stone", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Wiley Ingot", ModeleId = idR, Value = 0.9M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Yulerium Stones", ModeleId = idU, Value = 0.5M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Yulerium Ingot", ModeleId = idR, Value = 1.5M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zircon Stone", ModeleId = idU, Value = 0.05M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zircon Ingot", ModeleId = idR, Value = 0.15M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zorn Star Ore", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zorn Star Ingot", ModeleId = idR, Value = 0.03M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zulax Stones", ModeleId = idU, Value = 0.65M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Zulax Ingot", ModeleId = idR, Value = 1.95M }),
                Quantity = 3
            });


            // Complexe ore
            // repositories.Materials.Add(new Material() { Nom = "Motorhead Keg", ModeleId = idU, Value = 0.01M })	
            // repositories.Materials.Add(new Material() { Nom = "Nosifer Stone", ModeleId = idU, Value = 0.08M })			
            // Complexe ingot
            //    repositories.Materials.Add(new Material() { Nom = "Aumorphite Ingot", ModeleId = idR, Value = 8.09M });
            //    repositories.Materials.Add(new Material() { Nom = "Chalinum Alloy", ModeleId = idR, Value = 2.601M });
            //    repositories.Materials.Add(new Material() { Nom = "Cobaltium Ingot", ModeleId = idR, Value = 2.001M });
            //    repositories.Materials.Add(new Material() { Nom = "Frigulerian Dust", ModeleId = idR, Value = 3.4405M });
            //    repositories.Materials.Add(new Material() { Nom = "Galaurphite Ingot", ModeleId = idR, Value = 14.7353M });
            //    repositories.Materials.Add(new Material() { Nom = "Galvesperdite Ingot", ModeleId = idR, Value = 6.3625M });
            //    repositories.Materials.Add(new Material() { Nom = "Lystionite Steel Ingot", ModeleId = idR, Value = 4.0146M });
            //    repositories.Materials.Add(new Material() { Nom = "Nosi Ingot", ModeleId = idR, Value = 0.24M });
            //    repositories.Materials.Add(new Material() { Nom = "Solares Ingot", ModeleId = idR, Value = 3.59M });
            //    repositories.Materials.Add(new Material() { Nom = "Yashib Ingot", ModeleId = idR, Value = 0.65M });
            //    repositories.Materials.Add(new Material() { Nom = "Ycy Ingot", ModeleId = idR, Value = 1.05M });

            repositories.Refinables.AddRange(list);
        }

        private void AddTreasures()
        {
            List<Refinable> list = new List<Refinable>();

            int idU = repositories.Modeles.GetByNom("Treasure").Id;
            int idR = repositories.Modeles.GetByNom("Refined Treasure").Id;
			
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Barrel", ModeleId = idU, Value = 18M });
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Bearings", ModeleId = idU, Value = 2M });
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Codex Chamber", ModeleId = idU, Value = 40M });
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Cog", ModeleId = idU, Value = 10M });
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Gears", ModeleId = idU, Value = 1M });
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Housing", ModeleId = idU, Value = 30M });
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Inner Ring", ModeleId = idU, Value = 20M });
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Interface", ModeleId = idU, Value = 12M });
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Outer Ring", ModeleId = idU, Value = 30M });
			repositories.Materials.Add(new Material() { Nom = "Arkadian Golden Key Power Source", ModeleId = idU, Value = 6M });
			
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Aakas Alloy", ModeleId = idU, Value = 0.1M }),
                 RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Aakas Plating", ModeleId = idR, Value = 0.3M }),
                 Quantity = 3});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Aarkan Pellets", ModeleId = idU, Value = 0.02M }),
                 RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Aarkan Polymer", ModeleId = idR, Value = 0.06M }),
                 Quantity = 3});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Alkar Crystals", ModeleId = idU, Value = 0.05M }),
                 RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Alkar Lattice", ModeleId = idR, Value = 0.15M }),
                 Quantity = 3});
            list.Add(new Refinable(){
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Bismuth Fragment", ModeleId = idU, Value = 0.2M }),
                 RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Bismuth Plating", ModeleId = idR, Value = 0.6M }),
                 Quantity = 3});
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "ChemSet", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Binding Epoxy", ModeleId = idR, Value = 0.9M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Diagen Firedrops", ModeleId = idU, Value = 0.04M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Diagen Matrix", ModeleId = idR, Value = 0.12M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hexra Gems", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Hexra Electroplate", ModeleId = idR, Value = 0.3M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Khorudoul Extrusion", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Khorudoul Polymer", ModeleId = idR, Value = 0.24M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Khorum Alloy", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Khorum Plating", ModeleId = idR, Value = 0.6M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Part Of Brass Alloy", ModeleId = idU, Value = 0.12M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Brass Alloy", ModeleId = idR, Value = 0.36M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Part Of Bronze Alloy", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Bronze Alloy", ModeleId = idR, Value = 0.3M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Part Of Flint Arrow Head", ModeleId = idU, Value = 0.08M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Flint Arrow Head", ModeleId = idR, Value = 0.24M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Part Of Flint Axe Head", ModeleId = idU, Value = 0.06M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Flint Axe Head", ModeleId = idR, Value = 0.18M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Part Of Fly Amber", ModeleId = idU, Value = 0.1M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Fly Amber", ModeleId = idR, Value = 0.3M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Part Of Fossil Ammonite", ModeleId = idU, Value = 0.02M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Fossil Ammonite", ModeleId = idR, Value = 0.06M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Part Of Fossil Tooth", ModeleId = idU, Value = 0.01M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Fossil Tooth", ModeleId = idR, Value = 0.03M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Part Of Mosquito Amber", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Mosquito Amber", ModeleId = idR, Value = 0.9M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Pirrel Pellets", ModeleId = idU, Value = 0.3M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Pirrel Hexaton", ModeleId = idR, Value = 0.9M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Quenta Flux", ModeleId = idU, Value = 0.15M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Quenta Panel", ModeleId = idR, Value = 0.45M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Regula Lode", ModeleId = idU, Value = 0.2M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Regula Powder", ModeleId = idR, Value = 0.6M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Songkra Alloy", ModeleId = idU, Value = 0.25M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Songkra Plating", ModeleId = idR, Value = 0.75M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Songtil Agent", ModeleId = idU, Value = 0.06M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Balancing Agent", ModeleId = idR, Value = 0.18M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Starrix Nodes", ModeleId = idU, Value = 0.25M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Starrix Quilting", ModeleId = idR, Value = 0.75M }),
                Quantity = 3
            });
            list.Add(new Refinable()
            {
                UnrefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Vedacore Fibre", ModeleId = idU, Value = 0.15M }),
                RefinedMaterial = repositories.Materials.Add(new Material() { Nom = "Vedacore Sheeting", ModeleId = idR, Value = 0.45M }),
                Quantity = 3
            });

            repositories.Refinables.AddRange(list);
        }
	
        private void AddPlanetMaterial()
        {
            throw new NotImplementedException();
        }

        private void AddSearchModes()
        {
            List<SearchMode> list = new List<SearchMode>();

            list.Add(new SearchMode() { Nom = "Ores", Abbrev = "O", Multiplicateur = 2 });
            list.Add(new SearchMode() { Nom = "Enmatters", Abbrev = "E", Multiplicateur = 1 });
            list.Add(new SearchMode() { Nom = "Treasures", Abbrev = "T", Multiplicateur = 3 });
            list.Add(new SearchMode() { Nom = "Ores, Enmatters", Abbrev = "OE", Multiplicateur = 3 });
            list.Add(new SearchMode() { Nom = "Ores, Treasures", Abbrev = "OT", Multiplicateur = 2.5M });
            list.Add(new SearchMode() { Nom = "Enmatters, Treasures", Abbrev = "ET", Multiplicateur = 2 });
            list.Add(new SearchMode() { Nom = "Ores, Enmatters, Treasures", Abbrev = "OET", Multiplicateur = 3 });

            repositories.SearchModes.AddRange(list);
        }
    }
}

