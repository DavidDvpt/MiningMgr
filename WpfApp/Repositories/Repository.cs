using WpfApp.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using WpfApp.Context;

namespace WpfApp.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class, new()
    {
        protected MiningContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public Repository(MiningContext ctx)
        {
            Context = ctx ?? throw new ArgumentNullException("Null DbContext");
            DbSet = Context.Set<T>();
        }

        public T Add(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
            SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            //dbEntityEntry.State = EntityState.Deleted;
            SaveChanges();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
