using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class MBaseMessage
    {
        public string MessageType { get; set; }
        public string TranCode { get; set; }
        public int Seq { get; set; }
        public string FieldName { get; set; }
        public string Length { get; set; }
        public string DataType { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public string Mandatory { get; set; }
        public string Description { get; set; }
        public string DefaultValue { get; set; }
        public string Remark { get; set; }

    }
}