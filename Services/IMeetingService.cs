using MeetingScheduler.DOTs;

namespace MeetingScheduler.Services
{
    public interface IMeetingService
    {
        MeetingTimeSlotResponse ScheduleMeeting(CreateMeetingRequest request);
    }
}
