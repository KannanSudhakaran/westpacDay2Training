using Lab03ProductMinimalAPI.Data;
using Lab03ProductMinimalAPI.Model;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "This is WestPac Az2002 workshop Docs",
        Description = "Api for testing products and quick Poc using minimal apis"
    });

}

    );

builder.Services.AddDbContext<ProductDbContext>(options =>
{

    options.UseInMemoryDatabase("ProductDB");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/v1/products", async (ProductDbContext dbContext) =>
{
    return await dbContext.Products.ToListAsync();

}).WithTags("All Products Tag");

app.MapGet("/api/v1/products/{productId}", async (ProductDbContext dbContext, int productId) =>
{
    return await dbContext.Products.FindAsync(productId);

}).WithTags("Single Products Tag");

app.MapPost("/api/v1/products", async (ProductDbContext dbContext, Product product) =>
{
    dbContext.Products.Add(product);
    await dbContext.SaveChangesAsync();
    return Results.Created();
}).WithTags("Add a prodcut");

app.MapPut("/api/v1/products/{productId}", async (ProductDbContext dbContext, int productId, Product product) =>
{
    if (productId != product.Id)
        return Results.BadRequest("product id mismtach");

    dbContext.Entry(product).State = EntityState.Modified;
    await dbContext.SaveChangesAsync();
    return Results.NoContent();


}).WithTags("Update a Product");


app.MapDelete("/api/v1/products/{productId}", async (ProductDbContext dbcontext, int productId) =>
{

    if (await dbcontext.Products.FindAsync(productId) is Product p)
    {

        dbcontext.Products.Remove(p);
        await dbcontext.SaveChangesAsync();
        return Results.Ok(p.Id);
    }
    return Results.NotFound();
}).WithTags("Delete a product");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
