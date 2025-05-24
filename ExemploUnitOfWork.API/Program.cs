using ExemploUnitOfWork.API.Context;
using ExemploUnitOfWork.API.Interfaces.Services;
using ExemploUnitOfWork.API.Interfaces;
using ExemploUnitOfWork.API.Services;
using ExemploUnitOfWork.API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro dos servi�os
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClienteService, ClienteService>();

// Configura��o da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();