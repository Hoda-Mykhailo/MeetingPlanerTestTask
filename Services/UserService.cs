using MeetingScheduler.Models;

namespace MeetingScheduler.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();
        private int _userIdCounter = 1;

        public User CreateUser(string name)
        {
            var user = new User { Id = _userIdCounter++, Name = name };
            _users.Add(user);
            return user;
        }

        public User GetUser(int id) => _users.FirstOrDefault(u => u.Id == id);

        public List<Meeting> GetMeetingsForUser(int userId) =>
            GetUser(userId)?.Meetings ?? new List<Meeting>();
    }
}
