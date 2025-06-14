using FixerApp.Models.Entities;

namespace FixerApp.Repositories.Interfaces
{
    public interface IDisputeRepository
    {
        Dispute CreateDispute(Dispute dispute);
        List<Dispute> GetByUserId(long userId);
        List<Dispute> GetAll();
        Dispute GetById(long id);
        Dispute Update(Dispute dispute);
    }
}
