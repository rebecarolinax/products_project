using Microsoft.EntityFrameworkCore;
using webapi.productsproject.Context;
using webapi.productsproject.Interfaces;
using webapi.productsproject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Dependency injections
builder.Services.AddScoped<IProducts, ProductsRepository>();

// Add services to the container.

builder.Services.AddControllers();
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
