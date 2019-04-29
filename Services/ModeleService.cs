using System.Collections.Generic;
using System.Linq;
using Services.Context;
using Model;
using Services.Interfaces;

namespace Services
{
    /// <summary>
    /// Gestion du DbSet Modele
    /// </summary>
    public class ModeleService : CommunService<Modele>, IModeleService
    {
        #region Constructeur

        //public ModeleService(MiningContext ctx)
        //    : base(ctx)
        //{

        //}

        #endregion

        /// <summary>
        /// Retourne toutes les catégories par Categorie Id
        /// </summary>
        /// <param name="id">Id de la catégorie</param>
        /// <returns></returns>
        public ICollection<Modele> GetModelesByCategorieId(int id)
        {
            return DbSet.Where(x => x.Categorie.Id == id).ToList();
        }

        /// <summary>
        /// Retourne toutes les catégories par nom de Categorie
        /// </summary>
        /// <param name="nom">Nom de la catégorie</param>
        /// <returns></returns>
        public ICollection<Modele> GetModelesByCategorieName(string nom)
        {
            return DbSet.Where(x => x.Categorie.Nom == nom).ToList();
        }
    }
}
