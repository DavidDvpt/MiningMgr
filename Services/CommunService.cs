using Model;
using System.Data.Entity;
using Services.Context;
using System.Linq;
using Services.Interfaces;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace Services
{
    /// <summary>
    /// Classe de base pour toutes les entités qui ont un nom
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommunService<T> : BaseService<T>, ICommunService<T>
        where T : Commun, new()
    {
        #region Constructeur

        //public CommunService(MiningContext ctx)
        //    : base(ctx)
        //{
        //}

        #endregion


        public T GetByNom(string nom)
        {
            return DbSet.FirstOrDefault(x => x.Nom == nom);
        }

        public override IQueryable<T> GetAll()
        {
            return DbSet.OrderBy(x => x.Nom);
        }



    }
}
