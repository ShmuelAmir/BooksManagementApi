using Microsoft.EntityFrameworkCore;
using BooksManagementApi.Models;
using BooksManagementApi.Services;

// ----Test ImaggaService----
//var imaggaService = new ImaggaService();
//var tags = await imaggaService.GetTags("https://www.imagga.com/static/images/tagging/wind-farm-538576_640.jpg");
//foreach (var tag in tags)
//{
//    Console.WriteLine($"{tag.Tag} - {tag.Confidence}");
//}
// ----/Test ImaggaService----

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<OpenLibraryService>();
builder.Services.AddScoped<ImaggaService>();

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


