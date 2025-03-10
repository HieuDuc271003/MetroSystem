using MetroSystem.Data.Enities.MetroStationMod;
using MetroSystem.Data.Enities.NewFolder;
using MetroSystem.Data.Models;
using MetroSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetroSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetroStationController : ControllerBase
    {
        private readonly IMetroStationService _metroStationService;

        public MetroStationController(IMetroStationService metroStationService)
        {
            _metroStationService = metroStationService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllStations()
        {
            var stations = await _metroStationService.GetAllStationsAsync();
            return Ok(stations);
        }

        [HttpGet("by-name/{stationName}")] // 🔹 Đổi API route từ GetById thành GetByName
        public async Task<IActionResult> GetStationByName(string stationName)
        {
            var result = await _metroStationService.GetStationByNameAsync(stationName);
            if (!result.IsSuccess)
            {
                return NotFound(new { message = result.Message });
            }
            return Ok(result.Station);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStation([FromBody] MetroStationDto request)
        {
            var result = await _metroStationService.CreateStationAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(result.Station);
        }

        [HttpPut("update/{stationId}")]
        public async Task<IActionResult> UpdateStation(string stationId, [FromBody] UpdateMetroStationDto request)
        {
            var result = await _metroStationService.UpdateStationAsync(stationId, request);

            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(result.Station);
        }

    }
}