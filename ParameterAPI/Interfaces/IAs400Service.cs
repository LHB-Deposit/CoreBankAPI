using ParameterAPI.Helpers;
using ParameterAPI.Models;
using System.Collections.Generic;

namespace ParameterAPI.Interfaces
{
    public interface IAs400Service
    {
        IEnumerable<ParameterResponseModel> GetBOTOccupation(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetBusinessType(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetDocumentType(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetEducationLevel(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetOccupation(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetOccupationRisk(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetPrefixName(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetStatus(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetState(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetAddressType(AS400AppSettingModel appSettings);

        IEnumerable<ParameterResponseModel> GetParameter(AS400AppSettingModel appSettings, string[] condition = null, string keyconcat = "");
        IEnumerable<ParameterResponseModel> ExecuteGetParameter(string sql);
        IEnumerable<ParameterResponseModel> GetAccountType(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetSourceOfIncome(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetSourceOfIncomeCorp(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetCountry(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetPurposeOfAccountOpen(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetPurposeOfAccountOpenCorp(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetSourceOfDeposit(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetSourceOfDepositCorp(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetFatcaDescription(AS400AppSettingModel appSettings);
        IEnumerable<ParameterResponseModel> GetCountryRisk(AS400AppSettingModel appSettings);
    }
}
