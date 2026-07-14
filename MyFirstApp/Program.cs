using Microsoft.Extensions.Primitives;
using MyFirstApp.CustomMiddleware;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();



var app = builder.Build();

// Middleware 1 Lambda expression - app.use - pay attention to app.run and app.use and the difference of them
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello MIDDLEWARE 1 \n");
    await next(context);
});


// Middle ware 2
//app.UseMiddleware<MyCustomMiddleware>();
// This is an extension method - we used it instead of app.UseMiddleware<MyCustomMiddleware>();
app.UseMyCustomMiddleware();




// Middleware 3 - app.run is short circut middleware or terminating middleware - it will not send context to next middleware
// It terminates the middleware pipe
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello MIDDLEWARE 3 \n");
});

app.Run();
