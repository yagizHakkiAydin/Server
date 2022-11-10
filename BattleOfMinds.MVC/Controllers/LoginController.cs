using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
