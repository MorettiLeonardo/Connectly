using Connectly.Domain.Entities;
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

            builder.Property(u => u.Id)
                   .ValueGeneratedNever();

            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.Property(u => u.UpdatedAt)
                   .IsRequired();

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.Password)
                   .IsRequired();

            builder.Property(u => u.Bio)
                   .HasMaxLength(500);

            builder.Property(u => u.AvatarUrl)
                   .HasMaxLength(300);

            // Quem EU sigo
            builder.HasMany(u => u.Following)
                   .WithOne(f => f.Follower)
                   .HasForeignKey(f => f.FollowerId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Quem me segue
            builder.HasMany(u => u.Followers)
                   .WithOne(f => f.Following)
                   .HasForeignKey(f => f.FollowingId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
