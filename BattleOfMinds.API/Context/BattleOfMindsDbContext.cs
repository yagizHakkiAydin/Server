
using BattleOfMinds.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleOfMinds.API.Context
{
    public class BattleOfMindsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=20.223.182.23;Database=BattleOfMindsDb;User Id=sa;Password=Bom_123.!;Trust Server Certificate=True;");
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Competitions> Competitions { get; set; }
        public DbSet<CompetitionUsers> CompetitionUsers { get; set; }
        public DbSet<QuestionCategories> QuestionCategories { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }

    }
}
