//namespace MetroSystem.Controllers
//{
//    public class MetroLineController
//    {
//    }
//}
using MetroSystem.Data.Enities;
using MetroSystem.Data.Models;
using MetroSystem.RequestModel.MetroLineModel;
using MetroSystem.Data.RequestModel.MetroLineModel;
using MetroSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MetroSystem.Service.Service;

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

        [HttpPut("update-status/{lineId}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateMetroLineStatus(string lineId, [FromBody] bool status)
        {
            var result = await _metroLineService.UpdateMetroLineStatusAsync(lineId, status);
            if (!result) return NotFound("Metro line not found.");
            return Ok("Metro line status updated successfully.");
        }

        [HttpPut("update-line")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateMetroLineDetails(string lineId, [FromBody] RequestUpdateMetroLine requestUpdateMetroLine)
        {
            var result = await _metroLineService.UpdateMetroLineDetailsAsync(lineId, requestUpdateMetroLine);
            if (!result) return NotFound("Metro line not found or update failed.");
            return Ok("Metro line details updated successfully.");
        }

        [HttpGet("get-all")]
        //[Authorize(Roles = "R3")]
        public async Task<IActionResult> GetAllMetroLines()
        {
            var metroLines = await _metroLineService.GetAllMetroLinesAsync();
            return Ok(metroLines);
        }

        [HttpGet("get-by-name/{lineName}")]
        //[Authorize(Roles = "R3")]
        public async Task<IActionResult> GetMetroLineByName(string lineName)
        {
            var metroLine = await _metroLineService.GetMetroLineByNameAsync(lineName);
            if (metroLine == null) return NotFound("Metro line not found.");
            return Ok(metroLine);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> DeleteMetroLine(string id)
        {
            var result = await _metroLineService.DeleteMetroLineByIdAsync(id);
            if (!result) return NotFound(new { message = "Metro Line not found!" });

            return Ok(new { message = "Delete successfull!" });
        }


    }
}