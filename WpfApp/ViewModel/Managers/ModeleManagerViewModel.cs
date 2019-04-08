using System.Collections.Generic;
using System.Linq;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class ModeleManagerViewModel : ManagerViewModel<ModelePoco>
    {
        private CategoriePoco _selectedCategorie;
        public ModeleManagerViewModel()
        {
            CategoriesPoco = repos.CategoriesPoco.GetAll().ToList();
            SelectedCategorie = repos.CategoriesPoco.GetByNom("Tool");
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            CategorieNomVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void Init()
        {
            DataGridItemSource = repos.ModelesPoco.GetAll().ToList();
        }

        public ICollection<CategoriePoco> CategoriesPoco { get; set; }

        public ModelePoco DgSelectedItem
        {
            get => _dgSelectedItem;
            set
            {
                if (_dgSelectedItem != value)
                {
                    _dgSelectedItem = value;
                    //SelectedCategorie = DgSelectedItem.CategoriePoco;
                    OnPropertyChanged();
                }
            }
        }

        public CategoriePoco SelectedCategorie
        {
            get { return _selectedCategorie; }
            set
            {
                _selectedCategorie = value;
                OnPropertyChanged();
            }
        }

    }
}
