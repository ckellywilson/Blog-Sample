using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.PostgreSQL.EF.EntityConfigurations
{
    public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<BlogEntry>
    {
        public void Configure(EntityTypeBuilder<BlogEntry> builder)
        {
            builder.ToTable("blog_entry").HasKey(p => p.Id).HasName("blog_entry_pk");
            builder.Property(p => p.Id).UseSerialColumn().HasColumnName("blog_entry_id");
            builder.Property(p => p.BlogEntryName).HasColumnType("varchar(256)").HasColumnName("blog_entry_name").IsRequired();
            builder.HasIndex(p => p.BlogEntryName).IsUnique().HasName("blog_entry_blog_name_uc");
            builder.Property(p => p.BlogEntryDate).HasColumnType("timestamp with time zone").HasColumnName("blog_entry_date")
                .IsRequired();
        }
    }
}