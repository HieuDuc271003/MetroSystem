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

<<<<<<< HEAD
        //[HttpPost("create")]
        [HttpPost]
=======
        [HttpPost("create")]
>>>>>>> e644d97 (Adjust the Admin Pages)
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> AddBusLine([FromBody] RequestCreateBusLine requestCreateBusLine)
        {
            var result = await _busLineService.AddBusLineAsync(requestCreateBusLine);
            if (!result) return BadRequest("Failed to create Bus Line.");
            return Ok("Bus Line created successfully.");
        }

<<<<<<< HEAD
        //[HttpPut("update-status/{busLineId}")]
        [HttpPut("{busLineId}/status")]
=======
        [HttpPut("update-status/{busLineId}")]
>>>>>>> e644d97 (Adjust the Admin Pages)
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateBusLineStatus(string busLineId, [FromBody] bool status)
        {
            var result = await _busLineService.UpdateBusLineStatusAsync(busLineId, status);
            if (!result) return NotFound("Bus Line not found.");
            return Ok("Bus Line status updated successfully.");
        }

<<<<<<< HEAD
        //[HttpPut("update")]
        [HttpPut("{busLineId}")]
=======
        [HttpPut("update")]
>>>>>>> e644d97 (Adjust the Admin Pages)
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> UpdateBusLineDetails(string busLineId, [FromBody] RequestUpdateBusLine requestUpdateBusLine)
        {
            var result = await _busLineService.UpdateBusLineDetailsAsync(busLineId, requestUpdateBusLine);
            if (!result) return NotFound("Bus Line not found or update failed.");
            return Ok("Bus Line details updated successfully.");
        }

<<<<<<< HEAD
        //[HttpGet("get-all")]
        [HttpGet]
=======
        [HttpGet("get-all")]
>>>>>>> e644d97 (Adjust the Admin Pages)
        public async Task<IActionResult> GetAllBusLines()
        {
            var busLines = await _busLineService.GetAllBusLinesAsync();
            return Ok(busLines);
        }

<<<<<<< HEAD
        //[HttpGet("get-by-name/{busLineName}")]
        [HttpGet("{busLineName}")]
=======
        [HttpGet("get-by-name/{busLineName}")]
>>>>>>> e644d97 (Adjust the Admin Pages)
        public async Task<IActionResult> GetBusLineByName(string busLineName)
        {
            var busLine = await _busLineService.GetBusLineByNameAsync(busLineName);
            if (busLine == null) return NotFound("Bus line not found.");

            return Ok(busLine);
        }
<<<<<<< HEAD

        //[HttpDelete("{buslineId}")]
        [HttpDelete]
        [Authorize(Roles = "R3")]
        public async Task<IActionResult> DeleteBusLine(string id)
        {
            var result = await _busLineService.DeleteBusLineByIdAsync(id);
            if (!result) return NotFound(new { message = "Bus line not found!" });

            return Ok(new { message = "Delete successfull!" });
        }
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
    }
}
