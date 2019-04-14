using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Refinable")]
    public class RefinableDto : BindableBase
    {
        private int _unrefinedId;
        private int _refinedId;
        private MaterialDto _unrefinedMaterial;
        private MaterialDto _refinedMaterial;
        private int _quantity = 1;

        [Key]
        [Column(Order = 1)]
        public int UnrefinedId
        {
            get { return _unrefinedId; }
            set
            {
                if (_unrefinedId != value)
                {
                    UnrefinedId = value;
                    OnPropertyChanged();
                }
            }
        }

        [Key]
        [Column(Order = 2)]
        public int RefinedId
        {
            get { return _refinedId; }
            set
            {
                if (_refinedId != value)
                {
                    RefinedId = value;
                    OnPropertyChanged();
                }
            }
        }

        [ForeignKey("UnrefinedId")]
        public MaterialDto UnrefinedMaterial
        {
            get { return _unrefinedMaterial; }
            set
            {
                if (_unrefinedMaterial != value)
                {
                    UnrefinedMaterial = value;
                    OnPropertyChanged();
                }
            }
        }
        [ForeignKey("UnrefinedId")]
        public MaterialDto RefinedMaterial
        {
            get { return _refinedMaterial; }
            set
            {
                if (_refinedMaterial != value)
                {
                    RefinedMaterial = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    Quantity = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
