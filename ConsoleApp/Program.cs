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
            Console.Write("Nombre de categories : " + repo.Categories.GetAll().Count());
            Console.Write("\nNombre de modeles : " + repo.Modeles.GetAll().Count());
            Console.Write("\nNombre de ToolAccessoire : " + repo.ToolAccessoires.GetAll().Count());
            Console.Write("\nNombre de planetes : " + repo.Planets.GetAll().Count());
            Console.Write("\nNombre de Finders : " + repo.Finders.GetAll().Count());
            Console.Write("\nNombre de Excavators : " + repo.Excavators.GetAll().Count());
            Console.Write("\nNombre de Refiners : " + repo.Refiners.GetAll().Count());
            Console.Write("\nNombre de FinderAmplifiers : " + repo.FinderAmplifiers.GetAll().Count());
            Console.Write("\nNombre de Enhancers : " + repo.Enhancers.GetAll().Count());
            Console.Write("\nNombre de Search Modes : " + repo.SearchModes.GetAll().Count());
            Console.Write("\nAppuyez sur une touche pour continuer ...\n");
            Console.ReadKey();
        }
    }
}
