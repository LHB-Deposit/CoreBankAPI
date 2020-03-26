using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Models
{
    public class UserLevel : BaseEntity
    {
        [MaxLength(2)]
        [Column(TypeName = "varchar(2)")]
        public string UserLevelCode { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string UserLevelName { get; set; }
    }
}
