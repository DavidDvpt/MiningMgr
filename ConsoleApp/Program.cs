using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("turlututu");
            IRepositoriesUoW repo = new RepositoriesUoW();
            Console.Write("Nombre de categories : " + repo.CategoriesPoco.GetAll().Count());
            Console.Write("\nNombre de modeles : " + repo.ModelesPoco.GetAll().Count());
            Console.Write("\nNombre de ToolAccessoire : " + repo.ToolAccessoiresPoco.GetAll().Count());
            Console.Write("\nNombre de planetes : " + repo.PlanetsPoco.GetAll().Count());
            Console.Write("\nNombre de Finders : " + repo.FindersPoco.GetAll().Count());
            Console.Write("\nNombre de Excavators : " + repo.ExcavatorsPoco.GetAll().Count());
            Console.Write("\nNombre de Refiners : " + repo.RefinersPoco.GetAll().Count());
            Console.Write("\nNombre de FinderAmplifiers : " + repo.FinderAmplifiersPoco.GetAll().Count());
            Console.Write("\nNombre de Enhancers : " + repo.EnhancersPoco.GetAll().Count());
            Console.Write("\nNombre de Search Modes : " + repo.SearchModesPoco.GetAll().Count());
            Console.Write("\nAppuyez sur une touche pour continuer ...\n");
            Console.ReadKey();
        }
    }
}
