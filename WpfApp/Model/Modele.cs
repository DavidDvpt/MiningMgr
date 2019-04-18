using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Modele")]
    public class Modele : Commun
    {
        public Modele()
        {
            IsStackable = false;
            CategorieId = 0;
        }

        [Required]
        public bool IsStackable
        {
            get { return GetValue(() => IsStackable); }
            set
            {
                if (value != IsStackable)
                {
                    SetValue(() => IsStackable, value);
                }
            }
        }

        public int CategorieId
        {
            get { return GetValue(() => CategorieId); }
            set
            {
                if (value != CategorieId)
                {
                    SetValue(() => CategorieId, value);
                }
            }
        }

        [Required]
        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie
        {
            get { return GetValue(() => Categorie); }
            set
            {
                if (value != Categorie)
                {
                    SetValue(() => Categorie, value);
                    CategorieId = value.Id;
                }
            }
        }

        public virtual ICollection<InWorld> InWorlds { get; set; }
    }
}
