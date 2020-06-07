using ConsentAPI.Interfaces;
using iSeriesDataAccess.LibraryModel;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ConsentAPI.Services
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
                        if (HasProperty(new LHBDDATINH(), fileName))
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

        private bool HasProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }
    }
}