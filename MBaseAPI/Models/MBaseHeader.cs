using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class MBaseHeader : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string TranCode { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string ScenarioNumber { get; set; }

        [MaxLength(1)]
        [Column(TypeName = "varchar(1)")]
        public string ActionMode { get; set; }

        [MaxLength(1)]
        [Column(TypeName = "varchar(1)")]
        public string TransactionMode { get; set; }

        [MaxLength(2)]
        [Column(TypeName = "varchar(2)")]
        public string NumberOfRectoRetrieve { get; set; }

        public int InputLength { get; set; }
        public int ResponseLength { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }
    }
}