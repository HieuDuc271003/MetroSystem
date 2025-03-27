using MetroSystem.Data.RequestModel.ScheduleModel;
using MetroSystem.Service.Interface;
using MetroSystem.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MetroSystem.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> AddSchedule([FromBody] RequestCreateSchedule request)
        {
            if (request == null)
            {
                return BadRequest("Invalid schedule data.");
            }

            var result = await _scheduleService.AddScheduleAsync(request);
            if (!result)
            {
                return StatusCode(500, "Error creating schedule.");
            }

            return Ok("Schedule created successfully.");
        }

        [HttpPut("{scheduleId}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateSchedule(string scheduleId, [FromBody] RequestUpdateSchedule request)
        {
            if (string.IsNullOrEmpty(scheduleId) || request == null)
            {
                return BadRequest("Invalid schedule data.");
            }

            var result = await _scheduleService.UpdateScheduleAsync(scheduleId, request);
            if (!result)
            {
                return NotFound("Schedule not found or update failed.");
            }

            return Ok("Schedule updated successfully.");
        }

        [HttpGet("by-station/{stationName}")]
        public async Task<IActionResult> GetSchedulesByStationName(string stationName)
        {
            if (string.IsNullOrEmpty(stationName))
            {
                return BadRequest("Station name is required.");
            }

            var schedules = await _scheduleService.GetSchedulesByStationNameAsync(stationName);
            if (schedules == null || schedules.Count == 0)
            {
                return NotFound("No schedules found for this station.");
            }

            return Ok(schedules);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> DeleteSchedule(string id)
        {
            var result = await _scheduleService.DeleteScheduleByIdAsync(id);
            if (!result) return NotFound(new { message = "Schedule not found!" });

            return Ok(new { message = "Delete successfull!" });
        }

        [HttpGet]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedulesAsync();
            if (schedules == null || schedules.Count == 0)
            {
                return NotFound("No schedules found.");
            }

            return Ok(schedules);
        }


    }
}
