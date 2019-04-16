using System;
using WpfApp.Commands;

namespace WpfApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {

        }

        protected override void Init()
        {
            NavCommand = new CommandWithStringParam<string>(OnNav);
        }

        public CommandWithStringParam<string> NavCommand { get; private set; }

        #region ViewModels
        //private SetupManagerViewModel setupManagerViewModel = new SetupManagerViewModel();
        //private CategorieManagerViewModel categorieViewModel = new CategorieManagerViewModel();
        //private ModeleManagerViewModel modeleViewModel = new ModeleManagerViewModel();
        //private FinderManagerViewModel finderViewModel = new FinderManagerViewModel();
        //private PlanetManagerViewModel planetViewModel = new PlanetManagerViewModel();
        //private ExcavatorManagerViewModel excavatorViewModel = new ExcavatorManagerViewModel();
        //private RefinerManagerViewModel refinerViewModel = new RefinerManagerViewModel();
        //private FinderAmplifierManagerViewModel finderAmplifierViewModel = new FinderAmplifierManagerViewModel();
        //private EnhancerManagerViewModel enhancerViewModel = new EnhancerManagerViewModel();
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
                    CurrentViewModel = new SetupManagerViewModel();
                    break;
                case "categorie":
                    CurrentViewModel = new CategorieManagerViewModel();
                    break;
                case "modele":
                    CurrentViewModel = new ModeleManagerViewModel();
                    break;
                case "planet":
                    CurrentViewModel = new PlanetManagerViewModel();
                    break;
                case "finder":
                    CurrentViewModel = new FinderManagerViewModel();
                    break;
                case "excavator":
                    CurrentViewModel = new ExcavatorManagerViewModel();
                    break;
                case "refiner":
                    CurrentViewModel = new RefinerManagerViewModel();
                    break;
                case "finderAmplifier":
                    CurrentViewModel = new FinderAmplifierManagerViewModel();
                    break;
                case "enhancer":
                    CurrentViewModel = new EnhancerManagerViewModel();
                    break;
                case "material":
                    CurrentViewModel = new MaterialManagerViewModel();
                    break;
                case "searchMode":
                default:
                    CurrentViewModel = new SearchModeManagerViewModel();
                    break;
            }
        }
    }
}
