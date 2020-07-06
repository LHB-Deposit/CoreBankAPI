using DopaApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DopaApiService.Interfaces
{
    public interface ICheckCardStatusService
    {
        CardInfoResponseModel CheckCardStatusByCID(CardInfoRequestModel resquestModel);
        CardInfoResponseModel CheckCardStatusByLaser(CardInfoRequestModel resquestModel);
    }
}
