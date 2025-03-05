//namespace MetroSystem.Controllers
//{
//    public class MetroLineController
//    {
//    }
//}
using MetroSystem.Data.Enities;
using MetroSystem.Data.Models;
using MetroSystem.RequestModel.MetroLineModel;
using MetroSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MetroSystem.Controllers
{
    [Route("api/add-new-metro-lines")]
    [ApiController]
    public class MetroLineController : ControllerBase
    {
        private readonly IMetroLineService _metroLineService;

        public MetroLineController(IMetroLineService metroLineService)
        {
            _metroLineService = metroLineService;
        }

        //[HttpPost]
        //[Authorize(Roles = "Staff")]
        //public async Task<IActionResult> AddMetroLine([FromBody] MetroLine metroLine)
        //{
        //    var result = await _metroLineService.AddMetroLineAsync(metroLine);
        //    if (!result) return BadRequest("Failed to add metro line.");
        //    return Ok("Metro line added successfully.");
        //}
        [HttpPost]
       [Authorize(Roles = "R3")]
        public async Task<IActionResult> AddMetroLine([FromBody] RequestCreateMetroLine requestCreateMetroLine)
        {
            var result = await _metroLineService.AddMetroLineAsync(requestCreateMetroLine);
            if (!result) return BadRequest("Failed to add metro line.");
            return Ok("Metro line added successfully.");
        }
    }
}