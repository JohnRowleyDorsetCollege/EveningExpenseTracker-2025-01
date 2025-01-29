using Microsoft.AspNetCore.Mvc;

namespace EveningExpenseTracker.Controllers
{
    public class CascadeDemoController : Controller
    {
        public IActionResult Index()
        {
            List<string> countries = new List<string>() { "USA", "CANADA", "INDIA"};

            ViewBag.Countries = countries;
            return View();
        }

        public JsonResult GetStates(string country)
        {
            return Json(new List<string>() { $"{country}-State 1", $"{country}-State 2", $"{country}-State3" });
        }
    }
}
