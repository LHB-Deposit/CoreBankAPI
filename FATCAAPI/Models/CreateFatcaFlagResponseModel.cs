using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATCAAPI.Models
{
    public class CreateFatcaFlagResponseModel : BaseResponseModel
    {
        public string ReferenceKey { get; set; } = string.Empty;
    }
}