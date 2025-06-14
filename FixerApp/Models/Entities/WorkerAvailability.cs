using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixerApp.Models.Entities
{
    public class WorkerAvailability
    {
        public long Id { get; set; }

        [Required]
        public long WorkerId { get; set; }

        [ForeignKey("WorkerId")]
        public User Worker { get; set; } = null!;

        [Required]
        public DateTime AvailableDate { get; set; }

        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
