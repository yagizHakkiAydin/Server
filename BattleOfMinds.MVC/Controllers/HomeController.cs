using BattleOfMinds.Models.Models;
using BattleOfMinds.MVC.Communication;
using BattleOfMinds.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BattleOfMinds.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IServiceCommunication _serviceCommuniction;
        public HomeController(ILogger<HomeController> logger, IServiceCommunication serviceCommuniction)
        {
            _logger = logger;
            _serviceCommuniction = serviceCommuniction;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> Login(string email, string password)
        {
            
            var result = _serviceCommuniction.GetResponse("api/Users/Login?email="+email+"&password="+password).Result;
            return true;
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