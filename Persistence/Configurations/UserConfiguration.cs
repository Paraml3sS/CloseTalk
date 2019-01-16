using CloseTalk.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloseTalk.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(e => e.UserName).IsUnique()
                .HasName("UniqueKey_UserName");

            builder.Property(e => e.UserId)
                .UseSqlServerIdentityColumn()
                .HasMaxLength(6);

            builder.Property(e => e.FirstName)
                .HasMaxLength(20);

            builder.Property(e => e.LastName)
                .HasMaxLength(30);

            builder.Property(e => e.DoB)
                .HasColumnType("datetime");

            builder.Property(e => e.UserName)
                .HasMaxLength(15);

            builder.Property(e => e.EmailAddress)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.AccountRegistered)
                .HasDefaultValueSql("getdate()");
        }
    }
}
