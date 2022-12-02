using data_api.Models;

namespace data_api.Services
{
    public interface IDataService
    {
        Task<List<MonkeypoxDataModel>> GetLatestData();
    }
}