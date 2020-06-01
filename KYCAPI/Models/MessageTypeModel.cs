using SolutionUtility;

namespace KYCAPI.Models
{
    public class MessageTypeModel
    {
        [MatchParent("MessageType")]
        public string MessageType { get; set; }

        [MatchParent("TranCode")]
        public string TranCode { get; set; }

        [MatchParent("Seq")]
        public int Seq { get; set; }

        [MatchParent("FieldName")]
        public string FieldName { get; set; }

        [MatchParent("Length")]
        public string Length { get; set; }

        [MatchParent("DataType")]
        public string DataType { get; set; }

        [MatchParent("StartIndex")]
        public int StartIndex { get; set; }

        [MatchParent("EndIndex")]
        public int EndIndex { get; set; }

        [MatchParent("Mandatory")]
        public string Mandatory { get; set; }

        [MatchParent("Description")]
        public string Description { get; set; }

        [MatchParent("DefaultValue")]
        public string DefaultValue { get; set; }

        [MatchParent("Remark")]
        public string Remark { get; set; }
    }
}