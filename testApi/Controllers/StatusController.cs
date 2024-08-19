using Microsoft.AspNetCore.Mvc;
using testApi.ApiKey;
using testApi.Services.Interfaces;

namespace testApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statuses;
        private readonly ILogger<StatusController> _logger;
        private readonly IApiKeyValidation _apiKeyValidation;

        public StatusController(ILogger<StatusController> logger, IStatusService statuses, IApiKeyValidation apiKeyValidation)
        {
            _logger = logger;
            _statuses = statuses;
            _apiKeyValidation = apiKeyValidation;
        }

        [HttpGet(Name = "GetStatus")]
        public async Task<bool?> Get(int Id)
        {
            string? apiKey = Request.Headers[Constants.ApiKeyHeaderName];
            if (string.IsNullOrWhiteSpace(apiKey))
                return null;
            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);
            if (!isValid)
                return null;
            var response = await _statuses.GetStatus(Id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
               return response.Data.status;
            }
            return null;
        }
    }
}
