using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>

    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext")

    ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found."

    )));


// Seleccion del Sistema Gestor de Base de datos, dependiendo del entorno en el que estemos
if (builder.Environment.IsDevelopment())
{

    // si estamos el entorno de desarollo usamos SQLite
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext"));
    });
}
else
{
    // Si estamos en produccion usamos SQL Server

    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMovieContext"));
    });
}

var app = builder.Build();


// Seed the database
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
/*
 * In the previous code, Program.cs has been modified to do the following:
 * Get a database context instance from the dependency injection (DI) container.
 * Call the seedData.Initialize method, passing to it the database context instance.
 * Dispose the context when the seed method completes.
 *
 * The using statement ensures the context is disposed.
*/


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
