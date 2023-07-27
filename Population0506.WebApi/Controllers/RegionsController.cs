using Microsoft.AspNetCore.Mvc;
using Population0506.Data.Models;
using Population0506.Data.Services;

namespace Population0506.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly ILogger<RegionsController> _logger;
        private readonly IConfiguration _configuration;

        private readonly DataAccessService _dataAccessService;

        public RegionsController(ILogger<RegionsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            var sqlConnectionProvider = new SqlConnectionProvider(_configuration.GetConnectionString("PopulationDbConnectionString"));
            _dataAccessService = new DataAccessService(sqlConnectionProvider);
            
        }

        [HttpGet]
        public IEnumerable<Region> Get()
        {
           return _dataAccessService.GetRegions();
        }
    }
}