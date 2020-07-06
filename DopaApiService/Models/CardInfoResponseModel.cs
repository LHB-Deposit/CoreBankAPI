using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DopaApiService.Models
{
    public class CardInfoResponseModel : BaseResponseModel
    {
        public int Code { get; set; }
        public string Desc { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsError { get; set; }
        public string RefNo { get; set; }
    }
}
