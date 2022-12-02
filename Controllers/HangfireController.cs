using data_api.Models;
using data_api.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace data_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        private readonly IDataService _dataService;
        public HangfireController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from the data api");
        }

        [HttpPost]
        public async Task<ActionResult<string>> DatabaseUpdate()
        {
            RecurringJob.AddOrUpdate<DataService>(d =>d.GetLatestData(), Cron.Minutely);
            return Ok("Data pulling job initiated");
        }
    }
}