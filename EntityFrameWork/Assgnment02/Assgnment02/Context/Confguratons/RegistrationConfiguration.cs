using Assgnment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgnment02.Context.Confguratons
{
    internal class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(r =>
                new
                {
                    r.AttendeeId,
                    r.EventId
                });

            builder.Property(r => r.Note)
                   .HasMaxLength(300);

            builder.Property(r => r.RegisteredAt)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
