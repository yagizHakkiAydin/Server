using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Core.Entity;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace BattleOfMinds.API.Business
{
    public class CompetitionsBusiness : ICompetitionBusiness
    {

        private readonly IEntityRepository<Competitions> _entityRepository;
        private readonly IEntityRepository<Users> _usersEntityRepository;
        private readonly IEntityRepository<Questions> _questionsEntityRepository;
        public CompetitionsBusiness(IEntityRepository<Competitions> entityRepository, IEntityRepository<Users> usersEntityRepository, IEntityRepository<Questions> questionsEntityRepository)
        {
            _entityRepository = entityRepository;
            _usersEntityRepository = usersEntityRepository;
            _questionsEntityRepository= questionsEntityRepository;
        }

        public Task<Competitions> Add(Competitions Entity)
        {

            return _entityRepository.Add(Entity);
        }

        public async Task<Competitions> Get(Expression<Func<Competitions, bool>> filter = null, params Expression<Func<Competitions, object>>[] includes)
        {
            var result = _entityRepository.Get(filter, includes).Result;
            return result;
        }

        public async Task<List<Competitions>> GetAll(Expression<Func<Competitions, bool>> filter = null, params Expression<Func<Competitions, object>>[] includes)
        {
            List<Competitions> questions = new List<Competitions>();

            return await _entityRepository.GetAll(filter, includes);

        }

        public Task<Competitions> Update(Competitions Entity)
        {
            return _entityRepository.Update(Entity);
        }


        public Task<Competitions> Remove(Competitions Entity)
        {

            return _entityRepository.Remove(Entity);

        }



        public async Task<Users> findCompetition(int userId, string GameMode)
        {

            var result = await _entityRepository.Get(o => o.GameMode.Equals(GameMode) && o.isStarted.Equals(false), o => o.currentUsers);

            var user = _usersEntityRepository.Get(o => o.Id.Equals(userId)).Result;

            if (result == null)
            {

                Competitions newCompetition = new Competitions();

                newCompetition.GameMode = GameMode;
                if (GameMode == "OnevsOne") newCompetition.userCapacity = 2;
                else if (GameMode == "BattleRoyals") newCompetition.userCapacity = 20;
                newCompetition.isStarted = false;



                var _newCompetition = await _entityRepository.Add(newCompetition);
                await _entityRepository.Update(_newCompetition);

                await chooseQuestion(_newCompetition.Id);

                user.CompetitionsId = _newCompetition.Id;
               
                await _usersEntityRepository.Update(user);

            }
            else
            {

                result.currentUsers.Add(user);

                user.CompetitionsId = result.Id;

                if (result.userCapacity == result.currentUsers.Count) result.isStarted = true;
                await _entityRepository.Update(result);

            }

            return user;


        }

        public async Task<bool> isStarted(int competitionId)
        {

            var result = _entityRepository.Get(o => o.Id.Equals(competitionId)).Result;
            return result.isStarted;
        }

        public async Task<Questions> chooseQuestion(int competitionId)
        {

            List<Questions> list = await _questionsEntityRepository.GetAll(o => o.isDeleted.Equals(false) && o.isApproved.Equals(true));

            Random rndm = new Random();

            int questionIndex;
            Questions question;

            do
            {
                questionIndex = rndm.Next(0, list.Count);

                question = list.ElementAt(questionIndex);

            } while (question.CompetitionsId != 1);

            question.CompetitionsId = competitionId;

            var result = await _entityRepository.Get(o => o.Id.Equals(competitionId));

            await _questionsEntityRepository.Update(question);

            result.currentQuestionId = question.Id;

            await _entityRepository.Update(result);
            
            return question;
        }


        public async Task<Questions> getQuestion(int competitionId)
        {

            var result = await _entityRepository.Get(o => o.Id.Equals(competitionId));

            return await _questionsEntityRepository.Get(o => o.Id.Equals(result.currentQuestionId));

        }


        public async Task<int> resetCapacity(int competitionId)
        {

            var result = await _entityRepository.Get(o => o.Id.Equals(competitionId), o => o.currentUsers);

            if (result.currentCapacity <= 2) result.currentCapacity = 1;

            else result.currentCapacity = result.currentUsers.Count - (result.currentUsers.Count*2/5);

            await _entityRepository.Update(result);

            return result.currentCapacity;


        }


        public async Task<bool> exitCompetition(int userId)
        {

            var result = await _usersEntityRepository.Get(o => o.Id.Equals(userId));

            result.CompetitionsId = 1;

            await _usersEntityRepository.Update(result);

            return true;

        }


        public async Task<bool> wrongAnswer([FromBody] Users user)
        {

            user.CompetitionsId = 1;
            await _usersEntityRepository.Update(user);
            return true;

        }

        public async Task<bool> trueAnswer([FromBody] Users user)
        {

            var result = await _entityRepository.Get(o => o.Id.Equals(user.CompetitionsId));

            if (result.currentCapacity == 0)
            {

                user.CompetitionsId = 1;
                await _usersEntityRepository.Update(user);
                return false;

            }
            else
            {

                result.currentCapacity -= 1;

                await _entityRepository.Update(result);

                return true;

            }



        }


        public async Task<int> getCurrentCapacity(int competitionId)
        {

            var result = await _entityRepository.Get(o => o.Id.Equals(competitionId));

            return result.currentCapacity;

        }


        public async Task<bool> deleteCompetition(int competitionId)
        {

            var result = await _entityRepository.Get(o => o.Id.Equals(competitionId), o => o.currentUsers, o => o.askedQuestions);

            ICollection<Users> UsersList = result.currentUsers;

            int border = UsersList.Count;

            for (int i = 0; i < border; i++)
            {


                var user = await _usersEntityRepository.Get(o => o.Id.Equals(UsersList.ElementAt(i).Id));
                user.CompetitionsId = 1;
                await _usersEntityRepository.Update(user);

            }

            ICollection<Questions> QuestionsList = result.askedQuestions;

            border = QuestionsList.Count;

            for (int i = 0; i < border; i++)
            {

                var question = await _questionsEntityRepository.Get(o => o.Id.Equals(QuestionsList.ElementAt(i).Id));
                question.CompetitionsId = 1;
                await _questionsEntityRepository.Update(question);

            }
            result.askedQuestions = null;
            result.currentUsers = null;
           var r =  await _entityRepository.Update(result);
           var r1 = await _entityRepository.Remove(result);

            return true;
        }

    }
}
