using Microsoft.AspNetCore.Mvc;

namespace EveningExpenseTracker.Controllers
{
    public class CascadeDemoController : Controller
    {

        private static readonly Dictionary<string, List<string>> CountryStateData = new()
    {
        { "USA", new List<string> { "California", "Texas", "Florida" } },
        { "Canada", new List<string> { "Ontario", "Quebec", "British Columbia" } },
        { "India", new List<string> { "Maharashtra", "Karnataka", "Delhi" } }
    };

        public IActionResult Index()
        {
            // List<string> countries = new List<string>() { "USA", "CANADA", "INDIA"};

            ViewBag.Countries = CountryStateData.Keys;
            return View();
        }

        public JsonResult GetStates(string country)
        {
            // return Json(new List<string>() { $"{country}-State 1", $"{country}-State 2", $"{country}-State3" });

            if (CountryStateData.TryGetValue(country, out List<string> states))
            {
                return Json(states);
            }


            return Json(new List<string>());
        }


    }
}
