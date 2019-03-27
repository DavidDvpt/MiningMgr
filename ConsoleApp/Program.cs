using ModelCodeFisrtTPT.Repositories;
using ModelCodeFisrtTPT.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("turlututu");
            IRepositoriesUoW repo = new RepositoriesUoW();
            Console.Write("Nombre de categories :" + repo.Categories.GetAll().Count());
            Console.Write("\nNombre de modeles :" + repo.Modeles.GetAll().Count());
            Console.Write("\nNombre de planetes :" + repo.Planets.GetAll().Count());
            Console.Write("\nNombre de Finders :" + repo.Finders.GetAll().Count());
            Console.ReadKey();
        }
    }
}
