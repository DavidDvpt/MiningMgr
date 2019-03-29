using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Context;
using WpfApp.Model;
using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.ViewModel
{
    public class SetupViewModel
    {
        private IRepositoriesUoW repos;

        public SetupViewModel()
        {
            if (repos != null)
                repos = new RepositoriesUoW();
            else
                throw new NullReferenceException("Le context est null");
        }

        public Setup Setup { get; set; }

        // Pour alimenter le combobox choix du finder
        public ICollection<Finder> Finders()
        {
            return repos.Finders.GetAll().ToList();
        }

        // Pour alimenter le combobox choix du finderamplifier
        public ICollection<FinderAmplifier> FindersAmplifiers()
        {
            return repos.FinderAmplifiers.GetAll().ToList();
        }
    }
}
