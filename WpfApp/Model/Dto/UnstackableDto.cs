﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Unstackable")]
    public abstract class UnstackableDto : InWorldDto
    {
        #region SiPoco
        //[Required]
        //public bool IsLimited { get; set; } = true;

        //public decimal Decay { get; set; }

        //public string Code { get; set; } = "";
        #endregion

        #region SiDto
        private bool _isLimited = true;
        private decimal _decay;
        private string _code = "";

        [Required]
        public bool IsLimited
        {
            get => _isLimited;
            set
            {
                _isLimited = value;
                NotifyPropertyChanged();
            }
        }

        public decimal Decay
        {
            get => _decay;
            set
            {
                _decay = value;
                NotifyPropertyChanged();
            }
        }

        public string Code
        {
            get => _code;
            set
            {
                _code = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }
}
