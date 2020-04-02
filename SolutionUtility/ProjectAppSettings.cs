using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtility
{
    public class ProjectAppSettings
    {
        public string SECRET { get; set; }
        public string Expiration { get; set; }
        public int DbTimeout { get; set; }
        public string Local_SQLConnection { get; set; }
        public string DEV_SQLConnection { get; set; }
        public string PRD_SQLConnection { get; set; }
        public string DEV_AS400Connection { get; set; }
        public string PRD_AS400Connection { get; set; }
        public string DEV_SQL_USERID { get; set; }
        public string DEV_SQL_PASSWD { get; set; }
        public string DEV_AS400_USERID { get; set; }
        public string DEV_AS400_PASSWD { get; set; }
        public string PRD_SQL_USERID { get; set; }
        public string PRD_SQL_PASSWD { get; set; }
        public string PRD_AS400_USERID { get; set; }
        public string PRD_AS400_PASSWD { get; set; }
        public string ISTEST { get; set; }
        public string UseLocalDB { get; set; }
        public string LIB { get; set; }
        public string FILE { get; set; }
        public string KEY { get; set; }
        public string VALUE { get; set; }
    }
}
