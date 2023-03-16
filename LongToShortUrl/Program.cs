using LongToShortUrl.Data.Context;
using LongToShortUrl.Data.Repo;
using LongToShortUrl.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});
builder.Services.AddControllers();

builder.Services.AddTransient<IURLShortenerRepository, URLShortenerRepository>();
builder.Services.AddTransient<IURLShortenerService, URLShortenerService>();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    db.Database.EnsureCreated();
}



app.UseRouting();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=URLShortener}/{action=Index}/{id?}");
});

app.UseHttpsRedirection();

app.Run();

