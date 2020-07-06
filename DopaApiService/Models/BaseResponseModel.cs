using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DopaApiService.Models
{
    public class BaseResponseModel
    {
        public StatusResponseModel Status { get; set; }
        public string Data { get; set; }
    }
}
