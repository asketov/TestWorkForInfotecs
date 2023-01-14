using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Result;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public async Task<IActionResult> GetResultByFileName(GetResultsRequest request)
        {
            var models = await _resultService.GetResults(request);
            return Ok(models);
        }
    }
}
