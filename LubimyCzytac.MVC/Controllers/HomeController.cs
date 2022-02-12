using LubimyCzytac.Model;
using LubimyCzytac.MVC.Models;
using LubimyCzytac.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.ML;
using System.Diagnostics;

namespace LubimyCzytac.MVC.Controllers
{
    //public class IndexModel
    //{
    //    public long BookId { get; set; }
    //    public long UserId { get; set; }
    //}

    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //private readonly IBooksRepository booksRepository;
        //private readonly PredictionEnginePool<LubimyCzytacModel.ModelInput, LubimyCzytacModel.ModelOutput> predictionEngine;
        //private List<SelectListItem> books;

        //public HomeController(ILogger<HomeController> logger,
        //    IBooksRepository booksRepository,
        //    PredictionEnginePool<LubimyCzytacModel.ModelInput, LubimyCzytacModel.ModelOutput> predictionEngine)
        //{
        //    _logger = logger;
        //    this.booksRepository = booksRepository;
        //    this.predictionEngine = predictionEngine;
        //}

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            //if (books == null)
            //{
            //    books = (await booksRepository.GetBooksAsync(cancellationToken))
            //        .OrderBy(x => x.Name)
            //        .Select(x => new SelectListItem()
            //        {
            //            Text = x.Name,
            //            Value = x.Id.ToString()
            //        }).ToList();
            //}
            //ViewBag.Books = books;
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}