using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixrApp.Data;

namespace FixerApp.Repositories.Implementations
{
    public class DisputeRepository : IDisputeRepository
    {
        private readonly ApplicationDbContext _context;

        public DisputeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Dispute CreateDispute(Dispute dispute)
        {
            _context.Dispute.Add(dispute);
            _context.SaveChanges();
            return dispute;
        }

        public List<Dispute> GetByUserId(long userId)
        {
            return _context.Dispute.Where(d => d.UserId == userId).ToList();
        }

        public List<Dispute> GetAll()
        {
            return _context.Dispute.ToList();
        }

        public Dispute GetById(long id)
        {
            return _context.Dispute.FirstOrDefault(d => d.Id == id) ?? throw new InvalidOperationException($"Dispute with ID {id} not found.");
        }

        public Dispute Update(Dispute dispute)
        {
            _context.Dispute.Update(dispute);
            _context.SaveChanges();
            return dispute;
        }
    }
}
