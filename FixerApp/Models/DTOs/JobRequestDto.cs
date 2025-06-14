using System.ComponentModel.DataAnnotations;
using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.DTOs
{
    public class JobRequestDto
    {
        public long Id { get; set; }

        [Required] public string? Category { get; set; }
        [Required] public string? SubCategory { get; set; }

        [Required] public string? Description { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? EstimatedPrice { get; set; }

        public long? UserId { get; set; }
        public long? WorkerId { get; set; }

        [Required]
        public JobStatus Status { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
    }
}
