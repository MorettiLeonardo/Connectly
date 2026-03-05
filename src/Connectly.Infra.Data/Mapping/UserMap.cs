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

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Address)
                .HasColumnName("Email")
                .IsRequired(true);

            builder.OwnsOne(x => x.Email)
                .OwnsOne(x => x.Verification)
                .Property(x => x.Code)
                .HasColumnName("EmailVerificationCode")
                .IsRequired(true);

            builder.OwnsOne(x => x.Email)
                .OwnsOne(x => x.Verification)
                .Property(x => x.ExpiresAt)
                .HasColumnName("EmailVerificationExpiresAt")
                .IsRequired(false);

            builder.OwnsOne(x => x.Email)
                .OwnsOne(x => x.Verification)
                .Property(x => x.VerifiedAt)
                .HasColumnName("EmailVerificationVerifiedAt")
                .IsRequired(false);

            builder.OwnsOne(x => x.Email)
                .OwnsOne(x => x.Verification)
                .Ignore(x => x.IsActive);

            builder.OwnsOne(x => x.Password)
                .Property(x => x.Hash)
                .HasColumnName("PasswordHash")
                .IsRequired();

            builder.OwnsOne(x => x.Password)
                .Property(x => x.ResetCode)
                .HasColumnName("PasswordResetCode")
                .IsRequired();
            builder.Property(u => u.Bio)
                   .HasMaxLength(500);

            builder.Property(u => u.AvatarUrl)
                   .HasMaxLength(255);

            builder.HasMany(u => u.Following)
                .WithOne(f => f.Follower)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Followers)
                   .WithOne(f => f.Following)
                   .HasForeignKey(f => f.FollowingId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(u => u.Following)
                   .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(u => u.Followers)
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
