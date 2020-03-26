using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Models
{
    public class UserProfileResponse
    {
        public string UserId { get; set; }
        public string AccessToken { get; set; }
    }
}
