using DataAccess;
using ParameterAPIService.Models;
using System.Collections.Generic;

namespace ParameterAPIService.Interfaces
{
    public interface IParameterServices
    {
        IEnumerable<ParameterModel> GetBOTOccupation(ProjectAppSettings app);
        IEnumerable<ParameterModel> GetBusinessType(ProjectAppSettings app);
        IEnumerable<ParameterModel> GetDocumentType(ProjectAppSettings app);
        IEnumerable<ParameterModel> GetEducationLevel(ProjectAppSettings app);
        IEnumerable<ParameterModel> GetOccupationRisk(ProjectAppSettings app);
        IEnumerable<ParameterModel> GetPrefixName(ProjectAppSettings app);
        IEnumerable<ParameterModel> GetStatus(ProjectAppSettings app);

        IEnumerable<ParameterModel> ExecuteGetParameter(string sql);
    }
}
