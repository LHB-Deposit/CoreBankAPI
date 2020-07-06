using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DopaApiService.Models
{
    public class CardInfoRequestModel : BaseRequestModel
    {
        [Required]
        public string PID { get; set; }
        public string CID { get; set; }
        public string Bp1No { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string BirthDay { get; set; }
        public string LaserNumber { get; set; }
    }
}
