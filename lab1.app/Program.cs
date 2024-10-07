using lab1.app.Data;
using lab1.app.Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CinemaDbContext>(opt => 
opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CinemaWebDb;Integrated Security=True;TrustServerCertificate=True"));
var app = builder.Build();

app.MapGet("/Home", async (CinemaDbContext dbContext) =>
{
    var films = await dbContext.Films.ToListAsync();

    string html = "<html><head><title>Film List</title></head><body>";
    html += "<h1>Film List</h1>";
    html += "<table border='1'>";
    html += "<tr><th>Id</th><th>Name</th><th>Description</th></tr>";

    foreach (var film in films)
    {
        html += $"<tr><td>{film.Id}</td><td>{film.Name}</td><td>{film.Description}</td></tr>";
    }

    html += "</table>";
    html += "</body></html>";

    return Results.Content(html, "text/html");
});
app.MapGet("/AddFilm", () =>
{
    string html = "<html><head><title>Add New Film</title></head><body>";
    html += "<h1>Add New Film</h1>";
    html += "<form method='post' action='/AddFilm'>";
    html += "<label for='name'>Name:</label><br>";
    html += "<input type='text' id='name' name='name'><br>";
    html += "<label for='description'>Description:</label><br>";
    html += "<input type='text' id='description' name='description'><br><br>";
    html += "<input type='submit' value='Add'>";
    html += "</form>";
    html += "</body></html>";

    return Results.Content(html, "text/html");
});
app.MapPost("/AddFilm", async (HttpContext context, CinemaDbContext dbContext) =>
{
    var form = await context.Request.ReadFormAsync();
    string name = form["name"]!;
    string description = form["description"]!;

    var newFilm = new Film { Name = name, Description = description };
    dbContext.Films.Add(newFilm);
    await dbContext.SaveChangesAsync();

    return Results.Redirect("/Home");
});

app.Run();
