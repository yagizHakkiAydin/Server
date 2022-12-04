﻿using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Models.Models;
using System.Linq.Expressions;

namespace BattleOfMinds.API.Business.Abstract
{
    public interface IQuestionTypeBusiness : IEntityRepository<QuestionType>
    {
        public Task<QuestionType> Add(QuestionType Entity);
        public Task<QuestionType> Get(Expression<Func<QuestionType, bool>> filter = null);
        public Task<List<QuestionType>> GetAll(Expression<Func<QuestionType, bool>> filter = null);
        public Task<QuestionType> Update(QuestionType Entity);
    }
}
