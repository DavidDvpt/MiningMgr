using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp.Commands;
using WpfApp.Model.Poco;
using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new NavCommand<string>(OnNav);
            IRepositoriesUoW repos = new RepositoriesUoW();
            //Categories = repos.CategoriesPoco.GetAll().ToList();
            //Modele = repos.ModelesPoco.GetByNom("Finder");
            //SelectedCategorie = repos.CategoriesPoco.GetByNom("Tool");
            //_users = CreateUsers();
            //SelectedUser = _users.SingleOrDefault(x => x.Id == 4);
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

        //public ICollection<CategoriePoco> Categories { get; set; }

        //public ModelePoco Modele { get; set; }

        //public CategoriePoco SelectedCategorie { get; set; }

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

    //    private ICollection<User> _users;
    //    public ICollection<User> Users => _users;

    //    public User SelectedUser { get; set; }

    //    private ICollection<User> CreateUsers()
    //    {
    //        ICollection<User> col = new List<User>();
    //        User u1 = new User() { Id = 1, Nom = "Tu,n;tut", Prenom = "Zerhjfjtr" };
    //        User u2 = new User() { Id = 2, Nom = "Tutut", Prenom = "Zertfjjr" };
    //        User u3 = new User() { Id = 3, Nom = "Tjyuyutut", Prenom = "Zkkllertr" };
    //        User u4 = new User() { Id = 4, Nom = "Tutut", Prenom = "Zerldrfdstr" };
    //        User u5 = new User() { Id = 5, Nom = "Tytutuutut", Prenom = "qqfZertr" };
    //        User u6 = new User() { Id = 6, Nom = "Tuoootut", Prenom = "Zertr" };
    //        col.Add(u1);
    //        col.Add(u2);
    //        col.Add(u3);
    //        col.Add(u4);
    //        col.Add(u5);
    //        col.Add(u6);
    //        return col;
    //    }
    //}

    //public class User //: INotifyPropertyChanged
    //{
    //    private int _id;
    //    private string _nom;
    //    private string _prenom;

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //public int Id
        //{
        //    get { return _id; }
        //    set
        //    {
        //        _id = value;
        //        //NotifyPropertyChanged();
        //    }
        //}

        //public String Nom
        //{
        //    get { return _nom; }
        //    set
        //    {
        //        _nom = value;
        //        //NotifyPropertyChanged();
        //    }
        //}

        //public string Prenom
        //{
        //    get { return _prenom; }
        //    set
        //    {
        //        _prenom = value;
        //        //NotifyPropertyChanged();
        //    }
        //}
    }
}
