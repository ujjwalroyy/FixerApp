using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;
using FixerApp.Repositories.Interfaces;
using FixerApp.Services.Interfaces;

namespace FixerApp.Services.Implementations
{
    public class DisputeService : IDisputeService
    {
        private readonly IDisputeRepository _repository;

        public DisputeService(IDisputeRepository repository)
        {
            _repository = repository;
        }

        public DisputeDTO CreateDispute(DisputeDTO dto)
        {
            var dispute = new Dispute
            {
                JobId = dto.JobId,
                UserId = dto.UserId,
                Reason = dto.Reason,
                CreatedAt = DateTime.UtcNow,
                Status = DisputeStatus.PENDING
            };

            var created = _repository.CreateDispute(dispute);
            return MapToDTO(created);
        }

        public List<DisputeDTO> GetDisputesByUser(long userId)
        {
            return _repository.GetByUserId(userId).Select(MapToDTO).ToList();
        }

        public List<DisputeDTO> GetAllDisputes()
        {
            return _repository.GetAll().Select(MapToDTO).ToList();
        }

        public DisputeDTO RespondToDispute(long disputeId, string adminComment, DisputeStatus status)
        {
            var dispute = _repository.GetById(disputeId);
            if (dispute == null) throw new ArgumentException("Dispute not found");

            dispute.AdminComment = adminComment;
            dispute.Status = status;

            var updated = _repository.Update(dispute);
            return MapToDTO(updated);
        }

        private DisputeDTO MapToDTO(Dispute dispute) => new()
        {
            Id = dispute.Id,
            JobId = dispute.JobId,
            UserId = dispute.UserId,
            Reason = dispute.Reason,
            AdminComment = dispute.AdminComment,
            Status = dispute.Status,
            CreatedAt = dispute.CreatedAt
        };
    }
}
