﻿using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIFAPI.Models
{
    public class CreateCifAndAccountResponseModel : BaseResponseModel
    {
        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; } = string.Empty;

        [MatchParent("CFACCTNO")]
        public string AccountNumber { get; set; } = string.Empty;

        [MatchParent("CFACCTYP")]
        public string AccountType { get; set; } = string.Empty;
    }
}