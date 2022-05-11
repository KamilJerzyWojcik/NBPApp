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

        public INBPHelper NBPHelper { get; }
        public IHttpClientFactory HttpClientFactory { get; }
        public HttpResponseMessage CurrenctResponse { get; private set; }

        public NBPApiClient(INBPHelper nBPHelper, IHttpClientFactory httpClientFactory)
        {
            NBPHelper = nBPHelper;
            HttpClientFactory = httpClientFactory;
            cofigureClient();
        }

        private NBPApiClient cofigureClient()
        {
            client = HttpClientFactory.CreateClient(); ;
            client.BaseAddress = baseAdress;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(NBPHelper.GetTypeMedia()));
            return this;
        }
        
        private async Task<bool> SetResult(Response response)
        {
            string result = await response.HttpResponseMessage.Content.ReadAsStringAsync();
            NBPHelper.SetResult(result);
            return true;
        }
        
        public async Task<Response> GetResponse(string tableType)
        {
            var path = url(tableType.ToLower()).PathAndQuery;
            var response = await client.GetAsync(path);
            return new Response { IsSuccess = response.IsSuccessStatusCode, HttpResponseMessage = response};
        }

        public async Task<IEnumerable<CurrencyDto>> GetData(Response response)
        {
            await SetResult(response);
            return NBPHelper.GetData();
        }

        public async Task<IEnumerable<CurrencyDto>> GetDataRange(Response response)
        {
            await SetResult(response);
            return NBPHelper.GetDataRange();
        }
    }
}