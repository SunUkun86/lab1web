using lab1.app.Data;
using lab1.app.Data.Models;
using lab1.app.Extensions;
using lab1.app.Interfaces;
using lab1.app.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddServices();

var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Redirect("/Index");
});

app.MapPost("/AddFilm", async (HttpContext context, IFilmService filmService) =>
{
    var form = await context.Request.ReadFormAsync();
    string name = form["name"]!;
    string description = form["description"]!;

    var newFilm = new Film { Name = name, Description = description };
    await filmService.AddFilmAsync(newFilm);

    return Results.Redirect("/Index");
});

app.UseMiddleware<CinemaMiddleware>();

app.MapRazorPages();

app.Run();
