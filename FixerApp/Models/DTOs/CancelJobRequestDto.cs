using System.ComponentModel.DataAnnotations;

namespace FixerApp.Models.DTOs
{
    public class CancelJobRequestDto
    {
        [Required] public long JobId { get; set; }
        [Required] public long CancelledByUserId { get; set; }
        [Required] public string? Reason { get; set; }
    }
}
