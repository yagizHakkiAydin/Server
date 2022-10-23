using BattleOfMinds.API.Business;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        UsersBusiness business = new UsersBusiness();

        [HttpGet("{id}")]
        public IEnumerable<Users> Get(int id)
        {
            return business.Get(id);
        }

        [HttpGet]

        public IEnumerable<Users> GetAll()
        {
            return business.GetAll();
        }

    }
}
