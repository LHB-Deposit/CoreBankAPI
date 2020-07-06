using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DopaApiService.Helpers
{
    public class AppSettings
    {
        public string SECRET { get; set; }
        public string Expiration { get; set; }
        public string UseLocalDB { get; set; }
        public string SQL_USERID { get; set; }
        public string SQL_PASSWD { get; set; }
        public string ISTEST { get; set; }
    }
}
