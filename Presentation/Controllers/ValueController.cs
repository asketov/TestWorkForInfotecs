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
    public class ValueController : ControllerBase
    {
        private readonly ValueService _valueService;

        public ValueController(ValueService valueService)
        {
            _valueService = valueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetValuesByFileName(string fileName, CancellationToken token)
        {
            var models = await _valueService.GetValuesModelsByFileName(fileName, token);
            return Ok(models);
        }
    }
}
