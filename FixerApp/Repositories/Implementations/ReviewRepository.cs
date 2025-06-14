using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;

namespace FixerApp.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        public List<Review> FindByWorkerId(long workerId)
        {
            throw new NotImplementedException();
        }

        public List<WorkerRatingProjection> FindTopRatedWorkers()
        {
            throw new NotImplementedException();
        }

        public List<WorkerRatingProjection> FindTopRatedWorkersWithFilter(double minRating, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
