using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.MVC.Controllers
{
    public class AddController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Index2()
        {
            return View("Index1");
        }
    }
}
