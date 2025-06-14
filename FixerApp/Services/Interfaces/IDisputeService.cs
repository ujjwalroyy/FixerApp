using FixerApp.Models.DTOs;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Services.Interfaces
{
    public interface IDisputeService
    {
        DisputeDTO CreateDispute(DisputeDTO dto);
        List<DisputeDTO> GetDisputesByUser(long userId);
        List<DisputeDTO> GetAllDisputes();
        DisputeDTO RespondToDispute(long disputeId, string adminComment, DisputeStatus status);
    }
}
