using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.UserReservations);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Clients)
                .WithMany(c => c.ClientReservations)
                .UsingEntity(rc => rc.ToTable("ReservationsClients"));

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Rooms)
                .WithMany(rm => rm.RoomReservations)
                .UsingEntity(rr => rr.ToTable("ReservationsRooms"));
        }
    }
}
