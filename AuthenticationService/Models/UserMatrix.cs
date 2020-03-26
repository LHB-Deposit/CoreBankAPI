using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Models
{
    public class UserMatrix : BaseEntity
    {
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string UserLevel { get; set; }

        [MaxLength(6)]
        [Column(TypeName = "varchar(6)")]
        public string FunctionCode { get; set; }
    }
}
