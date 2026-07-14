using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Middleware Lambda expression 1 (Executes and terminates pipeline)
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello MIDDLEWARE");
});

// Middleware Lambda expression 2 (WILL NEVER EXECUTE)
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello MIDDLEWARE 2");
});

app.Run();
