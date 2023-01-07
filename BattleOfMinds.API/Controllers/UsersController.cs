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

        [HttpGet]
        [Route("GetAllPlayers")]
        public async Task<IEnumerable<Users>> GetAllPlayers()
        {
            return await _usersBusiness.GetAll(o => o.isDeleted.Equals(false) && o.UserType.Equals("Player"));
        }


        [HttpGet]
        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _usersBusiness.GetAll(o => o.isDeleted.Equals(false));
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

        [HttpGet]
        [Route("Email")]
        public async Task<Users> Get(string email)
        {
            return await _usersBusiness.Get(o => o.Email.Equals(email) && o.isDeleted.Equals(false));
        }


        [HttpPost]
        [Route("Sign-up")]
        public async Task<string> Register([FromBody]Users users)
        {
            return await _usersBusiness.Register(users);
        }

        [HttpGet]
        [Route("ApproveUser")]
        public async Task<bool> ApproveUser(int userId, string code)
        {

            return await _usersBusiness.ApproveUser(userId, code);
        }

        [HttpGet]
        [Route("Login")]
        public async Task<bool> Login(string email, string password)
        {
            return await _usersBusiness.Login(email, password);
        }


        [HttpGet]
        [Route("AdminLogin")]
        public async Task<bool> AdminLogin(string email, string password)
        {
            return await _usersBusiness.AdminLogin(email, password);
        }


        [HttpGet]
        [Route("ForgetPassword")]
        public async Task<bool> ForgetPassword(string email)
        {
            return await _usersBusiness.ForgetPassword(email);
        }

        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            return await _usersBusiness.UpdatePassword(userId, oldPassword, newPassword);
        }
    }
}
