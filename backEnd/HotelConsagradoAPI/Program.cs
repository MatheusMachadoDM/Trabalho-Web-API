using Microsoft.EntityFrameworkCore;
using HotelConsagradoAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Esta seção configura as ferramentas e funcionalidades que a nossa aplicação vai usar.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("null") // Permite requisições da origem 'null' (arquivos locais)
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
// Adiciona os serviços necessários para gerar a documentação da nossa API usando o Swagger/OpenAPI.
// Isso permite que outras pessoas (ou outros sistemas) entendam como usar a nossa API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelConsagradoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Constrói a aplicação web com todos os serviços que configuramos.
var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(); // Adicione esta linha para servir arquivos estáticos da pasta wwwroot

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();