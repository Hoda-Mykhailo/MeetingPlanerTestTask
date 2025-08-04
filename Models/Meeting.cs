namespace MeetingScheduler.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public List<int> ParticipantIds { get; set; } = new();
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
