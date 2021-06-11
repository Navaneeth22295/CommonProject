using MAFIL.Common.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MAFIL.Common.DB.Infrastructure.Data
{
    public class AuditDbContext : DbContext, IAuditContext
    {
        private readonly IOptions<AppSettings> _appSetting;

        #region constrcutors
        public AuditDbContext(DbContextOptions<AuditDbContext> options): base(options)
        {

        }

        public AuditDbContext(IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSetting = appSettings;
        }

        public AuditDbContext(IServiceProvider serviceProvider,
            IOptions<AppSettings> appSettings,
            IHttpContextAccessor httpContextAccessor) : base()
        {
            _appSetting = appSettings;
        }

        public AuditDbContext(DbContextOptions options,
            IOptions<AppSettings> appSettings,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _appSetting = appSettings;

        }


        public AuditDbContext(IServiceProvider serviceProvider,
             DbContextOptions options,
            IOptions<AppSettings> appSettings,
            IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _appSetting = appSettings;

        }

        #endregion constrcutors

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public virtual int SaveChanges(object userName)
        {
            return base.SaveChanges();
        }

        public async virtual Task<int> SaveChangesAsync(string userName)
        {
            return await base.SaveChangesAsync(default(CancellationToken));
        }

        public async virtual Task<int> SaveChangesAsync(int userId)
        {
            return await base.SaveChangesAsync(default(CancellationToken));
        }

        public async virtual Task<int> SaveChangesAsync(object userName, CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
