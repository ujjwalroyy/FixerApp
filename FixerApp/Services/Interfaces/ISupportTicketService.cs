using FixerApp.Models.DTOs;

namespace FixerApp.Services.Interfaces
{
    public interface ISupportTicketService
    {
        SupportTicketDto CreateTicket(SupportTicketDto dto);
        List<SupportTicketDto> GetTicketsByUser(long userId);
        List<SupportTicketDto> GetAllTickets();
        SupportTicketDto RespondToTicket(long ticketId, string response);
    }
}
