using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace iSeriesDataAccess.FileModel
{
    public class DPI2195F1
    {
        [MatchParent("CustomerId")]
        [StringLength(15)]
        public string F1ID { get; set; }

        [MatchParent("CustomerNumber")]
        [StringLength(19)]
        public string F1CIFNO { get; set; }

        [MatchParent("FatcaFlag")]
        [StringLength(1)]
        public string F1STS { get; set; }

        [MatchParent("FatcaCode")]
        [StringLength(10)]
        public string F1COD { get; set; }

        [MatchParent("CorporationGroup")]
        [StringLength(4)]
        public string F1CGRP { get; set; }

        [MatchParent("SocialSecurityNumber")]
        [StringLength(15)]
        public string F1SSN { get; set; }

        [MatchParent("GIIN")]
        [StringLength(19)]
        public string F1GIIN { get; set; }

        [MatchParent("DocumentDate6")]
        [StringLength(6)]
        public string F1DODT6 { get; set; }

        [MatchParent("DocumentDate7")]
        [StringLength(7)]
        public string F1DODT7 { get; set; }

        [MatchParent("LastUpdateBranch")]
        [StringLength(3)]
        public string F1UBRN { get; set; }

        [MatchParent("LastUpdateDate6")]
        [StringLength(6)]
        public string F1UDT6 { get; set; }

        [MatchParent("LastUpdateDate7")]
        [StringLength(7)]
        public string F1UDT7 { get; set; }

        [MatchParent("LastUpdateTime")]
        [StringLength(6)]
        public string F1UTIM { get; set; }

        [MatchParent("LastUser")]
        [StringLength(10)]
        public string F1UUSR { get; set; }

        [MatchParent("Temp1")]
        [StringLength(15)]
        public string F1TMP1 { get; set; }

        [MatchParent("Temp2")]
        [StringLength(40)]
        public string F1TMP2 { get; set; }

        [MatchParent("Temp3")]
        [StringLength(60)]
        public string F1TMP3 { get; set; }

    }
}
