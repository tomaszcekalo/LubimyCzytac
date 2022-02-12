using LubimyCzytac.MVC.Models;
using LubimyCzytac.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.ML;

namespace LubimyCzytac.MVC.Controllers
{
    public class PredictController : Controller
    {
        private readonly ILogger<PredictController> _logger;
        private readonly IBooksRepository booksRepository;
        private readonly PredictionEnginePool<LubimyCzytacModel.ModelInput, LubimyCzytacModel.ModelOutput> predictionEngine;

        public PredictController(ILogger<PredictController> logger,
            IBooksRepository booksRepository,
            PredictionEnginePool<LubimyCzytacModel.ModelInput, LubimyCzytacModel.ModelOutput> predictionEngine)
        {
            _logger = logger;
            this.booksRepository = booksRepository;
            this.predictionEngine = predictionEngine;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.Books = (await booksRepository.GetBooksAsync(cancellationToken))
                    .OrderBy(x => x.Name)
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Predict(PredictModel model, CancellationToken cancellationToken)
        {
            ViewBag.Prediction = predictionEngine.Predict(new LubimyCzytacModel.ModelInput()
            {
                BookId = model.BookId,
                UserId = model.UserId
            });
            return View("Prediction");
        }
    }
}