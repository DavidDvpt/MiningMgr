using System.Collections.Generic;
using System.Linq;
using Services.Context;
using Model;
using Services.Interfaces;

namespace Services
{
    /// <summary>
    /// Gestion du DbSet Material
    /// </summary>
    public class MaterialService : CommunService<Material>, IMaterialService
    {
        #region Constructeur

        //public MaterialService(MiningContext ctx)
        //    : base(ctx)
        //{

        //}

        #endregion

        /// <summary>
        /// Retourne tous les matériaux par Modele Id
        /// </summary>
        /// <param name="id">Id du modèle</param>
        /// <returns></returns>
        public ICollection<Material> GetByModeleId(int id)
        {
            return DbSet.Where(x => x.ModeleId == id).OrderBy(x=>x.Nom).ToList();
        }

        /// <summary>
        /// Retourne tous les matériaux par nom de Modele
        /// </summary>
        /// <param name="nom">Nom du modele</param>
        /// <returns></returns>
        public ICollection<Material> GetByModeleName(string nom)
        {
            return DbSet.Where(x => x.Modele.Nom == nom).OrderBy(x => x.Nom).ToList();
        }
    }
}
