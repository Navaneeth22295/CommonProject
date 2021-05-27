using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAFIL.Common.DB.Infrastructure.Data
{
    public class BaseSecurityDBContext : DbContext
    {
        private readonly IOptions<AppSettings> _appSetting;

        public BaseSecurityDBContext(IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSetting = appSettings;
        }

        public BaseSecurityDBContext(IServiceProvider serviceProvider, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSetting = appSettings;
        }

        public BaseSecurityDBContext(DbContextOptions options, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSetting = appSettings;
        }

        public BaseSecurityDBContext(IServiceProvider serviceProvider, DbContextOptions options, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSetting = appSettings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SetUpCommonEntity(modelBuilder);

        }

        protected virtual void SetUpCommonEntity(ModelBuilder modelBuilder)
        {

        }
    }
}
