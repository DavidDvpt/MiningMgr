﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbMiningEntities : DbContext
    {
        public DbMiningEntities()
            : base("name=DbMiningEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Common> Common { get; set; }
        public virtual DbSet<Enhancer_Info> Enhancer_Info { get; set; }
        public virtual DbSet<Excavator_Info> Excavator_Info { get; set; }
        public virtual DbSet<Finder_Info> Finder_Info { get; set; }
        public virtual DbSet<FinderAmplifier_Info> FinderAmplifier_Info { get; set; }
        public virtual DbSet<InWorld> InWorld { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Planet> Planet { get; set; }
        public virtual DbSet<Refiner_Info> Refiner_Info { get; set; }
        public virtual DbSet<Tool> Tool { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Unstackable> Unstackable { get; set; }
    }
}