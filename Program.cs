using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using static HelloWorld.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure EF Core with in-memory database
builder.Services.AddDbContext<CityContext>(options =>
    options.UseInMemoryDatabase("CityDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cities}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CityContext>();
    context.Cities.AddRange(
        new City { Name = "New York", Country = "USA", Population = 8419600 },
        new City { Name = "Tokyo", Country = "Japan", Population = 13929286 },
        new City { Name = "London", Country = "UK", Population = 8982000 }
    );
    context.SaveChanges();
}


app.Run();
