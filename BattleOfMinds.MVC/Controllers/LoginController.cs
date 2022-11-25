using BattleOfMinds.MVC.Communication;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.MVC.Controllers
{
    public class LoginController : Controller
    {

        public IServiceCommunication serviceCommunication;
        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> deneme()
        {
            return "gs";

        }
    }
}
