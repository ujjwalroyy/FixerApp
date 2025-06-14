using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.DTOs
{
    public class JobHistoryDto
    {
        private long JobId { get; set; }
        private string? Category {  get; set; }
        private string? SubCategory { get; set; }
        private string? Description  { get; set; }
        private JobStatus Status { get; set; }
        private PaymentMethod PaymentMethod { get; set; }
        private User? Worker {  get; set; }
        private User? User { get; set; }
    }
}
