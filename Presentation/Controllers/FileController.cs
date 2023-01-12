using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Api")]
    public class FileController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> UploadCsvFile([FromForm] IFormFile file)
        {
            if (file.ContentType != "csv") return BadRequest();
            
            return Ok();
        }
    }
}
