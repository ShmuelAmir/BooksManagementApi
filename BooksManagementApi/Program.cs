using Microsoft.EntityFrameworkCore;
using BooksManagementApi.Models;
using BooksManagementApi.Commands;
using BooksManagementApi.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));

builder.Services.AddScoped<BookCommands>();
builder.Services.AddScoped<BookQueries>();
builder.Services.AddScoped<OpenLibraryQueries>();
builder.Services.AddScoped<ImaggaQueries>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
