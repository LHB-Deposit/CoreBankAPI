﻿using MBaseAPI.Models;
using System.Collections.Generic;

namespace MBaseAPI.Interfaces
{
    public interface ISQLService
    {
        MBaseHeaderModel GetMBaseHeader(string tranCode);
        IEnumerable<MBaseMessageTypeModel> GetMBaseResponseMessages(string tranCode);
        IEnumerable<MBaseMessageTypeModel> GetMBaseHeaderMessages(string tranCode);
        IEnumerable<MBaseMessageTypeModel> GetMBaseInputMessages(string tranCode);

        void AddMBaseMessage(MBaseMessageTypeModel message);
    }
}
