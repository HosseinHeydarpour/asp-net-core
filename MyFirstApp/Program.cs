using Microsoft.Extensions.Primitives;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// enable routing
app.UseRouting();

// creating end-points
app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{fileName}.{fileExtension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["fileName"]);
        string? fileExtension = Convert.ToString(context.Request.RouteValues["fileExtension"]);
        await context.Response.WriteAsync($"In Files | requested file name: '{fileName}' | requested file extension: '{fileExtension}'");
    });


    endpoints.Map("employee/profile/{employeeName}", async (context) =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);

        await context.Response.WriteAsync($"In Employee profile | requested employee name: '{employeeName}'");
    });

   
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request recieved at {context.Request.Path}");
});

app.Run();
