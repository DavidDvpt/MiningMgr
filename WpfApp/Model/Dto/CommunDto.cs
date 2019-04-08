﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Commun")]
    public abstract class CommunDto : BaseDto// ICommunDto
    {
        #region SiPoco
        //[Key]
        //[Required]
        //public int Id { get; set; }

        //[Required]
        //[Column(TypeName = "VARCHAR")]
        //[StringLength(50, ErrorMessage = "La longueur maximum est de 50")]
        //[Index(IsUnique = true)]
        //public string Nom { get; set; }

        //[Required]
        //public bool IsActive { get; set; } = true;
        #endregion

        #region SiDto
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

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, ErrorMessage = "La longueur maximum est de 50")]
        [Index(IsUnique = true)]
        public string Nom
        {
            get => _nom;
            set
            {
                if (value != _nom)
                {
                    _nom = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required]
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
        #endregion
    }
}
