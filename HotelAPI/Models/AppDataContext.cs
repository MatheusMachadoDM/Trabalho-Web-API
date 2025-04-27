using System;
using Microsoft.EntityFrameworkCore;

using HotelAPI.Models;

public class AppDataContext : DbContext
{
    public DbSet<Hospede> Hospedes { get; set; }
    public DbSet<Reserva> Reservas { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Hotel.db");
    }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar a relação entre Hospede e Reserva
        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Hospede) // Uma reserva possui um Hospede
            .WithMany(h => h.Reservas) // Um hospede pode ter várias reservas
            .HasForeignKey(r => r.HospedeId); // Chave estrangeira 
    }
}