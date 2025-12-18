using Connectly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectly.Infra.Data.Mapping
{
    public class FollowMap : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("Follows");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                   .ValueGeneratedNever();

            builder.Property(f => f.CreatedAt)
                   .IsRequired();

            builder.Property(f => f.UpdatedAt)
                   .IsRequired();

            builder.Property(f => f.FollowerId)
                   .IsRequired();

            builder.Property(f => f.FollowingId)
                   .IsRequired();
        }
    }
}
