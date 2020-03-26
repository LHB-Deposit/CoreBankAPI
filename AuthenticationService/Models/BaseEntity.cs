using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPIService.Models
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
