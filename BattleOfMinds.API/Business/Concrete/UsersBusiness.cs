using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.API.Helpers;
using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Models.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IEntityRepository<Users> _entityRepository;

        public UsersBusiness(IEntityRepository<Users> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Task<Users> Get(Expression<Func<Users, bool>> filter = null, params Expression<Func<Users, object>>[] includes)
        {
            return _entityRepository.Get(filter,includes);
        }

        public Task<List<Users>> GetAll(Expression<Func<Users, bool>> filter = null, params Expression<Func<Users, object>>[] includes)
        {
            return _entityRepository.GetAll(filter,includes);
        }
        public Task<Users> Add(Users Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Users> Update(Users Entity)
        {
            return _entityRepository.Update(Entity);
        }

        public async Task<string> Register([FromBody] Users users)
        {
            var result = _entityRepository.GetAll(o => o.Email.Equals(users.Email) && o.isDeleted == false).Result.FirstOrDefault();
            if (result == null)
            {
                
                string resultCode = CodeGenerator.Generator();
                users.ApprovedCode = resultCode;
                users.Password = Crypt.base64Encode(users.Password);

                SendEmail sendEmail = new SendEmail();
                bool isSuccess = await sendEmail.UserSendEmail(users);
                if(isSuccess)
                {
                    await _entityRepository.Add(users);

                    return "Sign Up is Succeeded.Please check your email.";
                }
                else
                {
                    return "Email cannot been send.Please check your email address.";
                }
            }

            else 
                return "This email is already avaliable!";


        }

        public async Task<bool> ApproveUser(int userId, string code)
        {
            var user = await _entityRepository.Get(o => o.Id.Equals(userId));

            if (user.ApprovedCode.Equals(code))
            {

                user.isApproved = true;
                await _entityRepository.Update(user);
                return true;

            }
            else
            {
                user.isDeleted= true;
                return false;
            }    
        }


        public async Task<bool> Login(string email, string password)
        {
            var result = _entityRepository.Get(o => o.Email.Equals(email) && o.Password.Equals(Crypt.base64Encode(password)) && !o.isDeleted && o.isApproved).Result;

            if (result == null) return false;

            else return true;

        }

        public async Task<bool> AdminLogin(string email, string password)
        {
            var result = _entityRepository.Get(o => o.Email.Equals(email) && o.Password.Equals(Crypt.base64Encode(password)) && o.UserType == "Admin" && !o.isDeleted && o.isApproved).Result;

            if (result == null) return false;

            else return true;

        }
        public async Task<bool> ForgetPassword(string email)
        {
            var user = _entityRepository.Get(o => o.Email.Equals(email) && !o.isDeleted && o.isApproved).Result;
            if(user != null)
            {
                var newPassword = CodeGenerator.GeneratorPass();
                SendEmail sendEmail = new SendEmail();
                user.Password = newPassword;
                bool isSuccess = await sendEmail.ForgetPasswordEmail(user);
                if (isSuccess)
                {
                    var passCrypt = Crypt.base64Encode(newPassword);
                    user.Password = passCrypt;
                    await _entityRepository.Update(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            var user = _entityRepository.Get(o => o.Id.Equals(userId) && !o.isDeleted && o.isApproved).Result;
            if (user != null)
            {
                if(Crypt.base64Decode(user.Password).Equals(oldPassword))
                {
                    user.Password = Crypt.base64Encode(newPassword);
                    await _entityRepository.Update(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
