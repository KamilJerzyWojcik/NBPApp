using NBPApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBPApp.Services
{
    public interface INBPApiClient
    {
        Task<IEnumerable<CurrencyDto>> GetData(Response response);
        Task<IEnumerable<CurrencyDto>> GetDataRange(Response response);
        Task<Response> GetResponse(string tableType);
    }
}
