//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dto
{
    using System;
    using System.Collections.Generic;
    
    public partial class Common
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public bool Is_Active { get; set; }
    
        public virtual Categorie Categorie { get; set; }
        public virtual InWorld InWorld { get; set; }
        public virtual Planet Planet { get; set; }
        public virtual Type Type { get; set; }
    }
}
