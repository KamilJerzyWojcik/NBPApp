using NBPApp.Models;
using System.Collections.Generic;

namespace NBPApp.Services
{
    public interface INBPHelper
    {
        void SetResult(string result);
        List<CurrencyDto> GetData();
        string GetTypeMedia();
        List<CurrencyDto> GetDataRange();
    }
}
