using MBaseAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class HeaderMessageModel : MBaseHeaderMessage
    {
        public int InputLength { get; set; }
    }
}