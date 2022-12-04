using BattleOfMinds.MVC.Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.MVC.Controllers
{

    public class LoginController : Controller
    {

        public IServiceCommunication _serviceCommuniction;
        public LoginController(IServiceCommunication serviceCommuniction)
        {
            _serviceCommuniction = serviceCommuniction;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            
            var result = _serviceCommuniction.GetResponse("api/Users/AdminLogin?email=" + email + "&password=" + password).Result;
            if(result == "true")
                return Redirect("~/Home");
            else
                return View("Index");
        }

        [HttpPost]
        public string ForgetPass(string userEmail)
        {

            return _serviceCommuniction.GetResponse("api/Users/ForgetPassword?email=" + userEmail).Result;
        }

    }
}
