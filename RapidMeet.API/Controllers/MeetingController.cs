using Microsoft.AspNetCore.Mvc;
using RapidMeet.Application.DTOs.MeetingDTOs;
using RapidMeet.Application.Interfaces;

namespace RapidMeet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMeetingRequestDTO dto)
        {
            var result = await _meetingService.CreateMeetingAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var meetings = await _meetingService.GetAllMeetingsAsync();
            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var meeting = await _meetingService.GetMeetingByIdAsync(id);
            if (meeting == null) return NotFound();
            return Ok(meeting);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _meetingService.DeleteMeetingAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
