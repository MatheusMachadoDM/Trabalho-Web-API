using Microsoft.EntityFrameworkCore;

using API.Models;

public class AppDataContext : DbContext{
    //herda DbContext (representa o banco de dados)
    public DbSet<Quarto> Quartos { get; set; }
    //tabela Quartos
    public DbSet<Reserva> Reservas { get; set; }
    //tabela Reservas 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Data Source=hotel.db");
        //definindo qual banco utilizar(quando o comando "dotnet ef database update" for rodado, esse banco deve ser criado automáticamente)
    }
}