using EF02.Models;
using Microsoft.EntityFrameworkCore;

namespace EF02.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ✅ FIXED CONNECTION STRING
            optionsBuilder.UseSqlServer("Server=.;Database=EventHubDB;Trusted_Connection=True;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 1-to-1: Organizer ↔ Profile
            modelBuilder.Entity<Organizer>()
                .HasOne(o => o.Profile)
                .WithOne(p => p.Organizer)
                .HasForeignKey<Profile>(p => p.OrganizerId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region 1-to-1: Attendee ↔ Badge
            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.Badge)
                .WithOne(b => b.Attendee)
                .HasForeignKey<Badge>(b => b.AttendeeId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region 1-to-Many: Organizer → Events
            modelBuilder.Entity<Organizer>()
                .HasMany(o => o.Events)
                .WithOne(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region 1-to-Many: Event → Sessions
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Sessions)
                .WithOne(s => s.Event)
                .HasForeignKey(s => s.EventId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}