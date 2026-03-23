using Connectly.Domain.Contexts.Entities.Users;

namespace Connectly.Infra.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    namespace Connectly.Infra.Data.Mapping
    {
        internal class UserMap : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.ToTable("Users");

                builder.HasKey(u => u.Id);

                builder.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                builder.Property(u => u.Bio)
                    .HasMaxLength(500);

                builder.Property(u => u.AvatarUrl)
                    .HasMaxLength(2048);

                builder.HasMany(u => u.Following)
                    .WithOne(f => f.Follower)
                    .HasForeignKey(f => f.FollowerId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(u => u.Followers)
                    .WithOne(f => f.Following)
                    .HasForeignKey(f => f.FollowingId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}
