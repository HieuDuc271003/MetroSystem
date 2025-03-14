﻿using MetroSystem.Service.Interface;
using MetroSystem.Data.RequestModel.BusScheduleModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MetroSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusScheduleController : ControllerBase
    {
        private readonly IBusScheduleService _busScheduleService;

        public BusScheduleController(IBusScheduleService busScheduleService)
        {
            _busScheduleService = busScheduleService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "R3")]

        public async Task<IActionResult> AddBusSchedule([FromBody] RequestCreateBusSchedule request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            var result = await _busScheduleService.AddBusScheduleAsync(request);
            if (result)
            {
                return Ok("Bus schedule created successfully.");
            }
            return StatusCode(500, "Failed to create bus schedule.");
        }

        [HttpPut("update/{scheduleId}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateBusSchedule(string scheduleId, [FromBody] RequestUpdateBusSchedule request)
        {
            if (string.IsNullOrEmpty(scheduleId) || request == null)
            {
                return BadRequest("Invalid request data.");
            }

            var result = await _busScheduleService.UpdateBusScheduleAsync(scheduleId, request);
            if (result)
            {
                return Ok("Bus schedule updated successfully.");
            }
            return StatusCode(500, "Failed to update bus schedule.");
        }

        [HttpGet("station/{stationName}")]
        public async Task<IActionResult> GetBusSchedulesByStationName(string stationName)
        {

            if (string.IsNullOrEmpty(stationName))
            {
                return BadRequest("Bus station name is required.");
            }

            var schedules = await _busScheduleService.GetBusSchedulesByStationNameAsync(stationName);
            if (schedules == null || schedules.Count == 0)
            {
                return NotFound("No bus schedules found for the given station.");
            }
            return Ok(schedules);
        }
    }
}
