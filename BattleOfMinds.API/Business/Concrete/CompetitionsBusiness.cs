using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Core.Entity;
using BattleOfMinds.Models.Models;
using System.Linq.Expressions;

namespace BattleOfMinds.API.Business
{
    public class CompetitionsBusiness : ICompetitionBusiness
    {

        private readonly IEntityRepository<Competitions> _entityRepository;
        private readonly IEntityRepository<Users> _usersEntityRepository;

        public CompetitionsBusiness(IEntityRepository<Competitions> entityRepository, IEntityRepository<Users> usersEntityRepository)
        {
            _entityRepository = entityRepository;
            _usersEntityRepository = usersEntityRepository;
        }

        public Task<Competitions> Add(Competitions Entity)
        {

            return _entityRepository.Add(Entity);
        }

        public async Task<Competitions> Get(Expression<Func<Competitions, bool>> filter = null, params Expression<Func<Competitions, object>>[] includes)
        {
            var result =  _entityRepository.Get(filter, includes).Result;
            return result;
        }

        public async Task<List<Competitions>> GetAll(Expression<Func<Competitions, bool>> filter = null, params Expression<Func<Competitions, object>>[] includes)
        {
            List<Competitions> questions = new List<Competitions>();

            return await _entityRepository.GetAll(filter,includes);

        }

        public Task<Competitions> Update(Competitions Entity)
        {
            return _entityRepository.Update(Entity);
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

    }
}
