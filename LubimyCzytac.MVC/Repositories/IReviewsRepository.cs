using LubimyCzytac.Model;

namespace LubimyCzytac.MVC.Repositories
{
    public interface IReviewsRepository
    {
        Task<List<Review>> GetReviewsAsync(CancellationToken cancellationToken = default);
    }
}