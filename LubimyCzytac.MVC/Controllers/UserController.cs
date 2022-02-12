using LubimyCzytac.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LubimyCzytac.MVC.Controllers
{
	public class UserController : Controller
	{
		private readonly IReviewsRepository _reviewsRepository;
		private readonly IBooksRepository _booksRepository;

		public UserController(
			IBooksRepository booksRepository,
			IReviewsRepository reviewsRepository)
		{
			_reviewsRepository = reviewsRepository;
			_booksRepository = booksRepository;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Reviews(
			int userId,
			CancellationToken cancellationToken)
		{
			var books = (await _booksRepository
				.GetBooksAsync(cancellationToken))
				.ToDictionary(x => x.Id, x => x);

			var reviews = (await _reviewsRepository
				.GetReviewsAsync(cancellationToken))
				.Where(x => x.UserId == userId)
				.ToList();
			foreach (var item in reviews)
			{
				item.Book = books[item.BookId];
			}
			return View("Reviews", reviews);
		}
	}
}