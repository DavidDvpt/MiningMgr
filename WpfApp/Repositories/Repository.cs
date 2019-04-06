using WpfApp.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using WpfApp.Context;
using WpfApp.Model.Poco.Interfaces;
using WpfApp.Tools;

namespace WpfApp.Repositories
{
    public class Repository<TDto, TPoco> : IRepository<TDto, TPoco>
        where TDto : class, new()
        where TPoco : class, IPoco<TDto>, new()
    {
        protected MiningContext Context { get; set; }

        protected DbSet<TDto> DbSet { get; set; }

        public Repository(MiningContext ctx)
        {
            Context = ctx ?? throw new ArgumentNullException("Null DbContext");
            DbSet = Context.Set<TDto>();
        }

        public TPoco Add(TPoco entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity.GetDto());
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity.GetDto());
            }
            SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            TPoco entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public void Delete(TPoco entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity.GetDto());
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity.GetDto());
                DbSet.Remove(entity.GetDto());
            }
            SaveChanges();
        }

        public IQueryable<TPoco> GetAll()
        {
            return DbSet.ToPocoIQueryable<TDto, TPoco>();
        }

        public TPoco GetById(int id)
        {
            return DbSet.Find(id).ToPoco<TDto, TPoco>();
        }

        public void Update(TPoco entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity.GetDto());
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity.GetDto());
            }
            dbEntityEntry.State = EntityState.Deleted;
            SaveChanges();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
