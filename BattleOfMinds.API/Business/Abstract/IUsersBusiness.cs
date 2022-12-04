using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Business.Abstract
{
    public interface IUsersBusiness : IEntityRepository<Users>
    {
        public Task<string> Register([FromBody]Users users);

        public Task<bool> ApproveUser(int userId, string code);

        public Task<bool> Login(string email, string password);

        public Task<bool> AdminLogin(string email, string password);  

        public Task<bool> ForgetPassword(string email);

        public Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword);
    }
}
