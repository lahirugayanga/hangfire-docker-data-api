using data_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace data_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetData()
        {
            var result = await _dataService.GetLatestData();
            return Ok(result);
        }
    }
}
