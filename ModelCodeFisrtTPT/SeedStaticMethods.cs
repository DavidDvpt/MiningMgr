using System;
using ModelCodeFisrtTPT.Dto;
using ModelCodeFisrtTPT.Repositories.Interfaces;

namespace ModelCodeFisrtTPT
{
    public static class SeedStaticMethods
    {
        public static void Seed(IRepositoriesUoW repositories)
        {
            AddCategories(repositories);
            //AddModeles(repositories);
            //AddToolAccessoire(repositories);
            //AddPlanets(repositories);
            //AddFinders(repositories);
            //AddExcavators(repositories);
            //AddRefiners(repositories);
            //AddFinderAmplifiers(repositories);
            //AddEnhancers(repositories);
            //AddMaterials(repositories);
        }

        private static void AddCategories(IRepositoriesUoW repositories)
        {
            repositories.Categories.Add(new Categorie() { Nom = "Tool" });
            repositories.Categories.Add(new Categorie() { Nom = "Accessoire" });
            repositories.Categories.Add(new Categorie() { Nom = "Material" });
        }

        private static void AddModeles(IRepositoriesUoW repositories)
        {
            int id = repositories.Categories.GetByNom("Tool").Id;
            repositories.Modeles.Add(new Modele() { Nom = "Finder", IsStackable = false, CategorieId = id });
            repositories.Modeles.Add(new Modele() { Nom = "Excavator", IsStackable = false, Categorie = id });
            repositories.Modeles.Add(new Modele() { Nom = "Refiner", IsStackable = false, Categorie = id });

            id = repositories.Categories.GetByNom("Accessoire").Id;
            repositories.Modeles.Add(new Modele() { Nom = "Finder Amplifier", IsStackable = false, Categorie = id });
            repositories.Modeles.Add(new Modele() { Nom = "Finder Depth Enhancer", IsStackable = true, Categorie = id });
            repositories.Modeles.Add(new Modele() { Nom = "Finder Range Enhancer", IsStackable = true, Categorie = id });
            repositories.Modeles.Add(new Modele() { Nom = "Finder Skill Enhancer", IsStackable = true, Categorie = id });
            repositories.Modeles.Add(new Modele() { Nom = "Excavator Speed Enhancer", IsStackable = true, Categorie = id });

            id = repositories.Categories.GetByNom("Material").Id;
            repositories.Modeles.Add(new Modele() { Nom = "Enmatter", IsStackable = true, Categorie = id });
            repositories.Modeles.Add(new Modele() { Nom = "Treasure", IsStackable = true, Categorie = id });
            repositories.Modeles.Add(new Modele() { Nom = "Refined Ore", IsStackable = true, Categorie = id });
            repositories.Modeles.Add(new Modele() { Nom = "Refined Enmatter", IsStackable = true, Categorie = id });
            repositories.Modeles.Add(new Modele() { Nom = "Refined Treasure", IsStackable = true, Categorie = id });
        }

        private static void AddToolAccessoire(IRepositoriesUoW repositories)
        {
            int tId = repositories.Modeles.GetByNom("Finder").Id;
            repositories.ToolAccessoires.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("FinderAmplifier").Id });
            repositories.ToolAccessoires.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Depth Enhancer").Id });
            repositories.ToolAccessoires.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Range Enhancer").Id });
            repositories.ToolAccessoires.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Finder Skill Enhancer").Id });

            tId = repositories.Modeles.GetByNom("Excavator").Id;
            repositories.ToolAccessoires.Add(new ToolAccessoire() { ToolId = tId, AccessoireId = repositories.Modeles.GetByNom("Excavator Speed Enhancer").Id });
        }

        private static void AddPlanets(IRepositoriesUoW repositories)
        {
            repositories.Planets.Add(new Planet() { Nom = "Calypso" };
            repositories.Planets.Add(new Planet() { Nom = "Arkadia" };
            repositories.Planets.Add(new Planet() { Nom = "F.O.M.A." };
            repositories.Planets.Add(new Planet() { Nom = "Toulan" };
            repositories.Planets.Add(new Planet() { Nom = "Rocktropia" };
        }

        private static void AddFinders(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Finder").Id;
            repositories.Finders.Add(new Finder() { Nom = "A.R.C. Finder 0001 (L)",                             , IsLimited = true, ModeleId = Id, Value = 0.1, Decay = 0.25, Range = 54, Depth = 204, UsePerMin = 9, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "CDF Finder z10 (L)",                                     , IsLimited = true, ModeleId = Id, Value = 1, Decay = 0, Range = 54, Depth = 223.9, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "CDF Finder z25 (L)",                                     , IsLimited = true, ModeleId = Id, Value = 2, Decay = 0.56, Range = 54.2, Depth = 422.9, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "CDF Finder z40 (L)",         ,                           , IsLimited = true, ModeleId = Id, Value = 4, Decay = 0, Range = 54.6, Depth = 741.3, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Demonic Detector MK-I (L)",                      , IsLimited = true, ModeleId = Id, Value = 4.75, Decay = 0.5, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "DSEC Seeker L2 (L)",                                     , IsLimited = true, ModeleId = Id, Value = 18.6, Decay = 0, Range = 55, Depth = 213.9, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "DSEC Seeker L12 (L)",                                    , IsLimited = true, ModeleId = Id, Value = 49, Decay = 2.29, Range = 55, Depth = 462.7, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "DSEC Seeker L30 (L)",                                    , IsLimited = true, ModeleId = Id, Value = 136, Decay = 3.96, Range = 55, Depth = 820.9, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "eMINE FS (L)",                                               , IsLimited = true, ModeleId = Id, Value = 122, Decay = 1.743, Range = 54, Depth = 676.6, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-101",                                               , IsLimited = false, ModeleId = Id, Value = 5.5, Decay = 1, Range = 54, Depth = 263.7, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-102",                                               , IsLimited = false, ModeleId = Id, Value = 30, Decay = 1.15, Range = 54, Depth = 323.4, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-103",                                               , IsLimited = false, ModeleId = Id, Value = 55, Decay = 1.45, Range = 54.5, Depth = 363.2, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-104",                                               , IsLimited = false, ModeleId = Id, Value = 66.6, Decay = 1.63, Range = 54.5, Depth = 432.9, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-105",                                               , IsLimited = false, ModeleId = Id, Value = 82, Decay = 2.05, Range = 55, Depth = 522.4, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-105 TEN Edition",                           , IsLimited = false, ModeleId = Id, Value = 82, Decay = 2, Range = 55, Depth = 552.3, UsePerMin = 9, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-106",                                               , IsLimited = false, ModeleId = Id, Value = 79.95, Decay = 1.799, Range = 55, Depth = 582.1, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-210 (L)",                                           , IsLimited = true, ModeleId = Id, Value = 105, Decay = 1.25, Range = 54, Depth = 383.1, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-211 (L)",                                           , IsLimited = true, ModeleId = Id, Value = 121.2, Decay = 1.306, Range = 55, Depth = 472.6, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-212 (L)",                                           , IsLimited = true, ModeleId = Id, Value = 155.2, Decay = 1.343, Range = 55, Depth = 592, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-212, SGA Edition (L)",                  , IsLimited = true, ModeleId = Id, Value = 155.2, Decay = 0, Range = 55, Depth = 612, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-213 (L)",           ,                               , IsLimited = true, ModeleId = Id, Value = 201.2, Decay = 1.66, Range = 54.5, Depth = 631.8, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-213 (L) Adapted",                           , IsLimited = true, ModeleId = Id, Value = 678, Decay = 2.33, Range = 54, Depth = 811, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-213 (L) Customized",                    , IsLimited = true, ModeleId = Id, Value = 2678, Decay = 2.68, Range = 55, Depth = 850.8, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Finder F-214 (L)",           ,                               , IsLimited = true, ModeleId = Id, Value = 231.2, Decay = 0, Range = 54, Depth = 651.8, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Genesis Rookie Finder (L)",                      , IsLimited = true, ModeleId = Id, Value = 0.06, Decay = 0.239, Range = 54, Depth = 104.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Genesis Star Rookie Finder (L)",             , IsLimited = true, ModeleId = Id, Value = 0.1, Decay = 0, Range = 54, Depth = 104.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Imperium Detectonator X2 (L)",               , IsLimited = true, ModeleId = Id, Value = 170, Decay = 7, Range = 54, Depth = 626.9, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Imperium Trainee Finder (L)",                    , IsLimited = true, ModeleId = Id, Value = 0.1, Decay = 0.52, Range = 54, Depth = 204, UsePerMin = 9, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Island Ziplex Z1 Seeker",                            , IsLimited = false, ModeleId = Id, Value = 2.4, Decay = 0.751, Range = 55, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Lost Soul Seeker (L)",           ,                       , IsLimited = true, ModeleId = Id, Value = 48, Decay = 3.7, Range = 54.8, Depth = 721, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "NI Finder New Settler Issue (L)",                , IsLimited = true, ModeleId = Id, Value = 1, Decay = 0, Range = 54, Depth = 104.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Omegaton Detectonator MD-1 (L)",         , IsLimited = true, ModeleId = Id, Value = 0.1, Decay = 0.239, Range = 54, Depth = 104.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Sabad Finder M1 (L)",                                    , IsLimited = true, ModeleId = Id, Value = 2, Decay = 0.751, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Sabad Finder M2 (L)",                                    , IsLimited = true, ModeleId = Id, Value = 26, Decay = 0, Range = 55, Depth = 303.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Sabad Finder M3 (L)",                                    , IsLimited = true, ModeleId = Id, Value = 0, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Sabad Finder M4 (L)",                                    , IsLimited = true, ModeleId = Id, Value = 78, Decay = 0, Range = 55, Depth = 477.6, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Sabad Finder M5 (L)",                                    , IsLimited = true, ModeleId = Id, Value = 0, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 1 (L)",                                      , IsLimited = true, ModeleId = Id, Value = 2.5, Decay = 1.5, Range = 55, Depth = 206, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 2 (L)",                                      , IsLimited = true, ModeleId = Id, Value = 55, Decay = 2.2, Range = 55, Depth = 408, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 3 (L)",                                      , IsLimited = true, ModeleId = Id, Value = 95, Decay = 3.225, Range = 55, Depth = 631.8, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 3 Gold Rush",                        , IsLimited = false, ModeleId = Id, Value = 95, Decay = 3.225, Range = 55, Depth = 631.8, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 4 (L)",                                      , IsLimited = true, ModeleId = Id, Value = 150, Decay = 3.72, Range = 55, Depth = 741.3, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 5 (L)",                                      , IsLimited = true, ModeleId = Id, Value = 205, Decay = 4.125, Range = 55, Depth = 830.8, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 6 (L)",                                      , IsLimited = true, ModeleId = Id, Value = 260, Decay = 4.372, Range = 55, Depth = 885.6, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 7 (L)",                                      , IsLimited = true, ModeleId = Id, Value = 320, Decay = 4.552, Range = 55, Depth = 925.4, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 8 (L)",                                      , IsLimited = true, ModeleId = Id, Value = 390, Decay = 4.89, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster 8 Gold Rush",                        , IsLimited = false, ModeleId = Id, Value = 390, Decay = 0, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster Trainer (L)",                            , IsLimited = true, ModeleId = Id, Value = 0.4, Decay = 0.75, Range = 55, Depth = 104.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "TerraMaster TT (L)",                                     , IsLimited = true, ModeleId = Id, Value = 0.1, Decay = 0.239, Range = 54, Depth = 104.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A10 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 50, Decay = 1.5, Range = 54, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A13 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 51, Decay = 0, Range = 54, Depth = 223.9, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A16 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 52, Decay = 0, Range = 54, Depth = 253.8, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A19 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 53, Decay = 1.8, Range = 55, Depth = 303.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A22 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 54, Decay = 1.9, Range = 55, Depth = 403, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A25 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 55, Decay = 2, Range = 55.1, Depth = 502.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A28 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 56, Decay = 0, Range = 55.2, Depth = 602, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A31 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 57, Decay = 0, Range = 55.2, Depth = 701.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A33 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 58, Decay = 0, Range = 55.2, Depth = 801, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex A35 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 59, Decay = 0, Range = 55.2, Depth = 900.5, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex B35 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 50, Decay = 3, Range = 55, Depth = 502.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex B40 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 51, Decay = 0, Range = 55.1, Depth = 522.4, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex B50 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 52, Decay = 3.2, Range = 55.2, Depth = 542.3, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex B60 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 53, Decay = 0, Range = 55.2, Depth = 562.2, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex B70 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 54, Decay = 3, Range = 55.2, Depth = 582.1, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex C50 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 40, Decay = 0, Range = 55.2, Depth = 283.6, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex C65 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 44, Decay = 1.2, Range = 55.2, Depth = 313.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex C70 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 46, Decay = 1.2, Range = 55.2, Depth = 363.2, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex D33 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 44, Decay = 3.6, Range = 54, Depth = 801, UsePerMin = 8       BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex D44 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 46, Decay = 3.2, Range = 54, Depth = 900.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex D52 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 55, Decay = 3, Range = 54.5, Depth = 990, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex P20 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 10, Decay = 0, Range = 55.2, Depth = 701.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex P30 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 10, Decay = 0.16, Range = 55.2, Depth = 701.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex P50 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 10, Decay = 0, Range = 55.2, Depth = 701.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex P85 (L)",                                             , IsLimited = true, ModeleId = Id, Value = 10, Decay = 0, Range = 55.2, Depth = 701.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex P160 (L)",                                            , IsLimited = true, ModeleId = Id, Value = 10, Decay = 0.7, Range = 55.2, Depth = 701.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex TK120 Seeker (L)",                            , IsLimited = true, ModeleId = Id, Value = 218.6, Decay = 1.803, Range = 55, Depth = 701.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex TK220 Seeker (L)",                            , IsLimited = true, ModeleId = Id, Value = 264.8, Decay = 3.96, Range = 55, Depth = 776.1, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex TK320 Seeker (L)",                            , IsLimited = true, ModeleId = Id, Value = 311, Decay = 4.303, Range = 55, Depth = 850.8, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex TK320 Seeker, SGA Edition (L)",       , IsLimited = true, ModeleId = Id, Value = 233.25, Decay = 0, Range = 55, Depth = 870.7, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex VRX2000 Seeker (L)",                      , IsLimited = true, ModeleId = Id, Value = 339, Decay = 4.651, Range = 55, Depth = 925.4, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex VRX3000 Seeker (L)",                      , IsLimited = true, ModeleId = Id, Value = 387, Decay = 5.01, Range = 55, Depth = 1000, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex Z1 Seeker",                                           , IsLimited = false, ModeleId = Id, Value = 2.4, Decay = 1.501, Range = 55, Depth = 204, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex Z5 Seeker (L)",                                   , IsLimited = true, ModeleId = Id, Value = 29.8, Decay = 1.855, Range = 55, Depth = 303.5, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex Z10 Seeker (L)",                                  , IsLimited = true, ModeleId = Id, Value = 55, Decay = 2.209, Range = 55, Depth = 403, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex Z10 Seeker, SGA Edition (L)",         , IsLimited = true, ModeleId = Id, Value = 55, Decay = 0, Range = 0, Depth = 0, UsePerMin = 0, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex Z15 Seeker (L)",                                  , IsLimited = true, ModeleId = Id, Value = 80, Decay = 2.557, Range = 55, Depth = 477.6, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex Z20 Seeker (L)",                                  , IsLimited = true, ModeleId = Id, Value = 126.2, Decay = 1.452, Range = 55, Depth = 552.3, UsePerMin = 8, BasePecSearch = 50 });
            repositories.Finders.Add(new Finder() { Nom = "Ziplex Z25 Seeker (L)",                                  , IsLimited = true, ModeleId = Id, Value = 172.4, Decay = 3.251, Range = 55, Depth = 626.9, UsePerMin = 8, BasePecSearch = 50 });
        }

        private static void AddExcavators(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Excavator").Id;
            repositories.Excavators.Add(new Excavator() { Nom = "ARD Excavator A-100 (L)", ModeleId = id, IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "ARD Excavator Beginner (L)", ModeleId = id, IsLimited = true, Value = 0.5, Decay = 0, Efficienty = 1.2, UsePerMin = 17 });
            repositories.Excavators.Add(new Excavator() { Nom = "ARD Excavator M1 (L)", ModeleId = id, IsLimited = true, Value = 2.4, Decay = 0.3, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "ARD Excavator M2 (L)", ModeleId = id, IsLimited = true, Value = 54, Decay = 0, Efficienty = 9.2, UsePerMin = 24 });
            repositories.Excavators.Add(new Excavator() { Nom = "ARD Excavator M3 (L)", ModeleId = id, IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            repositories.Excavators.Add(new Excavator() { Nom = "ARD Excavator M4 (L)", ModeleId = id, IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            repositories.Excavators.Add(new Excavator() { Nom = "ARD Excavator M5 (L)", ModeleId = id, IsLimited = true, Value = 132, Decay = 2.336, Efficienty = 12.8, UsePerMin = 26 });
            repositories.Excavators.Add(new Excavator() { Nom = "Demonic Excavator MK-I (L)", ModeleId = id, IsLimited = true, Value = 5, Decay = 0.1, Efficienty = 0.6, UsePerMin = 17 });
            repositories.Excavators.Add(new Excavator() { Nom = "Earth Excavator ME/01", ModeleId = id, IsLimited = false, Value = 2.4, Decay = 0.3, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "eMINE E (L)", ModeleId = id, IsLimited = true, Value = 85, Decay = 2.101, Efficienty = 12, UsePerMin = 27 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Rookie Extractor (L)", ModeleId = id, IsLimited = true, Value = 0.01, Decay = 0, Efficienty = 1.2, UsePerMin = 17 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Basic Excavator (L)", ModeleId = id, IsLimited = true, Value = 3, Decay = 0.3, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/02", ModeleId = id, IsLimited = false, Value = 8, Decay = 0.5, Efficienty = 7.2, UsePerMin = 22 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/03", ModeleId = id, IsLimited = false, Value = 41, Decay = 0.75, Efficienty = 7.2, UsePerMin = 22 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/04", ModeleId = id, IsLimited = false, Value = 55, Decay = 0.85, Efficienty = 8, UsePerMin = 23 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/05", ModeleId = id, IsLimited = false, Value = 66, Decay = 1, Efficienty = 8.8, UsePerMin = 23 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Earth Excavator ME/05, SGA Edition", ModeleId = id, IsLimited = false, Value = 66, Decay = 0.8, Efficienty = 8.8, UsePerMin = 33 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Excavator Adjusted", ModeleId = id, IsLimited = false, Value = 18, Decay = 0.5, Efficienty = 12.8, UsePerMin = 23 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Excavator Improved", ModeleId = id, IsLimited = false, Value = 27, Decay = 0.5, Efficienty = 15.2, UsePerMin = 24 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Excavator Modified", ModeleId = id, IsLimited = false, Value = 4362, Decay = 3.212, Efficienty = 20.8, UsePerMin = 27 });
            repositories.Excavators.Add(new Excavator() { Nom = "Genesis Star Rookie Extractor (L)", ModeleId = id, IsLimited = true, Value = 0.1, Decay = 0, Efficienty = 1.2, UsePerMin = 17 });
            repositories.Excavators.Add(new Excavator() { Nom = "Imperium Extirpater v1", ModeleId = id, IsLimited = false, Value = 2.2, Decay = 0.34, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "Initiate''s Excavator (L)", ModeleId = id, IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "Island Earth Excavator ME/01", ModeleId = id, IsLimited = false, Value = 2.4, Decay = 0.3, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "Lost Soul Savior (L)", ModeleId = id, IsLimited = true, Value = 64, Decay = 0, Efficienty = 19.2, UsePerMin = 26 });
            repositories.Excavators.Add(new Excavator() { Nom = "NI Basic Excavator (L)", ModeleId = id, IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "NI Extractor  New Settler Issue  (L)", ModeleId = id, IsLimited = true, Value = 0.1, Decay = 0, Efficienty = 1.2, UsePerMin = 24 });
            repositories.Excavators.Add(new Excavator() { Nom = "Punk Digger (L)", ModeleId = id, IsLimited = true, Value = 3, Decay = 0, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-101", ModeleId = id, IsLimited = false, Value = 4, Decay = 0.6, Efficienty = 7.2, UsePerMin = 20 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-102", ModeleId = id, IsLimited = false, Value = 12.6, Decay = 1., Efficienty = 8, UsePerMin = 22 }); --A VERIFIER POUR LE 1.
repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-103", ModeleId = id, IsLimited = false, Value = 50, Decay = 1.5, Efficienty = 8.4, UsePerMin = 23 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-104", ModeleId = id, IsLimited = false, Value = 65, Decay = 1.73, Efficienty = 9.6, UsePerMin = 24 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-105", ModeleId = id, IsLimited = false, Value = 80, Decay = 2.22, Efficienty = 10.8, UsePerMin = 26 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-201 (L)", ModeleId = id, IsLimited = true, Value = 89, Decay = 1.29, Efficienty = 9.2, UsePerMin = 25 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-202 (L)", ModeleId = id, IsLimited = true, Value = 110, Decay = 1.6, Efficienty = 10.4, UsePerMin = 25 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-203 (L)", ModeleId = id, IsLimited = true, Value = 185, Decay = 2.06, Efficienty = 11.6, UsePerMin = 25 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-204 (L)", ModeleId = id, IsLimited = true, Value = 195, Decay = 2.331, Efficienty = 12.8, UsePerMin = 26 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-204 Adapted (L)", ModeleId = id, IsLimited = true, Value = 195, Decay = 2.331, Efficienty = 12.8, UsePerMin = 34 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-205 (L)", ModeleId = id, IsLimited = true, Value = 83, Decay = 2.5, Efficienty = 14, UsePerMin = 24 });
            repositories.Excavators.Add(new Excavator() { Nom = "Resource Extractor RE-301 (L)", ModeleId = id, IsLimited = true, Value = 83, Decay = 2.503, Efficienty = 14, UsePerMin = 24 });
            repositories.Excavators.Add(new Excavator() { Nom = "Rock Ripper 1 (L)", ModeleId = id, IsLimited = true, Value = 2, Decay = 0.28, Efficienty = 6.6, UsePerMin = 22 });
            repositories.Excavators.Add(new Excavator() { Nom = "Rock Ripper 2 (L)", ModeleId = id, IsLimited = true, Value = 22, Decay = 1.129, Efficienty = 7.7, UsePerMin = 24 });
            repositories.Excavators.Add(new Excavator() { Nom = "Rock Ripper 3 (L)", ModeleId = id, IsLimited = true, Value = 44, Decay = 1.454, Efficienty = 8.8, UsePerMin = 24 });
            repositories.Excavators.Add(new Excavator() { Nom = "Rock Ripper 3 Gold Rush", ModeleId = id, IsLimited = false, Value = 44, Decay = 0.833, Efficienty = 8.5, UsePerMin = 29 });
            repositories.Excavators.Add(new Excavator() { Nom = "Rock Ripper 4 (L)", ModeleId = id, IsLimited = true, Value = 0, Decay = 0, Efficienty = 0, UsePerMin = 0 });
            repositories.Excavators.Add(new Excavator() { Nom = "Rock Ripper Trainer (L)", ModeleId = id, IsLimited = true, Value = 0.2, Decay = 0.274, Efficienty = 6, UsePerMin = 17 });
            repositories.Excavators.Add(new Excavator() { Nom = "Rock Ripper TT (L)", ModeleId = id, IsLimited = true, Value = 3, Decay = 0.3, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "Rookie Rock Ripper", ModeleId = id, IsLimited = false, Value = 1, Decay = 0.274, Efficienty = 6, UsePerMin = 17 });
            repositories.Excavators.Add(new Excavator() { Nom = "Training Mineral Extractor (L)", ModeleId = id, IsLimited = true, Value = 0.1, Decay = 0, Efficienty = 6.8, UsePerMin = 19 });
            repositories.Excavators.Add(new Excavator() { Nom = "Xtreme Excavator MK-I (L)", ModeleId = id, IsLimited = true, Value = 5, Decay = 0, Efficienty = 7.6, UsePerMin = 17 });
        }

        private static void AddRefiners(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Refiner").Id;
            repositories.Refiners.Add(new Refiner() { Nom = "Chikara Refiner Adjusted", IsLimited = false, Value = 24, Decay = 0.015, UsePerMin = 22 });
            repositories.Refiners.Add(new Refiner() { Nom = "Chikara Refiner Modified", IsLimited = false, Value = 41, Decay = .013, UsePerMin = 25 });
            repositories.Refiners.Add(new Refiner() { Nom = "Chikara Refiner MR200", IsLimited = false, Value = 16, Decay = 0.023, UsePerMin = 20 });
            repositories.Refiners.Add(new Refiner() { Nom = "Chikara Refiner MR300", IsLimited = false, Value = 35, Decay = 0.022, UsePerMin = 21 });
            repositories.Refiners.Add(new Refiner() { Nom = "Chikara Refiner MR400", IsLimited = false, Value = 48, Decay = 0.02, UsePerMin = 30 });
            repositories.Refiners.Add(new Refiner() { Nom = "Demonic Refiner MK-I (L)", IsLimited = false, Value = 2, Decay = 0.03, UsePerMin = 0 });
            repositories.Refiners.Add(new Refiner() { Nom = "Genesis Rookie OreRefiner (L)", IsLimited = false, Value = 0.01, Decay = 0.11, UsePerMin = 0 });
            repositories.Refiners.Add(new Refiner() { Nom = "Genesis Star Basic Refiner", IsLimited = false, Value = 2, Decay = 0.031, UsePerMin = 20 });
            repositories.Refiners.Add(new Refiner() { Nom = "Imperium Resource Refiner 1A", IsLimited = false, Value = 3, Decay = 0.03, UsePerMin = 0 });
            repositories.Refiners.Add(new Refiner() { Nom = "Imperium Resource Refiner B1", IsLimited = false, Value = 6, Decay = 0.022, UsePerMin = 21 });
            repositories.Refiners.Add(new Refiner() { Nom = "Initiate's Refiner", IsLimited = false, Value = 2, Decay = 0.031, UsePerMin = 0 });
            repositories.Refiners.Add(new Refiner() { Nom = "NI Basic Refiner", IsLimited = false, Value = 2, Decay = 0.031, UsePerMin = 0 });
            repositories.Refiners.Add(new Refiner() { Nom = "NI Refiner New Settler Issue", IsLimited = false, Value = 1, Decay = 0, UsePerMin = 20 });
            repositories.Refiners.Add(new Refiner() { Nom = "PTech Refiner 1", IsLimited = false, Value = 2, Decay = 0.03, UsePerMin = 0 });
            repositories.Refiners.Add(new Refiner() { Nom = "PTech Refiner TT", IsLimited = false, Value = 2, Decay = 0.031, UsePerMin = 0 });
            repositories.Refiners.Add(new Refiner() { Nom = "Punk Blender", IsLimited = false, Value = 2, Decay = 0.031, UsePerMin = 0 });
            repositories.Refiners.Add(new Refiner() { Nom = "Refiner MR100", IsLimited = false, Value = 2, Decay = 0.031, UsePerMin = 20 });
            repositories.Refiners.Add(new Refiner() { Nom = "Transformer T-101", IsLimited = false, Value = 8, Decay = 0.03, UsePerMin = 20 });
            repositories.Refiners.Add(new Refiner() { Nom = "Transformer T-102", IsLimited = false, Value = 22.75, Decay = 0.028, UsePerMin = 21 });
            repositories.Refiners.Add(new Refiner() { Nom = "Transformer T-103", IsLimited = false, Value = 45.5, Decay = 0.026, UsePerMin = 22 });
            repositories.Refiners.Add(new Refiner() { Nom = "Transformer T-104", IsLimited = false, Value = 55.3, Decay = 0.023, UsePerMin = 34 });
            repositories.Refiners.Add(new Refiner() { Nom = "Transformer T-105", IsLimited = false, Value = 75, Decay = 0.021, UsePerMin = 36 });

        }

        private static void AddFinderAmplifiers(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("FinderAmplifier").Id;
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Cheeky Finder Amp (L)", IsLimited = true, 50, Decay = 50, Coefficient = 2.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "D-Class Mining Amp (L)", IsLimited = true, 160, Decay = 400, Coefficient = 20 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "DSEC Seeker Amplifier II (L)", IsLimited = true, 125, Decay = 133, Coefficient = 6.7 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "DSEC Seeker Amplifier III (L)", IsLimited = true, 268, Decay = 285, Coefficient = 14.3 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "eMINE Amplifier I (L)", IsLimited = true, 105, Decay = 75, Coefficient = 3.8 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "eMINE Amplifier II (L)", IsLimited = true, 105, Decay = 150, Coefficient = 7.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 1 Finder Amplifier", IsLimited = false, 78, Decay = 25, Coefficient = 1.3 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 1 Finder Amplifier (L)", IsLimited = true, 78, Decay = 25, Coefficient = 1.3 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 1 Finder Amplifier Light (L)", IsLimited = true, 30, Decay = 25, Coefficient = 1.3 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 2 Finder Amplifier", IsLimited = false, 78, Decay = 50, Coefficient = 2.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 2 Finder Amplifier (L)", IsLimited = true, 100, Decay = 50, Coefficient = 2.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 2 Finder Amplifier, SGA Edition", IsLimited = false, 78, Decay = 50, Coefficient = 2.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 2 Finder Amplifier Light (L)", IsLimited = true, 50, Decay = 50, Coefficient = 2.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 3 Finder Amplifier", IsLimited = false, 100, Decay = 100, Coefficient = 5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 3 Finder Amplifier (L)", IsLimited = true, 114, Decay = 100, Coefficient = 5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 3 Finder Amplifier, SGA Edition", IsLimited = false, 114, Decay = 100, Coefficient = 5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 3 Finder Amplifier Light (L)", IsLimited = true, 75, Decay = 100, Coefficient = 5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 4 Finder Amplifier (L)", IsLimited = true, 150, Decay = 150, Coefficient = 7.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 5 Finder Amplifier", IsLimited = false, 113, Decay = 200, Coefficient = 10 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 5 Finder Amplifier (L)", IsLimited = true, 200, Decay = 200, Coefficient = 10 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 6 Finder Amplifier (L)", IsLimited = true, 250, Decay = 250, Coefficient = 12.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 7 Finder Amplifier", IsLimited = false, 120, Decay = 300, Coefficient = 15 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 7 Finder Amplifier (L)", IsLimited = true, 120, Decay = 300, Coefficient = 15 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 8 Finder Amplifier", IsLimited = false, 160, Decay = 400, Coefficient = 20 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 8 Finder Amplifier (L)", IsLimited = true, 160, Decay = 400, Coefficient = 20 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 9 Finder Amplifier (L)", IsLimited = true, 260, Decay = 500, Coefficient = 25 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 10 Finder Amplifier (L)", IsLimited = true, 300, Decay = 750, Coefficient = 37.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 11 Finder Amplifier (L)", IsLimited = true, 350, Decay = 1000, Coefficient = 50 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 12 Finder Amplifier (L)", IsLimited = true, 255, Decay = 1500, Coefficient = 75 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level 13 Finder Amplifier (L)", IsLimited = true, 340, Decay = 2000, Coefficient = 100 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level I Finder Amplifier 'Achilles' (L)", IsLimited = true, 89, Decay = 25, Coefficient = 1.3 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level II Finder Amplifier 'Achilles' (L)", IsLimited = true, 115, Decay = 50, Coefficient = 2.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level II Finder Amplifier 'Athena' (L)", IsLimited = true, 82, Decay = 60, Coefficient = 3 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level III Finder Amplifier 'Achilles' (L)", IsLimited = true, 131, Decay = 100, Coefficient = 5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level III Finder Amplifier 'Athena' (L)", IsLimited = true, 102, Decay = 80, Coefficient = 4 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level V Finder Amplifier 'Athena' (L)", IsLimited = true, 178, Decay = 220, Coefficient = 11 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level VII Finder Amplifier 'Athena' (L)", IsLimited = true, 198, Decay = 320, Coefficient = 16 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Level VIII Finder Amplifier 'Athena' (L)", IsLimited = true, 208, Decay = 380, Coefficient = 19 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 1 (L)", IsLimited = true, 45, Decay = 80, Coefficient = 4 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 1 Gold Rush", IsLimited = false, 45, Decay = 80, Coefficient = 4 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 2 (L)", IsLimited = true, 195, Decay = 160, Coefficient = 8 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 3 (L)", IsLimited = true, 300, Decay = 250, Coefficient = 12.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 4 (L)", IsLimited = true, 315, Decay = 350, Coefficient = 17.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 5 (L)", IsLimited = true, 325, Decay = 450, Coefficient = 22.5 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 6 (L)", IsLimited = true, 338, Decay = 600, Coefficient = 30 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 7 (L)", IsLimited = true, 360, Decay = 900, Coefficient = 45 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 8 (L)", IsLimited = true, 385, Decay = 1200, Coefficient = 60 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 9 (L)", IsLimited = true, 400, Decay = 1600, Coefficient = 80 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp 10 (L)", IsLimited = true, 442, Decay = 2000, Coefficient = 100 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp I 'Athena' (L)", IsLimited = true, 64, Decay = 40, Coefficient = 2 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp IV 'Athena' (L)", IsLimited = true, 134, Decay = 120, Coefficient = 6 });
            repositories.Refiners.Add(new FinderAmplifier() { Nom = "Terra Amp VI 'Athena' (L)", IsLimited = true, 188, Decay = 260, Coefficient = 13 });
        }

        private static void AddEnhancers(IRepositoriesUoW repositories)
        {
            int id = repositories.Modeles.GetByNom("Finder Depth Enhancer").Id;
            CALL sp_EnhancerCreate('Mining Finder Depth Enhancer I', 			ModeleId = id,    	Slot = 1, 	BonusBalue1 = 7.43, 	BonusValue2 = 0, 	Value = 0.8 });
			CALL sp_EnhancerCreate('Mining Finder Depth Enhancer II', ModeleId = id, Slot = 2, BonusBalue1 = 7.43, BonusValue2 = 0, Value = 0.8 });
			CALL sp_EnhancerCreate('Mining Finder Depth Enhancer III', ModeleId = id, Slot = 3, BonusBalue1 = 7.43, BonusValue2 = 0, Value = 0.8 });
			CALL sp_EnhancerCreate('Mining Finder Depth Enhancer IV', ModeleId = id, Slot = 4, BonusBalue1 = 7.43, BonusValue2 = 0, Value = 0.8 });
			CALL sp_EnhancerCreate('Mining Finder Depth Enhancer IX', ModeleId = id, Slot = 9, BonusBalue1 = 7.43, BonusValue2 = 0, Value = 0.8 });
			CALL sp_EnhancerCreate('Mining Finder Depth Enhancer V', ModeleId = id, Slot = 5, BonusBalue1 = 7.43, BonusValue2 = 0, Value = 0.8 });
			CALL sp_EnhancerCreate('Mining Finder Depth Enhancer VI', ModeleId = id, Slot = 6, BonusBalue1 = 7.43, BonusValue2 = 0, Value = 0.8 });
			CALL sp_EnhancerCreate('Mining Finder Depth Enhancer VII', ModeleId = id, Slot = 7, BonusBalue1 = 7.43, BonusValue2 = 0, Value = 0.8 });
			CALL sp_EnhancerCreate('Mining Finder Depth Enhancer VIII', ModeleId = id, Slot = 8, BonusBalue1 = 7.43, BonusValue2 = 0, Value = 0.8 });
			CALL sp_EnhancerCreate('Mining Finder Depth Enhancer X', ModeleId = id, Slot = 10, BonusBalue1 = 7.43, BonusValue2 = 0, Value = 0.8 });
			
			int id = repositories.Modeles.GetByNom("Finder Range Enhancer").Id;
CALL sp_EnhancerCreate('Mining Finder Range Enhancer I', ModeleId = id, Slot = 1, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			CALL sp_EnhancerCreate('Mining Finder Range Enhancer II', ModeleId = id, Slot = 2, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			CALL sp_EnhancerCreate('Mining Finder Range Enhancer III', ModeleId = id, Slot = 3, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			CALL sp_EnhancerCreate('Mining Finder Range Enhancer IV', ModeleId = id, Slot = 4, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			CALL sp_EnhancerCreate('Mining Finder Range Enhancer IX', ModeleId = id, Slot = 9, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			CALL sp_EnhancerCreate('Mining Finder Range Enhancer V', ModeleId = id, Slot = 5, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			CALL sp_EnhancerCreate('Mining Finder Range Enhancer VI', ModeleId = id, Slot = 6, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			CALL sp_EnhancerCreate('Mining Finder Range Enhancer VII', ModeleId = id, Slot = 7, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			CALL sp_EnhancerCreate('Mining Finder Range Enhancer VIII', ModeleId = id, Slot = 8, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			CALL sp_EnhancerCreate('Mining Finder Range Enhancer X', ModeleId = id, Slot = 10, BonusBalue1 = 1, BonusValue2 = 10, Value = 1 });
			
			int id = repositories.Modeles.GetByNom("Finder Skill Enhancer").Id;
CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer I', ModeleId = id, Slot = 1, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer II', ModeleId = id, Slot = 2, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer III', ModeleId = id, Slot = 3, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer IV', ModeleId = id, Slot = 4, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer IX', ModeleId = id, Slot = 9, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer V', ModeleId = id, , Slot = 5, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer VI', ModeleId = id, Slot = 6, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer VII', ModeleId = id, Slot = 7, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer VIII', ModeleId = id, Slot = 8, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			CALL sp_EnhancerCreate('Mining Finder Skill Modification Enhancer X', ModeleId = id, Slot = 10, BonusBalue1 = 0.5, BonusValue2 = 0, Value = 0.6 });
			
			int id = repositories.Modeles.GetByNom("Excavator Speed Enhancer").Id;
CALL sp_EnhancerCreate('Mining Excavator Speed Enhancer I', ModeleId = id, Slot = 1, BonusBalue1 = 10, BonusValue2 = 0, Value = 0.2 });
			CALL sp_EnhancerCreate('Mining Excavator Speed Enhancer II', ModeleId = id, Slot = 2, BonusBalue1 = 10, BonusValue2 = 0, Value = 0.2 });
			CALL sp_EnhancerCreate('Mining Excavator Speed Enhancer III', ModeleId = id, Slot = 3, BonusBalue1 = 10, BonusValue2 = 0, Value = 0.2 });
			CALL sp_EnhancerCreate('Mining Excavator Speed Enhancer IV', ModeleId = id, Slot = 4, BonusBalue1 = 10, BonusValue2 = 0, Value = 0.2 });
			CALL sp_EnhancerCreate('Mining Excavator Speed Enhancer V', ModeleId = id, Slot = 5, BonusBalue1 = 10, BonusValue2 = 0, Value = 0.2 });
			CALL sp_EnhancerCreate('Mining Excavator Speed Enhancer VI', ModeleId = id, Slot = 6, BonusBalue1 = 10, BonusValue2 = 0, Value = 0.2 });
			CALL sp_EnhancerCreate('Mining Excavator Speed Enhancer VII', ModeleId = id, Slot = 7, BonusBalue1 = 10, BonusValue2 = 0, Value = 0.2 });
			CALL sp_EnhancerCreate('Mining Excavator Speed Enhancer VIII', ModeleId = id, Slot = 8, BonusBalue1 = 10, BonusValue2 = 0, Value = 0.2 });
			CALL sp_EnhancerCreate('Mining Excavator Speed Enhancer X', ModeleId = id, Slot = 10, BonusBalue1 = 10, BonusValue2 = 0, Value = 0.2 });
		}
		
		private static void AddMaterials(IRepositoriesUoW repositories)
{
    int id = repositories.Modeles.GetByNom("Material").Id;

}
    }
}
    }
}