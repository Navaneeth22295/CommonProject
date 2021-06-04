using System.Collections.Generic;
using System.Linq;

namespace MAFIL.Common.DB.Domain
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void CreateCollection(IEnumerable<T> entity);
        int CreateWithReturnId(T entity);
        void SaveChanges();

        void CreateWithoutCommit(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWithoutCommit(T entity);

        void DeleteCollection(IEnumerable<T> entity);

    }
}
