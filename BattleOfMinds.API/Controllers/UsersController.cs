using BattleOfMinds.API.Business;
using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersBusiness _usersBusiness;

        public UsersController(IUsersBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Users> Get(int id)
        {
            return await _usersBusiness.Get(o => o.Id.Equals(id) && o.isDeleted.Equals(false));
        }

        [HttpGet]

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _usersBusiness.GetAll(o => o.isDeleted.Equals(false));
        }

        [HttpPost]
        public async Task<Users> Add(Users users)
        {
            return await _usersBusiness.Add(users);
        }

        [HttpDelete]
        public async Task<Users> Delete(int id)
        {
            var result = await _usersBusiness.Get(o => o.Id.Equals(id) && o.isDeleted.Equals(false));
            result.isDeleted = true;
            return await _usersBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Users> Update(Users users)
        {

            return await _usersBusiness.Update(users);
        }


    }
}
