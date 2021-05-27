using MAFIL.Common.DB.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace MAFIL.Common.DB.Infrastructure.Dapper
{
    public class BaseRepository<T> : IDapper<T> where T : BaseEntity
    {
        private IDbConnection _dbConnection;

        public BaseRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
