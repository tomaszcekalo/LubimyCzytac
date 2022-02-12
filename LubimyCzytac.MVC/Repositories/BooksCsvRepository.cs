using LubimyCzytac.Model;

namespace LubimyCzytac.MVC.Repositories
{
    public class BooksCsvRepository : IBooksRepository
    {
        private List<Book> Books { get; set; }
        private char[] _separator = new char[] { ',' };

        public BooksCsvRepository()
        {
        }

        public async Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken = default)
        {
            if (Books == null)
            {
                Books = new List<Book>();
                var lines = await File.ReadAllLinesAsync("LubimyCzytacBooks.csv", cancellationToken);
                for (int i = 1; i < lines.Length; i++)
                {
                    var split = lines[i].Split(_separator);

                    //Id,Name,Image,Url
                    var id = long.Parse(split[0]);
                    var book = new Book()
                    {
                        Id = id,
                        Name = split[1],
                        Image = split[2],
                        Url = split[3]
                    };
                    Books.Add(book);
                }
            }
            return Books;
        }
    }
}