using MAFIL.Common.DB.Domain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAFIL.Common.DB
{
    [Table("APP_USER")]
    public class User: BaseEntity //IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int OTP { get; set; }
        public int EmailOTP { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
