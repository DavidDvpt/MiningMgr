﻿using System;
using System.Collections.Generic;
using WpfApp.Commands;

namespace WpfApp.ViewModel
{
    public abstract class ManagerViewModel<T> : BaseViewModel
        where T : class
    {
        protected T _dgSelectedItem;
        protected T _itemForm;

        public ManagerViewModel()
        {
            ColumnInit();
            UpdateButton = new MyICommand(UpdateItem);
        }

        protected abstract void ColumnInit();

        public MyICommand UpdateButton { get; private set; }

        public ICollection<T> DataGridItemSource { get; set; }

        #region DataGridColumnVisibility
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
        public bool CodeMinVisibility { get; set; } = false;

        // Tool
        public bool UsePerMinVisibility { get; set; } = false;

        //Depth
        public bool DepthVisibility { get; set; } = false;
        public bool RangeVisibility { get; set; } = false;

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
        #endregion

        public T DgSelectedItem
        {
            get => _dgSelectedItem;
            set
            {
                if (_dgSelectedItem != value)
                {
                    _dgSelectedItem = value;
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


        private void UpdateItem()
        {
            ItemForm = DgSelectedItem;
        }
    }
}
