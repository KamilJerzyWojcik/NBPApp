using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using NBPApp.Services;

namespace NBPApp.Models
{

    public class NBPApiClient : INBPApiClient
    {
        private HttpClient client;
        private Uri url(string tableType) => new Uri($"http://api.nbp.pl/api/exchangerates/tables/{tableType}");
        private Uri baseAdress => new Uri("http://api.nbp.pl/");
        private string[] tableTypes => new string[] { "a", "b", "c" };

        public INBPHelper NBPHelper { get; }
        public IHttpClientFactory HttpClientFactory { get; }

        public NBPApiClient(INBPHelper nBPHelper, IHttpClientFactory httpClientFactory)
        {
            NBPHelper = nBPHelper;
            HttpClientFactory = httpClientFactory;
        }

        private NBPApiClient cofigureClient()
        {
            client = HttpClientFactory.CreateClient(); ;
            client.BaseAddress = baseAdress;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(NBPHelper.GetTypeMedia()));
            return this;
        }

        private void addData(List<CurrencyDto> data, string result)
        {
            NBPHelper.SetResult(result);
            NBPHelper.AddData(data);
        }

        private async Task<List<CurrencyDto>> getAsync(string path)
        {
            var data = new List<CurrencyDto>();
            var response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                addData(data, result);
            }
            return data;
        }

        private async Task<IEnumerable<CurrencyDto>> runAsync()
        {

            var currencies = new List<CurrencyDto>();
            try
            {
                foreach (var t in tableTypes)
                {
                    var result = await getAsync(url(t).PathAndQuery);
                    currencies.AddRange(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return currencies;
        }

        public IEnumerable<CurrencyDto> Get()
        {
            return cofigureClient().runAsync().GetAwaiter().GetResult();
        }
    }
}