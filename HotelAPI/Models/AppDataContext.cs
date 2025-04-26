using System;
using Microsoft.EntityFrameworkCore;

using HotelAPI.Models;

public class AppDataContext : DbContext
{
    public DbSet<Hospede> Hospedes { get; set; }
    public DbSet<Reserva> Reservas { get; set; } 
    public DbSet<Quarto> Quartos{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Hotel.db");
    }
}