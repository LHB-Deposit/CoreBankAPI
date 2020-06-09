using ConsentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsentAPI.Interfaces
{
    public interface IAs400Service
    {
        VerifyConsentResponseModel VerifyConsent(VerifyConsentRequestModel requestModel);
        CreateConsentResponseModel CreateConsent(CreateConsentRequestModel requestModel);
    }
}
