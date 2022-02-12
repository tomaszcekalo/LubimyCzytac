using LubimyCzytac.Model;

namespace LubimyCzytac.MVC.Repositories
{
    public class ReviewsCsvRepository : IReviewsRepository
    {
        public List<Review> Reviews { get; private set; }
        private char[] _separator = new char[] { ',' };

        public async Task<List<Review>> GetReviewsAsync(CancellationToken cancellationToken = default)
        {
            if (Reviews == null)
            {
                Reviews = new List<Review>();
                var lines = await File.ReadAllLinesAsync("LubimyCzytacReviews.csv", cancellationToken);
                for (int i = 1; i < lines.Length; i++)
                {
                    var split = lines[i].Split(_separator);

                    //BookId,UserId,Date,RatingValue
                    var bookId = long.Parse(split[0]);
                    var userId = long.Parse(split[1]);
                    var date = DateTime.Parse(split[2]);
                    var ratingValue = int.Parse(split[3]);
                    var review = new Review()
                    {
                        BookId = bookId,
                        UserId = userId,
                        RatingValue = ratingValue,
                        Date = date
                    };
                    Reviews.Add(review);
                }
            }
            return Reviews;
        }
    }
}