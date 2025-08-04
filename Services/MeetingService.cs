using MeetingScheduler.Models;
using MeetingScheduler.DOTs;
using MeetingScheduler.Algorithms;


namespace MeetingScheduler.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IUserService _userService;
        private readonly List<Meeting> _meetings = new();
        private int _meetingIdCounter = 1;

        public MeetingService(IUserService userService)
        {
            _userService = userService;
        }

        public MeetingTimeSlotResponse ScheduleMeeting(CreateMeetingRequest request)
        {
            var proposedTime = MeetingSchedulerAlgorithm.FindEarliestSlot(
                request.ParticipantIds.Select(id => _userService.GetUser(id)).ToList(),
                request.EarliestStart,
                request.LatestEnd,
                TimeSpan.FromMinutes(request.DurationMinutes)
            );

            if (proposedTime == null)
                throw new Exception("Немає доступного часу для зустрічі.");

            var meeting = new Meeting
            {
                Id = _meetingIdCounter++,
                ParticipantIds = request.ParticipantIds,
                StartTime = proposedTime.StartTime,
                EndTime = proposedTime.EndTime
            };

            foreach (var userId in request.ParticipantIds)
            {
                var user = _userService.GetUser(userId);
                user?.Meetings.Add(meeting);
            }

            _meetings.Add(meeting);

            return new MeetingTimeSlotResponse
            {
                StartTime = meeting.StartTime,
                EndTime = meeting.EndTime
            };
        }
    }
}
