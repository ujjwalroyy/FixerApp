using System.ComponentModel.DataAnnotations;

namespace FixerApp.Models.DTOs
{
    public class WorkerAvailabilityDto
    {
        [Required]
        public long WorkerId { get; set; }

        [Required]
        public DateTime AvailableDate { get; set; }

        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
