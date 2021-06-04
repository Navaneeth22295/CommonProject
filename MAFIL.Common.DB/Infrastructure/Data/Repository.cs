using MAFIL.Common.DB.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MAFIL.Common.DB.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbSet<T> DbSet;

        protected DbContext _dbContext;

        public Repository(DbContext dataContext)
        {
            _dbContext = dataContext;
            DbSet = dataContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual void Create(T entity)
        {
            DbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void CreateCollection(IEnumerable<T> entity)
        {
            DbSet.AddRange(entity);
            _dbContext.SaveChanges();
        }

        public virtual void CreateWithoutCommit(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual int CreateWithReturnId(T entity)
        {
            DbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual void DeleteWithoutCommit(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void DeleteCollection(IEnumerable<T> entity)
        {
            foreach (var item in entity)
                DbSet.Remove(item);
            _dbContext.SaveChanges();
        }

        public virtual void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
