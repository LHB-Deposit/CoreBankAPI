using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Entity
{
    public class RequestBaseEntity
    {
        [Required]
        [MaxLength(7)]
        public string ReferenceNo { get; set; }
    }
}
