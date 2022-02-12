using LubimyCzytac.Model;

namespace LubimyCzytac.MVC.Models
{
    public class Recommendation : Book
    {
        public float Score { get; set; }

        public Recommendation(Book book)
            : base(book)
        {
        }
    }
}