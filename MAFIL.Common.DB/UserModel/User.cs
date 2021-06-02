using MAFIL.Common.DB.Domain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAFIL.Common.DB
{
    [Table("APP_USER")]
    public class User: BaseEntity // IdentityUser<int>
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int OTP { get; set; }
        public int EmailOTP { get; set; }

    }
}
