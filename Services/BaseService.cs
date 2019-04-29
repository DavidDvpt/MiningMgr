using Services.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Services
{
    public class BaseService<T> : IBaseService<T>
        where T : class, new()
    {
        #region Champs

        protected static MiningContext ctx;

        protected static MiningContext GetContext()
        {
             return ctx = ctx ?? new MiningContext();
        }

        #endregion

        #region Constructeur

        //public BaseService(MiningContext context)
        //{
        //    ctx = context ?? throw new ArgumentNullException("Null DbContext");
        //    DbSet = ctx.Set<T>();
        //}

        public BaseService()
        {
            DbSet = GetContext().Set<T>();
        }

        #endregion

        #region Proprietes

        public DbSet<T> DbSet { get; private set;}

        #endregion

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T Add(T entity)
        {
            AttachEntity(entity, EntityState.Added);
            DbSet.Add(entity);
            Commit();

            return entity;
        }

        public void AddRange(List<T> entities)
        {
            List<T> list = new List<T>();
            foreach (T entity in entities)
            {
                DbSet.Add(AttachEntity(entity, EntityState.Added));
            }

            Commit();
        }

        public void Update(T entity)
        {
            AttachEntity(entity, EntityState.Modified);

            Commit();
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = ctx.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }

            Commit();
        }

        private T AttachEntity(T entity, EntityState state)
        {
            DbEntityEntry dbEntityEntry = ctx.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = state;
            }

            return entity;
        }

        public void Commit()
        {
            ctx.SaveChanges();
        }

        //public MiningContext GetContext()
        //{
        //    return ctx;
        //}
    }
}
