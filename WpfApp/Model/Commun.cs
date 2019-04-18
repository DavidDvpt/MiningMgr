﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WpfApp.AttributValidation;

namespace WpfApp.Model
{
    [Table("Commun")]
    public abstract class Commun : BindableBase
    {
        private int _id;
        private string _nom;
        private bool _isActive = true;

        [Key]
        [Required]
        public int Id
        {
            get => _id;
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required(ErrorMessage = "Le Nom est requis")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50, ErrorMessage = "La longueur maximum est de 50")]
        [Index(IsUnique = true)]
        [Unique(ErrorMessage ="Ce nom est déjà utilisé")]
        //public string Nom
        //{
        //    get => _nom;
        //    set
        //    {
        //        if (value != _nom)
        //        {
        //            _nom = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}
        public string Nom
        {
            get
            {
                return GetValue(() => Nom);
            }
            set
            {
                SetValue(() => Nom, value);
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (value != _isActive)
                {
                    _isActive = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
