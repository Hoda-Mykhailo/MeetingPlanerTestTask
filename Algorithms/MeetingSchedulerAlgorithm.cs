using MeetingScheduler.DOTs;
using MeetingScheduler.Models;

namespace MeetingScheduler.Algorithms
{
    public class MeetingSchedulerAlgorithm
    {
        public static MeetingTimeSlotResponse? FindEarliestSlot(
        List<User> users,
        DateTime earliestStart,
        DateTime latestEnd,
        TimeSpan duration)
        {
            var current = earliestStart;

            while (current + duration <= latestEnd)
            {
                var proposedEnd = current + duration;
                bool conflict = users.Any(u => u.Meetings.Any(m =>
                    !(m.EndTime <= current || m.StartTime >= proposedEnd)));

                if (!conflict)
                {
                    return new MeetingTimeSlotResponse
                    {
                        StartTime = current,
                        EndTime = proposedEnd
                    };
                }

                current = current.AddMinutes(15); // крок перевірки
            }

            return null;
        }
    }
}
