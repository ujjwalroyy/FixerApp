using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.DTOs
{
    public class JobStatusUpdateDto
    {
        private long JobId {  get; set; }
        private JobStatus Status { get; set; }
        private double ExtraCharges { get; set; }
    }
}
