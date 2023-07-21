using Biblioteca.Repositories;
using Biblioteca.Services;
using Microsoft.EntityFrameworkCore;
using BibliotecaDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BibliotecaContext>(options => {
    options.
    UseSqlServer(builder.Configuration.GetConnectionString("BibliotecaConnection")); });
// Dependencias para las interfaces y repositorios correspondientes
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<ISalonRepository, SalonRepository>();
builder.Services.AddScoped<IEstanteriaRepository, EstanteriaRepository>();
builder.Services.AddScoped<IEstanteRepository, EstanteRepository>();
builder.Services.AddScoped<ISeccionRepository, SeccionRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();
builder.Services.AddScoped<IPrestamoLibroRepository, PrestamoLibroRepository>();

// Dependencias para los servicios correspondientes
builder.Services.AddScoped<LibroService>();
builder.Services.AddScoped<SalonService>();
builder.Services.AddScoped<EstanteriaService>();
builder.Services.AddScoped<EstanteService>();
builder.Services.AddScoped<SeccionService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PrestamoService>();
builder.Services.AddScoped<PrestamoLibroService>();
builder.Services.AddScoped<IUbicacionService, UbicacionService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BibliotecaContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
