using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Modele")]
    public class ModeleDto : CommunDto
    {
        #region SiPoco
        //[Required]
        //public bool IsStackable { get; set; } = false;

        //public int CategorieId { get; set; }

        //[ForeignKey("CategorieId")]
        //public virtual CategorieDto CategorieDto {get; set;}

        //public virtual ICollection<InWorldDto> InWorldsDto { get; set; }
        #endregion

        #region SiDto
        private bool _isStackable = false;
        private int _categorieId;
        private CategorieDto _categorieDto;

        [Required]
        public bool IsStackable
        {
            get => _isStackable;
            set
            {
                if (value != _isStackable)
                {
                    _isStackable = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int CategorieId
        {
            get => _categorieId;
            set
            {
                if (value != _categorieId)
                {
                    _categorieId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [ForeignKey("CategorieId")]
        public virtual CategorieDto CategorieDto
        {
            get => _categorieDto;
            set
            {
                if (value != _categorieDto)
                {
                    _categorieDto = value;
                    CategorieId = CategorieDto.Id;
                    NotifyPropertyChanged();
                }
            }
        }

        public virtual ICollection<InWorldDto> InWorldsDto { get; set; }
        #endregion
    }
}
