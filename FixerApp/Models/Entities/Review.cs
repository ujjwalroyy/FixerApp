namespace FixerApp.Models.Entities
{
    public class Review
    {
        public long Id {  get; set; }

        public long UserId { get; set; }
        public long WorkerId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
