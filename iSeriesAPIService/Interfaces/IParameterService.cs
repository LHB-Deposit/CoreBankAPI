using iSeriesAPIService.Helpers;
using iSeriesAPIService.Models;
using System.Collections.Generic;

namespace iSeriesAPIService.Interfaces
{
    public interface IParameterService
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
    }
}
