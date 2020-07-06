using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DopaApiService.Interfaces;
using DopaApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DopaApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckCardStatusController : ControllerBase
    {
        private readonly ICheckCardStatusService cardService;

        public CheckCardStatusController(ICheckCardStatusService cardService)
        {
            this.cardService = cardService;
        }

        [HttpPost]
        public CardInfoResponseModel CheckCardStatusByCID([FromBody] CardInfoRequestModel requestModel)
        {
            return cardService.CheckCardStatusByCID(requestModel);
        }

        [HttpPost]
        public CardInfoResponseModel CheckCardStatusByLaser([FromBody] CardInfoRequestModel requestModel)
        {
            return cardService.CheckCardStatusByLaser(requestModel);
        }
    }
}
