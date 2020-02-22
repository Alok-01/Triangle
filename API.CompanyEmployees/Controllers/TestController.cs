using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS.API.CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;

        public TestController(ILoggerManager logger, IRepositoryManager repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<string> GetLog()
        {
            //_repository.Company.AnyMethodFromCompanyRepository();
            //_repository.Employee.AnyMethodFromEmployeeRepository();
            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is an error message from our values controller."); return new string[] { "value1", "value2" };
        }
    }
}