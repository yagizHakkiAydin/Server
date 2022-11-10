using BattleOfMinds.Models.Models;
using BattleOfMinds.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BattleOfMinds.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> Login(string username, string password)
        {

            Users user = new Users();
            user.Email = username;
            user.Password = password;



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:7157/api/Users/Login");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Users>("Users/Login", user);

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
            }
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