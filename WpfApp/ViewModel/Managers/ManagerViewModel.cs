using System.Collections.Generic;
using System.Linq;
using WpfApp.Model.Dto;
using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.ViewModel
{
    public abstract class ManagerViewModel<T> : BaseViewModel
        where T : CommunDto, new()
    {
        #region attributs
        protected T _dgSelectedItem;// item seectionné ds le datagrid
        protected T _itemForm;  // Item actif du formulaire
        protected bool ModifySelected = false; // indique que l'item du datagrid selectionne est en cours de modification
        protected ICommunRepositoryDto<T> genericRepo; // repository generique utilisé par 80% des manager
        protected ICollection<T> _dataGridItemSource; // source du datagrid principal
        protected bool _modifyBtnEnabled = true;
        protected bool _createBtnEnabled = true;
        protected bool _validateBtnEnabled = true;
        protected bool _cancelBtnEnabled = true;
        #endregion

        public ManagerViewModel()
        {
            ColumnInit();
            CommandInit();
            genericRepo = new CommunRepositoryDto<T>(repos.GetContext());
            ItemSourceLoad();
        }

        private void CommandInit()
        {
            UpdateButton = new MyICommand(UpdateItem, ModifyBtnCanExecute);
            CreateButton = new MyICommand(CreateItem, CreateBtnCanExecute);
            ValiderButton = new MyICommand(ValiderItem, ValidateBtnCanExecute);
            AnnulerButton = new MyICommand(AnnulerItem, CancelBtnCanExecute);
        }

        public bool CanExecuteTest()
        {
            return false;
        }

        protected abstract void ColumnInit();

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

        public bool CbxModelesChoiceVisibility { get; set; } = false;
        #endregion

        #region Enabled Champ Formulaire
        public bool NomFormEnabled { get; set; } = false;
        #endregion

        public T DgSelectedItem
        {
            get => _dgSelectedItem;
            set
            {
                if (_dgSelectedItem != value)
                {
                    _dgSelectedItem = value;
                    RaiseCanExecuteChanged();
                    OnPropertyChanged();
                }
            }
        }

        public T ItemForm
        {
            get => _itemForm;
            set
            {
                if (_itemForm != value)
                {
                    _itemForm = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICollection<T> DataGridItemSource
        {
            get { return _dataGridItemSource; }
            set
            {
                if (_dataGridItemSource != value)
                {
                    _dataGridItemSource = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void ItemSourceLoad()
        {
            DataGridItemSource = genericRepo.GetAll().ToList();
        }

        protected virtual void ItemSourceUpdated()
        {
            DataGridItemSource = genericRepo.GetAll().ToList();
        }

        #region Commands et actions
        public MyICommand UpdateButton { get; private set; }
        public MyICommand CreateButton { get; private set; }
        public MyICommand ValiderButton { get; private set; }
        public MyICommand AnnulerButton { get; private set; }
     
        private void UpdateItem()
        {
            ItemForm = DgSelectedItem;
            DgSelectedItem = null;
            RaiseCanExecuteChanged();
        }

        protected virtual void CreateItem()
        {
            ItemForm = new T();
            RaiseCanExecuteChanged();
        }

        protected void ValiderItem()
        {
            //if (ModifySelected)
            //{
            //    genericRepo.Update(ItemForm);
            //}
            //else
            //{
            //    genericRepo.Add(ItemForm);
            //    ModifySelected = false;                
            //}
            //ItemForm = null;
            //ItemSourceUpdated();
            ////OnValidateBtnClick();
        }

        private void AnnulerItem()
        {
            ItemForm = null;
            RaiseCanExecuteChanged();
        }
        #endregion

        #region Gestion Des Boutons
        //public bool ModifyBtnEnabled
        //{
        //    get { return _modifyBtnEnabled; }
        //    set
        //    {
        //        if (ModifyBtnEnabled != value)
        //        {
        //            _modifyBtnEnabled = !ModifyBtnEnabled;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public bool CreateBtnEnabled
        //{
        //    get { return _createBtnEnabled; }
        //    set
        //    {
        //        if (CreateBtnEnabled != value)
        //        {
        //            _createBtnEnabled = !CreateBtnEnabled;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public bool ValidateBtnEnabled
        //{
        //    get { return _validateBtnEnabled; }
        //    set
        //    {
        //        if (ValidateBtnEnabled != value)
        //        {
        //            _validateBtnEnabled = !ValidateBtnEnabled;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public bool CancelBtnEnabled
        //{
        //    get { return _cancelBtnEnabled; }
        //    set
        //    {
        //        if (CancelBtnEnabled != value)
        //        {
        //            _cancelBtnEnabled = !CancelBtnEnabled;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        public bool CancelBtnCanExecute()
        {
            return ItemForm == null ? false : true;
        }

        public bool ModifyBtnCanExecute()
        {
            return DgSelectedItem != null ? true : false;
        }

        public bool CreateBtnCanExecute()
        {
            return ItemForm == null ? true : false;
        }

        public bool ValidateBtnCanExecute()
        {
            return false;
        }

        private void RaiseCanExecuteChanged()
        {
            UpdateButton.RaiseCanExecuteChanged();
            CreateButton.RaiseCanExecuteChanged();
            ValiderButton.RaiseCanExecuteChanged();
            AnnulerButton.RaiseCanExecuteChanged();
        }
        #endregion
    }
}
