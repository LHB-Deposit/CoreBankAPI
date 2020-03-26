using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPIService.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterModel register);
        UserProfileResponse Authenticate(AuthenticateModel authenticate);
        IEnumerable<UserProfile> GetUser();
    }
}
