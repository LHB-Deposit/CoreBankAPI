using ParameterAPI.Helpers;
using ParameterAPI.Models;
using System.Collections.Generic;

namespace ParameterAPI.Interfaces
{
    public interface IAs400Service
    {
        IEnumerable<ParameterModel> GetBOTOccupation(AppSettings app);
        IEnumerable<ParameterModel> GetBusinessType(AppSettings app);
        IEnumerable<ParameterModel> GetDocumentType(AppSettings app);
        IEnumerable<ParameterModel> GetEducationLevel(AppSettings app);
        IEnumerable<ParameterModel> GetOccupationRisk(AppSettings app);
        IEnumerable<ParameterModel> GetPrefixName(AppSettings app);
        IEnumerable<ParameterModel> GetStatus(AppSettings app);

        IEnumerable<ParameterModel> GetParameter(AppSettings app, string[] condition = null);
        IEnumerable<ParameterModel> ExecuteGetParameter(string sql);

        IEnumerable<ParameterModel> GetAccountType(AppSettings appSettings);
    }
}
