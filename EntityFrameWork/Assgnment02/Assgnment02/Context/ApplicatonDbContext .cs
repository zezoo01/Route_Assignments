using Assgnment02.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


internal class ApplicatonDbContext : DbContext
{
    public DbSet<Organizer> Organizers { get; set; }

    public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<Attendee> Attendees { get; set; }

    public DbSet<Badge> Badges { get; set; }

    public DbSet<Registration> Registrations { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());


        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Title)
                  .HasMaxLength(200)
                  .IsRequired();

            entity.Property(e => e.Description)
                  .HasMaxLength(1000);

            entity.HasOne(e => e.ParentEvent)
                  .WithMany(e => e.Sessions)
                  .HasForeignKey(e => e.ParentEventId)
                  .OnDelete(DeleteBehavior.Restrict);


            entity.Property<DateTime>("CreatedAt");

            entity.Property<DateTime>("LastModifiedAt");
        });


        modelBuilder.Entity<Organizer>()
            .HasOne(o => o.Profile)
            .WithOne(p => p.Organizer)
            .HasForeignKey<OrganizerProfile>(
                p => p.OrganizerId);
    }
}

