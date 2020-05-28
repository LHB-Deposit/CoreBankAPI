using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace MBaseAccess.Entity
{
    public class MBaseHeaderMessage
    {
        [Required]
        [MatchParent("SocketMessageLength")]
        public string SKTMLEN { get; set; }

        [Required]
        [MatchParent("HeaderType")]
        public string SKTHEAD { get; set; }

        [Required]
        [MatchParent("DeviceName")]
        public string SKTDEVN { get; set; }

        [MatchParent("SocketNumber")]
        public string SKTSKNB { get; set; }

        [MatchParent("PortNumber")]
        public string SKTPORT { get; set; }

        [MatchParent("Filler1Character")]
        public string SKTFILL { get; set; }

        [MatchParent("HeaderLength")]
        public string I13HLEN { get; set; }

        [MatchParent("MessageLength")]
        public string I13MLEN { get; set; }

        [MatchParent("VersionNumber")]
        public string I13VERS { get; set; }

        [MatchParent("HeaderFormatId")]
        public string I13HFMID { get; set; }

        [Required]
        [MatchParent("DataFormatId")]
        public string I13FMID { get; set; }

        [Required]
        [MatchParent("SourceId")]
        public string I13SID { get; set; }

        [MatchParent("DestinationId")]
        public string I13DID { get; set; }

        [MatchParent("RoutingNumber")]
        public string I13RTGN { get; set; }

        [MatchParent("MessageStatus")]
        public string I13MSTA { get; set; }

        [MatchParent("BankIdNumber")]
        public string I13BIN { get; set; }

        [MatchParent("Node")]
        public string I13NODE { get; set; }

        [MatchParent("ExchangeId")]
        public string I13XID { get; set; }

        [Required]
        [MatchParent("ScenarioNumber")]
        public string I13SSNO { get; set; }

        [Required]
        [MatchParent("TransactionCode")]
        public string I13TRCD { get; set; }

        [MatchParent("RetrievalReferenceNumber")]
        public string I13RRNO { get; set; }

        [MatchParent("AcquirerReferenceNumber")]
        public string I13ACQN { get; set; }

        [MatchParent("TransmissionNumber")]
        public string I13TMNO { get; set; }

        [MatchParent("NumberOfRecordsToBeLoaded")]
        public string I13NREC { get; set; }

        [MatchParent("NumberOfErrorsToBeLoaded")]
        public string I13NERR { get; set; }

        [Required]
        [MatchParent("UserId")]
        public string I13USER { get; set; }

        [Required]
        [MatchParent("TerminalId")]
        public string I13TMID { get; set; }

        [MatchParent("SupervisorId")]
        public string I13SUPV { get; set; }

        [Required]
        [MatchParent("MoreRecordIndicator")]
        public string I13MORE { get; set; }

        [MatchParent("CutoffIndicator")]
        public string I13CUTO { get; set; }

        [MatchParent("UserData")]
        public string I13UDTA { get; set; }

        [MatchParent("ResponseResultCode")]
        public string HDRIND { get; set; }

        [Required]
        [MatchParent("HUserID")]
        public string HDUSID { get; set; }

        [Required]
        [MatchParent("ReferenceNumber")]
        public string HDRNUM { get; set; }

        [MatchParent("RebidNumber")]
        public string HDRBID { get; set; }

        [Required]
        [MatchParent("EndOfGroupIndicator")]
        public string HDEGPI { get; set; }

        [MatchParent("BlockMessageNumber")]
        public string HDBMSG { get; set; }

        [Required]
        [MatchParent("AppSourceID")]
        public string HDSRID { get; set; }

        [Required]
        [MatchParent("DestinationID")]
        public string HDDSID { get; set; }

        [MatchParent("ReturnDataQueueName")]
        public string HDRTDQ { get; set; }

        [Required]
        [MatchParent("ComputerTerminalID")]
        public string HDTMID { get; set; }

        [Required]
        [MatchParent("BankNumber")]
        public string HDBKNO { get; set; }

        [Required]
        [MatchParent("BranchNumber")]
        public string HDBRNO { get; set; }

        [MatchParent("ReviewSupervisorIdLocal")]
        public string HDRSID { get; set; }

        [MatchParent("TransmitSupervisorIdLocal")]
        public string HDTSID { get; set; }

        [MatchParent("HostSupervisorId")]
        public string HDHSID { get; set; }

        [Required]
        [MatchParent("TransactionCode")]
        public string HDTXCD { get; set; }

        [Required]
        [MatchParent("ActionCode")]
        public string HDACCD { get; set; }

        [Required]
        [MatchParent("TransactionMode")]
        public string HDTMOD { get; set; }

        [Required]
        [MatchParent("NoOfRecordsToRetrieve")]
        public string HDNREC { get; set; }

        [Required]
        [MatchParent("MoreRecordsIndicator")]
        public string HDMREC { get; set; }

        [Required]
        [MatchParent("SearchMethod")]
        public string HDSMTD { get; set; }

        [MatchParent("ResponseErrorCode1")]
        public string HDRCD1 { get; set; }

        [MatchParent("ResponseReasonForCode1")]
        public string HDRRE1 { get; set; }

        [MatchParent("ResponseErrorCode2")]
        public string HDRCD2 { get; set; }

        [MatchParent("ResponseReasonForCode2")]
        public string HDRRE2 { get; set; }

        [MatchParent("ResponseErrorCode3")]
        public string HDRCD3 { get; set; }

        [MatchParent("ResponseReasonForCode3")]
        public string HDRRE3 { get; set; }

        [MatchParent("ResponseErrorCode4")]
        public string HDRCD4 { get; set; }

        [MatchParent("ResponseReasonForCode4")]
        public string HDRRE4 { get; set; }

        [MatchParent("ResponseErrorCode5")]
        public string HDRCD5 { get; set; }

        [MatchParent("ResponseReasonForCode5")]
        public string HDRRE5 { get; set; }

        [Required]
        [MatchParent("DateInFromClient")]
        public string HDDTIN { get; set; }

        [Required]
        [MatchParent("TimeInFromClient")]
        public string HDTMIN { get; set; }

        [MatchParent("AccountNo")]
        public string HDACTN { get; set; }

        [MatchParent("AccountType")]
        public string HDACTY { get; set; }

        [MatchParent("CIFNo")]
        public string HDCIFN { get; set; }

        [MatchParent("Filler")]
        public string HDFILR { get; set; }
    }
}
