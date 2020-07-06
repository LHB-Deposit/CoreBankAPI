using Dopa;
using DopaApiService.Interfaces;
using DopaApiService.Models;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DopaApiService.Services
{
    
    public class CheckCardStatusService : ICheckCardStatusService
    {
        private readonly CheckCardBankServiceSoap cardBankServiceSoap;
        
        
        public CheckCardStatusService(CheckCardBankServiceSoap cardBankServiceSoap)
        {
            this.cardBankServiceSoap = cardBankServiceSoap;
        }
        public CardInfoResponseModel CheckCardStatusByCID(CardInfoRequestModel requestModel)
        {
            CheckCardBankServiceSoapClient.EndpointConfiguration endpoint = CheckCardBankServiceSoapClient.EndpointConfiguration.CheckCardBankServiceSoap;
            CheckCardBankServiceSoapClient checkCardBank = new CheckCardBankServiceSoapClient(endpoint, "https://idcard.bora.dopa.go.th/CheckCardStatus/CheckCardService.asmx");

            var cIDResponse = checkCardBank.CheckCardByCIDAsync(requestModel.CID, requestModel.PID, requestModel.Bp1No);

            return GetResponse(cIDResponse);
        }

        public CardInfoResponseModel CheckCardStatusByLaser(CardInfoRequestModel requestModel)
        {
            CheckCardBankServiceSoapClient.EndpointConfiguration endpoint = CheckCardBankServiceSoapClient.EndpointConfiguration.CheckCardBankServiceSoap;
            CheckCardBankServiceSoapClient checkCardBank = new CheckCardBankServiceSoapClient(endpoint, "https://idcard.bora.dopa.go.th/CheckCardStatus/CheckCardService.asmx");

            var byLaserResponse = checkCardBank.CheckCardByLaserAsync(requestModel.PID, requestModel.Firstname, requestModel.Lastname, requestModel.BirthDay, requestModel.LaserNumber);

            return GetResponse(byLaserResponse);
        }

        private CardInfoResponseModel GetResponse<T>(T response)
        {
            CardInfoResponseModel responseModel = new CardInfoResponseModel();

            if (typeof(T).Equals(typeof(CheckCardByCIDResponse)))
            {
                var vResp = (CheckCardByCIDResponse)(object)response;
                responseModel.Code = vResp.Body.CheckCardByCIDResult.Code;
                responseModel.Desc = vResp.Body.CheckCardByCIDResult.Desc;
                responseModel.ErrorMessage = vResp.Body.CheckCardByCIDResult.ErrorMessage;
                responseModel.IsError = vResp.Body.CheckCardByCIDResult.IsError;
            } 
            else if (typeof(T).Equals(typeof(CheckCardByLaserResponse)))
            {
                var vResp = (CheckCardByLaserResponse)(object)response;
                responseModel.Code = vResp.Body.CheckCardByLaserResult.Code;
                responseModel.Desc = vResp.Body.CheckCardByLaserResult.Desc;
                responseModel.ErrorMessage = vResp.Body.CheckCardByLaserResult.ErrorMessage;
                responseModel.IsError = vResp.Body.CheckCardByLaserResult.IsError;
            }
            else
            {
                throw new NotSupportedException(typeof(T).Name + " not support");
            }

            return responseModel;
        }
    }
}
