using NBPApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBPApp.Services
{
    public interface INBPService
    {
        Task<IEnumerable<CurrencyDto>> GetCurrenciesData();
    }
}
