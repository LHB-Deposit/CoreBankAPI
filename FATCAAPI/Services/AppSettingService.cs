using FATCAAPI.Interfaces;
using iSeriesDataAccess.LibraryModel;
using SolutionUtility;
using System;
using System.Collections.Generic;

namespace FATCAAPI.Services
{
    public class AppSettingService : ProjectAppSettings, IAppSettingService
    {

        public AppSettingService() : base()
        {
        }

        public string GetLibrary(string fileName)
        {
            string _lib = string.Empty;
            foreach (var libName in APPSETTING_LIB)
            {
                switch (libName.Key)
                {
                    case nameof(LHBDDATINH):
                        if (HasProperty(new LHBDDATINH(), fileName))
                        {
                            _lib = $"{libName.Value}";
                        }
                        break;
                    case nameof(LHBTDATINH):
                        if (HasProperty(new LHBTDATINH(), fileName))
                        {
                            _lib = $"{libName.Value}";
                        }
                        break;
                    case nameof(LHBPDATINH):
                        if (HasProperty(new LHBPDATINH(), fileName))
                        {
                            _lib = $"{libName.Value}";
                        }
                        break;
                    case nameof(LHBDDATMAS):
                        if (HasProperty(new LHBDDATMAS(), fileName))
                        {
                            _lib = $"{libName.Value}";
                        }
                        break;
                    case nameof(LHBTDATMAS):
                        if (HasProperty(new LHBTDATMAS(), fileName))
                        {
                            _lib = $"{libName.Value}";
                        }
                        break;
                    case nameof(LHBPDATMAS):
                        if (HasProperty(new LHBPDATMAS(), fileName))
                        {
                            _lib = $"{libName.Value}";
                        }
                        break;
                    case nameof(LHBDDATPAR):
                        if (HasProperty(new LHBDDATPAR(), fileName))
                        {
                            _lib = $"{libName.Value}";
                        }
                        break;
                    case nameof(LHBTDATPAR):
                        if (HasProperty(new LHBTDATPAR(), fileName))
                        {
                            _lib = $"{libName.Value}";
                        }
                        break;
                    case nameof(LHBPDATPAR):
                        if (HasProperty(new LHBPDATPAR(), fileName))
                        {
                            _lib = $"{libName.Value}";
                        }
                        break;
                    default:
                        throw new ArgumentNullException();
                }
            }
            return _lib;
        }
        public string GetLibJob(string jobName)
        {
            string _jobName = string.Empty;
            foreach (var file in APPSETTING_LIBJOB)
            {
                switch (file.Key)
                {
                    case nameof(LHBDRUNINH):
                        if (HasProperty(new LHBDRUNINH(), jobName))
                        {
                            _jobName = $"{file.Value}";
                        }
                        break;
                    case nameof(LHBTRUNINH):
                        if (HasProperty(new LHBTRUNINH(), jobName))
                        {
                            _jobName = $"{file.Value}";
                        }
                        break;
                    case nameof(LHBPRUNINH):
                        if(HasProperty(new LHBPRUNINH(), jobName))
                        {
                            _jobName = $"{file.Value}";
                        }
                        break;
                    default:
                        throw new ArgumentNullException();
                }
            }
            return _jobName;
        }
        private bool HasProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }
    }
}