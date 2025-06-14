using FixerApp.Models.Entities;

namespace FixerApp.Repositories.Interfaces
{
    public interface ISupportTicketRepository
    {
        SupportTicket Create(SupportTicket ticket);
        SupportTicket? GetById(long id);
        List<SupportTicket> GetByUserId(long userId);
        List<SupportTicket> GetAll();
        void Update(SupportTicket ticket);
    }
}
