using MeetingScheduler.DOTs;
using MeetingScheduler.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeetingScheduler.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService = userService;

        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            var user = _userService.CreateUser(request.Name);
            return Ok(user);
        }

        [HttpGet("{userId}/meetings")]
        public IActionResult GetUserMeetings(int userId)
        {
            var meetings = _userService.GetMeetingsForUser(userId);
            return Ok(meetings);
        }
    }
}
