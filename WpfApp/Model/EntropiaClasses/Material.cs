using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Material")]
    public class Material : InWorld
    {
        public Material()
        {
            //RefinedTo = new List<Refinable>();
            //RefinedFrom = new List<Refinable>();
        }

        [InverseProperty("UnrefinedMaterial")]
        public virtual ICollection<Refinable> RefinedTo { get; set; }

        [InverseProperty("RefinedMaterial")]
        public virtual ICollection<Refinable> RefinedFrom { get; set; }

        public string RefinedToNomString
        {
            get
            {
                string val = "";
                if (RefinedTo != null && RefinedTo.Count != 0 )
                {
                    foreach (Refinable r in RefinedTo)
                    {
                        val += r.RefinedMaterial.Nom + ", ";
                    }
                    val = val.Substring(0, val.Length - 2);
                }
                
                return val;
            }
        }

        public string RefinedToQtyString
        {
            get
            {
                string val = "";
                if (RefinedTo != null && RefinedTo.Count != 0)
                {
                    foreach (Refinable r in RefinedTo)
                    {
                        val += r.Quantity + ", ";
                    }
                    val = val.Substring(0, val.Length - 2);
                }
                return val;
            }
        }

        public string RefinedFromNomString
        {
            get
            {
                string val = "";
                if (RefinedFrom != null && RefinedFrom.Count != 0)
                {
                    foreach (Refinable r in RefinedFrom)
                    {
                        val += r.UnrefinedMaterial.Nom + ", ";
                    }
                    val = val.Substring(0, val.Length - 2);
                }

                return val;
            }
        }

        public string RefinedFromQtyString
        {
            get
            {
                string val = "";
                if (RefinedFrom != null && RefinedFrom.Count != 0)
                {
                    foreach (Refinable r in RefinedFrom)
                    {
                        val += r.Quantity + ", ";
                    }
                    val = val.Substring(0, val.Length - 2);
                }
                return val;
            }
        }

    }
}
