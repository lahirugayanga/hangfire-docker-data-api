using data_api.Models;
using Newtonsoft.Json;

namespace data_api.Services
{
    public class DataService : IDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DataService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<MonkeypoxDataModel>> GetLatestData()
        {
            var client = _httpClientFactory.CreateClient();
            Task<HttpResponseMessage> response = client.GetAsync("https://opendata.ecdc.europa.eu/monkeypox/casedistribution/json/data.json");
            response.Wait();
            string resultContent = await response.Result.Content.ReadAsStringAsync();
            List<MonkeypoxDataModel> jsonData = JsonConvert.DeserializeObject<List<MonkeypoxDataModel>>(resultContent);
            return jsonData;
        }

    }
}
