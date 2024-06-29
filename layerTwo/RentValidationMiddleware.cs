using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System;
using System.Threading.Tasks;
using layerOne.models;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Newtonsoft.Json;
using layerTwo.Interfaces;

public class RentValidationMiddleware
{
    private readonly RequestDelegate _next;

    public RentValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Method == "POST" && context.Request.Path.StartsWithSegments("/Rent"))
        {
            //var body = context.Request.Body;
            //context.Request.Body.Seek(0, SeekOrigin.Begin);
            //var reader = new StreamReader(body);
            //var bodyContent = await reader.ReadToEndAsync();
            //context.Request.Body.Seek(0, SeekOrigin.Begin);

            var body = await new System.IO.StreamReader(context.Request.Body).ReadToEndAsync();

            var rent = JsonConvert.DeserializeObject<Rent>(body);

            if (rent != null)
            {
                var bookService = context.RequestServices.GetService<IBookService>();
                var books = await bookService.GetAllBooksAsync();
                var book = books.FirstOrDefault(b => b.BookId == rent.BookId);

                if (book == null)
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync("Book not found.");
                    return;
                }

                if (book.DateOfCut.HasValue)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Book is cut.");
                    return;
                }

                var rentService = context.RequestServices.GetService<IRentService>();
                var rents = await rentService.GetAll();
                var existingRents = rents.Where(r => r.BookId == rent.BookId);

                foreach (var existingRent in existingRents)
                {
                    if (existingRent.DateOff == null)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Book is already rented.");
                        return;
                    }

                    if (rent.Date >= existingRent.Date && rent.Date < existingRent.DateOff)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Rental periods overlap.");
                        return;
                    }
                }
            }
        }

        await _next(context);
    }
}

public static class RentValidationMiddlewareExtensions
{
    public static IApplicationBuilder UseRentValidationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RentValidationMiddleware>();
    }
}