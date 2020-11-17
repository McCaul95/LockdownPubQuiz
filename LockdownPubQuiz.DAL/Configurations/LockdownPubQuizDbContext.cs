using LockdownPubQuiz.DAL.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LockdownPubQuiz.Core.Repositories;
using LockdownPubQuiz.Core;
using Microsoft.AspNetCore.Identity;

namespace LockdownPubQuiz.DAL.Configurations
{
    public class LockdownPubQuizDbContext : IdentityDbContext<ApplicationUser>
    {
        public LockdownPubQuizDbContext(DbContextOptions<LockdownPubQuizDbContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameResult> GameResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>();
            modelBuilder.Entity<Answer>();
            modelBuilder.Entity<Player>();
            modelBuilder.Entity<Game>();
            modelBuilder.Entity<GameResult>();
        }
    }



    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LockdownPubQuizDbContext>
    {
        public LockdownPubQuizDbContext CreateDbContext(string[] args)
        {
           
            var builder = new DbContextOptionsBuilder<LockdownPubQuizDbContext>();
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            builder.UseSqlServer(connectionString);
            return new LockdownPubQuizDbContext(builder.Options);
        }
    }
}