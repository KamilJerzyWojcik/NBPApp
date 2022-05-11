using NBPApp.Models;
using System.Collections.Generic;

namespace NBPApp.Services
{
    public interface INBPApiClient
    {
        IEnumerable<CurrencyDto> Get();
    }
}
