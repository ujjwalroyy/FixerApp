using System.ComponentModel.DataAnnotations;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.DTOs
{
    public class AddTimelineDto
    {
        [Required]
        public long JobId { get; set; }

        [Required]
        public TimelineStage Stage { get; set; }

        [Required, StringLength(500)]
        public string? Description { get; set; } = string.Empty;
    }
}
