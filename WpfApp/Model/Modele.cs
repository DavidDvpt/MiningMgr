using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Modele")]
    public class Modele : Commun
    {
        private bool _isStackable = false;
        private int _categorieId;
        private Categorie _categorie;

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
        public virtual Categorie Categorie
        {
            get => _categorie;
            set
            {
                if (value != _categorie)
                {
                    _categorie = value;
                    CategorieId = Categorie.Id;
                    NotifyPropertyChanged();
                }
            }
        }

        public virtual ICollection<InWorld> InWorlds { get; set; }
    }
}
