using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp.Commands;
using WpfApp.Model;
using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.ViewModel
{
    public abstract class ManagerViewModel<T> : BaseViewModel
        where T : Commun, new()
    {
        #region attributs
        
        protected ICommunRepository<T> genericRepo; // repository generique utilisé par 80% des manager
        protected bool IsModified = false;

        #endregion

        #region Constructeurs et Initialisations

        public ManagerViewModel()
        {
            CommandInit();
            ColumnInit();
            genericRepo = new CommunRepository<T>(repos.GetContext());
            DataGridItemSourceLoad();
        }

        private void CommandInit()
        {
            UpdateCommand = new RelayCommand(UpdateExecute, UpdateCanExecute);
            CreateCommand = new RelayCommand(CreateExecute, CreateCanExecute);
            SubmitCommand = new RelayCommand(SubmitExecute, SubmitCanExecute);
            CancelCommand = new RelayCommand(CancelExecute, CancelCanExecute);
        }

        protected abstract void ColumnInit();

        #endregion  

        // Affichage ou non des colonnes du datagrid  ou des control )
        // à l'initialisation de la classe
        #region ColumnAndControlVisibility

        // Commun, Categorie, Planet
        public bool IdVisibility { get; set; } = false;
        public bool NomVisibility { get; set; } = false;
        public bool IsActiveVisibility { get; set; } = false;

        // Modele
        public bool CategorieNomVisibility { get; set; } = false;

        // InWorld
        public bool ValueVisibility { get; set; } = false;
        public bool ModeleNomVisibility { get; set; } = false;

        // Unstackable
        public bool IsLimitedVisibility { get; set; } = false;
        public bool DecayVisibility { get; set; } = false;
        public bool CodeVisibility { get; set; } = false;

        // Tool
        public bool UsePerMinVisibility { get; set; } = false;

        //Depth
        public bool DepthVisibility { get; set; } = false;
        public bool RangeVisibility { get; set; } = false;
        public bool BasePecSearchVisibility { get; set; } = false;

        // Excavator
        public bool EfficientyVisibility { get; set; } = false;

        // Accessoires
        // Finder Amplifier
        public bool CoefficientVisibility { get; set; } = false;

        // Enhancer
        public bool SlotVisibility { get; set; } = false;
        public bool BonusValue1Visibility { get; set; } = false;
        public bool BonusValue2Visibility { get; set; } = false;

        // SearchMode
        public bool AbbrevVisibility { get; set; } = false;
        public bool MultiplicateurVisibility { get; set; } = false;

        // Setup
        public bool SearchModeVisibility { get; set; } = false;
        public bool FinderVisibility { get; set; } = false;
        public bool FinderAmplifierVisibility { get; set; } = false;
        public bool DepthEnhancerQtyVisibility { get; set; } = false;
        public bool RangeEnhancerQtyVisibility { get; set; } = false;
        public bool SkillEnhancerQtyVisibility { get; set; } = false;
        
        public bool RefinedToVisibility { get; set; } = false;
        public bool QuantityToVisibility { get; set; } = false;

        public bool RefinedFromVisibility { get; set; } = false;
        public bool QuantityFromVisibility { get; set; } = false;

        public bool CbxModelesChoiceVisibility { get; set; } = false;
        #endregion

        #region Enabled Champ Formulaire

        public bool NomFormEnabled
        {
            get { return GetValue(() => NomFormEnabled); }
            set
            {
                if (NomFormEnabled != value)
                {
                    SetValue(() => NomFormEnabled, value); 
                }
            }
        }

        #endregion

        #region Datagrid

        protected virtual void DataGridItemSourceLoad()
        {
            DataGridItemSource = genericRepo.GetAll().ToList();
        }

        public T DgSelectedItem
        {
            get { return GetValue(() => DgSelectedItem); }
            set
            {
                if (DgSelectedItem != value)
                {
                    SetValue(() =>DgSelectedItem, value);
                }
            }
        }

        public ICollection<T> DataGridItemSource
        {
            get { return GetValue(() => DataGridItemSource); }
            set
            {
                if (DataGridItemSource != value)
                {
                    SetValue(() => DataGridItemSource, value);
                }
            }
        }

        #endregion

        #region Formulaire

        public T ItemForm
        {
            get => GetValue(() => ItemForm);
            set
            {
                if (ItemForm != value)
                {
                    SetValue(() => ItemForm, value);
                }
            }
        }

        #region Execute

        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public void UpdateExecute(object param)
        {
            ItemForm = DgSelectedItem;
            IsModified = true;
            DgSelectedItem = null;
        }
        public virtual void CreateExecute(object param)
        {
            ItemForm = new T();
            NomFormEnabled = true;
        }
        public virtual void SubmitExecute(object param)
        {
            if (IsModified)
            {
                genericRepo.Update(ItemForm);
            }
            else
            {
                genericRepo.Add(ItemForm);
            }
            IsModified = false;
            DataGridItemSourceLoad();
            AfficherMessage();
            ItemForm = null;
            NomFormEnabled = false;
        }
        public void CancelExecute(object param)
        {
            ItemForm = null;
            NomFormEnabled = false;
            IsModified = false;
        }
        
        #endregion

        #region Can Execute

        public bool CancelCanExecute(object param)
        {
            return ItemForm == null ? false : true;
        }
        public bool UpdateCanExecute(object param)
        {
            return ((DgSelectedItem != null) && (ItemForm == null)) ? true : false;
        }
        public bool CreateCanExecute(object param)
        {
            return ItemForm == null ? true : false;
        }
        public bool SubmitCanExecute(object param)
        {
            if (ItemForm == null)
            {
                return false;
            }
            if (Errors == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #endregion

        private void AfficherMessage()
        {
            MessageBox.Show("l'item " + ItemForm.Nom + "a bien été ajouté", "Info",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
