using LockdownPubQuiz.DAL.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace LockdownPubQuiz.DAL.Configurations
{
    public class LockdownPubQuizDbContext : IdentityDbContext<ApplicationUser>
    {
        public LockdownPubQuizDbContext(DbContextOptions<LockdownPubQuizDbContext> options) : base(options) { }
    }

  

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LockdownPubQuizDbContext>
    {
        public LockdownPubQuizDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<LockdownPubQuizDbContext>();
            var connectionString = configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            builder.UseSqlServer(connectionString);
            return new LockdownPubQuizDbContext(builder.Options);
        }
    }
}