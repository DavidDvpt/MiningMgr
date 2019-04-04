using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Commands;
using WpfApp.ViewModel;

namespace WpfApp
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new NavCommand<string>(OnNav);
        }
        public NavCommand<string> NavCommand { get; private set; }

        private SetupViewModel setupViewModel = new SetupViewModel();
        private CategorieManagerViewModel categorieViewModel = new CategorieManagerViewModel();
        private ModeleManagerViewModel modeleViewModel = new ModeleManagerViewModel();

        private BindableBase _CurrentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _CurrentViewModel;
            set
            {
                SetProperty(ref _CurrentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "setup":
                    CurrentViewModel = setupViewModel;
                    break;
                case "categorie":
                    CurrentViewModel = categorieViewModel;
                    break;
                case "modele":
                    CurrentViewModel = modeleViewModel;
                    break;
            }
        }
    }
}
