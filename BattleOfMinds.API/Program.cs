using BattleOfMinds.API.Business;
using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Core.EntityFramework;
using BattleOfMinds.Models.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IQuestionCategoriesBusiness, QuestionCategoriesBusiness>();
builder.Services.AddScoped<IEntityRepository<QuestionCategories>, EntityRepository<QuestionCategories, BattleOfMindsDbContext>>();
builder.Services.AddScoped<IEntityRepository<Questions>, EntityRepository<Questions, BattleOfMindsDbContext>>();
builder.Services.AddScoped<IQuestionsBusiness, QuestionsBusiness>();
builder.Services.AddScoped<IQuestionTypeBusiness, QuestionTypeBusiness>();
builder.Services.AddScoped<IEntityRepository<QuestionType>, EntityRepository<QuestionType, BattleOfMindsDbContext>>();
builder.Services.AddScoped<IUsersBusiness, UsersBusiness>();
builder.Services.AddScoped<IEntityRepository<Users>, EntityRepository<Users, BattleOfMindsDbContext>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
