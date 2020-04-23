using ParameterAPI.Helpers;
using ParameterAPI.Models;
using System.Collections.Generic;

namespace ParameterAPI.Interfaces
{
    public interface IAs400Service
    {
        IEnumerable<ParameterModel> GetBOTOccupation(AppSettings appSettings);
        IEnumerable<ParameterModel> GetBusinessType(AppSettings appSettings);
        IEnumerable<ParameterModel> GetDocumentType(AppSettings appSettings);
        IEnumerable<ParameterModel> GetEducationLevel(AppSettings appSettings);
        IEnumerable<ParameterModel> GetOccupation(AppSettings appSettings);
        IEnumerable<ParameterModel> GetOccupationRisk(AppSettings appSettings);
        IEnumerable<ParameterModel> GetPrefixName(AppSettings appSettings);
        IEnumerable<ParameterModel> GetStatus(AppSettings appSettings);

        IEnumerable<ParameterModel> GetParameter(AppSettings appSettings, string[] condition = null);
        IEnumerable<ParameterModel> ExecuteGetParameter(string sql);
        IEnumerable<ParameterModel> GetAccountType(AppSettings appSettings);
        IEnumerable<ParameterModel> GetSourceOfIncome(AppSettings appSettings);
        IEnumerable<ParameterModel> GetSourceOfIncomeCorp(AppSettings appSettings);
        IEnumerable<ParameterModel> GetCountry(AppSettings appSettings);
        IEnumerable<ParameterModel> GetPurposeOfAccountOpen(AppSettings appSettings);
        IEnumerable<ParameterModel> GetPurposeOfAccountOpenCorp(AppSettings appSettings);
        IEnumerable<ParameterModel> GetSourceOfDeposit(AppSettings appSettings);
        IEnumerable<ParameterModel> GetSourceOfDepositCorp(AppSettings appSettings);
    }
}
