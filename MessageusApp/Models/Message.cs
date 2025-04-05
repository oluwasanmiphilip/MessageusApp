namespace MessageusApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime ScheduledTime { get; set; } 

        public bool IsSent { get; set; }
        public DateTime? SentAt { get; set; }
        //public DateTime SentAT { get; internal set; }

        // Navigation property (optional)
        public User? User { get; set; }
        //public string? Recipient { get; internal set; }
    }
}
