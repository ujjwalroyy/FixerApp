using System.ComponentModel.DataAnnotations;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.Entities
{
    public class JobRequest
    {
        [Key] public long Id { get; set; }

        [Required] public string? Category { get; set; }
        [Required] public string? SubCategory { get; set; }
        [Required] public string? Description { get; set; }

        public JobStatus Status { get; set; } = JobStatus.PENDING;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? EstimatedPrice { get; set; }

        public bool Completed { get; set; } = false;
        public bool Refunded { get; set; } = false;
        public string? RefundReason { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required] public long UserId { get; set; }
        public long? WorkerId { get; set; }
    }
}