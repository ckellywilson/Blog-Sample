using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Blog.PostgreSQL.EF
{
    public class BlogContextDesignTimeFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        //private const string _connectionString = "server=localhost;database=blog;username=postgres;password=postgres";

        public BlogContext CreateDbContext(string[] args)
        {
            var connectionString = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build()
                .GetConnectionString("blog");
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new BlogContext(optionsBuilder.Options);
        }
    }
}