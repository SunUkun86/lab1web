using lab1.app.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab1.app.Middleware
{
    public class CinemaMiddleware
    {
        private readonly RequestDelegate _next;

        public CinemaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICinemaService cinemaService)
        {
            if (context.Request.Path == "/Cinemas")
            {
                var cinemas = cinemaService.GetAllCinemas();

                string html = "<html><head><title>Cinema List</title></head><body>";
                html += "<h1>Cinema List</h1>";
                html += "<table border='1'>";
                html += "<tr><th>Id</th><th>Name</th><th>Address</th></tr>";

                foreach (var cinema in cinemas)
                {
                    html += $"<tr><td>{cinema.Id}</td><td>{cinema.Name}</td><td>{cinema.Adress}</td></tr>";
                }

                html += "</table>";
                html += "</body></html>";

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(html);
            }
            else
            {
                await _next(context);
            }
        }
    }
}
