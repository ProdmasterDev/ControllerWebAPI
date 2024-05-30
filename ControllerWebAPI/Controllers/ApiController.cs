using ControllerWebAPI.Db;
using ControllerWebAPI.Dto;
using ControllerWebAPI.Requests;
using ControllerWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ControllerWebAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly OperationFactory _operationFactory;

        public ApiController(ILogger<ApiController> logger, OperationFactory operationFactory)
        {
            _logger = logger;
            _operationFactory = operationFactory;
        }

        [HttpPost]
        public async  Task<IActionResult> Post(ControllerRequest request)
        {
            _logger.LogInformation($"REQUEST:\n{JToken.FromObject(request)}");
            var serverResponseDto = new ServerResponseDto()
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Interval = 10
            };

            try
            {
                foreach (var msg in request.Messages)
                {
                    var serverMessage = await _operationFactory
                        .GetOperationByControllerMessage(msg)
                        .ProcessAndGetMessage(request,request.Messages.IndexOf(msg));
                    if (serverMessage != null)
                        serverResponseDto.Messages.Add(serverMessage);
                }
                _logger.LogInformation($"RESPONSE:\n{JToken.FromObject(serverResponseDto)}");
                return Ok(serverResponseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}\n{ex.InnerException?.Message}");
                return StatusCode(500);
            }
            
        }
    }
}
