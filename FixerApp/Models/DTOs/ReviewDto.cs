namespace FixerApp.Models.DTOs
{
    public class ReviewDto
    {
        private long Id {  get; set; }

        private long UserId { get; set; }
        private long WorkerId { get; set; }
        private int Rating { get; set; }
        private string? Comment { get; set; }
        private DateTime CreatedAt { get; set; }
    }
}
