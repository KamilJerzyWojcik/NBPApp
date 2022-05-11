using NBPApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBPApp.Services
{
    public class NBPService : INBPService
    {
        private TableType[] tableTypes => Enum.GetValues(typeof(TableType)) as TableType[];

        public NBPService(INBPApiClient nBPApiClient)
        {
            NBPApiClient = nBPApiClient;
        }

        public INBPApiClient NBPApiClient { get; }

        public async Task<IEnumerable<CurrencyDto>> GetCurrenciesData()
        {

            var currencies = new List<CurrencyDto>();
            
            try
            {
                foreach (var tableType in tableTypes)
                {
                    var response = await NBPApiClient.GetResponse(tableType.ToString().ToLower());

                    if (!response.IsSuccess)
                    {
                        break;
                    }

                    switch (tableType)
                    {
                        case TableType.A:
                        case TableType.B:
                            currencies.AddRange(await NBPApiClient.GetData(response));
                            break;
                        case TableType.C:
                            currencies.AddRange(await NBPApiClient.GetDataRange(response));
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return currencies;
        }


    }
}
