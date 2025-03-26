using MetroSystem.Data.RequestModel.BusStationModel;
using MetroSystem.Service.Interface;
<<<<<<< HEAD
using MetroSystem.Service.Service;
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
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

<<<<<<< HEAD
        //[HttpPost("create")]
        [HttpPost]
=======
        [HttpPost("create")]
>>>>>>> e644d97 (Adjust the Admin Pages)
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

<<<<<<< HEAD
        //[HttpPut("update-status/{busStationId}")]
        [HttpPut("{busStationId}/status")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateBusStationStatus(string busStationId, [FromBody] bool newStatus)
        {
            var result = await _busStationService.UpdateBusStationStatusAsync(busStationId, newStatus);
            if (result)
            {
                return Ok("Bus station status updated successfully.");
            }
            return StatusCode(500, "Failed to update bus station status.");
        }


        //[HttpPut("update/{busStationId}")]
        [HttpPut("{busStationId}")]
=======
        [HttpPut("update/{busStationId}")]
>>>>>>> e644d97 (Adjust the Admin Pages)
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

<<<<<<< HEAD
        [HttpGet("{busStationName}")]
=======
        [HttpGet("get/{busStationName}")]
>>>>>>> e644d97 (Adjust the Admin Pages)
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
<<<<<<< HEAD

        [HttpDelete("{id}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> DeleteBusStation(string id)
        {
            var result = await _busStationService.DeleteBusStationByIdAsync(id);
            if (!result) return NotFound(new { message = "Bus station not found!" });

            return Ok(new { message = "Delete successfull!" });
        }
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
    }
}
