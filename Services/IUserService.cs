using MeetingScheduler.Models;

namespace MeetingScheduler.Services
{
    public interface IUserService
    {
        User CreateUser(string name);
        User GetUser(int id);
        List<Meeting> GetMeetingsForUser(int userId);
    }
}
