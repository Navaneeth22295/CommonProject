using MAFIL.Common.DB.Domain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAFIL.Common.DB
{
    [Table("APP_USER_ROLE")]
    public class UserRole : BaseEntity //IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
