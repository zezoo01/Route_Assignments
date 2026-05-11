using Assgnment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgnment02.Context.Confguratons
{
    internal class AttendeeConfiguration : IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.Property(a => a.FullName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.Email)
                   .HasMaxLength(150);

            builder.OwnsOne(a => a.Address);
        }
    }
}
