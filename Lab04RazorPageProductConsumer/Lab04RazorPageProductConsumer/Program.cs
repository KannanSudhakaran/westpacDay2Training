var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient("remoteApiFactory", 
    client => {

        client.BaseAddress = new Uri("https://apibackend-westpack-2025.azurewebsites.net/");

});

builder.Services.AddHttpClient("localApiFactory",
    client => {

        client.BaseAddress = new Uri("https://localhost:7016/");

    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
