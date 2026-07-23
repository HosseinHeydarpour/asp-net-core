using Microsoft.Extensions.Primitives;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// enable routing
app.UseRouting();

// creating end-points
app.UseEndpoints(endpoints =>
{
    // add your end points - all methods which start with Map
    endpoints.MapGet("/map1", async (context) => await context.Response.WriteAsync("Map1 Route Enabled"));

    endpoints.MapPost("/map2", async (context) => await context.Response.WriteAsync("Map2 Route Enabled"));

   
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request recieved at {context.Request.Path}");
});

app.Run();
