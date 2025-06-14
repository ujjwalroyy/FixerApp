using FixerApp.Models.Entities;

namespace FixerApp.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        List<Review> FindByWorkerId(long workerId);

        List<WorkerRatingProjection> FindTopRatedWorkers();

        List<WorkerRatingProjection> FindTopRatedWorkersWithFilter(double minRating, int limit);

    }
}

public interface WorkerRatingProjection {
    long GetWorkerId();
    double GetAverageRating();
}

