// Data/HotelConsagradoDbContext.cs
using Microsoft.EntityFrameworkCore;
using HotelConsagradoAPI.Models;

namespace HotelConsagradoAPI.Data
{
    public class HotelConsagradoDbContext : DbContext
    {
        public HotelConsagradoDbContext(DbContextOptions<HotelConsagradoDbContext> options) : base(options)
        {
        }

        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Hospede> Hospedes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>()
                .HasMany(r => r.Hospedes)
                .WithOne(h => h.Reserva)
                .HasForeignKey(h => h.ReservaId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}