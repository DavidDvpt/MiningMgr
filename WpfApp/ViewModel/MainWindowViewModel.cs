using System;
using WpfApp.Commands;

namespace WpfApp.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new NavCommand<string>(OnNav);
        }

        public NavCommand<string> NavCommand { get; private set; }

        #region ViewModels
        private SetupManagerViewModel setupManagerViewModel = new SetupManagerViewModel();
        private CategorieManagerViewModel categorieViewModel = new CategorieManagerViewModel();
        private ModeleManagerViewModel modeleViewModel = new ModeleManagerViewModel();
        private FinderManagerViewModel finderViewModel = new FinderManagerViewModel();
        private PlanetManagerViewModel planetViewModel = new PlanetManagerViewModel();
        private ExcavatorManagerViewModel excavatorViewModel = new ExcavatorManagerViewModel();
        private RefinerManagerViewModel refinerViewModel = new RefinerManagerViewModel();
        private FinderAmplifierManagerViewModel finderAmplifierViewModel = new FinderAmplifierManagerViewModel();
        private EnhancerManagerViewModel enhancerViewModel = new EnhancerManagerViewModel();
        #endregion

        private BindableBase _CurrentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _CurrentViewModel;
            set
            {
                SetProperty(ref _CurrentViewModel, value);
                int i = DateTime.Now.Year;
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "setup":
                    CurrentViewModel = setupManagerViewModel;
                    break;
                case "categorie":
                    CurrentViewModel = categorieViewModel;
                    break;
                case "modele":
                    CurrentViewModel = modeleViewModel;
                    break;
                case "planet":
                    CurrentViewModel = planetViewModel;
                    break;
                case "finder":
                    CurrentViewModel = finderViewModel;
                    break;
                case "excavator":
                    CurrentViewModel = excavatorViewModel;
                    break;
                case "refiner":
                    CurrentViewModel = refinerViewModel;
                    break;
                case "finderAmplifier":
                    CurrentViewModel = finderAmplifierViewModel;
                    break;
                case "enhancer":
                    CurrentViewModel = enhancerViewModel;
                    break;
                    //case "searchMode":
                    //default:
                    //    CurrentViewModel = searchModeViewModel;
                    //    break;
            }
        }
    }
}
