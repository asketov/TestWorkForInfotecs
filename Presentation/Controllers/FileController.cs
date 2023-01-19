using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ValueService _valueService;
        public FileController(ValueService valueService)
        {
            _valueService = valueService;
        }
        [HttpPost]
        public async Task<ActionResult> UploadValuesFromCsvFile(IFormFile  csvFile)
        {
            if (csvFile.ContentType != "text/csv") return BadRequest("Это не csv формат");
            await _valueService.AddValuesFromFile(csvFile.OpenReadStream(), csvFile.FileName);
            return Ok();
        }
    }
}
