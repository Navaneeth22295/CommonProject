using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAFIL.Common.DB.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Created_On = new DateTime();
            this.Update_On = new DateTime();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public int? Update_By { get; set; }
        public DateTime? Update_On { get; set; }



    }
}
