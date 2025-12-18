using Connectly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectly.Infra.Data.Mapping
{
    internal class LikeMap : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            // Tabela
            builder.ToTable("Likes");

            // BaseEntity
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                   .ValueGeneratedNever();

            builder.Property(l => l.CreatedAt)
                   .IsRequired();

            builder.Property(l => l.UpdatedAt)
                   .IsRequired();

            // Propriedades
            builder.Property(l => l.PostId)
                   .IsRequired();

            builder.Property(l => l.UserId)
                   .IsRequired();

            // Relacionamento: Like -> Post
            builder.HasOne(l => l.Post)
                   .WithMany(p => p.Likes)
                   .HasForeignKey(l => l.PostId);
        }
    }
}
