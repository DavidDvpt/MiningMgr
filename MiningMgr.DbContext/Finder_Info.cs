//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiningMgr.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Finder_Info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Finder_Info()
        {
            this.Setups = new HashSet<Setup>();
        }
    
        public int Id { get; set; }
        public decimal Depth { get; set; }
        public decimal FinderRange { get; set; }
        public short BasePecSearch { get; set; }
    
        public virtual Tool Tool { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Setup> Setups { get; set; }
    }
}