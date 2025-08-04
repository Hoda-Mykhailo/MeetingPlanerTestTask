using MeetingScheduler.DOTs;
using MeetingScheduler.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeetingScheduler.Controllers
{
    [ApiController]
    [Route("meetings")]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingsController(IMeetingService meetingService) => _meetingService = meetingService;

        [HttpPost]
        public IActionResult CreateMeeting(CreateMeetingRequest request)
        {
            try
            {
                var result = _meetingService.ScheduleMeeting(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
