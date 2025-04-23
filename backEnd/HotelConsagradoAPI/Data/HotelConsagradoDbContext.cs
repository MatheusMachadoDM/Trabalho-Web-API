using Microsoft.EntityFrameworkCore;
using HotelConsagradoAPI.Models;

namespace HotelConsagradoAPI.Data
{
    public class HotelConsagradoDbContext : DbContext
    {
        public HotelConsagradoDbContext(DbContextOptions<HotelConsagradoDbContext> options) : base(options)
        {
        }

        // Representa a tabela de Reservas no banco de dados.
        public DbSet<Reserva> Reservas { get; set; }

        // Representa a tabela de Hospedes no banco de dados.
        public DbSet<Hospede> Hospedes { get; set; }

        // Método chamado durante a criação do modelo do banco de dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o relacionamento um-para-muitos entre Reserva e Hospede.
            modelBuilder.Entity<Reserva>()
                .HasMany(r => r.Hospedes)
                .WithOne(h => h.Reserva)
                .HasForeignKey(h => h.ReservaId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}