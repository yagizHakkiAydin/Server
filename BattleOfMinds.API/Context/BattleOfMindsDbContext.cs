using BattleOfMinds.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;

namespace BattleOfMinds.API.Context
{
    public class BattleOfMindsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=BattleOfMindsPc;Database=BattleOfMindsDb;User Id=sa;Password=Bom_123.!;Trust Server Certificate=True;");
            dbContextOptionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.StateChanged,
                                                           CoreEventId.DetectChangesCompleted,
                                                           CoreEventId.DetectChangesStarting,
                                                           CoreEventId.StartedTracking,
                                                           CoreEventId.MultipleNavigationProperties,
                                                           CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning,
                                                           CoreEventId.SensitiveDataLoggingEnabledWarning,
                                                           CoreEventId.ContextInitialized,
                                                           SqlServerEventId.DecimalTypeDefaultWarning,
                                                           RelationalEventId.BoolWithDefaultWarning
                                                         ));
            base.OnConfiguring(dbContextOptionsBuilder);

        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Competitions>().HasMany(c => c.currentUsers);
        //    modelBuilder.Entity<Competitions>().HasMany(c => c.askedQuestions);

        //}

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Competitions> Competitions { get; set; }
        public virtual  DbSet<QuestionCategories> QuestionCategories { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }

}
}
