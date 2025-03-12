using MetroSystem.Data.RequestModel.BusStationModel;
using MetroSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetroSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStationController : ControllerBase
    {
        private readonly IBusStationService _busStationService;

        public BusStationController(IBusStationService busStationService)
        {
            _busStationService = busStationService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> AddBusStation([FromBody] RequestCreateBusStation request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            var result = await _busStationService.AddBusStationAsync(request);
            if (result)
            {
                return Ok("Bus station added successfully.");
            }
            return StatusCode(500, "Failed to add bus station.");
        }

        [HttpPut("update/{busStationId}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateBusStation(string busStationId, [FromBody] RequestUpdateBusStation request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            var result = await _busStationService.UpdateBusStationAsync(busStationId, request);
            if (result)
            {
                return Ok("Bus station updated successfully.");
            }
            return StatusCode(500, "Failed to update bus station.");
        }

        [HttpGet("get/{busStationName}")]
        public async Task<IActionResult> GetBusStationByName(string busStationName)
        {
            if (string.IsNullOrEmpty(busStationName))
            {
                return BadRequest("Bus station name is required.");
            }

            var station = await _busStationService.GetBusStationsByStationNameAsync(busStationName);
            if (station == null || station.Count == 0)
            {
                return NotFound("No bus schedules found for the given station.");
            }
            return Ok(station);
        }
    }
}
