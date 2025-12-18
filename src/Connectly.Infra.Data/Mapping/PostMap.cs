using Connectly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectly.Infra.Data.Mapping
{
    internal class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            // BaseEntity
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedNever();

            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.Property(p => p.UpdatedAt)
                   .IsRequired();

            // Propriedades do Post
            builder.Property(p => p.Content)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(p => p.UserId)
                   .IsRequired();

            // Relacionamento: Post -> User
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(p => p.UserId);

            // Relacionamento: Post -> Comments
            builder.HasMany(p => p.Comments)
                   .WithOne(c => c.Post)
                   .HasForeignKey(c => c.PostId);

            // Relacionamento: Post -> Likes
            builder.HasMany(p => p.Likes)
                   .WithOne(l => l.Post)
                   .HasForeignKey(l => l.PostId);
        }
    }
}
