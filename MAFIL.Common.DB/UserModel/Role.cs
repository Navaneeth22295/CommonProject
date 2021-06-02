using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using MAFIL.Common.DB.Domain;

namespace MAFIL.Common.DB
{
    [Table("APP_ROLE")]
    public class Role : BaseEntity  // IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
