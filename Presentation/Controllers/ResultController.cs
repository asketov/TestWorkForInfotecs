using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BLL.Models.Result;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ResultService _resultService;
        public ResultController(ResultService resultService)
        {
            _resultService = resultService;
        }
        [HttpGet]
        public async Task<ActionResult> GetResultsInJson([FromQuery]GetResultsRequest request, CancellationToken token)
        {
            var models = await _resultService.GetResults(request, token);
            if (!models.Any()) return NotFound("Такие результаты не найдены");
            var json = JsonSerializer.Serialize(models);
            var bytes = Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", "getResults.json");
        }
    }
}
