using LubimyCzytac.Model;
using LubimyCzytac.MVC.Models;
using LubimyCzytac.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LubimyCzytac.MVC.Controllers
{
	public class BookController : Controller
	{
		private readonly IBooksRepository _booksRepository;
		private readonly IReviewsRepository _reviewsRepository;

		public BookController(
			IBooksRepository booksRepository,
			IReviewsRepository reviewsRepository)
		{
			_booksRepository = booksRepository;
			_reviewsRepository = reviewsRepository;
		}

		public async Task<IActionResult> Index(
			string q = "",
			CancellationToken cancellationToken = default)
		{
			List<Book> books = new List<Book>();
			if (!string.IsNullOrEmpty(q))
			{
				books = (await _booksRepository.GetBooksAsync(cancellationToken))
					.Where(x => x.Name.ToLowerInvariant().Contains(q.ToLowerInvariant()))
					.OrderBy(x => x.Name)
					.ToList();
			}
			return View("Index", books);
		}

		public async Task<IActionResult> Reviews(
			int bookId,
			CancellationToken cancellationToken)
		{
			var reviews = (await _reviewsRepository
				.GetReviewsAsync(cancellationToken))
				.Where(x => x.BookId == bookId)
				.ToList();
			return View("Reviews", reviews);
		}
	}
}