﻿using MetroSystem.Data.Enities.MetroStationMod;
using MetroSystem.Data.Enities.NewFolder;
using MetroSystem.Data.Models;
using MetroSystem.Service.Interface;
using MetroSystem.Service.Service;
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

        //[HttpPost("create")]
        [HttpPost]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> CreateStation([FromBody] MetroStationDto request)
        {
            var result = await _metroStationService.CreateStationAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(result.Station);
        }

        [HttpPut("{stationId}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateStation(string stationId, [FromBody] UpdateMetroStationDto request)
        {
            var result = await _metroStationService.UpdateStationAsync(stationId, request);

            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(result.Station);
        }


        [HttpGet("nearest-by-address")]
        public async Task<IActionResult> GetNearestStationsByAddress([FromQuery] string address)
        {
            var stations = await _metroStationService.GetNearestStationsAsync(address);
            return Ok(stations);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> DeleteMetroStation(string id)
        {
            var result = await _metroStationService.DeleteMetroStationByIdAsync(id);
            if (!result) return NotFound(new { message = "Metro station not found!" });

            return Ok(new { message = "Delete successfull!" });
        }

        [HttpGet("nearest-bus-station")]
        public async Task<IActionResult> GetNearestBusStation([FromQuery] string stationName)
        {
            var result = await _metroStationService.GetNearestBusStationAsync(stationName);
            if (result == null)
            {
                return NotFound($"No nearest bus station found for metro station '{stationName}'.");
            }

            return Ok(result);
        }

    }
}