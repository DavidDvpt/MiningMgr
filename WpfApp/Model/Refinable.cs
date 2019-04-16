using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Refinable")]
    public class Refinable : BindableBase
    {
        private int _unrefinedId;
        private int _refinedId;
        private Material _unrefinedMaterial;
        private Material _refinedMaterial;
        private int _quantity = 1;

        [Key]
        [Column(Order = 1)]
        public int UnrefinedId
        {
            get { return _unrefinedId; }
            set
            {
                if (UnrefinedId != value)
                {
                    _unrefinedId = value;
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
                if (RefinedId != value)
                {
                    _refinedId = value;
                    OnPropertyChanged();
                }
            }
        }

        [ForeignKey("UnrefinedId")]
        public Material UnrefinedMaterial
        {
            get { return _unrefinedMaterial; }
            set
            {
                if (UnrefinedMaterial != value)
                {
                    _unrefinedMaterial = value;
                    OnPropertyChanged();
                }
            }
        }

        [ForeignKey("RefinedId")]
        public Material RefinedMaterial
        {
            get { return _refinedMaterial; }
            set
            {
                if (RefinedMaterial != value)
                {
                    _refinedMaterial = value;
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
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
