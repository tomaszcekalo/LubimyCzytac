using Microsoft.AspNetCore.Mvc;
using LubimyCzytac.MVC.Models;
using LubimyCzytac.MVC.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.ML;

namespace LubimyCzytac.MVC.Controllers
{
    public class TopRecommendationsController : Controller
    {
        private readonly ILogger<TopRecommendationsController> _logger;
        private readonly IBooksRepository booksRepository;
        private readonly IReviewsRepository reviewsRepository;
        private readonly PredictionEnginePool<LubimyCzytacModel.ModelInput, LubimyCzytacModel.ModelOutput> predictionEngine;

        public TopRecommendationsController(ILogger<TopRecommendationsController> logger,
            IBooksRepository booksRepository,
            IReviewsRepository reviewsRepository,
            PredictionEnginePool<LubimyCzytacModel.ModelInput, LubimyCzytacModel.ModelOutput> predictionEngine)
        {
            _logger = logger;
            this.booksRepository = booksRepository;
            this.reviewsRepository = reviewsRepository;
            this.predictionEngine = predictionEngine;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ForUser(
            RecommendationRequestModel model,
            CancellationToken cancellationToken)
        {
            if (model.Amount > 0)
            {
                var userReviewedBookIds = (await reviewsRepository.GetReviewsAsync(cancellationToken))
                    .Where(x => x.UserId == model.UserId)
                    .Select(x => x.BookId)
                    .ToList();
                var books = (await booksRepository
                    .GetBooksAsync(cancellationToken))
                        .OrderBy(x => x.Name).ToList();

                var topRecommendations = (from b in books
                                          where !userReviewedBookIds.Contains(b.Id)
                                          let p = predictionEngine.Predict(
                                             new LubimyCzytacModel.ModelInput()
                                             {
                                                 UserId = model.UserId,
                                                 BookId = b.Id
                                             })
                                          where !float.IsNaN(p.Score)
                                          orderby p.Score descending
                                          select new Recommendation(b)
                                          {
                                              Score = p.Score
                                          })
                                          .Take(model.Amount)
                                          ;
                return View("ForUser", topRecommendations);
            }
            return View("Index");
        }
    }
}