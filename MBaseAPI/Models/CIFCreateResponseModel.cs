using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class CIFCreateResponseModel
    {
        public string CustomerNumber { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
    }
}