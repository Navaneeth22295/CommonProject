using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MAFIL.Common.DB.Infrastructure.Data
{
    public interface IAuditContext : IDbContext
    {
        int SaveChanges(object userName);

        //async
        Task<int> SaveChangesAsync(object userName, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(int userId);
        Task<int> SaveChangesAsync(string userName);
    }
}
