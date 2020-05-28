using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class MBaseMessageModel
    {
        public HeaderTransactionModel HeaderTransaction { get; set; }
        public IEnumerable<MessageTypeModel> HeaderMessages { get; set; }
        public IEnumerable<MessageTypeModel> InputMessages { get; set; }
        public IEnumerable<MessageTypeModel> ResponseMessages { get; set; }
    }
}