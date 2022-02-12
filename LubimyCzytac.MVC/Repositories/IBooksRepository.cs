using LubimyCzytac.Model;

namespace LubimyCzytac.MVC.Repositories
{
    public interface IBooksRepository
    {
        Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken = default);
    }
}