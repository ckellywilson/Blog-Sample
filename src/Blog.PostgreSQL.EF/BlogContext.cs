using Blog.Domain;
using Blog.PostgreSQL.EF.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Blog.PostgreSQL.EF
{
    public class BlogContext : DbContext
    {
        /// <summary>
        ///     New <see cref="BlogContext" />
        /// </summary>
        /// <param name="options">Instance of <see cref="DbContextOptions{TContext}" /></param>
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BlogPostEntityTypeConfiguration());
        }
    }
}