namespace MessageusApp.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key
        public string PlanType { get; set; } = "Free"; // Example: Free, Premium, Pro
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation property
        public User User { get; set; } = null!;
    }
}
