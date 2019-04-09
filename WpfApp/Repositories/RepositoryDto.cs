using WpfApp.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using WpfApp.Context;

namespace WpfApp.Repositories
{
    public class RepositoryDto<TDto> : IRepositoryDto<TDto>
        where TDto : class, new()
    {
        protected MiningContext Context { get; set; }

        protected DbSet<TDto> DbSet { get; set; }

        public RepositoryDto(MiningContext ctx)
        {
            Context = ctx ?? throw new ArgumentNullException("Null DbContext");
            DbSet = Context.Set<TDto>();
        }

        public TDto Add(TDto entity)
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
            TDto entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public void Delete(TDto entity)
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

        public IQueryable<TDto> GetAll()
        {
            return DbSet;
        }

        public TDto GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(TDto entity)
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
