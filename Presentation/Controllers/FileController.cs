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
        public async Task<ActionResult> UploadValuesFromCsvFile([FromForm] List<IFormFile> file)
        {
            
            if (file[0].ContentType != "text/csv") return BadRequest();
            await _valueService.AddValuesFromFile(file[0].OpenReadStream(), file[0].FileName);
            return Ok();
        }
    }
}
