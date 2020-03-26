using AuthenticationAPIService.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationService.Models
{
    public class UserProfile : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string UserId { get; set; }

        [MaxLength(2)]
        [Column(TypeName = "varchar(2)")]
        public string UserLevel { get; set; }

        [MaxLength(300)]
        [Column(TypeName = "nvarchar(300)")]
        public string NameTH { get; set; }

        [MaxLength(300)]
        [Column(TypeName = "varchar(300)")]
        public string NameEN { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")] 
        public string Email { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Department { get; set; }

        [Column(TypeName = "text")]
        public string Hash { get; set; }

        [Column(TypeName = "text")]
        public string Salt { get; set; }

        public bool ActiveStatus { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string IPAddress { get; set; }

        public DateTime? LastUsage { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogout { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
