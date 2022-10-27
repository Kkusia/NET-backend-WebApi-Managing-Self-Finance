using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository;
using ManagingSelfFinanceWebAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer("DefaultConnection"));
builder.Services.AddScoped<IRepository<Operation>, OperationRepository>();
builder.Services.AddScoped<IRepository<RegisterOperation>, RegisterOperationRepository>();
builder.Services.AddScoped<IRepository<TypeOperation>, TypeOperationRepository>();
builder.Services.AddScoped<IRepository<Report>, ReportRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
