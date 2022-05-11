using NBPApp.Models;
using System.Collections.Generic;

namespace NBPApp.Services
{
    public interface INBPHelper
    {
        void SetResult(string result);
        void AddData(List<CurrencyDto> data);
        string GetTypeMedia();
    }
}
