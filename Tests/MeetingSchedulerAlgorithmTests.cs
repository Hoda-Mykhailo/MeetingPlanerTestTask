using NUnit.Framework;
using MeetingScheduler.Algorithms;
using MeetingScheduler.Models;

namespace MeetingScheduler.Tests
{
    public class MeetingSchedulerAlgorithmTests
    {
        [Test]
        public void FindsEarliestSlot_NoConflicts()
        {
            var users = new List<User>
            {
                new User { Id = 1, Meetings = new List<Meeting>() },
                new User { Id = 2, Meetings = new List<Meeting>() }
            };

            var result = MeetingSchedulerAlgorithm.FindEarliestSlot(
                users,
                new DateTime(2025, 6, 20, 9, 0, 0),
                new DateTime(2025, 6, 20, 17, 0, 0),
                TimeSpan.FromMinutes(60)
            );

            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2025, 6, 20, 9, 0, 0), result.StartTime);
        }
    }
}
