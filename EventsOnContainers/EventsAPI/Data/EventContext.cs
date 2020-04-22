using EventsAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        {   }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<EventType>(e =>
            {
                e.ToTable("EventTypes");

                e.Property(b => b.Id)
                .IsRequired()
                .UseHiLo("event_use_hilo");

                e.Property(b => b.Type)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<EventDetail>(e =>
            {
                e.ToTable("Events");

                e.Property(b => b.ID)
                .IsRequired()
                .UseHiLo("Event_Hilo");

               /* e.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(200);*/
               
               /* e.Property(b => b.Venue)
                .IsRequired()
                .HasMaxLength(100);*/

               e.Property(b => b.Price)
                .IsRequired();

             /*   e.Property(b => b.Occupancy)
                .IsRequired(); */

               /* e.Property(b => b.Age)
                .IsRequired()
                .HasMaxLength(100);*/

                e.Property(b => b.Date)
                .IsRequired()
                .HasMaxLength(100);

                e.HasOne(c => c.EventType)
                .WithMany()
                .HasForeignKey(c=> c.EventTypeID);
               
            }); 
        }
    }
}
