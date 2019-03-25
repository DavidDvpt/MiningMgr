using System;
using ModelCodeFisrtTPT.Repositories.Interfaces;

namespace ModelCodeFisrtTPT
{
    public static class SeedStaticMethods
    {
        public static void Seed(IRepositoriesUoW repositories)
        {
            AddCategories(repositories);
        }

        private static void AddCategories(IRepositoriesUoW repositories)
        {
            repositories.Categories.Add(new Dto.Categorie() { Nom = "Tool" });
            repositories.Categories.Add(new Dto.Categorie() { Nom = "Accessoire" });
            repositories.Categories.Add(new Dto.Categorie() { Nom = "Material" });
        }
    }
}