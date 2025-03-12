using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MetroSystem.Data.RequestModel.BusLineModel;
using MetroSystem.Service.Interface;

namespace MetroSystem.Controllers
{
    [Route("api/bus-lines")]
    [ApiController]
    public class BusLineController : ControllerBase
    {
        private readonly IBusLineService _busLineService;

        public BusLineController(IBusLineService busLineService)
        {
            _busLineService = busLineService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> AddBusLine([FromBody] RequestCreateBusLine requestCreateBusLine)
        {
            var result = await _busLineService.AddBusLineAsync(requestCreateBusLine);
            if (!result) return BadRequest("Failed to create Bus Line.");
            return Ok("Bus Line created successfully.");
        }

        [HttpPut("update-status/{busLineId}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateBusLineStatus(string busLineId, [FromBody] bool status)
        {
            var result = await _busLineService.UpdateBusLineStatusAsync(busLineId, status);
            if (!result) return NotFound("Bus Line not found.");
            return Ok("Bus Line status updated successfully.");
        }

        [HttpPut("update")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateBusLineDetails(string busLineId, [FromBody] RequestUpdateBusLine requestUpdateBusLine)
        {
            var result = await _busLineService.UpdateBusLineDetailsAsync(busLineId, requestUpdateBusLine);
            if (!result) return NotFound("Bus Line not found or update failed.");
            return Ok("Bus Line details updated successfully.");
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBusLines()
        {
            var busLines = await _busLineService.GetAllBusLinesAsync();
            return Ok(busLines);
        }

        [HttpGet("get-by-name/{busLineName}")]
        public async Task<IActionResult> GetBusLineByName(string busLineName)
        {
            var busLine = await _busLineService.GetBusLineByNameAsync(busLineName);
            if (busLine == null) return NotFound("Bus line not found.");

            return Ok(busLine);
        }
    }
}
