using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.Entities
{
    public class Notification
    {
        public long Id { get; set; }

        [Required]
        public string? Message { get; set; }

        [Required]
        public bool Read { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public NotificationType Type { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
