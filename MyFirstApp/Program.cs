using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);




var app = builder.Build();

// Middleware 1 Lambda expression - app.use - pay attention to app.run and app.use and the difference of them
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello MIDDLEWARE 1 \n");
    await next(context);
});

// Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello MIDDLEWARE 2 \n");
    // await next(context); with this middleware 2 will be the terminating middleware
});

// Middleware 3 - app.run is short circut middleware or terminating middleware - it will not send context to next middleware
// It terminates the middleware pipe
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello MIDDLEWARE 3");
});

app.Run();
