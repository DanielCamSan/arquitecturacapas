var builder = WebApplication.CreateBuilder(args);
//dotnet add package Swashbuckle.AspNetCore


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Dependency Injection
builder.Services.AddScoped<GoodRepository.Repositories.IBookRepository, GoodRepository.Repositories.BookRepository>();
builder.Services.AddScoped<GoodRepository.Services.IBookService, GoodRepository.Services.BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Products API v1");
        options.RoutePrefix = "swagger"; // UI en /swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
