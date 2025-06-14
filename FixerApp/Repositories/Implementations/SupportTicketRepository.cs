using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixrApp.Data;

namespace FixerApp.Repositories.Implementations
{
    public class SupportTicketRepository : ISupportTicketRepository
    {
        private readonly ApplicationDbContext _context;

        public SupportTicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public SupportTicket Create(SupportTicket ticket)
        {
            _context.SupportTicket.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public SupportTicket? GetById(long id)
        {
            return _context.SupportTicket.FirstOrDefault(t => t.Id == id);
        }

        public List<SupportTicket> GetByUserId(long userId)
        {
            return _context.SupportTicket
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
        }

        public List<SupportTicket> GetAll()
        {
            return _context.SupportTicket
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
        }

        public void Update(SupportTicket ticket)
        {
            _context.SupportTicket.Update(ticket);
            _context.SaveChanges();
        }
    }
}
