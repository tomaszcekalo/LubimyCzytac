using Microsoft.AspNetCore.Mvc;

namespace LubimyCzytac.MVC.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
