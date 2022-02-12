using LubimyCzytac.Model;
using Microsoft.EntityFrameworkCore;

namespace LubimyCzytac.MVC.Repositories
{
    public class BooksSqlRepository : IBooksRepository
    {
        public BooksSqlRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public DatabaseContext DatabaseContext { get; }

        public async Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken)
        {
            return await DatabaseContext.Books.ToListAsync(cancellationToken);
        }
    }
}