using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.PostgreSQL.EF.EntityConfigurations
{
    public class BlogPostEntityTypeConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable("blog_post").HasKey(p => p.Id).HasName("blog_post_pkey");
            builder.Property(p => p.Id).UseSerialColumn().HasColumnName("blog_post_id");
            builder.Property(p => p.BlogPostComment).HasColumnType("text").HasColumnName("blog_post_comment").IsRequired();
            builder.Property(p => p.BlogPostDate).HasColumnType("timestamp with time zone").HasColumnName("blog_post_date")
                .IsRequired();
            builder.Property(p => p.BlogEntryId).HasColumnName("blog_entry_id").IsRequired();

            //fk
            builder.HasOne(p => p.BlogEntry).WithMany(p => p.BlogPosts).HasForeignKey(p => p.BlogEntryId)
                .HasConstraintName("blog_post_blog_entry_blog_entry_id_fkey");
        }
    }
}